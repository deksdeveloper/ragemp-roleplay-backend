using GTANetworkAPI;
using System;
using System.Collections.Generic;

class barstoress : Script
{

    [RemoteEvent("barstores")]
    public static void barstores(Player Client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        if (Main.GetPlayerMoney(Client) < 30)
                        {
                            Main.DisplayErrorMessage(Client, "info", "Yeterli miktarda paranýz yok.");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 1, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }



                        Main.GivePlayerMoney(Client, -30);
                        Main.DisplayErrorMessage(Client, "success", "Baþarýyla 1 adet 'Su' satýn aldýnýz!");
                        Inventory.GiveItemToInventory(Client, 1, 1);
                        break;
                    }
                case 1:
                    {
                        if (Main.GetPlayerMoney(Client) < 50)
                        {
                            Main.DisplayErrorMessage(Client, "info", "Yeterli miktarda paranýz yok.");
                            return;

                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 68, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }


                        Main.GivePlayerMoney(Client, -50);
                        Main.DisplayErrorMessage(Client, "success", "Baþarýyla 1 adet 'Bira' satýn aldýnýz!");
                        Inventory.GiveItemToInventory(Client, 68, 1);
                        break;
                    }
                case 2:
                    {
                        if (Main.GetPlayerMoney(Client) < 80)
                        {
                            Main.DisplayErrorMessage(Client, "info", "Yeterli miktarda paranýz yok.");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 69, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }


                        Main.GivePlayerMoney(Client, -80);
                        Main.DisplayErrorMessage(Client, "success", "Baþarýyla 1 adet 'Konyak' satýn aldýnýz!");
                        Inventory.GiveItemToInventory(Client, 69, 1);
                        break;
                    }
                case 3:
                    {
                        if (Main.GetPlayerMoney(Client) < 100)
                        {
                            Main.DisplayErrorMessage(Client, "info", "Yeterli miktarda paranýz yok.");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 70, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -100);
                        Main.DisplayErrorMessage(Client, "success", "Baþarýyla 1 adet 'Viski' satýn aldýnýz!");
                        Inventory.GiveItemToInventory(Client, 70, 1);
                        break;
                    }
                case 4:
                    {
                        if (Main.GetPlayerMoney(Client) < 100)
                        {
                            Main.DisplayErrorMessage(Client, "info", "Yeterli miktarda paranýz yok.");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 71, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -100);
                        Main.DisplayErrorMessage(Client, "success", "Baþarýyla 1 adet 'Votka' satýn aldýnýz!");
                        Inventory.GiveItemToInventory(Client, 71, 1);
                        break;
                    }
                case 5:
                    {
                        if (Main.GetPlayerMoney(Client) < 300)
                        {
                            Main.DisplayErrorMessage(Client, "info", "Yeterli miktarda paranýz yok.");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 72, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        Main.GivePlayerMoney(Client, -300);
                        Main.DisplayErrorMessage(Client, "success", "Baþarýyla 1 adet 'Þampanya' satýn aldýnýz!");
                        Inventory.GiveItemToInventory(Client, 72, 1);
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