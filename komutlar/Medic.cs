/*
 /reanimar
 /desfibrilador

 */
using GTANetworkAPI;
using System;
using System.Collections.Generic;

class MedicSystem : Script
{
    List<Vector3> MD_Revive_Point = new List<Vector3> {
      {new Vector3(358.40 , -591.05 , 28.79 )},
      {new Vector3(356.83, -594.95, 28.79 )},
      {new Vector3(356.83 ,-594.95,28.79 )}
    };

    public MedicSystem()
    {
        foreach (Vector3 v in MD_Revive_Point)
        {
            ColShape ss = NAPI.ColShape.CreateCylinderColShape(v, 30f, 6, 0);
            ss.SetData<dynamic>("ColName", "MD_Revive");
        }
        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Doktor ))~n~~g~$3000~n~" + Main.LabelCommandColor + "« E »", new Vector3(308.65, -595.32, 43.28), 12, 0.3500f, 4, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Ilac ))~n~~g~$2000~n~" + Main.LabelCommandColor + "« E »", new Vector3(311.14, -565.65, 43.28), 12, 0.3500f, 4, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Ilk Yardim ))~n~~g~$1000~n~" + Main.LabelCommandColor + "« E »", new Vector3(311.75, -561.83, 43.28), 12, 0.3500f, 4, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Asansor ))~n~" + Main.LabelCommandColor + "« /asansor »", new Vector3(343.54, -581.92, 28.79), 12, 0.3500f, 4, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Asansor ))~n~" + Main.LabelCommandColor + "« /asansor »", new Vector3(332.88, -569.42, 43.28), 12, 0.3500f, 4, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Kiyafet Dolabi ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(301.19, -596.50, 43.28), 12, 0.3500f, 4, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Isbası Noktasi ))~n~" + Main.LabelCommandColor + "« /mduty »", new Vector3(304.53, -600.34, 43.28), 12, 0.3500f, 4, new Color(0, 122, 255, 150));

    }

    public static void DisplayMedicUniforms(Player Client)
    {
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "Doktor 1", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Doktor 2", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Doktor 3", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Doktor 4", Description = "", RightLabel = "" });

        InteractMenu.CreateMenu(Client, "MEDIC_UNIFORM_SELECT", "Üniforma", "~b~Seçin:", true, NAPI.Util.ToJson(menu_item_list), false);
    }


    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {  
        if (callbackId == "MEDIC_UNIFORM_SELECT")
        {
            UsefullyRP.CMD_Mascara(Client, false);
            switch (selectedIndex)
            {
                case 0:

                    if ((PedHash)Client.Model == PedHash.FreemodeMale01) // DUGI RUKAVI
                    { 
                        Client.SetClothes(3, 86, 0); // TORSO
                        Client.SetClothes(4, 138, 2); // LEGS
						//Client.SetClothes(5, 0, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 126, 0); // ACCESSORIES 
                        Client.SetClothes(8, 153, 0); // UNDERSHIRT
						//Client.SetClothes(9, 0, 0); // ARMORS
                        //Client.SetClothes(10, 90, 0); // DECALS
                        Client.SetClothes(11, 383, 3);  // TOPS
                        Client.SetAccessories(0, 9, 2);  // HATS?				
 
 
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
                        Client.SetData<dynamic>("character_duty_outfit", 211);
 
                    }
                    else if ((PedHash)Client.Model == PedHash.FreemodeFemale01) // DUGI RUKAVI
                    {
                        Client.SetClothes(3, 105, 0); // TORSO
                        Client.SetClothes(4, 145, 2); // LEGS
						//Client.SetClothes(5, 0, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 96, 0); // ACCESSORIES 
                        Client.SetClothes(8, 189, 0); // UNDERSHIRT
						//Client.SetClothes(9, 0, 0); // ARMORS
                        //Client.SetClothes(10, 90, 0); // DECALS
                        Client.SetClothes(11, 401, 3);  // TOPS
                        Client.SetAccessories(0, 9, 2);  // HATS?
 
                        
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
                        Client.SetData<dynamic>("character_duty_outfit", 211);
                    }
 
                    break;
                case 1:
                    if ((PedHash)Client.Model == PedHash.FreemodeMale01) // KRATKI RUKAVI
                    {
                        Client.SetClothes(3, 85, 0); // TORSO
                        Client.SetClothes(4, 138, 2); // LEGS
						//Client.SetClothes(5, 0, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 126, 0); // ACCESSORIES 
                        Client.SetClothes(8, 153, 0); // UNDERSHIRT
						//Client.SetClothes(9, 0, 0); // ARMORS
                        //Client.SetClothes(10, 90, 0); // DECALS
                        Client.SetClothes(11, 382, 3);  // TOPS
                        Client.SetAccessories(0, 9, 2);  // HATS?	
 
                        
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
 
 
                        Client.SetData<dynamic>("character_duty_outfit", 212); 
 
                    }
                    else if ((PedHash)Client.Model == PedHash.FreemodeFemale01) // KRATKI RUKAVI
                    {
                        Client.SetClothes(3, 109, 0); // TORSO
                        Client.SetClothes(4, 145, 2); // LEGS
						//Client.SetClothes(5, 0, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 96, 0); // ACCESSORIES 
                        Client.SetClothes(8, 189, 0); // UNDERSHIRT
						//Client.SetClothes(9, 0, 0); // ARMORS
                        //Client.SetClothes(10, 90, 0); // DECALS
                        Client.SetClothes(11, 400, 3);  // TOPS
                        Client.SetAccessories(0, 9, 2);  // HATS?	                 
 
 
 
                        
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
                        Client.SetData<dynamic>("character_duty_outfit", 212);
                    }
                    break;
                case 2:
                    if ((PedHash)Client.Model == PedHash.FreemodeMale01) // MANTIL
                    {
                        Client.SetClothes(3, 1, 0); // TORSO
                        Client.SetClothes(4, 23, 0); // LEGS
						//Client.SetClothes(5, 0, 0); // BAGS
                        Client.SetClothes(6, 50, 0); // SHOES  
                        Client.SetClothes(7, 126, 0); // ACCESSORIES 
                        Client.SetClothes(8, 10, 0); // UNDERSHIRT
						//Client.SetClothes(9, 0, 0); // ARMORS
                        //Client.SetClothes(10, 90, 0); // DECALS
                        Client.SetClothes(11, 384, 0);  // TOPS
                        //Client.SetPropIndex(0, 9, 2);  // HATS?                   
 
 
                        
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
 
                        Client.SetData<dynamic>("character_duty_outfit", 213);
 
                    }
                    else if ((PedHash)Client.Model == PedHash.FreemodeFemale01) // MANTIL
                    {
                        Client.SetClothes(3, 1, 0); // TORSO
                        Client.SetClothes(4, 23, 0); // LEGS
						//Client.SetClothes(5, 0, 0); // BAGS
                        Client.SetClothes(6, 57, 0); // SHOES  
                        Client.SetClothes(7, 96, 0); // ACCESSORIES 
                        Client.SetClothes(8, 26, 0); // UNDERSHIRT
						//Client.SetClothes(9, 0, 0); // ARMORS
                        //Client.SetClothes(10, 90, 0); // DECALS
                        Client.SetClothes(11, 402, 0);  // TOPS
                        //Client.SetPropIndex(0, 9, 2);  // HATS?           
 
 
                        
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
                        Client.SetData<dynamic>("character_duty_outfit", 213); 
                    }
                    break;
                case 3:
                    if ((PedHash)Client.Model == PedHash.FreemodeMale01) // HIRURG
                    {
                        Client.SetClothes(3, 85, 0); // TORSO
                        Client.SetClothes(4, 96, 1); // LEGS
						//Client.SetClothes(5, 0, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 126, 0); // ACCESSORIES 
                        Client.SetClothes(8, 153, 0); // UNDERSHIRT
						//Client.SetClothes(9, 0, 0); // ARMORS
                        Client.SetClothes(10, 58, 0); // DECALS
                        Client.SetClothes(11, 250, 1);  // TOPS
                        Client.SetAccessories(0, 122, 1);  // HATS?	
 
 
                        Client.SetData<dynamic>("character_duty_outfit", 214);
 
                    }
                    else if ((PedHash)Client.Model == PedHash.FreemodeFemale01) // HIRURG
                    {
                        Client.SetClothes(3, 109, 0); // TORSO
                        Client.SetClothes(4, 145, 2); // LEGS
						//Client.SetClothes(5, 0, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 96, 0); // ACCESSORIES 
                        Client.SetClothes(8, 189, 0); // UNDERSHIRT
						//Client.SetClothes(9, 0, 0); // ARMORS
                        //Client.SetClothes(10, 66, 0); // DECALS
                        Client.SetClothes(11, 258, 1);  // TOPS
                        Client.SetAccessories(0, 121, 1);  // HATS?	   
 
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
                        Client.SetData<dynamic>("character_duty_outfit", 214);
                    }
                break;
            }
            Client.TriggerEvent("freeze", false);

        }
    }

    public static void keypresse(Player client)
    {
        if(Main.GetPlayerMoney(client) < 3000)
        {
            Main.SendErrorMessage(client, "Yeterli miktarda paranız yok!");
            return;
        }
        if(NAPI.Player.GetPlayerHealth(client) >= 99)
        {
            Main.SendErrorMessage(client, "Tedavi olmanıza gerek yok.");
            return;
        }

        client.TriggerEvent("DialogCagir", "Hastane > Doktor", "$3.000 karşılığında tedavi olmayı kabul ediyor musun?", "Evet", "Hayır", 1);
    }

    [Command("mduty")]
    public static void mdutycmd(Player Client)
    {
        if(Main.IsInRangeOfPoint(Client.Position, new Vector3(304.53, -600.34, 43.28), 2.0f))
        if (FactionManage.GetPlayerGroupID(Client) == FactionManage.FACTION_TYPE_MEDIC)
        {
        
            if (Client.GetData<dynamic>("duty") == 0)
            {
                NAPI.Notification.SendNotificationToPlayer(Client, Translation.notification_11);
                Client.SetData<dynamic>("duty", 1);

            }
            else if (Client.GetData<dynamic>("duty") == 1)
            {
                NAPI.Notification.SendNotificationToPlayer(Client, Translation.notification_12);
                Client.SetData<dynamic>("duty", 0);
                Outfits.RemovePlayerDutyOutfit(Client);
                Main.UpdatePlayerClothes(Client);
                NAPI.Player.SetPlayerArmor(Client, 0);

            }
        }
    }

    public static void MakeMeds(Player Client)
    {
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_MEDIC)
        {
            InteractMenu_New.SendNotificationError(Client, "Bu işlemi yapabilmek için LSMD birliğinde olmalısın.");
            return;
        }
        if (AccountManage.GetPlayerRank(Client) < 5)
        {
            Main.DisplayErrorMessage(Client, "error",  "Bu işlemi yapabilmek için rütbenizin mimimum 5 olması gerekmekte.");
        }
        if (Client.GetData<dynamic>("MedMakeOn") == true)
        {
            Main.DisplayErrorMessage(Client, "error",  "Zaten ilaç yapıyorsunuz!");
            return;
        }
        Client.SetData("MedMakeOn", true);
        NAPI.Player.PlayPlayerAnimation(Client, 39, "mp_fbi_heist", "loop");
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(Client))
            {
                Inventory.GiveItemToInventory(Client, 27, 1);
                Main.DisplayErrorMessage(Client, "success", "Başarıyla ilaç yaptınız!");
                Main.GivePlayerMoney(Client, -2000);
                Client.StopAnimation();
                Client.SetData("MedMakeOn", false);
            }

        }, delayTime: 10000);

    }
    public static void MakeFAid(Player Client)
    {
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_MEDIC)
        {
            InteractMenu_New.SendNotificationError(Client, "Bu komutu kullanabilmek için LSMD birliğinde olmalısın.");
            return;
        }
        if (AccountManage.GetPlayerRank(Client) < 3)
        {
            Main.DisplayErrorMessage(Client, "error",  "Bu işlemi yapabilmek için rütbenizin mimimum 3 olması gerekmekte.");
        }
        if (Client.GetData<dynamic>("MedMakeOn") == true)
        {
            Main.DisplayErrorMessage(Client, "error",  "Zaten ilk yardım yapıyorsunuz!");
            return;
        }
        Client.SetData("MedMakeOn", true);
        NAPI.Player.PlayPlayerAnimation(Client, 39, "mp_fbi_heist", "loop");
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(Client))
            {
                Inventory.GiveItemToInventory(Client, 22, 1);
                Main.DisplayErrorMessage(Client, "success", "Başarıyla ilk yardım yaptınız!");
                Main.GivePlayerMoney(Client, -1000);
                Client.StopAnimation();
                Client.SetData("MedMakeOn", false);
            }

        }, delayTime: 10000);

    }


    [Command("asansor")]
    public static void EMSLift(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(343.54, -581.92, 28.79), 3.0f))
        {
            Client.Position = new Vector3(332.88, -569.42, 43.28);
            return;
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(332.88, -569.42, 43.28), 3.0f))
        {
            Client.Position = new Vector3(343.54, -581.92, 28.79);
            return;
        }

    }

    [Command("tedaviet", "~y~[!]~w~: /tedaviet [ID/İsim] [Fiyat]")]
    public static void CMD_Izleci(Player Client, string idOrName, int price)
    {
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_MEDIC)
        {
            InteractMenu_New.SendNotificationError(Client, "Bu komutu kullanabilmek için LSMD birliğinde olmalısın.");
            return;
        }

        if (NAPI.Data.HasEntityData(Client, "reanimando"))
        {
            if (Client.GetData<dynamic>("reanimando") == true)
            {
                Main.SendErrorMessage(Client, "Şu anda bunu yapamazsınız!");
                return;
            }
        }
        if (Client.GetSharedData<dynamic>("Injured") == 1)
        {
            Main.SendErrorMessage(Client, "Şu anda bunu yapamazsınız!");
            return;
        }
        if (price < 1)
        {
            Main.SendCustomChatMessasge(Client, "Tutar $1'den az veya $5.000'den fazla olamaz!");
            return;
        }
        if (price > 5000)
        {
            Main.SendCustomChatMessasge(Client, "Tutar $1'den az veya $5.000'den fazla olamaz!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            if (target.GetSharedData<dynamic>("Injured") == 1)
            {
                Main.SendErrorMessage(Client, "Kişi baygın. Farklı bir tür yardım gerekiyor!");
                return;
            }

            if (target.Health >= 100)
            {
                Main.SendErrorMessage(Client, "Oyuncunun tedaviye ihtiyacı yok.");
                return;
            }

            if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 5))
            {
                Main.SendErrorMessage(Client, "Tedavi etmek istediğiniz kişiye yakın değilsiniz!");
                return;
            }

            Main.SendServerMessage(Client,AccountManage.GetCharacterName(target) + " isimli kişiye ~g~$" + price.ToString("N0") + "~w~ karşılığında tedavi teklif ettiniz.");
            Main.SendInfoMessage(target, AccountManage.GetCharacterName(Client) + "adlı Doktor, size $" + price.ToString("N0") + "~w~ karşılığında tedavi teklif ediyor. (Kabul etmek için: /kabulet tedavi). ");

            target.SetData<dynamic>("curar_offerBy", Client);
            target.SetData<dynamic>("curar_offerPrice", price);

            target.TriggerEvent("update_health", target.Health, target.Armor);

            NAPI.Task.Run(() =>
            {
                if (!Client.Exists) return;

                Client.SetData<dynamic>("curar_offerBy", null);
                Client.SetData<dynamic>("curar_offerPrice", 0);
            }, delayTime: 30000);
        }
    }

    [Command("yaralitedaviet", "~y~[!]~w~: /yaralitedaviet [ID/İsim]")]
    public static void CMD_CPR(Player Client, string idOrName)
    {
        if (FactionManage.GetPlayerGroupID(Client) != 2)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için LSMD birliğinde olmalısın.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            if (Client.Position.DistanceTo(target.Position) > 3)
            {
                Main.SendErrorMessage(Client, "Tedavi etmek istediğiniz kişiye yakın değilsiniz!");
                return;
            }
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Oyuncu sunucuda değil.");
                return;
            }
            if (target.GetSharedData<dynamic>("Injured") != 1)
            {
                Main.SendErrorMessage(Client, "Oyuncu yaralı değil.");
                return;
            }
            if (Client.GetSharedData<dynamic>("Injured") == 1)
            {
                Main.SendErrorMessage(Client, "Şu anda bunu yapamazsınız!");
                return;
            }

            // target.SetSharedData("Injured", 0);

            target.TriggerEvent("freeze", false);

            CMD_medicrevive(Client, target);
            Main.GivePlayerMoney(Client, 1000);
            Main.GivePlayerMoney(target, -1000);

            //NAPI.Player.StopPlayerAnimation(target);

        }
        else Main.SendErrorMessage(Client, "Oyuncu yaralı değil.");
    }

    public static void CMD_medicrevive(Player Client, Player target)
    {
        if (NAPI.Data.HasEntityData(Client, "reanimando"))
        {
            if (Client.GetData<dynamic>("reanimando") == true)
            {
                Main.SendErrorMessage(Client, "Tedavi devam ediyor, lütfen bekleyin...");
                return;
            }
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_MEDIC && FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(Client, "Bu işlemi yapabilmek için LSMD birliğinde olmalısın.");
            return;
        }
        if (Client.GetSharedData<dynamic>("Injured") == 1)
        {
            Main.SendErrorMessage(Client, "Şu anda bunu yapamazsınız!");
            return;
        }
        if (target.GetData<dynamic>("status") == true)
        {
            if (Main.IsInRangeOfPoint(Client.Position, target.Position, 2.0f) && Client != target)
            {
                if (target.GetSharedData<dynamic>("Injured") == 1)
                {
                    if (Client.Exists == false) return;
                    if (target.Exists == false) return;

                    Vector3 playerpos = Client.Position;
                    target.TriggerEvent("freezeEx", true);
                    Client.TriggerEvent("freezeEx", true);
                    target.TriggerEvent("freeze", true);
                    Client.TriggerEvent("freeze", true);

                    Client.SetData<dynamic>("reanimando", true);

                    NAPI.Task.Run(() =>
                    {
                        if (Client.Exists == false) return;
                        if (target.Exists == false) return;
                        target.Rotation = new Vector3(target.Rotation.X, target.Rotation.Y, 359);
                        Client.Rotation = new Vector3(Client.Rotation.X, Client.Rotation.Y, 264);

                        NAPI.Entity.SetEntityPosition(target, new Vector3(playerpos.X + 1, playerpos.Y - 0.4, playerpos.Z));
                        NAPI.Entity.SetEntityPosition(Client, new Vector3(playerpos.X, playerpos.Y, playerpos.Z));

                        target.PlayAnimation("mini@cpr@char_b@cpr_str", "cpr_kol_idle", 39);
                        Client.PlayAnimation("mini@cpr@char_a@cpr_def", "cpr_intro", 39);

                        NAPI.Task.Run(() =>
                        {
                            if (Client.Exists == false) return;
                            if (target.Exists == false) return;

                            target.PlayAnimation("mini@cpr@char_b@cpr_str", "cpr_pumpchest", 39);
                            Client.PlayAnimation("mini@cpr@char_a@cpr_str", "cpr_pumpchest", 39);

                            target.TriggerEvent("InjuredSystem:Destroy");

                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists == false) return;
                                if (target.Exists == false) return;

                                Revive_Player(target);

                                Client.TriggerEvent("freezeEx", false);
                                target.TriggerEvent("freezeEx", false);
                                target.TriggerEvent("freeze", false);
                                Client.TriggerEvent("freeze", false);

                                Client.StopAnimation();
                                target.StopAnimation();

                                target.SetSharedData("Injured", 0);

                                Client.SetData<dynamic>("reanimando", false);

                                NAPI.Player.SetPlayerHealth(target, 40);
                                AccountManage.SetPlayerHunger(target, 25);
                                AccountManage.SetPlayerThirsty(target, 25);
                                target.TriggerEvent("update_health", target.Health, target.Armor);

                                if (Client != target) Main.SendSuccessMessage(Client, $"Tedavi başarıyla tamamlandı, hasta kurtarıldı!");
                                Main.SendInfoMessage(target, "" + UsefullyRP.GetPlayerNameToTarget(Client, target) + " sizi tedavi etti.");
                            }, 8000);
                        }, 7500);
                    }, 1000);
                    return;
                }
            }
            Main.SendErrorMessage(Client, "Tedavi etmek istediğiniz kişiye yakın değilsiniz!");
        }
    }

    [Command("hastaneyatir")]
    public void Drop_To_Hospital(Player player)
    {
        if (!player.IsInVehicle)
        {
            return;
        }
        if (AccountManage.GetPlayerGroup(player) != 2 && player.Vehicle.Class != 18)
        {
            return;
        }
        foreach (var item in MD_Revive_Point)
        {
            if (item.DistanceTo(player.Position) <= 6)
            {
                List<Player> players = NAPI.Pools.GetAllPlayers();
                foreach (var c in players)
                {
                    if (AccountManage.GetPlayerConnected(c) && c.IsInVehicle && c.Vehicle.Handle == player.Vehicle.Handle && c.GetSharedData<dynamic>("Injured") == 1)
                    {
                        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(20, player);
                        foreach (Player target in proxPlayers)
                        {
                            Main.SendCustomChatMessasge(target, "<font color ='#C2A2DA'>" + UsefullyRP.GetPlayerNameToTarget(c, target) + " sedye ile hastaneye götürüldü.");
                        }
                        MedicSystem.Revive_Player(c);
                    }
                }
            }
        }
    }

    public static void Revive_Player(Player Client)
    {
        int count = 0;
        try
        {

            foreach (Player item in NAPI.Pools.GetAllPlayers())
            {
                if (AccountManage.GetPlayerGroup(item) == 2)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                if (Client.IsInVehicle)
                {
                    Player target = null;
                    foreach (Player pl in NAPI.Player.GetPlayersInRadiusOfPlayer(4, Client))
                    {
                        if (pl.IsInVehicle && pl.VehicleSeat == (int)VehicleSeat.Driver && Client.Vehicle.Handle == pl.Vehicle.Handle)
                        {
                            target = pl;
                            break;
                        }
                    }

                    if (target != null && AccountManage.GetPlayerGroup(target) == 2 && Client.Vehicle.Class == 18)
                    {

                        if (Client.GetData<dynamic>("playerCuffed") == 1)
                        {
                            NAPI.Player.PlayPlayerAnimation(Client, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.AllowPlayerControl | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "idle");
                        }
                        if (Client.GetSharedData<dynamic>("Injured") != 1)
                        {
                            Client.TriggerEvent("freezeEx", false);
                            Client.TriggerEvent("TanabCuff", false);
                        }
                        Client.TriggerEvent("setFollow", false, null);
                        Client.SetData<dynamic>("BeingDragged", false);

                        UsefullyRP.RemoveMaskFromPlayer(Client);

                        if (NAPI.Data.GetEntityData(Client, "MainProgressText") == true)
                        {
                            Main.DeleteTextProgressBar(Client);
                        }
                        NAPI.Player.StopPlayerAnimation(Client);
                        Client.SetSharedData("Injured", 2);
                        Client.SetSharedData("InjuredTime", 30);

                        AccountManage.SetPlayerHunger(Client, 50.0f);
                        AccountManage.SetPlayerThirsty(Client, 40.0f);

                        Client.SetSharedData("Injured", 2);
                        Client.SetSharedData("character_hospital", 1);
                        Main.SendCustomChatMessasge(Client, Translation.message_06);
                        NAPI.ClientEvent.TriggerClientEvent(Client, "DisplayCustomCamera", new Vector3(219.664, -631.7549, 93.18502), new Vector3(-4, 0, 155));
                        NAPI.Entity.SetEntityPosition(Client, new Vector3(346.97, -600.84, 67.22));
                        Client.TriggerEvent("freeze", true);


                        TimeSpan time = TimeSpan.FromSeconds(Client.GetSharedData<dynamic>("InjuredTime"));
                        string time_left = time.ToString(@"mm\:ss");


                    }
                    return;
                }
                return;
            }
            else
            {
                Player target = null;
                foreach (Player pl in NAPI.Player.GetPlayersInRadiusOfPlayer(7, Client))
                {
                    if (pl.IsInVehicle && pl.VehicleSeat == (int)VehicleSeat.Driver && Client.Vehicle.Handle == pl.Vehicle.Handle)
                    {
                        target = pl;
                        break;
                    }
                }
                if (target != null && AccountManage.GetPlayerGroup(target) == 1 && Client.Vehicle.Class == 18)
                {

                    UsefullyRP.RemoveMaskFromPlayer(Client);

                    if (NAPI.Data.GetEntityData(Client, "MainProgressText") == true)
                    {
                        Main.DeleteTextProgressBar(Client);
                    }
                    NAPI.Player.StopPlayerAnimation(Client);
                    Client.SetSharedData("Injured", 2);
                    Client.SetSharedData("InjuredTime", 30);

                    AccountManage.SetPlayerHunger(Client, 50.0f);
                    AccountManage.SetPlayerThirsty(Client, 40.0f);

                    Client.SetSharedData("Injured", 2);
                    Client.SetSharedData("character_hospital", 1);
                    Main.SendCustomChatMessasge(Client, Translation.message_06);
                    NAPI.ClientEvent.TriggerClientEvent(Client, "DisplayCustomCamera", new Vector3(219.664, -631.7549, 93.18502), new Vector3(-4, 0, 155));
                    NAPI.Entity.SetEntityPosition(Client, new Vector3(346.97, -600.84, 67.22));
                    Client.TriggerEvent("freeze", true);


                    TimeSpan time = TimeSpan.FromSeconds(Client.GetSharedData<dynamic>("InjuredTime"));
                    string time_left = time.ToString(@"mm\:ss");


                }
                return;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    [RemoteEvent("getemsvehs")]
    public static void getemsvehs(Player Client, int index)
    {
        try
        {
            switch (index)
            {
                case 0:
                    {
                        VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("ambulance");
                        var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, new Vector3(333.52, -574.74, 28.79), -16f, 0, 0);
                        vehicle.Dimension = 0;
                        Random tbla = new Random();
                        int tabla = tbla.Next(100, 999);
                        string finaltabl = "LSMD-" + tabla;
                        vehicle.NumberPlate = finaltabl;
                        vehicle.PrimaryColor = 111;
                        vehicle.SecondaryColor = 111;
                        Main.SetVehicleFuel(vehicle, 90.0);
                        vehicle.SetData("emsveh", true);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla araç garajdan çıkartıldı!");
                        break;
                    }
                case 1:
                    {
                        VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("ambulance");
                        var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, new Vector3(326.32, -572.79, 28.79), -16f, 0, 0);
                        vehicle.Dimension = 0;
                        Random tbla = new Random();
                        int tabla = tbla.Next(100, 999);
                        string finaltabl = "LSMD-" + tabla;
                        vehicle.NumberPlate = finaltabl;
                        vehicle.PrimaryColor = 111;
                        vehicle.SecondaryColor = 111;
                        Main.SetVehicleFuel(vehicle, 90.0);
                        vehicle.SetData("emsveh", true);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla araç garajdan çıkartıldı!");
                        break;
                    }
                case 2:
                    {
                        VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("ambulance");
                        var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, new Vector3(326.93, -582.53, 28.79), -16f, 0, 0);
                        vehicle.Dimension = 0;
                        Random tbla = new Random();
                        int tabla = tbla.Next(100, 999);
                        string finaltabl = "LSMD-" + tabla;
                        vehicle.NumberPlate = finaltabl;
                        vehicle.PrimaryColor = 111;
                        vehicle.SecondaryColor = 111;
                        Main.SetVehicleFuel(vehicle, 90.0);
                        vehicle.SetData("emsveh", true);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla araç garajdan çıkartıldı!");
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static void delemscar(Player player)
    {
        if (!player.IsInVehicle)
        {
            return;
        }
        Vehicle veh = player.Vehicle;
        if (veh.GetData<dynamic>("emsveh") == true)
        {
            veh.Delete();
        }
        else
        {
            Main.DisplayErrorMessage(player, "error", "Bu araç, LSMD aracı değil!");
            return;
        }
    }

    /*
    var players = NAPI.Pools.GetAllPlayers();
    if (target.GetData<dynamic>("status") == true)
    {
        if (Main.IsInRangeOfPoint(sender.Position, target.Position, 2.0f) && sender != target)
        {
            if (target.GetSharedData<dynamic>("Injured") == 1)
            {

                sender.SetData<dynamic>("reanimando", true);
                Main.SendCustomChatMessasge(sender, "~y~[INFO]:~w~ Shoma dar hale talash Baraye ehyaye bimar hastid ~y~" + AccountManage.GetCharacterName(target) + "~w~ ...");
                NAPI.Player.PlayPlayerAnimation(sender, 49, "mini@cpr@char_a@cpr_str", "cpr_kol");
                NAPI.Task.Run(() =>
                {
                    if (!sender.Exists) return;
                    if (!target.Exists) return;

                    if (sender.GetData<dynamic>("reanimando") == true)
                    {
                        AccountManage.SetPlayerHunger(target, 20.0f);
                        AccountManage.SetPlayerThirsty(target, 20.0f);
                        sender.SetData<dynamic>("reanimando", false);
                        target.SetSharedData("Injured", 0);
                        NAPI.Player.SetPlayerHealth(target, 40);
                        target.TriggerEvent("freeze", false);
                        target.TriggerEvent("freezeEx", false);
                        NAPI.Player.StopPlayerAnimation(target);
                        target.TriggerEvent("InjuredSystem:Destroy");
                        NAPI.Player.StopPlayerAnimation(sender);
                        Main.SendCustomChatMessasge(sender, "~y~[INFO]:~w~ Shoma ~g~sucesso~w~ Bimar ~y~" + AccountManage.GetCharacterName(target) + "~w~.");
                        Main.SendInfoMessage(target, "You were revived by the doctor ~y~" + AccountManage.GetCharacterName(sender) + "~w~.");
                        target.TriggerEvent("update_health", target.Health);
                    }
                }, delayTime: 7 * 1000);


            }
            else Main.SendCustomChatMessasge(sender, "~r~Greska:~w~ in Player asib dide.");
        }
    }*/

}

