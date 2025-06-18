using GTANetworkAPI;
using System;
using MySql.Data.MySqlClient;

class Osiguranje : Script
{
    [ServerEvent(Event.ResourceStart)]
    public static void OnResourceStart()
    {
        API.Shared.CreateTextLabel(Main.LabelColor + "(( Sigorta Noktasi ))~n~" + Main.LabelCommandColor + "« E »", new Vector3(-83.47, 80.86, 71.55), 8.0f, 0.8f, 4, new Color(0, 122, 255, 150));
    }

    [RemoteEvent("InsuranceBuys")]
    public static void InsuranceBuys(Player player, int index)
    {
        try
        {
            if (player.GetData<dynamic>("status") == true)
            {
                if (player.VehicleSeat != 0)
                {
                    Notify.Send(player, "error", $"Sürücü koltuðunda olmalýsýnýz", 3000);
                    return;
                }
                if (player.Vehicle.GetData<dynamic>("Mashin_Owner") == AccountManage.GetPlayerSQLID(player))
                {
                    switch (index)
                    {
                        case 0:
                            {
                                if (Main.GetPlayerMoney(player) < 3000)
                                {
                                    Main.DisplayErrorMessage(player, "info", "Yeterli paranýz yok");
                                    return;
                                }
                                Main.DisplayErrorMessage(player, "success", "100 saatlik sigorta yaptýrdýnýz!");
                                Main.GivePlayerMoney(player, -3000);
                                Main.CreateMySqlCommand("UPDATE `vehicles` SET `veh_osiguranje` = 100 WHERE `id` = '" + player.Vehicle.GetData<int>("veh_sql") + "'");
                                break;
                            }
                        case 1:
                            {
                                if (Main.GetPlayerMoney(player) < 7000)
                                {
                                    Main.DisplayErrorMessage(player, "info", "Yeterli paranýz yok");
                                    return;
                                }
                                Main.DisplayErrorMessage(player, "success", "300 saatlik sigorta yaptýrdýnýz!");
                                Main.GivePlayerMoney(player, -7000);
                                Main.CreateMySqlCommand("UPDATE `vehicles` SET `veh_osiguranje` = 300 WHERE `id` = '" + player.Vehicle.GetData<int>("veh_sql") + "'");
                                break;
                            }
                        case 2:
                            {
                                if (Main.GetPlayerMoney(player) < 15000)
                                {
                                    Main.DisplayErrorMessage(player, "info", "Yeterli paranýz yok");
                                    return;
                                }
                                Main.DisplayErrorMessage(player, "success", "720 saatlik sigorta satýn yaptýrdýnýz!");
                                Main.GivePlayerMoney(player, -15000);
                                Main.CreateMySqlCommand("UPDATE `vehicles` SET `veh_osiguranje` = 720 WHERE `id` = '" + player.Vehicle.GetData<int>("veh_sql") + "'");
                                break;
                            }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
