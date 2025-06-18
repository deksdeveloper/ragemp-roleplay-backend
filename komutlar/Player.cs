using GTANetworkAPI;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Qiwi.BillPayments.Model;
using System.Reflection.Emit;
using GTANetworkAPI;
class playerCommands : Script
{
    [Flags]
    public enum AnimationFlags
    {
        Loop = 1 << 0,
        StopOnLastFrame = 1 << 1,
        OnlyAnimateUpperBody = 1 << 4,
        AllowPlayerControl = 1 << 5,
        Cancellable = 1 << 7
    }



    [Command("lisansgoster", "~y~[!]~w~: /lisansgoster [ID/İsim]", Alias = "lisanslar")]
    public static void ShowLicenses(Player player, string nameorid = "")
    {
        if (nameorid == "")
        {
            nameorid = player.Value.ToString();
        }
        Player target = Main.findPlayer(player, nameorid);
        if (target != null)
        {
            if (player.Position.DistanceTo(target.Position) >= 5f)
            {
                Main.DisplayErrorMessage(player, "error", "Lisans göstermek istediğiniz kişiye yakın değilsiniz!");
                return;
            }

            Main.SendCustomChatMessasge(target, "~y~--------------~g~[" + AccountManage.GetCharacterName(player) + "~y~ Lisansları]-----------------");
            if (player.GetData<dynamic>("character_car_lic") > 0)
            {
                Main.SendCustomChatMessasge(target, "~b~Sürücü Lisansı: ~g~Var | Son kullanım tarihi: " + player.GetData<dynamic>("character_car_lic") + "");
            }
            else
            {
                Main.SendCustomChatMessasge(target, "~b~Sürücü Lisansı: ~r~Yok");
            }

            if (player.GetData<dynamic>("character_moto_lic") > 0)
            {
                Main.SendCustomChatMessasge(target, "~b~Motosiklet Lisansı: ~g~Var | Son kullanım tarihi: " + player.GetData<dynamic>("character_moto_lic") + "");
            }
            else
            {
                Main.SendCustomChatMessasge(target, "~b~Motosiklet Lisansı: ~r~Yok");
            }

            if (player.GetData<dynamic>("character_fly_lic") > 0)
            {
                Main.SendCustomChatMessasge(target, "~b~Uçuş Lisansı: ~g~Var | Son kullanım tarihi: " + player.GetData<dynamic>("character_fly_lic") + "");
            }
            else
            {
                Main.SendCustomChatMessasge(target, "~b~Uçuş Lisansı: ~r~Yok");
            }

            if (player.GetData<dynamic>("character_gun_lic") > 0)
            {
                Main.SendCustomChatMessasge(target, "~b~Silah Lisansı: ~g~Var | Son kullanım tarihi: " + player.GetData<dynamic>("character_gun_lic") + "");
            }
            else
            {
                Main.SendCustomChatMessasge(target, "~b~Silah Lisansı: ~r~Yok");
            }
        }
    }

    public static void privdance(Player player)
    {
        NAPI.Player.PlayPlayerAnimation(player, 1, "anim@mp_player_intcelebrationfemale@raining_cash", "raining_cash");
        NAPI.Particle.CreateLoopedParticleEffectOnEntity("ent_brk_banknotes", "ent_brk_banknotes", player, new Vector3(0.0, 0.0, 1.0), new Vector3(0.0, 0.0, 0.0), 1, 60309, 0);
        player.TriggerEvent("privatedances");
        BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_cash_pile_01"), 60309, new Vector3(0.0, 0.0, 0), new Vector3(0, 0, 0));
        Main.GivePlayerMoney(player, -80);
        player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~- ~y~$80");

        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(player))
            {
                NAPI.Player.StopPlayerAnimation(player);
                BasicSync.DetachObject(player);
            }
        }, delayTime: 4500);

    }


    [Command("kimlikgoster", "~y~[!]~w~: /kimlikgoster [ID/İsim]")]
    public void showpassport(Player player, string nameorid)
    {
        Player Target = Main.findPlayer(player, nameorid);

        if (Target.Exists)
        {
            if (player.Position.DistanceTo(Target.Position) >= 5f)
            {
                Main.DisplayErrorMessage(player, "error", "Kimlik göstermek istediğiniz kişiye yakın değilsiniz!");
                return;
            }
            InteractMenu_New.pSelected(player, Target, "showpas");
        }
        else
        {
            Main.DisplayErrorMessage(player, "error", "Kimlik göstermek istediğiniz kişi oyunda değil!");
        }
        return;
    }

    [Command("aracmenu")]
    public void carcontrolcmd(Player player)
    {
        player.TriggerEvent("Display_cartool");
    }

    [Command("radio2")]
    public void ToggleRadio(Player Client)
    {
        if (Inventory.GetPlayerItemFromInventory(Client, 23) < 1)
        {
            Main.SendErrorMessage(Client, "Üzerinizde 'Radyo' yok.");
            return;
        }
        Client.TriggerEvent("Toggle_Radio");
    }

    [RemoteEvent("setfreq")]
    public void Remote_Setfreq(Player Client, int freq)
    {
        if (Client.HasSharedData("Radio_Status") && Client.GetData<dynamic>("Radio_Status") != false)
        {
            command_Radio(Client, (ushort)freq);
        }
        else
        {
            Main.DisplayErrorMessage(Client, "error", "Radyo bağlantınız kapalı.");
            return;
        }
    }

    [Command("frekans", "~y~[!]~w~: /frekans [Frekans]")]
    public void command_Radio(Player Client, ushort freq)
    {
        if (freq <= 1 || freq >= 65535)
        {
            Main.SendErrorMessage(Client, "Radyo frekansı 1 ile 65535 arasında olmalıdır.");
            return;
        }
        //int index = Inventory.GetInventoryIndexFromName(Client, "Radio");
        if (Inventory.GetPlayerItemFromInventory(Client, 23) < 1)
        {
            Main.SendErrorMessage(Client, "Üzerinizde 'Radyo' yok.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE && freq >= 911 && freq <= 915)
        {
            InteractMenu_New.SendNotificationError(Client, "Bu frekans korumalı.");
            return;
        }

        if (Client.HasSharedData("Radio_Status"))
        {
            if (Client.GetSharedData<dynamic>("Radio_Status") == true)
            {
                if (Client.GetData<dynamic>("status") == true)
                {
                    // Client.SetSharedData("RadioFreq", freq);
                    Radio.RadioSystem.Radio_Call(Client, freq);
                    Main.SendSuccessMessage(Client, "Başarıyla yeni bir frekansa bağlandınız! Yeni frekans: " + freq + "");
                }
            }
        }
    }


    [Command("karakter")]
    public void PlayerStatsEvent(Player client)
    {
        int level = client.GetData<dynamic>("character_level");
        int exp = client.GetData<dynamic>("character_exp");
        int rpvpoints = client.GetData<dynamic>("character_credits");
        int skill = client.GetData<dynamic>("jobskill");
        string referral = client.GetData<dynamic>("refferal");
        int carlic = client.GetData<dynamic>("character_car_lic");
        int motolic = client.GetData<dynamic>("character_moto_lic");
        int gunlic = client.GetData<dynamic>("character_gun_lic");
        string organisation = FactionManage.faction_data[AccountManage.GetPlayerGroup(client)].faction_name;
        string orgrank = FactionManage.faction_data[AccountManage.GetPlayerGroup(client)].faction_rank[AccountManage.GetPlayerRank(client)];
        string adminrank = adminCommands.GetPlayerAdminRank(client);
        int age = client.GetData<dynamic>("character_age");

        string vip = "Yok";
        if (VIP.GetPlayerVIP(client) >= 1) vip = "Var";

        if (organisation == "Staff") organisation = "Yok";
        if (orgrank == "nema") orgrank = "Yok";

        string aehliyet = "Yok";
        if (carlic >= 1) aehliyet = "Yok";

        string mehliyet = "Yok";
        if (motolic >= 1) mehliyet = "Yok";

        string gehliyet = "Yok";
        if (gunlic >= 1) gehliyet = "Var";

        string numara = "Yok";
        if (client.HasData("character_cellphone"))
        {
            numara = client.GetData<int>("character_cellphone").ToString();
        }

        int bank = NAPI.Data.GetEntityData(client, "character_bank");
        int money = NAPI.Data.GetEntityData(client, "character_money");

        Main.SendCustomChatMessasge(client, $"<font color='#66ED00'>//----------------------- {AccountManage.GetCharacterName(client)} ({client.Handle}) -----------------------//");
        Main.SendCustomChatMessasge(client, $"<font color='#CCE6E6'>[HESAP]<font color='#FFFFFF'> SQLID: <font color='#C2A2DA'>{client.GetData<dynamic>("character_sqlid")} <font color='#FFFFFF'>- Seviye: <font color='#C2A2DA'>{level} <font color='#FFFFFF'>- Deneyim Puanı: <font color='#C2A2DA'>{exp}");
        Main.SendCustomChatMessasge(client, $"<font color='#CCE6E6'>[HESAP]<font color='#FFFFFF'> Yönetici Seviyesi: <font color='#C2A2DA'>{adminrank} <font color='#FFFFFF'>- V.I.P: <font color='#C2A2DA'>{vip} <font color='#FFFFFF'>- OOC Bakiye: <font color='#C2A2DA'>{rpvpoints}");
        Main.SendCustomChatMessasge(client, $"<font color='#CCE6E6'>[KARAKTER]<font color='#FFFFFF'> Yaş: <font color='#C2A2DA'>{age} <font color='#FFFFFF'>- Birlik: <font color='#C2A2DA'>{organisation} <font color='#FFFFFF'>- Rütbe: <font color='#C2A2DA'>{orgrank}");
        Main.SendCustomChatMessasge(client, $"<font color='#CCE6E6'>[KARAKTER]<font color='#FFFFFF'> Araç Ehliyeti: <font color='#C2A2DA'>{aehliyet} <font color='#FFFFFF'>- Motor Ehliyeti: <font color='#C2A2DA'>{mehliyet} <font color='#FFFFFF'>- Silah Lisansı: <font color='#C2A2DA'>{gehliyet}");
        Main.SendCustomChatMessasge(client, $"<font color='#CCE6E6'>[KARAKTER]<font color='#FFFFFF'> Telefon: <font color='#C2A2DA'>{numara} <font color='#FFFFFF'>- Cüzdan: <font color='#C2A2DA'>{money} <font color='#FFFFFF'>- Banka: <font color='#C2A2DA'>{bank}");
    }

    [Command("r", "~y~[!]~w~: /r(adio) [Mesaj]", GreedyArg = true, Alias = "radio")]
    public void ChatRadio(Player Client, string chat)
    {
        if (Inventory.GetPlayerItemFromInventory(Client, 23) <= 0)
        {
            Main.SendErrorMessage(Client, "Üzerinizde 'Radyo' yok.");
            return;
        }
        if (Client.HasSharedData("Radio_Status") == false || Client.GetSharedData<dynamic>("Radio_Status") == false)
        {
            Main.SendErrorMessage(Client, "Radyo cihazınız kapalı!");
            return;
        }
        if (Client.HasSharedData("RadioFreq") && Client.GetSharedData<dynamic>("RadioFreq") == 0)
        {
            Main.SendErrorMessage(Client, "Frekansınız henüz ayarlanmamış, /frekans ile ayarlayabilirsiniz.");
            return;
        }

        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (Client.GetSharedData<dynamic>("RadioFreq") == target.GetSharedData<dynamic>("RadioFreq") && target.GetSharedData<dynamic>("Radio_Status") == true)
            {
                Main.SendCustomChatMessasge(target, "~y~[RADYO] " + UsefullyRP.GetPlayerNameToTarget(Client, target) + " : ~y~" + chat);
            }

            if (Client.Position.DistanceTo(target.Position) < 15f && Client.Handle != target.Handle)
            {
                // NAPI.ClientEvent.TriggerClientEvent(Client, "Send_ToServer", "[Radio] Mige: " + chat);
                Main.SendCustomChatMessasge(target, UsefullyRP.GetPlayerNameToTarget(Client, target) + " ~w~(Radyo): ~w~" + chat);
            }
        }
    }


    [Command("id", "~y~[!]~w~: /id [ID/İsim]")]
    public void GetPlayerId(Player sender, string idOrName)
    {
        if (sender.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(sender, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(sender) < 2)
        {
            return;
        }

        Player target = Main.findPlayer(sender, idOrName);
        if (target != null)
        {
            Main.SendCustomChatMessasge(sender, string.Format("~w~{0} ~w~(ID:~y~ {1}~w~)", AccountManage.GetCharacterName(target), Main.getIdFromClient(target)));
        }

    }

    [Command("uyeler", Alias = "birlikuyeler")]
    public void CMD_membros(Player Client)
    {
        if (FactionManage.GetPlayerGroupID(Client) == 0)
        {
            Main.SendErrorMessage(Client, "Herhangi bir birliğe üye değilsin.");
            return;
        }
        int faction = AccountManage.GetPlayerGroup(Client);

        Main.SendCustomChatMessasge(Client, "<font color='#418756'>(( [" + FactionManage.faction_data[faction].faction_name + "] - Üyeler ))");
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var target in players)
        {
            if (target.GetData<dynamic>("status") == true)
            {
                if (AccountManage.GetPlayerGroup(target) == faction)
                {
                    int rank = AccountManage.GetPlayerRank(target);
                    if (FactionManage.GetPlayerGroupType(Client) != 4)
                    {
                        if (target.HasData("duty") && target.GetData<dynamic>("duty") == 1)
                        {
                            Main.SendCustomChatMessasge(Client, "<font color='#57b573'> " + AccountManage.GetCharacterName(target) + " (ID: " + Main.getIdFromClient(target) + ") - Rütbe: " + FactionManage.faction_data[faction].faction_rank[rank] + " (" + rank + ")  ~g~İşbaşında ");
                        }
                        else
                        {
                            Main.SendCustomChatMessasge(Client, "<font color='#57b573'> " + AccountManage.GetCharacterName(target) + " (ID: " + Main.getIdFromClient(target) + ") - Rütbe: " + FactionManage.faction_data[faction].faction_rank[rank] + " (" + rank + ")  ~r~İşbaşında değil.");
                        }
                    }
                    else
                    {
                        Main.SendCustomChatMessasge(Client, "<font color='#57b573'> " + AccountManage.GetCharacterName(target) + " (ID: " + Main.getIdFromClient(target) + ") - Rütbe: " + FactionManage.faction_data[faction].faction_rank[rank] + " (" + rank + ")");
                    }
                }
            }
        }
    }

    [Command("gasp", "~y~[!]~w~: /gasp [ID/İsim]", Alias = "gaspet, paracal")]
    public void CMD_mug(Player Client, string idOrName)
    {
        Player target = Main.findPlayer(Client, idOrName);

        if (target == null)
        {
            return;
        }

        if (Client == target)
        {
            Main.SendErrorMessage(Client, "Kendinizi gasp edemezsiniz.");
            return;
        }

        if (FactionManage.GetPlayerGroupID(Client) != 4)
        {
            Main.SendErrorMessage(Client, "Bunu yapamazsınız!");
            return;
        }

        if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 2.0f))
        {
            Main.SendErrorMessage(Client, "Gasp etmek istediğiniz kişiye yakın değilsiniz.");
            return;
        }

        if (target.HasData("mug_timeout") && target.GetData<dynamic>("mug_timeout") < DateTime.Now)
        {
            Main.SendErrorMessage(Client, "Bu oyuncu zaten yakınlarda gasp edilmiş.");
            return;
        }

        if (target.GetData<dynamic>("handsup") == false)
        {
            Main.SendErrorMessage(Client, "Oyuncunun elleri havada değil.");
            return;
        }

        if (Main.GetPlayerMoney(target) < 2)
        {
            Main.SendErrorMessage(Client, "Oyuncunun parası yok.");
            return;
        }

        int money = Main.GetPlayerMoney(target) / 2;

        Main.GivePlayerMoney(Client, money);
        Main.GivePlayerMoney(target, -money);

        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
        foreach (Player alvo in proxPlayers)
        {
            alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + ", elini " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + "'in cebine elini atıp $" + money + " çaldı.");
        }

        target.SetData<dynamic>("mug_timeout", DateTime.Now.AddMinutes(15));
    }


    [Command("me", "~y~[!]~w~: /me [Hareket]", GreedyArg = true)]
    public void ME_Command(Player Client, string hareket)
    {
        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(10, Client);
        foreach (Player target in proxPlayers)
        {
            Main.SendCustomChatMessasge(target, "<font color ='#249628'>* " + AccountManage.GetCharacterName(Client) + " " + hareket + "");
        }
    }

    [Command("do", "~y~[!]~w~: /do [Durum]", GreedyArg = true)]
    public void DO_Command(Player Client, string durum)
    {

        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(10, Client);
        foreach (Player target in proxPlayers)
        {
            Main.SendCustomChatMessasge(target, "<font color ='#249628'>* " + durum + " (( " + AccountManage.GetCharacterName(Client) + " ))");
        }
    }

    [Command("s", "~y~[!]~w~: /s(hout) [Mesaj]", Alias = "shout", GreedyArg = true)]
    public void S_Command(Player Client, string mesaj)
    {
        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
        foreach (Player target in proxPlayers)
        {

            if (target.Dimension == Client.Dimension)
            {
                Main.SendCustomChatMessasge(target, UsefullyRP.GetPlayerNameToTarget(Client, target) + " " + "bağırarak: " + Main.EMBED_WHITE + " " + mesaj + "!");
            }

        }

    }

    [Command("w", "~y~[!]~w~: /w(hisper) [Mesaj]", Alias = "whisper", GreedyArg = true)]
    public void W_Command(Player Client, string mesaj)
    {
        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(3f, Client);
        foreach (Player target in proxPlayers)
        {
            if (target.Dimension == Client.Dimension)
            {
                Main.SendCustomChatMessasge(target, Main.EMBED_GREY + UsefullyRP.GetPlayerNameToTarget(Client, target) + " " + Main.EMBED_GREY + "fısıldayarak: " + " " + mesaj);
            }
            //target.TriggerEvent("Send_ToChat", "", UsefullyRP.GetPlayerNameToTarget(Client, target) + " " + Main.EMBED_GREY + "sussurra: " + Main.EMBED_WHITE + " " + poruka);
        }
    }

    [Command("b", GreedyArg = true, Alias = "ooc")]
    public void B_Command(Player Client, string mesaj)
    {
        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(20f, Client);

        foreach (Player target in proxPlayers)
        {
            if (target.Dimension == Client.Dimension)
            {
                Main.SendCustomChatMessasge(target, Main.EMBED_GREY + "(( " + Main.EMBED_WHITE + "" + UsefullyRP.GetPlayerNameToTarget(Client, target) + ": " + mesaj + " " + Main.EMBED_GREY + "))");
            }
        }
    }




    [Command("f", Alias = "faction", GreedyArg = true)]
    public void CMD_faction(Player Client, string mesaj)
    {
        if (FactionManage.GetPlayerGroupType(Client) == 4 || AccountManage.GetPlayerRank(Client) == -1)
        {
            InteractMenu_New.SendNotificationError(Client, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }

        int faction = AccountManage.GetPlayerGroup(Client);
        int rank = AccountManage.GetPlayerRank(Client);

        var players = NAPI.Pools.GetAllPlayers();

        foreach (Player c in players)
        {
            if (c.GetData<dynamic>("status") == true)
            {
                if (AccountManage.GetPlayerGroup(c) == faction)
                {
                    Main.SendMessageWithTagToPlayer(c, "" + Main.EMBED_CYAN + "** (( ", "" + Main.EMBED_CYAN + "" + " " + AccountManage.GetCharacterName(Client) + " " + mesaj + "" + " )) **");
                }
            }
        }
    }


    [Command("kabul", "~y~[!]~w~: /kabul [İşlem]", Alias = "kabulet")]
    public void CMD_aceitar(Player Client, string islem)
    {

        if (islem == "tedavi")
        {
            if (Client.GetData<dynamic>("curar_offerPrice") != 0)
            {
                if (!AccountManage.GetPlayerConnected(Client.GetData<dynamic>("curar_offerBy")))
                {
                    Client.SetData<dynamic>("curar_offerBy", null);
                    Client.SetData<dynamic>("curar_offerPrice", 0);

                    Main.SendErrorMessage(Client, "Kimse size tedavi teklif etmedi veya tedaviyi teklif eden doktor sunucudan ayrıldı.");
                    return;
                }
                if (Main.GetPlayerMoney(Client) < Client.GetData<dynamic>("curar_offerPrice"))
                {
                    Client.SetData<dynamic>("curar_offerBy", null);
                    Client.SetData<dynamic>("curar_offerPrice", 0);
                    Main.SendErrorMessage(Client, "Yeterli miktarda paranız yok.");
                    return;
                }

                if (!Main.IsInRangeOfPoint(Client.Position, NAPI.Entity.GetEntityPosition(Client.GetData<dynamic>("curar_offerBy")), 30))
                {
                    Client.SetData<dynamic>("curar_offerBy", null);
                    Client.SetData<dynamic>("curar_offerPrice", 0);
                    Main.SendErrorMessage(Client, "Doktorun yanına yakın değilsiniz.");
                    return;
                }

                NAPI.Player.SetPlayerHealth(Client, 100);

                Main.SendSuccessMessage(Client, "" + AccountManage.GetCharacterName(Client.GetData<dynamic>("curar_offerBy")) + "~w~ Sizi ~g~$" + Client.GetData<dynamic>("curar_offerPrice").ToString("N0") + "~w~ karşılığında tedavi etti.");
                Main.SendCustomChatMessasge(Client.GetData<dynamic>("curar_offerBy"), " adlı doktor, ~y~" + AccountManage.GetCharacterName(Client) + "~w~ adlı oyuncuyu ~g~$" + Client.GetData<dynamic>("curar_offerPrice").ToString("N0") + "~w~ karşılığında tedavi etti.");

                Main.GivePlayerMoney(Client, -Client.GetData<dynamic>("curar_offerPrice"));
                Main.GivePlayerMoney(Client.GetData<dynamic>("curar_offerBy"), Client.GetData<dynamic>("curar_offerPrice"));

                Client.SetData<dynamic>("curar_offerBy", null);
                Client.SetData<dynamic>("curar_offerPrice", 0);
            }
        }
        else if (islem == "davet")
        {
            if (Client.GetData<dynamic>("group_invite") != -1)
            {
                if (FactionManage.GetPlayerGroupID(Client) == 1)
                {
                    return;
                }
                int group_id = Client.GetData<dynamic>("group_invite");
                Player inviteBy = Client.GetData<dynamic>("group_inviteBy");

                if (Main.IsPlayerLogged(inviteBy) == true)
                {
                    FactionManage.SendFactionMessage(inviteBy, "~w~ ~g~" + UsefullyRP.GetPlayerNameToTarget(Client, inviteBy) + "~w~'yi davet ettiniz.");
                    FactionManage.SendFactionMessage(Client, "~w~ Davetinizi kabul ettiniz ~g~" + UsefullyRP.GetPlayerNameToTarget(inviteBy, Client) + "~w~ ve birliğe katıldınız.");

                    AccountManage.SetPlayerLeader(Client, 0);
                    AccountManage.SetPlayerGroup(Client, group_id);
                    AccountManage.SetPlayerRank(Client, 0);
                    Client.TriggerEvent("factionchange", group_id);

                    FactionManage.SaveFaction(group_id);
                    Client.SetData<dynamic>("group_invite", -1);
                    Client.SetData<dynamic>("group_inviteBy", -1);
                }
                else
                {
                    Client.SetData<dynamic>("group_invite", -1);
                    Client.SetData<dynamic>("group_inviteBy", -1);

                    InteractMenu_New.SendNotificationError(Client, "Kimse sizi davet etmeyi veya davet eden kişi sunucudan ayrıldı.");
                }
            }
            else InteractMenu_New.SendNotificationError(Client, "Kimse sizi davet etmeyi veya davet eden kişi sunucudan ayrıldı.");
        }
    }

    [Command("davetet", "~y~[!]~w~: /davetet [ID/İsim]")]
    public void CMD_convidar(Player Client, string idOrName)
    {

        Player target = Main.findPlayer(Client, idOrName);
        if (AccountManage.GetPlayerLeader(Client) < 1 && AccountManage.GetPlayerLeader(Client) > FactionManage.MAX_FACTIONS)
        {
            Main.SendErrorMessage(Client, "Bu işlemi gerçekleştirebilmek için yeterli yetkiniz yok.");
            return;
        }
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Geçersiz oyuncu!");
                return;
            }
            if (target.GetData<dynamic>("character_level") < 3)
            {
                Main.SendErrorMessage(Client, "Davet etmek istediğiniz kişinin seviyesi yeterli değil.");
                return;
            }
            if (AccountManage.GetPlayerGroup(target) != 0)
            {
                Main.SendErrorMessage(Client, "Davet etmek istediğiniz kişi zaten bir birliğe mensup.");
                return;
            }

            if (target.GetData<dynamic>("group_invite") != -1)
            {
                Main.SendErrorMessage(Client, "Davet etmek istediğiniz kişinin aktif bir daveti var.");
                return;
            }
            if (target.Position.DistanceTo(Client.Position) > 4)
            {
                Main.SendErrorMessage(Client, "Davet etmek istediğiniz kişiye yakın değilsiniz.");
                return;
            }

            int group_id = AccountManage.GetPlayerGroup(Client);
            target.SetData<dynamic>("group_invite", AccountManage.GetPlayerGroup(Client));
            target.SetData<dynamic>("group_inviteBy", Client);

            FactionManage.SendFactionMessage(target, " ~g~" + UsefullyRP.GetPlayerNameToTarget(Client, target) + "~w~ sizi ~b~" + FactionManage.faction_data[group_id].faction_name + "~w~ adlı birliğe katılmaya davet etti.");

            FactionManage.SendFactionMessage(Client, "~g~" + UsefullyRP.GetPlayerNameToTarget(target, Client) + "~w~ adlı oyuncuyu birliğe davet ettiniz.");

            faction_blip.RemoveBlip(target);

            NAPI.Task.Run(() =>
            {
                if (NAPI.Player.IsPlayerConnected(target))
                {
                    target.SetData<dynamic>("group_inviteBy", -1);
                    target.SetData<dynamic>("group_invite", -1);
                }
            }, delayTime: 30 * 1000);

        }
    }


    [Command("birliktenat", "~y~[!]~w~: /birliktenat [ID/İsim]")]
    public void CMD_expulsar(Player Client, string idOrName)
    {

        Player target = Main.findPlayer(Client, idOrName);

        if (AccountManage.GetPlayerLeader(Client) < 1 && AccountManage.GetPlayerLeader(Client) > FactionManage.MAX_FACTIONS)
        {
            Main.SendErrorMessage(Client, "Bu işlemi gerçekleştirebilmek için yeterli yetkiniz yok.");
            return;
        }
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Geçersiz oyuncu!");
                return;
            }

            int group_id = AccountManage.GetPlayerGroup(Client);

            if (AccountManage.GetPlayerGroup(target) != group_id)
            {
                Main.SendErrorMessage(Client, "Birlikten atmak istediğiniz kişi, sizin birliğinizde değil.");
            }

            Main.SendCustomChatMessasge(target, "~b~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(Client)] + " " + AccountManage.GetPlayerGroup(Client) + "~w~ sizi ~g~" + FactionManage.faction_data[group_id].faction_name + "~w~ adlı birliten attı.");

            Main.SendCustomChatMessasge(Client, "Siz, " + AccountManage.GetCharacterName(target) + " adlı oyuncuyu " + FactionManage.faction_data[group_id].faction_name + "~w~ adlı birliğinizden attınız.");

            NAPI.Data.SetEntityData(target, "duty", 0);
            Main.UpdatePlayerClothes(target);
            target.SetData<dynamic>("duty", 0);
            Outfits.RemovePlayerDutyOutfit(target);
            AccountManage.SetPlayerLeader(target, 0);
            AccountManage.SetPlayerGroup(target, 0);
            AccountManage.SetPlayerRank(target, 0);
            Main.SavePlayerInformation(target);
            faction_blip.RemoveBlip(target);

        }

    }

    [Command("rutbeyukselt", "~y~[!]~w~: /rutbeyukselt [ID/İsim]")]
    public void CMD_promover(Player Client, string idOrName)
    {

        Player target = Main.findPlayer(Client, idOrName);

        if (AccountManage.GetPlayerLeader(Client) < 1 && AccountManage.GetPlayerLeader(Client) > FactionManage.MAX_FACTIONS)
        {
            Main.SendErrorMessage(Client, "Bu işlemi gerçekleştirebilmek için yeterli yetkiniz yok.");
            return;
        }
        if (target != null)
        {
            if (target == Client)
            {
                Main.SendErrorMessage(Client, "Kendi rütbeni yükseltemezsin.");
                return;
            }
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Rütbesini yükseltmek istediğiniz kişi oyunda değil.");
                return;
            }
            int group_id = AccountManage.GetPlayerGroup(Client);

            if (AccountManage.GetPlayerGroup(target) != group_id)
            {
                Main.SendErrorMessage(Client, "Rütbesini yükseltmek istediğiniz kişi sizin birliğinizde değil.");
            }

            if (AccountManage.GetPlayerRank(target) == FactionManage.GetMaxRank(group_id) - 1)
            {
                Main.SendErrorMessage(Client, "Rütbesini yükseltmek istediğiniz kişi zaten en üst rütbede.");
                return;
            }

            Main.SendCustomChatMessasge(target, " ~b~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(Client)] + " " + AccountManage.GetPlayerGroup(Client) + "~w~, sizi ~g~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(target) + 1] + "~w~ rütbesine terfi ettirdi.");

            Main.SendCustomChatMessasge(Client, "" + AccountManage.GetCharacterName(target) + " adlı oyuncuyu ~g~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(target) + 1] + "~w~ rütbesine terfi ettirdiniz.");

            AccountManage.SetPlayerRank(target, AccountManage.GetPlayerRank(target) + 1);
        }
    }



    [Command("rutbedusur", "~y~[!]~w~: /rutbedusur [ID/İsim]")]
    public void CMD_rebaixar(Player Client, string idOrName)
    {

        Player target = Main.findPlayer(Client, idOrName);
        if (AccountManage.GetPlayerLeader(Client) < 1 && AccountManage.GetPlayerLeader(Client) > FactionManage.MAX_FACTIONS)
        {
            Main.SendErrorMessage(Client, "Bu işlemi gerçekleştirebilmek için yeterli yetkiniz yok.");
            return;
        }
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Rütbesini düşürmek istediğiniz kişi oyunda değil.");
                return;
            }
            int group_id = AccountManage.GetPlayerGroup(Client);

            if (AccountManage.GetPlayerGroup(target) != group_id)
            {
                Main.SendErrorMessage(Client, "Rütbesini düşürmek istediğiniz kişi sizin birliğinizde değil.");
            }

            if (AccountManage.GetPlayerRank(target) == 0)
            {
                Main.SendErrorMessage(Client, "Rütbesini düşürmek istediğiniz kişi zaten en düşük rütbede.");
                return;
            }

            Main.SendCustomChatMessasge(target, " ~b~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(Client)] + " " + AccountManage.GetPlayerGroup(Client) + "~w~, ~g~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(target) - 1] + "~w~ rütbesini verdi.");

            Main.SendCustomChatMessasge(Client, "" + AccountManage.GetCharacterName(target) + " adlı oyuncunun rütbesini ~g~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(target) - 1] + "~w~ olarak değiştirdiniz.");

            AccountManage.SetPlayerRank(target, AccountManage.GetPlayerRank(target) - 1);
        }

    }

    [Command("motor")]
    public void AracMotor(Player Client)
    {
        if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
        {
            if (VehicleStreaming.GetEngineState(Client.Vehicle) == true)
            {

                VehicleStreaming.SetEngineState(Client.Vehicle, false);

            }
            else if (VehicleStreaming.GetEngineState(Client.Vehicle) == false)
            {

                if (Client.HasData("Refueling"))
                {
                    Main.SendErrorMessage(Client, "Yakıt doldurulurken motoru çalıştıramazsınız.");
                    return;
                }

                Main.DisplaySubtitle(Client, " ", 3);

                Main.EmoteMessage(Client, "aracın anahtarını saat yönünde döndürerek motoru çalıştırmayı dener.");
                NAPI.Task.Run(() =>
                {
                    if (!Client.Exists) return;

                    if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
                    {
                        if (Client.Vehicle.Health < 300)
                        {
                            Main.SendErrorMessage(Client, "Aracın motoru hasarlı, motor çalıştırılamıyor.");
                            return;
                        }

                        if (NAPI.Data.HasEntityData(Client.Vehicle, "vehicle_colision"))
                        {

                            Main.SendErrorMessage(Client, "Motor durduruldu.");
                            return;
                        }

                        if (Main.GetVehicleFuel(Client.Vehicle) <= 2)
                        {

                            Main.SendErrorMessage(Client, "Aracın yakıtı yok, motor çalıştırılamıyor.");
                            return;
                        }
                        if (Client.Vehicle.HasData("IsInHighEnd") && Client.Vehicle.GetData<dynamic>("IsInHighEnd") == true)
                        {

                            Main.SendErrorMessage(Client, "Bu aracın anahtarlarına sahip değilsin.");
                            return;
                        }
                        if (Client.Vehicle.GetData<bool>("racveh") || Client.Vehicle.GetData<bool>("shipwar"))
                        {
                            return;
                        }

                        VehicleStreaming.SetEngineState(Client.Vehicle, true);

                        Main.EmoteMessage(Client, "aracın motorunu çalıştırdı.");
                    }
                }, delayTime: 1500);

            }
        }
    }

    [Command("kilit")]
    public void AracKilit(Player Client)
    {
        Vehicle vehicle = Utils.GetClosestVehicle(Client, 5.0f);

        int playerid = Main.getIdFromClient(Client);
        if (vehicle != null && NAPI.Entity.DoesEntityExist(vehicle))
        {
            for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
            {
                if ((AccountManage.GetPlayerAdmin(Client) > 6 && AccountManage.IsAdminOnDuty(Client) == 1) || PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
                {
                    if (VehicleStreaming.GetLockState(vehicle))
                    {
                        VehicleStreaming.SetLockStatus(vehicle, false);
                        Main.EmoteMessage(Client, $"{vehicle.DisplayName} model aracın kilidini açar.");
                        Notify.Send(Client, "success", "Başarıyla aracın kilidini açtınız!", 5000);
                    }
                    else
                    {
                        VehicleStreaming.SetLockStatus(vehicle, true);
                        Main.EmoteMessage(Client, $"{vehicle.DisplayName} model aracı kilitler.");
                        Notify.Send(Client, "success", "Başarıyla aracı kilitlediniz!", 5000);
                    }
                    return;
                }
            }

            for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
            {

                if (FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_owned[i] != "Unknown" && FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_entity[i] == vehicle)
                {
                    if (VehicleStreaming.GetLockState(vehicle))
                    {
                        VehicleStreaming.SetLockStatus(vehicle, false);
                        Main.EmoteMessage(Client, $"{vehicle.DisplayName} model aracın kilidini açar.");
                        Notify.Send(Client, "success", "Başarıyla aracın kilidini açtınız!", 5000);
                    }
                    else
                    {
                        VehicleStreaming.SetLockStatus(vehicle, true);
                        Main.EmoteMessage(Client, $"{vehicle.DisplayName} model aracı kilitler.");
                        Notify.Send(Client, "success", "Başarıyla aracı kilitlediniz!", 5000);
                    }
                    return;
                }
            }
        }
    }


    [Command("cc")]
    public void Clear(Player player)
    {
        Main.ClearChat(player);
        Main.SendSuccessMessage(player, "Başarıyla sohbet temizlendi.");
    }

    [Command("fontsize", "~y~[!]~w~: /fontsize [Değer / 0.5-1.5")]
    public void Fontsize(Player player, double fontSize)
    {
        Main.setFontsize(player, fontSize);
    }

    [Command("pagesize", "~y~[!]~w~: /pagesize [Değer / 4-24")]
    public void Pagesize(Player player, int pageSize)
    {
        Main.setPagesize(player, pageSize);
    }

    [Command("timestamp")]
    public void Timestamp(Player player)
    {
        Main.setTimeStamp(player);
    }

    [Command("togglechat")]
    public void Toggle(Player player)
    {
        Main.setToggleChat(player);
    }

    [Command("dl")]
    public static void DL(Player player)
    {
        if (player.GetData<bool>("VehInfo") == false)
        {
            player.SetData("VehInfo", true);
            Main.SetVehicleInformationStatus(player, true);
            Main.SendServerMessage(player, "Başarıyla araç bilgi labelleri aktif edildi.");
            return;
        }
        if (player.GetData<bool>("VehInfo") == true)
        {
            player.SetData("VehInfo", false);
            Main.SetVehicleInformationStatus(player, false);
            Main.SendServerMessage(player, "Başarıyla araç bilgi labelleri kapatıldı.");
            return;
        }
    }

    [Command("silahgizle")]
    public static void SilahGizle(Player player)
    {
        if (player.CurrentWeapon != WeaponHash.Unarmed)
        {
            Inventory.oruzijeinuse(player);
        }
    }
}