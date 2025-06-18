using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class adminCommands : Script
{
    public static int HELPER = 1;
    public static int COORDENADOR = 8;
    public static int DEVELOPER = 9;
    public static int MANAGMENT = 10;

   

    public class GetVehicleInfo : Script
    {
        public GetVehicleInfo()
        {


        }
    }

    [RemoteEvent("kickclient")]
    public static void kickclient(Player Client)
    {
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " kickclient REMOTE kullanıldı");
        Client.Kick();
    }

    [Command("acloth", "~y~[!]~w~: /acloth [ID/İsim] [Slot ID] [Texture]")]
    public void glog(Player player, int id, int slotid, int texture)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için iş başında olmalısınız, /aduty komutu ile iş başına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) <= 7)
        {
            return;
        }
        player.SetClothes(id, slotid, texture);
    }

    [Command("aehliyetver", "~y~[!]~w~: /aehliyetver [ID/İsim] [0/1]")]
    public void setcarlic(Player player, string NameOrID, int set)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için iş başında olmalısınız, /aduty komutu ile iş başına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) <= 6)
        {
            return;
        }
        Player target = Main.findPlayer(player, NameOrID);

        if (target != null)
        {
            if (set == 0) Main.SendCustomChatMessasge(player, "Başarıyla " + target.Name + " adlı oyuncunun sürücü lisansını aldınız!");
            if (set == 1) Main.SendCustomChatMessasge(player, "başarıyla " + target.Name + " adlı oyuncuya sürücü lisansı verdiniz.");
            target.SetData<dynamic>("character_car_lic", set);
        }
    }

    [Command("gno")]
    public void GetNearestObject(Player player)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için iş başında olmalısınız, /aduty komutu ile iş başına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) < 6)
        {
            return;
        }
        player.TriggerEvent("GetNearestObject");
    }

    [Command("setaskin", "~y~[!]~w~: /setskin [ID/İsim] [Hash]", Alias = "setskin")]
    public void SetAdminSkin(Player Client, string nameOrid, string hash)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için iş başında olmalısınız, /aduty komutu ile iş başına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 5)
        {
            return;
        }
        if (!UInt32.TryParse(hash, out UInt32 skin))
        {
            Main.SendCustomChatMessasge(Client, "Geçersiz Hash.");
            return;
        }
        if (Enum.GetName(typeof(PedHash), skin) == null)
        {
            Main.SendCustomChatMessasge(Client, "Geçersiz kıyafet!");
            return;
        }

        Player target = Main.findPlayer(Client, nameOrid);
        if (target == null)
        {
            Main.DisplayErrorMessage(Client, "error", "Oyuncu sunucuda değil!");
            return;
        }
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " /setskin kullandı: " + hash.ToString());
        Client.SetSkin(skin);
    }

    [Command("freeze", "~y~[!]~w~: /dondur [ID/İsim] [0/1]", Alias = "dondur")]
    public void FreezeCmd(Player Client, string idorname, int stats = 0)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 3)
        {
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için iş başında olmalısınız, /aduty komutu ile iş başına geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idorname);
        if (target.Exists)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " /freeze kullandı!: " + stats.ToString());

            switch (stats)
            {
                case 1:
                    target.TriggerEvent("freeze", true);
                    target.TriggerEvent("freezeEx", true);
                    return;
                default:
                    target.TriggerEvent("freeze", false);
                    target.TriggerEvent("freezeEx", false);
                    return;
            }
        }
    }

    [Command("gotopos", "~y~[!]~w~: /gotopos [X] [Y] [Z]", Alias = "posgit")]
    public void command_apos(Player Client, int pos1, int pos2, int pos3)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için iş başında olmalısınız, /aduty komutu ile iş başına geçebilirsiniz.");
            return;
        }

        NAPI.Entity.SetEntityPosition(Client, new Vector3(pos1, pos2, pos3));
    }

    [Command("apm", "~y~[!]~w~: /apm [ID] [Mesaj]", Alias = "adminpm", GreedyArg = true)]
    public void adminpm(Player Client, string ID, string message)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için iş başında olmalısınız, /aduty komutu ile iş başına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 1)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        Player target = Main.findPlayer(Client, ID);
        if (target != null)
        {
            Main.SendCustomChatMessasge(target, "~y~[ADMIN PM] " + adminCommands.GetPlayerAdminRank(Client) + " ~y~" + adminCommands.GetAdminName(Client) + "~y~ PM: " + message);
            Main.SendCustomChatMessasge(Client, "~y~[ADMIN PM] " + target.Name + " PM:" + message);
        }
    }

    [Command("q", Alias = "quit")]
    public void quitgame(Player Client)
    {
        Client.Kick();
        return;
    }

    [Command("ajail", "~y~[!]~w~: /ajail [ID/İsim] [süre] [sebep]", GreedyArg = true)]
    public void CMD_setdimensao(Player Client, string idOrName, int minutes, string reason)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 3)
        {
            Main.SendErrorMessage(Client, "Yeterli yetkiniz yok!");
            return;
        }

        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için iş başında olmalısınız, /aduty komutu ile iş başına geçebilirsiniz.");
            return;
        }

        Player target = Main.findPlayer(Client, idOrName);
        if (target == null)
        {
            Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
            return;
        }
        if (target.GetData<dynamic>("status") != true)
        {
            Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
            return;
        }
        if (reason.Length < 1 && reason.Length > 34)
        {
            Main.SendErrorMessage(Client, "Sebep minimum 1, maksimum 34 harf olabilir.");
            return;
        }
        if (minutes < 1)
        {
            Main.SendErrorMessage(Client, "Süre 1 dakikadan az olamaz!");
            return;
        }

        GameLog.ELog(Client, GameLog.MyEnum.Admin, ", " + AccountManage.GetCharacterName(target) + " adlı oyuncuyu jaile attı. Süre: " + minutes + " dakika, sebep: " + reason);
        Main.SendCustomChatToAll("~r~ADM:~w~ " + AccountManage.GetCharacterName(target) + ",~w~ " + AccountManage.GetCharacterName(Client) + " adlı yetkili tarafından " + minutes + " dakika hapise atıldı, Sebep: " + reason + ".");

        OOC_Prison(target, Client, minutes * 60, reason);
    }

    [Command("aunjail", "~y~[!]~w~: /aunjail [ID/İsim]")]
    public void CMD_setdimensao(Player Client, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }

        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için iş başında olmalısınız, /aduty komutu ile iş başına geçebilirsiniz.");
            return;
        }

        Player target = Main.findPlayer(Client, idOrName);

        if (target == null)
        {
            Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
            return;
        }

        if (target.GetData<dynamic>("status") != true)
        {
            Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
            return;
        }

        if (target.GetData<dynamic>("character_ooc_prison_time") < 2)
        {
            Main.SendErrorMessage(Client, "Oyuncu OOC hapiste değil.");
            return;
        }

        target.SetData<dynamic>("character_ooc_prison_time", 1);
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " oyuncuyu /aunjail ile hapisten çıkarttı: " + AccountManage.GetCharacterName(target));
        Main.SendInfoMessage(target, "(" + GetPlayerAdminRank(Client) + ") " + AccountManage.GetCharacterName(Client) + " adlı yetkili tarafından hapisten çıkartıldınız!");
        Main.SendInfoMessage(Client, AccountManage.GetCharacterName(target) + " adlı oyuncuyu hapisten çıkarttınız!");
    }

    [Command("unjail", "~y~[!]~w~: /unjail [ID/İsim]")]
    public void CMD_unjailcmd(Player Client, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 5)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }

        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için iş başında olmalısınız, /aduty komutu ile iş başına geçebilirsiniz.");
            return;
        }

        Player target = Main.findPlayer(Client, idOrName);

        if (target == null)
        {
            Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
            return;
        }

        if (target.GetData<dynamic>("status") != true)
        {
            Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
            return;
        }

        if (target.GetData<dynamic>("character_prison_time") < 2)
        {
            Main.SendErrorMessage(Client, "Oyuncu IC hapiste değil!");
            return;
        }

        target.SetData<dynamic>("character_prison_time", 1);
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " oyuncuyu /aunjail ile hapisten çıkarttı: " + AccountManage.GetCharacterName(target));
        Main.SendInfoMessage(target, "(" + GetPlayerAdminRank(Client) + ") " + AccountManage.GetCharacterName(Client) + " adlı yetkili tarafından hapisten çıkartıldınız!");
        Main.SendInfoMessage(Client, AccountManage.GetCharacterName(target) + " adlı oyuncuyu hapisten çıkarttınız!");
    }

    public static void OOC_Prison(Player Client, Player admin, int time, string reason)
    {
        int new_time = time;
        if (NAPI.Data.GetEntityData(Client, "character_prison") > 0)
        {
            new_time += Client.GetData<dynamic>("character_prison_time");
            Client.SetData<dynamic>("character_prison", 0);
            Client.SetData<dynamic>("character_prison_time", 0);
        }
        Client.SetData<dynamic>("character_ooc_prison_time", new_time);

        SendBackToPrison(Client);
    }

    public static void SendBackToPrison(Player Client)
    {
        if (Client.GetData<dynamic>("character_ooc_prison_time") > 0)
        {
            NAPI.Entity.SetEntityPosition(Client, new Vector3(1651.297, 2573.728, 45.56485));
            Client.Rotation = new Vector3(0, 0, 181.6034);
            Client.Dimension = 255;
        }
    }

    public static string GetPlayerAdminRank(Player Client)
    {
        string rank = "Bilinmiyor";

        switch (AccountManage.GetPlayerAdmin(Client))
        {
            case 1: rank = "Game Staff"; break;
            case 2: rank = "Admin I"; break;
            case 3: rank = "Admin II"; break;
            case 4: rank = "Admin III"; break;
            case 5: rank = "Admin IV"; break;
            case 6: rank = "Lead Admin"; break;
            case 7: rank = "High Lead Admin"; break;
            case 8: rank = "Management"; break;
            case 9: rank = "Founder"; break;
            default: rank = "Oyuncu"; break;
        }
        return rank;
    }

    [Command("adminsifrekontrol", "~y~[!]~w~: /adminsifrekontrol [ID/İsim]")]
    public static void ProveriAPin(Player Client, string idOrName)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız. /aduty komutunu kullanarak göreve geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 8)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }

        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (AccountManage.GetPlayerAdmin(target) < 1)
            {
                Main.SendErrorMessage(Client, "Admin şifresine bakmak istediğiniz kişi yetkili değil!");
                return;
            }

            Main.SendSuccessMessage(Client, AccountManage.GetCharacterName(target) + " adlı yetkilinin admin şifresi: " + target.GetData<dynamic>("admin_pin"));
        }
    }

    [Command("ad", "~y~[!]~w~: /aduty [Admin Şifresi]", Alias = "aduty, adminduty, aisbasi")]
    public static void CMD_sa(Player Client, int PIN)
    {
        if (PIN != Client.GetData<int>("admin_pin"))
        {
            Main.SendErrorMessage(Client, "Hatalı şifre!");
            return;
        }
        if (PIN == 0)
        {
            Main.SendErrorMessage(Client, "Şifre 0 olamaz!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 1)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 1)
        {
            foreach (var target in NAPI.Pools.GetAllPlayers())
            {
                if (target.GetData<dynamic>("status") == true && AccountManage.GetPlayerAdmin(target) > 1)
                {
                    Main.SendMessageWithTagToPlayer(target, Main.EMBED_RED + "ADM: ", AccountManage.GetCharacterName(Client) + " işbaşından çıkış yaptı!");
                }
            }

            Client.SetData<dynamic>("admin_duty", 0);
            Client.SetSharedData("Invicible_Admin", false);
        }
        else
        {
            foreach (var target in NAPI.Pools.GetAllPlayers())
            {
                if (target.GetData<dynamic>("status") == true && AccountManage.GetPlayerAdmin(target) > 0)
                {
                    Main.SendMessageWithTagToPlayer(target, Main.EMBED_RED + "ADM: ", AccountManage.GetCharacterName(Client) + " işbaşına geçti!");
                }
            }
            Client.SetData<dynamic>("admin_duty", 1);
            Client.SetSharedData("Invicible_Admin", true);

        }

    }

    [Command("asifreduzenle", "~y~[!]~w~: /asifreduzenle [ID/İsim] [Yeni Şifre]")]
    public static void setapinCMD(Player Client, string idOrName, int PIN)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız. /aduty komutunu kullanarak göreve geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {

            if (AccountManage.GetPlayerAdmin(target) < 1)
            {
                Main.SendErrorMessage(Client, "Admin şifresini düzenlemek istediğiniz kişi yetkili değil!");
                return;
            }

            GameLog.ELog(Client, GameLog.MyEnum.Admin, " admin şifresini ayarladı. /asifreduzenle: " + AccountManage.GetCharacterName(target) + " için: " + PIN.ToString());
            Main.CreateMySqlCommand("UPDATE `characters` SET `apin` = '" + PIN + "'  WHERE `userid` = '" + target.GetData<dynamic>("player_sqlid") + "';");
            target.SetData<dynamic>("admin_pin", PIN);
            Main.SendSuccessMessage(Client, AccountManage.GetCharacterName(target) + " adlı yetkilinin admin şifresi " + PIN.ToString() + " olarak ayarlandı.");
        }
        else Main.SendErrorMessage(Client, "Oyuncu sunucuda değil.");
    }

    [Command("setadmin", "~y~[!]~w~: /setadmin [ID/İsim] [Level]")]
    public static void SetPlayerAdminLevel(Player Client, string idOrName, int level)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız. /aduty komutunu kullanarak göreve geçebilirsiniz.");
            return;
        }
        if (level >= AccountManage.GetPlayerAdmin(Client))
        {
            Main.SendErrorMessage(Client, "Kendi seviyenizden daha yüksek bir admin seviyesi belirleyemezsiniz!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " admin seviyesini değiştirdi /setadmin: " + AccountManage.GetCharacterName(target) + " için: " + level.ToString());
            AccountManage.SetPlayerAdmin(target, level);

            Main.SendCustomChatMessasge(Client, "~o~[ADMIN]:~w~ " + AccountManage.GetCharacterName(target) + " adlı oyuncunun admin seviyesini " + level + " (" + GetPlayerAdminRank(target) + ") olarak ayarladınız.");
            Main.SendCustomChatMessasge(target, "~o~[ADMIN]:~w~  " + GetPlayerAdminRank(Client) + " " + AccountManage.GetCharacterName(Client) + " admin seviyenizi " + level + " (" + GetPlayerAdminRank(target) + ") olarak belirledi.");
            Main.CreateMySqlCommand("UPDATE `characters` SET `adminLevel` = '" + target.GetData<dynamic>("admin_level") + "'  WHERE `userid` = '" + target.GetData<dynamic>("player_sqlid") + "';");
        }
        else Main.DisplayErrorMessage(Client, "error", "Oyuncu sunucuda değil!");
    }

    [Command("kick", "~y~[!]~w~: /kick [ID/İsim] [Sebep]", GreedyArg = true)]
    public void CMD_kick(Player Client, string idOrName, string reason)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 3)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız. /aduty komutunu kullanarak göreve geçebilirsiniz.");
            return;
        }

        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " /kick komutunu kullandı. Sunucudan atılan kişi: " + AccountManage.GetCharacterName(target) + " Sebep: " + reason.ToString());
            Main.SendCustomChatToAll("~r~[KICK] " + target.Name + " sunucudan atıldı, sebep: " + reason.ToString() + "!");


            target.Kick();
        }
        else Main.DisplayErrorMessage(Client, "info", "Oyuncu sunucuda değil!");
    }

    [Command("getcar", "~y~[!]~w~: /getcar [Araç ID]")]
    public void getcar(Player Client, int id)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Görevde olmalısınız! /aduty komutuyla görev moduna geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        try
        {
            foreach (Vehicle veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.Handle.Value == id)
                {
                    GameLog.ELog(Client, GameLog.MyEnum.Admin, " /getcar komutunu kullandı: " + veh.NumberPlate);

                    veh.Position = Client.Position.Around(3);
                    veh.Rotation = new Vector3(0, 0, veh.Rotation.Z);
                    Main.DisplayErrorMessage(Client, "success", "Model: " + veh.Model + " ID: " + veh.Handle.Value + " Araç yanına çekildi!");
                    return;
                }
            }
            Main.DisplayErrorMessage(Client, "error", "Geçersiz ID!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    [Command("setfuel", "~y~[!]~w~: /setfuel [Benzin Miktarı]", Alias = "abenzinduzenle")]
    public void setfuelcmd(Player Client, double fuel)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 5)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 6)
        {
            Main.SendErrorMessage(Client, "Görevde olmalısınız! /aduty komutuyla görev moduna geçebilirsiniz.");
            return;
        }

        Main.SetVehicleFuel(Client.Vehicle, fuel);
    }

    [Command("aplaka", "~y~[!]~w~: /aplaka [Plaka]", Alias = "aplakaduzenle")]
    public void cc(Player Client, string Tablice)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 6)
        {
            Main.SendErrorMessage(Client, "Görevde olmalısınız! /aduty komutuyla görev moduna geçebilirsiniz.");
            return;
        }
        if (Tablice.Length > 8)
        {
            return;
        }
        Vehicle veh = Client.Vehicle;
        veh.NumberPlate = Tablice;
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " kullandı: " + Tablice);
    }


    [Command("spec", "~y~[!]~w~: /spec [id/İsim] (Bitirmek için /spec off)")]
    public void CMD_espiar(Player Client, string idOrName)
    {
        try
        {
            if (AccountManage.GetPlayerAdmin(Client) < 2)
            {
                Main.SendErrorMessage(Client, "Yetkiniz yok!");
                return;
            }

            if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) != 4)
            {
                Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız! /aduty komutuyla görev moduna geçebilirsiniz.");
                return;
            }

            if (idOrName == "off")
            {
                if (Client.GetData<dynamic>("spmode") == true)
                {
                    NAPI.ClientEvent.TriggerClientEvent(Client, "spMode");
                    Client.SetData<dynamic>("spclient", -1);
                    Client.Dimension = Client.GetData<dynamic>("spdim");
                    NAPI.Entity.SetEntityPosition(Client, Client.GetData<dynamic>("sppos"));
                    Client.Transparency = 255;
                    Client.SetSharedData("isadmininvicible", false);
                    Client.SetData<dynamic>("spmode", false);
                    Main.SendCustomChatMessasge(Client, "Başarıyla specten çıktın.");
                }
                return;
            }

            Player target = Main.findPlayer(Client, idOrName);

            if (target != null)
            {
                if (Client.Value == target.Value)
                {
                    Main.SendCustomChatMessasge(Client, "Kendini izleyemezsin.");
                    return;
                }
                if (Client.HasSharedData("badgeon"))
                {
                    Client.SetSharedData("badgeon", false);
                }
                GameLog.ELog(Client, GameLog.MyEnum.Admin, "/spec komutunu kullandı. İzlenen kişi: " + AccountManage.GetCharacterName(target));

                NAPI.ClientEvent.TriggerClientEvent(Client, "spMode");
                Client.SetData<dynamic>("sppos", Client.Position);
                Client.SetData<dynamic>("spdim", Client.Dimension);
                Client.SetSharedData("isadmininvicible", true);
                Client.TriggerEvent("freeze", true);
                NAPI.Entity.SetEntityPosition(Client, (target.Position + new Vector3(0, 0, 50)));
                Client.Dimension = target.Dimension;

                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(Client))
                    {
                        Client.TriggerEvent("freeze", false);
                        Client.SetData<dynamic>("spmode", true);
                        Client.SetData<dynamic>("spclient", target.Value);
                        Main.SendCustomChatMessasge(Client, "~wİzlenen kişi: " + AccountManage.GetCharacterName(target) + "~w~.");
                        Client.Transparency = 0;
                        NAPI.ClientEvent.TriggerClientEvent(Client, "attachEntityToEntity", Client, target, 0, new Vector3(0, 0, 5), new Vector3(0, 0, 3));
                    }
                }, 4000);

            }
            else InteractMenu_New.SendNotificationError(Client, "Oyuncu sunucuda değil!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    [Command("getpos", Alias = "posyazdir")]
    public void getpos(Player Client)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız! /aduty komutuyla görev moduna geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        Main.SendCustomChatMessasge(Client, $"{Client.Position}  ~r~ || ~g~{Client.Heading} ~b~{Client.Rotation}");
        if (Client.Vehicle != null)
            Main.SendCustomChatMessasge(Client, $"{Client.Vehicle.Position}  ~r~ || ~g~{Client.Vehicle.Heading} ~b~{Client.Vehicle.Rotation}");
    }


    [RemoteEvent("fly_admin")]
    public void fly_remotevent(Player client)
    {
        startFreemode(client);
    }

    [RemoteEvent("ESP_ADMIN")]
    public void ESP_ADMIN(Player client)
    {
        if (AccountManage.GetPlayerAdmin(client) <= 4)
        {
            return;
        }
        if (client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }

        client.TriggerEvent("ESP_ADMIN");

    }

    [Command("fly")]
    public void startFreemode(Player Client)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 2)
        {
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }

        Client.TriggerEvent("flyModeStart");
    }

    [Command("awarn", "~y~[!]~w~: /auyari [ID/İsim] [Sebep]", Alias = "auyari, uyari", GreedyArg = true)]
    public void CMD_Admin_Warn(Player Client, int ID, string reason = "")
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız! /aduty komutuyla görev moduna geçebilirsiniz.");
            return;
        }
        if (reason == "")
        {
            Main.SendErrorMessage(Client, "Lütfen bir sebep giriniz!");
            return;
        }
        Player target = Main.getClientFromId(Client, ID);
        if (target != null)
        {
            Main.SendCustomChatMessasge(Client, "~c~ " + AccountManage.GetCharacterName(target) + " adlı oyuncuya 1 uyarı puanı verdiniz, sebep: " + reason);
            Main.SendCustomChatMessasge(target, "~r~[WARN] Admin " + GetPlayerAdminRank(Client) + " " + GetAdminName(Client) + "~w~ size 1 uyarı puanı verdi, sebep: " + reason);
            Main.CreateMySqlCommand("INSERT INTO `admin_warns` (`user_id`,`character_name`,`admin_user_id`,`admin_name`,`reason`) VALUES ('" + AccountManage.GetPlayerUserSQLID(target) + "','" + AccountManage.GetCharacterName(target) + "','" + AccountManage.GetPlayerUserSQLID(Client) + "','" + AccountManage.GetCharacterName(Client) + "','" + reason + "') ");
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " /awarn komutunu kullandı. Uyarılan Kişi: " + AccountManage.GetCharacterName(target) + ", Sebep: " + reason);
        }
        else
        {
            Main.DisplayErrorMessage(Client, "error",  "Bir hata oluştu!");
        }
    }


    [Command("gorunmezlik", "inv")]
    public void invisible(Player Client)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 2)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız! /aduty komutuyla görev moduna geçebilirsiniz.");
            return;
        }
        if (Client.Transparency == 255)
        {
            Client.Transparency = 0;
            Client.SetSharedData("isadmininvicible", true);
            Main.SendSuccessMessage(Client, "Başarıyla görünmezlik modunu aktif ettiniz!");
        }
        else if (Client.Transparency == 0)
        {
            Client.SetSharedData("isadmininvicible", false);
            Client.Transparency = 255;
            Main.SendSuccessMessage(Client, "Başarıyla görünmezlik modunu de-aktf ettiniz!");
        }
    }


    //
    [Command("atamir")]
    public void fixVeh(Player Client)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız! /aduty komutuyla görev moduna geçebilirsiniz.");
            return;
        }
        if (Client.IsInVehicle)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " /fixcar komutunu kullandı. Tamir edilen araç: " + Client.Vehicle.NumberPlate.ToString());

            Client.Vehicle.Repair();
        }
    }


    [RemoteEvent("saveFreemodePosition")]
    public static void saveFreemodePosition(Player Client, string x, string y, string z, string rx, string ry, string rz)
    {
        Main.SendCustomChatMessasge(Client, "saveFreemodePosition:~y~ Konum: ~c~" + x + ", " + y + ", " + z + " ~y~Dönüş:~c~ " + rx + ", " + ry + ", " + rz + ".");
    }

    //startFreemode


    [Command("ban", "~y~[!]~w~: /ban [ID/İsim] [Sebep] [Bitiş Tarihi (Gün.Ay.Yıl) - 0: Sınırsız]", Alias = "yasakla", GreedyArg = true)]
    public void CMD_ban(Player Client, string idOrName, string reason, string datum)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız! /aduty komutuyla görev moduna geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
                return;
            }

            MySqlConnection connect = new MySqlConnection(Main.myConnectionString);

            string tarih;
            if (datum == "0")
            {
                tarih = "01.01.2090";
            }
            else
            {
                tarih = datum;
            }

            Main.CreateMySqlCommand("UPDATE `users` SET `isban` = '1' ,banreason='" + reason + "', passq='" + datum + "',bannedby='" + AccountManage.GetCharacterName(Client) + "' WHERE socialclubname='" + target.SocialClubName + "';");
            Main.SendCustomChatToAll("~r~ADM: " + AccountManage.GetCharacterName(target) + " adlı oyuncu, " + adminCommands.GetPlayerAdminRank(Client) + " " + adminCommands.GetAdminName(Client) + " tarafından sunucudan yasaklandı!");

            GameLog.ELog(Client, GameLog.MyEnum.Admin, " /ban komutunu kullandı. Yasaklanan Kişi:" + AccountManage.GetCharacterName(target) + ", Sebep: " + reason.ToString());
            target.Kick();
        }
        else InteractMenu_New.SendNotificationError(Client, "Oyuncu sunucuda değil!");

    }

    [Command("unban", "~y~[!]~w~: /unban [Social Club]")]
    public void CMD_unban(Player Client, string socialclub)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 5)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız! /aduty komutuyla görev moduna geçebilirsiniz.");
            return;
        }
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " /unban komutunu kullandı. Yasağı açılan kişi: " + socialclub);
        Main.CreateMySqlCommand("UPDATE `users` SET `isban` = '0' ,banreason='',bannedby='' WHERE socialclubname='" + socialclub + "';");
        Main.SendCustomChatMessasge(Client, "" + socialclub + " social clubun yasağı kaldırıldı.");
    }


    [Command("ahelp", Alias = "ah", GreedyArg = true)]
    public void CMD_Apomoziboze(Player client)
    {
        int adminLevel = AccountManage.GetPlayerAdmin(client);

        if (client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }

        string commands = "";

        for (int i = 1; i <= adminLevel; i++)
        {
            switch (i)
            {
                case 1:
                    commands += "~c~[GM] /apm - /ah - /getpdim - /zamankontrol\n";
                    break;
                case 2:
                    commands += "~c~[A1] /a - /aduty - /fly - /gorunmezlik - /id\n";
                    break;
                case 3:
                    commands += "~c~[A2] /ajail - /kick - /spec - /arevive - /hastahanedencikar - /goto - /veh - /deleteveh\n";
                    break;
                case 4:
                    commands += "~c~[A3] /dondur - /gotopos - /aunjail - /getcar - /auyari - /atamir - /ban - /setdim\n";
                    break;
                case 5:
                    commands += "~c~[A4] /unjail - /setfuel - /unban - /gethere - /sethp - /setodecu - /rboombox - /boombox\n";
                    break;
                case 6:
                    commands += "~c~[A5] /aehliyetver - /gno - /aplaka - /getpos - /aooc - /setxp - /abirliktenat - /aranmatemizle - /setskill\n";
                    commands += "~c~[A5] /etkinlikolustur - /etkinlikbaslat - /etkinlikbitir - /aesyaver - /asilahsifirla - /setarmor - /setweather\n";
                    break;
                case 7:
                    commands += "~c~[D] /acloth - /carliv - /asifreduzenle - /setadmin - /herkesever - /setleader\n";
                    commands += "~c~[D] /setfaction - /givemoney - /deletedveh - /setvip - /asilahver - /aisyeriver - /aisyeriparasifirla\n";
                    commands += "~c~[D] /hoodolustur - /hoodduzenle - /nexthood - /acikarttirmabaslat - /chcoinduzenle - /chcoinver - /cctvolustur - /gemisavasi\n";
                    break;
                case 8:
                    commands += "~c~[CM] /2xpayday - /poskaydet - /getvhash - /vhp - /adminsifrekontrol - /settime\n";
                    commands += "~c~[CM] /garajolustur - /garajsil - /evgarajolustur - /evolustur - /evduzenle - /evfiyatduzenle\n";
                    break;
                case 9:
                    commands += "~c~[!] /kickall - /saveall\n";
                    break;
                default:
                    Main.SendErrorMessage(client, "Bu komut için yetkiniz yok /ahelp kullanarak komutları görüntüleyebilirsiniz!");
                    return;
            }
            Main.SendCustomChatMessasge(client, commands);
        }
    }

    [Command("admin", "~y~[!]~w~: /a(dmin) [Mesaj]", Alias = "a", GreedyArg = true)]
    public void CMD_admin(Player Client, string poruka)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) == 0)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        var players = NAPI.Pools.GetAllPlayers();

        foreach (Player c in players)
        {
            if (c.GetData<dynamic>("status") == true)
            {
                if (AccountManage.GetPlayerAdmin(c) > 0)
                {
                    Main.SendCustomChatMessasge(c, "<font color='#e30202'>[aChat] " + GetPlayerAdminRank(Client) + " - " + AccountManage.GetCharacterName(Client) + ":~w~ " + poruka + "");
                }
            }
        }
    }


    [Command("aooc", "~y~[!]~w~: /aooc [Mesaj]", GreedyArg = true)]
    public void CMD_cv(Player Client, string poruka)
    {
        if (AccountManage.GetPlayerAdmin(Client) <= 6)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 3)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }

        Main.SendMessageWithTagToAll("<font color='#00afe3'>(( [Oyun Dışı] (" + GetPlayerAdminRank(Client) + ")", "" + " <font color='#00afe3'>" + AccountManage.GetCharacterName(Client) + ": <font color='#00afe3'>" + poruka);

    }

    [Command("revive", "~y~[!]~w~: /revive [ID/İsim]", Alias = "arevive")]
    public void CMD_reviver(Player sender, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(sender) < 3)
        {
            Main.SendErrorMessage(sender, "Yetkiniz yok!");
            return;
        }
        if (sender.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(sender) <= 7)
        {
            Main.SendErrorMessage(sender, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(sender, idOrName);
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(sender, "Oyuncu sunucuda değil!");
                return;
            }
            if (target.GetSharedData<dynamic>("Injured") != 1)
            {
                Main.SendErrorMessage(sender, "Oyuncu yaralı değil!");
                return;
            }
            GameLog.ELog(sender, GameLog.MyEnum.Admin, " /revive komutunu " + AccountManage.GetCharacterName(target) + " oyuncusunda kullandı.");

            target.SetSharedData("Injured", 0);
            NAPI.Player.SetPlayerHealth(target, 40);
            target.TriggerEvent("update_health", target.Health, target.Armor);
            target.TriggerEvent("InjuredSystem:Destroy");
            target.TriggerEvent("freeze", false);
            target.TriggerEvent("freezeEx", false);
            NAPI.Player.StopPlayerAnimation(target);
            if (sender != target) Main.SendCustomChatMessasge(sender, AccountManage.GetCharacterName(target) + " adlı kişiyi canlandırdınız.");
            Main.SendServerMessage(target, "" + AccountManage.GetCharacterName(sender) + " adlı yetkili tarafından canlandırıldınız.");
            target.TriggerEvent("update_health", target.Health, target.Armor);
        }
        else Main.SendErrorMessage(sender, "Oyuncu yaralı değil.");
    }

    [Command("goto", "~y~[!]~w~: /goto [ID/İsim]")]
    public void CMD_ir(Player Client, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 3)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
                return;
            }

            Main.SendServerMessage(Client, AccountManage.GetCharacterName(target) + " adlı kişinin yanına ışınlandınız.");

            NAPI.Entity.SetEntityPosition(Client, target.Position - new Vector3(0, 1, 0.5));
        }
        else InteractMenu_New.SendNotificationError(Client, "Oyuncu sunucuda değil!");
    }

    [Command("gethere", "~y~[!]~w~: /gethere [ID/İsim]")]
    public void CMD_trazer(Player Client, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
                return;
            }
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " /gethere komutunu kullandı, oyuncu: " + AccountManage.GetCharacterName(target));

            Main.SendServerMessage(Client, AccountManage.GetCharacterName(target) + " adlı kişiyi yanınınıza çektiniz.");
            Main.SendServerMessage(target, AccountManage.GetCharacterName(Client) + " adlı yetkili sizi yanına çekti.");


            if (target.IsInVehicle && target.VehicleSeat == (int)VehicleSeat.Driver)
            {
                Vehicle vehicle = target.Vehicle;
                vehicle.Position = Client.Position.Around(4);
                target.Dimension = Client.Dimension;
                vehicle.Dimension = Client.Dimension;
                target.SetIntoVehicle(vehicle, (int)VehicleSeat.Driver);
                Main.DisplayRadar(Client, true);
            }
            else
            {
                NAPI.Entity.SetEntityPosition(target, Client.Position.Around(4));
                target.Dimension = Client.Dimension;
            }
        }
        else InteractMenu_New.SendNotificationError(Client, "Oyuncu sunucuda değil!");
    }

    [Command("setxp", "~y~[!]~w~: /setxp [ID/İsim] [EXP]")]
    public void CMD_darexperiencia(Player Client, string idOrName, int quantidade)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
                return;
            }
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " /setxp komutunu kullandı, oyuncu: " + AccountManage.GetCharacterName(target) + " xp: " + quantidade);

            if (Client != target) Main.SendServerMessage(Client, AccountManage.GetCharacterName(target) + " adlı oyuncuya " + quantidade + " miktar EXP verdiniz.");
            Main.SendServerMessage(target, AccountManage.GetCharacterName(Client) + " adlı yetkili, size " + quantidade + " miktar EXP verdi.");
            Main.GivePlayerEXP(target, quantidade);
        }
    }

    [Command("kickall", "~y~[!]~w~: /kickall [Sebep]")]
    public void CMD_KickAll(Player Client, string reason)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 9)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        foreach (var item in NAPI.Pools.GetAllPlayers())
        {
            Main.SendErrorMessage(item, reason + " sebebiyle sunucudan atıldınız.");
            item.Kick();
        }
    }


    public static void UpdateRefferals()
    {
        string name;
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        for (int i = 0; i < 100; i++)
        {
            name = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            Main.CreateMySqlCommand("UPDATE `users` SET `refferal`='" + name + "' WHERE `refferal`='0' LIMIT 1");
        }
    }

    public static string updatereferal()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
    }



    [Command("saveall")]
    public void CMD_saveaccounts(Player Client)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 9)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var i in players)
        {
            if (i.GetData<dynamic>("status") == true)
            {
                Main.SavePlayerInformation(i);
                WeaponManage.SaveWeapons(i);
                int playerid = Main.getIdFromClient(Client);
                if (Client.GetData<dynamic>("status") == true && Client.Exists)
                {
                    for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                    {
                        if (PlayerVehicle.vehicle_data[playerid].model[index] != "")
                        {
                            if (PlayerVehicle.vehicle_data[playerid].handle[index] != null && PlayerVehicle.vehicle_data[playerid].handle[index].Exists)
                            {
                                PlayerVehicle.vehicle_data[playerid].position[index] = PlayerVehicle.vehicle_data[playerid].handle[index].Position;
                                PlayerVehicle.vehicle_data[playerid].rotation[index] = PlayerVehicle.vehicle_data[playerid].handle[index].Rotation.Z;
                            }
                            if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index] != null && PlayerVehicle.vehicle_data[playerid].handle[index].Exists)
                            {
                                PlayerVehicle.SavePlayerVehicle(Client, index);
                            }
                        }
                    }
                }
            }
        }
        Main.SendSuccessMessage(Client, "Tüm hesaplar kaydedildi!");
    }



    [Command("setleader", "~y~[!]~w~: /setleader [ID/İsim] [Birlik ID]")]
    public void CMD_darlider(Player Client, string idOrName, int factionid)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
                return;
            }

            if (factionid < 0 || factionid > 255)
            {
                Main.SendErrorMessage(Client, "Birlik ID'si 0 ile 255 arasında olmalı!");
            }
            else if (FactionManage.faction_data[factionid].faction_type == 0)
            {
                Main.SendErrorMessage(Client, "Bu birlik düzenlenmemiş!");
            }
            else
            {
                GameLog.ELog(Client, GameLog.MyEnum.Admin, " /setleader komutunu kullandı, oyuncu: " + AccountManage.GetCharacterName(target) + " organizasyon: " + factionid);

                target.SetData<dynamic>("duty", 0);
                Outfits.RemovePlayerDutyOutfit(target);
                AccountManage.SetPlayerLeader(target, 1);
                AccountManage.SetPlayerGroup(target, factionid);
                AccountManage.SetPlayerRank(target, FactionManage.GetMaxRank(factionid));
                target.TriggerEvent("factionchange", factionid);
                FactionManage.faction_data[factionid].faction_leader = AccountManage.GetPlayerSQLID(target);

                if (Client != target)
                {
                    Main.SendServerMessage(Client, AccountManage.GetCharacterName(target) + " adlı oyuncuyu " + FactionManage.faction_data[factionid].faction_name + " adlı birliğin lideri olarak atadınız.");
                    Main.SendInfoMessage(target, "" + AccountManage.GetCharacterName(Client) + " adlı yetkili sizi " + FactionManage.faction_data[factionid].faction_name + " adlı birliğin lideri olarak atadı.");
                }
                else Main.SendInfoMessage(target, "" + AccountManage.GetCharacterName(Client) + " adlı yetkili sizi " + FactionManage.faction_data[factionid].faction_name + " adlı birliğin lideri olarak atadı.");

                Main.SavePlayerInformation(target);
                FactionManage.SaveFaction(factionid);

                faction_blip.RemoveBlip(target);
            }
        }
    }


    [Command("setfaction", "~y~[!]~w~: /setfaction [ID/İsim] [Birlik ID]")]
    public void CMD_setfaccao(Player Client, string idOrName, int factionid)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
                return;
            }
            if (factionid < 0 || factionid > 255)
            {
                Main.SendErrorMessage(Client, "Birlik ID'si 0 ile 255 arasında olmalı!");
            }
            else if (FactionManage.faction_data[factionid].faction_type == 0)
            {
                Main.SendErrorMessage(Client, "Bu birlik düzenlenmemiş!");
            }
            else
            {
                GameLog.ELog(Client, GameLog.MyEnum.Admin, " /setfaction komutunu kullandı, oyuncu: " + AccountManage.GetCharacterName(target) + " organizasyon: " + factionid);
                target.SetData<dynamic>("duty", 0);
                Outfits.RemovePlayerDutyOutfit(target);
                AccountManage.SetPlayerGroup(target, factionid);
                AccountManage.SetPlayerRank(target, FactionManage.GetMaxRank(factionid));
                Main.SavePlayerInformation(target);
                if (Client != target) Main.SendServerMessage(Client, AccountManage.GetCharacterName(target) + " adlı oyuncuyu " + FactionManage.faction_data[factionid].faction_name + " birliğine dahil ettiniz.");
                else Main.SendInfoMessage(target, "" + AccountManage.GetCharacterName(Client) + " adlı yetkili sizi ~b~" + FactionManage.faction_data[factionid].faction_name + "~w~ birliğine dahil etti.");
                faction_blip.RemoveBlip(target);
            }
        }
    }

    [Command("abirliktenat", "~y~[!]~w~: /abirliktenat [ID/İsim]")]
    public void CMD_tirargrupo(Player Client, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
                return;
            }

            GameLog.ELog(Client, GameLog.MyEnum.Admin, " /abirliktenat komutunu kullandı, oyuncu: " + AccountManage.GetCharacterName(target));

            NAPI.Data.SetEntityData(target, "duty", 0);
            Main.UpdatePlayerClothes(target);
            target.SetData<dynamic>("duty", 0);
            Outfits.RemovePlayerDutyOutfit(target);
            AccountManage.SetPlayerLeader(target, 0);
            AccountManage.SetPlayerGroup(target, 0);
            AccountManage.SetPlayerRank(target, 0);
            Main.SavePlayerInformation(target);
            if (Client != target) Main.SendServerMessage(Client, AccountManage.GetCharacterName(target) + " adlı oyuncuyu birliğinden attınız.");
            else Main.SendServerMessage(target, "" + AccountManage.GetCharacterName(Client) + " adlı yetkili sizi birliğinizden attı!");
            faction_blip.RemoveBlip(target);
        }
    }



    [Command("givemoney", "~y~[!]~w~: /givemoney [ID/İsim] [Para]")]
    public void command_giveplayermoney(Player Client, string idOrName, int value)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
                return;
            }
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " /givemoney komutunu kullandı, oyuncu: " + AccountManage.GetCharacterName(target) + " para miktarı: " + value);

            if (Client != target) Main.SendServerMessage(Client, AccountManage.GetCharacterName(target) + " adlı oyuncuya " + value.ToString("N0") + " miktar para verdiniz.");
            else Main.SendInfoMessage(target, AccountManage.GetCharacterName(Client) + " adlı yetkili size $" + value.ToString("N0") + " miktar para verdi.");

            Main.GivePlayerMoney(target, value);
            Main.SavePlayerInformation(target);
        }
    }

    [Command("veh", "~y~[!]~w~: /veh [Model] [Renk1] [Renk2]", Alias = "car")]
    public void CMD_veh(Player player, string vehName, int color = 0, int color2 = 0)
    {
        if (AccountManage.GetPlayerAdmin(player) < 3)
        {
            Main.SendErrorMessage(player, "Yetkiniz yok!");
            return;
        }
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }

        VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
        if (vehHash != 0)
        {
            var vehicle = NAPI.Vehicle.CreateVehicle(vehHash, player.Position, player.Rotation.Z, 0, 0);
            vehicle.Dimension = player.Dimension;
            vehicle.NumberPlate = "ADMIN-ARACI";
            Main.SetVehicleFuel(vehicle, 99.0);
            NAPI.Vehicle.SetVehicleEngineStatus(vehicle, true);
            player.SetIntoVehicle(vehicle, 0);
            vehicle.PrimaryColor = color;
            vehicle.SecondaryColor = color2;
        }
        else
        {
            Main.SendErrorMessage(player, $"Böyle bir araç bulunmamaktadır: ~h~" + vehName);
            return;
        }
    }



    [Command("dveh", Alias = "deleteveh")]
    public void CMD_delveh(Player sender)
    {
        if (sender.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(sender, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(sender) < 3)
        {
            Main.SendErrorMessage(sender, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        if (sender.IsInVehicle)
        {
            Vehicle veh = sender.Vehicle;
            if (!veh.Exists) return;
            if (veh.NumberPlate == "ADMIN-ARACI")
            {
                veh.Delete();
                Main.SendSuccessMessage(sender, "Başarıyla admin aracını sildiniz.");
            }
            else
            {
                Main.SendErrorMessage(sender, "Bu araç admin aracı değil.");
                return;
            }
        }
    }


    [Command("deletedveh")]
    public void CMD_ddelveh(Player sender)
    {
        if (sender.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(sender, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(sender) < 7)
        {
            Main.SendErrorMessage(sender, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        if (sender.IsInVehicle)
        {
            Vehicle veh = sender.Vehicle;
            veh.Delete();
        }
    }

    [Command("aranmatemizle", "~y~[!]~w~: /aranmatemizle [ID/İsim]")]
    public void CMD_aocistiwl(Player p, string idOrName)
    {
        if (p.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(p, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(p) < 6)
        {
            Main.SendErrorMessage(p, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        Player target = Main.findPlayer(p, idOrName);
        int wanted = target.GetSharedData<dynamic>("character_wanted_level");
        Police.SetPlayerCrime(target, -wanted);
        Main.SendSuccessMessage(p, AccountManage.GetCharacterName(target) + " adlı oyuncunun aranma seviyesini temizlediniz.");
        GameLog.ELog(p, GameLog.MyEnum.Admin, " " + AccountManage.GetCharacterName(target) + " adlı oyuncun, " + wanted + " seviye olan aranmasını temizledi.");
    }

    [Command("setvip", "~y~[!]~w~: /setvip [ID/İsim] [Seviye] [Gün]")]
    public static void CMD_setvip(Player sender, string idOrName, int level, int dana)
    {
        if (sender.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(sender, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(sender) < 7)
        {
            Main.SendErrorMessage(sender, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        Player target = Main.findPlayer(sender, idOrName);
        if (target != null)
        {
            NAPI.Data.SetEntityData(target, "character_vip", level);

            DateTime characterVipExpire = Convert.ToDateTime(target.GetData<dynamic>("character_vip_expire"));

            if (characterVipExpire > DateTime.Now)
            {
                target.SetData<dynamic>("character_vip_expire", characterVipExpire.AddDays(dana));
            }
            else
            {
                target.SetData<dynamic>("character_vip_date", DateTime.Now);
                target.SetData<dynamic>("character_vip_expire", DateTime.Now.AddDays(dana));
            }
            Main.SavePlayerInformation(target);
            Main.SendSuccessMessage(sender, AccountManage.GetCharacterName(target) + " adlı oyuncuya " + dana + " günlük VIP verdiniz.");
            Main.SendSuccessMessage(target, AccountManage.GetCharacterName(sender) + " adlı yetkili, size " + dana + " günlük VIP verdi.");
            GameLog.ELog(sender, GameLog.MyEnum.Admin, "" + AccountManage.GetCharacterName(target) + " adlı oyuncuya " + dana + " günlük VIP verdi.");
        }
    }

    public static void CMD_setvipref(Player sender, int level, int dana)
    {
        if (sender != null)
        {
            NAPI.Data.SetEntityData(sender, "character_vip", level);

            DateTime characterVipExpire = Convert.ToDateTime(sender.GetData<dynamic>("character_vip_expire"));

            if (characterVipExpire > DateTime.Now)
            {
                sender.SetData<dynamic>("character_vip_expire", characterVipExpire.AddDays(dana));
            }
            else
            {
                sender.SetData<dynamic>("character_vip_date", DateTime.Now); 
                sender.SetData<dynamic>("character_vip_expire", DateTime.Now.AddDays(dana));
            }
            Main.SavePlayerInformation(sender);
        }
    }

    [Command("setweather", "~y~[!]~w~: /setweather [ID]")]
    public void command_mudarclima(Player Client, int weather)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 5)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        if (weather < 0 || weather >= 14)
        {
            Main.SendErrorMessage(Client, "Geçersiz hava durumu ID'si!");
            return;
        }
        else
        {
            NAPI.World.SetWeather(Enum.GetName(typeof(Weather), weather));
            Main.SendSuccessMessage(Client, "Başarıyla hava durumu ayarlandı. Yeni hava durumu: " + weather + "~w~.");
        }
    }

    [Command("settime", "~y~[!]~w~: /settime [Saat] [Dakika]")]
    public void settime(Player Client, byte h, byte m)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 8)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 5)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        NAPI.World.SetTime(Main.Server_Hours, Main.Server_Minutes, 0);
        Main.Server_Hours = h;
        Main.Server_Minutes = m;
        Main.SendSuccessMessage(Client, "Başarıyla saat ayarlandı. Yeni saat/dakika: " + h + " - " + m);
    }

    [Command("sethp", "~y~[!]~w~: /sethp [ID/İsim] [Can]", Alias = "canayarla")]
    public void command_vida(Player Client, string idOrName, int value)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 5)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " /sethp komutuyla " + AccountManage.GetCharacterName(target) + " oyuncusunun sağlık değerini " + value + " olarak ayarladı.");

            NAPI.Player.SetPlayerHealth(target, value);
            target.TriggerEvent("update_health", target.Health, target.Armor);
            Main.SendSuccessMessage(Client, AccountManage.GetCharacterName(target) + " adlı oyuncunun canı " + value + " olarak ayarlandı.");
            Main.SendSuccessMessage(target, AccountManage.GetCharacterName(Client) + " adlı yetkili, canınızı " + value + " olarak ayarladı.");
        }
    }

    [Command("setarmor", "~y~[!]~w~: /setarmor [ID/İsim] [Zırh]", Alias = "zirhayarla")]
    public void command_colete(Player Client, string idOrName, int value)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " /setarmour komutuyla " + AccountManage.GetCharacterName(target) + " oyuncusunun zırh değerini " + value + " olarak ayarladı.");
            NAPI.Player.SetPlayerArmor(target, value);
            Main.SendSuccessMessage(Client, AccountManage.GetCharacterName(target) + " adlı oyuncunun zırhı " + value + " olarak ayarlandı.");
            Main.SendSuccessMessage(target, AccountManage.GetCharacterName(Client) + " adlı yetkili, zırhınızı " + value + " olarak ayarladı.");
        }
    }

    [Command("asilahver", "~y~[!]~w~: /asilahver [ID/İsim] [Silah] [Mermi]", Alias = "giveweapon")]
    public void CMD_dararma(Player Client, string idOrName, string name, int ammo)
    {
        if (AccountManage.GetPlayerAdmin(Client) <= 7)
        {
            Main.SendErrorMessage(Client, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            var index = 0;
            int weapon_id = -1;
            foreach (var gun in Main.weapon_list)
            {
                if (gun.model.Contains(name) == true)
                {
                    weapon_id = index;
                    break;
                }
                index++;
            }

            if (weapon_id == -1)
            {
                Main.SendErrorMessage(Client, "Bu silah mevcut değil.");
                return;
            }



            WeaponHash hashcode = NAPI.Util.WeaponNameToModel(Main.weapon_list[weapon_id].model);
            WeaponManage.SetPlayerWeaponEx(target, name, ammo);
            if (Main.weapon_list[weapon_id].classe == "Melee")
            {
                Main.SendServerMessage(Client, AccountManage.GetCharacterName(target) + " adlı oyuncuya " + hashcode + " ID'li silahı verdiniz.");
            }
            else
            {
                Main.SendServerMessage(Client, AccountManage.GetCharacterName(target) + " adlı kişiye " + hashcode + " ID'li silahı (" + (long)hashcode + " - " + weapon_id + ") ve " + ammo + " mermi verdiniz.");
            }

        }
    }

    [Command("resetweapons", "~y~[!]~w~: /resetweapons [ID/İsim]", Alias = "asilahsifirla")]
    public void resetweapons(Player Client, string ID)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        Player target = Main.findPlayer(Client, ID);
        if (target != null)
        {
            WeaponHash hashcode = NAPI.Player.GetPlayerCurrentWeapon(target);
            NAPI.Player.RemovePlayerWeapon(target, hashcode);
        }
    }

    [Command("zamankontrol")]
    public static void checkstimeCMD(Player client)
    {
        if (client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(client) < 1)
        {
            Main.SendErrorMessage(client, "Yetkiniz yok!");
            return;
        }
        DateTime serverTime = DateTime.Now;
        Main.SendServerMessage(client, $"Şu anda sunucuda yerel saat: {serverTime}");
    }

   
    [Command("herkesever", "~y~[!]~w~: /herkesever [Para/EXP] [Miktar]")]
    public void CMD_svima(Player Client, string sta, int miktar)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız, /aduty komutunu kullanarak göreve geçebilirsiniz.");
            return;
        }
        if (miktar < 1 || miktar > 30000)
        {
            Main.SendErrorMessage(Client, "Miktar minimum 1, maksimum 30000 olabilir.");
            return;
        }
        if (sta != "Para" && sta != "EXP")
        {
            Main.SendErrorMessage(Client, "Sadece 'EXP' veya 'Para' verebilirsiniz.");
            return;
        }
        if (sta == "EXP")
        {
            if(miktar < 250)
            {
                Main.SendErrorMessage(Client, "Maksimum 250 EXP verebilirsiniz.");
                return;
            }
            foreach (var player in NAPI.Pools.GetAllPlayers())
            {
                Main.GivePlayerEXP(player, miktar);
            }
            Main.SendCustomChatToAll($"~r~ADM: ~w~" + AccountManage.GetCharacterName(Client) + $", adlı yetkili herkese '{miktar}' miktar bonus EXP verdi.");
        }
        else if (sta == "Para")
        {
            foreach (var player in NAPI.Pools.GetAllPlayers())
            {
                Main.GivePlayerMoney(player, miktar);
            }
            Main.SendCustomChatToAll($"~r~ADM: ~w~" + AccountManage.GetCharacterName(Client) + $", adlı yetkili herkese '{miktar}' miktar bonus Para verdi.");
        }
    }

    [Command("setdim", "~y~[!]~w~: /setdim [ID/İsim] [Dimension)]")]
    public void CMD_setdimensao(Player Client, string idOrName, uint dimension)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 6)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız, /aduty komutunu kullanarak göreve geçebilirsiniz.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
                return;
            }
            GameLog.ELog(Client, GameLog.MyEnum.Admin, ", " + AccountManage.GetCharacterName(target) + "adlı oyuncunun dimensionunu ayarladı.");

            Main.SendServerMessage(Client, AccountManage.GetCharacterName(target) + " adlı oyuncunun dimensionu " + dimension + " olarak ayarlandı.");
            target.Dimension = dimension;
        }
        else InteractMenu_New.SendNotificationError(Client, "Oyuncu sunucuda değil!");
    }

    [Command("getpdim")]
    public void CMD_debug(Player Client, string idOrName)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için görevde olmalısınız, /aduty komutunu kullanarak göreve geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 1)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        uint igrac = NAPI.Entity.GetEntityDimension(Client);
        Main.SendServerMessage(Client, "Oyuncunun dimensionu: " + igrac + ".");
    }



    public enum MessageType
    {
        Admin

    }

    public static string GetAdminName(Player client)
    {
        return AccountManage.GetCharacterName(client);
    }

    public static void MessageWithTag(Player Client, MessageType type, string message)
    {
        string Text = "~r~Bir hata oluştu, lütfen sunucu sahibiyle iletişime geçin!";
        switch (type)
        {
            case MessageType.Admin:
                Text = "~r~[Admin CMD] " + message;
                break;
            default:
                break;
        }
        Main.SendCustomChatMessasge(Client, Text);
    }

    [Command("gotomeslek", "~y~[!]~w~: /gotomeslek [Meslek ID]")]
    public void CMD_gotomeslek(Player Client, int jobID)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 1)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }

        Vector3 jobPosition;
        string jobName;

        switch (jobID)
        {
            case 1:
                jobName = "Pizzacılık";
                jobPosition = new Vector3(130.70288, -1463.0945, 29.357023);
                break;
            case 2:
                jobName = "Madencilik";
                jobPosition = new Vector3(-595.07477, 2093.1235, 131.49953);
                break;
            case 3:
                jobName = "Otobüs Şoförlüğü";
                jobPosition = new Vector3(452.81778, -620.55023, 28.562202);
                break;
            case 4:
                jobName = "Pentester";
                jobPosition = new Vector3(-1083.1687, -248.06578, 37.763233);
                break;
            case 5:
                jobName = "Tavukçuluk";
                jobPosition = new Vector3(-68.77934, 6253.611, 31.090158);
                break;
            default:
                Main.SendErrorMessage(Client, "Geçersiz meslek ID'si!");
                return;
        }

        Main.SendSuccessMessage(Client, "" + jobName + " adlı mesleğe ışınlandınız.");
        NAPI.Entity.SetEntityPosition(Client, jobPosition);
    }

    [RemoteEvent("SaveWaypointPosition")]
    public void SaveWaypointPosition(Player client, float x, float y, float z)
    {
        Vector3 waypointPosition = new Vector3(x, y, z);
        client.SetData("waypoint_position", waypointPosition);
    }

    [RemoteEvent("ClearWaypointPosition")]
    public void ClearWaypointPosition(Player client)
    {
        if (client.HasData("waypoint_position"))
        {
            client.ResetData("waypoint_position");
        }
    }

    [Command("gotow", "~y~[!]~w~: /gotow")]
    public void CMD_gotow(Player Client)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 3)
        {
            Main.SendErrorMessage(Client, "Yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }

        Vector3 waypoint = Client.GetData<Vector3>("waypoint_position");

        if (waypoint != null && waypoint != new Vector3(0, 0, 0))
        {
            if (Client.IsInVehicle)
            {
                Vehicle vehicle = Client.Vehicle;
                Main.SendSuccessMessage(Client, "Haritada işaretlediğiniz yere ışınlandınız.");
                NAPI.Entity.SetEntityPosition(Client, waypoint);
                NAPI.Entity.SetEntityPosition(vehicle, waypoint);
            }
            else
            {
                Main.SendSuccessMessage(Client, "Haritada işaretlediğiniz yere ışınlandınız.");
                NAPI.Entity.SetEntityPosition(Client, waypoint);
            }
        }
        else
        {
            Main.SendErrorMessage(Client, "Haritada bir yer işaretlemediğiniz için ışınlanma işlemi yapılamadı!");
        }
    }



    [Command("goto1")]
    public void TeleportToPosition(Player player)
    {
        NAPI.Entity.SetEntityPosition(player, new Vector3(3485.99, 2568.018, 13.2927));
    }

    [Command("goto2")]
    public void TeleportToPositionx(Player player)
    {
        NAPI.Entity.SetEntityPosition(player, new Vector3(1272.18, -1712.11, 55.27));
    }

    [Command("goto3")]
    public void TeleportToPositionz(Player player)
    {
        NAPI.Entity.SetEntityPosition(player, new Vector3(-107.56066, -2706.5156, 6.507262));
    }

    [Command("goto4")]
    public void TeleportToPositiony(Player player)
    {
        NAPI.Entity.SetEntityPosition(player, new Vector3(1891.7834, 5006.52, 47.956657));
    }

}

