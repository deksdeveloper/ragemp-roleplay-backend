using GTANetworkAPI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using MySql.Data.MySqlClient;

public class arcadius : Script
{

    [ServerEvent(Event.ResourceStart)]
    public static void OnRentStart()
    {
        NAPI.TextLabel.CreateTextLabel("Şirket~n~Para Çek ~n~ ~g~", new Vector3(-128.13, -641.90, 168.72 + 0.3), 12, 0.1200f, 0, new Color(0, 122, 255, 150), false, 0);
    }

    public static void keypressE(Player client)
    {
        if (Main.IsInRangeOfPoint(client.Position, new Vector3(-117.26, -604.52, 36.28), 3.0f))
        {
            client.Position = new Vector3(-140.38, -621.02, 168.82);
            return;
        }
        if (Main.IsInRangeOfPoint(client.Position, new Vector3(-140.38, -621.02, 168.82), 3.0f) && client.Dimension == 0)
        {
            client.Position = new Vector3(-117.26, -604.52, 36.28);
            return;
        }
    }

    public static void keypressY(Player client)
    {
        if (client.Dimension != 0) return;
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandText = ("SELECT `money` FROM `companies` WHERE `owner` = '" + client.GetData<dynamic>("character_sqlid") + "';");
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                if (reader.Read())
                {
                    int money = reader.GetInt32("money");
                    client.SetData("bizmoney", money);
                }
                else
                {
                    Main.SendErrorMessage(client, "Şirketiniz yok.");
                    return;
                }
            }
            Mainpipeline.Close();
        }
        int totmoney = client.GetData<dynamic>("bizmoney");
        //client.TriggerEvent("UpdateBusinessBalance", totmoney);
        client.TriggerEvent("Display_newbbank", totmoney);

        return;
    }

    [RemoteEvent("bBankWithdrawMoney")]
    public static void bBankWithdrawMoney(Player Client, int amount)
    {
        int value = Convert.ToInt32(amount);

        if (value < 1 || value > 1000000)
        {
            Main.SendErrorMessage(Client, "Miktar 1 ile 1,000,000 arasında olmalıdır.");
            return;
        }
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandText = ("SELECT `money` FROM `companies` WHERE `owner` = '" + Client.GetData<dynamic>("character_sqlid") + "';");
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                if (reader.Read())
                {
                    int money = reader.GetInt32("money");
                    Client.SetData("bizmoney", money);
                }
                else
                {
                    Main.DisplayErrorMessage(Client, "error", "Şirketiniz yok.");
                    return;
                }
            }
            Mainpipeline.Close();
        }
        int totmoney = Client.GetData<dynamic>("bizmoney");
        if (Client.GetData<dynamic>("bizmoney") < value)
        {
            Main.SendErrorMessage(Client, "Yeterli miktarda paranız yok!");
            return;
        }

        double totalmoney = value * 0.20;
        int rounded = (int)Math.Round(totalmoney, 0);
        Main.GivePlayerMoneyBank(Client, value - rounded);
        int remain = totmoney - value;
        setbizmoney(Client, remain);
        Main.SendSuccessMessage(Client, "Hesabınızdan şirket hesabına " + value.ToString("N0") + " para aktardınız ve " + rounded + " vergi ödediniz.");
    }

    [Command("aisyeriver", "~y~[!]~w~: /aisyeriver [ID/İsim] [İşyeri ID]")]
    public static void CMD_aisyeriver(Player playerid, string hedef, int businessID)
    {
        if (playerid.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(playerid, "Bu komutu kullanabilmek için görevde olmalısınız, /aduty komutunu kullanarak göreve geçin.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(playerid) < 7)
        {
            Main.SendErrorMessage(playerid, "Yetkiniz yok.");
            return;
        }
        Player igrac = Main.findPlayer(playerid, hedef);
        int sqid = igrac.GetData<dynamic>("character_sqlid");

        if (igrac != null)
        {
            Main.CreateMySqlCommand("UPDATE `companies` SET `owner_name` = '" + AccountManage.GetCharacterName(igrac) + "', `owner` = " + sqid + " WHERE `id` = " + businessID + ";");
            Main.SendSuccessMessage(playerid, $"{businessID} ID'li işyeri, {hedef} ID'li oyuncuya verildi.");

            GameLog.ELog(playerid, GameLog.MyEnum.Admin, " oyuncuya " + AccountManage.GetCharacterName(igrac) + " işletme: " + businessID + " atadı.");
        }

    }

    [Command("aisyeriparasifirla", "~y~[!]~w~: /aisyeriparaduzenle [İşyeri ID]")]
    public static void CMD_setbizmoney(Player sender, int businessID)
    {
        if (sender.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(sender, "Bu komutu kullanabilmek için görevde olmalısınız, /aduty komutunu kullanarak göreve geçin.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(sender) < 7)
        {
            Main.SendErrorMessage(sender, "Yetkiniz yok.");
            return;
        }

        Main.CreateMySqlCommand("UPDATE `companies` SET `money` = 0 WHERE `id` = '" + businessID + "';");
        Main.SendSuccessMessage(sender, $"{businessID} ID'li işyerinin parası sıfırlandı.");
        GameLog.ELog(sender, GameLog.MyEnum.Admin, "işletmenin parası sıfırlandı ID: " + businessID + "");

    }

    public static void setbizmoney(Player sender, int amount)
    {
        Main.CreateMySqlCommand("UPDATE `companies` SET `money` = '" + amount + "' WHERE `owner` = '" + sender.GetData<dynamic>("character_sqlid") + "';");
    }



}
