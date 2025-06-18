using GTANetworkAPI;
using System;
using System.Collections.Generic;
//autoskolaa
public class EhliyetKursu : Script
{

    private static List<Vector3> Checkpoints = new List<Vector3>()
    {
        new Vector3(-610.79865, -2271.0083, 5.9482813),
        new Vector3(-506.638, -2149.9526, 8.982431),
        new Vector3(-278.1685, -2188.5344, 10.309659),
        new Vector3(7.103925, -2081.7866, 10.261352),
        new Vector3(-240.62085, -1844.7511, 29.12345),
        new Vector3(-359.2044, -1820.4208, 22.795097),
        new Vector3(-781.7449, -2199.168, 16.45727),
        new Vector3(-1078.8828, -2622.8972, 13.817429),
        new Vector3(-846.8897, -2584.8281, 13.815342),
        new Vector3(-613.73425, -2280.5994, 5.936411),
    };

    [RemoteEvent("server:EhliyetSecildi")]
    public void EhliyetSecildi(Player Client, bool status, int index)
    {
        if (status == true)
        {
            // 0 = araç ehliyet
            // 1 = motor ehliyet
            try
            {
                switch (index)
                {
                    case 0:
                        {
                            if (Main.GetPlayerMoney(Client) < 500)
                            {
                                Main.SendErrorMessage(Client, "Üzerinizde yeterli miktarda para yok.");
                                return;
                            }

                            if (Client.GetData<dynamic>("character_car_lic") > 10)
                            {
                                Main.SendErrorMessage(Client, "Zaten Sürücü ehliyetine sahipsin.");
                                return;
                            }

                            Client.TriggerEvent("client:EhliyetKapat");
                            AracSinavBasla(Client);
                            Main.SendServerMessage(Client, "Baþarýyla Sürücü ehliyeti için test sürüþüne baþladýnýz.");
                            Main.SendServerMessage(Client, "Kapýnýn önündeki araca binip motoru çalýþtýrdýktan sonra Waypoint'leri takip ederek ilerleyebilirsiniz.");
                            Main.GivePlayerMoney(Client, -500);
                            break;
                        }
                    case 1:
                        {
                            if (Main.GetPlayerMoney(Client) < 250)
                            {
                                Main.SendErrorMessage(Client, "Üzerinizde yeterli miktarda para yok.");
                                return;
                            }

                            if (Client.GetData<dynamic>("character_motor_lic") > 10)
                            {
                                Main.SendErrorMessage(Client, "Zaten Motorsiklet ehliyetine sahipsin.");
                                return;
                            }

                            Client.TriggerEvent("client:EhliyetKapat");
                            MotorSinavBasla(Client);
                            Main.SendServerMessage(Client, "Baþarýyla Motorsiklet ehliyeti için test sürüþüne baþladýnýz.");
                            Main.SendServerMessage(Client, "Kapýnýn önündeki araca binip motoru çalýþtýrdýktan sonra Waypoint'leri takip ederek ilerleyebilirsiniz.");
                            Main.GivePlayerMoney(Client, -250);
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

    public void AracSinavBasla(Player c)
    {
        var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(132.24, -1462.01, 28.35), 1, 2, 0);
        col.OnEntityEnterColShape += (shape, c) => {
            try
            {
                c.SetData("INTERACTIONCHECK", 8);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        };
        col.OnEntityExitColShape += (shape, c) => {
            try
            {
                c.SetData("INTERACTIONCHECK", 0);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        };

        string playername = AccountManage.GetCharacterName(c);
        string vehName = "premier";
        VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
        Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(-628.31, -2270.97, 5.95), new Vector3(0, 0, -140), 27, 111, "as"+playername, 255, false, true, 0);
        Main.SetVehicleFuel(vehicle, 100.0);
        for (int i = 0; i < Checkpoints.Count; i++)
        {
            var colshape = NAPI.ColShape.CreateCylinderColShape(Checkpoints[i], 4, 5, 0);
            colshape.OnEntityEnterColShape += PlayerEnterCheckpoint;
            colshape.SetData("LMNUMBER", i);
        }
        c.TriggerEvent("createCheckpoint", 12, 1, Checkpoints[0]  - new Vector3(0, 0, 2), 4, 0, 221, 255, 0);
        c.TriggerEvent("createWaypoint", Checkpoints[0].X, Checkpoints[0].Y);
        c.SetData("lmpoint", 0);
    }


    private static void PlayerEnterCheckpoint(ColShape shape, Player c)
    {
        try
        {

            if (shape.GetData<int>("LMNUMBER") != c.GetData<int>("lmpoint")) return;
                var lmpoint = c.GetData<int>("lmpoint");
                if (lmpoint == Checkpoints.Count - 1)
                {
                    Vehicle veh = c.Vehicle;
                    string playername = AccountManage.GetCharacterName(c);
                    if (c.IsInVehicle && veh.NumberPlate == "as"+playername)
                    {
                        NAPI.Entity.DeleteEntity(c.Vehicle);
                        c.TriggerEvent("deleteCheckpoint", 12, 0);
                        c.SetData<dynamic>("character_car_lic", 720);
                        Main.SendSuccessMessage(c, "Ehliyet sýnavýný baþarýyla tamamladýnýz ve Sürücü ehliyeti aldýnýz.");
                        Main.SavePlayerInformation(c);
                        return;
                    }
                    else
                    {
                        return;
                    }
                        
                }
                c.SetData("lmpoint", lmpoint + 1);
                     

                    if (lmpoint + 2 < Checkpoints.Count)
                        c.TriggerEvent("createCheckpoint", 12, 1, Checkpoints[lmpoint + 1] - new Vector3(0, 0, 2), 4, 0, 255, 255, 255, Checkpoints[lmpoint + 2] - new Vector3(0, 0, 1.12));
                    else
                        c.TriggerEvent("createCheckpoint", 12, 1, Checkpoints[lmpoint + 1] - new Vector3(0, 0, 2), 4, 0, 221, 255, 0);
                    c.TriggerEvent("createWaypoint", Checkpoints[lmpoint + 1].X, Checkpoints[lmpoint + 1].Y);

        } catch (Exception e) { Console.WriteLine(e); }
    }

    public void MotorSinavBasla(Player c)
    {
        var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(132.24, -1462.01, 28.35), 1, 2, 0);
        col.OnEntityEnterColShape += (shape, c) => {
            try
            {
                c.SetData("INTERACTIONCHECK", 8);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        };
        col.OnEntityExitColShape += (shape, c) => {
            try
            {
                c.SetData("INTERACTIONCHECK", 0);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        };

        string playername = AccountManage.GetCharacterName(c);
        string vehName = "enduro";
        VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
        Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(-628.31, -2270.97, 5.95), new Vector3(0, 0, -140), 27, 111, "as" + playername, 255, false, true, 0);
        Main.SetVehicleFuel(vehicle, 100.0);
        for (int i = 0; i < Checkpoints.Count; i++)
        {
            var colshape = NAPI.ColShape.CreateCylinderColShape(Checkpoints[i], 4, 5, 0);
            colshape.OnEntityEnterColShape += PlayerEnterCheckpointMotor;
            colshape.SetData("LMNUMBER", i);
        }
        c.TriggerEvent("createCheckpoint", 12, 1, Checkpoints[0] - new Vector3(0, 0, 2), 4, 0, 221, 255, 0);
        c.TriggerEvent("createWaypoint", Checkpoints[0].X, Checkpoints[0].Y);
        c.SetData("lmpoint", 0);
    }

    private static void PlayerEnterCheckpointMotor(ColShape shape, Player c)
    {
        try
        {

            if (shape.GetData<int>("LMNUMBER") != c.GetData<int>("lmpoint")) return;
            var lmpoint = c.GetData<int>("lmpoint");
            if (lmpoint == Checkpoints.Count - 1)
            {
                Vehicle veh = c.Vehicle;
                string playername = AccountManage.GetCharacterName(c);
                if (c.IsInVehicle && veh.NumberPlate == "as" + playername)
                {
                    NAPI.Entity.DeleteEntity(c.Vehicle);
                    c.TriggerEvent("deleteCheckpoint", 12, 0);
                    c.SetData<dynamic>("character_moto_lic", 720);
                    Main.SendSuccessMessage(c, "Ehliyet sýnavýný baþarýyla tamamladýnýz ve Motor ehliyeti aldýnýz.");
                    Main.SavePlayerInformation(c);
                    return;
                }
                else
                {
                    return;
                }

            }
            c.SetData("lmpoint", lmpoint + 1);


            if (lmpoint + 2 < Checkpoints.Count)
                c.TriggerEvent("createCheckpoint", 12, 1, Checkpoints[lmpoint + 1] - new Vector3(0, 0, 2), 4, 0, 255, 255, 255, Checkpoints[lmpoint + 2] - new Vector3(0, 0, 1.12));
            else
                c.TriggerEvent("createCheckpoint", 12, 1, Checkpoints[lmpoint + 1] - new Vector3(0, 0, 2), 4, 0, 221, 255, 0);
            c.TriggerEvent("createWaypoint", Checkpoints[lmpoint + 1].X, Checkpoints[lmpoint + 1].Y);

        }
        catch (Exception e) { Console.WriteLine(e); }
    }

    [ServerEvent(Event.PlayerDisconnected)]
    public static void onPlayerDissconnectedHandler(Player player, DisconnectionType type, string reason)
    {
        try
        {
            string playername = AccountManage.GetCharacterName(player);
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "as"+playername)
                {
                    veh.Delete();
                }
            }
        }
        catch (Exception e) { Console.Write(e);}
    }
    
}