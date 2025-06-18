using GTANetworkAPI;
using System;
using MySql.Data.MySqlClient;
class Challange : Script
{

    public string name { get; set; }
    public double btime { get; set; }

    public double novovreme = 0;
    public TextLabel TehBest { get; set; }

    [ServerEvent(Event.ResourceStart)]
    public void OnResourceStart()
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandText = ("SELECT * FROM challange");
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    name = reader.GetString("name");
                    btime = reader.GetDouble("time");
                    TextLabelUpdate();
                }
            }
            Mainpipeline.Close();
        }
        NAPI.TextLabel.CreateTextLabel("Route 68~n~~w~[~g~ /challenge (/yaris) ~w~]", new Vector3(-2866.03, 2196.28, 34.15), 12, 0.3500f, 4, new Color(0, 122, 255, 150));

    }

    public void TextLabelUpdate()
    {
        TehBest = NAPI.TextLabel.CreateTextLabel("Route 68~n~~w~~g~ Sýra 1: ~n~~w~" + name + "~n~~w~" + btime + " sn ~w~", new Vector3(1994.73, 3053.47, 47.21), 12, 0.3500f, 4, new Color(0, 122, 255, 150));
    }

    [Command("challenge", Alias = "yaris")]
    public void ChallangeEvent(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-2866.03, 2196.28, 34.15), 5) && Client.IsInVehicle)
        {
            DateTime startTime = DateTime.Now;
            Trigger.ClientEvent(Client, "createCheckpoint", 15, 1, new Vector3(1974.21, 2979.87, 45.07), 8, 0, 221, 255, 0);
            Client.TriggerEvent("createWaypoint", 1974.21, 2979.87);
            Client.SendChatMessage("Yarýþ baþlatýldý! ~r~HAREKETE GEÇ!");

            System.Timers.Timer checkpointTimer = new System.Timers.Timer(300);
            checkpointTimer.Elapsed += (sender, e) =>
            {
                TimeSpan elapsed = DateTime.Now - startTime;
                if (elapsed.TotalSeconds >= 120)
                {
                    checkpointTimer.Stop();
                    checkpointTimer.Dispose();
                    Trigger.ClientEvent(Client, "deleteCheckpoint", 15, 0);
                    Client.SendChatMessage("Süre doldu, yarýþ sona erdi.");
                }
                else
                {
                    if (Main.IsInRangeOfPoint(Client.Position, new Vector3(1974.21, 2979.87, 45.77), 35))
                    {
                        checkpointTimer.Stop();
                        checkpointTimer.Dispose();
                        double elapsedSeconds = Math.Round(elapsed.TotalSeconds, 2);
                        Trigger.ClientEvent(Client, "deleteCheckpoint", 15, 0);
                        Client.SendChatMessage("Baþarýyla tamamlanan süre ~r~: " + elapsedSeconds + " ~w~saniye.");
                        novovreme = elapsedSeconds;
                        UpdateBestTime(Client);
                        if (Client.GetData<dynamic>("zadatak6") == true)
                        {
                            Client.SetData("zadatak6", false);
                            Main.GivePlayerEXP(Client, 300);
                            Main.GivePlayerMoney(Client, 3000);
                            Main.DisplayErrorMessage(Client, "success", "Günlük görevinizi tamamladýnýz.");
                        }
                    }
                }
            };
            checkpointTimer.Start();
        }
    }
    public void UpdateBestTime(Player Client)
    {
        double btime = 0;
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandText = ("SELECT * FROM challange");
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    btime = reader.GetDouble("time");
                    name = reader.GetString("name");
                }
            }
            Mainpipeline.Close();
        } 
        if (novovreme < btime)
        {
            Client.SetData("thevreme", novovreme);
            Main.CreateMySqlCommand("UPDATE `challange` SET `name` = '" + AccountManage.GetCharacterName(Client) + "', `time` = " + Client.GetData<double>("thevreme").ToString().Replace(",", ".") + ";");
            NAPI.Task.Run(() =>
            {
                TehBest.Delete();
                TehBest = NAPI.TextLabel.CreateTextLabel("Route 68~n~~w~~g~ Sýra 1: ~n~~w~" + AccountManage.GetCharacterName(Client) + "~n~~w~" + Client.GetData<dynamic>("thevreme") + " saniye ~w~", new Vector3(1994.73, 3053.47, 47.21), 12, 0.3500f, 4, new Color(0, 122, 255, 150));
            });
        }
    }
}