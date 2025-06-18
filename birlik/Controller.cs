using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
public class FactionManage : Script
{
    //int teste = PlayerVehicles.IndexOf(new vehicleEnum() { player_vehicle_id = 55 });
    public static int MAX_FACTIONS = 50;
    public static int MAX_FACTION_RANK = 11;
    public static int FACTION_TYPE_NONE = 0;
    public static int FACTION_TYPE_POLICE = 1;
    public static int FACTION_TYPE_MEDIC = 2;
    public static int FACTION_TYPE_MECHANIC = 3;

    public class FactionEnum : IEquatable<FactionEnum>
    {
        public int faction_id { get; set; }
        public int faction_type { get; set; }
        public string faction_name { get; set; }
        public string faction_abbrev { get; set; }
        public int faction_leader { get; set; }
        public string faction_motd { get; set; }
        public string faction_color { get; set; }
        public string faction_logo { get; set; }
        public string faction_description { get; set; }
        public int faction_turf_color { get; set; }
        public int verify { get; set; }

        public string[] faction_rank { get; set; } = new string[MAX_FACTION_RANK];
        public int[] faction_salary { get; set; } = new int[MAX_FACTION_RANK];

        public int faction_armory_recurso { get; set; }
        public string[] faction_armory_gun { get; set; } = new string[20];
        public int[] faction_armory_stock { get; set; } = new int[20];
        public int[] faction_armory_price { get; set; } = new int[20];

        public Entity faction_armory_marker { get; set; }
        public Entity faction_armory_label { get; set; }

        public float faction_armory_x { get; set; }
        public float faction_armory_y { get; set; }
        public float faction_armory_z { get; set; }

        public string[] faction_vehicle_name { get; set; } = new string[MAX_FACTION_VEHICLES];
        public string[] faction_vehicle_owned { get; set; } = new string[MAX_FACTION_VEHICLES];
        public Vehicle[] faction_vehicle_entity { get; set; } = new Vehicle[MAX_FACTION_VEHICLES];

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            FactionEnum objAsPart = obj as FactionEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return faction_id;
        }
        public bool Equals(FactionEnum other)
        {
            if (other == null) return false;
            return (this.faction_id.Equals(other.faction_id));
        }
    }

    public static List<FactionEnum> faction_data = new List<FactionEnum>();

    public static void FactionInit()
    {

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `faction`;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                var index = 0;
                while (reader.Read())
                {
                    faction_data.Add(new FactionEnum()
                    {
                        faction_id = reader.GetInt32("id"),
                        faction_type = reader.GetInt32("type"),
                        faction_name = reader.GetString("name"),
                        faction_abbrev = reader.GetString("abbrev"),
                        faction_leader = reader.GetInt32("leader"),
                        faction_motd = reader.GetString("motd"),
                        faction_color = reader.GetString("color"),
                        faction_logo = reader.GetString("logo"),
                        faction_description = reader.GetString("description"),
                        faction_turf_color = reader.GetInt32("zone_color"),
                        verify = reader.GetInt32("verify"),
                    });

                    for (int i = 0; i < 20; i++)
                    {
                        faction_data[index].faction_armory_gun[i] = reader.GetString("armory_gun_" + i);
                        faction_data[index].faction_armory_stock[i] = reader.GetInt32("armory_stock_" + i);
                        faction_data[index].faction_armory_price[i] = reader.GetInt32("armory_price_" + i);
                        
                    }

                    faction_data[index].faction_armory_recurso = reader.GetInt32("stock");
                    faction_data[index].faction_armory_x = reader.GetFloat("armory_x");
                    faction_data[index].faction_armory_y = reader.GetFloat("armory_y");
                    faction_data[index].faction_armory_z = reader.GetFloat("armory_z");

                    //faction_data[index].faction_armory_label = NAPI.TextLabel.CreateTextLabel("~y~~h~- Oruzarnica ~b~" + faction_data[index].faction_name + "~y~ -~w~~h~~n~~n~~w~Koristite ~y~~h~y~h~~w~ da otvorite meni.", new Vector3(faction_data[index].faction_armory_x, faction_data[index].faction_armory_y, faction_data[index].faction_armory_z + 0.3), 12, 0.3500f, 4, new Color(0, 122, 255, 150));


                    for (int b = 0; b < MAX_FACTION_VEHICLES; b++)
                    {
                        faction_data[index].faction_vehicle_name[b] = "Serbest";
                        faction_data[index].faction_vehicle_owned[b] = "Bilinmiyor";
                    }


                    LoadFactionRank(index);
                    index++;
                }
            }
            Mainpipeline.Close();
        }
    }




    public static void LoadFactionRank(int factionid)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `faction_rank` WHERE  `id` = " + factionid + ";", Mainpipeline);
            MySqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < MAX_FACTION_RANK; i++)
                {
                    faction_data[factionid].faction_rank[i] = reader.GetString("rank_" + i);
                    faction_data[factionid].faction_salary[i] = reader.GetInt32("salary_" + i);
                    
                }
            }
            Mainpipeline.Close();
        }
    }

    public static void SaveFaction(int index)
    {
        string query = "UPDATE faction SET name = @name, type = @type, abbrev = @abbrev, leader = @leader, motd = @motd, color = @color, `stock` = @stock, `armory_x` = @armory_x, `armory_y` = @armory_y, `armory_z` = @armory_z, `zone_color` = @zone_color";

        for (int i = 0; i < 20; i++)
        {
            query = query + ", armory_gun_" + i + " = '" + faction_data[index].faction_armory_gun[i] + "', armory_stock_" + i + " = '" + faction_data[index].faction_armory_stock[i] + "', armory_price_" + i + " = '" + faction_data[index].faction_armory_price[i] + "' ";
        }
        query = query + " WHERE `id` = '" + index + "'";

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();

                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                // paramenters
                myCommand.Parameters.AddWithValue("@name", faction_data[index].faction_name);
                myCommand.Parameters.AddWithValue("@type", faction_data[index].faction_type);
                myCommand.Parameters.AddWithValue("@abbrev", faction_data[index].faction_abbrev);
                myCommand.Parameters.AddWithValue("@leader", faction_data[index].faction_leader);
                myCommand.Parameters.AddWithValue("@motd", faction_data[index].faction_motd);
                myCommand.Parameters.AddWithValue("@color", faction_data[index].faction_color);
                myCommand.Parameters.AddWithValue("@zone_color", faction_data[index].faction_turf_color);

                myCommand.Parameters.AddWithValue("@stock", faction_data[index].faction_armory_recurso);
                myCommand.Parameters.AddWithValue("@armory_x", faction_data[index].faction_armory_x);
                myCommand.Parameters.AddWithValue("@armory_y", faction_data[index].faction_armory_y);
                myCommand.Parameters.AddWithValue("@armory_z", faction_data[index].faction_armory_z);


                // command
                myCommand.ExecuteNonQuery();
                Mainpipeline.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }

    public static void InsertFaction(int index)
    {

        string query = "INSERT INTO `faction` (`name`, `type` , `abbrev` , `leader`, `motd`  , `color`  , `stock`  , `armory_x`  , `armory_y` , `armory_z` , `zone_color` ) ";

        query = query + "VALUES (@name,@type,@abbrev,@leader,@motd,@color,@stock,@armory_x, @armory_y,@armory_z,@zone_color)";

        //  query = query + " WHERE `id` = '" + index + "'";


        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();

                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                // paramenters

                myCommand.Parameters.AddWithValue("@name", faction_data[index].faction_name);
                myCommand.Parameters.AddWithValue("@type", faction_data[index].faction_type);
                myCommand.Parameters.AddWithValue("@abbrev", faction_data[index].faction_abbrev);
                myCommand.Parameters.AddWithValue("@leader", faction_data[index].faction_leader);
                myCommand.Parameters.AddWithValue("@motd", faction_data[index].faction_motd);
                myCommand.Parameters.AddWithValue("@color", faction_data[index].faction_color);
                myCommand.Parameters.AddWithValue("@zone_color", faction_data[index].faction_turf_color);

                myCommand.Parameters.AddWithValue("@stock", faction_data[index].faction_armory_recurso);
                myCommand.Parameters.AddWithValue("@armory_x", faction_data[index].faction_armory_x);
                myCommand.Parameters.AddWithValue("@armory_y", faction_data[index].faction_armory_y);
                myCommand.Parameters.AddWithValue("@armory_z", faction_data[index].faction_armory_z);

                // command
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO `faction_rank` (`rank_10`) VALUES ('Leader') ";
                myCommand.ExecuteNonQuery();
                Mainpipeline.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }

    public static void SaveFactionRanks(int index)
    {
        string query = "UPDATE faction_rank SET rank_0 = '" + faction_data[index].faction_rank[0] + "', salary_0 = '" + faction_data[index].faction_salary[0] + "'";
        for (int i = 0; i < MAX_FACTION_RANK; i++)
        {
            query = query + ", rank_" + i + " = '" + faction_data[index].faction_rank[i] + "', salary_" + i + " = '" + faction_data[index].faction_salary[i] + "'";
        }
        query = query + "WHERE `id` = '" + index + "'";

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                myCommand.ExecuteNonQuery();
                Mainpipeline.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

        }
    }

    public static int GetPlayerGroupID(Player Client)
    {
        try
        {
            return faction_data[NAPI.Data.GetEntityData(Client, "character_group")].faction_id;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public static int GetPlayerGroupType(Player Client)
    {
        return faction_data[NAPI.Data.GetEntityData(Client, "character_group")].faction_type;
    }

    public static string Faction_Type(int factionid)
    {
        string type = "N/A";
        switch (factionid)
        {
            case 1:
                {
                    type = "LSPD";
                    break;
                }

            case 2:
                {
                    type = "LSMD";
                    break;
                }
            case 3:
                {
                    type = "San News";
                    break;
                }
            case 4:
                {
                    type = "İl-Legal";
                    break;
                }
            case 5:
                {
                    type = "Taxi";
                    break;
                }
            case 6:
                {
                    type = "Mekanik";
                    break;
                }

        }
        return type;
    }

    public static int GetMaxRank(int index)
    {
        int rank = MAX_FACTION_RANK - 1;
        while (0 < rank)
        {
            if (faction_data[index].faction_rank[rank] != "Undefined")
            {
                return rank;
            }
            rank--;
        }
        return MAX_FACTION_RANK - 1;
    }

    public static void DisplayEditFaction(Player Client)
    {
        int index = NAPI.Data.GetEntityData(Client, "EditingFactionID");

        List<string> list = new List<string>();

        list.Add("N/A");
        list.Add("Polis");
        list.Add("Doktor");
        list.Add("Haberci");
        list.Add("İl-legal");
        list.Add("Taxi");
        list.Add("Mekanik");
        list.Add("Hitman");
        list.Add("İl-legal");

        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "İsim", Description = "", RightLabel = "~b~" + faction_data[index].faction_name });
        menu_item_list.Add(new { Type = 6, Name = "Tür", Description = "", List = list, StartIndex = faction_data[index].faction_type });
        menu_item_list.Add(new { Type = 1, Name = "Kısa Ad", Description = "", RightLabel = "~y~" + faction_data[index].faction_abbrev });
        menu_item_list.Add(new { Type = 1, Name = "Organizasyon Rengi", Description = "HEX formatında olmalı, ~y~Örnek: ~w~FFFFFF", RightLabel = "~y~" + faction_data[index].faction_color });
        menu_item_list.Add(new { Type = 1, Name = "Bölge Rengi", Description = "Renk ID'lerini şu adreste bulabilirsiniz: ~y~https://wiki.rage.mp/index.php?title=Blips", RightLabel = "~y~" + faction_data[index].faction_turf_color });
        menu_item_list.Add(new { Type = 1, Name = "Ceza Düzenle", Description = "", RightLabel = "~c~>>" });
        menu_item_list.Add(new { Type = 1, Name = "Maaş Düzenle", Description = "", RightLabel = "~c~>>" });

        InteractMenu.CreateMenu(Client, "FACTION_EDITING_MENU", "Birlik", "Düzenleniyor ~b~" + faction_data[index].faction_name + " ~c~(" + index + ").", false, NAPI.Util.ToJson(menu_item_list), false);

        //NAPI.ClientEvent.TriggerClientEvent(Client, "display_edit_select_faction", index, faction_data[index].faction_type, Faction_Type(faction_data[index].faction_type), faction_data[index].faction_name, faction_data[index].faction_color, faction_data[index].faction_abbrev, faction_data[index].faction_armory_recurso);

    }
    public static int MAX_FACTION_VEHICLES = 100;

    public static void DisplayFactionVehicles(Player Client)
    {
        int faction_id = AccountManage.GetPlayerGroup(Client);

        if (faction_id == 1)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "Golf", Description = "", RightLabel = "~c~Tüm" });
            menu_item_list.Add(new { Type = 4, Name = "Audi", Description = "", RightLabel = "~c~Tüm" });
            menu_item_list.Add(new { Type = 4, Name = "Chevrolet", Description = "", RightLabel = "~c~Tüm" });
            InteractMenu.CreateMenu(Client, "VEHICLE_FACTION_SPAWN", "Garaj", "~b~Otomobil:", true, NAPI.Util.ToJson(menu_item_list), false);
        }
        else if (faction_id == 2)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "Ambulans", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 4, Name = "Ambulans2", Description = "", RightLabel = "" });
            //menu_item_list.Add(new { Type = 4, Name = "fbi2", Description = "", RightLabel = "~c~Rank ~w~4~g~+" });
            // menu_item_list.Add(new { Type = 4, Name = "Polmav", Description = "", RightLabel = "~c~Rank ~w~7~g~+" });
            InteractMenu.CreateMenu(Client, "VEHICLE_FACTION_SPAWN", "Garaj", "~b~Hastane garajı:", true, NAPI.Util.ToJson(menu_item_list), false);
        }

        else if (faction_id == 3)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "Sherif", Description = "", RightLabel = "~c~Tüm" });
            menu_item_list.Add(new { Type = 4, Name = "Sherif2", Description = "", RightLabel = "~c~Tüm" });
            menu_item_list.Add(new { Type = 4, Name = "Polisb", Description = "", RightLabel = "~c~Tüm" });
            menu_item_list.Add(new { Type = 4, Name = "Pranger", Description = "", RightLabel = "~c~Tüm" });
            menu_item_list.Add(new { Type = 4, Name = "Polis4", Description = "", RightLabel = "~c~Tüm" });
            menu_item_list.Add(new { Type = 4, Name = "Polmav", Description = "", RightLabel = "~c~Rank ~w~5~g~+" });
            InteractMenu.CreateMenu(Client, "VEHICLE_FACTION_SPAWN", "Garaj", "~b~Sherif Garajı:", true, NAPI.Util.ToJson(menu_item_list), false);
        }
        else if (GetPlayerGroupID(Client) == 6)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "çekici", Description = "", RightLabel = "~c~Tüm" });
            menu_item_list.Add(new { Type = 4, Name = "çekici2", Description = "", RightLabel = "~c~Tüm" });
            menu_item_list.Add(new { Type = 4, Name = "bobcatxl", Description = "", RightLabel = "~c~Tüm" });
            InteractMenu.CreateMenu(Client, "VEHICLE_FACTION_SPAWN", "Garaj", "~b~Mekanik Garajı:", true, NAPI.Util.ToJson(menu_item_list), false);
        }
        else if (GetPlayerGroupID(Client) == 5)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 4, Name = "Taksi", Description = "", RightLabel = "~c~Tüm" });
            //menu_item_list.Add(new { Type = 4, Name = "Rentalbus", Description = "", RightLabel = "~c~Tüm" });
            InteractMenu.CreateMenu(Client, "VEHICLE_FACTION_SPAWN", "Garaj", "~b~Taksi Garajı:", true, NAPI.Util.ToJson(menu_item_list), false);
        }
    }

    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "VEHICLE_FACTION_SPAWN")
        {
            string vehicle_name = objectName;

            var factionid = AccountManage.GetPlayerGroup(Client);
            if (factionid == -1) { return; }

            int index = -1;
            for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
            {
                if (faction_data[factionid].faction_vehicle_name[i] == "Livre")
                {
                    index = i;
                }
            }

            if (index == -1)
            {
                Main.SendErrorMessage(Client, "Şu anda garajdan araç alamazsınız.");
                return;
            }


            if (factionid == 1)
            {
                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(Client) && faction_data[factionid].faction_vehicle_entity[i] != null)
                    {
                        //  Main.DisplayErrorMessage(Client, "error", "Mashin Shoma Dar Map Mibashad.");
                        //  return;
                        try { if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists) faction_data[factionid].faction_vehicle_entity[i].Delete(); faction_data[factionid].faction_vehicle_entity[i] = null; } catch (Exception) { }
                        faction_data[factionid].faction_vehicle_entity[i] = null;
                        faction_data[factionid].faction_vehicle_name[i] = "Livre";
                        faction_data[factionid].faction_vehicle_owned[i] = "Unknown";
                    }
                }

                if (vehicle_name == "Golf")
                {
                    VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("polgolf");
                    var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, new Vector3(450.81, -975.83, 25.69), 86f, 0, 0);
                    vehicle.Dimension = 0;
                    Random tbla = new Random();
                    int tabla = tbla.Next(100, 999);
                    string finaltabl = "P-" + tabla;
                    vehicle.NumberPlate = finaltabl;
                    vehicle.PrimaryColor = 111;
                    vehicle.SecondaryColor = 111;
                    Main.SetVehicleFuel(vehicle, 90.0);
                    vehicle.SetData("polveh", true);

                }
                else if (vehicle_name == "Audi")
                {

                    VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("polaudi");
                    var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, new Vector3(435.89, -976.01, 25.69), 86f, 0, 0);
                    vehicle.Dimension = 0;
                    Random tbla = new Random();
                    int tabla = tbla.Next(100, 999);
                    string finaltabl = "P-" + tabla;
                    vehicle.NumberPlate = finaltabl;
                    vehicle.PrimaryColor = 111;
                    vehicle.SecondaryColor = 111;
                    Main.SetVehicleFuel(vehicle, 90.0);
                    vehicle.SetData("polveh", true);

                }
                else if (vehicle_name == "Chevrolet")
                {

                    VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("polchev");
                    var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, new Vector3(458.98, -993.10, 25.69), -4.1f, 0, 0);
                    vehicle.Dimension = 0;
                    Random tbla = new Random();
                    int tabla = tbla.Next(100, 999);
                    string finaltabl = "P-" + tabla;
                    vehicle.NumberPlate = finaltabl;
                    vehicle.PrimaryColor = 111;
                    vehicle.SecondaryColor = 111;
                    Main.SetVehicleFuel(vehicle, 90.0);
                    vehicle.SetData("polveh", true);

                }

            }
            else if (factionid == 2)
            {
                if (vehicle_name == "Polmav" && AccountManage.GetPlayerRank(Client) < 3)
                {
                    Main.SendErrorMessage(Client, "Rütbe 3 veya üstü olmalısınız!");
                }
                if (vehicle_name == "fbi2" && AccountManage.GetPlayerRank(Client) < 3)
                {
                    Main.SendErrorMessage(Client, "Rütbe 3 veya üstü olmalısınız!");
                    return;
                }
                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(Client))
                    {
                        try
                        {
                            if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists)
                                faction_data[factionid].faction_vehicle_entity[i].Delete();
                            faction_data[factionid].faction_vehicle_entity[i] = null;
                        }
                        catch (Exception) { }
                        faction_data[factionid].faction_vehicle_entity[i] = null;
                        faction_data[factionid].faction_vehicle_name[i] = "Livre";
                        faction_data[factionid].faction_vehicle_owned[i] = "Unknown";
                    }
                }



                if (vehicle_name == "Ambulance")
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel("Ambulance");
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(1823.8856, 3691.7468, 33.992996), new Vector3(0, 0, -77.09678), -1, -1);
                    //       NAPI.Player.SetPlayerIntoVehicle(Client, faction_data[factionid].faction_vehicle_entity[index], (int)VehicleSeat.Driver);
                    // VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);
                    VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);

                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    faction_data[factionid].faction_vehicle_entity[index].Health = Main.DEFAULT_VEHICLE_HEALTH;
                }

                if (vehicle_name == "Ambulance2")
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel("Ambulance");
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(1823.8856, 3691.7468, 33.992996), new Vector3(0, 0, -77.09678), -1, -1);
                    //       NAPI.Player.SetPlayerIntoVehicle(Client, faction_data[factionid].faction_vehicle_entity[index], (int)VehicleSeat.Driver);
                    // VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);
                    VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);

                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    faction_data[factionid].faction_vehicle_entity[index].Livery = 2;
                    faction_data[factionid].faction_vehicle_entity[index].Health = Main.DEFAULT_VEHICLE_HEALTH;
                }
                if (vehicle_name == "fbi2")
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-456.40778, -282.6884, 35.740326), new Vector3(0, 0, 68.28551), -1, -1);
                    //        NAPI.Player.SetPlayerIntoVehicle(Client, faction_data[factionid].faction_vehicle_entity[index], (int)VehicleSeat.Driver);
                    // VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);
                    VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);

                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    faction_data[factionid].faction_vehicle_entity[index].PrimaryColor = 27;
                    faction_data[factionid].faction_vehicle_entity[index].SecondaryColor = 43;
                    faction_data[factionid].faction_vehicle_entity[index].Health = Main.DEFAULT_VEHICLE_HEALTH;


                }
                if (vehicle_name == "Polmav")
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-455.88364, -293.38693, 78.16802), new Vector3(0, 0, 86), -1, -1);
                    //          NAPI.Player.SetPlayerIntoVehicle(Client, faction_data[factionid].faction_vehicle_entity[index], (int)VehicleSeat.Driver);
                    //  VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);
                    VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);

                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    faction_data[factionid].faction_vehicle_entity[index].Livery = 1;
                    faction_data[factionid].faction_vehicle_entity[index].Health = Main.DEFAULT_VEHICLE_HEALTH;
                }
                /*else
                {
                    Random rnd = new Random();
                    int item = rnd.Next(0, 3);
                    switch (item)
                    {
                        case 0:
                            {
                                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-422.2811, -334.2184, 33.1091), new Vector3(0, 0, 80.59139), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(Client, faction_data[factionid].faction_vehicle_entity[index], -1);
                                VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                faction_data[factionid].faction_vehicle_entity[index].Health = Main.DEFAULT_VEHICLE_HEALTH;
                                break;
                            }
                        case 1:
                            {
                                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-422.2811, -334.2184, 33.1091), new Vector3(0, 0, 80.59139), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(Client, faction_data[factionid].faction_vehicle_entity[index], -1);
                                VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                faction_data[factionid].faction_vehicle_entity[index].Health = Main.DEFAULT_VEHICLE_HEALTH;
                                break;
                            }
                        case 2:
                            {
                                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-422.2811, -334.2184, 33.1091), new Vector3(0, 0, 80.59139), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(Client, faction_data[factionid].faction_vehicle_entity[index], -1);
                                VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                faction_data[factionid].faction_vehicle_entity[index].Health = Main.DEFAULT_VEHICLE_HEALTH;
                                break;
                            }
                        case 3:
                            {
                                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-422.2811, -334.2184, 33.1091), new Vector3(0, 0, 80.59139), -1, -1);
                                NAPI.Player.SetPlayerIntoVehicle(Client, faction_data[factionid].faction_vehicle_entity[index], -1);
                                VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);
                                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 99.0);
                                faction_data[factionid].faction_vehicle_entity[index].Health = Main.DEFAULT_VEHICLE_HEALTH;
                                break;
                            }
                    }
                }*/
            }
            else if (factionid == 3)
            {
                if (vehicle_name == "Polmav" && AccountManage.GetPlayerRank(Client) < 5)
                {
                    Main.SendErrorMessage(Client, "Rütbe 3 veya üzeri olmalısınız!");
                    return;
                }

                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(Client))
                    {
                        try
                        {
                            if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists)
                                faction_data[factionid].faction_vehicle_entity[i].Delete();
                            faction_data[factionid].faction_vehicle_entity[i] = null;
                        }
                        catch (Exception) { }
                        faction_data[factionid].faction_vehicle_entity[i] = null;
                        faction_data[factionid].faction_vehicle_name[i] = "Livre";
                        faction_data[factionid].faction_vehicle_owned[i] = "Unknown";
                    }
                }
                if (vehicle_name == "Polmav")





                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-475.2526, 5988.587, 31.33668), new Vector3(0, 0, 314.8221), -1, -1);
                    //          NAPI.Player.SetPlayerIntoVehicle(Client, faction_data[factionid].faction_vehicle_entity[index], (int)VehicleSeat.Driver);
                    // VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);
                    VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);

                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    faction_data[factionid].faction_vehicle_entity[index].Health = Main.DEFAULT_VEHICLE_HEALTH;
                }
                else
                {
                    VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                    faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-448.3, 5994.5, 30.9), new Vector3(0, 0, 266.9), -1, -1);
                    //         NAPI.Player.SetPlayerIntoVehicle(Client, faction_data[factionid].faction_vehicle_entity[index], (int)VehicleSeat.Driver);
                    //  VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);
                    VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);

                    Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                    faction_data[factionid].faction_vehicle_entity[index].Health = Main.DEFAULT_VEHICLE_HEALTH;

                }
                faction_data[factionid].faction_vehicle_name[index] = vehicle_name;
                faction_data[factionid].faction_vehicle_owned[index] = AccountManage.GetCharacterName(Client);
            }
            else if (GetPlayerGroupID(Client) == 6)
            {
                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(Client))
                    {
                        try { if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists) faction_data[factionid].faction_vehicle_entity[i].Delete(); faction_data[factionid].faction_vehicle_entity[i] = null; } catch (Exception) { }
                        faction_data[factionid].faction_vehicle_entity[i] = null;
                        faction_data[factionid].faction_vehicle_name[i] = "Livre";
                        faction_data[factionid].faction_vehicle_owned[i] = "Unknown";
                    }
                }

                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(-354.0995, -115.8306, 38.69666), new Vector3(0, 0, 71.95589), -1, -1);
                //       NAPI.Player.SetPlayerIntoVehicle(Client, faction_data[factionid].faction_vehicle_entity[index], (int)VehicleSeat.Driver);
                // VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);
                VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);

                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                faction_data[factionid].faction_vehicle_entity[index].Health = Main.DEFAULT_VEHICLE_HEALTH;


                faction_data[factionid].faction_vehicle_name[index] = vehicle_name;
                faction_data[factionid].faction_vehicle_owned[index] = AccountManage.GetCharacterName(Client);
            }
            else if (GetPlayerGroupID(Client) == 5)
            {
                for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
                {
                    if (faction_data[factionid].faction_vehicle_owned[i] == AccountManage.GetCharacterName(Client))
                    {
                        try { if (faction_data[factionid].faction_vehicle_entity[i] != null && faction_data[factionid].faction_vehicle_entity[i].Exists) faction_data[factionid].faction_vehicle_entity[i].Delete(); faction_data[factionid].faction_vehicle_entity[i] = null; } catch (Exception) { }
                        faction_data[factionid].faction_vehicle_entity[i] = null;
                        faction_data[factionid].faction_vehicle_name[i] = "Livre";
                        faction_data[factionid].faction_vehicle_owned[i] = "Unknown";
                    }
                }

                VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(902.5665, -142.7664, 76.62575), new Vector3(0, 0, 333.7004), -1, -1);
                //     NAPI.Player.SetPlayerIntoVehicle(Client, faction_data[factionid].faction_vehicle_entity[index], (int)VehicleSeat.Driver);
                //VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);
                VehicleStreaming.SetEngineState(faction_data[factionid].faction_vehicle_entity[index], false);

                Main.SetVehicleFuel(faction_data[factionid].faction_vehicle_entity[index], 100.0);
                faction_data[factionid].faction_vehicle_entity[index].Health = Main.DEFAULT_VEHICLE_HEALTH;


                faction_data[factionid].faction_vehicle_name[index] = vehicle_name;
                faction_data[factionid].faction_vehicle_owned[index] = AccountManage.GetCharacterName(Client);
            }


            faction_data[factionid].faction_vehicle_name[index] = vehicle_name;
            faction_data[factionid].faction_vehicle_owned[index] = AccountManage.GetCharacterName(Client);
        }
        //-359.3449, 6062.392, 31.50013
        else if (callbackId == "FACTION_LIST_MENU")
        {
            NAPI.Data.SetEntityData(Client, "EditingFactionID", selectedIndex);
            DisplayEditFaction(Client);
        }
        else if (callbackId == "FACTION_EDITING_MENU")
        {
            int index = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            switch (selectedIndex)
            {
                case 0:
                    {
                        InteractMenu.User_Input(Client, "input_faction_name", "Organizasyon Adı", faction_data[index].faction_name);
                        InteractMenu.CloseDynamicMenu(Client);
                        break;
                    }
                case 2:
                    {
                        InteractMenu.User_Input(Client, "input_faction_abbrev", "Kısa Ad", faction_data[index].faction_abbrev);
                        InteractMenu.CloseDynamicMenu(Client);
                        break;
                    }
                case 3:
                    {
                        InteractMenu.User_Input(Client, "input_faction_color", "Organizasyon Rengi", faction_data[index].faction_color);
                        InteractMenu.CloseDynamicMenu(Client);
                        break;
                    }
                case 4:
                    {
                        InteractMenu.User_Input(Client, "input_faction_turf_color", "Bölge Rengi", faction_data[index].faction_turf_color.ToString(), "", "number");
                        InteractMenu.CloseDynamicMenu(Client);
                        break;
                    }
                case 5:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        for (int i = 0; i < MAX_FACTION_RANK; i++)
                        {
                            if (faction_data[index].faction_rank[i] == "Undefined")
                            {
                                menu_item_list.Add(new { Type = 4, Name = "Rank " + i + ".", Description = "", RightLabel = "~c~Tanımsız" });
                            }
                            else
                            {
                                menu_item_list.Add(new { Type = 4, Name = "Rank " + i + ".", Description = "", RightLabel = "~s~" + faction_data[index].faction_rank[i] + "" });
                            }
                        }
                        InteractMenu.CreateMenu(Client, "FACTION_EDITING_RANK", "Organizasyon", "~b~Rank Düzenleme " + index + ":", false, NAPI.Util.ToJson(menu_item_list), false);
                        break;
                    }
                case 6:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        for (int i = 0; i < MAX_FACTION_RANK; i++)
                        {
                            menu_item_list.Add(new { Type = 4, Name = "~c~Rank " + i + ".~s~ " + faction_data[index].faction_rank[i], Description = "", RightLabel = "~g~$" + faction_data[index].faction_salary[i] + "" });
                        }
                        InteractMenu.CreateMenu(Client, "FACTION_EDITING_SALARY", "Organizasyon", "~b~Maaş Düzenleme:", false, NAPI.Util.ToJson(menu_item_list), false);
                        break;
                    }

                case 7:
                    {
                        faction_data[index].faction_armory_x = Client.Position.X;
                        faction_data[index].faction_armory_y = Client.Position.Y;
                        faction_data[index].faction_armory_z = Client.Position.Z;

                        NAPI.Entity.DeleteEntity(faction_data[index].faction_armory_label);
                        //faction_data[index].faction_armory_label = NAPI.TextLabel.CreateTextLabel("~y~~h~- Oruzarnica ~b~" + faction_data[index].faction_name + "~y~ -~w~~h~~n~~n~~w~Koristite ~y~~h~y~h~~w~ da pristupite", new Vector3(faction_data[index].faction_armory_x, faction_data[index].faction_armory_y, faction_data[index].faction_armory_z + 0.3), 12, 0.3500f, 4, new Color(0, 122, 255, 150));

                        SaveFaction(index);
                        DisplayEditFaction(Client);
                        break;
                    }
                case 8:
                    {
                        InteractMenu.User_Input(Client, "input_faction_recurso", "Silah Deposuna Kaynak", faction_data[index].faction_armory_recurso.ToString(), "", "number");
                        InteractMenu.CloseDynamicMenu(Client);
                        break;
                    }
                case 9:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        for (int i = 0; i < 20; i++)
                        {
                            if (faction_data[index].faction_armory_gun[i] == "0")
                            {
                                menu_item_list.Add(new { Type = 4, Name = "~w~" + i + ". ~c~Boş", Description = "", RightLabel = "" });
                            }
                            else
                            {
                                menu_item_list.Add(new { Type = 4, Name = "~w~" + i + ". ~y~" + faction_data[index].faction_armory_gun[i] + "", Description = "", RightLabel = "~c~600 mühimmat" });
                            }
                        }
                        InteractMenu.CreateMenu(Client, "FACTION_EDITING_GUN", "Organizasyon", "~b~Silahlar:", false, NAPI.Util.ToJson(menu_item_list), false);
                        break;
                    }
                case 10:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        for (int i = 0; i < 20; i++)
                        {
                            menu_item_list.Add(new { Type = 4, Name = "~w~" + i + ". ~y~" + faction_data[index].faction_armory_gun[i] + "", Description = "", RightLabel = "~c~Fiyat: " + faction_data[index].faction_armory_price[i] + " kaynak" });
                        }
                        InteractMenu.CreateMenu(Client, "FACTION_EDITING_GUN_STOCK", "Organizasyon", "~b~Silahlar:", false, NAPI.Util.ToJson(menu_item_list), false);
                        break;
                    }
            }
        }
        else if (callbackId == "FACTION_EDITING_RANK")
        {
            int index = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            Client.SetData("faction_editing_rank", selectedIndex);
            InteractMenu.User_Input(Client, "input_faction_rank", "Rank Adı", faction_data[index].faction_rank[selectedIndex]);
            InteractMenu.CloseDynamicMenu(Client);
            SaveFactionRanks(index);
        }
        else if (callbackId == "FACTION_EDITING_SALARY")
        {
            int index = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            Client.SetData("faction_editing_rank", selectedIndex);
            InteractMenu.User_Input(Client, "input_faction_salary", "Maaş", faction_data[index].faction_salary[selectedIndex].ToString(), "", "number");
            InteractMenu.CloseDynamicMenu(Client);
            SaveFactionRanks(index);
        }
        else if (callbackId == "FACTION_EDITING_GUN")
        {
            int index = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            Client.SetData("faction_editing_rank", selectedIndex);
            InteractMenu.User_Input(Client, "input_faction_gun", "Silah", faction_data[index].faction_armory_gun[selectedIndex].ToString(), "", "text");
            InteractMenu.CloseDynamicMenu(Client);
        }
        else if (callbackId == "FACTION_EDITING_GUN_STOCK")
        {
            int index = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            Client.SetData("faction_editing_rank", selectedIndex);
            InteractMenu.User_Input(Client, "input_faction_gun_stock", "Silah Stoku", faction_data[index].faction_armory_price[selectedIndex].ToString(), "", "number");
            InteractMenu.CloseDynamicMenu(Client);
        }
        else if (callbackId == "FACTION_EDITING_RESOURCE")
        {
            int index = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            Client.SetData("faction_editing_rank", selectedIndex);
            InteractMenu.User_Input(Client, "input_faction_resource", "Kaynak Stoku", faction_data[index].faction_armory_recurso.ToString(), "", "number");
            InteractMenu.CloseDynamicMenu(Client);
        }
        else if (callbackId == "ARMORY_Deposit_RESPONSE")
        {
            try
            {

                int id = Client.GetData<dynamic>("Deparmory_" + selectedIndex);
                if (id == -1)
                {
                    Main.SendCustomChatMessasge(Client, "~r~ HATA");
                    return;
                }



                Main.DisplayErrorMessage(Client, "success", Inventory.player_inventory[Client.Value].amount[id] + "x " + Inventory.itens_available[Inventory.player_inventory[Client.Value].type[id]].name + " Deposit Shod");
                if (Inventory.player_inventory[Client.Value].amount[id] > 0 && Inventory.itens_available[Inventory.player_inventory[Client.Value].type[id]].guest != Inventory.ITEM_TYPE_WEAPON)
                {
                    Inventory.RemoveItemFromInventory(Client, id, 9999);
                }
                else if (Inventory.player_inventory[Client.Value].amount[id] > 0)
                {
                    WeaponManage.RemovePlayerWeaponAndAttachment(Client, (WeaponHash)Enum.Parse(typeof(WeaponHash), Inventory.itens_available[Inventory.player_inventory[Client.Value].type[id]].name));
                    Inventory.RemoveItemFromInventory(Client, id, 9999);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("ARMORY_Deposit_RESPONSE" + e);
            }
        }
        else if (callbackId == "ARMORY_BUY_RESPONSE")
        {
            int faction_id = AccountManage.GetPlayerGroup(Client);
            int item = selectedIndex;
            if (faction_id == -1)
            {
                Main.SendErrorMessage(Client, "Organizasyonda değilsiniz.");
                return;
            }

            if (faction_data[faction_id].faction_armory_gun[item] == "0")
            {
                NAPI.Notification.SendNotificationToPlayer(Client, "HATA: Burada hiçbir şey yok!", true);
            }
            else if (faction_data[faction_id].faction_armory_recurso < faction_data[faction_id].faction_armory_price[item])
            {
                NAPI.Notification.SendNotificationToPlayer(Client, "HATA: Yeterli kaynak yok.", true);
            }


            else
            {

                if (Inventory.GetItemCategoryid(faction_data[faction_id].faction_armory_gun[item]) == Inventory.ITEM_TYPE_Ammunation)
                {
                    if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Inventory.Item_Name_To_Type(faction_data[faction_id].faction_armory_gun[item]), 30, Inventory.Max_Inventory_Weight(Client)))
                    {
                        return;
                    }
                    if (AccountManage.GetPlayerGroup(Client) == 1)
                    {
                        Inventory.GiveItemToInventoryFromName(Client, faction_data[faction_id].faction_armory_gun[item], 30, 0, 0);
                    }
                    else
                    {
                        Inventory.GiveItemToInventoryFromName(Client, faction_data[faction_id].faction_armory_gun[item], 30, 0, 0);
                    }
                    Main.SendCustomChatMessasge(Client, "~y~[SİLAH DEPOSU]:~w~ ~y~30~w~ adet ~y~" + faction_data[faction_id].faction_armory_gun[item] + "~w~ silah depoya eklendi.");
                    return;
                }
                /*Client.TriggerEvent("removeAllWeapons");
                NAPI.Task.Run(() =>
                {
                    NAPI.Player.RemoveAllPlayerWeapons(Client);
                }, delayTime: 250);*/

                if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Inventory.Item_Name_To_Type(faction_data[faction_id].faction_armory_gun[item]), 1, Inventory.Max_Inventory_Weight(Client)))
                {
                    return;
                }
                NAPI.Task.Run(() =>
                {
                    WeaponHash hashcode = NAPI.Util.WeaponNameToModel(faction_data[faction_id].faction_armory_gun[item]);
                    faction_data[faction_id].faction_armory_recurso -= faction_data[faction_id].faction_armory_price[item];

                    if (faction_data[faction_id].faction_armory_price[item] == 0)
                        Main.SendCustomChatMessasge(Client, "~y~[SİLAH DEPOSU]:~w~ Eklendi. ~y~" + faction_data[faction_id].faction_armory_gun[item] + "~w~ silah deposuna.");
                    else
                        Main.SendCustomChatMessasge(Client, "~y~[SİLAH DEPOSU]:~w~ Aldınız. ~y~" + hashcode + "~w~ silah deposundan. ~r~(Fiyat: " + faction_data[faction_id].faction_armory_price[item] + ")");
                    List<dynamic> weap = new List<dynamic>();


                    if (AccountManage.GetPlayerGroup(Client) == 1)
                    {
                        Inventory.GiveItemToInventory(Client, Inventory.Item_Name_To_Type(faction_data[faction_id].faction_armory_gun[item]), 1, 0, 0, -1);
                    }
                    else
                    {
                        Inventory.GiveItemToInventory(Client, Inventory.Item_Name_To_Type(faction_data[faction_id].faction_armory_gun[item]), 1, 1, 0, -1);
                    }

                    //       Inventory.GiveItemToInventoryFromName(Client, , 1, 1);
                    //  WeaponManage.SetPlayerWeaponEx(Client, faction_data[faction_id].faction_armory_gun[item], 150);

                    // WeaponManage.SetPlayerWeaponEx(Client, faction_data[faction_id].faction_armory_gun[item], 250);
                    //NAPI.Player.SetPlayerCurrentWeaponAmmo(Client, 250);

                }, delayTime: 500);


                //NAPI.Player.GivePlayerWeapon(Client, hashcode, 600);

            }
        }
    }

    public static void ListItemMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        if (callbackId == "FACTION_EDITING_MENU")
        {
            int index = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            int type_id = valueIndex;

            faction_data[index].faction_type = type_id;
            SaveFaction(index);
            // DisplayEditFaction(Client);
        }
    }
    public static async System.Threading.Tasks.Task UpdateBankMoney(string id, int money)
    {
        System.Threading.Tasks.Task.Run(() =>
        {
            MySqlConnection connection = new MySqlConnection(Main.myConnectionString);
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "UPDATE characters SET bank=bank+'" + money + "' WHERE id='" + id + "' ";
            command.ExecuteNonQuery();
            connection.Close();
        });

    }

    public static void OnMenuReturnClose(Player Client, String callbackId)
    {
    }

    public static void OnInputResponse(Player Client, string response, string inputtext)
    {
        if (response == "change_faction_abbrev")
        {
            int faction_id = GetPlayerGroupID(Client);
            string name = inputtext;
            if (String.IsNullOrEmpty(name))
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Bunu yapamazsınız!");
                DisplayEditFaction(Client);
                return;
            }
            faction_data[faction_id].faction_abbrev = name.ToString();
            SaveFaction(faction_id);
        }
        else if (response == "change_faction_color")
        {
            int faction_id = GetPlayerGroupID(Client);
            string name = inputtext;
            if (String.IsNullOrEmpty(name))
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Bunu yapamazsınız!");
                DisplayEditFaction(Client);
                return;
            }
            faction_data[faction_id].faction_color = name.ToString();
            SaveFaction(faction_id);
        }

        else if (response == "input_faction_name")
        {
            int faction_id = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            string name = inputtext;
            if (String.IsNullOrEmpty(name))
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Bunu yapamazsınız!");
                DisplayEditFaction(Client);
                return;
            }
            faction_data[faction_id].faction_name = name.ToString();
            SaveFaction(faction_id);
            DisplayEditFaction(Client);
        }
        else if (response == "input_faction_Create")
        {
            string name = inputtext;
            CreateFaction(Client, name);
        }
        else if (response == "input_faction_abbrev")
        {
            int faction_id = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            string name = inputtext;
            if (String.IsNullOrEmpty(name))
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Bunu yapamazsınız!");
                DisplayEditFaction(Client);
                return;
            }
            faction_data[faction_id].faction_abbrev = name.ToString();
            SaveFaction(faction_id);
            DisplayEditFaction(Client);
        }
        else if (response == "input_faction_color")
        {
            int faction_id = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            string name = inputtext;
            if (String.IsNullOrEmpty(name))
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Bunu yapamazsınız!");
                DisplayEditFaction(Client);
                return;
            }
            faction_data[faction_id].faction_color = name.ToString();
            SaveFaction(faction_id);
            DisplayEditFaction(Client);
        }
        else if (response == "input_faction_turf_color")
        {
            int faction_id = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            int value = Convert.ToInt32(inputtext);
            if (!Main.IsNumeric(inputtext))
            {
                Client.SendNotification("~r~[HATA]:~w~ Bunu yapamazsınız!");
                return;
            }
            if (value < 1)
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Değer 1 ile 85 arasında olmalı!");
                DisplayEditFaction(Client);
                return;
            }
            if (value > 85)
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Değer 1 ile 85 arasında olmalı!");
                DisplayEditFaction(Client);
                return;
            }
            faction_data[faction_id].faction_turf_color = value;
            SaveFaction(faction_id);
            DisplayEditFaction(Client);
        }
        else if (response == "input_faction_rank")
        {
            int faction_id = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            int rank_id = NAPI.Data.GetEntityData(Client, "faction_editing_rank");
            string name = inputtext;
            if (String.IsNullOrEmpty(name))
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Bunu yapamazsınız!");
                DisplayEditFaction(Client);
                return;
            }
            faction_data[faction_id].faction_rank[rank_id] = name.ToString();
            SaveFaction(faction_id);
            DisplayEditFaction(Client);
        }
        else if (response == "input_player_faction_rank")
        {
            int faction_id = AccountManage.GetPlayerGroup(Client);
            int rank_id = NAPI.Data.GetEntityData(Client, "faction_editing_rank");
            string name = inputtext;
            if (String.IsNullOrEmpty(name))
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Bunu yapamazsınız!");
                DisplayEditFaction(Client);
                return;
            }
            Main.SendSuccessMessage(Client, "Rank değiştirdiniz. ~c~" + rank_id + "~w~ ~c~" + faction_data[faction_id].faction_rank[rank_id] + "~w~'den ~y~" + name.ToString() + "~w~'ye.");
            faction_data[faction_id].faction_rank[rank_id] = name.ToString();
            SaveFaction(faction_id);
            SaveFactionRanks(faction_id);
            InteractMenu.ShowPlayerFactionMenu(Client);
        }
        else if (response == "input_faction_salary")
        {
            int faction_id = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            int rank_id = NAPI.Data.GetEntityData(Client, "faction_editing_rank");
            string value = inputtext;
            if (!Main.IsNumeric(inputtext))
            {
                Client.SendNotification("~r~[HATA]~n~~w~Geçersiz giriş!");
                return;
            }

            if (Convert.ToInt32(value) < 1)
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Değer 1 ile $50.000 arasında olmalıdır!");
                DisplayEditFaction(Client);
                return;
            }
            else if (Convert.ToInt32(value) > 50000)
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Değer 1 ile $50.000 arasında olmalıdır!");
                DisplayEditFaction(Client);
                return;
            }
            faction_data[faction_id].faction_salary[rank_id] = Convert.ToInt32(value);
            SaveFaction(faction_id);
            DisplayEditFaction(Client);
        }
        else if (response == "input_faction_gun")
        {

            int index = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            int slot = NAPI.Data.GetEntityData(Client, "faction_editing_rank");
            string value = inputtext;


            if (value == "0")
            {
                faction_data[index].faction_armory_gun[slot] = "0";
                DisplayEditFaction(Client);
                return;
            }

            int weapon_id = -1;
            foreach (var gun in Main.weapon_list)
            {
                if (gun.model.Contains(value) == true)
                {
                    weapon_id = index;
                    break;
                }
                index++;
            }

            if (weapon_id == -1)
            {
                return;
            }


            faction_data[index].faction_armory_gun[slot] = value;
            SaveFaction(index);
            DisplayEditFaction(Client);
        }
        else if (response == "input_faction_gun_stock")
        {
            int index = NAPI.Data.GetEntityData(Client, "EditingFactionID");
            int slot = NAPI.Data.GetEntityData(Client, "faction_editing_rank");
            string value = inputtext;

            if (!Main.IsNumeric(inputtext))
            {
                Client.SendNotification("~r~[HATA]~n~~w~Geçersiz giriş!");
                return;
            }

            if (Convert.ToInt32(value) < 0)
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Değer 0 ile 1.000 arasında olmalıdır!");
                DisplayEditFaction(Client);
                return;
            }
            else if (Convert.ToInt32(value) > 50000)
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Değer 0 ile 1.000 arasında olmalıdır!");
                DisplayEditFaction(Client);
                return;
            }
        


        faction_data[index].faction_armory_price[slot] = Convert.ToInt32(value);
            SaveFaction(index);
            DisplayEditFaction(Client);
        }
        else if (response == "input_faction_recurso")
        {
            int index = NAPI.Data.GetEntityData(Client, "EditingFactionID");

            if (!Main.IsNumeric(inputtext))
            {
                Client.SendNotification("~r~[HATA]~n~~w~Geçersiz giriş!");
                return;
            }

            int value = Convert.ToInt32(inputtext);

            if (Convert.ToInt32(value) < 0)
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Değer 0 ile 10.000 arasında olmalıdır.");
                DisplayEditFaction(Client);
                return;
            }
            else if (Convert.ToInt32(value) > 10000)
            {
                Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Değer 0 ile 10.000 arasında olmalıdır.");
                DisplayEditFaction(Client);
                return;
            }

            faction_data[index].faction_armory_recurso = Convert.ToInt32(value);
            SaveFaction(index);
            DisplayEditFaction(Client);
        }

    }


    public static void SendFactionMessage(int faction, string poruka)
    {
        var players = NAPI.Pools.GetAllPlayers();
        foreach (Player c in players)
        {
            if (c.GetData<dynamic>("status") == true)
            {
                if (AccountManage.GetPlayerGroup(c) == faction)
                {
                    if (faction_data[faction].faction_color == "Undefined")
                    {
                        Main.SendCustomChatMessasge(c, "<font color='#009E12'>" + poruka);
                    }
                    else Main.SendCustomChatMessasge(c, "<font color='#" + faction_data[faction].faction_color + "'>" + poruka);
                }
            }
        }
    }

    public static void SendGroupMessage(int group_type, string poruka)
    {
        var players = NAPI.Pools.GetAllPlayers();
        foreach (Player c in players)
        {
            if (c.GetData<dynamic>("status") == true)
            {
                if (AccountManage.GetPlayerGroup(c) != 0 && faction_data[AccountManage.GetPlayerGroup(c)].faction_type == group_type)
                {
                    if (faction_data[AccountManage.GetPlayerGroup(c)].faction_color == "Undefined")
                    {
                        Main.SendCustomChatMessasge(c, "<font color='#009E12'>" + poruka);
                    }
                    else Main.SendCustomChatMessasge(c, "<font color='#" + faction_data[AccountManage.GetPlayerGroup(c)].faction_color + "'>" + poruka);
                }
            }
        }
    }

    [RemoteEvent("OnFaction_ClickButton")]
    public void MyFaction(Player Client, int buttonid, int faction_id)
    {
        if (buttonid == 1)
        {
            List<dynamic> member_list = new List<dynamic>();
            List<dynamic> faction_temp_data = new List<dynamic>();

            int count = 0;
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {

                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM `characters` WHERE  `group` = " + faction_id + ";", Mainpipeline);
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        member_list.Add(new { name = reader.GetString("name"), rank = reader.GetInt32("group_rank"), leader = reader.GetInt32("leader"), level = reader.GetInt32("level"), online = reader.GetInt32("status") });
                        count++;
                    }

                    faction_temp_data.Add(new
                    {
                        f_name = faction_data[faction_id].faction_name,
                        f_type_name = Faction_Type(faction_data[faction_id].faction_type),
                        f_members = count,
                        f_logo = faction_data[faction_id].faction_logo,
                        f_description = faction_data[faction_id].faction_description,

                        f_rank = faction_data[faction_id].faction_rank,
                        f_salary = faction_data[faction_id].faction_salary,
                        f_abbrev = faction_data[faction_id].faction_abbrev,
                        f_color = faction_data[faction_id].faction_color,
                        f_type = faction_data[faction_id].faction_type,
                        f_stock = faction_data[faction_id].faction_armory_recurso
                    });

                    Client.TriggerEvent("ViewFaction_Display", NAPI.Util.ToJson(member_list), NAPI.Util.ToJson(faction_temp_data));
                }
                Mainpipeline.Close();
            }
        }
    }

    [RemoteEvent("OnFaction_SaveEditing")]
    public void MyFaction(Player Client, int faction_id, string name, int type, string color, string abbrev, int recurso, string logo, string des, string rank_0, string rank_1, string rank_2, string rank_3, string rank_4, string rank_5, string rank_6, string rank_7, string rank_8, string rank_9, int salary_0, int salary_1, int salary_2, int salary_3, int salary_4, int salary_5, int salary_6, int salary_7, int salary_8, int salary_9)
    {


        faction_data[faction_id].faction_name = name;
        faction_data[faction_id].faction_color = color;
        faction_data[faction_id].faction_abbrev = abbrev;
        faction_data[faction_id].faction_armory_recurso = recurso;
        faction_data[faction_id].faction_type = type;
        faction_data[faction_id].faction_name = name;

        faction_data[faction_id].faction_logo = logo;
        faction_data[faction_id].faction_description = des;

        faction_data[faction_id].faction_rank[0] = rank_0;
        faction_data[faction_id].faction_rank[1] = rank_1;
        faction_data[faction_id].faction_rank[2] = rank_2;
        faction_data[faction_id].faction_rank[3] = rank_3;
        faction_data[faction_id].faction_rank[4] = rank_4;
        faction_data[faction_id].faction_rank[5] = rank_5;
        faction_data[faction_id].faction_rank[6] = rank_6;
        faction_data[faction_id].faction_rank[7] = rank_7;
        faction_data[faction_id].faction_rank[8] = rank_8;
        faction_data[faction_id].faction_rank[9] = rank_9;

        faction_data[faction_id].faction_salary[0] = salary_0;
        faction_data[faction_id].faction_salary[1] = salary_1;
        faction_data[faction_id].faction_salary[2] = salary_2;
        faction_data[faction_id].faction_salary[3] = salary_3;
        faction_data[faction_id].faction_salary[4] = salary_4;
        faction_data[faction_id].faction_salary[5] = salary_5;
        faction_data[faction_id].faction_salary[6] = salary_7;
        faction_data[faction_id].faction_salary[7] = salary_8;
        faction_data[faction_id].faction_salary[8] = salary_9;
        faction_data[faction_id].faction_salary[9] = salary_9;

        SaveFaction(faction_id);
        SaveFactionRanks(faction_id);

        Client.SendNotification("~g~Organizacija uspesno sacuvana!", false);

    }
    /* [RemoteEvent("keypress:F2")]
     public void KeyPressI(Player Client)
     {
         if (Client.GetData<dynamic>("globalBrowser") == false)
         {
             int faction_id = AccountManage.GetPlayerGroup(Client);

             // Faction List
             List<dynamic> menu_item_list = new List<dynamic>();
             foreach (var faction in faction_data)
             {
                 menu_item_list.Add(new { name = faction.faction_name, type = Faction_Type(faction.faction_type), leader = faction.faction_leader });

             }

             Client.TriggerEvent("display_faction_browser", faction_id, NAPI.Util.ToJson(menu_item_list), AccountManage.GetPlayerAdmin(Client), AccountManage.GetPlayerRank(Client));
             Client.SetData("globalBrowser", true);

         }
         else
         {
             Client.TriggerEvent("hide_faction_browser");
             Client.SetData("globalBrowser", false);

         }
     }*/


    [RemoteEvent("factionJoin")]
    public void factionJoin(Player player, int id)
    {
        if (GetPlayerGroupID(player) == 0)
        {
            Main.CreateMySqlCommand("INSERT INTO `faction_invite` (`player`,`factionid`,`name`) VALUES (" + AccountManage.GetPlayerSQLID(player) + "," + id + ",'" + AccountManage.GetCharacterName(player) + "')");
        }
    }

    [RemoteEvent("factionJoinApprove")]
    public void factionJoinApprove(Player player, int id)
    {

        Main.CreateMySqlCommand("DELETE FROM `faction_invite` where `player`='" + id + "'");

        int group_id = GetPlayerGroupID(player);

        Player target = Main.FindPlayerFromSqlid(id);

        if (target == null || !target.Exists)
        {
            Main.CreateMySqlCommand("UPDATE `characters` SET `leader`='0',`group`='" + group_id + "',`group_rank`='0' WHERE `id`='" + id + "'");
        }
        else
        {
            Main.SendCustomChatMessasge(target, "~w~ Organizasyona ~y~" + faction_data[GetPlayerGroupID(player)].faction_name + "~w~ katıldınız.");
            AccountManage.SetPlayerLeader(target, 0);
            AccountManage.SetPlayerGroup(target, group_id);
            AccountManage.SetPlayerRank(target, 0);
            target.TriggerEvent("factionchange", group_id);
            FactionManage.SaveFaction(group_id);

        }


    }

    [RemoteEvent("factionJoinDecline")]
    public void factionJoinDecline(Player player, int id)
    {
        Main.CreateMySqlCommand("DELETE FROM `faction_invite` where `player`='" + id + "'");
    }

    [RemoteEvent("factionCharacterKick")]
    public void factionCharacterKick(Player player, int id, int rank)
    {
        if (rank == 10)
        {
            Main.SendCustomChatMessasge(player, "~w~Oyuncuyu organizasyonunuzdan attınız.");
            return;
        }
        Main.CreateMySqlCommand("DELETE FROM `faction_invite` where `player`='" + id + "'");
        Player target = Main.FindPlayerFromSqlid(id);
        if (target != null)
        {
            NAPI.Data.SetEntityData(target, "duty", 0);
            Main.UpdatePlayerClothes(target);
            target.SetData("duty", 0);
            Outfits.RemovePlayerDutyOutfit(target);
            if (AccountManage.GetPlayerLeader(target) == 1 && FactionManage.GetPlayerGroupType(target) == 4)
            {
                FactionManage.DisbandTheFaction(FactionManage.GetPlayerGroupID(target));
            }
            AccountManage.SetPlayerLeader(target, 0);
            AccountManage.SetPlayerGroup(target, 0);
            AccountManage.SetPlayerRank(target, 0);
            Main.SavePlayerInformation(target);
            Main.SendCustomChatMessasge(target, "~w~Lider tarafından organizasyondan atıldınız.");
        }
    

        else
        {
            Main.CreateMySqlCommand("UPDATE `characters` SET `leader`='0',`group`='0',`group_rank`='0' WHERE `id`='" + id + "'");

        }
    }

    [RemoteEvent("factionDecline")]
    public void factionDecline(Player player)
    {
        Main.CreateMySqlCommand("DELETE FROM `faction_invite` where `player`='" + AccountManage.GetPlayerSQLID(player) + "'");
    }


    [RemoteEvent("factionLeave")]
    public void factionLeave(Player player)
    {
        NAPI.Data.SetEntityData(player, "duty", 0);
        Main.UpdatePlayerClothes(player);
        player.SetData("duty", 0);
        Outfits.RemovePlayerDutyOutfit(player);
        if (AccountManage.GetPlayerLeader(player) == 1 && FactionManage.GetPlayerGroupType(player) == 4)
        {
            FactionManage.DisbandTheFaction(FactionManage.GetPlayerGroupID(player));
        }
        AccountManage.SetPlayerLeader(player, 0);
        AccountManage.SetPlayerGroup(player, 0);
        AccountManage.SetPlayerRank(player, 0);
        Main.SavePlayerInformation(player);
        Main.SendCustomChatMessasge(player, "~w~Organizasyonu terk ettiniz!");
    }

    //cclose
    [RemoteEvent("ShowFactionList")]
    public static void ShowFactionList(Player player)
    {
        System.Threading.Tasks.Task.Run(() =>
        {

            List<dynamic> factionlist = new List<dynamic>();
            int requestto = 0;
            foreach (var item in faction_data)
            {
                if (item.faction_id == 0)
                {
                    continue;
                }
                long membercount = 0;
                using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT COUNT(*) FROM `characters` where `group`='" + item.faction_id + "'";
                    membercount = (Int64)command.ExecuteScalar();
                    connection.Close();
                }
                if (item.faction_name != "empty")
                {
                    factionlist.Add(new { name = item.faction_name, members = membercount, id = item.faction_id, type = item.faction_type });
                }
            }

            using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT `factionid` FROM `faction_invite` where `player`='" + AccountManage.GetPlayerSQLID(player) + "'";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        requestto = reader.GetInt32("factionid");
                    }
                }
                connection.Close();
            }

            NAPI.Task.Run(() =>
            {
                player.TriggerEvent("ShowFactionList", NAPI.Util.ToJson(factionlist), AccountManage.GetPlayerLeader(player), GetPlayerGroupID(player), requestto);
            });
        });

    }


    [RemoteEvent("EditCharacterRank")]
    public void EditCharacterRank(Player player, int characterid, int newrank)
    {
        if (AccountManage.GetPlayerLeader(player) != 1 || AccountManage.GetPlayerRank(player) <= 8)
        {
            return;
        }

        Player target = Main.FindPlayerFromSqlid(characterid);
        if (target != null && target.Exists)
        {
            AccountManage.SetPlayerRank(target, newrank);
            //    Main.SendCustomChatMessasge(player, "~w~[~b~FACTION~w~] Rank ~y~"+AccountManage.GetCharacterName(target)+" ~w~Be ~y~"+faction_data[AccountManage.GetPlayerGroup(target)].faction_rank[newrank]+"~w~ Taghir Yaft");
            //   Main.SendCustomChatMessasge(target, "~w~[~b~FACTION~w~] Rank Shoma Be ~y~"+faction_data[AccountManage.GetPlayerGroup(target)].faction_rank[newrank]+"~w~ Taghir Yaft");
        }
        else
        {
            //  Main.SendCustomChatMessasge(player, "~w~[~b~FACTION~w~] Rank ~y~" +  + " ~w~Be ~y~" + faction_data[AccountManage.GetPlayerGroup(target)].faction_rank[newrank] + "~w~ Taghir Yaft");
            Main.CreateMySqlCommand("UPDATE `characters` SET `group_rank`='" + newrank + "' WHERE `id`='" + characterid + "'");
        }
    }

    [RemoteEvent("EditRankName")]
    public void EditRankName(Player player, int rankid, string rankname)
    {
        if (AccountManage.GetPlayerLeader(player) != 1 || AccountManage.GetPlayerRank(player) <= 8)
        {
            return;
        }
        faction_data[GetPlayerGroupID(player)].faction_rank[rankid] = rankname;
        Main.CreateMySqlCommand("UPDATE `faction_rank` SET `rank_" + rankid + "`='" + rankname + "' WHERE `id`='" + GetPlayerGroupID(player) + "'");
    }

    /*  public void TryCreateFaction(Player Client)
      {
          if (Client.GetData<dynamic>("character_level") <= 4)
          {
              Main.SendCustomChatMessasge(Client, "Shoma Hanoz Level 5 Nashodid");
              return;
          }

          if (Main.GetPlayerMoney(Client) < 25000)
          {
              Main.SendCustomChatMessasge(Client, "Shoma $25,000 Baraye Tasis Faction Niyaz Darid");
              return;
          }
          if (AccountManage.GetPlayerGroup(Client) == 0)
          {
              InteractMenu.User_Input(Client, "input_faction_Create", "Esm Faction Ra Entekhab Konid", "", "Sakht Faction $25,000 Hazine Darad");
          }
          else
          {
              Main.SendCustomChatMessasge(Client, "Shoma Dar Faction Mibashid");

          }
      }*/
    [RemoteEvent("createFaction")]
    public static void CreateFaction(Player Client, string FactionName)
    {
        if (String.IsNullOrEmpty(FactionName))
        {
            Main.SendCustomChatMessasge(Client, "~r~[HATA]:~w~ Bunu yapamazsınız!");
            DisplayEditFaction(Client);
            return;
        }
        var pattern = "^[a-zA-Z ]*$";
        if (!System.Text.RegularExpressions.Regex.IsMatch(FactionName, pattern))
        {
            Main.SendCustomChatMessasge(Client, "~w~Sadece A'dan Z'ye kadar olan harfleri kullanabilirsiniz.");
            return;
        }
        if (FactionName.Length < 3 || FactionName.Length > 31)
        {
            Main.SendCustomChatMessasge(Client, "Adınız 3'ten az veya 31'den fazla karakter olamaz!");
            return;
        }
        if (Main.GetPlayerMoney(Client) < 1000000)
        {
            Main.SendCustomChatMessasge(Client, "Yeterli paranız yok!");
            return;
        }
        Main.GivePlayerMoney(Client, -1000000);
        Main.SendCustomChatMessasge(Client, "Organizasyon kurdunuz: ~g~" + FactionName + " .");

        for (int index = 0; index < faction_data.Count - 1; index++)
        {
            if (faction_data[index].faction_name == "empty" && faction_data[index].faction_leader == -1 && faction_data[index].faction_type == 5)
            {
                faction_data[index].faction_name = FactionName;
                faction_data[index].faction_leader = AccountManage.GetPlayerSQLID(Client);

                AccountManage.SetPlayerLeader(Client, 1);
                AccountManage.SetPlayerGroup(Client, index);
                AccountManage.SetPlayerRank(Client, 10);
                SaveFaction(index);
                Main.SavePlayerInformation(Client);
                return;
            }
        }
        Main.SendCustomChatMessasge(Client, "~r~Bunu yapamazsınız!");
    


    /* int index = faction_data.Count;
     faction_data.Add(new FactionEnum()
     {
         faction_id = index,
         faction_type = 4,
         faction_name = FactionName,
         faction_abbrev = "unknown",
         faction_leader = AccountManage.GetPlayerSQLID(Client),
         faction_motd = "Hello Boys",
         faction_color = "FFFFFF",
         faction_logo = "https://i.imgur.com/BRSSf6F.png",
         faction_description = "",
         faction_turf_color = 34,
     });
     AccountManage.SetPlayerGroup(Client, index);
     AccountManage.SetPlayerRank(Client, 10);
     AccountManage.SetPlayerLeader(Client, index);
     for (int i = 0; i < 20; i++)
     {
         faction_data[index].faction_armory_gun[i] = "0";
         faction_data[index].faction_armory_stock[i] = 0;
         faction_data[index].faction_armory_price[i] = 0;

     }

     faction_data[index].faction_armory_recurso = 0;
     faction_data[index].faction_armory_x = 0;
     faction_data[index].faction_armory_y = 0;
     faction_data[index].faction_armory_z = 0;

     faction_data[index].faction_armory_label = NAPI.TextLabel.CreateTextLabel("~y~~h~- ORUZARNICA ~b~" + faction_data[index].faction_name + "~y~ -~w~~h~~n~~n~~w~Use ~y~~h~y~h~~w~ To Open The Menu", new Vector3(faction_data[index].faction_armory_x, faction_data[index].faction_armory_y, faction_data[index].faction_armory_z + 0.3), 12, 0.3500f, 4, new Color(0, 122, 255, 150));

     for (int b = 0; b < MAX_FACTION_VEHICLES; b++)
     {
         faction_data[index].faction_vehicle_name[b] = "Livre";
         faction_data[index].faction_vehicle_owned[b] = "Unknown";
     }*/

}

public class requests_structer
    {
        public int character;
        public string name;
        public int level;
        public int phone;
    }

//cclose
    [Command("birlik")]
    public void Manage_Faction(Player player)
    {
        if (AccountManage.GetPlayerLeader(player) != 1)
        {
            Main.SendCustomChatMessasge(player, "Organizasyon lideri değilsiniz!");
            return;
        }
        System.Threading.Tasks.Task.Run(() =>
        {

            int factionid = GetPlayerGroupID(player);
            int membercount = 0;

            List<dynamic> members = new List<dynamic>();
            List<dynamic> ranks = new List<dynamic>();

            using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT `id`,`group`,`name`,`group_rank` FROM `characters` where `group`='" + factionid + "'";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetInt32("group") == factionid)
                    {
                        membercount++;
                        members.Add(new { character = reader.GetInt32("id"), name = reader.GetString("name"), rank = reader.GetInt32("group_rank") });
                    }
                }
                connection.Close();
            }

            using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM `faction_rank` where `id`='" + factionid + "'";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < MAX_FACTION_RANK; i++)
                    {
                        ranks.Add(new { name = reader.GetString("rank_" + i) });
                    }
                }

                connection.Close();
            }
            List<requests_structer> requests = new List<requests_structer>();

            using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT `name`,`id`,`player`,`factionid` FROM `faction_invite` where `factionid`='" + GetPlayerGroupID(player) + "'";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    requests.Add(new requests_structer { character = reader.GetInt32("player"), name = reader.GetString("name"), level = 0, phone = 0 });
                }
                connection.Close();
            }
            if (requests.Count > 0)
            {

                for (int i = 0; i < requests.Count; i++)
                {
                    using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT `id`,`level`,`character_cellphone` FROM `characters` where `id`='" + requests[i].character + "'";
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            requests[i].level = reader.GetInt32("level");
                            requests[i].phone = reader.GetInt32("character_cellphone");
                        }
                        connection.Close();
                    }
                }
            }

            List<dynamic> faction = new List<dynamic>();
            faction.Add(new { name = faction_data[factionid].faction_name, type = faction_data[factionid].faction_type, announce = faction_data[factionid].faction_motd, members = membercount });

            NAPI.Task.Run(() =>
            {
                

                player.TriggerEvent("showfactionmenu", NAPI.Util.ToJson(faction), NAPI.Util.ToJson(requests), NAPI.Util.ToJson(members), NAPI.Util.ToJson(ranks));
            });
        });
    }

    public static int GetGraffiti(Player client)
    {
        int gang = AccountManage.GetPlayerGroup(client);
        int totalRows = 0;
        try
        {
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM `graf` WHERE `band` = '" + gang + "';", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        totalRows++;
                    }
                }
                Mainpipeline.Close();
            }
        }
        catch (Exception e) { Console.WriteLine(e); }

        return totalRows;
    }

    public static int PrintBandsWith10RowsOrMore()
    {
        int numBands = 0;
        int band = -1;
        try
        {
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `band`, COUNT(*) AS `total_rows` FROM `graf` GROUP BY `band` HAVING `total_rows` >= 10;", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        band = reader.GetInt32(0);
                    }
                }
                Mainpipeline.Close();
            }
        }
        catch (Exception e) { Console.WriteLine(e); }
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var Player in players)
        {
            if (Player.GetData<dynamic>("status") == true)
            {
                if (band == AccountManage.GetPlayerGroup(Player))
                {
                    Player.SendChatMessage("10 dan fazla grafitti yaptığınız için $2000 aldınız.");
                    Main.GivePlayerMoney(Player, 2000);
                }
            }
        }
        return numBands;
    }

    [Command("spray")]
    public static void CMD_Spray(Player player)
    {
        if (FactionManage.GetPlayerGroupID(player) == 4 || FactionManage.GetPlayerGroupID(player) == 5 || FactionManage.GetPlayerGroupID(player) == 6 || FactionManage.GetPlayerGroupID(player) == 7)
        {

            if (player.HasData("graffiti"))
            {
                player.PlayAnimation("anim@amb@business@weed@weed_inspecting_lo_med_hi@", "weed_spraybottle_stand_spraying_02_inspectorfemale", 1);
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_cs_spray_can"), 6286, new Vector3(0.06, 0.00, -0.03), new Vector3(45, 90, 90));
                NAPI.Task.Run(() => 
                {
                    if (NAPI.Player.IsPlayerConnected(player))
                    {
                    try 
                    { 
                        player.StopAnimation();
                        BasicSync.DetachObject(player);
                        player.GetData<Graffiti>("graffiti").SetGang(FactionManage.GetPlayerGroupID(player)); 
                    } 
                    catch 
                    { 

                    } 
                    }
                }, 9000);
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    public static void SendFactionMessage(Player player, string message)
    {
        Main.SendCustomChatMessasge(player, "~b~[ORGANİZASYON] ~w~" + message);
    }

    public static int GetDutyStats(Player client)
    {
        if (client.HasData("duty"))
        {
            return client.GetData<dynamic>("duty");
        }
        return 0;
    }

//cclose
    public static void DisbandTheFaction(int group_id)
    {
        foreach (var item in NAPI.Pools.GetAllPlayers())
        {
            if (GetPlayerGroupID(item) == group_id)
            {
                faction_data[group_id].faction_name = "empty";
                NAPI.Data.SetEntityData(item, "duty", 0);
                Main.UpdatePlayerClothes(item);
                item.SetData("duty", 0);
                Outfits.RemovePlayerDutyOutfit(item);
                AccountManage.SetPlayerLeader(item, 0);
                AccountManage.SetPlayerGroup(item, 0);
                AccountManage.SetPlayerRank(item, 0);
                //Main.SavePlayerInformation(item);
                FactionManage.SendFactionMessage(item, " ~w~Sizin organizasyonunuz ~r~silindi~w~ !");
            }
        }

        using (MySqlConnection connection = new MySqlConnection(Main.myConnectionString))
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE `characters` SET `group`='0',`leader`='0',`group_rank`='0' WHERE `group` = " + group_id + "";
            command.ExecuteNonQuery();
            connection.Close();
        }

        faction_data[group_id].faction_type = 4;
        faction_data[group_id].faction_name = "empty";
        faction_data[group_id].faction_abbrev = "empty";
        faction_data[group_id].faction_leader = -1;
        faction_data[group_id].faction_motd = "empty";
        faction_data[group_id].faction_color = "empty";
        faction_data[group_id].faction_logo = "https://i.imgur.com/BRSSf6F.png";
        faction_data[group_id].faction_description = "Nema opisa";
        faction_data[group_id].faction_turf_color = 0;

        for (int i = 0; i < 20; i++)
        {
            faction_data[group_id].faction_armory_gun[i] = "0";
            faction_data[group_id].faction_armory_stock[i] = 0;
            faction_data[group_id].faction_armory_price[i] = 0;
        }

        faction_data[group_id].faction_armory_recurso = 0;
        faction_data[group_id].faction_armory_x = 0;
        faction_data[group_id].faction_armory_y = 0;
        faction_data[group_id].faction_armory_z = 0;

        //   faction_data[group_id].faction_armory_label = NAPI.TextLabel.CreateTextLabel("~y~~h~- ORUZARNICA ~b~" + faction_data[group_id].faction_name + "~y~ -~w~~h~~n~~n~~w~Use ~y~~h~y~h~~w~ To Open The Menu", new Vector3(faction_data[group_id].faction_armory_x, faction_data[group_id].faction_armory_y, faction_data[group_id].faction_armory_z + 0.3), 12, 0.3500f, 4, new Color(0, 122, 255, 150));
        for (int b = 0; b < MAX_FACTION_VEHICLES; b++)
        {
            faction_data[group_id].faction_vehicle_name[b] = "Livre";
            faction_data[group_id].faction_vehicle_owned[b] = "Unknown";
        }

        for (int i = 0; i < MAX_FACTION_RANK; i++)
        {
            faction_data[group_id].faction_rank[i] = "empty";
            faction_data[group_id].faction_salary[i] = 0;
        }
        SaveFaction(group_id);
    }


}

