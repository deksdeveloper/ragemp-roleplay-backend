using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
class Sherif:Script
{
    public Sherif()
    {
        /*NAPI.TextLabel.CreateTextLabel("~y~ Soyunma Odası ~n~~n~~w~ Üniformayı almak için ~n~~n~~w~ ~b~  Y ~w~ tuşuna basın", new Vector3(-448.7, 6011.6, 31.7 + 0.3), 12, 0.3500f, 4, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel("~y~~h~- DUR -~w~~h~~n~~n~~w~", new Vector3(-450.0119, 6016.234, 31.71639 + 0.3), 12, 0.3500f, 0, new Color(0, 122, 255, 150));
        NAPI.Marker.CreateMarker(1, new Vector3(-450.0119, 6016.234, 31.71639 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(0, 122, 255, 150));


        NAPI.TextLabel.CreateTextLabel("~y~ Otopark ~n~~n~~w~ Aracı geri vermek için ~n~~n~~w~ ~b~  E ~w~ tuşuna basın", new Vector3(-478.38116, 6019.4365, 31.34054 + 0.3), 12, 0.3500f, 0, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel("~y~ Garaj ~n~~n~~w~ Aracı almak için ~n~~n~~w~ ~b~  Y ~w~ tuşuna basın", new Vector3(-444.1966, 5998.2153, 31.49011 + 0.3), 12, 0.650f, 0, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel("~y~ /skiniwl ~n~~n~~w~ Aranma seviyesini düşürmek için ~n~~n~ Her aranma seviyesi eklemek için $3000 ödeyin~w~~n~ ~b~  Y ~w~ tuşuna basın", new Vector3(791.54, 2176.50, 52.64 + 0.3), 12, 0.650f, 0, new Color(0, 122, 255, 150));
    */}

    public static void SherifUniform(Player player)
    {

        if ((int)NAPI.Data.GetEntitySharedData(player, "CHARACTER_ONLINE_GENRE") == 1)
        {
            player.SetClothes(11, 201, 0);
            player.SetClothes(4, 37, 1);
            player.SetClothes(6, 61, 0);
            player.SetClothes(8, 15, 0);
        }
        else
        {
            player.SetClothes(11, 201, 0);
            player.SetClothes(4, 37, 1);
            player.SetClothes(6, 61, 0);
            player.SetClothes(8, 15, 0);
        }
       
    }

}
