using GTANetworkAPI;
using System;
using System.Collections.Generic;

class oglasi : Script
{
    [RemoteEvent("wnewsSubmitPost")]
    public static void wnewsSubmitPost(Player Client, string content, int phonenumber)
    {
        if (Main.GetPlayerMoney(Client) < 1000)
        {
            Main.DisplayErrorMessage(Client, "info", "Yeterli paranýz yok.");
            return;

        }
        if (Client.GetData<dynamic>("oglas") == true)
        {
            Main.DisplayErrorMessage(Client, "info", "Zaten bir ilan verdiniz, 1 dakika bekleyin.");
            return;
        }
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(Client))
            {
                Client.SetData("oglas", false);
            }

        }, 60000);
        Main.GivePlayerMoney(Client, -1000);
        NAPI.Chat.SendChatMessageToAll("~g~[ÝLAN] ~b~ " + content);
        NAPI.Chat.SendChatMessageToAll("~b~" + AccountManage.GetCharacterName(Client) + " ~g~Telefon~b~: " + phonenumber);
        Main.GiveCompanyMoney(0, 100);
        Client.SetData("oglas", true);
    }
}

