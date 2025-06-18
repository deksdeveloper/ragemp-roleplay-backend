using System;
using System.Collections.Generic;
using GTANetworkAPI;


class shipwar : Script
{

    public static bool shipwarstarted = false;
    public static int maxitems = 0;


    [Command("gemisavasi")]
    public static void startshipwar(Player player)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) < 7)
        {
            Main.SendErrorMessage(player, "Yeterli yetkiniz yok!");
            return;
        }
        NAPI.Chat.SendChatMessageToAll("~r~-------------------------------------------------------------");
        NAPI.Chat.SendChatMessageToAll("Malzeme taşıyan gemi, Los Santos limanına 10 dakika içinde varacak!");
        NAPI.Chat.SendChatMessageToAll("~r~-------------------------------------------------------------");
        TimerEx.SetTimer(() =>
        {

            startedbattle(player);

        }, 600000, 1);
    }


    public static void startedbattle(Player player)
    {
        
        string vehName = "tug";
        VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
        if (vehHash != 0)
        {
            var vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(30.53, -2774.82, 0.50), new Vector3(0, 0, 0), 0, 0);
            vehicle.SetData<dynamic>("shipwar", true);
            vehicle.Dimension = 0;
            Main.SetVehicleFuel(vehicle, 0.0);
            vehicle.NumberPlate = "Administration";
            NAPI.Vehicle.SetVehicleEngineStatus(vehicle, false); 
            shipwarstarted = true;
            var label = NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Gemi Yagmalama ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(30.933, -2771.02, 5.20), 16, 0.600f, 0, new Color(0, 122, 255, 150));
            TimerEx.SetTimer(() =>
            {
                label.Delete();
                vehicle.Delete();
                shipwarstarted = false;
                maxitems = 0;

            }, 600000, 1);
        }
    }
    [RemoteEvent("stealship")]
    public static void stealship(Player player)
    {  
        
        if (player.GetData<dynamic>("pljackas") == true)
        {
            return;
        } 
        player.SetData<dynamic>("pljackas", true);

        if (shipwarstarted == true)
        {
            
            Main.PlayAnimation(player, "amb@world_human_gardener_plant@male@idle_a", "idle_b", 49, 0);
            TimerEx.SetTimer(() =>
            {
                player.StopAnimation();
                ShipReward(player);
                player.SetData<dynamic>("pljackas", false);
            }, 10000, 1);
        }
    }

    public static void ShipReward(Player player)
    {
        if (maxitems > 20)
        {
            Main.SendErrorMessage(player, "Gemide ürün kalmadı!");
            return;
        }
        
        var items = new Dictionary<int, int>
        {
            { 0, 49 },
            { 1, 50 },
            { 2, 53 },
            { 3, 54 },
            { 4, 55 },
            { 5, 56 },
            { 6, 1 }
        };

        var rnd = new Random();
        var item = rnd.Next(1, 3);
        var random_value = rnd.Next(0, 7);
        var inventoryId = items[random_value];
        Inventory.GiveItemToInventory(player, inventoryId, item);
        maxitems += item;
        Main.SendSuccessMessage(player, "Başarıyla gemiden eşya aldınız!");
    }
}