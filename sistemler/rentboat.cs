using GTANetworkAPI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using MySql.Data.MySqlClient;

    public class bRent : Script
    {
        public static List<Vector3> rentpos = new List<Vector3>()
        {
            new Vector3(-712.58, -1298.56, 5.10),
        };

        public bRent()
        {
            foreach (var pos in rentpos)
            {
                NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Tekne Kiralama Noktasi ))~n~" + Main.LabelCommandColor + "« Y »", pos, 12, 0.3500f, 4, new Color(0, 122, 255, 150));

                
                Entity temp_blip;
                temp_blip = NAPI.Blip.CreateBlip(pos);
                NAPI.Blip.SetBlipName(temp_blip, "Tekne Kiralama");
                NAPI.Blip.SetBlipSprite(temp_blip, 404);
                NAPI.Blip.SetBlipColor(temp_blip, 9);
                NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
                NAPI.Blip.SetBlipShortRange(temp_blip, true);
            }

        }

        [RemoteEvent("bRentveh")]
        public static void bRentveh(Player Client, int index)
        {
            try
            {

                switch (index)
                {
                    case 0:
                        {


                                if (Client.GetData<dynamic>("rented") == true)
                                {
                                    Main.DisplayErrorMessage(Client, "error", "Zaten kiraladýðýnýz bir araç var, kirayý iptal etmek için /unrent");
                                    return;
                                }
                                string playername = AccountManage.GetCharacterName(Client);
                                string vehName = "dinghy";
                                VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
                                Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(-725.84, -1327.87, 0.00), new Vector3(0.00, 0.00, -133.63), 92, 111, "rt" + playername, 255, false, true, 0);
                                Main.SetVehicleFuel(vehicle, 100.0);
                                Client.SetData("rented", true);
                                bRentCost(Client);
                                Main.DisplayErrorMessage(Client, "success", "Araç kiraladýnýz, kira ücreti her dakika için $100. Kirayý iptal etmek için /unrent");



                        break;
                        }
                    case 1:
                        {
                            
                                
                                    if (Client.GetData<dynamic>("rented") == true)
                                    {
                                        Main.DisplayErrorMessage(Client, "error", "Zaten kiraladýðýnýz bir araç var, kirayý iptal etmek için /unrent");
                                        return;
                                    }
                                    string playername = AccountManage.GetCharacterName(Client);
                                    string vehName = "seashark";
                                    VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
                                    Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(-725.84, -1327.87, 0.00), new Vector3(0.00, 0.00, -133.63), 92, 111, "rt"+playername, 255, false, true, 0);
                                    Main.SetVehicleFuel(vehicle, 100.0);
                                    Client.SetData("rented", true);
                                    bRentCost(Client);
                                    Main.DisplayErrorMessage(Client, "success", "Araç kiraladýnýz, kira ücreti her dakika için $100. Kirayý iptal etmek için /unrent");
                                
                            
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void bRentCost(Player c)
        {
            if(c.GetData<dynamic>("rented") == false)
            {
                return;
            }
            if(c.GetData<dynamic>("rented") == true)
            {
                int price = 500;
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(c))
                    {

                        if (Main.GetPlayerMoney(c) < price)
                        {
                            Main.DisplayErrorMessage(c, "info", "Kiranýzý devam ettirmek için yeterli paranýz yok");
                            Rent.CMDunrent(c);
                            return;
                        }
                        Main.GivePlayerMoney(c, -price);
                        Main.SendErrorMessage(c, "Kiralýk aracýnýzýn kirasýný iptal etmediðiniz için tekrardan banka hesabýnýzdan ~r~500$ ~w~ kesildi.");
                        bRentCost(c);
                    }

                }, delayTime: 60000);
            }
        }

    }
