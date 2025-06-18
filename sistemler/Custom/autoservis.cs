using GTANetworkAPI;
using System.Collections.Generic;
using System;

class autoservis : Script
{
    public static List<Vector3> carfix = new List<Vector3>()
    {
        new Vector3(732.5282, -1088.9098, 22.168987),
        new Vector3(-1154.8661, -2006.4633, 13.180249),
        new Vector3(110.84247, 6626.2925, 31.787214),
    };

    public autoservis()
    {
        foreach (var pos in carfix)
        {
            NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Arac Tamir Noktasi ))~n~~g~$500~n~" + Main.LabelCommandColor + "« E »", pos, 12, 0.3500f, 4, new Color(0, 122, 255, 150));


            Entity temp_blip;
            temp_blip = NAPI.Blip.CreateBlip(pos);
            NAPI.Blip.SetBlipName(temp_blip, "Araç Tamir Noktasý");
            NAPI.Blip.SetBlipSprite(temp_blip, 72);
            NAPI.Blip.SetBlipColor(temp_blip, 12);
            NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);
        }
    }

    public static void keypresse(Player client)
    {
        foreach (var v in carfix)
        {
            if (Main.IsInRangeOfPoint(client.Position, v, 5))
            {
                if (client.IsInVehicle)
                {
                    if (Main.GetPlayerMoney(client) < 500)
                    {
                        Main.DisplayErrorMessage(client, "error", "Yeterli paranýz yok!");
                        return;
                    }

                    Main.SendServerMessage(client, "6 saniye sonra tamirden ayrýlacaksýnýz.");
                    Main.DisplaySubtitle(client, "ARAC TAMIR EDILIYOR...", 6);
                    client.TriggerEvent("freeze", true);
                    client.TriggerEvent("freezeEx", true);
                    NAPI.Task.Run(() =>
                    {
                        if (NAPI.Player.IsPlayerConnected(client))
                        {
                            if (!client.IsInVehicle) return;
                            Vehicle veh = client.Vehicle;
                            if (!veh.Exists) return;
                            veh.Repair();
                            Main.GivePlayerMoney(client, -500);
                            Main.GiveCompanyMoney(8, 500);
                            client.TriggerEvent("Hide_Crafting_System");
                            Main.DisplaySubtitle(client, "ARAC BASARIYLA TAMIR EDILDI!", 1);
                            client.TriggerEvent("freeze", false);
                            client.TriggerEvent("freezeEx", false);
                        }
                    }, delayTime: 6000);

                }
                else
                {
                    return;
                }
            }
        }
    }
}
