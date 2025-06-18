using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

public class Polygon : Script
{
    private static Dictionary<int, DynamicZone> zones = new Dictionary<int, DynamicZone>();
    private static int nextZoneId = 1;
    private static Timer fishLimitResetTimer;

    public enum ZoneType
    {
        Yok = 0,
        Balýkçýlýk = 1,
        Güvenli = 2
    }

    public class DynamicZone
    {
        public int Id { get; set; }
        public Vector3 Pos1 { get; set; }
        public Vector3 Pos2 { get; set; }
        public Vector3 Pos3 { get; set; }
        public Vector3 Pos4 { get; set; }
        public ColShape ColShape { get; set; }
        public ZoneType Type { get; set; }
        public int MaxFishLimit { get; set; }
        public int CurrentFishCount { get; set; }
        public DateTime LastResetTime { get; set; }
        public int RequiredLevel { get; set; }

        public DynamicZone(int id, Vector3 pos1, Vector3 pos2, Vector3 pos3, Vector3 pos4, ZoneType type, int maxFishLimit = 100, int requiredLevel = 1)
        {
            Id = id;
            Pos1 = pos1;
            Pos2 = pos2;
            Pos3 = pos3;
            Pos4 = pos4;
            Type = type;
            MaxFishLimit = maxFishLimit;
            CurrentFishCount = 0;
            LastResetTime = DateTime.Now;
            RequiredLevel = requiredLevel;
        }
    }

    [ServerEvent(Event.ResourceStart)]
    public void OnResourceStart()
    {
        try
        {
            CreateZonesTable();
            LoadZonesFromDatabase();
            StartFishLimitResetTimer();
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"Resource start hatasý: {ex.Message}");
        }
    }

    private void StartFishLimitResetTimer()
    {
        try
        {
            // 6 saat = 6 * 60 * 60 * 1000 = 21600000 milisaniye
            fishLimitResetTimer = new Timer(21600000);
            fishLimitResetTimer.Elapsed += OnFishLimitReset;
            fishLimitResetTimer.AutoReset = true;
            fishLimitResetTimer.Enabled = true;
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"Timer baþlatma hatasý: {ex.Message}");
        }
    }

    private async void OnFishLimitReset(object sender, ElapsedEventArgs e)
    {
        try
        {
            foreach (var zone in zones.Values.Where(z => z.Type == ZoneType.Balýkçýlýk))
            {
                zone.CurrentFishCount = 0;
                zone.LastResetTime = DateTime.Now;
                await UpdateFishLimitInDatabase(zone.Id, zone.CurrentFishCount, zone.LastResetTime);
            }
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"Balýk limiti sýfýrlama hatasý: {ex.Message}");
        }
    }

    private void CreateZonesTable()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
            {
                connection.Open();
                string query = @"CREATE TABLE IF NOT EXISTS `dynamic_zones` (
                    `id` INT AUTO_INCREMENT PRIMARY KEY,
                    `pos1_x` FLOAT NOT NULL,
                    `pos1_y` FLOAT NOT NULL,
                    `pos1_z` FLOAT NOT NULL,
                    `pos2_x` FLOAT NOT NULL,
                    `pos2_y` FLOAT NOT NULL,
                    `pos2_z` FLOAT NOT NULL,
                    `pos3_x` FLOAT NOT NULL,
                    `pos3_y` FLOAT NOT NULL,
                    `pos3_z` FLOAT NOT NULL,
                    `pos4_x` FLOAT NOT NULL,
                    `pos4_y` FLOAT NOT NULL,
                    `pos4_z` FLOAT NOT NULL,
                    `zone_type` INT NOT NULL,
                    `max_fish_limit` INT DEFAULT 100,
                    `current_fish_count` INT DEFAULT 0,
                    `last_reset_time` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    `required_level` INT DEFAULT 1,
                    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                string alterQuery = @"
                    ALTER TABLE `dynamic_zones` 
                    ADD COLUMN IF NOT EXISTS `max_fish_limit` INT DEFAULT 100,
                    ADD COLUMN IF NOT EXISTS `current_fish_count` INT DEFAULT 0,
                    ADD COLUMN IF NOT EXISTS `last_reset_time` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    ADD COLUMN IF NOT EXISTS `required_level` INT DEFAULT 1;";

                using (MySqlCommand alterCommand = new MySqlCommand(alterQuery, connection))
                {
                    alterCommand.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"Tablo oluþturma hatasý: {ex.Message}");
        }
    }

    private void LoadZonesFromDatabase()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM dynamic_zones";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        Vector3 pos1 = new Vector3(reader.GetFloat("pos1_x"), reader.GetFloat("pos1_y"), reader.GetFloat("pos1_z"));
                        Vector3 pos2 = new Vector3(reader.GetFloat("pos2_x"), reader.GetFloat("pos2_y"), reader.GetFloat("pos2_z"));
                        Vector3 pos3 = new Vector3(reader.GetFloat("pos3_x"), reader.GetFloat("pos3_y"), reader.GetFloat("pos3_z"));
                        Vector3 pos4 = new Vector3(reader.GetFloat("pos4_x"), reader.GetFloat("pos4_y"), reader.GetFloat("pos4_z"));
                        ZoneType zoneType = (ZoneType)reader.GetInt32("zone_type");

                        int maxFishLimit = reader.IsDBNull("max_fish_limit") ? 100 : reader.GetInt32("max_fish_limit");
                        int currentFishCount = reader.IsDBNull("current_fish_count") ? 0 : reader.GetInt32("current_fish_count");
                        DateTime lastResetTime = reader.IsDBNull("last_reset_time") ? DateTime.Now : reader.GetDateTime("last_reset_time");
                        int requiredLevel = reader.IsDBNull("required_level") ? 1 : reader.GetInt32("required_level");

                        CreateZoneColShape(id, pos1, pos2, pos3, pos4, zoneType, maxFishLimit, currentFishCount, lastResetTime, requiredLevel);

                        if (id >= nextZoneId)
                            nextZoneId = id + 1;
                    }
                }
            }

            NAPI.Util.ConsoleOutput($"Veritabanýndan {zones.Count} bölge yüklendi.");
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"Bölgeleri yükleme hatasý: {ex.Message}");
        }
    }

    private void CreateZoneColShape(int id, Vector3 pos1, Vector3 pos2, Vector3 pos3, Vector3 pos4, ZoneType zoneType, int maxFishLimit = 100, int currentFishCount = 0, DateTime? lastResetTime = null, int requiredLevel = 1)
    {
        try
        {
            List<Vector3> points = new List<Vector3> { pos1, pos2, pos3, pos4 };

            float minX = points.Min(p => p.X);
            float maxX = points.Max(p => p.X);
            float minY = points.Min(p => p.Y);
            float maxY = points.Max(p => p.Y);
            float minZ = points.Min(p => p.Z) - 5f;
            float maxZ = points.Max(p => p.Z) + 10f;

            Vector3 center = new Vector3((minX + maxX) / 2, (minY + maxY) / 2, (minZ + maxZ) / 2);
            float width = maxX - minX;
            float height = maxY - minY;
            float radius = Math.Max(width, height) / 2;

            ColShape colShape = NAPI.ColShape.CreateCylinderColShape(center, radius, (maxZ - minZ));

            DynamicZone zone = new DynamicZone(id, pos1, pos2, pos3, pos4, zoneType, maxFishLimit, requiredLevel);
            zone.CurrentFishCount = currentFishCount;
            zone.LastResetTime = lastResetTime ?? DateTime.Now;
            zone.ColShape = colShape;

            colShape.SetData("ZONE_ID", id);
            colShape.SetData("ZONE_TYPE", zoneType);
            colShape.SetData("REQUIRED_LEVEL", requiredLevel);

            zones.Add(id, zone);
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"ColShape oluþturma hatasý: {ex.Message}");
        }
    }

    private async Task<bool> SaveZoneToDatabase(int id, Vector3 pos1, Vector3 pos2, Vector3 pos3, Vector3 pos4, ZoneType zoneType, int maxFishLimit = 100, int requiredLevel = 1)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
            {
                await connection.OpenAsync();
                string query = @"INSERT INTO dynamic_zones 
                    (id, pos1_x, pos1_y, pos1_z, pos2_x, pos2_y, pos2_z, pos3_x, pos3_y, pos3_z, pos4_x, pos4_y, pos4_z, zone_type, max_fish_limit, current_fish_count, last_reset_time, required_level) 
                    VALUES (@id, @pos1_x, @pos1_y, @pos1_z, @pos2_x, @pos2_y, @pos2_z, @pos3_x, @pos3_y, @pos3_z, @pos4_x, @pos4_y, @pos4_z, @zone_type, @max_fish_limit, @current_fish_count, @last_reset_time, @required_level)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@pos1_x", pos1.X);
                    command.Parameters.AddWithValue("@pos1_y", pos1.Y);
                    command.Parameters.AddWithValue("@pos1_z", pos1.Z);
                    command.Parameters.AddWithValue("@pos2_x", pos2.X);
                    command.Parameters.AddWithValue("@pos2_y", pos2.Y);
                    command.Parameters.AddWithValue("@pos2_z", pos2.Z);
                    command.Parameters.AddWithValue("@pos3_x", pos3.X);
                    command.Parameters.AddWithValue("@pos3_y", pos3.Y);
                    command.Parameters.AddWithValue("@pos3_z", pos3.Z);
                    command.Parameters.AddWithValue("@pos4_x", pos4.X);
                    command.Parameters.AddWithValue("@pos4_y", pos4.Y);
                    command.Parameters.AddWithValue("@pos4_z", pos4.Z);
                    command.Parameters.AddWithValue("@zone_type", (int)zoneType);
                    command.Parameters.AddWithValue("@max_fish_limit", maxFishLimit);
                    command.Parameters.AddWithValue("@current_fish_count", 0);
                    command.Parameters.AddWithValue("@last_reset_time", DateTime.Now);
                    command.Parameters.AddWithValue("@required_level", requiredLevel);

                    await command.ExecuteNonQueryAsync();
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"Veritabanýna kaydetme hatasý: {ex.Message}");
            return false;
        }
    }

    private async Task<bool> UpdateFishLimitInDatabase(int id, int currentFishCount, DateTime lastResetTime)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE dynamic_zones SET current_fish_count = @current_fish_count, last_reset_time = @last_reset_time WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@current_fish_count", currentFishCount);
                    command.Parameters.AddWithValue("@last_reset_time", lastResetTime);
                    await command.ExecuteNonQueryAsync();
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"Balýk limiti güncelleme hatasý: {ex.Message}");
            return false;
        }
    }

    private async Task<bool> UpdateZoneLevelInDatabase(int id, int requiredLevel)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
            {
                await connection.OpenAsync();
                string query = "UPDATE dynamic_zones SET required_level = @required_level WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@required_level", requiredLevel);
                    await command.ExecuteNonQueryAsync();
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"Bölge level güncelleme hatasý: {ex.Message}");
            return false;
        }
    }

    private async Task<bool> DeleteZoneFromDatabase(int id)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM dynamic_zones WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"Veritabanýndan silme hatasý: {ex.Message}");
            return false;
        }
    }

    [Command("bolgeolustur", "~y~[!]~w~: /bolgeolustur [Tip] [Balýk Limiti] [Gerekli Level] (1: Balýkçýlýk, 2: Güvenli Bölge)")]
    public void CreateZone(Player player, int zoneType, int fishLimit = 100, int requiredLevel = 1)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için iþ baþýnda olmalýsýnýz, /aduty komutu ile iþ baþýna geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) <= 7)
        {
            return;
        }

        try
        {
            if (zoneType < 1 || zoneType > 2)
            {
                Main.SendErrorMessage(player, "Geçersiz bölge tipi! 1: Balýkçýlýk, 2: Güvenli Bölge");
                return;
            }

            if (fishLimit < 1 || fishLimit > 1000)
            {
                Main.SendErrorMessage(player, "Balýk limiti 1-1000 arasýnda olmalýdýr!");
                return;
            }

            if (requiredLevel < 1 || requiredLevel > 5)
            {
                Main.SendErrorMessage(player, "Gerekli level 1-5 arasýnda olmalýdýr!");
                return;
            }

            player.SetData("CREATING_ZONE", true);
            player.SetData("ZONE_TYPE", (ZoneType)zoneType);
            player.SetData("FISH_LIMIT", fishLimit);
            player.SetData("REQUIRED_LEVEL", requiredLevel);
            player.SetData("ZONE_POINTS", new List<Vector3>());

            string typeName = ((ZoneType)zoneType).ToString();
            Main.SendSuccessMessage(player, "Bölge oluþturma modu aktif edildi!");
            Main.SendSuccessMessage(player, $"Bölge tipi: {typeName}");
            Main.SendSuccessMessage(player, $"Gerekli level: {requiredLevel}");
            if (zoneType == 1)
            {
                Main.SendSuccessMessage(player, $"Balýk limiti: {fishLimit}");
            }
            Main.SendSuccessMessage(player, "1. noktayý iþaretlemek için /nokta yazýn.");
        }
        catch (Exception ex)
        {
            Main.SendErrorMessage(player, $"Hata: {ex.Message}");
        }
    }

    [Command("nokta")]
    public void SetPoint(Player player)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için iþ baþýnda olmalýsýnýz, /aduty komutu ile iþ baþýna geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) <= 7)
        {
            return;
        }

        try
        {
            if (!player.HasData("CREATING_ZONE") || !player.GetData<bool>("CREATING_ZONE"))
            {
                Main.SendErrorMessage(player, "Þu anda bölge oluþturmuyorsunuz.");
                return;
            }

            List<Vector3> points = player.GetData<List<Vector3>>("ZONE_POINTS");
            Vector3 currentPos = player.Position;

            points.Add(currentPos);
            player.SetData("ZONE_POINTS", points);

            Main.SendSuccessMessage(player, $"{points.Count}. nokta iþaretlendi: {currentPos.X:F2}, {currentPos.Y:F2}, {currentPos.Z:F2}");

            if (points.Count < 4)
            {
                Main.SendInfoMessage(player, $"{points.Count + 1}. noktayý iþaretlemek için /nokta yazýn.");
            }
            else
            {
                CreateZoneFromPoints(player, points);
            }
        }
        catch (Exception ex)
        {
            Main.SendErrorMessage(player, $"Hata: {ex.Message}");
        }
    }

    private async void CreateZoneFromPoints(Player player, List<Vector3> points)
    {
        try
        {
            ZoneType zoneType = player.GetData<ZoneType>("ZONE_TYPE");
            int fishLimit = player.HasData("FISH_LIMIT") ? player.GetData<int>("FISH_LIMIT") : 100;
            int requiredLevel = player.HasData("REQUIRED_LEVEL") ? player.GetData<int>("REQUIRED_LEVEL") : 1;

            bool saveResult = await SaveZoneToDatabase(nextZoneId, points[0], points[1], points[2], points[3], zoneType, fishLimit, requiredLevel);

            if (!saveResult)
            {
                Main.SendErrorMessage(player, "Bölge veritabanýna kaydedilemedi!");
                return;
            }

            CreateZoneColShape(nextZoneId, points[0], points[1], points[2], points[3], zoneType, fishLimit, 0, null, requiredLevel);

            Main.SendSuccessMessage(player, $"Bölge baþarýyla oluþturuldu ve kaydedildi! (ID: {nextZoneId})");
            Main.SendInfoMessage(player, $"Tip: {zoneType}");
            Main.SendInfoMessage(player, $"Gerekli Level: {requiredLevel}");
            if (zoneType == ZoneType.Balýkçýlýk)
            {
                Main.SendInfoMessage(player, $"Balýk Limiti: {fishLimit}");
            }

            nextZoneId++;

            player.ResetData("CREATING_ZONE");
            player.ResetData("ZONE_TYPE");
            player.ResetData("FISH_LIMIT");
            player.ResetData("REQUIRED_LEVEL");
            player.ResetData("ZONE_POINTS");
        }
        catch (Exception ex)
        {
            Main.SendErrorMessage(player, $"Bölge oluþturulurken hata: {ex.Message}");
        }
    }

    [Command("bolgesil", "~y~[!]~w~: /bolgesil [Bölge ID]")]
    public async void DeleteZone(Player player, int zoneId = -1)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için iþ baþýnda olmalýsýnýz, /aduty komutu ile iþ baþýna geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) <= 7)
        {
            return;
        }

        try
        {
            if (zoneId == -1)
            {
                Main.SendErrorMessage(player, "~y~[!]~w~: /bolgesil [Bölge ID]");
                Main.SendInfoMessage(player, "Bölge listesi için /bolgeler yazýn");
                return;
            }

            if (!zones.ContainsKey(zoneId))
            {
                Main.SendErrorMessage(player, $"{zoneId} ID'li bölge bulunamadý!");
                return;
            }

            DynamicZone zone = zones[zoneId];

            bool deleteResult = await DeleteZoneFromDatabase(zoneId);

            if (!deleteResult)
            {
                Main.SendErrorMessage(player, "Bölge veritabanýndan silinemedi!");
                return;
            }

            if (zone.ColShape != null)
            {
                zone.ColShape.Delete();
            }

            zones.Remove(zoneId);
            Main.SendSuccessMessage(player, $"{zone.Type} bölgesi (ID: {zoneId}) baþarýyla silindi!");
        }
        catch (Exception ex)
        {
            Main.SendErrorMessage(player, $"Hata: {ex.Message}");
        }
    }

    [Command("bolgeler")]
    public void ListZones(Player player)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için iþ baþýnda olmalýsýnýz, /aduty komutu ile iþ baþýna geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) <= 7)
        {
            return;
        }

        try
        {
            if (zones.Count == 0)
            {
                Main.SendInfoMessage(player, "Henüz hiç bölge oluþturulmamýþ.");
                return;
            }

            Main.SendInfoMessage(player, "======================== BÖLGE LÝSTESÝ ========================");
            foreach (var zone in zones.Values)
            {
                if (zone.Type == ZoneType.Balýkçýlýk)
                {
                    Main.SendInfoMessage(player, $"ID: {zone.Id} | Tip: {zone.Type} | Level: {zone.RequiredLevel} | Balýk: {zone.CurrentFishCount}/{zone.MaxFishLimit}");
                }
                else
                {
                    Main.SendInfoMessage(player, $"ID: {zone.Id} | Tip: {zone.Type} | Level: {zone.RequiredLevel}");
                }
            }
        }
        catch (Exception ex)
        {
            Main.SendErrorMessage(player, $"Hata: {ex.Message}");
        }
    }

    [Command("bolgebilgi", "~y~[!]~w~: /bolgebilgi [Bölge ID]")]
    public void ZoneInfo(Player player, int zoneId = -1)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için iþ baþýnda olmalýsýnýz, /aduty komutu ile iþ baþýna geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) <= 7)
        {
            return;
        }

        try
        {
            if (zoneId == -1)
            {
                Main.SendErrorMessage(player, "~y~[!]~w~: /bolgebilgi [Bölge ID]");
                return;
            }

            if (!zones.ContainsKey(zoneId))
            {
                Main.SendErrorMessage(player, $"{zoneId} ID'li bölge bulunamadý!");
                return;
            }

            DynamicZone zone = zones[zoneId];
            Vector3 center = new Vector3(
                (zone.Pos1.X + zone.Pos2.X + zone.Pos3.X + zone.Pos4.X) / 4,
                (zone.Pos1.Y + zone.Pos2.Y + zone.Pos3.Y + zone.Pos4.Y) / 4,
                (zone.Pos1.Z + zone.Pos2.Z + zone.Pos3.Z + zone.Pos4.Z) / 4
            );

            Main.SendInfoMessage(player, "======================== BÖLGE BÝLGÝLERÝ ========================");
            Main.SendInfoMessage(player, $"ID: {zone.Id}");
            Main.SendInfoMessage(player, $"Tip: {zone.Type}");
            Main.SendInfoMessage(player, $"Gerekli Level: {zone.RequiredLevel}");
            if (zone.Type == ZoneType.Balýkçýlýk)
            {
                Main.SendInfoMessage(player, $"Balýk Durumu: {zone.CurrentFishCount}/{zone.MaxFishLimit}");
                Main.SendInfoMessage(player, $"Son Sýfýrlanma: {zone.LastResetTime:dd.MM.yyyy HH:mm}");
            }
            Main.SendInfoMessage(player, $"Merkez: {center.X:F2}, {center.Y:F2}, {center.Z:F2}");
            Main.SendInfoMessage(player, $"1. Nokta: {zone.Pos1.X:F2}, {zone.Pos1.Y:F2}, {zone.Pos1.Z:F2}");
            Main.SendInfoMessage(player, $"2. Nokta: {zone.Pos2.X:F2}, {zone.Pos2.Y:F2}, {zone.Pos2.Z:F2}");
            Main.SendInfoMessage(player, $"3. Nokta: {zone.Pos3.X:F2}, {zone.Pos3.Y:F2}, {zone.Pos3.Z:F2}");
            Main.SendInfoMessage(player, $"4. Nokta: {zone.Pos4.X:F2}, {zone.Pos4.Y:F2}, {zone.Pos4.Z:F2}");
        }
        catch (Exception ex)
        {
            Main.SendErrorMessage(player, $"Hata: {ex.Message}");
        }
    }

    [Command("baliklimitduzenle", "~y~[!]~w~: /baliklimitduzenle [Bölge ID] [Balýk]")]
    public async void ResetFishLimit(Player player, int zoneId, int balikporno)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için iþ baþýnda olmalýsýnýz, /aduty komutu ile iþ baþýna geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) <= 7)
        {
            return;
        }

        try
        {
            if (!zones.ContainsKey(zoneId))
            {
                Main.SendErrorMessage(player, $"{zoneId} ID'li bölge bulunamadý!");
                return;
            }

            DynamicZone zone = zones[zoneId];

            if (zone.Type != ZoneType.Balýkçýlýk)
            {
                Main.SendErrorMessage(player, "Bu bölge balýkçýlýk bölgesi deðil!");
                return;
            }

            zone.CurrentFishCount = balikporno;

            if (balikporno == 0)
            {
                zone.LastResetTime = DateTime.Now;
            }
            bool updateResult = await UpdateFishLimitInDatabase(zone.Id, zone.CurrentFishCount, zone.LastResetTime);

            if (updateResult)
            {
                Main.SendSuccessMessage(player, $"Bölge {zoneId} balýk limiti düzenlendi!");
            }
            else
            {
                Main.SendErrorMessage(player, "Veritabaný güncellenirken hata oluþtu!");
            }
        }
        catch (Exception ex)
        {
            Main.SendErrorMessage(player, $"Hata: {ex.Message}");
        }
    }

    [ServerEvent(Event.PlayerEnterColshape)]
    public void OnPlayerEnterColshape(ColShape colShape, Player player)
    {
        try
        {
            if (colShape.HasData("ZONE_ID"))
            {
                int zoneId = colShape.GetData<int>("ZONE_ID");
                ZoneType zoneType = colShape.GetData<ZoneType>("ZONE_TYPE");

                OnZoneEnterCustom(player, zoneId, zoneType);
            }
        }
        catch (Exception ex)
        {
            NAPI.Chat.SendChatMessageToAll($"ColShape Enter Hatasý: {ex.Message}");
        }
    }

    [ServerEvent(Event.PlayerExitColshape)]
    public void OnPlayerExitColshape(ColShape colShape, Player player)
    {
        try
        {
            if (colShape.HasData("ZONE_ID"))
            {
                int zoneId = colShape.GetData<int>("ZONE_ID");
                ZoneType zoneType = colShape.GetData<ZoneType>("ZONE_TYPE");

                OnZoneExitCustom(player, zoneId, zoneType);
            }
        }
        catch (Exception ex)
        {
            NAPI.Chat.SendChatMessageToAll($"ColShape Exit Hatasý: {ex.Message}");
        }
    }

    private void OnZoneEnterCustom(Player player, int zoneId, ZoneType zoneType)
    {
        try
        {
            switch (zoneType)
            {
                case ZoneType.Balýkçýlýk:
                    Main.SendInfoMessage(player, "Balýkçýlýk bölgesine girdiniz.");
                    break;
                case ZoneType.Güvenli:
                    Main.SendSuccessMessage(player, "Güvenli bölgeye girdiniz.");
                    player.TriggerEvent("GuvenliBolge", true);
                    break;
            }
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"Zone enter custom error: {ex.Message}");
        }
    }

    private void OnZoneExitCustom(Player player, int zoneId, ZoneType zoneType)
    {
        try
        {
            switch (zoneType)
            {
                case ZoneType.Güvenli:
                    Main.SendInfoMessage(player, "Güvenli bölgeden çýktýnýz.");
                    player.TriggerEvent("GuvenliBolge", false);
                    break;
                case ZoneType.Balýkçýlýk:
                    Main.SendInfoMessage(player, "Balýkçýlýk bölgesinden çýktýnýz.");
                    break;
            }
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"Zone exit custom error: {ex.Message}");
        }
    }

    [ServerEvent(Event.PlayerDisconnected)]
    public void OnPlayerDisconnected(Player player, DisconnectionType type, string reason)
    {
        try
        {
            if (player.HasData("CREATING_ZONE"))
            {
                player.ResetData("CREATING_ZONE");
                player.ResetData("ZONE_TYPE");
                player.ResetData("ZONE_POINTS");
            }
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput($"Oyuncu disconnect temizlik hatasý: {ex.Message}");
        }
    }

    public static ZoneType BolgeKontrol(Player player)
    {
        try
        {
            List<int> playerZones = new List<int>();

            foreach (var zone in zones.Values)
            {
                if (zone.ColShape != null && NAPI.ColShape.IsPointWithinColshape(zone.ColShape, player.Position))
                {
                    playerZones.Add(zone.Id);
                }
            }

            if (playerZones.Count == 0)
            {
                return ZoneType.Yok;
            }
            else
            {
                foreach (int zoneId in playerZones)
                {
                    if (zones.ContainsKey(zoneId))
                    {
                        DynamicZone zone = zones[zoneId];
                        return zone.Type;
                    }
                }
            }
        }
        catch
        {
            return ZoneType.Yok;
        }
        return ZoneType.Yok;
    }

    public static int BolgeLevel(Player player)
    {
        try
        {
            List<int> playerZones = new List<int>();

            foreach (var zone in zones.Values)
            {
                if (zone.ColShape != null && NAPI.ColShape.IsPointWithinColshape(zone.ColShape, player.Position))
                {
                    playerZones.Add(zone.Id);
                }
            }

            if (playerZones.Count == 0)
            {
                return -1;
            }
            else
            {
                foreach (int zoneId in playerZones)
                {
                    if (zones.ContainsKey(zoneId))
                    {
                        DynamicZone zone = zones[zoneId];
                        return zone.RequiredLevel;
                    }
                }
            }
        }
        catch
        {
            return -1;
        }
        return -1;
    }

    public static bool BalikLimitKontrol(Player player)
    {
        try
        {
            List<int> playerZones = new List<int>();

            foreach (var zone in zones.Values)
            {
                if (zone.ColShape != null && NAPI.ColShape.IsPointWithinColshape(zone.ColShape, player.Position))
                {
                    playerZones.Add(zone.Id);
                }
            }

            if (playerZones.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (int zoneId in playerZones)
                {
                    if (zones.ContainsKey(zoneId))
                    {
                        DynamicZone zone = zones[zoneId];
                        if (zone.Type == ZoneType.Balýkçýlýk)
                        {
                            if (zone.MaxFishLimit > zone.CurrentFishCount) return false;
                            else return true;
                        }
                        else return false;
                    }
                }
            }
        }
        catch
        {
            return false;
        }
        return false;
    }
}