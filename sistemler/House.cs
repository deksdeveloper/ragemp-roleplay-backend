using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipes;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

public class EvSistemi : Script
{
    public static List<House> HouseInfo = new List<House>();

    public class House
    {
        public int id { get; set; }
        public string name { get; set; }
        public int owner_sqlid { get; set; }
        public string owner_name { get; set; }
        public bool locked { get; set; }
        public int price { get; set; }
        public bool sell_house { get; set; }
        public bool vip { get; set; }
        public Vector3 exterior { get; set; }
        public float exterior_a { get; set; }
        public Vector3 interior { get; set; }
        public int evinterior { get; set; }
        public Blip blip { get; set; }
        public Marker marker { get; set; }
        public float interior_a { get; set; }
        public GTANetworkAPI.TextLabel label;
    }


    public EvSistemi()
    {

    }


    public static void LoadHousesFromDatabase()
    {
        using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM evsistemi;";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    House house = new House
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        owner_sqlid = reader.IsDBNull("owner_sqlid") ? 0 : reader.GetInt32("owner_sqlid"),
                        owner_name = reader.IsDBNull("owner_name") ? null : reader.GetString("owner_name"),
                        locked = reader.GetBoolean("lock_status"),
                        price = reader.GetInt32("price"),
                        sell_house = reader.GetBoolean("sell_house"),
                        vip = reader.GetBoolean("vip"),
                        exterior = new Vector3(reader.GetFloat("exterior_x"), reader.GetFloat("exterior_y"), reader.GetFloat("exterior_z")),
                        exterior_a = reader.GetFloat("exterior_a"),
                        interior = new Vector3(reader.GetFloat("interior_x"), reader.GetFloat("interior_y"), reader.GetFloat("interior_z")),
                        interior_a = reader.GetFloat("interior_a"),
                        evinterior = reader.GetInt32("evinterior")
                    };


                    HouseInfo.Add(house);
                    CreateHouseLabel(house);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Console.WriteLine($"[MYSQL Hata] Evler yüklenirken hata oluştu: {ex.Message}");
            }
        }
    }

    private static void CreateHouseLabel(House house)
    {
        int index = HouseInfo.FindIndex(h => h.id == house.id);
        if (index == -1) return;

        string houseStatus = house.sell_house ? "~y~BU EV SATILIK!" : $"~r~Sahip: {house.owner_name ?? "Yok"}";
        string lockStatus = house.locked ? "~r~Kilitli" : "~g~Açık";
        string labelText = $"{house.name} - #{house.id}\n{houseStatus}\n~w~Fiyat: {house.price}$\n{lockStatus}";

        var color = house.sell_house ? new Color(0, 255, 0, 100) : new Color(255, 0, 0, 100);
        var color2 = house.sell_house ? 1 : 2;
        var name = "Ev #" + house.id;

        if (!house.sell_house)
        {
            HouseInfo[index].blip = NAPI.Blip.CreateBlip(HouseInfo[index].exterior);
            NAPI.Blip.SetBlipName(HouseInfo[index].blip, name);
            NAPI.Blip.SetBlipSprite(HouseInfo[index].blip, 411);
            NAPI.Blip.SetBlipColor(HouseInfo[index].blip, color2);
            NAPI.Blip.SetBlipScale(HouseInfo[index].blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(HouseInfo[index].blip, true);
        }

        HouseInfo[index].marker = NAPI.Marker.CreateMarker(1, HouseInfo[index].exterior - new Vector3(0, 0, 1.0), new Vector3(), new Vector3(), 2.0f, color, true, 0);

        house.label = NAPI.TextLabel.CreateTextLabel(labelText, house.exterior, 10.0f, 0.5f, 4, new Color(255, 255, 255, 255));
    }

    private static void RefreshHouseLabel(House house)
    {
        int index = HouseInfo.FindIndex(h => h.id == house.id);
        if (index == -1) return;

        house.label?.Delete();
        house.blip?.Delete();
        house.marker?.Delete();

        string houseStatus = house.sell_house ? "~y~BU EV SATILIK!" : $"~r~Sahip: {house.owner_name ?? "Yok"}";
        string lockStatus = house.locked ? "~r~Kilitli" : "~g~Açık";
        string labelText = $"{house.name} - #{house.id}\n{houseStatus}\n~w~Fiyat: {house.price}$\n{lockStatus}";

        var color = house.sell_house ? new Color(0, 255, 0, 100) : new Color(255, 0, 0, 100);
        var color2 = house.sell_house ? 1 : 2;
        var name = "Ev #" + house.id;

        if (!house.sell_house)
        {
            HouseInfo[index].blip = NAPI.Blip.CreateBlip(HouseInfo[index].exterior);
            NAPI.Blip.SetBlipName(HouseInfo[index].blip, name);
            NAPI.Blip.SetBlipSprite(HouseInfo[index].blip, 411);
            NAPI.Blip.SetBlipColor(HouseInfo[index].blip, color2);
            NAPI.Blip.SetBlipScale(HouseInfo[index].blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(HouseInfo[index].blip, true);
        }

        HouseInfo[index].marker = NAPI.Marker.CreateMarker(1, HouseInfo[index].exterior - new Vector3(0, 0, 1.0), new Vector3(), new Vector3(), 2.0f, color, true, 0);

        house.label = NAPI.TextLabel.CreateTextLabel(labelText, house.exterior, 10.0f, 0.5f, 4, new Color(255, 255, 255, 255));
    }

    private static void UpdateHouseInDatabase(House house, string column, string value)
    {
        using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                connection.Open();
                string query = $"UPDATE evsistemi SET {column} = @value WHERE id = @houseId;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", value);
                command.Parameters.AddWithValue("@houseId", house.id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MYSQL Hata] Ev güncellenirken hata oluştu: {ex.Message}");
            }
        }
    }

    private static void SaveHouseToDatabase(House house)
    {
        using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO evsistemi (name, owner_sqlid, owner_name, sell_house, lock_status, price, vip, " +
                               "exterior_x, exterior_y, exterior_z, exterior_a, " +
                               "interior_x, interior_y, interior_z, interior_a, evinterior) " +
                               "VALUES (@name, @owner_sqlid, @owner_name, @sell_house, @lock_status, @price, @vip, " +
                               "@exterior_x, @exterior_y, @exterior_z, @exterior_a, " +
                               "@interior_x, @interior_y, @interior_z, @interior_a, @evinterior);";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", house.name);
                command.Parameters.AddWithValue("@owner_sqlid", house.owner_sqlid);
                command.Parameters.AddWithValue("@owner_name", house.owner_name ?? "Yok"); // Use "Yok" instead of DBNull.Value
                command.Parameters.AddWithValue("@sell_house", house.sell_house);
                command.Parameters.AddWithValue("@lock_status", house.locked);
                command.Parameters.AddWithValue("@price", house.price);
                command.Parameters.AddWithValue("@vip", house.vip);
                command.Parameters.AddWithValue("@exterior_x", house.exterior.X);
                command.Parameters.AddWithValue("@exterior_y", house.exterior.Y);
                command.Parameters.AddWithValue("@exterior_z", house.exterior.Z);
                command.Parameters.AddWithValue("@exterior_a", house.exterior_a);
                command.Parameters.AddWithValue("@interior_x", house.interior.X);
                command.Parameters.AddWithValue("@interior_y", house.interior.Y);
                command.Parameters.AddWithValue("@interior_z", house.interior.Z);
                command.Parameters.AddWithValue("@interior_a", house.interior_a);
                command.Parameters.AddWithValue("@evinterior", house.evinterior);

                command.ExecuteNonQuery();

                house.id = (int)command.LastInsertedId;

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MYSQL Hata] Ev kaydedilirken hata oluştu: {ex.Message}");
            }
        }
    }


    [Command("evolustur", "~y~[!]~w~: /evolustur [Fiyat]")]
    public void CreateHouseCommand(Player player, int price)
    {
        Vector3 position = player.Position;
        float heading = player.Heading;

        House newHouse = new House
        {
            id = HouseInfo.Count + 1,
            name = "Bilinmeyen Ev",
            owner_sqlid = 0,
            owner_name = null,
            locked = false,
            price = price,
            sell_house = true,
            vip = false,
            exterior = position,
            exterior_a = heading,
            interior = new Vector3(-781.6287, 318.20883, 217.63889),
            interior_a = 0f,
            evinterior = 1
        };

        HouseInfo.Add(newHouse);
        SaveHouseToDatabase(newHouse);
        CreateHouseLabel(newHouse);

        var index = 0;

        Main.SendSuccessMessage(player, $"Yeni ev oluşturuldu! (Fiyat: ${price})");
    }

    [Command("evduzenle", "~y~[!]~w~: /evduzenle [ID] [isim/sahip/fiyat/interior/exterior] [Değer]")]
    public void EditHouseCommand(Player player, int houseId, string setting, string value = "")
    {
        House house = HouseInfo.Find(h => h.id == houseId);

        if (house == null)
        {
            Main.SendErrorMessage(player, "Böyle bir ev bulunamadı.");
            return;
        }

        switch (setting.ToLower())
        {
            case "isim":
                house.name = value;
                UpdateHouseInDatabase(house, "name", value);
                Main.SendSuccessMessage(player, $"Ev adı {value} olarak değiştirildi.");
                RefreshHouseLabel(house);
                break;

            case "sahip":
                if (string.IsNullOrEmpty(value))
                {
                    Main.SendErrorMessage(player, "Geçersiz ev sahibi adı!");
                    return;
                }

                house.owner_name = AccountManage.GetCharacterName(player);
                house.owner_sqlid = player.GetData<int>("character_sqlid");
                UpdateHouseInDatabase(house, "owner_sqlid", house.owner_sqlid.ToString());
                UpdateHouseInDatabase(house, "owner_name", house.owner_name);
                Main.SendSuccessMessage(player, $"Ev sahibi {value} olarak değiştirildi.");
                RefreshHouseLabel(house);
                break;

            case "fiyat":
                if (!int.TryParse(value, out int newPrice) || newPrice <= 0)
                {
                    Main.SendErrorMessage(player, "Geçersiz fiyat!");
                    return;
                }

                house.price = newPrice;
                UpdateHouseInDatabase(house, "price", newPrice.ToString());
                Main.SendSuccessMessage(player, $"Ev fiyatı {newPrice}$ olarak güncellendi.");
                RefreshHouseLabel(house);
                break;
            case "icmekan":
                if (!int.TryParse(value, out int interior) || interior <= 0)
                {
                    Main.SendErrorMessage(player, "Geçersiz interior!");
                    return;
                }

                house.evinterior = interior;
                UpdateHouseInDatabase(house, "evinterior", interior.ToString());
                Main.SendSuccessMessage(player, "Evin interioru " + interior + " olarak değiştirildi.");

                switch (house.evinterior)
                {
                    case 0:
                        {
                            Main.SendErrorMessage(player, "İnterior tipi 1-4 arasında olabilir..");
                            break;
                        }
                    case 1:
                        {
                            house.interior = new Vector3(-781.6287, 318.20883, 217.63889);
                            UpdateHouseInDatabase(house, "interior_x", house.interior.X.ToString());
                            UpdateHouseInDatabase(house, "interior_y", house.interior.Y.ToString());
                            UpdateHouseInDatabase(house, "interior_z", house.interior.Z.ToString());
                            UpdateHouseInDatabase(house, "interior_a", house.interior_a.ToString());
                            break;
                        }
                    case 2:
                        {
                            house.interior = new Vector3(-776.52673, 323.56116, 211.99716);
                            UpdateHouseInDatabase(house, "interior_x", house.interior.X.ToString());
                            UpdateHouseInDatabase(house, "interior_y", house.interior.Y.ToString());
                            UpdateHouseInDatabase(house, "interior_z", house.interior.Z.ToString());
                            UpdateHouseInDatabase(house, "interior_a", house.interior_a.ToString());
                            break;
                        }
                    case 3:
                        {
                            house.interior = new Vector3(-778.5933, 317.04263, 223.25766);
                            UpdateHouseInDatabase(house, "interior_x", house.interior.X.ToString());
                            UpdateHouseInDatabase(house, "interior_y", house.interior.Y.ToString());
                            UpdateHouseInDatabase(house, "interior_z", house.interior.Z.ToString());
                            UpdateHouseInDatabase(house, "interior_a", house.interior_a.ToString());
                            break;
                        }
                    case 4:
                        {
                            house.interior = new Vector3(-779.4124, 338.9296, 196.72154);
                            UpdateHouseInDatabase(house, "interior_x", house.interior.X.ToString());
                            UpdateHouseInDatabase(house, "interior_y", house.interior.Y.ToString());
                            UpdateHouseInDatabase(house, "interior_z", house.interior.Z.ToString());
                            UpdateHouseInDatabase(house, "interior_a", house.interior_a.ToString());

                            break;
                        }
                    default:
                        {
                            Main.SendErrorMessage(player, "İnterior tipi 1-4 arasında olabilir.");
                            break;
                        }
                }

                if (house.label != null)
                    house.label.Delete();
                CreateHouseLabel(house);
                break;
            case "exterior":
                house.exterior = player.Position;
                house.exterior_a = player.Heading;
                UpdateHouseInDatabase(house, "exterior_x", house.exterior.X.ToString());
                UpdateHouseInDatabase(house, "exterior_y", house.exterior.Y.ToString());
                UpdateHouseInDatabase(house, "exterior_z", house.exterior.Z.ToString());
                UpdateHouseInDatabase(house, "exterior_a", house.exterior_a.ToString());
                Main.SendSuccessMessage(player, "Evin dış konumu güncellendi.");

                if (house.label != null)
                    house.label.Delete();
                CreateHouseLabel(house);
                break;

            case "interior":
                house.interior = player.Position;
                house.interior_a = player.Heading;
                UpdateHouseInDatabase(house, "interior_x", house.interior.X.ToString());
                UpdateHouseInDatabase(house, "interior_y", house.interior.Y.ToString());
                UpdateHouseInDatabase(house, "interior_z", house.interior.Z.ToString());
                UpdateHouseInDatabase(house, "interior_a", house.interior_a.ToString());
                Main.SendSuccessMessage(player, "Evin iç konumu güncellendi.");

                if (house.label != null)
                    house.label.Delete();
                CreateHouseLabel(house);
                break;

            default:
                Main.SendCustomChatMessasge(player, "~y~[!]~w~: /evduzenle [id] [isim/sahip/fiyat/interior/exterior] [değer]");
                break;
        }
    }


    [Command("evsil", "~y~[!]~w~: /evsil [ID]")]
    public void DeleteHouseCommand(Player player, int houseId)
    {
        House house = HouseInfo.Find(h => h.id == houseId);

        if (house == null)
        {
            Main.SendErrorMessage(player, "Böyle bir ev bulunamadı.");
            return;
        }

        DeleteHouseFromDatabase(house);
        HouseInfo.Remove(house);
        if (house.label != null)
        {
            house.label.Delete();
        }

        if (house.blip != null)
        {
            house.blip.Delete();
        }

        if (house.marker != null)
        {
            house.marker.Delete();
        }

        Main.SendSuccessMessage(player, $"{house.name} adlı ev silindi.");
    }

    private static void DeleteHouseFromDatabase(House house)
    {
        using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                connection.Open();
                string query = "DELETE FROM evsistemi WHERE id = @houseId;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@houseId", house.id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MYSQL Hata] Ev silinirken hata oluştu: {ex.Message}");
            }
        }
    }

    public static void EvGirCik(Player player)
    {
        if (player.GetData<int>("OyuncuEv") == -1)
        {
            House house = null;

            foreach (var h in HouseInfo)
            {
                if (Vector3.Distance(h.exterior, player.Position) < 5.0f)
                {
                    house = h;
                    break;
                }
            }

            if (house == null)
            {
                return;
            }

            if (house.locked)
            {
                return;
            }

            EveGonder(player, house);

            Main.SendSuccessMessage(player, $"{house.name} evine girdiniz. /evcik ile çıkabilirsiniz.");
        }
        else
        {

            int ev = player.GetData<int>("OyuncuEv");

            if (ev == -1)
            {
                return;
            }

            House house = HouseInfo.Find(h => h.id == ev);
            // kitap sikecegim

            if (Vector3.Distance(house.interior, player.Position) > 5.0f || player.Dimension != house.id + 1000)
            {
                return;
            }

            if (house == null)
            {
                return;
            }

            player.SetData<int>("OyuncuEv", -1);
            player.Position = house.exterior;
            player.Dimension = 0;
            Main.SendSuccessMessage(player, $"{house.name} evinden çıktınız.");
        }
    }


    public static void EveGonder(Player player, House ev)
    {
        if (ev == null)
        {
            return;
        }

        if (ev.locked)
        {
            Main.SendErrorMessage(player, "Bu ev kilitli.");
            return;
        }

        switch (ev.evinterior)
        {
            case 0:
                {
                    Main.SendErrorMessage(player, "Bu ev ayarlanmamış veya hatalı.");
                    break;
                }
            case 1:
                {
                    uint houseDimension = (uint)(ev.id + 1000);
                    player.SetData<int>("OyuncuEv", ev.id);
                    player.Position = new Vector3(-781.6287, 318.20883, 217.63889);
                    player.Dimension = houseDimension;
                    break;
                }
            case 2:
                {
                    uint houseDimension = (uint)(ev.id + 1000);
                    player.SetData<int>("OyuncuEv", ev.id);
                    player.Position = new Vector3(-776.52673, 323.56116, 211.99716);
                    player.Dimension = houseDimension;
                    break;
                }
            case 3:
                {
                    uint houseDimension = (uint)(ev.id + 1000);
                    player.SetData<int>("OyuncuEv", ev.id);
                    player.Position = new Vector3(-778.5933, 317.04263, 223.25766);
                    player.Dimension = houseDimension;
                    break;
                }
            case 4:
                {
                    uint houseDimension = (uint)(ev.id + 1000);
                    player.SetData<int>("OyuncuEv", ev.id);
                    player.Position = new Vector3(-779.4124, 338.9296, 196.72154);
                    player.Dimension = houseDimension;
                    break;
                }
            default:
                {
                    Main.SendErrorMessage(player, "Bu ev ayarlanmamış veya hatalı.");
                    break;
                }
        }
    }
    [Command("evsatinal")]
    public void BuyHouseCommand(Player player)
    {
        House house = HouseInfo.Find(h => h.exterior.DistanceTo(player.Position) < 3.0f);

        if (house == null || house.sell_house == false)
        {
            Main.SendErrorMessage(player, "Satılık ev bulunamadı.");
            return;
        }

        if (Main.GetPlayerMoney(player) < house.price)
        {
            Main.SendErrorMessage(player, "Yeterli paranız yok.");
            return;
        }

        player.SetData("money", player.GetData<int>("money") - house.price);
        house.owner_name = AccountManage.GetCharacterName(player);
        house.owner_sqlid = player.GetData<int>("character_sqlid");
        house.sell_house = false;
        UpdateHouseInDatabase(house, "owner_sqlid", house.owner_sqlid.ToString());
        UpdateHouseInDatabase(house, "owner_name", AccountManage.GetCharacterName(player));
        UpdateHouseInDatabase(house, "sell_house", "0");

        RefreshHouseLabel(house);

        Main.SendSuccessMessage(player, $"Ev başarıyla satın alındı. Fiyat: ${house.price}");
    }

    [Command("evkilitle")]
    public void LockHouseCommand(Player player)
    {
        House house = null;

        foreach (var h in HouseInfo)
        {
            if (Vector3.Distance(h.exterior, player.Position) < 5.0f)
            {
                house = h;
                break;
            }
        }

        if (house == null)
        {
            Main.SendErrorMessage(player, "Yakınınızda bir ev bulunmamaktadır.");
            return;
        }

        if (house == null || house.owner_sqlid != player.GetData<int>("character_sqlid"))
        {
            Main.SendErrorMessage(player, "Bu evi kilitleme izniniz yok!");
            return;
        }

        house.locked = !house.locked;
        UpdateHouseInDatabase(house, "lock_status", house.locked ? "1" : "0");

        if (house.label != null)
            house.label.Delete();

        CreateHouseLabel(house);

        Main.SendSuccessMessage(player, house.locked ? "Evin kapısını kilitlediniz!" : "Evin kapısını açtınız!");
    }

    [Command("ev")]
    public static void EvPanel(Player player)
    {
        House house = null;

        foreach (var h in HouseInfo)
        {
            if ((player.Dimension == h.id + 1000 && Vector3.Distance(h.interior, player.Position) < 20.0f) ||
            (player.Dimension == 0 && Vector3.Distance(h.exterior, player.Position) < 3.0f))
            {
                house = h;
                break;
            }

        }

        if (house == null)
        {
            Main.SendErrorMessage(player, "Yakınınızda bir ev bulunmamaktadır.");
            return;
        }

        player.TriggerEvent("EvPanelCagir", house.id);
    }

    [RemoteEvent("EvPanelCS")]
    public void EvPanelEv(Player client, int id, int evid)
    {
        House ev = null;
        foreach (var h in HouseInfo)
        {
            if (evid == h.id)
            {
                ev = h;
            }
        }
        if (ev == null)
        {
            Main.SendErrorMessage(client, "Bir hata oluştu.");
            client.TriggerEvent("Hide_Crafting_System");
            return;
        }
        if (Vector3.Distance(ev.exterior, client.Position) > 3.0f &&
        (Vector3.Distance(ev.interior, client.Position) > 20.0f || client.Dimension != ev.id + 1000))
        {
            Main.SendErrorMessage(client, "Herhangi bir evin kapısında veya içerisinde değilsin.");
            client.TriggerEvent("Hide_Crafting_System");
            return;
        }

        if (ev.owner_sqlid != client.GetData<int>("character_sqlid"))
        {
            Main.SendErrorMessage(client, "Bu evi yönetme iznin yok.");
            client.TriggerEvent("Hide_Crafting_System");
            return;
        }
        switch (id)
        {
            case 0:
                {
                    Main.SendErrorMessage(client, ev.name + " adlı evin yönetim panelini kapattınız.");
                    client.TriggerEvent("Hide_Crafting_System");
                    break;
                }
            case 1:
                {
                    ev.locked = !ev.locked;
                    UpdateHouseInDatabase(ev, "lock_status", ev.locked ? "1" : "0");

                    if (ev.label != null)
                        ev.label.Delete();

                    CreateHouseLabel(ev);

                    Main.SendSuccessMessage(client, ev.locked ? "Evin kapısını kilitlediniz!" : "Evin kapısını açtınız!");
                    client.TriggerEvent("Hide_Crafting_System");
                    break;
                }
        }
    }
}