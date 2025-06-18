//using GTANetworkAPI;
//using System.Collections.Generic;
//using System;

//class gunshop : Script
//{
//    public static List<dynamic> gnstors = new List<dynamic>();

//    public gunshop()
//    {
//        gnstors.Add(new { MarkerType = 1, position = new Vector3(21.673754, -1106.8872, 29.79703) });
//        gnstors.Add(new { MarkerType = 1, position = new Vector3(810.36646, -2156.876, 29.619015) });
//        gnstors.Add(new { MarkerType = 1, position = new Vector3(251.90987, -49.716873, 69.941055) });
//        gnstors.Add(new { MarkerType = 1, position = new Vector3(842.7783, -1033.4158, 28.194862) });
//        gnstors.Add(new { MarkerType = 1, position = new Vector3(-662.41565, -935.65607, 21.829226) });
//        gnstors.Add(new { MarkerType = 1, position = new Vector3(-1306.0776, -393.90637, 36.69577) });
//        gnstors.Add(new { MarkerType = 1, position = new Vector3(2568.1682, 294.91653, 108.73487) });
//        gnstors.Add(new { MarkerType = 1, position = new Vector3(1693.5725, 3759.4382, 34.705315) });
//        gnstors.Add(new { MarkerType = 1, position = new Vector3(-330.30396, 6082.9517, 31.454767) });
//        gnstors.Add(new { MarkerType = 1, position = new Vector3(-1117.7506, 2697.9763, 18.55415) });
//        gnstors.Add(new { MarkerType = 1, position = new Vector3(-3171.7493, 1087.2, 20.83875) });
//        foreach (var atm in gnstors)
//        {
//            NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Silah Marketi ))~n~" + Main.LabelCommandColor + "« Y »", atm.position, 12, 0.3500f, 4, new Color(0, 122, 255, 150));

//            Entity temp_blip;
//            temp_blip = NAPI.Blip.CreateBlip(atm.position);
//            NAPI.Blip.SetBlipName(temp_blip, "Silah Marketi");
//            NAPI.Blip.SetBlipSprite(temp_blip, 110);
//            NAPI.Blip.SetBlipColor(temp_blip, 1);
//            NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
//            NAPI.Blip.SetBlipShortRange(temp_blip, true);

//        }
//    }

//    public static void gunshotstore(Player Client)
//    {
//        foreach (var guns in gnstors)
//        {
//            if (Main.IsInRangeOfPoint(Client.Position, guns.position, 3.0f))
//            {
//                Client.TriggerEvent("Display_gunsstore");
//            }
//        }
//    }

//    [RemoteEvent("bweaponshop")]
//    public static void bweaponshop(Player player, int index)
//    {
//        try
//        {
//            switch (index)
//            {
//                case 0:

//                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 18, 1, Inventory.Max_Inventory_Weight(player)))
//                    {
//                        return;
//                    }

//                    if (Main.GetPlayerMoney(player) < 500)
//                    {
//                        Main.DisplayErrorMessage(player, "error", "Üzerinizde yeterli miktarda para yok!");
//                        return;
//                    }

//                    Main.DisplayErrorMessage(player, "success", "Başarıyla 1 adet 'Pistol' satın aldınız!");
//                    Main.GivePlayerMoney(player, -500);
//                    Main.GiveCompanyMoney(9, 50);
//                    Inventory.GiveItemToInventoryFromName(player, "Pistol", 1);

//                    return;
//                case 1:

//                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 18, 1, Inventory.Max_Inventory_Weight(player)))
//                    {
//                        return;
//                    }

//                    if (Main.GetPlayerMoney(player) < 13500)
//                    {
//                        Main.DisplayErrorMessage(player, "error", "Üzerinizde yeterli miktarda para yok!");
//                        return;
//                    }

//                    Main.DisplayErrorMessage(player, "success", "Başarıyla 1 adet 'Carbinerifle' satın aldınız!");

//                    Main.GivePlayerMoney(player, -13500);
//                    Main.GiveCompanyMoney(9, 13500);
//                    Inventory.GiveItemToInventoryFromName(player, "Carbinerifle", 1);
//                    return;
//                case 2:

//                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 18, 1, Inventory.Max_Inventory_Weight(player)))
//                    {
//                        return;
//                    }

//                    if (Main.GetPlayerMoney(player) < 15000)
//                    {
//                        Main.DisplayErrorMessage(player, "error", "Üzerinizde yeterli miktarda para yok!");
//                        return;
//                    }

//                    Main.DisplayErrorMessage(player, "success", "Başarıyla 1 adet 'Assaultrifle' satın aldınız!");
//                    Main.GivePlayerMoney(player, -15000);
//                    Main.GiveCompanyMoney(9, 15000);
//                    Inventory.GiveItemToInventoryFromName(player, "Assaultrifle", 1);
//                    return;
//                case 3:

//                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 6, 1, Inventory.Max_Inventory_Weight(player)))
//                    {

//                        return;

//                    }

//                    if (Main.GetPlayerMoney(player) < 200)
//                    {
//                        Main.DisplayErrorMessage(player, "error", "Üzerinizde yeterli miktarda para yok!");
//                        return;
//                    }

//                    Main.DisplayErrorMessage(player, "success", "Başarıyla 28 adet 'Pistol Mermisi' satın aldınız!");
//                    Main.GivePlayerMoney(player, -200);
//                    Main.GiveCompanyMoney(9, 20);
//                    Inventory.GiveItemToInventory(player, 6, 28);
//                    return;
//                case 4:

//                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 7, 1, Inventory.Max_Inventory_Weight(player)))
//                    {

//                        return;

//                    }

//                    if (Main.GetPlayerMoney(player) < 300)
//                    {
//                        Main.DisplayErrorMessage(player, "error", "Üzerinizde yeterli miktarda para yok!");
//                        return;
//                    }

//                    Main.DisplayErrorMessage(player, "success", "Başarıyla 120 adet 'SMG Mermisi' satın aldınız!");
//                    Main.GivePlayerMoney(player, -300);
//                    Main.GiveCompanyMoney(9, 30);
//                    Inventory.GiveItemToInventory(player, 7, 120);
//                    return;
//                case 5:

//                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 4, 1, Inventory.Max_Inventory_Weight(player)))
//                    {

//                        return;

//                    }

//                    if (Main.GetPlayerMoney(player) < 400)
//                    {
//                        Main.DisplayErrorMessage(player, "error", "Üzerinizde yeterli miktarda para yok!");
//                        return;
//                    }

//                    Main.DisplayErrorMessage(player, "success", "Başarıyla 120 adet 'Otomatik Tüfek Mermisi' satın aldınız!");
//                    Main.GivePlayerMoney(player, -400);
//                    Main.GiveCompanyMoney(9, 40);
//                    Inventory.GiveItemToInventory(player, 4, 120);
//                    return;
//                case 6:

//                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 5, 1, Inventory.Max_Inventory_Weight(player)))
//                    {

//                        return;

//                    }

//                    if (Main.GetPlayerMoney(player) < 500)
//                    {
//                        Main.DisplayErrorMessage(player, "error", "Üzerinizde yeterli miktarda para yok!");
//                        return;
//                    }

//                    Main.DisplayErrorMessage(player, "success", "Başarıyla 25 adet 'Pompalı Mermisi' satın aldınız!");
//                    Main.GivePlayerMoney(player, -500);
//                    Main.GiveCompanyMoney(9, 50);
//                    Inventory.GiveItemToInventory(player, 5, 25);
//                    return;
//                case 7:

//                    if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 3, 1, Inventory.Max_Inventory_Weight(player)))
//                    {
//                        return;
//                    }

//                    if (Main.GetPlayerMoney(player) < 600)
//                    {
//                        Main.DisplayErrorMessage(player, "error", "Üzerinizde yeterli miktarda para yok!");
//                        return;
//                    }

//                    Main.DisplayErrorMessage(player, "success", "Başarıyla 21 adet 'Keskin Nişancı Mermisi' satın aldınız!");
//                    Main.GivePlayerMoney(player, -600);
//                    Main.GiveCompanyMoney(9, 60);
//                    Inventory.GiveItemToInventory(player, 3, 21);
//                    return;
//            }


//        }
//        catch (Exception e) { Console.Write(e); }
//    }
//}