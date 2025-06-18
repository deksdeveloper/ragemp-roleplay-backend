using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

class policeCommands : Script
{

    [Command("isbasi")]
    public void ToggleBadge(Player player)
    {
        if (!Main.IsInRangeOfPoint(player.Position, new Vector3(469.00632, -988.65173, 25.729673), 2.0f))
        {
            Main.SendErrorMessage(player, "İşbaşı noktasına yakın değilsin.");
            return;
        }
        if (AccountManage.GetPlayerGroup(player) != 1)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        Police.ChangeBadgeStatus(player);
        if (player.GetSharedData<dynamic>("badgeon"))
        {
            NAPI.Notification.SendNotificationToPlayer(player, Translation.notification_11);
            player.SetData<dynamic>("duty", 1);
            Main.SendErrorMessage(player, "Başarıyla işbaşına geçtin.");
        }
        else
        {
            NAPI.Notification.SendNotificationToPlayer(player, Translation.notification_12);
            Outfits.RemovePlayerDutyOutfit(player);
            Main.UpdatePlayerClothes(player);
            NAPI.Player.SetPlayerArmor(player, 0);
            Main.SendErrorMessage(player, "Başarıyla işbaşından çıktın.");
        }
    }

    [Command("ipkullan")]
    public void rapple(Player Client)
    {
        if (!Client.IsInVehicle)
        {
            return;
        }
        if (Client.Vehicle.DisplayName.ToLower() != "polmav")
        {
            return;
        }
        if (AccountManage.GetPlayerGroup(Client) != 1)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (NAPI.Player.GetPlayerVehicleSeat(Client) == (int)VehicleSeat.RightRear || NAPI.Player.GetPlayerVehicleSeat(Client) == (int)VehicleSeat.LeftRear)
        {
            foreach (var item in NAPI.Player.GetPlayersInRadiusOfPlayer(500, Client))
            {
                item.TriggerEvent("rappel", Client);
            }
            Main.SendCustomChatMessasge(Client, "İp yardımıyla helikopterden inmeye başlıyorsunuz.");
            Main.EmoteMessage(Client, "ip yardımıyla helikopterden inmeye başlar.");
        }
    }

    [Command("lokasyonbul", "~y~[!]~w~: /lokasyonbul [ID/İsim]")]
    public void find_phone(Player client, string idOrname)
    {
        if (client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (AccountManage.GetPlayerGroup(client) != 1)
        {
            Main.SendErrorMessage(client, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (client.HasData("lc_Timeout") && client.GetData<dynamic>("lc_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
        {
            Main.SendErrorMessage(client, "Bu komutu her 30 saniyede bir kullanabilirsiniz]");
            return;
        }
        client.SetData<dynamic>("lc_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 30000);
        Player target = Main.findPlayer(client, idOrname);
        if (target != null)
        {
            Random random = new Random();

            float xOffset = (float)random.Next(-250, 251);
            float yOffset = (float)random.Next(-250, 251);
            float zOffset = (float)random.Next(-250, 251);
            Vector3 position = target.Position + new Vector3(xOffset, yOffset, zOffset);
            Main.SendSuccessMessage(client, "Radarda +-250 metre çapında tespit edildi.");
            Trigger.ClientEvent(client, "createWLBlip", position);
            NAPI.Task.Run(() =>
            {
                if (!NAPI.Player.IsPlayerConnected(client)) return;
                Trigger.ClientEvent(client, "deleteWLBlip");
            }, delayTime: 30000);
        }
        else
        {
            Main.SendErrorMessage(client, "Oyuncu çevrimdışı!");
            return;
        }
    }


    [RemoteEvent("locateplayer")]
    public void find_phone2(Player client, string idOrname)
    {
        if (client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (AccountManage.GetPlayerGroup(client) != 1)
        {
            Main.SendErrorMessage(client, "Bu işlemi yapabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (client.HasData("lc_Timeout") && client.GetData<dynamic>("lc_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
        {
            Main.SendErrorMessage(client, "Bu komutu her 30 saniyede bir kullanabilirsiniz]");
            return;
        }
        client.SetData<dynamic>("lc_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 30000);
        Player target = Main.findPlayer(client, idOrname);
        if (target != null)
        {
            Random random = new Random();

            float xOffset = (float)random.Next(-250, 251);
            float yOffset = (float)random.Next(-250, 251);
            float zOffset = (float)random.Next(-250, 251);
            Vector3 position = target.Position + new Vector3(xOffset, yOffset, zOffset);
            Main.SendSuccessMessage(client, "Radarda +-250 metre çapında tespit edildi.");
            Trigger.ClientEvent(client, "createWLBlip", position);
            NAPI.Task.Run(() =>
            {
                if (!NAPI.Player.IsPlayerConnected(client)) return;
                Trigger.ClientEvent(client, "deleteWLBlip");
            }, delayTime: 30000);
        }
        else
        {
            Main.SendErrorMessage(client, "Oyuncu çevrimdışı!");
            return;
        }

    }

    [Command("destekiste", Alias = "acildurum")]
    public void command_destekkiste(Player Client)
    {
        if (FactionManage.GetPlayerGroupID(Client) != 1) { Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın."); return; }
        if (Client.GetData<dynamic>("duty") == 0) { Main.SendErrorMessage(Client, "İşbaşında değilsiniz."); return; }
        if (Client.GetData<dynamic>("playerCuffed") == 1) { Main.SendErrorMessage(Client, "Şu anda bu işlemi yapamazsınız."); return; }
        if (Client.GetData<dynamic>("PD_Panic") == 0)
        {
            Client.SetData<dynamic>("PD_Panic", 1);
            Main.SendSuccessMessage(Client, "Destek istediniz, desteği kapatmak için tekrardan /destekiste komutunu kullanabilirsiniz.");
            Main.EmoteMessage(Client, "telsizin acil durum butonuna basar ve destek ister.");
            foreach (Player pl in NAPI.Pools.GetAllPlayers())
            {
                if (FactionManage.GetPlayerGroupID(pl) == FactionManage.FACTION_TYPE_POLICE && pl.GetData<dynamic>("duty") == 1 && Client != pl)
                {
                    Main.SendCustomChatMessasge(pl, "[~r~PANİK ALARMI~w~] <font color='#E86153'> Panik alarmı çaldı!");
                }
            }
        }
        else
        {
            Client.SetData<dynamic>("PD_Panic", 0);
            Main.SendSuccessMessage(Client, "Destek isteğini kapattınız.");
        }
    }



    [Command("dep", "~y~[!]~w~: /dep(artment) [Mesaj]", Alias = "d, department", GreedyArg = true)]
    public void CMD_departamento(Player Client, string poruka)
    {

        if (AccountManage.GetPlayerGroup(Client) == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (AccountManage.GetPlayerRank(Client) == -1)
        {
            InteractMenu_New.SendNotificationError(Client, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE && FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_MEDIC)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        int faction = AccountManage.GetPlayerGroup(Client);
        int rank = AccountManage.GetPlayerRank(Client);

        var players = NAPI.Pools.GetAllPlayers();
        
        if (faction == 1)
        {
            Client.SetData<string>("f1", "LSPD");
        }
        if (faction == 2)
        {
            Client.SetData<string>("f1", "LSMD");
        }
        foreach (Player c in players)
        {
            if (c.GetData<dynamic>("status") == true)
            {
                if (FactionManage.GetPlayerGroupID(c) == FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupID(c) == FactionManage.FACTION_TYPE_MEDIC)
                {
                    Main.SendCustomChatMessasge(c, "<font color='#FF6347'> **"+ Client.GetData<string>("f1") +" "+ UsefullyRP.GetPlayerNameToTarget(Client, c) + " : " + poruka + " **");
                }
            }
        }

    }

    [Command("m", "~y~[!]~w~: /m(egafon) [Mesaj]", Alias = "megafon", GreedyArg = true)]
    public void CMD_megafone(Player Client, string poruka)
    {
        if (AccountManage.GetPlayerGroup(Client) == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (Client.GetData<dynamic>("duty") == 0)
        {
            InteractMenu_New.SendNotificationError(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız.");
            return;
        }

        int faction = AccountManage.GetPlayerGroup(Client);
        int rank = AccountManage.GetPlayerRank(Client);

        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(45, Client);
        foreach (Player target in proxPlayers)
        {
           target.TriggerEvent("Send_ToChat", "", " <font color='#fbff00'>" + UsefullyRP.GetPlayerNameToTarget(Client, target) + " <font color='#fbff00'>(Megafon): <font color='#fbff00'>" + poruka.ToUpper());
        }

    }
    [Command("hapiseat", "~y~[!]~w~: /hapiseat [ID/İsim]")]
    public void CMD_prender(Player Client, string idOrname)
    {
        if (AccountManage.GetPlayerGroup(Client) == 0)
        {
            InteractMenu_New.SendNotificationError(Client, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        if (AccountManage.GetPlayerRank(Client) == -1)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(458.63, -985.65, 34.20), 3.0f) || Main.IsInRangeOfPoint(Client.Position, new Vector3(458.34, -1008.04, 28.27), 3.0f))
        {
            Player target = Main.findPlayer(Client, idOrname);
            if (target != null)
            {
                if (Main.IsInRangeOfPoint(target.Position, Client.Position, 3) && Client != target)
                {
                    int wl = target.GetSharedData<dynamic>("character_wanted_level");
                    if (target.GetData<dynamic>("BeingDragged") == true)
                    {
                        InteractMenu_New.SendNotificationError(Client, "Sürüklenen bir oyuncuyu hapise atamazsın.");
                        return;
                    }

                    int minutes = 0;
                    if (wl == 0)
                    {
                        Client.SendNotification("Aranma seviyesi olmayan bir oyuncuyu hapise atamazsın.");
                        return;
                    }
                    else if (wl > 0)
                    {
                        minutes = wl * 5 * 60;
                    }

                    int tkazna = wl * 2000; 
                    int preward = wl * 1000; 
                    Main.GivePlayerMoney(target, tkazna); 
                    Main.GivePlayerMoney(Client, preward);

                    NAPI.Notification.SendNotificationToPlayer(target, "~w~" + AccountManage.GetCharacterName(Client) + " adlı devlet memuru, sizi " + minutes + "~w~ saniye hapis cezasına çarptırdı.");
                    NAPI.Notification.SendNotificationToPlayer(Client, "" + AccountManage.GetCharacterName(target) + " adl oyuncuyu " + minutes + "~w~ saniye hapis cezasına çarptırdınız.");

                    Client.TriggerEvent("createNewHeadNotificationAdvanced", "" + AccountManage.GetCharacterName(target) + "~w~'yi " + minutes + "~w~ saniye hapis cezasına çarptırdınız.");

                    int count = 0;
                    foreach (var teste in Main.prison_spawns)
                    {
                        count++;
                    }
                    Random rnd = new Random();
                    int index = rnd.Next(0, count);

                    NAPI.Entity.SetEntityPosition(target, Main.prison_spawns[index].position);
                    target.Rotation = Main.prison_spawns[index].rotation;

                    NAPI.Player.SetPlayerClothes(target, 1, 0, 0);
                    NAPI.Player.SetPlayerClothes(target, 5, 0, 0);
                    NAPI.Player.SetPlayerClothes(target, 1, 0, 0);
                    NAPI.Player.SetPlayerClothes(target, 7, 0, 0);
                    NAPI.Player.SetPlayerClothes(target, 9, 0, 0);
                    NAPI.Player.SetPlayerClothes(target, 10, 0, 0);

                    NAPI.Player.ClearPlayerAccessory(target, 0);
                    NAPI.Player.ClearPlayerAccessory(target, 1);
                    NAPI.Player.ClearPlayerAccessory(target, 2);
                    NAPI.Player.ClearPlayerAccessory(target, 6);
                    NAPI.Player.ClearPlayerAccessory(target, 7);

                    NAPI.Player.SetPlayerClothes(target, 4, 3, 7);
                    NAPI.Player.SetPlayerClothes(target, 11, 5, 0);
                    NAPI.Player.SetPlayerClothes(target, 3, 5, 0);
                    NAPI.Player.SetPlayerClothes(target, 8, 0, 18);
                    NAPI.Player.SetPlayerClothes(target, 6, 8, 0);

                    target.SetData<dynamic>("character_prison", 1);
                    target.SetData<dynamic>("character_prison_cell", index);
                    target.SetData<dynamic>("character_prison_time", minutes);
                    target.SetSharedData("character_wanted_level", 0);

                    target.SetData<dynamic>("playerCuffed", 0);
                    target.StopAnimation();

                    target.TriggerEvent("freezeEx", false);
                    target.TriggerEvent("setFollow", false, Client);

                    if (Client.GetData<int>("oyuncuAramada") != TelefonSistem.ARAMA_BOS)
                    {
                        TelefonSistem.CagriRed(Client);
                    }
                    return;
                }
            }
            else
            {
                Main.DisplayErrorMessage(Client, "info", "Hapise atma noktasında değilsiniz.");
            }
        }
        InteractMenu_New.SendNotificationError(Client, "Hapise atmak istediğiniz oyuncuya yakın değilsiniz.");
    }


    [Command("aranmaseviyesiekle", "~y~[!]~w~: /aranmaseviyesiekle [ID/İsim] [Miktar]")]
    public void CMD_mandato(Player p, string idOrName, int Zvezdica)
    {
        Player target = Main.findPlayer(p, idOrName);
        if (Zvezdica < 1)
        {
            Main.SendErrorMessage(p, "Geçerli bir aranma seviyesi girmediniz. (1-10)");
            return;
        }
        if (Zvezdica > 10)
        {
            Main.SendErrorMessage(p, "Geçerli bir aranma seviyesi girmediniz. (1-10)");
            return;
        }
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.SendErrorMessage(p, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(p, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        Police.SetPlayerCrime(target, Zvezdica);
        NAPI.Notification.SendNotificationToPlayer(p, "" + AccountManage.GetCharacterName(target) + "adlı oyuncuya başarıyla aranma seviyesi eklediniz.");
    }

    [Command("aranmaseviyesitemizle", "~y~[!]~w~: /aranmaseviyesitemizle [ID/İsim]")]
    public void CMD_ocistiwl(Player p, string idOrName)
    {
        if (AccountManage.GetPlayerLeader(p) < 1 && FactionManage.GetPlayerGroupID(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(p, "Bu işlemi gerçekleştirebilmek için yeterli yetkiniz yok.");
            return;
        }
        Player target = Main.findPlayer(p, idOrName);
        int wanted = target.GetSharedData<dynamic>("character_wanted_level");
        Police.SetPlayerCrime(target, -wanted);
        NAPI.Notification.SendNotificationToPlayer(p, "" + AccountManage.GetCharacterName(target) + "adlı oyuncunun aranma seviyesini temizlediniz.");
    }

    [Command("ustara", "~y~[!]~w~: /ustara [ID/İsim]")]
    public void CMD_revistar(Player p, string idOrName)
    {
        Main.SendErrorMessage(p, "Üst aramasını, şüphelinin elleri havadayken 'I' tuşu ile yapabilirsiniz.");
        return;
    }

    [Command("frisktrunk")]
    public void CMD_revistarveiculo(Player p)
    {
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.SendErrorMessage(p, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(p, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }

        Vehicle vehicle = Utils.GetClosestVehicle(p, 5.0f);

        if (NAPI.Entity.DoesEntityExist(vehicle))
        {
            if (NAPI.Data.HasEntityData(vehicle, "MAX_VEHICLE_SLOT"))
            {
                if (NAPI.Data.GetEntityData(vehicle, "MAX_VEHICLE_SLOT") > 0)
                {
                    Main.SendCustomChatMessasge(p, "~w~-----------------------------");
                    Main.SendCustomChatMessasge(p, "~g~Bagaj");
                    List<dynamic> menu_item_list = new List<dynamic>();
                    for (int i = 0; i < 30; i++)
                    {
                        if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0)
                        {
                            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
                            {
                                Main.SendCustomChatMessasge(p, "(Eşya) ~c~" + Inventory.itens_available[NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type")].name + " ~w~(" + NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") + ")");
                            }
                        }
                    }
                    Main.SendCustomChatMessasge(p, "~w~-----------------------------");
                    return;
                }
            }
        }
        Main.SendErrorMessage(p, "* Bunu yapamazsınız!");
    }



    [Command("elkoyesya", "~y~[!]~w~: /elkoyesya [ID/İsim] [Eşya]")]
    public void CMD_confiscaritem(Player p, string idOrName, string itemName)
    {

        Player target = Main.findPlayer(p, idOrName);
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.SendErrorMessage(p, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(p, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }

        if (target == null)
        {
            Main.SendErrorMessage(p, "Geçersiz oyuncu!");
            return;
        }

        int playerid = Main.getIdFromClient(target);

        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
        {
            if (Inventory.player_inventory[playerid].type[index] != 0 && Inventory.player_inventory[playerid].type[index] < Inventory.itens_available.Count)
            {
                if (Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name == itemName)
                {
                    if (Inventory.player_inventory[playerid].amount[index] > 0)
                    {

                        Main.SendSuccessMessage(p, "" + Inventory.player_inventory[playerid].amount[index] + " " + Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name + " eşyasını " + AccountManage.GetCharacterName(target) + "'nın üstünden aldınız.");
                        Main.SendSuccessMessage(target, " " + AccountManage.GetCharacterName(p) + ", üzerinizden " + Inventory.player_inventory[playerid].amount[index] + " " + Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name + " eşyasını aldı.");
                        Inventory.RemoveItem(target, itemName, Inventory.player_inventory[playerid].amount[index]);
                        return;
                    }
                }

            }
        }
        Main.DisplayErrorMessage(p, "error", "Geçersiz eşya adı girdiniz.");
    }

    [Command("elkoysilah", "~y~[!]~w~: /elkoysilah [ID/İsim]")]
    public void CMD_confiscararmas(Player p, string idOrName)
    {
        Player target = Main.findPlayer(p, idOrName);
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.SendErrorMessage(p, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(p, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }

        if (target == null)
        {
            Main.SendErrorMessage(p, "Geçersiz oyuncu!");
            return;
        }

        WeaponManage.RemoveAllWeaponEx(target);

        Main.SendSuccessMessage(p, "" + AccountManage.GetCharacterName(target) + " adlı oyuncunun tüm silahlarına el koydunuz.");
        Main.SendSuccessMessage(target, "" + AccountManage.GetCharacterName(p) + " tüm silahlarınıza el koydu.");
    }

    /*[Command("ticket", "Koriscenje: /ticket [id/DeoImena] [Cena] [Razlog]", GreedyArg = true )]
    public void CMD_fine(Player Client, string idOrName, int kazna, string razlog)
    {

        Player target = Main.findPlayer(Client, idOrName);
        if (AccountManage.GetPlayerGroup(Client) == 0)
        {
            InteractMenu_New.SendNotificationError(Client, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        if (AccountManage.GetPlayerRank(Client) == -1)
        {
            InteractMenu_New.SendNotificationError(Client, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE)
        {
            InteractMenu_New.SendNotificationError(Client, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }

        if (target == null)
        {
            InteractMenu_New.SendNotificationError(Client, "Pogresan ID.");
            return;
        }
        if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 3.0f))
        {
            InteractMenu_New.SendNotificationError(Client, "Morate biti pored igraca!");
            return;
        }
        if (kazna < 1 || kazna > 20000)
        {
            InteractMenu_New.SendNotificationError(Client, "Iznos ne moze biti manji od 1 ili veci od $20.000.");
            return;
        }

        Main.SendCustomChatMessasge(Client, " ~w~ Dali ste kaznu u iznosu od $$" + kazna.ToString("N0") + " igracu ~w~ " + UsefullyRP.GetPlayerNameToTarget(target,Client) + ".");
        Main.SendInfoMessage(target, "" + FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_rank[AccountManage.GetPlayerRank(Client)] + " " + UsefullyRP.GetPlayerNameToTarget(Client, target) + " vam je napisao kaznu u iznosu od ~g~$" + kazna.ToString("N0") + "~w~ Razlog: " + razlog + " .");
        Main.GivePlayerMoney(target, -kazna);


    }*/




    [Command("cezakes", "~y~[!]~w~: /cezakes [Plaka] [Miktar]")]
    public void CMD_finevehicle(Player Client, string placa, int preco)
    {
        if (AccountManage.GetPlayerGroup(Client) == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (AccountManage.GetPlayerGroup(Client) == -1)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }

        if (preco < 1 || preco > 20000)
        {
            InteractMenu_New.SendNotificationError(Client, "Kesilecek cezanın miktarı minimum 1$, maksimum 20.000$ olabilir.");
            return;
        }

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `vehicles` WHERE `vehicle_plate` = '" + placa + "' or `vehicle_plate` = '" + placa.Replace(" ", "-") + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                //var index = 0;
                while (reader.Read())
                {
                    string vehicle_plate = reader.GetString("vehicle_plate");
                    if (vehicle_plate == placa)
                    {
                        var players = NAPI.Pools.GetAllPlayers();
                        foreach (var pl in players)
                        {
                            if (pl.GetData<dynamic>("status") == true)
                            {
                                if (NAPI.Data.GetEntityData(pl, "character_sqlid") == reader.GetInt32("vehicle_owner_id"))
                                {
                                    for (int index = 0; 0 < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                                    {
                                        if (placa == Convert.ToString(PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].plate[index]))
                                        {
                                            Main.SendCustomChatMessasge(pl, "Ceza kesildi. ~c~(" + PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].model[index] + ")~w~ Plaka: ~y~" + Convert.ToString(PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].plate[index]) + "~w~ Tutar: ~g~$" + preco.ToString("N0") + "~w~ Sahip: " + AccountManage.GetCharacterName(Client) + "~w~.");

                                            if (VIP.GetPlayerVIP(pl) == 1)
                                            {
                                                int new_preco = preco - (int)(0.25 * preco);
                                                preco = new_preco;
                                                Main.SendMessageWithTagToPlayer(pl, "" + Main.EMBED_VIP + "[VIP]", "VIP olduğunuz için cezanız %20 daha az olacak! Ödeyeceğiniz tutar: $" + new_preco + " - VIP olmasaydınız ödeyeceğiniz tutar:: " + preco + "");
                                            }



                                            PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].ticket[index] = preco;
                                            PlayerVehicle.SavePlayerVehicle(pl, index);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Mainpipeline.Close();
        }
        InteractMenu_New.SendNotificationError(Client, "Girdiğiniz plakaya sahip araç bulunamadı.");
    }

    [Command("aranmalistesi")]
    public void ListaTrazenih(Player player)
    {
        List<dynamic> data = new List<dynamic>();

        foreach(Player suspect in NAPI.Pools.GetAllPlayers())
        {
            if (suspect.GetSharedData<dynamic>("character_wanted_level") > 7)
            {
                if(API.Shared.IsPlayerConnected(suspect) && suspect.GetData<dynamic>("status") == true)
                {
                    data.Add(new { Suspect = AccountManage.GetCharacterName(suspect), Wanted = suspect.GetSharedData<dynamic>("character_wanted_level") });
                }
            }
            
        }
        player.TriggerEvent("Display_Wanted_List", NAPI.Util.ToJson(data));
    }

    /*[Command("wl")]
    public void cmdwantedlista(Player handle)
    {
        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni!");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        handle.SendChatMessage("***WANTED***");
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandText = ("SELECT name, wanted FROM `characters` WHERE wanted > 6 AND loggedin = 1");
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    string suspect = reader.GetString("name");
                    int wanted = reader.GetInt32("wanted");
                    handle.SendChatMessage(" " + suspect +" "+ wanted +" ⭐ ");
                }
            }
        } 
        handle.SendChatMessage("***WANTED***");
    }*/

    [Command("aranmasorgula", "~y~[!]~w~: /aranmasorgula [ID/İsim]")]
    public void cmdpwantedlista(Player handle, Player target)
    {
        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            Main.SendErrorMessage(handle, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            Main.SendErrorMessage(handle, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(handle, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        handle.SendChatMessage(""+ AccountManage.GetCharacterName(target) +" adlı oyuncunun aranma seviyesi: " + target.GetSharedData<dynamic>("character_wanted_level"));
    }


    [Command("kelepce", "~y~[!]~w~: /kelepcele [ID/İsim]", Alias = "kelepcele")]
    public void CMD_algemar(Player handle, string idOrName)
    {

        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            Main.SendErrorMessage(handle, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            Main.SendErrorMessage(handle, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(handle, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        if (handle.GetSharedData<dynamic>("Injured") == 1)
        {
            Main.SendErrorMessage(handle, "Yaralıyken bu komutu kullanamazsın!");
            return;
        }
        Player target = Main.findPlayer(handle, idOrName);
        if (target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {

                if (target.GetData<dynamic>("playerCuffed") == 1)
                {
                    Main.SendErrorMessage(handle, "Oyuncu zaten kelepçelenmiş.");
                    return;
                }

                if (target.IsInVehicle)
                {
                    Main.SendErrorMessage(handle, "Aracın içerisindeki bulunan birisini kelepçeleyemezsin.");
                    return;
                }

                target.SetData<dynamic>("handsup", false);
                Main.SendInfoMessage(handle, "~b~" + AccountManage.GetCharacterName(target) + "~w~ adlı oyuncu başarıyla kelepçelendi.");
                Main.SendInfoMessage(target, "~b~" + AccountManage.GetCharacterName(handle) + "~w~ adlı polis sizi kelepçeledi.");

                target.SetData<dynamic>("playerCuffed", 1);
                target.StopAnimation();
                Inventory.oruzijeinuse(target);
                if (target.GetData<int>("oyuncuAramada") != TelefonSistem.ARAMA_BOS)
                {
                    TelefonSistem.CagriRed(target);
                }
                Police.CuffPlayer(target);
                return;
            }
        }
        Main.SendErrorMessage(handle, "Kelepçelemek istediğiniz oyuncuya yakın değilsiniz.");
    }

    [Command("kelepcecikar", "~y~[!]~w~: /kelepcecikar [ID/İsim]")]
    public void CMD_desalgemar(Player handle, string idOrName)
    {
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(handle, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        Player target = Main.findPlayer(handle, idOrName);
        if (target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {

                if (target.GetData<dynamic>("playerCuffed") == 1)
                {
                    Police.UnCuffPlayer(target);
                }
                return;
            }
        }
        Main.SendErrorMessage(handle, "Kelepçesini çıkartmak istediğiniz oyuncuya yakın değilsiniz.");
    }

    [Command("aracabindir", "~y~[!]~w~: /aracabindir [ID] [Koltuk ID (1-2)]")]
    public void CMD_deter(Player handle, string idOrName, int assento)
    {
        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            Main.SendErrorMessage(handle, "Bu komutu kullanabilmek için LSPD veya LSMD birliğine mensup olmalısın.");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            Main.SendErrorMessage(handle, "Bu komutu kullanabilmek için LSPD veya LSMD birliğine mensup olmalısın.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_MEDIC)
        {
            Main.SendErrorMessage(handle, "Bu komutu kullanabilmek için LSPD veya LSMD birliğine mensup olmalısın.");
            return;
        }

        if (handle.IsInVehicle)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "Araçtayken bu komutu kullanamazsın.");
            return;
        }

        Player target = Main.findPlayer(handle, idOrName);
        if (target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {
                if (assento != 1 && assento != 2)
                {
                    Main.SendErrorMessage(handle, "Geçersiz koltuk ID.");
                    return;
                }

                if (target.GetData<dynamic>("playerCuffed") == 0)
                {
                    Main.SendErrorMessage(handle, "Araca bindirmek istediğiniz oyuncu kelepçeli değil.");
                    return;
                }

                if (target.IsInVehicle)
                {
                    Main.SendErrorMessage(handle, "Bu oyuncu zaten araçta.");
                    return;
                }

                NetHandle vehicle = Utils.GetClosestVehicle(target, 5.0f);

                if (!NAPI.Entity.DoesEntityExist(vehicle))
                {
                    Main.SendErrorMessage(handle, "Yakınınızda araç bulunmamakta.");
                    return;
                }

                var p = NAPI.Pools.GetAllPlayers();
                foreach (var i in p)
                {
                    if (i.GetData<dynamic>("status") == true && NAPI.Player.IsPlayerInAnyVehicle(i) && NAPI.Player.GetPlayerVehicleSeat(i) == assento)
                    {
                        Main.SendErrorMessage(handle, "Bindirmek istediğiniz koltuk zaten dolu.");
                        return;
                    }
                }

                Main.SendSuccessMessage(handle, "~b~" + AccountManage.GetCharacterName(target) + "~w~ adlı oyuncuyu araca bindirdiniz.");
                NAPI.Player.SetPlayerIntoVehicle(target, vehicle, assento);
                NAPI.Player.PlayPlayerAnimation(target, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "sit");

                target.TriggerEvent("freezeEx", true);
                return;
            }
        }

        Main.SendErrorMessage(handle, "Araca bindirmek istediğiniz oyuncuya yakın değilsiniz.");
    }

    [Command("maskecikart", "~y~[!]~w~: /maskecikart [ID/İsim]")]
    public void CMD_tirarmascara(Player handle, string idOrName)
    {
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(handle, "Bu komutu kullanabilmek için LSPD birliğine mensup olmalısın.");
            return;
        }
        Player target = Main.findPlayer(handle, idOrName);
        if (target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {
                if (target.GetData<dynamic>("playerCuffed") == 0)
                {
                    Main.SendErrorMessage(handle, "Maskesini çıkartmak istediğiniz oyuncu kelepçeli değil.");
                    return;
                }

                if (!handle.GetSharedData<dynamic>("using_mask"))
                {
                    Main.SendErrorMessage(handle, "Bu oyuncu zaten maske takmıyor.");
                    return;
                }

                Main.SendSuccessMessage(handle, "~b~" + AccountManage.GetCharacterName(target) + "~y~ adlı oyuncunun maskesini çıkarttınız.");
                Main.SendInfoMessage(target, "~b~" + AccountManage.GetCharacterName(handle) + "~y~ adlı polis, maskenizi çıkarttı.");

                UsefullyRP.RemoveMaskFromPlayer(target);
                return;
            }
        }
        Main.SendErrorMessage(handle, "Maskesini çıkartmak istediğiniz oyuncuya yakın değilsiniz.");
    }

    [Command("surukle", "~y~[!]~w~: /surukle [ID/İsim]")]
    public static void CMD_arrastar(Player handle, string idOrName)
    {
        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            Main.SendErrorMessage(handle, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            Main.SendErrorMessage(handle, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_MEDIC)
        {
            Main.SendErrorMessage(handle, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }

        Player target = Main.findPlayer(handle, idOrName);
        if (target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {
                if (target.GetData<dynamic>("BeingDragged") == false)
                {
                    if (target.GetData<dynamic>("playerCuffed") == 0)
                    {
                        Main.SendErrorMessage(handle, "Sürüklemek istediğiniz oyuncu kelepçeli değil.");
                        return;
                    }

                    if (target.IsInVehicle)
                    {
                        NAPI.Player.WarpPlayerOutOfVehicle(target);
                    }

                    NAPI.Player.PlayPlayerAnimation(target, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.AllowPlayerControl | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "idle");

                    target.TriggerEvent("setFollow", true, handle);
                    target.TriggerEvent("freezeEx", true);
                    target.SetData<dynamic>("BeingDragged", true);

                    target.SetSharedData("DisableExitVehicle", false);
                    Main.SendSuccessMessage(handle, "" + AccountManage.GetCharacterName(target) + " adlı oyuncuyu sürüklemeye başladınız.");
                }
                else
                {
                    Main.SendSuccessMessage(handle, "" + AccountManage.GetCharacterName(target) + " adlı oyuncuyu sürüklemeyi bıraktınız.");
                    target.TriggerEvent("setFollow", false, handle);
                    target.SetData<dynamic>("BeingDragged", false);
                    target.TriggerEvent("freezeEx", true);
                }
                return;
            }
        }
        Main.SendErrorMessage(handle, "Bunu yapamazsınız.");
    }

    [RemoteEvent("buygunlic")]
    public void BuyGunLicense(Player player)
    {
        if (AccountManage.GetPlayerConnected(player))
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(441.28094, -981.8585, 30.6896), 3))
            {
                if (Main.GetPlayerMoney(player) < 20000)
                {
                    Main.SendErrorMessage(player, "Yeterli miktarda paranız yok.");
                    return;
                }
                if (player.GetData<dynamic>("character_gun_lic") > 0)
                {
                    Main.SendErrorMessage(player, "Zaten silah ruhsatınız var.");
                    return;
                }
                Main.SendSuccessMessage(player, "Başarıyla silah ruhsatı satın aldınız.");
                player.SetData<dynamic>("character_gun_lic", 720);
                Main.GivePlayerMoney(player, -20000);
                Main.SavePlayerInformation(player);
            }
        }
    }


}

