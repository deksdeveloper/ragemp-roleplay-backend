
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Xml.Schema;

class TelefonSistem : Script
{
    public int ID { get; set; }
    public string name { get; set; }
    public int number { get; set; }

    public enum RehberData
    {
        ID, Sahip, Isim, Telefon, Count
    }

    private const int MaxRehber = 1000;

    public const int ARAMA_BOS = 0;
    public const int ARAMA_ARIYOR = 1;
    public const int ARAMA_ARANIYOR = 2;
    public const int ARAMA_KONUSUYOR = 3;

    private static object[,] rehberData = new object[MaxRehber, (int)RehberData.Count];

    public static void SetRehberData(int id, RehberData key, object value)
        => rehberData[id, (int)key] = value;

    public static T GetRehberData<T>(int id, RehberData key)
    {
        object value = rehberData[id, (int)key];
        return value != null ? (T)value : default;
    }

    public static bool RehberHasData(int id, RehberData key)
        => rehberData[id, (int)key] != null;

    public static void RehberClearData(int id)
    {
        for (int i = 0; i < (int)RehberData.Count; i++)
            rehberData[id, i] = null;
    }

    public static List<int> TumRehberler()
    {
        var active = new List<int>();
        for (int id = 0; id < MaxRehber; id++)
            if (RehberHasData(id, RehberData.ID)) active.Add(id);
        return active;
    }

    public static void NewNumber(Player Client)
    {
        Random rnd = new Random();
        int random_number = rnd.Next(100000, 999999);

        Client.SetData<dynamic>("character_cellphone", random_number);

        Main.SendCustomChatMessasge(Client, "Yeni telefon numaranız : ~b~" + String.Format("{0:###-###}", random_number) + "~w~.");


        if (GetPlayerNumber(Client) != 0)
        {
            Client.TriggerEvent("initPhone");
            Client.TriggerEvent("setPhoneNumber", GetPlayerNumber(Client));
        }
    }

    [Command("telefon")]
    public static void TelefonAc(Player player)
    {
        if (GetPlayerNumber(player) != 0)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "client:TelefonAc", GetPlayerNumber(player));
        }
        else
        {
            Main.SendErrorMessage(player, "Telefonunuz yok.");
            return;
        }
    }

    public static void TelefonUIKapat(Player player)
    {
        var kapatEvents = new[] {
            "client:AnaMenuKapat", "client:NumaraCevirKapat", "client:KisaMesajKapat",
            "client:KisaMesajIkiKapat", "client:RehberKapat", "client:KartvizitEkleKapat",
            "client:KartvizitEkleIkiKapat"
        };
        foreach (var evt in kapatEvents)
            NAPI.ClientEvent.TriggerClientEvent(player, evt);
    }

    [RemoteEvent("server:AnaMenuIslem")]
    public static void AnaMenuIslem(Player player, bool status, int islem)
    {
        if (!status) return;
        TelefonUIKapat(player);

        switch (islem)
        {
            case 0: NAPI.ClientEvent.TriggerClientEvent(player, "client:NumaraCevir"); break;
            case 1: NAPI.ClientEvent.TriggerClientEvent(player, "client:KisaMesaj"); break;
            case 2:
                NAPI.Util.ConsoleOutput(GetRehberJson(player));
                NAPI.ClientEvent.TriggerClientEvent(player, "client:RehberYukle", GetRehberJson(player));
                break;
            case 3: Main.SendErrorMessage(player, "ayarlar"); break;
        }
    }

    // Numara çevirme
    [RemoteEvent("server:NumaraCevirildi")]
    public static void NumaraCevirildi(Player player, bool status, string numara)
    {
        if (!status) return;
        if (string.IsNullOrEmpty(numara) || numara.Length > 8)
        {
            Main.SendErrorMessage(player, "Geçersiz telefon numarası girdiniz.");
            return;
        }

        int num;
        if (!int.TryParse(numara, out num))
        {
            Main.SendErrorMessage(player, "Geçersiz telefon numarası girdiniz.");
            return;
        }
    }

    [RemoteEvent("server:KisaMesajBirinci")]
    public static void KisaMesajBirinci(Player player, bool status, string number)
    {
        if (!status) return;
        if (string.IsNullOrEmpty(number) || number.Length > 8)
        {
            Main.SendErrorMessage(player, "Geçersiz telefon numarası girdiniz.");
            return;
        }

        int num;
        if (!int.TryParse(number, out num))
        {
            Main.SendErrorMessage(player, "Geçersiz telefon numarası girdiniz.");
            return;
        }

        player.SetData("mesajAdim1", num);
        NAPI.ClientEvent.TriggerClientEvent(player, "client:KisaMesajIki", number);
    }

    [RemoteEvent("server:KisaMesajIkinci")]
    public static void KisaMesajIkinci(Player player, bool status, string message)
    {
        if (!status) return;
        if (string.IsNullOrEmpty(message) || message.Length > 128)
        {
            Main.SendErrorMessage(player, "Mesaj minimum 1, maksimum 128 harf olabilir.");
            return;
        }
        SMS_Gonder(player, player.GetData<int>("mesajAdim1"), message);
    }

    public static string GetRehberJson(Player player)
    {
        var lobiler = new List<TelefonSistem>();
        int playerNum = GetPlayerNumber(player);

        for (int i = 0; i < MaxRehber; i++)
        {
            if (!RehberHasData(i, RehberData.ID)) continue;
            if (GetRehberData<int>(i, RehberData.Sahip) == playerNum)
                lobiler.Add(new TelefonSistem
                {
                    ID = GetRehberData<int>(i, RehberData.ID),
                    name = GetRehberData<string>(i, RehberData.Isim),
                    number = GetRehberData<int>(i, RehberData.Telefon)
                });
        }
        return NAPI.Util.ToJson(lobiler);
    }

    public static bool NumaraKontrol(int number, int targetnumber)
    {
        try
        {
            foreach (var rid in TumRehberler())
            {
                if (!RehberHasData(rid, RehberData.ID)) continue;
                if (GetRehberData<int>(rid, RehberData.Sahip) == number &&
                    GetRehberData<int>(rid, RehberData.Telefon) == targetnumber)
                    return true;
            }
        }
        catch { NAPI.Util.ConsoleOutput("NumaraKontrol fonksiyonunda hata!"); }
        return false;
    }

    public static int GetNumaraID(Player player, int number)
    {
        try
        {
            int playerNum = GetPlayerNumber(player);
            foreach (var rid in TumRehberler())
            {
                if (!RehberHasData(rid, RehberData.ID)) continue;
                if (GetRehberData<int>(rid, RehberData.Sahip) == playerNum &&
                    GetRehberData<int>(rid, RehberData.Telefon) == number)
                    return rid;
            }
        }
        catch { NAPI.Util.ConsoleOutput("NumaraKontrol fonksiyonunda hata!"); }
        return -1;
    }

    public static bool CheckRehberName(Player player, string name)
    {
        try
        {
            int playerNum = GetPlayerNumber(player);
            foreach (var rid in TumRehberler())
            {
                if (!RehberHasData(rid, RehberData.ID)) continue;
                if (GetRehberData<int>(rid, RehberData.Sahip) == playerNum &&
                    GetRehberData<string>(rid, RehberData.Isim) == name)
                    return true;
            }
        }
        catch { NAPI.Util.ConsoleOutput("NumaraKontrol fonksiyonunda hata!"); }
        return false;
    }

    public static int GetPlayerNumber(Player client)
        => client.HasData("character_cellphone") ? client.GetData<dynamic>("character_cellphone") : 0;

    [RemoteEvent("server:RehberSecildi")]
    public static void RehberSecildi(Player player, bool status, string number)
    {
        if (!status || string.IsNullOrEmpty(number) || GetPlayerNumber(player) == 0) return;

        if (number == "numaraekle")
        {
            TelefonUIKapat(player);
            NAPI.ClientEvent.TriggerClientEvent(player, "client:KartvizitEkle");
            return;
        }

        TelefonUIKapat(player);
        if (int.TryParse(number, out int num) && NumaraKontrol(GetPlayerNumber(player), num))
        {
            int rid = GetNumaraID(player, num);
            if (RehberHasData(rid, RehberData.ID))
            {
                string isim = GetRehberData<string>(rid, RehberData.Isim);
                NAPI.ClientEvent.TriggerClientEvent(player, "client:KartvizitIslem", isim, num);
                player.SetData("rehberIslem1", num);
            }
        }
        else Main.SendErrorMessage(player, "Rehber sisteminde bir hata oluştu.");
    }

    [RemoteEvent("server:KartvizitEklendi")]
    public static void KartvizitEklendi(Player player, bool status, string numara)
    {
        if (!int.TryParse(numara, out int num)) return;
        if (NumaraKontrol(GetPlayerNumber(player), num))
        {
            Main.SendErrorMessage(player, "Eklemek istediğiniz kişi zaten rehberinizde kayıtlı!");
            return;
        }
        if (num > 8 && num <= 0)
        {
            Main.SendErrorMessage(player, "Geçersiz telefon numarası girdiniz.");
            return;
        }
        player.SetData("kartvizitEkle1", num);
        NAPI.ClientEvent.TriggerClientEvent(player, "client:KartvizitEkleIki");
    }

    [RemoteEvent("server:KartvizitEkleIkiEklendi")]
    public static void KartvizitEkleIkiEklendi(Player player, bool status, string isim)
    {
        int num = player.GetData<int>("kartvizitEkle1");
        if (CheckRehberName(player, isim))
        {
            Main.SendErrorMessage(player, $"Rehberinizde {isim} adlı kişi kayıtlı. Farklı bir isimle tekrar deneyin.");
            return;
        }
        if (isim.Length > 32 || isim.Length <= 0)
        {
            Main.SendErrorMessage(player, "Geçersiz telefon numarası girdiniz.");
            return;
        }
        SaveRehber(player, GetPlayerNumber(player), num, isim);
    }

    private static void SaveRehber(Player player, int num, int tnum, string isim)
    {
        using (var connection = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO rehber (Sahip, Telefon, Isim) VALUES (@Sahip, @Telefon, @Isim);";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Sahip", num);
                command.Parameters.AddWithValue("@Telefon", tnum);
                command.Parameters.AddWithValue("@Isim", isim);
                command.ExecuteNonQuery();

                int sqlid = (int)command.LastInsertedId;
                SetRehberData(sqlid, RehberData.ID, sqlid);
                int rid = GetRehberData<int>(sqlid, RehberData.ID);
                SetRehberData(rid, RehberData.Sahip, num);
                SetRehberData(rid, RehberData.Telefon, tnum);
                SetRehberData(rid, RehberData.Isim, isim);

                Main.SendSuccessMessage(player, $"Kişi kaydedildi. Numara: {tnum} - isim: {isim} - ID: {sqlid}");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MYSQL Hata] Rehber kaydedilirken hata oluştu: {ex.Message}");
            }
        }
    }

    private static void UpdateRehberInDatabase(int rid, string column, string value)
    {
        using (var connection = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                connection.Open();
                int dbid = GetRehberData<int>(rid, RehberData.ID);
                string query = $"UPDATE rehber SET {column} = @value WHERE ID = @rehberid;";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", value);
                command.Parameters.AddWithValue("@rehberid", dbid);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MYSQL Hata] Rehber güncellenirken hata oluştu: {ex.Message}");
            }
        }
    }

    public static void LoadRehber()
    {
        using (var connection = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM rehber;";
                var command = new MySqlCommand(query, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int sqlid = reader.GetInt32("ID");
                    int num = reader.GetInt32("Sahip");
                    int tnum = reader.GetInt32("Telefon");
                    string isim = reader.GetString("Isim");

                    SetRehberData(sqlid, RehberData.ID, sqlid);
                    int rid = GetRehberData<int>(sqlid, RehberData.ID);
                    SetRehberData(rid, RehberData.Sahip, num);
                    SetRehberData(rid, RehberData.Telefon, tnum);
                    SetRehberData(rid, RehberData.Isim, isim);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MYSQL Hata] Rehber yüklenirken hata oluştu: {ex.Message}");
            }
        }
    }

    [RemoteEvent("server:KartvizitIslemYapildi")]
    public static void KartvizitIslemYapildi(Player player, bool status, int islem)
    {
        if (!status) return;
        int num = player.GetData<int>("rehberIslem1");
        int rid = GetNumaraID(player, num);
        string isim = GetRehberData<string>(rid, RehberData.Isim);

        switch (islem)
        {
            case 0: NAPI.ClientEvent.TriggerClientEvent(player, "client:KartvizitIkiIslem", isim, num); break;
            case 1: Arama_Yap(player, num); break;
            case 2:
                {
                    player.SetData("mesajAdim1", num);
                    NAPI.ClientEvent.TriggerClientEvent(player, "client:KisaMesajIki", num);
                    break;
                }
            case 3: NAPI.ClientEvent.TriggerClientEvent(player, "client:KartvizitSil", isim, num); break;
        }
    }

    [RemoteEvent("server:KartvizitSilOnay")]
    public static void KartvizitSilOnay(Player player, bool status)
    {
        if (status)
        {
            int num = player.GetData<int>("rehberIslem1");
            int rid = GetNumaraID(player, num);
            string isim = GetRehberData<string>(rid, RehberData.Isim);

            Main.SendServerMessage(player, $"Başarıyla {isim} ({num}) adlı rehber kaydını sildiniz.");
            RehberSil(player, num);
        }
    }

    public static void RehberSil(Player player, int num)
    {
        int rid = GetNumaraID(player, num);
        if (rid != -1)
        {
            string query = "DELETE FROM `rehber` WHERE `Telefon` = '" + num + "' AND `Sahip` = '" + GetPlayerNumber(player) + "';";
            Main.CreateMySqlCommand(query);
            RehberClearData(rid);
        }
    }



    [RemoteEvent("server:KartvizitIkiIslemYapildi")]
    public static void KartvizitIkiIslemYapildi(Player player, bool status, int islem)
    {
        if (!status) return;
        int num = player.GetData<int>("rehberIslem1");
        int rid = GetNumaraID(player, num);
        string isim = GetRehberData<string>(rid, RehberData.Isim);

        switch (islem)
        {
            case 0: NAPI.ClientEvent.TriggerClientEvent(player, "client:NumaraDuzenle", isim, num); break;
            case 1: NAPI.ClientEvent.TriggerClientEvent(player, "client:IsimDuzenle", isim, num); break;
        }
    }

    [RemoteEvent("server:NumaraDuzenlendi")]
    public static void NumaraDuzenlendi(Player player, bool status, string number)
    {
        if (!status) return;
        if (!int.TryParse(number, out int num) || (num > 8 && num <= 0))
        {
            Main.SendErrorMessage(player, "Geçersiz telefon numarası girdiniz.");
            return;
        }

        int numara = player.GetData<int>("rehberIslem1");
        int rid = GetNumaraID(player, numara);

        if (rid != -1 && RehberHasData(rid, RehberData.ID))
        {
            SetRehberData(rid, RehberData.Telefon, num);
            UpdateRehberInDatabase(rid, "Telefon", num.ToString());
        }
    }

    [RemoteEvent("server:IsimDuzenlendi")]
    public static void IsimDuzenlendi(Player player, bool status, string yeniisim)
    {
        if (!status) return;
        if (yeniisim.Length > 32 && yeniisim.Length <= 0)
        {
            Main.SendErrorMessage(player, "İsim minimum 1, maksimum 32 harf olabilir.");
            return;
        }

        int numara = player.GetData<int>("rehberIslem1");
        int rid = GetNumaraID(player, numara);

        if (rid != -1 && RehberHasData(rid, RehberData.ID))
        {
            SetRehberData(rid, RehberData.Isim, yeniisim);
            UpdateRehberInDatabase(rid, "Isim", yeniisim);
        }
    }

    public static Player GetNumberOwner(int number)
    {
        foreach (var player in NAPI.Pools.GetAllPlayers())
        {
            if (GetPlayerNumber(player) == number)
            {
                return player;
            }
        }

        return null;
    }

    public static void SMS_Gonder(Player player, int numara, string mesaj)
    {
        if (player == null) return;

        Player hedef = GetNumberOwner(numara);

        if (hedef == player)
        {
            Main.SendErrorMessage(player, "Kendinize Kısa mesaj gönderemezsiniz!");
            return;
        }

        if (hedef == null)
        {
            Main.SendErrorMessage(player, "Kısa mesaj göndermek istediğiniz kişiye ulaşılamıyor.");
            return;
        }

        if (!NAPI.Player.IsPlayerConnected(hedef))
        {
            Main.SendErrorMessage(player, "Kısa mesaj göndermek istediğiniz kişiye ulaşılamıyor.");
            return;
        }

        if (GetPlayerNumber(hedef) != numara)
        {
            Main.SendErrorMessage(player, "Kısa mesaj göndermek istediğiniz kişiye ulaşılamıyor.");
            return;
        }

        string hedefisim = "Yok";
        string bizimisim = "Yok";
        if (NumaraKontrol(GetPlayerNumber(player), numara))
        {
            int numaraid = GetNumaraID(player, numara);
            if (numaraid != -1)
            {
                int rid = GetRehberData<int>(numaraid, RehberData.ID);
                hedefisim = GetRehberData<string>(rid, RehberData.Isim);
            }
        }

        if (NumaraKontrol(GetPlayerNumber(hedef), GetPlayerNumber(player)))
        {
            int numaraid = GetNumaraID(hedef, GetPlayerNumber(player));
            if (numaraid != -1)
            {
                int rid = GetRehberData<int>(numaraid, RehberData.ID);
                bizimisim = GetRehberData<string>(rid, RehberData.Isim);
            }
        }

        if (hedefisim != "Yok")
        {
            Main.SendCustomChatMessasge(player, $"<font color='#f6ff00'>[SMS] >>: {hedefisim}: {mesaj}");
        }
        else Main.SendCustomChatMessasge(player, $"<font color='#f6ff00'>[SMS] >>: {numara}: {mesaj}");

        if (bizimisim != "Yok")
        {
            Main.SendCustomChatMessasge(hedef, $"<font color='#f6ff00'>[SMS] <<: {bizimisim}: {mesaj}");
        }
        else Main.SendCustomChatMessasge(hedef, $"<font color='#f6ff00'>[SMS] <<: {GetPlayerNumber(player)}: {mesaj}");

        player.SetData("mesajAdim1", -1);
    }

    [Command("sms", "~y~[!]~w~: /sms [Telefon Numarası] [Mesaj]", Alias = "mesaj, mesajgonder", GreedyArg = true)]
    public static void SMS(Player player, Int32 numara, string mesaj)
    {
        if (numara <= 0 && numara > 8)
        {
            Main.SendErrorMessage(player, "Geçersiz telefon numarası girdiniz.");
            return;
        }

        if (mesaj.Length <= 0 && mesaj.Length > 128)
        {
            Main.SendErrorMessage(player, "Mesaj minimum 1, maksimum 128 harf olabilir.");
            return;
        }

        SMS_Gonder(player, numara, mesaj);
    }

    [Command("ara")]
    public static void Arama_Yap(Player player, int numara)
    {
        if (player == null) return;

        Player hedef = GetNumberOwner(numara);

        if (hedef == player)
        {
            Main.SendErrorMessage(player, "Kendinizi arayamazsınız!");
            return;
        }

        if (hedef == null)
        {
            Main.SendErrorMessage(player, "Aramak istediğiniz kişiye ulaşılamıyor.");
            return;
        }

        if (!NAPI.Player.IsPlayerConnected(hedef))
        {
            Main.SendErrorMessage(player, "Aramak istediğiniz kişiye ulaşılamıyor.");
            return;
        }

        if (GetPlayerNumber(hedef) != numara)
        {
            Main.SendErrorMessage(player, "Aramak istediğiniz kişiye ulaşılamıyor.");
            return;
        }

        if (player.GetData<int>("oyuncuAramada") == ARAMA_KONUSUYOR)
        {
            Main.SendErrorMessage(player, "Şu anda farklı birisini arayamazsınız.");
            return;
        }

        if (player.GetData<int>("oyuncuAramada") == ARAMA_ARIYOR)
        {
            Main.SendErrorMessage(player, "Şu anda farklı birisini arayamazsınız.");
            return;
        }

        if (player.GetData<int>("oyuncuAramada") == ARAMA_ARANIYOR)
        {
            Main.SendErrorMessage(player, "Şu anda farklı birisini arayamazsınız.");
            return;
        }

        if (hedef.GetData<int>("oyuncuAramada") == ARAMA_KONUSUYOR)
        {
            Main.SendErrorMessage(player, "Aradığınız kişi şu anda başka birisiyle konuşuyor.");
            return;
        }

        if (hedef.GetData<int>("oyuncuAramada") == ARAMA_ARIYOR)
        {
            Main.SendErrorMessage(player, "Aradığınız kişi şu anda başka birisiyle konuşuyor.");
            return;
        }

        if (hedef.GetData<int>("oyuncuAramada") == ARAMA_ARANIYOR)
        {
            Main.SendErrorMessage(player, "Aradığınız kişi şu anda başka birisiyle konuşuyor.");
            return;
        }

        string hedefisim = "Yok";
        string bizimisim = "Yok";
        if (NumaraKontrol(GetPlayerNumber(player), numara))
        {
            int numaraid = GetNumaraID(player, numara);
            if (numaraid != -1)
            {
                int rid = GetRehberData<int>(numaraid, RehberData.ID);
                hedefisim = GetRehberData<string>(rid, RehberData.Isim);
            }
        }

        if (NumaraKontrol(GetPlayerNumber(hedef), GetPlayerNumber(player)))
        {
            int numaraid = GetNumaraID(hedef, GetPlayerNumber(player));
            if (numaraid != -1)
            {
                int rid = GetRehberData<int>(numaraid, RehberData.ID);
                bizimisim = GetRehberData<string>(rid, RehberData.Isim);
            }
        }

        Main.EmoteMessage(player, "telefonunda bir kaç numara tuşlar.");

        player.SetData("oyuncuAramada", ARAMA_ARIYOR);
        hedef.SetData("oyuncuAramada", ARAMA_ARANIYOR);

        player.SetData("KonusulanKisi", hedef);
        hedef.SetData("KonusulanKisi", player);

        if (hedefisim != "Yok")
        {
            Main.SendServerMessage(player, $"{hedefisim} aranıyor, lütfen cevap vermesini bekleyin. /cagrired ile çağrıyı bitirebilirsiniz.");
        }
        else Main.SendServerMessage(player, $"{numara} aranıyor, lütfen cevap vermesini bekleyin. /cagrired ile çağrıyı bitirebilirsiniz.");

        if (bizimisim != "Yok")
        {
            Main.SendInfoMessage(hedef, $"Gelen Arama: {bizimisim} - /cagrikabul ile çağrıyı kabul edebilir, /cagrired ile çağrıyı kapatabilirsiniz.");
        }
        else Main.SendInfoMessage(hedef, $"Gelen Arama: {GetPlayerNumber(player)} - /cagrikabul ile çağrıyı kabul edebilir, /cagrired ile çağrıyı kapatabilirsiniz.");

        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, hedef);
        foreach (Player target in proxPlayers)
        {
            Main.SendCustomChatMessasge(target, "<font color ='#C2A2DA'>** Telefonu çalmaktadır. ((" + UsefullyRP.GetPlayerNameToTarget(hedef, target) + "))");
        }
    }

    [Command("cagrikabul")]
    public static void CagriKabul(Player player)
    {
        if (player.GetData<int>("oyuncuAramada") != ARAMA_ARANIYOR)
        {
            Main.SendErrorMessage(player, "Gelen çağrı yok.");
            return;
        }
        Player hedef = null;
        int bulunan;
        bulunan = 0;
        foreach (var p in NAPI.Pools.GetAllPlayers())
        {
            if (NAPI.Player.IsPlayerConnected(p))
            {
                if (p.GetData<dynamic>("status") == true)
                {
                    if (p.GetData<int>("oyuncuAramada") == ARAMA_ARIYOR)
                    {
                        if (p.GetData<Player>("KonusulanKisi") == player)
                        {
                            hedef = p;
                            bulunan++;
                            break;
                        }
                    }
                }
            }
        }
        if (bulunan <= 0)
        {
            Main.SendErrorMessage(player, "Bağlantı kesildi.");
            return;
        }

        player.SetData("oyuncuAramada", ARAMA_KONUSUYOR);
        hedef.SetData("oyuncuAramada", ARAMA_KONUSUYOR);

        player.SetData("KonusulanKisi", hedef);
        hedef.SetData("KonusulanKisi", player);

        Main.SendServerMessage(player, "Alıcı telefonu açtı, /cagrired ile çağrıyı istediğiniz zaman sonlandırabilirsiniz.");
        Main.SendServerMessage(hedef, "Telefonu açtın, /cagrired ile çağrıyı istediğiniz zaman sonlandırabilirsiniz.");
    }

    [Command("cagrired")]
    public static void CagriRed(Player player)
    {
        if (player.GetData<int>("oyuncuAramada") == ARAMA_BOS)
        {
            Main.SendErrorMessage(player, "Herhangi bir aramada değilsiniz.");
            return;
        }

        Player hedef = null;
        int bulunan;
        bulunan = 0;
        foreach (var p in NAPI.Pools.GetAllPlayers())
        {
            if (NAPI.Player.IsPlayerConnected(p))
            {
                if (p.GetData<dynamic>("status") == true)
                {
                    if (p.GetData<int>("oyuncuAramada") != ARAMA_BOS)
                    {
                        if (p.GetData<Player>("KonusulanKisi") == player)
                        {
                            hedef = p;
                            bulunan++;
                            break;
                        }
                    }
                }
            }
        }
        if (bulunan <= 0)
        {
            Main.SendErrorMessage(player, "Herhangi bir aramada değilsiniz.");
            return;
        }

        if (player.GetData<int>("oyuncuAramada") == ARAMA_ARANIYOR)
        {
            Main.SendServerMessage(hedef, "Giden çağrı reddedildi.");
            Main.SendServerMessage(player, "Gelen çağrı reddedildi.");

            player.SetData("oyuncuAramada", ARAMA_BOS);
            hedef.SetData("oyuncuAramada", ARAMA_BOS);

            player.SetData<Player>("KonusulanKisi", null);
            hedef.SetData<Player>("KonusulanKisi", null);
        }
        else if (player.GetData<int>("oyuncuAramada") == ARAMA_ARIYOR)
        {
            Main.SendServerMessage(player, "Çağrı bitirildi.");

            player.SetData("oyuncuAramada", ARAMA_BOS);
            hedef.SetData("oyuncuAramada", ARAMA_BOS);

            player.SetData<Player>("KonusulanKisi", null);
            hedef.SetData<Player>("KonusulanKisi", null);
        }
        else if (player.GetData<int>("oyuncuAramada") == ARAMA_KONUSUYOR)
        {
            Main.SendServerMessage(player, "Telefonu kapattınız.");
            Main.SendServerMessage(hedef, "Karşıdaki kişi konuşmayı sonlandırdı.");

            player.SetData("oyuncuAramada", ARAMA_BOS);
            hedef.SetData("oyuncuAramada", ARAMA_BOS);

            player.SetData<Player>("KonusulanKisi", null);
            hedef.SetData<Player>("KonusulanKisi", null);
        }
    }

    [ServerEvent(Event.PlayerDisconnected)]
    public void OnPlayerDisconnect(Player player, DisconnectionType type, string reason)
    {
        player.SetData("mesajAdim1", 0);
        player.SetData("rehberIslem1", 0);
        player.SetData("kartvizitEkle1", 0);
        
        if (player.GetData<int>("oyuncuAramada") != ARAMA_BOS)
        {
            Player hedef = player.GetData<Player>("KonusulanKisi");
            if (hedef != null)
            {
                if (player.GetData<int>("oyuncuAramada") == ARAMA_ARANIYOR)
                {
                    Main.SendServerMessage(hedef, "Giden çağrı reddedildi.");
                    Main.SendServerMessage(player, "Gelen çağrı reddedildi.");

                    player.SetData("oyuncuAramada", ARAMA_BOS);
                    hedef.SetData("oyuncuAramada", ARAMA_BOS);

                    player.SetData<Player>("KonusulanKisi", null);
                    hedef.SetData<Player>("KonusulanKisi", null);
                }
                else if (player.GetData<int>("oyuncuAramada") == ARAMA_ARIYOR)
                {
                    Main.SendServerMessage(player, "Çağrı bitirildi.");

                    player.SetData("oyuncuAramada", ARAMA_BOS);
                    hedef.SetData("oyuncuAramada", ARAMA_BOS);

                    player.SetData<Player>("KonusulanKisi", null);
                    hedef.SetData<Player>("KonusulanKisi", null);
                }
                else if (player.GetData<int>("oyuncuAramada") == ARAMA_KONUSUYOR)
                {
                    Main.SendServerMessage(player, "Telefonu kapattınız.");
                    Main.SendServerMessage(hedef, "Karşıdaki kişi konuşmayı sonlandırdı.");

                    player.SetData("oyuncuAramada", ARAMA_BOS);
                    hedef.SetData("oyuncuAramada", ARAMA_BOS);

                    player.SetData<Player>("KonusulanKisi", null);
                    hedef.SetData<Player>("KonusulanKisi", null);
                }
            }
            else
            {
                player.SetData("oyuncuAramada", ARAMA_BOS);
                hedef.SetData("oyuncuAramada", ARAMA_BOS);

                player.SetData<Player>("KonusulanKisi", null);
                hedef.SetData<Player>("KonusulanKisi", null);
            }
        }
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnect(Player player)
    {
        player.SetData("mesajAdim1", 0);
        player.SetData("rehberIslem1", 0);
        player.SetData("kartvizitEkle1", 0);
        player.SetData("oyuncuAramada", ARAMA_BOS);
        player.SetData<Player>("KonusulanKisi", null);
    }

    public static void MesajGonder(Player player, string mesaj)
    {

        Player hedef = null;
        int bulunan;
        bulunan = 0;
        foreach (var p in NAPI.Pools.GetAllPlayers())
        {
            if (NAPI.Player.IsPlayerConnected(p))
            {
                if (p.GetData<dynamic>("status") == true)
                {
                    if (p.GetData<int>("oyuncuAramada") != ARAMA_BOS)
                    {
                        if (p.GetData<Player>("KonusulanKisi") == player)
                        {
                            hedef = p;
                            bulunan++;
                            break;
                        }
                    }
                }
            }
        }
        if (bulunan <= 0)
        {
            Main.SendErrorMessage(player, "Herhangi bir aramada değilsiniz.");
            return;
        }

        string hedefisim = "Yok";
        string bizimisim = "Yok";
        int numara = GetPlayerNumber(hedef);
        if (NumaraKontrol(GetPlayerNumber(player), numara))
        {
            int numaraid = GetNumaraID(player, numara);
            if (numaraid != -1)
            {
                int rid = GetRehberData<int>(numaraid, RehberData.ID);
                hedefisim = GetRehberData<string>(rid, RehberData.Isim);
            }
        }

        if (NumaraKontrol(GetPlayerNumber(hedef), GetPlayerNumber(player)))
        {
            int numaraid = GetNumaraID(hedef, GetPlayerNumber(player));
            if (numaraid != -1)
            {
                int rid = GetRehberData<int>(numaraid, RehberData.ID);
                bizimisim = GetRehberData<string>(rid, RehberData.Isim);
            }
        }

        if (NAPI.Player.IsPlayerConnected(player) && player.GetData<dynamic>("status") == true)
        {
            if (NAPI.Player.IsPlayerConnected(hedef) && hedef.GetData<dynamic>("status") == true)
            {

                if (hedefisim != "Yok")
                {
                    Main.SendCustomChatMessasge(player, $"<font color ='#00c4c1'> (Cep Telefonu) {AccountManage.GetCharacterName(player)}: {mesaj}");
                }
                //else Main.SendCustomChatMessasge(player, $"<font color ='#00c4c1'> (Cep Telefonu) {numara}: {mesaj}");

                if (bizimisim != "Yok")
                {
                    Main.SendCustomChatMessasge(hedef, $"<font color ='#00c4c1'> (Cep Telefonu) {bizimisim}: {mesaj}");
                }
                else Main.SendCustomChatMessasge(hedef, $"<font color ='#00c4c1'> (Cep Telefonu) {GetPlayerNumber(player)}: {mesaj}");
            }
        }
    }
}