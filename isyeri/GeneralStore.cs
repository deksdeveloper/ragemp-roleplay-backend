using GTANetworkAPI;
using Infinity.meslekler;
using System;
using System.Collections.Generic;

class GeneralStore : Script
{

    public static List<dynamic> genstore = new List<dynamic>();



    public GeneralStore()
    {

        genstore.Add(new { MarkerType = 1, position = new Vector3(26.420563, -1347.0519, 29.497025) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-48.55561, -1757.1757, 29.421017) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(1136.3129, -982.0838, 46.415848) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(1162.8124, -323.28806, 69.20513) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(374.5595, 326.85794, 103.56638) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-1223.4705, -906.55646, 12.326346) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-1821.3231, 792.39044, 138.12675) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(1961.7357, 3741.7756, 32.343746) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(1698.8347, 4925.0225, 42.06367) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(1729.6604, 6414.641, 35.03723) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(1392.1151, 3603.983, 34.980927) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-1487.665, -379.17163, 40.16343) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-2968.4546, 390.9022, 15.043314) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-3040.2012, 586.15967, 7.9089293) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-3242.5671, 1001.9007, 12.830707) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(2678.9248, 3281.3389, 55.24113) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(2556.5107, 382.7558, 108.62295) });
        foreach (var atm in genstore)
        {
            NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( 24/7 Market ))~n~" + Main.LabelCommandColor + "« Y »", atm.position, 16, 0.600f, 0, new Color(0, 122, 255, 150));

            Entity temp_blip;
            temp_blip = NAPI.Blip.CreateBlip(atm.position);
            NAPI.Blip.SetBlipName(temp_blip, "24/7 Market");
            NAPI.Blip.SetBlipSprite(temp_blip, 628);
            NAPI.Blip.SetBlipColor(temp_blip, 25);
            NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);
        }
    }

    public static void SatinAl(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(127.92, -1284.73, 29.27), 3) || Main.IsInRangeOfPoint(Client.Position, new Vector3(-1391.67, -604.96, 30.50), 5) || Main.IsInRangeOfPoint(Client.Position, new Vector3(-562.03, 286.69, 82.20), 3) || Main.IsInRangeOfPoint(Client.Position, new Vector3(1110.46, 208.35, -49.44), 4) || Main.IsInRangeOfPoint(Client.Position, new Vector3(1984.77, 3052.18, 47.97), 4))
        {
            Client.TriggerEvent("Display_bars");
            return;
        }
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-57.31, -1096.82, 26.42), 5))
        {
            Client.TriggerEvent("Display_carshop");
            return;
        }
        foreach (var kiyafetcxi in newCloth.kiyafetci)
        {
            if (Main.IsInRangeOfPoint(Client.Position, kiyafetcxi.Position, 3.0f))
            {
                Client.Rotation = new Vector3(0, 0, kiyafetcxi.Rotation);
                if ((int)NAPI.Data.GetEntitySharedData(Client, "CHARACTER_ONLINE_GENRE") == 1)
                {

                    newCloth.ShowClothesMainMenu(Client);
                    return;
                }
                else
                {
                    newCloth.ShowClothesMainMenu(Client);
                    return;
                }
            }
        }

        foreach (var berberciler in Barber.berberci)
        {
            if (Main.IsInRangeOfPoint(Client.Position, berberciler.Position, 3.0f))
            {
                Client.Rotation = new Vector3(0, 0, berberciler.Rotation);
                Barber.DisplayMenu(Client);
                return;
            }
        }
        foreach (var gsm in genstore)
        {
            if (Main.IsInRangeOfPoint(Client.Position, gsm.position, 3.0f))
            {
                Client.TriggerEvent("Display_sevenstore");
                return;
            }
        }

        int business_id = 0;

        foreach (var business in BusinessManage.business_list)
        {


            if (Main.IsInRangeOfPoint(Client.Position, business.business_barber, 3))
            {
                if (business.business_Lock)
                {
                    Main.DisplayErrorMessage(Client, "error", "Bu iş yeri kilitli!");
                    return;
                }
                else if (business.business_Type == 12)
                {
                    TattoBusiness.ShowTattoo(Client);
                    return;
                }
            }
            business_id++;

        }
    }

    [RemoteEvent("fourseven")]
    public static void fourseven(Player Client, int index)
    {
        try
        {

            switch (index)
            {

                case 0:
                    {
                        if (Main.GetPlayerMoney(Client) < 25)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 1, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -25);
                        Main.GiveCompanyMoney(7, 2);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Su' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, 1, 1);
                        break;
                    }
                case 1:
                    {
                        if (Main.GetPlayerMoney(Client) < 30)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 2, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -30);
                        Main.GiveCompanyMoney(7, 3);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Burger' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, 2, 1);
                        break;
                    }
                case 2:
                    {
                        if (Main.GetPlayerMoney(Client) < 1000)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (TelefonSistem.GetPlayerNumber(Client) != 0)
                        {
                            Main.SendErrorMessage(Client, "Zaten bir telefonunuz var.");
                            break;
                        }

                        Main.GivePlayerMoney(Client, -1000);
                        Main.GiveCompanyMoney(7, 100);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Telefon' satın aldınız!");
                        TelefonSistem.NewNumber(Client);
                        break;
                    }
                case 3:
                    {
                        if (Main.GetPlayerMoney(Client) < 100)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 21, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -100);
                        Main.GiveCompanyMoney(7, 10);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Benzin Bidonu' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, 21, 1);
                        break;
                    }
                case 4:
                    {
                        if (Main.GetPlayerMoney(Client) < 150)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 23, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -150);
                        Main.GiveCompanyMoney(7, 15);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Radyo' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, 23, 1);
                        break;
                    }
                case 5:
                    {
                        if (Main.GetPlayerMoney(Client) < 50)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 25, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -50);
                        Main.GiveCompanyMoney(7, 5);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Plastik Kelepçe' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, 25, 1);
                        break;
                    }
                case 7:
                    {
                        if (Main.GetPlayerMoney(Client) < 500)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 73, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -500);
                        Main.GiveCompanyMoney(7, 50);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Levye' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, 77, 1);
                        break;
                    }
                case 8:
                    {
                        if (Main.GetPlayerMoney(Client) < 5)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.YEM_EKMEK, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -5);
                        Main.GiveCompanyMoney(7, 5);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Ekmek' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.YEM_EKMEK, 1);
                        break;
                    }
                case 9:
                    {
                        if (Main.GetPlayerMoney(Client) < 11)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.YEM_KURT, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -11);
                        Main.GiveCompanyMoney(7, 11);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Kurt' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.YEM_KURT, 1);
                        break;
                    }
                case 10:
                    {
                        if (Main.GetPlayerMoney(Client) < 19)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.YEM_SOLUCAN, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -19);
                        Main.GiveCompanyMoney(7, 19);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Solucan' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.YEM_SOLUCAN, 1);
                        break;
                    }
                case 11:
                    {
                        if (Main.GetPlayerMoney(Client) < 30)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.YEM_BALIKPARCASI, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -30);
                        Main.GiveCompanyMoney(7, 30);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Solucan' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.YEM_BALIKPARCASI, 1);
                        break;
                    }
                case 12:
                    {
                        if (Main.GetPlayerMoney(Client) < 300)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.OLTA_DEFAULT, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -300);
                        Main.GiveCompanyMoney(7, 300);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Olta' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.OLTA_DEFAULT, 1);
                        break;
                    }
                case 13:
                    {
                        if (Main.GetPlayerMoney(Client) < 600)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.OLTA_KUCUK, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -600);
                        Main.GiveCompanyMoney(7, 600);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Olta (Küçük)' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.OLTA_KUCUK, 1);
                        break;
                    }
                case 14:
                    {
                        if (Main.GetPlayerMoney(Client) < 800)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.OLTA_ORTA, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -800);
                        Main.GiveCompanyMoney(7, 800);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Olta (Orta)' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.OLTA_ORTA, 1);
                        break;
                    }
                case 15:
                    {
                        if (Main.GetPlayerMoney(Client) < 1100)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.OLTA_BUYUK, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -1100);
                        Main.GiveCompanyMoney(7, 1100);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Olta (Büyük)' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.OLTA_BUYUK, 1);
                        break;
                    }
                case 16:
                    {
                        if (Main.GetPlayerMoney(Client) < 40)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.YEM_KARIDES, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -40);
                        Main.GiveCompanyMoney(7, 40);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Karides' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.YEM_KARIDES, 1);
                        break;
                    }
                case 17:
                    {
                        if (Main.GetPlayerMoney(Client) < 50)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.YEM_RAPALA, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -50);
                        Main.GiveCompanyMoney(7, 50);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Rapala' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.YEM_RAPALA, 1);
                        break;
                    }
                case 18:
                    {
                        if (Main.GetPlayerMoney(Client) < 60)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.YEM_JIG, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -60);
                        Main.GiveCompanyMoney(7, 60);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Jig' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.YEM_JIG, 1);
                        break;
                    }
                case 19:
                    {
                        if (Main.GetPlayerMoney(Client) < 70)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.YEM_KALAMAR, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -70);
                        Main.GiveCompanyMoney(7, 70);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Kalamar' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.YEM_KALAMAR, 1);
                        break;
                    }
                case 20:
                    {
                        if (Main.GetPlayerMoney(Client) < 80)
                        {
                            Main.DisplayErrorMessage(Client, "error", "Yeterli miktarda paranız yok!");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Balikcilik.YEM_SAHTEKALAMAR, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -80);
                        Main.GiveCompanyMoney(7, 80);
                        Main.DisplayErrorMessage(Client, "success", "Başarıyla 1 adet 'Sahte Kalamar' satın aldınız!");
                        Inventory.GiveItemToInventory(Client, Balikcilik.YEM_SAHTEKALAMAR, 1);
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

}