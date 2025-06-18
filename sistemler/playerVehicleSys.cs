using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PlayerVehicle : Script
{
    public static int MAX_PLAYER_VEHICLES = 3;

    public class VehicleEnum : IEquatable<VehicleEnum>
    {
        public int id { get; set; }
        public int[] owner_sql { get; set; } = new int[MAX_PLAYER_VEHICLES];


        public Vehicle[] handle { get; set; } = new Vehicle[MAX_PLAYER_VEHICLES];

        public int[] index { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public string[] model { get; set; } = new string[MAX_PLAYER_VEHICLES];
        public Vector3[] position { get; set; } = new Vector3[MAX_PLAYER_VEHICLES];

        public float[] rotation { get; set; } = new float[MAX_PLAYER_VEHICLES];
        public int[] cor_1 { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] cor_2 { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] neons { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] dimension { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public string[] plate { get; set; } = new string[MAX_PLAYER_VEHICLES];
        public int[] ticket { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] state { get; set; } = new int[MAX_PLAYER_VEHICLES];

        public int[] health { get; set; } = new int[MAX_PLAYER_VEHICLES];
        public int[] fuel { get; set; } = new int[MAX_PLAYER_VEHICLES];

        public string[] json_vehicle_mods { get; set; } = new string[MAX_PLAYER_VEHICLES];

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            VehicleEnum objAsPart = obj as VehicleEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(VehicleEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<VehicleEnum> vehicle_data = new List<VehicleEnum>();

    public static int MaxPlayerVehicles(Player Client)
    {
        int vehicles = 1;
        if (Client.GetData<dynamic>("status") == true)
        {
            if (VIP.GetPlayerDonator(Client) >= 1)
            {
                vehicles += 1;
            }

            if (VIP.GetPlayerVIP(Client) >= 1)
            {
                vehicles += 1;
            }
        
            if (Client.GetData<dynamic>("character_vehicle_slots") >= 1)
            {
                vehicles += Client.GetData<dynamic>("character_vehicle_slots");
            }
        }

        return vehicles;
    }

    public class VehicleMod
    {
        // Client
        public int vehicle_color_1;
        public int vehicle_color_2;
        public int vehicle_engine;
        public int vehicle_brakes;
        public int vehicle_suspesion;
        public int vehicle_armor;

        public VehicleMod()
        {
            vehicle_color_1 = 0;
            vehicle_color_1 = 0;
            vehicle_engine = -1;
            vehicle_brakes = -1;
            vehicle_suspesion = -1;
            vehicle_armor = -1;
        }
    }


    public static Dictionary<NetHandle, VehicleMod> VehicleModData = new Dictionary<NetHandle, VehicleMod>();

    public static void LoadPlayerVehicles(Player Client)
    {

        //CountDBVehicle(Client);
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `vehicles` WHERE `vehicle_owner_id` = '" + NAPI.Data.GetEntityData(Client, "character_sqlid") + "';", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                int playerid = Main.getIdFromClient(Client);
                var index = 0;

                while (reader.Read())
                {


                    vehicle_data[playerid].index[index] = reader.GetInt32("id");
                    vehicle_data[playerid].model[index] = reader.GetString("vehicle_model");
                    vehicle_data[playerid].position[index] = new Vector3(float.Parse(reader.GetString("vehicle_position_x")), float.Parse(reader.GetString("vehicle_position_y")), float.Parse(reader.GetString("vehicle_position_z")));
                    vehicle_data[playerid].rotation[index] = float.Parse(reader.GetString("vehicle_rotation_z"));
                    vehicle_data[playerid].cor_1[index] = reader.GetInt32("vehicle_color_1");
                    vehicle_data[playerid].cor_2[index] = reader.GetInt32("vehicle_color_2");
                    vehicle_data[playerid].dimension[index] = reader.GetInt32("vehicle_dimension");
                    vehicle_data[playerid].plate[index] = reader.GetString("vehicle_plate");
                    vehicle_data[playerid].ticket[index] = reader.GetInt32("vehicle_ticket");
                    vehicle_data[playerid].state[index] = reader.GetInt32("vehicle_state");
                    vehicle_data[playerid].health[index] = reader.GetInt32("health");
                    vehicle_data[playerid].fuel[index] = reader.GetInt32("fuel");
                    vehicle_data[playerid].owner_sql[index] = reader.GetInt32("vehicle_owner_id");



                    if (reader.GetString("mods").Length > 10)
                    {
                        vehicle_data[playerid].json_vehicle_mods[index] = reader.GetString("mods");

                    }
                    else vehicle_data[playerid].json_vehicle_mods[index] = "";



                    if (vehicle_data[playerid].state[index] == 3)
                    {


                    }
                    if (vehicle_data[playerid].state[index] == 1)
                    {

                        SpawnPlayerVehicle(Client, index);

                        vehicle_data[playerid].handle[index].Health = vehicle_data[playerid].health[index];

                    }
                    index++;

                }

            }
            Mainpipeline.Close();
        }
    }






    public class VehicleMods
    {
        public int vehicle_mod { get; set; }
    }




    public static void SpawnPlayerVehicle(Player Client, int index)
    {

        int playerid = Main.getIdFromClient(Client);


        foreach (Vehicle item in NAPI.Pools.GetAllVehicles())
        {
            if (item.GetData<dynamic>("Mashin_Owner") == AccountManage.GetPlayerSQLID(Client) && item.GetData<dynamic>("Owner_set") == false && item.GetData<dynamic>("veh_sql") == vehicle_data[playerid].index[index])
            {
                vehicle_data[playerid].handle[index] = item;


                item.SetData<dynamic>("Owner_set", true);
                return;
            }
        }

        

        vehicle_data[playerid].handle[index] = API.Shared.CreateVehicle(NAPI.Util.GetHashKey(vehicle_data[playerid].model[index]), vehicle_data[playerid].position[index], vehicle_data[playerid].rotation[index], vehicle_data[playerid].cor_1[index], vehicle_data[playerid].cor_2[index], dimension: (uint)vehicle_data[playerid].dimension[index]);
        vehicle_data[playerid].handle[index].SetData<dynamic>("Mashin_Owner", AccountManage.GetPlayerSQLID(Client));
        vehicle_data[playerid].handle[index].SetData<dynamic>("Owner_set", true);
        vehicle_data[playerid].handle[index].SetData<dynamic>("index_Mashin", index);
        vehicle_data[playerid].handle[index].SetData<dynamic>("veh_sql", vehicle_data[playerid].index[index]);

        if (vehicle_data[playerid].state[index] == 3)
        {
            //vehicle_data[playerid].handle[index].SetSharedData("VehFreezed", true);
            // HighEnd.SetVehicleFreeze(veh: vehicle_data[playerid].handle[index], boolean: true);
        }

        //step1:
        // Vehicle Inventory
        VehicleInventory.AddInventoryToVehicle(vehicle_data[playerid].handle[index], NAPI.Util.VehicleNameToModel(vehicle_data[playerid].model[index]));
        VehicleInventory.LoadVehicleInventoryItens(Client, vehicle_data[playerid].handle[index], vehicle_data[playerid].index[index]);

        // fuel e locks
        // VehicleStreaming.SetEngineState(vehicle_data[playerid].handle[index], false);
        //VehicleStreaming.SetLockStatus(vehicle_data[playerid].handle[index], true);
        VehicleStreaming.SetLockStatus(vehicle_data[playerid].handle[index], true);
        VehicleStreaming.SetEngineState(vehicle_data[playerid].handle[index], false);
        Main.SetVehicleFuel(vehicle_data[playerid].handle[index], Convert.ToDouble(vehicle_data[playerid].fuel[index]));

        // plate
        NAPI.Vehicle.SetVehicleNumberPlate(vehicle_data[playerid].handle[index], vehicle_data[playerid].plate[index]);

        vehicle_data[playerid].handle[index].SetSharedData("INTERACT", vehicle_data[playerid].handle[index].Type);


        // string[] temp_mysql_data = reader.GetString("mods").ToString().Split('|');
        string[] temp_mysql_data = vehicle_data[playerid].json_vehicle_mods[index].ToString().Split('|');


        // mods
        if (vehicle_data[playerid].json_vehicle_mods[index] != "")
        {

            for (int i = 0; i < 70; i++)
            {
                if (i == 68) continue;
                if (i == 69) continue;
                vehicle_data[playerid].handle[index].SetMod(i, Convert.ToInt32(temp_mysql_data[i]));
            }

            vehicle_data[playerid].handle[index].NeonColor = new Color(Convert.ToInt32(temp_mysql_data[68]), Convert.ToInt32(temp_mysql_data[69]), Convert.ToInt32(temp_mysql_data[70]));
            if ((vehicle_data[playerid].handle[index].NeonColor.Red == 0 && vehicle_data[playerid].handle[index].NeonColor.Green == 0 && vehicle_data[playerid].handle[index].NeonColor.Blue == 0) || (vehicle_data[playerid].handle[index].NeonColor.Red == 255 && vehicle_data[playerid].handle[index].NeonColor.Green == 255 && vehicle_data[playerid].handle[index].NeonColor.Blue == 255))
            {
                API.Shared.SetVehicleNeonState(vehicle_data[playerid].handle[index], false);
            }
            else
            {
                NAPI.Vehicle.SetVehicleNeonColor(vehicle_data[playerid].handle[index], vehicle_data[playerid].handle[index].NeonColor.Red, vehicle_data[playerid].handle[index].NeonColor.Green, vehicle_data[playerid].handle[index].NeonColor.Blue);
                API.Shared.SetVehicleNeonState(vehicle_data[playerid].handle[index], true);
            }



        }

        // colors
        
        NAPI.Vehicle.SetVehiclePrimaryColor(vehicle_data[playerid].handle[index], vehicle_data[playerid].cor_1[index]);
        NAPI.Vehicle.SetVehicleSecondaryColor(vehicle_data[playerid].handle[index], vehicle_data[playerid].cor_2[index]);


        try
        {
            NAPI.Task.Run(() =>
            {
                if (index >= 0 && index < vehicle_data[playerid].handle.Length) {
                    vehicle_data[playerid].handle[index].PrimaryColor = vehicle_data[playerid].cor_1[index];
                    vehicle_data[playerid].handle[index].SecondaryColor = vehicle_data[playerid].cor_2[index];

                    if (temp_mysql_data.Length >= 71) {
                        vehicle_data[playerid].handle[index].NeonColor = new Color(Convert.ToInt32(temp_mysql_data[68]), Convert.ToInt32(temp_mysql_data[69]), Convert.ToInt32(temp_mysql_data[70]));
                    }
                    else {
                        Console.WriteLine("");

                    }
                }
                else {
                    Console.WriteLine("index is not valid" + index);
                }
            }, delayTime: 2000);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        vehicle_data[playerid].handle[index].Health = vehicle_data[playerid].health[index];
    }

    public static void SavePlayerVehicle(Player Client, int index)
    {
        int playerid = Main.getIdFromClient(Client);

        if (vehicle_data[playerid].model[index] == "")
        {
            return;
        }
        // start string query
        string main_query = "UPDATE vehicles SET ";

        //update coluns
        main_query = main_query + "`vehicle_model` = '" + vehicle_data[playerid].model[index] + "',";
        main_query = main_query + "`vehicle_state` = '" + vehicle_data[playerid].state[index] + "',";
        main_query = main_query + "`vehicle_position_x` = '" + vehicle_data[playerid].position[index].X.ToString() + "',";
        main_query = main_query + "`vehicle_position_y` = '" + vehicle_data[playerid].position[index].Y.ToString() + "',";
        main_query = main_query + "`vehicle_position_z` = '" + vehicle_data[playerid].position[index].Z.ToString() + "',";
        main_query = main_query + "`vehicle_rotation_z` = '" + vehicle_data[playerid].rotation[index].ToString() + "',";

        main_query = main_query + "`vehicle_dimension` = '" + vehicle_data[playerid].dimension[index] + "',";
        main_query = main_query + "`vehicle_ticket` = '" + vehicle_data[playerid].ticket[index] + "',";

        if (vehicle_data[playerid].state[index] == 1)
        {
            main_query = main_query + "`vehicle_color_1` = '" + vehicle_data[playerid].handle[index].PrimaryColor + "',";
            main_query = main_query + "`vehicle_color_2` = '" + vehicle_data[playerid].cor_2[index] + "',";

            main_query = main_query + "`vehicle_plate` = '" + vehicle_data[playerid].plate[index] + "',";
            main_query = main_query + "`health` = '" + Convert.ToInt32(vehicle_data[playerid].handle[index].Health) + "',";
            main_query = main_query + "`fuel` = '" + Convert.ToInt32(Main.GetVehicleFuel(vehicle_data[playerid].handle[index])) + "',";

            vehicle_data[playerid].health[index] = Convert.ToInt32(vehicle_data[playerid].handle[index].Health);
            vehicle_data[playerid].fuel[index] = Convert.ToInt32(Main.GetVehicleFuel(vehicle_data[playerid].handle[index]));
            
            string vehicle = "";
            for (int i = 0; i < 68; i++)
            {
                vehicle += vehicle_data[playerid].handle[index].GetMod(i) + "|";
            }
            vehicle += vehicle_data[playerid].handle[index].NeonColor.Red + "|";
            vehicle += vehicle_data[playerid].handle[index].NeonColor.Green + "|";
            vehicle += vehicle_data[playerid].handle[index].NeonColor.Blue + "";
            main_query = main_query + "`mods` = '" + vehicle + "' ";

            main_query = main_query + " WHERE `id` = '" + vehicle_data[playerid].index[index] + "'";

            vehicle_data[playerid].json_vehicle_mods[index] = vehicle;

            vehicle_data[playerid].cor_1[index] = vehicle_data[playerid].handle[index].PrimaryColor;
        }
        else
        {
            main_query = main_query + "`vehicle_plate` = '" + vehicle_data[playerid].plate[index] + "'";
            main_query = main_query + " WHERE `id` = '" + vehicle_data[playerid].index[index] + "'";
        }
        //execute mysql command with the query
        Main.CreateMySqlCommand(main_query);

    }

    public static async Task SaveOfflinePlayerVehicle(Vehicle veh, int vehsql)
    {

        string main_query = "UPDATE vehicles SET ";

        //update coluns
        main_query = main_query + "`vehicle_position_x` = '" + veh.Position.X.ToString() + "',";
        main_query = main_query + "`vehicle_position_y` = '" + veh.Position.Y.ToString() + "',";
        main_query = main_query + "`vehicle_position_z` = '" + veh.Position.Z.ToString() + "',";
        main_query = main_query + "`vehicle_rotation_z` = '" + veh.Rotation.Z.ToString() + "',";

        if (veh.HasData("vehicle_fuel"))
        {
            main_query = main_query + "`fuel` = '" + Convert.ToInt32(Main.GetVehicleFuel(veh)) + "'";
        }
        //main_query = main_query + "`health` = '" + Convert.ToInt32(veh.Health.ToString()) + "'";
        main_query = main_query + " WHERE `id` = " + vehsql + "";

        Main.CreateMySqlCommand(main_query);
    }

    private static string GenerateLicensePlate()
    {
        var random = new Random();

        string lettersPart1 = RandomString(1, random);
        string lettersPart2 = RandomString(2, random);
        string numbersPart1 = RandomNumberString(3, random);
        string numbersPart2 = RandomNumberString(2, random);

        return lettersPart1 + numbersPart1 + lettersPart2 + numbersPart2;
    }

    private static string RandomString(int length, Random random)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    private static string RandomNumberString(int length, Random random)
    {
        const string chars = "0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    // =============================================================

    public static void CreatePlayerVehicle(Player Client, int index, string model, float position_x = 0.0f, float position_y = 0.0f, float position_z = 0.0f, float rotation_x = 0.0f, float rotation_y = 0.0f, float rotation_z = 0.0f, int color_1 = 0, int color_2 = 0, int dimension = 0)
    {
        int playerid = Main.getIdFromClient(Client);

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            try
            {
                Mainpipeline.Open();
                string query = "INSERT INTO vehicles (`vehicle_owner_id`, `vehicle_model`, `vehicle_state`)" + " VALUES ('" + AccountManage.GetPlayerSQLID(Client) + "', '" + model + "', '1')";
                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                myCommand.ExecuteNonQuery();
                long last_vehicle_id = myCommand.LastInsertedId;

                vehicle_data[playerid].index[index] = Convert.ToInt32(last_vehicle_id);
                vehicle_data[playerid].model[index] = model;
                vehicle_data[Main.getIdFromClient(Client)].state[index] = 5; 
                vehicle_data[playerid].position[index] = new Vector3(position_x, position_y, position_z);
                vehicle_data[playerid].rotation[index] = rotation_z;
                vehicle_data[playerid].cor_1[index] = color_1;
                vehicle_data[playerid].cor_2[index] = color_2;
                vehicle_data[playerid].dimension[index] = dimension;
                vehicle_data[playerid].ticket[index] = 0;
                vehicle_data[playerid].health[index] = 1000;
                vehicle_data[playerid].fuel[index] = 100;
                vehicle_data[playerid].plate[index] = GenerateLicensePlate();

                SavePlayerVehicle(Client, index);
                Mainpipeline.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }

    [RemoteEvent("BuyVehicleFromCreditStore")]
    public static void BuyVehicleFromCreditStore(Player Client, string model, int price)
    {
        int index = PlayerVehicle.GetPlayerVehicleFreeSlotIndex(Client);

        if (index == -1)
        {
            Main.SendErrorMessage(Client, "Daha fazla araç alamazsınız. Maksimum araç sayınız: " + PlayerVehicle.MAX_PLAYER_VEHICLES);
            return;
        }

        if (VIP.GetPlayerCredits(Client) < price)
        {
            Main.DisplayErrorMessage(Client, "error", "Fiyat: " + price + " VIP kredisi: " + VIP.GetPlayerCredits(Client) + ".");
            return;
        }

        VIP.SetPlayerCredits(Client, VIP.GetPlayerCredits(Client) - price);

        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[Araç Galerisi]", "Tebrikler, " + model + " aracını " + price + " karşılığında satın aldınız.");
        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "[Araç Galerisi]", "Aracınızı park etmeyi unutmayın, /park komutunu kullanabilir veya F5 ile park edebilirsiniz!");

        CreatePlayerVehicle(Client, index, model, Client.Position.X, Client.Position.Y, Client.Position.Z, 0, 0, Client.Rotation.Z, 120, 120, 0);

        PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].state[index] = 1;
        PlayerVehicle.SpawnPlayerVehicle(Client, index);
        NAPI.Player.SetPlayerIntoVehicle(Client, PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].handle[index], (int)VehicleSeat.Driver);

        VehicleStreaming.SetEngineState(PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].handle[index], false);
        VehicleStreaming.SetLockStatus(PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].handle[index], true);
    }



    public static void ResetPlayerVehicleData(Player Client)
    {
        for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            ResetPlayerVehicleDataFromIndex(Client, index);
        }
    }

    public static void ResetPlayerVehicleDataFromIndex(Player Client, int index)
    {
        int playerid = Main.getIdFromClient(Client);
        if (vehicle_data[playerid].state[index] == 1)
        {
            if (vehicle_data[playerid].handle[index].Exists)
            {
                foreach (var ls in LSCUSTOM_NEW.ls_custom)
                {
                    ls.label_position.Text = Translation.ls_custom_label_free;
                    vehicle_data[playerid].handle[index].ResetData("lscustom_use");
                }

                //NAPI.Data.SetEntityData(vehicle_data[playerid].handle[index], "Mashin_owner", Client.GetData<dynamic>("player_sqlid"));
                //NAPI.Data.SetEntityData(vehicle_data[playerid].handle[index], "Mashin_Info", vehicle_data[playerid]);
                //NAPI.Entity.DeleteEntity(vehicle_data[playerid].handle[index]);
                //vehicle_data[playerid].handle[index] = null;
            }
        }

        vehicle_data[playerid].model[index] = "";
        vehicle_data[playerid].position[index] = new Vector3(0, 0, 0);
        vehicle_data[playerid].rotation[index] = 0;
        vehicle_data[playerid].cor_1[index] = 0;
        vehicle_data[playerid].cor_2[index] = 0;
        vehicle_data[playerid].dimension[index] = 0;
        vehicle_data[playerid].state[index] = 0;
        vehicle_data[playerid].plate[index] = "0";
        vehicle_data[playerid].ticket[index] = 0;
    }

    public static int GetPlayerVehicleCount(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);
        int index = 0, count = 0;
        while (count < MAX_PLAYER_VEHICLES)
        {
            if (vehicle_data[playerid].model[index] != "" && vehicle_data[playerid].model[index] != null)
            {
                index++;
            }
            count++;
        }
        return index;
    }

    public static int GetPlayerVehicleFreeSlotIndex(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);
        for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            if (vehicle_data[playerid].model[index] == "" || vehicle_data[playerid].model[index] == null)
            {
                return index;
            }
        }
        return -1;
    }

    [RemoteEvent("KeyPress:F5")]
    public static void KeyPressF5(Player Client)
    {
        if (Client.GetData<dynamic>("General_CEF") == false)
        {
            ShowPlayerVehicles(Client);
        }
    }

    [RemoteEvent("TrackVehicle")]
    public static void TrackVehicle(Player Client, int index)
    {
        int playerid = Main.getIdFromClient(Client);
        NAPI.ClientEvent.TriggerClientEvent(Client, "Destroy_Character_Menu");
        if (vehicle_data[playerid].model[index] != "" && vehicle_data[playerid].model[index] != null)
        {
            if (vehicle_data[playerid].state[index] != 1 && vehicle_data[playerid].state[index] != 3)
            {
                Main.SendErrorMessage(Client, "Araç garajda olduğu için işaretlenemedi. En yakın garajdan aracı çıkartabilirsiniz.");

            }
            else
            {
                try
                {


                    Vector3 position = NAPI.Entity.GetEntityPosition(vehicle_data[playerid].handle[index]);

                    Main.SendCustomChatMessasge(Client, "Aracınız ~y~" + vehicle_data[playerid].model[index] + "~w~ size ~b~" + position.DistanceTo(Client.Position).ToString("0") + " metre~w~ uzaklıkta. Waypoint 1 dakika içinde kaybolacak!");

                    Client.TriggerEvent("blip_remove", "Tracker");
                    Client.TriggerEvent("blip_create_ext", "Tracker", position, 75, 0.80f, 225);

                    NAPI.Task.Run(() =>
                    {
                        if (Client.Exists)
                        {
                            Client.TriggerEvent("blip_remove", "Tracker");
                        }
                    }, delayTime: 60 * 1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        else
        {
            Main.SendErrorMessage(Client, "Böyle bir " + index + " yok.");

        }
    }

    [RemoteEvent("DeleteVehicle")]
    public static void DeleteVehicle(Player Client, int index)
    {
        return;
        NAPI.ClientEvent.TriggerClientEvent(Client, "Destroy_Character_Menu");
        int playerid = Main.getIdFromClient(Client);
        if (vehicle_data[playerid].model[index] != "" && vehicle_data[playerid].model[index] != null)
        {

            if (vehicle_data[playerid].state[index] == 1)
            {
                if (vehicle_data[playerid].handle[index].Exists)
                {
                    vehicle_data[playerid].handle[index].Delete();
                }
            }

            Main.CreateMySqlCommand("DELETE FROM `vehicles` WHERE `id` = '" + vehicle_data[playerid].index[index] + "';");

            Main.SendCustomChatMessasge(Client, "* ~b~" + vehicle_data[playerid].model[index] + "~w~ silindi.");

            vehicle_data[playerid].model[index] = "";
            vehicle_data[playerid].position[index] = new Vector3(0, 0, 0);
            vehicle_data[playerid].rotation[index] = 0;
            vehicle_data[playerid].cor_1[index] = 0;
            vehicle_data[playerid].cor_2[index] = 0;
            vehicle_data[playerid].dimension[index] = 0;
            vehicle_data[playerid].state[index] = 0;
            vehicle_data[playerid].plate[index] = "0";
            vehicle_data[playerid].ticket[index] = 0;
        }
    

        else
        {
            Main.SendErrorMessage(Client, "Slot " + index + " için araç yok.");
        }
    }

    public static void PlayerDisconnectVeh(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);
        for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            if (vehicle_data[playerid].model[index] != "" && vehicle_data[playerid].model[index] != null)
            {
                if (vehicle_data[playerid].state[index] == 1)
                {
                    vehicle_data[playerid].handle[index].SetData<dynamic>("Owner_set", false);
                }
            }
        }
    }
    public enum getvehiclestate
    {
        In_Insurance_Company,
        In_Street,
        Public_Garage,
        High_End,
        House_Garage,
    }

    public static void ShowPlayerVehicles(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);
        List<dynamic> menu_item_list = new List<dynamic>();
        for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            if (vehicle_data[playerid].model[index] != "" && vehicle_data[playerid].model[index] != null)
            {
                if (vehicle_data[playerid].state[index] == 0)
                {
                    menu_item_list.Add(new { Model = vehicle_data[playerid].model[index], Status = "El konmuş", Index = index });
                }
                else if (vehicle_data[playerid].state[index] == 1)
                {
                    menu_item_list.Add(new { Model = vehicle_data[playerid].model[index], Status = "Şehirde", Index = index });
                }
                else if (vehicle_data[playerid].state[index] == 2)
                {
                    menu_item_list.Add(new { Model = vehicle_data[playerid].model[index], Status = "Parçalanmış", Index = index });
                }
                else if (vehicle_data[playerid].state[index] == 3)
                {
                    menu_item_list.Add(new { Model = vehicle_data[playerid].model[index], Status = "High End", Index = index });
                }
                else if (vehicle_data[playerid].state[index] == 4)
                {
                    menu_item_list.Add(new { Model = vehicle_data[playerid].model[index], Status = "Garajda", Index = index });
                }
                else if (vehicle_data[playerid].state[index] == 5)
                {
                    menu_item_list.Add(new { Model = vehicle_data[playerid].model[index], Status = "Garajda", Index = index });
                }
            }
        }
        Client.TriggerEvent("Display_Player_Vehicles", NAPI.Util.ToJson(menu_item_list));
    }

    public static void ShowPlayerVehiclesToRelease(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);
        List<dynamic> menu_item_list = new List<dynamic>();
        for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            if (vehicle_data[playerid].model[index] != "" && vehicle_data[playerid].model[index] != null)
            {

                int foreach_index = 0, dealership_index = -1, price = 4000;
                foreach (var vehicle_dealership in Dealership.CarDealershipVehicles)
                {
                    if (vehicle_dealership.car_dealership_model_name == vehicle_data[playerid].model[index])
                    {
                        dealership_index = foreach_index;
                    }
                    foreach_index++;
                }

                if (dealership_index == -1)
                {
                    price = 4000;
                }
                else price = Convert.ToInt32(Dealership.CarDealershipVehicles[dealership_index].car_dealership_stock_price) / 100 * 5;


                if (vehicle_data[playerid].state[index] == 0 || vehicle_data[playerid].state[index] == 2)
                {
                    menu_item_list.Add(new { Index = index, Model = vehicle_data[playerid].model[index], Price = price });
                }

            }
        }

        Client.TriggerEvent("Display_Release_Vehicles", NAPI.Util.ToJson(menu_item_list));

    }

    [RemoteEvent("PayInsure")]
    public static void PayInsurece(Player Client, int index, int price)
    {
        int playerid = Main.getIdFromClient(Client);
        NAPI.ClientEvent.TriggerClientEvent(Client, "Hide_Browser");
        if (vehicle_data[playerid].model[index] != "" && vehicle_data[playerid].model[index] != null)
        {
            if (vehicle_data[playerid].state[index] == 0 || vehicle_data[playerid].state[index] == 2)
            {
                if (Main.GetPlayerMoney(Client) < price)
                {
                    Main.SendCustomChatMessasge(Client, "Yeterli paranız yok.");

                    return;
                }

                Random rnd = new Random();
                int estacionamento = rnd.Next(0, 3);

                switch (estacionamento)
                {
                    case 0:
                        vehicle_data[playerid].position[index] = new Vector3(-242.5172, -1183.938, 22.61802);
                        vehicle_data[playerid].rotation[index] = 1.427602f;

                        break;
                    case 1:
                        vehicle_data[playerid].position[index] = new Vector3(-235.4772, -1183.781, 22.61792);
                        vehicle_data[playerid].rotation[index] = 0.01197207f;

                        break;
                    case 2:
                        vehicle_data[playerid].position[index] = new Vector3(-225.9057, -1183.738, 22.61738);
                        vehicle_data[playerid].rotation[index] = 4.911421f;

                        break;
                    case 3:
                        vehicle_data[playerid].position[index] = new Vector3(-219.4278, -1184.928, 22.61718);
                        vehicle_data[playerid].rotation[index] = 0.152357f;
                        break;

                }

                Main.GivePlayerMoney(Client, -price);

                vehicle_data[playerid].state[index] = 1;

                SpawnPlayerVehicle(Client, index);
                SavePlayerVehicle(Client, index);

                Main.SendCustomChatMessasge(Client, "Sigortadan ~y~" + vehicle_data[playerid].model[index] + "~w~ aracını aldınız ve ~g~$" + price.ToString("N0") + "~w~ ödediniz.");
            }
            else
            {
                Main.SendErrorMessage(Client, "Bu araçta sigorta bulunmuyor!");
            }
        }
        else
        {
            Main.SendErrorMessage(Client, "Araçta donanım yok! " + index + ".");
        }
    }

    [Command("park")]
    public static void CMD_estacionar(Player Client)
    { 
        if (!Client.IsInVehicle)
        {
            InteractMenu_New.SendNotificationError(Client, "Bir araçta olmalısınız!");
            return;
        }
        int playerid = Main.getIdFromClient(Client);

        for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            if (vehicle_data[playerid].state[index] == 1)
            {
                if (vehicle_data[playerid].handle[index].Exists && vehicle_data[playerid].handle[index] == Client.Vehicle)
                {
                    vehicle_data[playerid].position[index] = Client.Vehicle.Position;
                    vehicle_data[playerid].rotation[index] = Client.Vehicle.Rotation.Z;

                    SavePlayerVehicle(Client, index);
                    Main.DisplayErrorMessage(Client, "info", "Aracınızı park ettiniz: " + Main.EMBED_LIGHTGREEN + vehicle_data[playerid].model[index] + Main.EMBED_WHITE + "");

                    return;
                }
            }
        }
        InteractMenu_New.SendNotificationError(Client, "Bu aracı park edemezsiniz!");
    }


    [Command("aracsat", "~y~[R]~w~: /aracsat [ID/İsim] [Fiyat]")]
    public void CMD_aracsat(Player Client, string idOrname, int price)
    {
        if (!Client.IsInVehicle)
        {
            Main.SendErrorMessage(Client, "Satmak istediğiniz araçta değilsiniz!");
            return;
        }

        Player target = Main.findPlayer(Client, idOrname);

        if (target == null)
        {
            Main.SendErrorMessage(Client, "Oyuncu sunucuda değil!");
            return;
        }

        if (Client.GetData<dynamic>("status") == false)
        {
            Main.SendErrorMessage(Client, "Yanlış ID!");
            return;
        }

        if (price < 1 || price > 50000000)
        {
            Main.SendErrorMessage(Client, "Fiyat 1'den küçük veya $50.000.000'dan büyük olamaz.");
            return;
        }

        if (Client == target)
        {
            Main.SendErrorMessage(Client, "Bu aracı kendinize satamazsınız!");
            return;
        }

        if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 3.0f))
        {
            Main.SendErrorMessage(Client, "Oyuncu yanınızda değil!");
            return;
        }

        int playerid = Main.getIdFromClient(Client);

        for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
        {
            if (vehicle_data[playerid].state[index] == 1)
            {
                if (vehicle_data[playerid].handle[index].Exists && vehicle_data[playerid].handle[index] == Client.Vehicle)
                {
                    Main.SendInfoMessage(Client, "Oyun " + AccountManage.GetCharacterName(target) + " oyuncusuna, aracınızı " + vehicle_data[playerid].model[index] + " için $" + price.ToString("N0") + " olarak teklif ettiniz.");

                    target.SetData<dynamic>("vehicle_offer_id", index);
                    target.SetData<dynamic>("vehicle_offer_price", price);
                    target.SetData<dynamic>("vehicle_offer_handle", Client);

                    InteractMenu.ShowModal(target, "VEHICLE_SELL_TO_PLAYER", "Araç Satışı", "" + AccountManage.GetCharacterName(Client) + " size " + vehicle_data[playerid].model[index] + " aracını $" + price.ToString("N0") + " karşılığında satmayı teklif ediyor.", "Evet, aracı alacağım.", "Hayır, aracı almak istemiyorum.");
                    return;
                }
            }
        }
        Main.SendErrorMessage(Client, "Başka birinin aracını satamazsınız!");
    }

    public static void ModalConfirm(Player Client, string response)
    {
        if (response == "VEHICLE_SELL_TO_PLAYER")
        {
            Player selling = Client.GetData<dynamic>("vehicle_offer_handle");

            if (!API.Shared.IsPlayerConnected(selling))
            {
                Main.SendErrorMessage(Client, "Oyuncu artık sunucuda değil!");
                return;
            }

            if (selling.GetData<dynamic>("status") == false)
            {
                Main.SendErrorMessage(Client, "Oyuncu mevcut değil!");
                return;
            }

            int vehicle_id = Client.GetData<dynamic>("vehicle_offer_id");
            int price = Client.GetData<dynamic>("vehicle_offer_price");

            int targetid = Main.getIdFromClient(selling);
            int playerid = Main.getIdFromClient(Client);
            for (int index = 0; index < MAX_PLAYER_VEHICLES; index++)
            {
                if (vehicle_data[targetid].state[index] == 1)
                {
                    if (vehicle_data[targetid].handle[index].Exists && vehicle_data[targetid].handle[index] == selling.Vehicle && index == vehicle_id)
                    {

                        if (Main.GetPlayerMoney(Client) < price)
                        {
                            Main.SendErrorMessage(Client, "Yeterli paranız yok!");
                            return;
                        }

                        if (GetPlayerVehicleFreeSlotIndex(Client) == -1)
                        {
                            Main.SendErrorMessage(Client, "Araç için yeterli alanınız yok!");
                            return;
                        }


                        Main.SendSuccessMessage(Client, "Şu aracı satın aldınız: " + vehicle_data[targetid].model[index] + " " + AccountManage.GetCharacterName(selling) + " adlı oyuncudan, fiyatı: $" + price.ToString("N0") + ". Tebrikler!");
                        Main.SendSuccessMessage(selling, "" + AccountManage.GetCharacterName(Client) + " teklifinizi kabul etti ve " + vehicle_data[targetid].model[index] + " aracınızı $" + price.ToString("N0") + " karşılığında satın aldı.");

                        Main.GivePlayerMoney(selling, price);
                        Main.GivePlayerMoney(Client, -price);

                        if (PlayerVehicle.vehicle_data[Main.getIdFromClient(selling)].handle[index].Exists) NAPI.Entity.DeleteEntity(PlayerVehicle.vehicle_data[Main.getIdFromClient(selling)].handle[index]);

                        PlayerVehicle.vehicle_data[Main.getIdFromClient(selling)].handle[index] = null;
                        PlayerVehicle.vehicle_data[Main.getIdFromClient(selling)].state[index] = 0;

                        // 
                        int free_slot = GetPlayerVehicleFreeSlotIndex(Client);
                        Main.CreateMySqlCommand("UPDATE `vehicles` SET `vehicle_owner_id` = " + AccountManage.GetPlayerSQLID(Client) + " WHERE `id` = " + vehicle_data[targetid].index[index] + "; ");


                        // Add Variable to new owner
                        vehicle_data[playerid].handle[free_slot] = selling.Vehicle;
                        vehicle_data[playerid].index[free_slot] = vehicle_data[targetid].index[index];
                        vehicle_data[playerid].model[free_slot] = vehicle_data[targetid].model[index];
                        vehicle_data[playerid].position[free_slot] = selling.Vehicle.Position;
                        vehicle_data[playerid].rotation[free_slot] = selling.Vehicle.Rotation.Z;
                        vehicle_data[playerid].cor_1[free_slot] = vehicle_data[targetid].cor_1[index];
                        vehicle_data[playerid].cor_2[free_slot] = vehicle_data[targetid].cor_2[index];
                        vehicle_data[playerid].dimension[free_slot] = vehicle_data[targetid].dimension[index];
                        vehicle_data[playerid].state[free_slot] = vehicle_data[targetid].state[index];
                        vehicle_data[playerid].plate[free_slot] = vehicle_data[targetid].plate[index];
                        vehicle_data[playerid].ticket[free_slot] = vehicle_data[targetid].ticket[index];


                        // Remove Vehicle from old owner
                        vehicle_data[targetid].handle[index] = null;
                        vehicle_data[targetid].model[index] = "";
                        vehicle_data[targetid].position[index] = new Vector3(0, 0, 0);
                        vehicle_data[targetid].rotation[index] = 0;
                        vehicle_data[targetid].cor_1[index] = 0;
                        vehicle_data[targetid].cor_2[index] = 0;
                        vehicle_data[targetid].dimension[index] = 0;
                        vehicle_data[targetid].state[index] = 0;
                        vehicle_data[targetid].plate[index] = "0";
                        vehicle_data[targetid].ticket[index] = 0;

                       

                        // Save vehicle to new owner
                        SavePlayerVehicle(Client, index);
                        SavePlayerVehicle(selling, index);
                        
                        return;
                    }
                }
            }

        }

    }

    [Command("dekspos")]
    public static void DeksPos(Player player)
    {
        player.Position = new Vector3(1568.4415,-982.6196, 59.36934);
    }

}
