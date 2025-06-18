using GTANetworkAPI;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Timers;


class DialogSistem : Script
{
    public static List<TimerEx> iyiles_timer = new List<TimerEx>();
   
    public DialogSistem()
    {

    }

    [RemoteEvent("kabulettix")]
    public void KabulEtti(Player client, int id)
    {
        switch(id)
        {
            case 1:
                {
                    int sure = 0;
                    int playerid = Main.getIdFromClient(client);
                    iyiles_timer[playerid] = TimerEx.SetTimer(() =>
                    {
                        try
                        {
                            sure++;
                            if (sure >= 15)
                            {
                                if (NAPI.Player.IsPlayerConnected(client))
                                {
                                    client.StopAnimation();
                                    client.Dimension = 0;
                                    client.TriggerEvent("freeze", false);
                                    Main.SendSuccessMessage(client, "Başarıyla tedavi oldunuz! ~r~(-$3.000)~w~");
                                    Main.GivePlayerMoney(client, -3000);
                                    int playerid = Main.getIdFromClient(client);
                                    client.TriggerEvent("DestroyCustomCamera");
                                    NAPI.Player.SetPlayerHealth(client, 100);
                                    client.TriggerEvent("update_health", client.Health, client.Armor);
                                    if (iyiles_timer[playerid] != null)
                                    {
                                        iyiles_timer[playerid].Kill();
                                        iyiles_timer[playerid] = null;
                                    }
                                }
                            }
                            else
                            {
                                NAPI.ClientEvent.TriggerClientEvent(client, "DisplayCustomCamera", new Vector3(363.56, -583.46, 43.28), new Vector3(-4, 0, -63.97));
                                NAPI.Entity.SetEntityPosition(client, new Vector3(366.79, -581.68, 44.21));
                                client.TriggerEvent("freeze", true);
                                Main.DisplaySubtitle(client, $"Tedavi oluyorsunuz... {sure}/15", 1);
                                NAPI.Player.PlayPlayerAnimation(client, (int)(Main.AnimationFlags.StopOnLastFrame | Main.AnimationFlags.AllowPlayerControl), "combat@damage@injured_pistol@to_writhe", "variation_b");
                            }


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }, 1000, 0);
                    break;
                }
        }
    }

    [RemoteEvent("kabuletmedix")]
    public void KabulEtmedi(Player client, int id)
    {
        switch(id)
        {
            case 1:
                {
                    Main.SendErrorMessage(client, "Tedavi olmayı reddettin.");
                    break;
                }
        }
    }

    [Command("dialog")]
    public static void DialogCikar(Player client, string baslik, string icerik, string buton1, string buton2, int id)
    {
        client.TriggerEvent("DialogCagir", baslik, icerik, buton1, buton2, id);
    }

}
