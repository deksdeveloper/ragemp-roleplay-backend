using GTANetworkAPI;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class Rent : Script
{
    public static List<Vector3> rentpos = new List<Vector3>()
    {
        new Vector3(-200.74, 6226.99, 31.49),
        new Vector3(1980.26, 3780.17, 32.18),
        new Vector3(1810.20, 4591.45, 36.96),
        new Vector3(-1016.0152, -2695.0583, 13.977075),
        new Vector3(-0.3819425, -1718.8488, 29.296698),
        new Vector3(-693.74854, -1102.0911, 14.5253105),
        new Vector3(216.60117, -809.9229, 30.715343),
        new Vector3(-341.12708, 269.4189, 85.583565),
        new Vector3(-1531.7198, -429.00357, 35.4422),
        new Vector3(-3249.5876, 987.63904, 12.4858265),
    };

    public Rent()
    {
        foreach (var pos in rentpos)
        {
            NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Arac Kiralama Noktasi ))~n~" + Main.LabelCommandColor + "« Y »", pos, 12, 0.3500f, 4, new Color(0, 122, 255, 150));

            Entity temp_blip = NAPI.Blip.CreateBlip(pos);
            NAPI.Blip.SetBlipName(temp_blip, "Araç Kiralama Noktası");
            NAPI.Blip.SetBlipSprite(temp_blip, 739);
            NAPI.Blip.SetBlipColor(temp_blip, 24);
            NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);
        }
    }

    public static void triggerrent(Player client)
    {
        if (client.IsInVehicle) return;

        foreach (var v in rentpos)
        {
            if (Main.IsInRangeOfPoint(client.Position, v, 5))
            {
                client.TriggerEvent("Display_rent");
            }
        }
    }

    [RemoteEvent("rentveh")]
    public static void rentveh(Player Client, int index)
    {
        try
        {
            if (Client.GetData<dynamic>("rented") == true)
            {
                Main.SendErrorMessage(Client, "Zaten kiralık bir aracınız var, kirayı iptal etmek için '/arackiraiptal' komutunu kullanabilirsiniz.");
                return;
            }

            string playername = AccountManage.GetCharacterName(Client);
            string vehName = index == 0 ? "faggio" : "dilettante";
            VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
            Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, Client.Position + new Vector3(2f, 0, 0), Client.Rotation, 92, 111, "KA" + playername, 255, false, true, 0);

            Main.SetVehicleFuel(vehicle, 100.0);
            Client.SetData("rented", true);
            RentCost(Client);
            Main.SendSuccessMessage(Client, "Araç başarıyla kiralandı. Her dakika banka hesabınızdan kiralama bedeli olarak $50 eksilecek.");
            Main.SendSuccessMessage(Client, "Kiralamayı iptal etmek isterseniz '/arackiraiptal' komutunu kullanabilirsiniz.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static void RentCost(Player c)
    {
        if (c.GetData<dynamic>("rented") == false) return;

        int price = 50;
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(c))
            {
                if (c.GetData<dynamic>("rented") == false) return;

                if (Main.GetPlayerBank(c) < price)
                {
                    Main.SendErrorMessage(c, "Kira bedelini karşılayamadığınız için otomatik olarak araç iade edildi.");
                    CMDunrent(c);
                    return;
                }
                Main.GivePlayerMoneyBank(c, -price);
                Main.SendErrorMessage(c, "Araç kiralama bedeli olarak banka hesabınızdan $50 eksildi.");
                RentCost(c);
            }
        }, delayTime: 60000);
    }

    [Command("arackiraiptal")]
    public static void CMDunrent(Player client)
    {
        if (client.GetData<dynamic>("rented") == true)
        {
            client.SetData<dynamic>("rented", false);
            string playername = AccountManage.GetCharacterName(client);

            Main.SendSuccessMessage(client, "Başarıyla araç kiralaması iptal edildi.");
            Main.GiveCompanyMoney(5, 30);

            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "KA" + playername)
                {
                    veh.Delete();
                }
            }
        }
    }

    [ServerEvent(Event.PlayerDisconnected)]
    public static void onPlayerDissconnectedHandler(Player player, DisconnectionType type, string reason)
    {
        try
        {
            string playername = AccountManage.GetCharacterName(player);
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "KA" + playername)
                {
                    veh.Delete();
                    player.SetData<dynamic>("rented", false);
                }
            }
        }
        catch (Exception e)
        {
            Console.Write(e);
        }
    }
}
