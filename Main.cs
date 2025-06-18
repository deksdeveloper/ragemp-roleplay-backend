

using GTANetworkAPI;
using Infinity.Logger;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Discord;
using Discord.WebSocket;
using Discord.Rest;

public class Main : Script
{
    public static bool PAYDAY_READY = false;

    public static string SERVER_NAME = "LS Noire Roleplay - www.ls-noire.com";
    public static string SERVER_SIGLA = "LSNRP";
    public static string SERVER_WEBSITE = "www.ls-noire.com";
    public static string myConnectionString = "SERVER=localhost;DATABASE=s40595_rpvdb;UID=root;PASSWORD=;SSL Mode=none;pooling = false;convert zero datetime=True";


    public const string LabelColor = "~b~";
    public const string LabelCommandColor = "~y~"; 
    public const string LabelHighlightColor = "~r~"; 
    public const string NewLine = "~n~";


    public static bool CANINE_SYSTEM = true;

    public static List<TimerEx> emote_timer = new List<TimerEx>();


    public static List<dynamic> prison_spawns = new List<dynamic>();
    public static List<dynamic> crime_list = new List<dynamic>();

    public static Dictionary<Player, NetHandle> playerLabels = new Dictionary<Player, NetHandle>();
    public static bool[] admin_vehicle_spawned { get; set; } = new bool[20];
    public static Vehicle[] admin_vehicle { get; set; } = new Vehicle[20];
    public static int MAX_PLAYERS = 200;

    public static int HOSPITAL_TIME_EXECUTE = 2 * 90;
    public static int HOSPITAL_TIME_DEFAULT = 2 * 90;

    public static int PAYDAYMULTIPLIER = 1;

    public static float DEFAULT_VEHICLE_HEALTH = 500.0f;

    public int clothe_store_door_1, clothe_store_door_2, ammunation_pillbox_1, ammunation_pillbox_2, motorsport_parking_door1, motorsport_parking_door2, motorsport_main_door1, motorsport_main_door2, motorsport_right_office_door, motorsport_left_office_door, oficina_portao, oficina_porta;


    [Flags]
    public enum AnimationFlags
    {
        Loop = 1 << 0,
        StopOnLastFrame = 1 << 1,
        OnlyAnimateUpperBody = 1 << 4,
        AllowPlayerControl = 1 << 5,
        Cancellable = 1 << 7
    }

    private CrashLogger logger { get; set; }

    public Main()
    {
        var thread = new Thread(SQLThreadHandler)
        { IsBackground = true };
        thread.Start();


        MySqlConnection connection = new MySqlConnection(myConnectionString);
        connection.Open();
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE characters SET canteleport=1";
        command.ExecuteNonQuery();
        connection.Close();

        NAPI.Server.SetAutoSpawnOnConnect(false);
        NAPI.Server.SetAutoRespawnAfterDeath(false);
        NAPI.Server.SetGlobalServerChat(false);
        this.logger = new CrashLogger();
    }


    public static List<dynamic> metalic_color_list = new List<dynamic>();
    public static List<dynamic> weapon_list = new List<dynamic>();

    public static byte Server_Hours;
    public static byte Server_Minutes;
    public static byte Server_Sec;


    public static List<TimerEx> damageTimer = new List<TimerEx>();

    [ServerEvent(Event.ResourceStart)]
    public void OnResourceStart()
    {
        for (var i = 0; i < MAX_PLAYERS; i++)
        {
            emote_timer.Add(null);
            DialogSistem.iyiles_timer.Add(null);
            damageTimer.Add(null);
            PlayerVehicle.vehicle_data.Add(new PlayerVehicle.VehicleEnum { id = i });
        }
        for (int i = 0; i < 18; i++)
        {
            Inventory.NumberOfInventorySlot.Add(i);

        }
        Server_Hours = 9;
        Server_Minutes = 0;
        Server_Sec = 0;

        Police.PDCustomCloth.Add(194);
        Police.PDCustomCloth.Add(196);
        Police.PDCustomCloth.Add(197);
        Police.PDCustomCloth.Add(199);
        Police.PDCustomCloth.Add(198);


        NAPI.World.SetWeather(Weather.EXTRASUNNY);
        NAPI.World.SetTime(9, 0, 0);


        Main.CreateMySqlCommand("UPDATE users SET logged=0 WHERE logged=1");
        NAPI.Data.SetWorldData("SaveVehicles", 0);

        #region metalic colors
        metalic_color_list.Add(new { color_id = 0, color_name = "Metallic Black" });
        metalic_color_list.Add(new { color_id = 1, color_name = "Metallic Graphite Black" });
        metalic_color_list.Add(new { color_id = 2, color_name = "Metallic Black Steal" });
        metalic_color_list.Add(new { color_id = 3, color_name = "Metallic Dark Silver" });
        metalic_color_list.Add(new { color_id = 4, color_name = "Metallic Silver" });
        metalic_color_list.Add(new { color_id = 5, color_name = "Metallic Blue Silver" });
        metalic_color_list.Add(new { color_id = 6, color_name = "Metallic Steel Gray" });
        metalic_color_list.Add(new { color_id = 7, color_name = "Metallic Shadow Silver" });
        metalic_color_list.Add(new { color_id = 8, color_name = "Metallic Stone Silver" });
        metalic_color_list.Add(new { color_id = 9, color_name = "Metallic Midnight Silver" });
        metalic_color_list.Add(new { color_id = 10, color_name = "Metallic Gun Metal" });
        metalic_color_list.Add(new { color_id = 11, color_name = "Metallic Anthracite Grey" });
        metalic_color_list.Add(new { color_id = 27, color_name = "Metallic Red" });
        metalic_color_list.Add(new { color_id = 28, color_name = "Metallic Torino Red" });
        metalic_color_list.Add(new { color_id = 29, color_name = "Metallic Formula Red" });
        metalic_color_list.Add(new { color_id = 30, color_name = "Metallic Blaze Red" });
        metalic_color_list.Add(new { color_id = 31, color_name = "Metallic Graceful Red" });
        metalic_color_list.Add(new { color_id = 32, color_name = "Metallic Garnet Red" });
        metalic_color_list.Add(new { color_id = 33, color_name = "Metallic Desert Red" });
        metalic_color_list.Add(new { color_id = 34, color_name = "Metallic Cabernet Red" });
        metalic_color_list.Add(new { color_id = 35, color_name = "Metallic Candy Red" });
        metalic_color_list.Add(new { color_id = 36, color_name = "Metallic Sunrise Orange" });
        metalic_color_list.Add(new { color_id = 37, color_name = "Metallic Classic Gold" });
        metalic_color_list.Add(new { color_id = 38, color_name = "Metallic Orange" });
        metalic_color_list.Add(new { color_id = 49, color_name = "Metallic Dark Green" });
        metalic_color_list.Add(new { color_id = 50, color_name = "Metallic Racing Green" });
        metalic_color_list.Add(new { color_id = 51, color_name = "Metallic Sea Green" });
        metalic_color_list.Add(new { color_id = 52, color_name = "Metallic Olive Green" });
        metalic_color_list.Add(new { color_id = 53, color_name = "Metallic Green" });
        metalic_color_list.Add(new { color_id = 54, color_name = "Metallic Gasoline Blue Green" });
        metalic_color_list.Add(new { color_id = 61, color_name = "Metallic Midnight Blue" });
        metalic_color_list.Add(new { color_id = 62, color_name = "Metallic Dark Blue" });
        metalic_color_list.Add(new { color_id = 63, color_name = "Metallic Saxony Blue" });
        metalic_color_list.Add(new { color_id = 64, color_name = "Metallic Blue" });
        metalic_color_list.Add(new { color_id = 65, color_name = "Metallic Mariner Blue" });
        metalic_color_list.Add(new { color_id = 66, color_name = "Metallic Harbor Blue" });
        metalic_color_list.Add(new { color_id = 67, color_name = "Metallic Diamond Blue" });
        metalic_color_list.Add(new { color_id = 68, color_name = "Metallic Surf Blue" });
        metalic_color_list.Add(new { color_id = 69, color_name = "Metallic Nautical Blue" });
        metalic_color_list.Add(new { color_id = 70, color_name = "Metallic Bright Blue" });
        metalic_color_list.Add(new { color_id = 71, color_name = "Metallic Purple Blue" });
        metalic_color_list.Add(new { color_id = 72, color_name = "Metallic Spinnaker Blue" });
        metalic_color_list.Add(new { color_id = 73, color_name = "Metallic Ultra Blue" });
        metalic_color_list.Add(new { color_id = 74, color_name = "Metallic Bright Blue" });
        metalic_color_list.Add(new { color_id = 88, color_name = "Metallic Taxi Yellow" });
        metalic_color_list.Add(new { color_id = 89, color_name = "Metallic Race Yellow" });
        metalic_color_list.Add(new { color_id = 90, color_name = "Metallic Bronze" });
        metalic_color_list.Add(new { color_id = 91, color_name = "Metallic Yellow Bird" });
        metalic_color_list.Add(new { color_id = 92, color_name = "Metallic Lime" });
        metalic_color_list.Add(new { color_id = 93, color_name = "Metallic Champagne" });
        metalic_color_list.Add(new { color_id = 94, color_name = "Metallic Pueblo Beige" });
        metalic_color_list.Add(new { color_id = 95, color_name = "Metallic Dark Ivory" });
        metalic_color_list.Add(new { color_id = 96, color_name = "Metallic Choco Brown" });
        metalic_color_list.Add(new { color_id = 97, color_name = "Metallic Golden Brown" });
        metalic_color_list.Add(new { color_id = 98, color_name = "Metallic Light Brown" });
        metalic_color_list.Add(new { color_id = 99, color_name = "Metallic Straw Beige" });
        metalic_color_list.Add(new { color_id = 100, color_name = "Metallic Moss Brown" });
        metalic_color_list.Add(new { color_id = 101, color_name = "Metallic Biston Brown" });
        metalic_color_list.Add(new { color_id = 102, color_name = "Metallic Beechwood" });
        metalic_color_list.Add(new { color_id = 103, color_name = "Metallic Dark Beechwood" });
        metalic_color_list.Add(new { color_id = 104, color_name = "Metallic Choco Orange" });
        metalic_color_list.Add(new { color_id = 105, color_name = "Metallic Beach Sand" });
        metalic_color_list.Add(new { color_id = 106, color_name = "Metallic Sun Bleeched Sand" });
        metalic_color_list.Add(new { color_id = 107, color_name = "Metallic Cream" });
        metalic_color_list.Add(new { color_id = 111, color_name = "Metallic White" });
        metalic_color_list.Add(new { color_id = 112, color_name = "Metallic Frost White" });
        metalic_color_list.Add(new { color_id = 125, color_name = "Metallic Securicor Green" });
        metalic_color_list.Add(new { color_id = 137, color_name = "Metallic Vermillion Pink" });
        metalic_color_list.Add(new { color_id = 142, color_name = "Metallic Black Purple" });
        metalic_color_list.Add(new { color_id = 143, color_name = "Metallic Black Red" });
        metalic_color_list.Add(new { color_id = 145, color_name = "Metallic Purple" });
        metalic_color_list.Add(new { color_id = 146, color_name = "Metallic V Dark Blue" });
        metalic_color_list.Add(new { color_id = 150, color_name = "Metallic Lava Red" });
        #endregion metaliccolors

        weapon_list.Add(new { picture = "knife", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Knife), hash = -1716189206, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Nightstick), hash = 1737195953, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Hammer), hash = 1317494643, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Nightstick), hash = -102323637, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Dagger), hash = -1834847097, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Hatchet), hash = -102973651, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Knuckle), hash = -656458692, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Machete), hash = -581044007, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Flashlight), hash = -1951375401, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Wrench), hash = 419712736, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Bat), hash = -1786099057, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Battleaxe), hash = -853065399, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Stone_hatchet), hash = 940833800, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Pistol), hash = 453432689, classe = "pistol", type = "Handguns", damagePerHealth = 10 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Combatpistol), hash = 1593441988, classe = "pistol", type = "Handguns", damagePerHealth = 13 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Snspistol), hash = -1076751822, classe = "pistol", type = "Handguns", damagePerHealth = 8 });
        weapon_list.Add(new { picture = "102", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Heavypistol), hash = -771403250, classe = "pistol", type = "Handguns", damagePerHealth = 13 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Vintagepistol), hash = 137902532, classe = "pistol", type = "Handguns", damagePerHealth = 5 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Marksmanpistol), hash = -598887786, classe = "pistol", type = "Handguns", damagePerHealth = 10 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Appistol), hash = 584646201, classe = "pistol", type = "Handguns", damagePerHealth = 11 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Stungun), hash = 911657153, classe = "Tazer", type = "Handguns", damagePerHealth = 2 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Flaregun), hash = 1198879012, classe = "pistol", type = "Handguns", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Doubleaction), hash = -1746263880, classe = "pistol", type = "Handguns", damagePerHealth = 10 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Smg), hash = 736523883, classe = "Secundary", type = "Machine Guns", damagePerHealth = 7 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Assaultsmg), hash = -270015777, classe = "Secundary", type = "Machine Guns", damagePerHealth = 5 });
        weapon_list.Add(new { picture = "123", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Minismg), hash = -1121678507, classe = "Secundary", type = "Machine Guns", damagePerHealth = 5 });
        weapon_list.Add(new { picture = "149", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Pumpshotgun), hash = 487013001, classe = "Secundary", type = "Shotguns", damagePerHealth = 40 });
        weapon_list.Add(new { picture = "149", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Pumpshotgun_mk2), hash = 1432025498, classe = "Secundary", type = "Shotguns", damagePerHealth = 40 });
        weapon_list.Add(new { picture = "Pistol-Cwase", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Sawnoffshotgun), hash = 2017895192, classe = "Secundary", type = "Shotguns", damagePerHealth = 10 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Microsmg), hash = 324215364, classe = "Secundary", type = "Machine Guns", damagePerHealth = 5 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Machinepistol), hash = -619010992, classe = "Secundary", type = "Machine Guns", damagePerHealth = 5 });
        weapon_list.Add(new { picture = "pistol50", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Pistol50), hash = -1716589765, classe = "pistol", type = "Handguns", damagePerHealth = 19 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Crowbar), hash = -2067956739, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Golfclub), hash = 1141786504, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Switchblade), hash = -538741184, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Poolcue), hash = -1810795771, classe = "Melee", type = "Branca", damagePerHealth = 0 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Assaultrifle), hash = -1074790547, classe = "Primary", type = "Assault Rifles", damagePerHealth = 10 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Bullpuprifle), hash = -1654528753, classe = "Secundary", type = "Shotguns", damagePerHealth = 10 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Assaultshotgun), hash = -494615257, classe = "Secundary", type = "Shotguns", damagePerHealth = 20 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Musket), hash = -1466123874, classe = "Secundary", type = "Shotguns", damagePerHealth = 99 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Heavyshotgun), hash = 984333226, classe = "Secundary", type = "Shotguns", damagePerHealth = 10 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Doubleaction), hash = -275439685, classe = "Secundary", type = "Shotguns", damagePerHealth = 10 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Combatpdw), hash = 171789620, classe = "Secundary", type = "Machine Guns", damagePerHealth = 2 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Combatmg), hash = 2144741730, classe = "Secundary", type = "Machine Guns", damagePerHealth = 15 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Gusenberg), hash = 1627465347, classe = "Secundary", type = "Machine Guns", damagePerHealth = 10 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Revolver), hash = -1045183535, classe = "pistol", type = "Handguns", damagePerHealth = 10 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Carbinerifle), hash = -2084633992, classe = "Primary", type = "Assault Rifles", damagePerHealth = 3 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Advancedrifle), hash = -1357824103, classe = "Primary", type = "Assault Rifles", damagePerHealth = 1 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Specialcarbine), hash = -1063057011, classe = "Primary", type = "Assault Rifles", damagePerHealth = 6 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Bullpuprifle), hash = 2132975508, classe = "Primary", type = "Assault Rifles", damagePerHealth = 3 });
        weapon_list.Add(new { picture = "131", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Compactrifle), hash = 1649403952, classe = "Primary", type = "Assault Rifles", damagePerHealth = 2 });
        weapon_list.Add(new { picture = "136", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Sniperrifle), hash = 100416529, classe = "Primary", type = "Sniper Rifles", damagePerHealth = 70 });
        weapon_list.Add(new { picture = "Pistol-Case", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Heavysniper), hash = 205991906, classe = "Primary", type = "Sniper Rifles", damagePerHealth = 130 });
        weapon_list.Add(new { picture = "136", model = Enum.GetName(typeof(WeaponHash), WeaponHash.Fireextinguisher), hash = 101631238, classe = "Melee", type = "Branca", damagePerHealth = 130 });





        foreach (var weapon in Main.weapon_list)
        {
            Inventory.itens_available.Add(new Inventory.itemEnum { picture = weapon.picture, id = Inventory.itens_available.Count, name = weapon.model, Useable = true, description = "", guest = Inventory.ITEM_TYPE_WEAPON, hash = 1877891248, position = 0.8f, weight = 2.0f });
        }



        NAPI.Util.ConsoleOutput("Oyun modu yükleniyor...");
        NAPI.World.RemoveIpl("facelobbyfake");
        NAPI.World.RequestIpl("facelobby");
        NAPI.World.RemoveIpl("fakeint");
        NAPI.World.RemoveIpl("shutter_closed");
        NAPI.World.RequestIpl("shr_int");
        NAPI.World.RequestIpl("shr_int");
        NAPI.World.RemoveIpl("v_tunnel_hole");
        NAPI.World.RemoveIpl("v_tunnel_hole_lod");
        NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_0_biker_dlc_int_01_milo");
        NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_1_biker_dlc_int_02_milo");
        NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_2_biker_dlc_int_ware01_milo");
        NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_3_biker_dlc_int_ware02_milo");
        NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_4_biker_dlc_int_ware03_milo");
        NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_5_biker_dlc_int_ware04_milo");
        NAPI.World.RequestIpl("bkr_biker_interior_placement_interior_6_biker_dlc_int_ware05_milo");
        NAPI.World.RequestIpl("ex_exec_warehouse_placement_interior_1_int_warehouse_s_dlc_milo");
        NAPI.World.RequestIpl("ex_exec_warehouse_placement_interior_0_int_warehouse_m_dlc_milo");
        NAPI.World.RequestIpl("ex_exec_warehouse_placement_interior_2_int_warehouse_l_dlc_milo");
        NAPI.World.RequestIpl("imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
        NAPI.World.RequestIpl("bkr_bi_hw1_13_int");
        NAPI.World.RemoveIpl("rc12b_fixed");
        NAPI.World.RemoveIpl("rc12b_destroyed");
        NAPI.World.RequestIpl("rc12b_default");
        NAPI.World.RequestIpl("coronertrash");
        NAPI.World.RequestIpl("Coroner_Int_On");
        NAPI.World.RequestIpl("apa_v_mp_h_01_a");
        NAPI.World.RequestIpl("apa_v_mp_h_01_c");
        NAPI.World.RequestIpl("apa_v_mp_h_01_b");
        NAPI.World.RequestIpl("apa_v_mp_h_02_a");
        NAPI.World.RequestIpl("apa_v_mp_h_02_c");
        NAPI.World.RequestIpl("apa_v_mp_h_02_b");
        NAPI.World.RequestIpl("apa_v_mp_h_03_a");
        NAPI.World.RequestIpl("apa_v_mp_h_03_c");
        NAPI.World.RequestIpl("apa_v_mp_h_03_b");
        NAPI.World.RequestIpl("apa_v_mp_h_04_a");
        NAPI.World.RequestIpl("apa_v_mp_h_04_c");
        NAPI.World.RequestIpl("apa_v_mp_h_04_b");
        NAPI.World.RequestIpl("apa_v_mp_h_05_a");
        NAPI.World.RequestIpl("apa_v_mp_h_05_c");
        NAPI.World.RequestIpl("apa_v_mp_h_05_b");
        NAPI.World.RequestIpl("apa_v_mp_h_06_a");
        NAPI.World.RequestIpl("apa_v_mp_h_06_c");
        NAPI.World.RequestIpl("apa_v_mp_h_06_b");
        NAPI.World.RequestIpl("apa_v_mp_h_07_a");
        NAPI.World.RequestIpl("apa_v_mp_h_07_c");
        NAPI.World.RequestIpl("apa_v_mp_h_07_b");
        NAPI.World.RequestIpl("apa_v_mp_h_08_a");
        NAPI.World.RequestIpl("apa_v_mp_h_08_c");
        NAPI.World.RequestIpl("apa_v_mp_h_08_b");
        NAPI.World.RequestIpl("ba_barriers_case1");
        NAPI.World.RequestIpl("ba_case1_madonna");
        NAPI.World.RequestIpl("v_sheriff2");
        NAPI.World.RequestIpl("v_sheriff");
        NAPI.World.RequestIpl("post_hiest_unload");
        NAPI.World.RequestIpl("farm");
        NAPI.World.RequestIpl("farm_props");
        NAPI.World.RequestIpl("farm_int");




        foreach (var Player in NAPI.Pools.GetAllPlayers()) NAPI.Player.FreezePlayerTime(Player, true);

        if (NAPI.Resource.HasSetting(this, "XP_RATE")) Economy.XP_RATE = NAPI.Resource.GetSetting<int>(this, "XP_RATE");
        if (NAPI.Resource.HasSetting(this, "XP_RATE_HOURLY")) Economy.XP_RATE = NAPI.Resource.GetSetting<int>(this, "XP_RATE_HOURLY");

        NAPI.Util.ConsoleOutput("[Veritabanı]: Meslekler yüklendi.");
        NAPI.Util.ConsoleOutput("[Veritabanı]: İşyerleri yüklendi.");
        BusinessManage.BusinessInit();

        NAPI.Util.ConsoleOutput("[Veritabanı]: Araçlar yüklendi.");
        //Dealership.CarDealershipInit();


        NAPI.Util.ConsoleOutput("[Veritabanı]: Birlikler yüklendi.");
        FactionManage.FactionInit();

        EvSistemi.LoadHousesFromDatabase();


        NAPI.Util.ConsoleOutput("[Veritabanı]: Envanter eşyaları yüklendi.");
        WerehouseManage.WerehouseManageInit();

        NAPI.Util.ConsoleOutput("[Veritabanı]: Kapılar yüklendi.");
        DoorLock.DoorLockInit();


        NAPI.Util.ConsoleOutput("[Veritabanı]: Kıyafetler yüklendi.");
        Outfits.OutfitTester_Init();

        NAPI.Util.ConsoleOutput("[Veritabanı]: Garajlar yüklendi.");
        GarageSys.GarageSystemInit();


        NAPI.Util.ConsoleOutput("[Veritabanı]: Radyo istasyonları yüklendi.");
        XMR.XMRs();

        TelefonSistem.LoadRehber();

        PropertySystem.EntraceSystemInit();

        PAYDAY_READY = false;

        prison_spawns.Add(new { position = new Vector3(461.3749, -981.0369, 34.21715), rotation = new Vector3(0, 0, -90.01505) });
        prison_spawns.Add(new { position = new Vector3(461.5625, -993.0786, 34.18745), rotation = new Vector3(0, 0, -91.31867) });
        prison_spawns.Add(new { position = new Vector3(455.70325, -981.6282, 34.21715), rotation = new Vector3(0, 0, -88.90997) });

        prison_spawns.Add(new { position = new Vector3(455.2427, -992.9408, 34.187447), rotation = new Vector3(0, 0, -88.90997) });
        prison_spawns.Add(new { position = new Vector3(449.80823, -981.18677, 34.217148), rotation = new Vector3(0, 0, -88.90997) });
        prison_spawns.Add(new { position = new Vector3(449.45215, -993.6211, 34.187447), rotation = new Vector3(0, 0, -88.90997) });
        //   prison_spawns.Add(new { position = new Vector3(480.76, -994.48, 24.91), rotation = new Vector3(0, 0, -88.90997) });




        ColShape col = NAPI.ColShape.Create2DColShape(113.79f, -1290f, 150, 10, 0);
        col.SetData<dynamic>("ColName", "Club1");

        NAPI.Data.SetWorldData("announceTime", 1);

        NAPI.Util.ConsoleOutput(" ");
        NAPI.Util.ConsoleOutput(" ");
        NAPI.Util.ConsoleOutput("------------------------");
        NAPI.Util.ConsoleOutput("" + Main.SERVER_NAME + ";" + " yüklendi! Geliştirici: Deks - Krips");
        NAPI.Util.ConsoleOutput("------------------------");
        NAPI.Server.SetCommandErrorMessage(Translation.invalid_command);
        GlobalTime();
       // WarTimer();
        UpdateTime();
        CheckRoundClock();
        AccountDataSave();
        AFK_System();
        PlayerAccountSave();
        UpdateWeapon();
        DeksBugDuzelt();

    }

    public static string FormatNumber(int number)
    {
        string formatted = number.ToString("C", new CultureInfo("en-US"));
        return formatted;
    }
    public static void GivePlayerEXP(Player Client, int amount)
    {
        if (Client.GetData<dynamic>("character_level") >= 0)
        {
            int new_level = (50 * (Client.GetData<dynamic>("character_level")) * (Client.GetData<dynamic>("character_level")) * (Client.GetData<dynamic>("character_level")) - 150 * (Client.GetData<dynamic>("character_level")) * (Client.GetData<dynamic>("character_level")) + 600 * (Client.GetData<dynamic>("character_level"))) / 5;

            Client.TriggerEvent("updateRankBar", Client.GetData<dynamic>("character_level"), new_level, Client.GetData<dynamic>("character_exp"), Client.GetData<dynamic>("character_exp") + amount, Client.GetData<dynamic>("character_level"));

            Client.SetData<dynamic>("character_exp", Client.GetData<dynamic>("character_exp") + amount);

            if (Client.GetData<dynamic>("character_exp") >= new_level)
            {
                int next_level = Client.GetData<dynamic>("character_level") + 1;

                ShowColorShard(Client, "Level Up !", string.Format(Translation.shard_give_experience, new_level.ToString("N0"), next_level), 69, 10, 7000);
                Client.SetData<dynamic>("character_level", Client.GetData<dynamic>("character_level") + 1);
                GivePlayerEXP(Client, -new_level);
            }
        }
    }

    [ServerEvent(Event.ResourceStopEx)]
    public void OnResourceStop(string resourcename)
    {
        var players = NAPI.Pools.GetAllPlayers();

        foreach (var Player in players)
        {
            if (Player.GetData<dynamic>("status") == true)
            {
                Main.SavePlayerInformation(Player);

            }
        }

    }




    [RemoteEvent("enableChatInput")]
    public void enableChatInput(Player Client, bool toggle)
    {
        Client.SetSharedData("enableChatInput", toggle);
    }

    [RemoteEvent("enableVoiceInput")]
    public void enableVoiceInput(Player Client, bool toggle)
    {
        Client.SetSharedData("enableVoiceInput", toggle);
    }

    [RemoteEvent("OnPlayerCreateWaypoint")]
    public void OnplayerCreateWaypoint(Player Client, float x, float y, float z)
    {
        if (AccountManage.GetPlayerAdmin(Client) > 0)
        {
            if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
            {

                Vehicle vehicle = Client.Vehicle;
                vehicle.Position = new Vector3(x, y, z);
                Client.SetIntoVehicle(vehicle, (int)VehicleSeat.Driver);

            }
            else
            {
                NAPI.Entity.SetEntityPosition(Client, new Vector3(x, y, z));
            }
        }
    }

    [ServerEvent(Event.PlayerEnterColshape)]
    public void OnPlayerEnterColshape(ColShape shape, Player Client)
    {
        if (Client.GetData<dynamic>("status") == true)
        {
            Client.SetData<dynamic>("InColshape", shape);

            if (shape.HasData("PB_index"))
            {
                PropertySystem.OnPlayerEnterColshape(Client, shape);
            }
            if (shape.HasData("ColName") && shape.GetData<dynamic>("ColName") == "Bank_Salary")
            {
                Client.TriggerEvent("Display_Player_NotfMenu", "LS-Bank", " $ " + GetSalaryFromBank(Client), "Na vasem racunu");
            }
            if (shape.HasData("ColName") && shape.GetData<dynamic>("ColName") == "BusinessShop")
            {
                Client.SetData<dynamic>("InBusinessShop", true);
            }

            DriverLicense.OnEnterDynamicArea(Client, shape);
            Police.OnEnterDynamicArea(Client, shape);
        }


    }

    [ServerEvent(Event.PlayerExitColshape)]
    public void OnPlayerExitColShape(ColShape shape, Player Client)
    {

        Client.SetData<dynamic>("InColshape", null);


        if (shape.HasData("PB_index"))
        {
            PropertySystem.OnPlayerExitColshape(Client, shape);
        }
        if (shape.HasData("ColName") && shape.GetData<dynamic>("ColName") == "Bank_Salary")
        {
            Client.TriggerEvent("Destroy_NotfMenu");
        }

        if (shape.GetData<dynamic>("ColName") == "BusinessShop")
        {
            Client.SetData<dynamic>("InBusinessShop", false);
        }

        if (Client.GetData<dynamic>("status") == true)
        {

            if (Client.HasData("InCCTV") && Client.GetData<dynamic>("InCCTV") != 2 && shape.GetData<dynamic>("ColName") == "camaccess")
            {

                foreach (var item in Security_Camera.camsaccess)
                {
                    if (shape.Handle == item.Colshape.Handle)
                    {
                        item.isinuse = false;
                        Client.ResetData("InCCTV");
                        Main.Display_HUD(Client, true);
                        return;
                    }
                }
            }

            Police.OnLeaveDynamicArea(Client, shape);

            var index = 0;
            foreach (var business in BusinessManage.business_list)
            {
                if (shape == business.business_object_Area)
                {
                    NAPI.Data.SetEntityData(Client, "player_in_business", -1);
                }
                if (shape == business.business_marker_area)
                {
                    Client.TriggerEvent("BusinessPlayerMenuHide");
                    Client.TriggerEvent("DealerShipMenuHide");

                }
                index++;
            }
        }
    }

    public static void DisplayRadar(Player Client, bool toggle)
    {

        if (Client.GetData<dynamic>("DisplayRadar") != toggle)
        {
            Client.TriggerEvent("UI:DisplayRadar", toggle);
        }
        Client.SetData<dynamic>("DisplayRadar", toggle);


    }


    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Player Client)
    {
        try
        {
            Client.Dimension = 90000;
            Client.SetData<dynamic>("character_hotel", -1);
            Client.SetData<dynamic>("character_hotel_left", 0);
            Client.SetData<dynamic>("InsideHotelID", -1);

            Client.TriggerEvent("check_client_csharp");

            Client.SetSharedData("UI_Stats", true);
            Client.TriggerEvent("Discord_Update", SERVER_NAME +  " (Giriş yapıyor.)", SERVER_WEBSITE);

            Client.Name = Client.SocialClubName;
            Client.SetSharedData("SubTitle", " ");

            Client.SetData<dynamic>("using_inventory", false);

            NAPI.World.SetTime(Server_Hours, Server_Minutes, Server_Sec);
            Client.TriggerEvent("TimeOfDay", "" + Server_Hours + ":" + Server_Minutes + "");

            Client.SetData<dynamic>("report_id", -1);
            Client.SetData<dynamic>("Respone_Report", -1);



            Client.SetSharedData("remoteID", Client.Value);


            Client.SetData<dynamic>("PaydayTime", 3600);

            Client.SetData<dynamic>("admin_duty", 0);
            Client.SetSharedData("admin_shared_name", 0);

            Client.ResetData("school_tutorial");
            Client.SetData<dynamic>("food_delivery", 0);
            Client.SetSharedData("emoteTimeout", 0);
            Client.SetSharedData("falando", false);
            Client.SetData<dynamic>("handsup", false);
            Client.SetData<dynamic>("connectSeconds", 0);
            Client.SetData<dynamic>("character_cellphone", 0);
            Client.TriggerEvent("RemoveAllBlips");
            Client.SetSharedData("emoteText", "");
            Client.SetData<dynamic>("BeingDragged", false);

            Client.SetData<dynamic>("shirt_enable", true);
            Client.SetData<dynamic>("legs_enable", true);
            Client.SetData<dynamic>("shoes_enable", true);

            Client.SetData<dynamic>("phone_enable", false);

            Client.TriggerEvent("enableInteriorProp", 247297, "weed_growthf_stage3");
            Client.TriggerEvent("enableInteriorProp", 247297, "weed_growthi_stage2");
            Client.TriggerEvent("enableInteriorProp", 247297, "weed_growthh_stage3");
            Client.TriggerEvent("enableInteriorProp", 247297, "weed_growthd_stage3");
            Client.TriggerEvent("enableInteriorProp", 247297, "weed_growthc_stage2");
            Client.TriggerEvent("enableInteriorProp", 247297, "weed_growthb_stage1");
            Client.TriggerEvent("enableInteriorProp", 247297, "weed_drying");
            Client.TriggerEvent("enableInteriorProp", 247297, "weed_chairs");
            Client.TriggerEvent("enableInteriorProp", 247297, "weed_upgrade_equip");
            Client.TriggerEvent("enableInteriorProp", 247297, "weed_production");
            Client.TriggerEvent("enableInteriorProp", 247297, "weed_hosef");


            Client.TriggerEvent("enableInteriorProp", 247553, "coke_cut_05");
            Client.TriggerEvent("enableInteriorProp", 247553, "coke_press_upgrade");
            Client.TriggerEvent("enableInteriorProp", 247553, "equipment_upgrade");
            Client.TriggerEvent("enableInteriorProp", 247553, "production_upgrade");
            Client.TriggerEvent("enableInteriorProp", 247553, "security_high");
            Client.TriggerEvent("enableInteriorProp", 247553, "set_up");
            Client.TriggerEvent("enableInteriorProp", 247553, "table_equipment_upgrade");


            Client.TriggerEvent("enableInteriorProp", 247041, "meth_lab_setup");
            Client.TriggerEvent("enableInteriorProp", 247041, "meth_lab_production");
            Client.TriggerEvent("enableInteriorProp", 247041, "meth_lab_security_high");
            Client.TriggerEvent("enableInteriorProp", 247041, "meth_lab_upgrade");

            Client.TriggerEvent("enableInteriorProp", 246529, "cash_large");
            Client.TriggerEvent("enableInteriorProp", 246529, "coke_large");
            Client.TriggerEvent("enableInteriorProp", 246529, "counterfeit_large");
            Client.TriggerEvent("enableInteriorProp", 246529, "id_large");
            Client.TriggerEvent("enableInteriorProp", 246529, "meth_large");
            Client.TriggerEvent("enableInteriorProp", 246529, "weed_large");



            Client.TriggerEvent("enableInteriorProp", 246273, "cash_stash3");
            Client.TriggerEvent("enableInteriorProp", 246273, "coke_stash3");
            Client.TriggerEvent("enableInteriorProp", 246273, "counterfeit_stash3");
            Client.TriggerEvent("enableInteriorProp", 246273, "weed_stash3");
            Client.TriggerEvent("enableInteriorProp", 246273, "id_stash3");
            Client.TriggerEvent("enableInteriorProp", 246273, "meth_stash3");

            Client.TriggerEvent("enableInteriorProp", 252673, "branded_style_set");
            Client.TriggerEvent("enableInteriorProp", 252673, "car_floor_hatch");
            Client.TriggerEvent("enableInteriorProp", 252673, "door_blocker");

            NAPI.World.RequestIpl("canyonrvrdeep");
            NAPI.World.RequestIpl("canyonrvrshallow");

            NAPI.World.DeleteWorldProp(3053754761, new Vector3(-596, 2088, 131.34), 3);

            NAPI.World.DeleteWorldProp(-1578791031, new Vector3(-1044, 4911.6, 208.5), 3);
            NAPI.World.DeleteWorldProp(-13153749, new Vector3(-1043, 4909.3, 208.4), 3);



            Client.SetData<dynamic>("curar_offerBy", null);
            Client.SetData<dynamic>("curar_offerPrice", 0);

            Client.SetData<dynamic>("AFK_Time", 900);
            Client.SetSharedData("Radio_Status", false);

            Client.TriggerEvent("screenFadeIn", 1000);
            Client.TriggerEvent("getPedOverlay");


            Client.SetData<dynamic>("SpeedLimit", false);
            Client.SetData<dynamic>("SpeedLimitValue", 0);

            Client.SetData<dynamic>("globalBrowser", false);

            Client.SetData<dynamic>("displayMessage_Timer", -1);

            ResetSQLData(Client);
            Client.SetSharedData("DisableExitVehicle", false);
            Client.SetSharedData("DisableVehicleMove", false);

            Client.TriggerEvent("setResistStage", 0);
            Client.SetData<dynamic>("shipment", false);

            PlayerVehicle.ResetPlayerVehicleData(Client);
            Inventory.ResetInventoryVariables(Client);


            Client.SetData<dynamic>("status", false);
            Client.SetSharedData("Injured", 0);
            Client.SetData<dynamic>("group_invite", -1);
            Client.SetData<dynamic>("group_inviteBy", -1);
            Client.SetData<dynamic>("firstJoinned", false);

            Client.SetData<dynamic>("playerCuffed", 0);

            Client.SetData<dynamic>("General_CEF", false);


            NAPI.Data.SetEntityData(Client, "ShowTextForPlayer", -1);
            NAPI.Data.SetEntityData(Client, "LastTransaction", -1);
            NAPI.Data.SetEntityData(Client, "player_in_business", -1);
            NAPI.Data.SetEntityData(Client, "MainProgressBar", false);
            NAPI.Data.SetEntityData(Client, "MainProgressText", false);
            NAPI.Data.SetEntityData(Client, "Handsup", false);

            Client.SetData<dynamic>("inHelp", false);
            Client.SetData<dynamic>("IsAnyMenuOpen", false);

            Client.SetData<dynamic>("jobDuty", 0);


            Client.SetData<dynamic>("mechanic_color", 0);
            Client.SetData<dynamic>("MechOfferBy", -1);
            Client.SetData<dynamic>("MechOfferPrice", 0);
            Client.SetData<dynamic>("repaingPendent", false);

            Client.SetData<dynamic>("player_teleport", false);

            Client.SetData<dynamic>("TaxiFee", 0);

            Client.SetData<dynamic>("player_garbage_attach", false);


            Client.SetData<dynamic>("fishing", false);
            Client.SetData<dynamic>("fishingCaptured", -1);

            Client.SetData<dynamic>("garbage_id", -1);

            Client.SetData<dynamic>("in_meth_area", false);
            Client.SetData<dynamic>("in_meth_area2", false);

            Client.Dimension = (uint)getIdFromClient(Client);


            OnPlayerFinishedDownloadHandler(Client);



            WeaponManage.OnPlayerConnect(Client);
            RobberyNPC.OnPlayerConnect(Client);
            Inventory.OnPlayerConnected(Client);
            Client.SetData<dynamic>("inEffect_weed", -1);
            Client.SetData<dynamic>("inEffect_heroin", -1);



            for (int i = 0; i < 10; i++)
            {
                Client.SetData<dynamic>("animation_shortcut_dict_" + i, "");
                Client.SetData<dynamic>("animation_shortcut_state_" + i, "");
                Client.SetData<dynamic>("animation_shortcut_flag_" + i, 0);
            }


            Client.SetData<dynamic>("Enable_K_Menu", false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void IfExistSetLoggedStats(Player Client)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandText = "SELECT socialclubname,logged FROM `users` WHERE `socialclubname` = '" + Client.SocialClubName + "'";
            query.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query))
            {
                da.Fill(dt);
            }
            int i = 0;
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {

            }
            else
            {
                query.CommandText = "UPDATE users SET logged=0 WHERE socialclubname='" + Client.SocialClubName + "'";
                query.ExecuteNonQuery();
            }
            Mainpipeline.Close();

        }

    }

    [ServerEvent(Event.PlayerDisconnected)]
    public void OnPlayerDisconnected(Player Client, DisconnectionType type, string reason)
    {

        try
        {
            IfExistSetLoggedStats(Client);

            Client.TriggerEvent("factionchange", 0);
            if (Client.GetData<dynamic>("status") == true)
            {
                List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(20, Client);
                switch (type)
                {
                    case DisconnectionType.Left:
                        {
                            foreach (Player item in proxPlayers)
                            {
                                if (Client != item)
                                {
                                    item.TriggerEvent("Send_ToChat", "", "<font color ='#BDBDBD'>" + UsefullyRP.GetPlayerNameToTarget(Client, item) + " sunucudan ayrıldı. (Kendi İsteğiyle)</font>");
                                }
                            }
                            Client.TriggerEvent("Discord_Update", SERVER_NAME + " (Çıkış Yapıyor)", SERVER_WEBSITE);
                            break;
                        }

                    case DisconnectionType.Timeout:
                        {
                            foreach (Player item in proxPlayers)
                            {
                                if (Client != item)
                                {
                                    item.TriggerEvent("Send_ToChat", "", "<font color ='#BDBDBD'>" + UsefullyRP.GetPlayerNameToTarget(Client, item) + " sunucudan ayrıldı. (Zaman Aşımı/Crash)</font>");
                                }
                            }
                            Client.TriggerEvent("Discord_Update", SERVER_NAME + " (Bağlantı Kesildi)", SERVER_WEBSITE);
                            break;
                        }

                    case DisconnectionType.Kicked:
                        {
                            foreach (Player item in proxPlayers)
                            {
                                if (Client != item)
                                {
                                    item.TriggerEvent("Send_ToChat", "", "<font color ='#BDBDBD'>" + UsefullyRP.GetPlayerNameToTarget(Client, item) + " sunucudan ayrıldı. (Atıldı/Yasaklandı)</font>");
                                }
                            }
                            Client.TriggerEvent("Discord_Update", SERVER_NAME + " (Sunucudan Atıldı)", SERVER_WEBSITE);
                            break;
                        }

                    default:
                        break;
                }

                XMR.OnPlayerDisconnect(Client);
                AdminReport.OnPlayerDisconnected(Client);
                PlayerVehicle.PlayerDisconnectVeh(Client);
                Main.CreateMySqlCommand("UPDATE characters SET loggedin=0 WHERE id='" + AccountManage.GetPlayerSQLID(Client) + "'");
                if (Client.GetData<int>("oyuncuAramada") != TelefonSistem.ARAMA_BOS)
                {
                    TelefonSistem.CagriRed(Client);
                }
                InteractMenu_New.Reset_ClientSide_Variable(Client);

                WeaponManage.SaveWeapons(Client);

                Main.SavePlayerInformation(Client);

                Inventory.OnPlayerDisconnect(Client);

                Police.Call_OnDisconect(Client);


                faction_blip.OnPlayerDisconect(Client);

                Services.Remove_Service(Client);

                Client.ResetData("AnimationMenu");

                if (Client.HasData("Refueling"))
                {
                    Client.ResetData("Refueling");
                }

                Client.ResetSharedData("DisableExitVehicle");

                Client.ResetSharedData("DisableVehicleMove");

                NAPI.Data.SetEntityData(Client, "player_in_business", -1);

                Client.SetData<dynamic>("group_inviteBy", -1);
                Client.SetData<dynamic>("group_invite", -1);


                PlayerVehicle.ResetPlayerVehicleData(Client);



            }
        }
        catch (Exception e)
        {
            NAPI.Util.ConsoleOutput("[Crash] " + e.Message + " " + e.StackTrace);
        }

    }

    public static string EMBED_WHITE = "<font color='#ffffff'>";
    public static string EMBED_GREY = "<font color='#999999'>";
    public static string EMBED_YELLOW = "<font color='#EDD415'>";
    public static string EMBED_PURPLE = "<font color='#8365E0'>";
    public static string EMBED_ORANGE = "<font color='#FF9924'>";
    public static string EMBED_RED = "<font color='#FF0400'>";
    public static string EMBED_LIGHTRED = "<font color='#F55653'>";
    public static string EMBED_GREEN = "<font color='#1AC211'>";
    public static string EMBED_LIGHTGREEN = "<font color='#72DB4F'>";
    public static string EMBED_LIGHTBLUE = "<font color='#3973FA'>";
    public static string EMBED_BLUE = "<font color='#2F84FA'>";
    public static string EMBED_CYAN = "<font color='#05E7EB'>";
    public static string EMBED_PINK = "<font color='#FF6EE4'>";
    public static string EMBED_SERVER = "<font color='#009999'>";
    public static string EMBED_ROLEPLAY = "<font color='#C2A2DA'>";
    public static string EMBED_VIP = "<font color='#73FA66'>";

    public static string EMBED_COP_Message = "<font color='#3575FF'>";


    public static string EMBED_GROVE = "<font color='#00D000'>";
    public static string EMBED_BALLAS = "<font color='#00D000'>";
    public static string EMBED_VAGOS = "<font color='#FBDC04'>";
    public static string EMBED_AZTECAS = "<font color='#01FCFF'>";
    public static string EMBED_SANNEWS = "<font color='#E9B6B7'>";

    public static string EMBED_REPORT = "<font color='#ED8C37'>";
    public static string EMBED_CELLPHONE = "<font color='#E1EAED'>";
    public static string EMBED_CELLPHONE_2 = "<font color='#B0D4C1'>";


    public static string EMBED_NOOB_1 = "<font color='#009999'>";
    public static string EMBED_NOOB_2 = "<font color='#009966'>";

    public static void SendMessageToPlayer(Player Client, string message)
    {
        Main.SendCustomChatMessasge(Client, message);
    }

    public static void SendMessageToAll(string message)
    {
        foreach (var Player in NAPI.Pools.GetAllPlayers())
        {
            if (Player.GetData<dynamic>("status") == true)
            {
                Main.SendCustomChatMessasge(Player, message);
            }
        }
    }

    public static void SendMessageWithTagToPlayer(Player Client, string tag, string message)
    {
        Main.SendCustomChatMessasge(Client, tag + EMBED_WHITE + " " + message);
    }

    public static void SendMessageWithTagToAll(string tag, string message)
    {
        foreach (var Player in NAPI.Pools.GetAllPlayers())
        {
            if (Player.GetData<dynamic>("status") == true) Main.SendCustomChatMessasge(Player, tag + EMBED_WHITE + " " + message);
        }
    }

    [RemoteEvent("server:pressKeyT")]
    public static void PressKeyT(Player player)
    {
        NAPI.ClientEvent.TriggerClientEvent(player, "client:chatKey");
    }

    [RemoteEvent("server:onPlayerMessage")]
    public static void OnPlayerMessage(Player Client, string message)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }

        if (Client.HasData("Chat_Timeout") && Client.GetData<dynamic>("Chat_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
        {
            SendErrorMessage(Client, "Çok hızlı mesaj yazdığınız için mesaj gönderilemedi.");
            return;
        }
        Client.SetData<dynamic>("Chat_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 600);

        if (Client.GetData<int>("oyuncuAramada") == TelefonSistem.ARAMA_KONUSUYOR)
        {            
            TelefonSistem.MesajGonder(Client, message);

            List<Player> seksPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(18, Client);
            foreach (Player target in seksPlayers)
            {
                if (target.GetData<dynamic>("status") == true)
                {
                    if (Client.GetData<dynamic>("admin_duty") == 1)
                    {
                        Main.SendCustomChatMessasge(target, EMBED_WHITE + "(( <font color='#F20000'>" + adminCommands.GetPlayerAdminRank(Client) + " " + AccountManage.GetCharacterName(Client) + ": " + EMBED_WHITE + "" + message + EMBED_WHITE + " ))");
                    }
                    else
                    {
                        if (Client.GetSharedData<dynamic>("using_mask"))
                        {
                            target.TriggerEvent("Send_ToChat", "", "" + Translation.chat_mask_type + "" + AccountManage.GetPlayerSQLID(Client) + ":" + EMBED_GREY + "" + EMBED_WHITE + "", message);
                        }
                        else
                        {
                            target.TriggerEvent("Send_ToChat", "", AccountManage.GetCharacterName(Client) + ":" + EMBED_GREY + "" + EMBED_WHITE + "", message);
                        }
                    }
                }
            }

            return;
        }

        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(18, Client);
        foreach (Player target in proxPlayers)
        {
            if (target.GetData<dynamic>("status") == true)
            {
                if (Client.GetData<dynamic>("admin_duty") == 1)
                {
                    Main.SendCustomChatMessasge(target, "(( <font color='#F20000'>" + adminCommands.GetPlayerAdminRank(Client) + " " + AccountManage.GetCharacterName(Client) + ": " + EMBED_WHITE + "" + message + "<font color='#F20000'> ))");
                }
                else
                {
                    if (Client.GetSharedData<dynamic>("using_mask"))
                    {
                        target.TriggerEvent("Send_ToChat", "", "" + Translation.chat_mask_type + "" + AccountManage.GetPlayerSQLID(Client) + ":" + EMBED_GREY + "" + EMBED_WHITE + "", message);
                    }
                    else
                    {
                        target.TriggerEvent("Send_ToChat", "", AccountManage.GetCharacterName(Client) + ":" + EMBED_GREY + "" + EMBED_WHITE + "", message);
                    }
                }
            }
        }
    }

    public static string errorColor = "#ff1100";
    public static string serverColor = "#00ff08";
    public static string successColor = "#00ff08";
    public static string infoColor = "#696902";
    public static string warningColor = "#696902";
    public static string usageColor = "#ffe680";
    public static string defaultColor = "#FFFFFF";

    public static string errorSyntax = "[!]";
    public static string serverSyntax = "[!]";
    public static string successSyntax = "[!]";
    public static string infoSyntax = "[!]";
    public static string warningSyntax = "[!]";
    public static string usageSyntax = "[!]";

    public static void SendCustomMessage(Player player, string message)
    {
        message = message.Replace("~w~", "<span style=\"color:#ffffff\">");
        message = message.Replace("~c~", "<span style=\"color:#999999\">");
        message = message.Replace("~y~", "<span style=\"color:#EDD415\">");
        message = message.Replace("~q~", "<span style=\"color:#8365E0\">");
        message = message.Replace("~o~", "<span style=\"color:#FF9924\">");
        message = message.Replace("~r~", "<span style=\"color:#FF0400\">");
        message = message.Replace("~g~", "<span style=\"color:#1AC211\">");
        message = message.Replace("~b~", "<span style=\"color:#2F84FA\">");
        message = message.Replace("~p~", "<span style=\"color:#FF6EE4\">");

        string encodedMessage = HttpUtility.HtmlEncode(message);

        string coloredMessage = $"<span style=\"color: {errorColor};\">{errorSyntax}: <span style=\"color: {defaultColor};\"> {encodedMessage}</span>";
        NAPI.ClientEvent.TriggerClientEvent(player, "client:chatMessage", coloredMessage);
    }

    public static void SendErrorMessage(Player player, string message)
    {
        message = message.Replace("~w~", "<span style=\"color:#ffffff\">");
        message = message.Replace("~c~", "<span style=\"color:#999999\">");
        message = message.Replace("~y~", "<span style=\"color:#EDD415\">");
        message = message.Replace("~q~", "<span style=\"color:#8365E0\">");
        message = message.Replace("~o~", "<span style=\"color:#FF9924\">");
        message = message.Replace("~r~", "<span style=\"color:#FF0400\">");
        message = message.Replace("~g~", "<span style=\"color:#1AC211\">");
        message = message.Replace("~b~", "<span style=\"color:#2F84FA\">");
        message = message.Replace("~p~", "<span style=\"color:#FF6EE4\">");

        string encodedMessage = HttpUtility.HtmlEncode(message);

        string coloredMessage = $"<span style=\"color: {errorColor};\">{errorSyntax}: <span style=\"color: {defaultColor};\"> {encodedMessage}</span>";
        NAPI.ClientEvent.TriggerClientEvent(player, "client:chatMessage", coloredMessage);
    }

    public static void SendAntiCheatMessage(Player player, string message)
    {
        message = message.Replace("~w~", "<span style=\"color:#ffffff\">");
        message = message.Replace("~c~", "<span style=\"color:#999999\">");
        message = message.Replace("~y~", "<span style=\"color:#EDD415\">");
        message = message.Replace("~q~", "<span style=\"color:#8365E0\">");
        message = message.Replace("~o~", "<span style=\"color:#FF9924\">");
        message = message.Replace("~r~", "<span style=\"color:#FF0400\">");
        message = message.Replace("~g~", "<span style=\"color:#1AC211\">");
        message = message.Replace("~b~", "<span style=\"color:#2F84FA\">");
        message = message.Replace("~p~", "<span style=\"color:#FF6EE4\">");

        string encodedMessage = HttpUtility.HtmlEncode(message);

        string coloredMessage = $"<span style=\"color: {errorColor};\">{errorSyntax}: <span style=\"color: {defaultColor};\"> {encodedMessage}</span>";
        NAPI.ClientEvent.TriggerClientEvent(player, "client:chatMessage", coloredMessage);

        if (AccountManage.GetPlayerConnected(player))
        {
            foreach (var item in NAPI.Pools.GetAllPlayers())
            {
                if (AccountManage.GetPlayerAdmin(item) >= 1)
                {
                    Main.SendCustomChatMessasge(item, message);
                    GameLog.ELog(player, GameLog.MyEnum.Anti_Cheat, player.Name + "(" + player.SocialClubName + ")" + " " + message + " hilesini kullanıyor.");
                }
            }
        }
    }

    public static void SendSuccessMessage(Player player, string message)
    {
        message = message.Replace("~w~", "<span style=\"color:#ffffff\">");
        message = message.Replace("~c~", "<span style=\"color:#999999\">");
        message = message.Replace("~y~", "<span style=\"color:#EDD415\">");
        message = message.Replace("~q~", "<span style=\"color:#8365E0\">");
        message = message.Replace("~o~", "<span style=\"color:#FF9924\">");
        message = message.Replace("~r~", "<span style=\"color:#FF0400\">");
        message = message.Replace("~g~", "<span style=\"color:#1AC211\">");
        message = message.Replace("~b~", "<span style=\"color:#2F84FA\">");
        message = message.Replace("~p~", "<span style=\"color:#FF6EE4\">");

        string encodedMessage = HttpUtility.HtmlEncode(message);

        string coloredMessage = $"<span style=\"color: {successColor};\">{successSyntax}: <span style=\"color: {defaultColor};\"> {encodedMessage}</span>";
        NAPI.ClientEvent.TriggerClientEvent(player, "client:chatMessage", coloredMessage);
    }

    public static void SendServerMessage(Player player, string message)
    {
        message = message.Replace("~w~", "<span style=\"color:#ffffff\">");
        message = message.Replace("~c~", "<span style=\"color:#999999\">");
        message = message.Replace("~y~", "<span style=\"color:#EDD415\">");
        message = message.Replace("~q~", "<span style=\"color:#8365E0\">");
        message = message.Replace("~o~", "<span style=\"color:#FF9924\">");
        message = message.Replace("~r~", "<span style=\"color:#FF0400\">");
        message = message.Replace("~g~", "<span style=\"color:#1AC211\">");
        message = message.Replace("~b~", "<span style=\"color:#2F84FA\">");
        message = message.Replace("~p~", "<span style=\"color:#FF6EE4\">");

        string encodedMessage = HttpUtility.HtmlEncode(message);

        string coloredMessage = $"<span style=\"color: {serverColor};\">{serverSyntax}: <span style=\"color: {defaultColor};\"> {encodedMessage}</span>";
        NAPI.ClientEvent.TriggerClientEvent(player, "client:chatMessage", coloredMessage);
    }

    public static void SendInfoMessage(Player player, string message)
    {
        message = message.Replace("~w~", "<span style=\"color:#ffffff\">");
        message = message.Replace("~c~", "<span style=\"color:#999999\">");
        message = message.Replace("~y~", "<span style=\"color:#EDD415\">");
        message = message.Replace("~q~", "<span style=\"color:#8365E0\">");
        message = message.Replace("~o~", "<span style=\"color:#FF9924\">");
        message = message.Replace("~r~", "<span style=\"color:#FF0400\">");
        message = message.Replace("~g~", "<span style=\"color:#1AC211\">");
        message = message.Replace("~b~", "<span style=\"color:#2F84FA\">");
        message = message.Replace("~p~", "<span style=\"color:#FF6EE4\">");

        string encodedMessage = HttpUtility.HtmlEncode(message);

        string coloredMessage = $"<span style=\"color: {infoColor};\">{infoSyntax}: <span style=\"color: {defaultColor};\"> {encodedMessage}</span>";
        NAPI.ClientEvent.TriggerClientEvent(player, "client:chatMessage", coloredMessage);
    }

    public static void SendWarningMessage(Player player, string message)
    {
        message = message.Replace("~w~", "<span style=\"color:#ffffff\">");
        message = message.Replace("~c~", "<span style=\"color:#999999\">");
        message = message.Replace("~y~", "<span style=\"color:#EDD415\">");
        message = message.Replace("~q~", "<span style=\"color:#8365E0\">");
        message = message.Replace("~o~", "<span style=\"color:#FF9924\">");
        message = message.Replace("~r~", "<span style=\"color:#FF0400\">");
        message = message.Replace("~g~", "<span style=\"color:#1AC211\">");
        message = message.Replace("~b~", "<span style=\"color:#2F84FA\">");
        message = message.Replace("~p~", "<span style=\"color:#FF6EE4\">");

        string encodedMessage = HttpUtility.HtmlEncode(message);

        string coloredMessage = $"<span style=\"color: {warningColor};\">{warningSyntax}: <span style=\"color: {defaultColor};\"> {encodedMessage}</span>";
        NAPI.ClientEvent.TriggerClientEvent(player, "client:chatMessage", coloredMessage);
    }

    public static void SendUsageMessage(Player player, string message)
    {
        message = message.Replace("~w~", "<span style=\"color:#ffffff\">");
        message = message.Replace("~c~", "<span style=\"color:#999999\">");
        message = message.Replace("~y~", "<span style=\"color:#EDD415\">");
        message = message.Replace("~q~", "<span style=\"color:#8365E0\">");
        message = message.Replace("~o~", "<span style=\"color:#FF9924\">");
        message = message.Replace("~r~", "<span style=\"color:#FF0400\">");
        message = message.Replace("~g~", "<span style=\"color:#1AC211\">");
        message = message.Replace("~b~", "<span style=\"color:#2F84FA\">");
        message = message.Replace("~p~", "<span style=\"color:#FF6EE4\">");

        string encodedMessage = HttpUtility.HtmlEncode(message);

        string coloredMessage = $"<span style=\"color: {usageColor};\">{usageSyntax}: <span style=\"color: {defaultColor};\"> {encodedMessage}</span>";
        NAPI.ClientEvent.TriggerClientEvent(player, "client:chatMessage", coloredMessage);
    }

    public static void SendMeslekMesaj(Player player, string message)
    {
        message = message.Replace("~w~", "<span style=\"color:#ffffff\">");
        message = message.Replace("~c~", "<span style=\"color:#999999\">");
        message = message.Replace("~y~", "<span style=\"color:#EDD415\">");
        message = message.Replace("~q~", "<span style=\"color:#8365E0\">");
        message = message.Replace("~o~", "<span style=\"color:#FF9924\">");
        message = message.Replace("~r~", "<span style=\"color:#FF0400\">");
        message = message.Replace("~g~", "<span style=\"color:#1AC211\">");
        message = message.Replace("~b~", "<span style=\"color:#2F84FA\">");
        message = message.Replace("~p~", "<span style=\"color:#FF6EE4\">");

        string encodedMessage = HttpUtility.HtmlEncode(message);

        string coloredMessage = $"<span style=\"color: {usageColor};\">{usageSyntax}: <span style=\"color: {defaultColor};\"> {encodedMessage}</span>";
        NAPI.ClientEvent.TriggerClientEvent(player, "client:chatMessage", coloredMessage);
    }

    public static void SendPlayerMessage(Player player, string message)
    {
        message = message.Replace("~w~", "<span style=\"color:#ffffff\">");
        message = message.Replace("~c~", "<span style=\"color:#999999\">");
        message = message.Replace("~y~", "<span style=\"color:#EDD415\">");
        message = message.Replace("~q~", "<span style=\"color:#8365E0\">");
        message = message.Replace("~o~", "<span style=\"color:#FF9924\">");
        message = message.Replace("~r~", "<span style=\"color:#FF0400\">");
        message = message.Replace("~g~", "<span style=\"color:#1AC211\">");
        message = message.Replace("~b~", "<span style=\"color:#2F84FA\">");
        message = message.Replace("~p~", "<span style=\"color:#FF6EE4\">");

        string encodedMessage = HttpUtility.HtmlEncode(message);

        string coloredMessage = $"<span style=\"color: {defaultColor};\">{AccountManage.GetCharacterName(player)}: <span style=\"color: {defaultColor};\"> {encodedMessage}</span>";
        NAPI.ClientEvent.TriggerClientEvent(player, "client:chatMessage", coloredMessage);
    }

    public static void setTimeStamp(Player player)
    {
        if (player.GetData<bool>("timeStamp") == true)
        {
            player.SetData("timeStamp", false);
            loadChatSettings(player);
        }
        else
        {
            player.SetData("timeStamp", true);
            loadChatSettings(player);
        }
        SavePlayerInformation(player);
    }

    public static void setToggleChat(Player player)
    {
        if (player.GetData<bool>("toggleChat") == true)
        {
            player.SetData("toggleChat", false);
            loadChatSettings(player);
        }
        else
        {
            player.SetData("toggleChat", true);
            loadChatSettings(player);
        }
        SavePlayerInformation(player);
    }

    public static void disableChat(Player player)
    {
        player.SetData("toggleChat", false);
        loadChatSettings(player);
    }

    public static void enableChat(Player player)
    {
        player.SetData("toggleChat", true);
        loadChatSettings(player);
    }

    public static void SetChatStatus(Player player, bool status)
    {
        player.SetData("toggleChat", status);
        loadChatSettings(player);
    }

    public static void setPagesize(Player player, int pageSize)
    {
        if (pageSize < 4 || pageSize > 24)
        {
            SendErrorMessage(player, "Pagesize minimum 4, maksimum 24 olabilir.");
            return;
        }
        player.SetData("pageSize", pageSize);
        loadChatSettings(player);
        SavePlayerInformation(player);
    }

    public static void setFontsize(Player player, double fontSize)
    {
        if (fontSize < 0.5 || fontSize > 1.5)
        {
            SendErrorMessage(player, "Fontsize minimum 0.5, maksimum 1.5 olabilir.");
            return;
        }
        player.SetData<double>("fontSize", fontSize);
        loadChatSettings(player);
        SavePlayerInformation(player);
    }

    public static void loadChatSettings(Player player)
    {
        bool timestamp = player.GetData<bool>("timeStamp");
        bool togglechat = player.GetData<bool>("toggleChat");
        double fontsize = player.GetData<double>("fontSize");
        int pagesize = player.GetData<int>("pageSize");
        NAPI.ClientEvent.TriggerClientEvent(player, "client:loadChatSettings", timestamp, togglechat, fontsize, pagesize);
    }

    [RemoteEvent("server:pressKeyF7")]
    public static void PressKeyF7(Player player)
    {
        if (player.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (player.HasSharedData("UI_Stats") == false)
        {
            player.SetSharedData("UI_Stats", true);
        }
        hideall(player, !player.GetSharedData<dynamic>("UI_Stats"));
    }

    public static void ClearChat(Player player)
    {
        NAPI.ClientEvent.TriggerClientEvent(player, "client:clearChat");
    }

    [ServerEvent(Event.VehicleDeath)]
    public void OnVehicleDeath(Vehicle vehicle)
    {
        foreach (var ls in LSCUSTOM_NEW.ls_custom)
        {
            if (ls.in_use == true && ls.vehicle == vehicle)
            {
                ls.in_use = false;
                ls.vehicle = null;
                ls.label_position.Text = Translation.ls_custom_label_free;
                vehicle.ResetData("lscustom_use");
            }
        }

        API.Shared.ConsoleOutput("Vehicle Death");


        int faction_id = 0;
        foreach (var faction in FactionManage.faction_data)
        {
            for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
            {
                if (FactionManage.faction_data[faction_id].faction_vehicle_name[i] != "Unknown")
                {
                    try
                    {
                        if (FactionManage.faction_data[faction_id].faction_vehicle_entity[i] == vehicle)
                        {
                            FactionManage.faction_data[faction_id].faction_vehicle_name[i] = "Livre";
                            FactionManage.faction_data[faction_id].faction_vehicle_owned[i] = "Unknown";
                            FactionManage.faction_data[faction_id].faction_vehicle_entity[i] = null;
                        }
                    }
                    catch (Exception)
                    {
                        NAPI.Util.ConsoleOutput("[ÇIKTI]: OnVehicle Death - Birlik Aracı");
                    }
                }
            }
            faction_id++;
        }

        VehicleInventory.RemoveVehicleInventory(vehicle);

        NAPI.Data.ResetEntityData(vehicle, "vehicle_colision");
        NAPI.Data.ResetEntityData(vehicle, "engine_status");


        for (int i = 0; i < 20; i++)
        {
            if (vehicle == admin_vehicle[i])
            {
                admin_vehicle_spawned[i] = false;

            }
        }

        for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
        {
            var players = NAPI.Pools.GetAllPlayers();
            foreach (var Player in players)
            {
                if (Player.GetData<dynamic>("status") == true)
                {
                    try
                    {
                        if (vehicle == PlayerVehicle.vehicle_data[Main.getIdFromClient(Player)].handle[index])
                        {
                            PlayerVehicle.vehicle_data[Main.getIdFromClient(Player)].state[index] = 0;
                            PlayerVehicle.SavePlayerVehicle(Player, index);

                        }
                    }
                    catch (Exception)
                    {
                        NAPI.Util.ConsoleOutput("[ÇIKTI]: OnVehicle Death - Oyuncu Aracı");
                    }
                }
            }
        }

        NAPI.Task.Run(() =>
        {
            if (!vehicle.Exists) return;
            NAPI.Entity.DeleteEntity(vehicle);
        }, delayTime: 30000);
    }

    [ServerEvent(Event.PlayerEnterVehicleAttempt)]
    public void OnPlayerTryingEnterVehicle(Player player, Vehicle veh, sbyte seat)
    {

    }

    [ServerEvent(Event.PlayerEnterVehicle)]
    public void OnPlayerEnterVehicle(Player Client, Vehicle vehicle, sbyte seatID)
    {
        if (VehicleStreaming.GetLockState(vehicle))
        {
            Client.WarpOutOfVehicle();
        }
        if (Client.HasData("InBusinessShop") && Client.GetData<dynamic>("InBusinessShop") == true && seatID == (int)VehicleSeat.Driver && vehicle.GetData<bool>("IsInHighEnd") == true)
        {
            //HighEnd.ShowVehicleSellMenu(Client, vehicle);
        }

        else if (vehicle.Class != 13)
        {
        }

        for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
        {
            if (NAPI.Data.HasEntityData(Client, "character_data_vehicle_" + index + "_handle") && NAPI.Data.HasEntityData(Client, "character_data_vehicle_" + index + "_ticket"))
            {
                if (vehicle == NAPI.Data.GetEntityData(Client, "character_data_vehicle_" + index + "_handle"))
                {
                    NAPI.Util.ConsoleOutput("Crash #1");
                    if (Convert.ToInt32(NAPI.Data.GetEntityData(Client, "character_data_vehicle_" + index + "_ticket")) > 0)
                    {
                        InteractMenu_New.SendNotificationInfo(Client, string.Format(Translation.notification_enter_vehicle_ticket, NAPI.Data.GetEntityData(Client, "character_data_vehicle_" + index + "_model"), NAPI.Data.GetEntityData(Client, "character_data_vehicle_" + index + "_ticket").ToString("N0")));
                    }
                }
            }
        }
        if (seatID == (int)VehicleSeat.Driver)
        {
            NAPI.Task.Run(() => {
                try
                {
                    Client.TriggerEvent("radiooff");
                }
                catch { }
            }, 500);
        }

        if (seatID == 0)
        {
            int playerid = getIdFromClient(Client);
            if (vehicle.GetData<bool>("polveh") == true)
            {
                Main.SendCustomChatMessasge(Client, $"<font color='#AFAFAF'>ARAÇ: <font color='#FFFFFF'>Bu araç <font color='#AFAFAF'> Los Santos Police Departmant<font color='#FFFFFF'> adlı birliğe aittir.");
            }
            else if (vehicle.GetData<bool>("emsveh") == true)
            {
                Main.SendCustomChatMessasge(Client, $"<font color='#AFAFAF'>ARAÇ: <font color='#FFFFFF'>Bu araç <font color='#AFAFAF'> Los Santos Medical Departmant<font color='#FFFFFF'> adlı birliğe aittir.");
            }
            else
            {
                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                {
                    if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].state[index] == 3)
                    {
                        if (PlayerVehicle.vehicle_data[playerid].handle[index].Exists && PlayerVehicle.vehicle_data[playerid].handle[index] == Client.Vehicle)
                        {
                            int sqlid = PlayerVehicle.vehicle_data[playerid].owner_sql[index];
                            Main.SendCustomChatMessasge(Client, $"<font color='#AFAFAF'>ARAÇ: <font color='#FFFFFF'>Bu araç <font color='#AFAFAF'> {SQLIDToName(sqlid)}<font color='#FFFFFF'> adlı kişiye aittir.");
                            return;
                        }
                    }
                }
            }
        }
            

        if (VehicleStreaming.GetEngineState(vehicle) == false && Client.VehicleSeat == (int)VehicleSeat.Driver)
        {

        }
    }


    [ServerEvent(Event.Update)]
    public void OnPlayerUpdate()
    {
        foreach (var Player in API.Shared.GetAllPlayers())
        {
            if (Player.GetData<dynamic>("status") == true && Player.GetData<dynamic>("PD_Panic") == 1)
            {
                faction_blip.Update_Blip_For_Player(Player);
            }
        }
    }

    [ServerEvent(Event.PlayerExitVehicle)]
    public void OnPlayerExitVehicleHandler(Player Client, Vehicle vehicle)
    {

        if (vehicle.Exists)
        {

            if (Client.HasData("ls_customs"))
            {

            }

            if (NAPI.Data.HasEntityData(vehicle, "TransportDuty") && NAPI.Data.GetEntityData(vehicle, "TransportDuty") == true)
            {

                if (Client.VehicleSeat == (int)VehicleSeat.Driver)
                {
                    Main.SendCustomChatMessasge(Client, string.Format(Translation.message_taxi_driver_exit_Vehicle, NAPI.Data.GetEntityData(vehicle, "TransportFee").ToString("N0")));


                    Client.TriggerEvent("update_taxi_fare", false, 0, 0, false);

                    var players_in_vehicle = NAPI.Pools.GetAllPlayers();
                    foreach (var i in players_in_vehicle)
                    {
                        if (i.GetData<dynamic>("status") == true && Client.Vehicle == i.Vehicle && i.VehicleSeat != (int)VehicleSeat.Driver && i.GetData<dynamic>("TaxiFee") >= 0)
                        {
                            Main.GivePlayerMoney(i, -i.GetData<dynamic>("TaxiFee"));
                            i.SetData<dynamic>("TaxiFee", 0);
                            Main.SendCustomChatMessasge(i, "~y~*~w~ Bir taksici göreve başladı, yolculuk başına ücret: ~g~$" + i.GetData<dynamic>("TaxiFee").ToString("N0") + "");
                            i.TriggerEvent("update_taxi_fare", false, 0, 0, false);
                        }
                    }

                    Client.Vehicle.SetData<dynamic>("TransportDuty", false);
                    Client.Vehicle.SetData<dynamic>("TransportPrice", 0);
                    Client.Vehicle.SetData<dynamic>("TransportFee", 0);
                    Client.Vehicle.SetData<dynamic>("TransportTime", 0);
                    Client.Vehicle.ResetData("TransportDuty");
                }
                else
                {
                    if (Client.GetData<dynamic>("TaxiFee") > 0)
                    {
                        Main.SendCustomChatMessasge(Client, Translation.message_taxi_passager_exit_vehicle_2 + Client.GetData<dynamic>("TaxiFee").ToString("N0"));
                        GivePlayerMoney(Client, -Client.GetData<dynamic>("TaxiFee"));

                        if (vehicle.HasData("TransportDriver"))
                        {
                            Player target = vehicle.GetData<dynamic>("TransportDriver");

                            if (API.Shared.IsPlayerConnected(target) && target.GetData<dynamic>("status") == true)
                            {
                                Main.GivePlayerMoney(target, Client.GetData<dynamic>("TaxiFee"));
                                Main.SendSuccessMessage(target, string.Format(Translation.message_taxi_passager_exit_vehicle_3, UsefullyRP.GetPlayerNameToTarget(Client, target), Client.GetData<dynamic>("TaxiFee")));
                            }
                        }

                        Client.TriggerEvent("update_taxi_fare", false, 0, 0, false);


                    }
                    else DisplayErrorMessage(Client, "error", string.Format(Translation.message_taxi_passager_exit_vehicle_4, NAPI.Data.GetEntityData(vehicle, "TransportPrice")));
                    Client.SetData<dynamic>("TaxiFee", 0);
                }
            }

            if (NAPI.Data.HasEntityData(vehicle, "engine_status"))
            {
                NAPI.Data.ResetEntityData(vehicle, "engine_status");
            }

            if (Client.HasData("Refueling"))
            {
                Client.ResetData("Refueling");
            }
        }
    }


    [ServerEvent(Event.PlayerExitVehicle)]
    public void PlayerExitVehicle(Player Client, Vehicle vehicle)
    {
        NAPI.ClientEvent.TriggerClientEvent(Client, "VehStream_PlayerExitVehicleAttempt", vehicle);
    }

    [ServerEvent(Event.VehicleDamage)]
    public void OnVehicleDamageHandler(Vehicle entity, float bodyHealthLoss, float engineHealthLoss)
    {
        if (NAPI.Vehicle.GetVehicleEngineHealth(entity) < 300)
        {
            Player Player = (Player)NAPI.Vehicle.GetVehicleDriver(entity);
            if (Player.IsNull)
            {
                return;
            }
            if (Player.GetData<dynamic>("status") == true)
            {
                if (Player.IsInVehicle)
                {
                    if (Player.Vehicle == entity)
                    {
                        if (Player.VehicleSeat == (int)VehicleSeat.Driver)
                        {
                            Main.SendInfoMessage(Player, Translation.message_01);
                            VehicleStreaming.SetEngineState(entity, false);

                        }
                    }
                }
            }
        }
        else if (NAPI.Vehicle.GetVehicleEngineHealth(entity) > 300 && engineHealthLoss > 50)
        {
            Player Player = (Player)NAPI.Vehicle.GetVehicleDriver(entity);
            if (Player.IsNull)
            {
                return;
            }
            if (Player.GetData<dynamic>("status") == true && Player.IsInVehicle)
            {
                if (!NAPI.Data.HasEntityData(Player.Vehicle, "vehicle_colision"))
                {
                    Player.TriggerEvent("createNewHeadNotificationAdvanced", Translation.head_notification_0);


                    NAPI.Data.SetEntityData(entity, "vehicle_colision", true);
                    VehicleStreaming.SetEngineState(entity, false);
                    VehicleStreaming.SetEngineState(entity, false);
                    Random rnd = new Random();
                    int random_timer = rnd.Next(8, 14);

                    NAPI.Task.Run(() =>
                    {
                        if (!entity.Exists) return;
                        VehicleStreaming.SetEngineState(entity, true);
                        VehicleStreaming.SetEngineState(entity, true);

                        NAPI.Data.ResetEntityData(entity, "vehicle_colision");
                    }, random_timer * 1000);
                }
            }
        }
    }


    [RemoteEvent("OnPlayerHealthChange")]
    public static void OnPlayerHealthChange(Player Client, int new_health)
    {
        if (Client.Armor > 0)
        {
        }
        Client.TriggerEvent("update_health", Client.Health - new_health, Client.Armor);
    }

    [ServerEvent(Event.PlayerDeath)]
    public void OnPlayerDeath(Player Client, Player entityKiller, uint weapon)
    {
        if (Client.GetData<dynamic>("status") == true)
        {
            if (entityKiller != null && Client != null)
            {
                GameLog.ELog(Client, GameLog.MyEnum.Dead, " Oyuncu " + entityKiller.GetData<dynamic>("character_name") + " oyuncuyu " + Enum.GetName(typeof(WeaponHash), weapon) + " ile öldürdü.");
            }

            if (Client.GetData<int>("oyuncuAramada") != TelefonSistem.ARAMA_BOS)
            {
                TelefonSistem.CagriRed(Client);
            }

            Client.TriggerEvent("death_screen_false");


            if (Client.HasData("inVehicleInventory"))
            {
                if (Client.GetData<dynamic>("inVehicleInventory") == true)
                {
                    Client.SetData<dynamic>("inVehicleInventory", false);
                }
            }

            Client.SetSharedData("DisableExitVehicle", false);
            Client.SetSharedData("DisableVehicleMove", false);

            if (NAPI.Data.GetEntityData(Client, "MainProgressText") == true)
            {
                DeleteTextProgressBar(Client);
            }

            if (Client.GetData<dynamic>("character_prison") > 0)
            {
                Main.DisplayErrorMessage(Client, "info", "Zatvor 666");
                Client.Health = 50;
                Client.StopAnimation();
                sendBackToPrison(Client);
                return;
            }
            if (Client.GetData<dynamic>("character_ooc_prison_time") > 0)
            {
                ShowColorShard(Client, "~y~Dobrodosao nazad!", "", 2, 10, 6500);
                adminCommands.SendBackToPrison(Client);
                return;
            }
            if (Client.GetSharedData<dynamic>("Injured") == 1 && Client.GetData<dynamic>("character_prison") == 0)
            {
                NAPI.Player.SetPlayerHealth(Client, 100);
                NAPI.Player.SpawnPlayer(Client, Client.Position);
                Inventory.ClearInventory(Client);
                Client.TriggerEvent("screenFadeOut", 1);
                Client.TriggerEvent("InjuredSystem:Destroy");

                NAPI.Task.Run(() =>
                {
                    if (!Client.Exists) return;

                    Client.TriggerEvent("screenFadeIn", 1500);
                }, delayTime: 2000);

                Client.SetClothes(5, 0, 0);
                Client.SetData<dynamic>("character_backpack", 0);
                Client.SetData<dynamic>("BackPack3_OverLoad", false);

                ShowColorShard(Client, Translation.shard_01_title, Translation.shard_01, 2, 10, 6500);
                sendToHospital(Client, HOSPITAL_TIME_EXECUTE, true);
                return;
            }
            if (Client.GetData<dynamic>("character_prison") == 0)
            {
                Client.SetSharedData("Injured", 1);
                Client.SetSharedData("InjuredTime", 101);
                NAPI.World.SetTime(Server_Hours, Server_Minutes, Server_Sec);
            }
        }
    }
    [RemoteEvent("SetFullyInjured")]
    public void SetFullyInjured(Player Client)
    {

        if (!Client.Exists) return;
        if (Client.IsInVehicle)
        {
            NAPI.Player.SetPlayerHealth(Client, 100);
            NAPI.Player.SpawnPlayer(Client, Client.Position.Around(2));
        }
        else
        {
            NAPI.Player.SetPlayerHealth(Client, 100);
            NAPI.Player.SpawnPlayer(Client, Client.Position);
        }
        NAPI.Player.PlayPlayerAnimation(Client, 39, "dead", "dead_d");

        Client.TriggerEvent("freezeEx", true);
        Client.TriggerEvent("freeze", true);
        Client.TriggerEvent("InjuredSystem", 450 * 1000);
        NAPI.Player.SetPlayerHealth(Client, 100);
        Client.Armor = 0;
        Client.TriggerEvent("update_health", Client.Health, Client.Armor);


        NAPI.Task.Run(() =>
        {
            if (!Client.Exists) return;
            NAPI.Player.PlayPlayerAnimation(Client, (int)(Main.AnimationFlags.Loop), "dead", "dead_d");

        }, 300);
    }

    [ServerEvent(Event.PlayerSpawn)]
    public void OnPlayerSpawn(Player Client)
    {
        NAPI.Blip.SetBlipSprite(Client, 15);
    }

    public static void sendBackToPrison(Player Client)
    {
        UsefullyRP.RemoveMaskFromPlayer(Client);

        NAPI.Entity.SetEntityPosition(Client, prison_spawns[Client.GetData<dynamic>("character_prison_cell")].position);
        Client.Rotation = prison_spawns[Client.GetData<dynamic>("character_prison_cell")].rotation;
        Client.TriggerEvent("freezeEx", false);
        Client.TriggerEvent("freeze", false);

        NAPI.Player.SetPlayerClothes(Client, 1, 0, 0);
        NAPI.Player.SetPlayerClothes(Client, 5, 0, 0);
        NAPI.Player.SetPlayerClothes(Client, 1, 0, 0);
        NAPI.Player.SetPlayerClothes(Client, 7, 0, 0);
        NAPI.Player.SetPlayerClothes(Client, 9, 0, 0);
        NAPI.Player.ClearPlayerAccessory(Client, 0);
        NAPI.Player.ClearPlayerAccessory(Client, 1);
        NAPI.Player.ClearPlayerAccessory(Client, 2);
        NAPI.Player.ClearPlayerAccessory(Client, 6);
        NAPI.Player.ClearPlayerAccessory(Client, 7);

        NAPI.Player.SetPlayerClothes(Client, 4, 3, 7);
        NAPI.Player.SetPlayerClothes(Client, 11, 5, 0);
        NAPI.Player.SetPlayerClothes(Client, 3, 5, 0);
        NAPI.Player.SetPlayerClothes(Client, 8, 0, 18);
        NAPI.Player.SetPlayerClothes(Client, 6, 8, 0);


        TimeSpan time = TimeSpan.FromSeconds(Client.GetData<dynamic>("character_prison_time"));
        string str = time.ToString(@"hh\:mm\:ss");
    }

    [RemoteEvent("InjuredSystemHospital")]
    public static void sendToHospital(Player Client, int seconds = 30, bool stats = true)
    {
        if (stats)
        {
            for (int i = 0; i < Inventory.MAX_INVENTORY_ITENS; i++)
            {
                if (Inventory.player_inventory[Client.Value].amount[i] >= 1 && Inventory.itens_available[Inventory.player_inventory[Client.Value].type[i]].guest == Inventory.ITEM_TYPE_WEAPON)
                {
                    Inventory.DropItemFromInventory(Client, i, Inventory.itens_available[Inventory.player_inventory[Client.Value].type[i]].name, Inventory.player_inventory[Client.Value].amount[i], -1);
                }
            }
            Inventory.ClearInventory(Client);
            WeaponManage.RemoveAllWeaponEx(Client);
        }

        UsefullyRP.RemoveMaskFromPlayer(Client);

        if (NAPI.Data.GetEntityData(Client, "MainProgressText") == true)
        {
            DeleteTextProgressBar(Client);
        }
        if (Inventory.GetInventoryIndexFromName(Client, "Radio") <= 0)
        {
            foreach (Player pl in NAPI.Pools.GetAllPlayers())
            {
                if (pl.GetData<dynamic>("status") == true)
                {
                    if (pl.GetSharedData<dynamic>("RadioFreq") == Client.GetSharedData<dynamic>("RadioFreq") && pl != Client)
                    {
                        Client.TriggerEvent("v_disconnect", pl);
                        pl.TriggerEvent("v_disconnect", Client);
                    }
                }
            }
            Client.SetSharedData("Radio_Status", false);
            Client.SetSharedData("RadioFreq", 0);
        }
        Random rnd = new Random();
        int randdim = rnd.Next(1, 50);
        uint isa = Convert.ToUInt16(randdim);

        NAPI.Player.StopPlayerAnimation(Client);
        Client.SetSharedData("Injured", 0);
        Client.SetSharedData("InjuredTime", 0);

        AccountManage.SetPlayerHunger(Client, 50.0f);
        AccountManage.SetPlayerThirsty(Client, 40.0f);

        Client.SetSharedData("Injured", 0);
        Client.Dimension = 0;
        Client.SetSharedData("character_hospital", 0);
        NAPI.Entity.SetEntityPosition(Client, new Vector3(298.42578, -584.391, 43.26092));
        NAPI.Entity.SetEntityRotation(Client, new Vector3(0, 0, 71.29355));
        Client.TriggerEvent("freeze", false);

        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(Client))
            {
                Client.StopAnimation();
                Client.Dimension = 0;
                Client.TriggerEvent("freeze", false);
            }
        }, delayTime: 1000);

        Client.SetSharedData("Injured", 0);
        Client.TriggerEvent("InjuredSystem:Destroy");
        Client.TriggerEvent("freeze", false);
        Client.TriggerEvent("freezeEx", false);
        NAPI.Player.StopPlayerAnimation(Client);

        TimeSpan time = TimeSpan.FromSeconds(Client.GetSharedData<dynamic>("InjuredTime"));
        string time_left = time.ToString(@"mm\:ss");

        if (GetPlayerMoney(Client) <= 250)
        {
            if (GetPlayerMoney(Client) <= 0)
            {
                Main.SendInfoMessage(Client, $"Ağır yaralandınız, sağlık ekipleri gelip sizi hastaneye kaldırdı.");
                SendInfoMessage(Client, $"Üzerinizde para olmadığı için hastane masraflarınız devlet tarafından karşılandı.");
            }
            int kesilecekpara = GetPlayerMoney(Client);
            Main.SendInfoMessage(Client, $"Ağır yaralandınız, sağlık ekipleri gelip sizi hastaneye kaldırdı.");
            SendInfoMessage(Client, $"{FormatNumber(kesilecekpara)} hastane masraflarını ödediniz.");
            GivePlayerMoney(Client, -kesilecekpara);
        }
        else
        {
            int kesilecekpara = 250;
            Main.SendInfoMessage(Client, $"Ağır yaralandınız, sağlık ekipleri gelip sizi hastaneye kaldırdı.");
            SendInfoMessage(Client, $"{FormatNumber(kesilecekpara)} hastane masraflarını ödediniz.");
            GivePlayerMoney(Client, -kesilecekpara);
        }
    }

    public static BlockingCollection<string> _jobs = new BlockingCollection<string>();
    private void SQLThreadHandler()
    {
        foreach (var job in _jobs.GetConsumingEnumerable(CancellationToken.None))
        {

            ExcuteMysqlCommand(job);
            Thread.Sleep(2);
        }
    }

    public static void ExcuteMysqlCommand(string command)
    {
        try
        {
            using (MySqlConnection CustomConnection = new MySqlConnection(myConnectionString))
            {

                CustomConnection.Open();
                MySqlCommand myCommand = new MySqlCommand(command, CustomConnection);
                myCommand.ExecuteNonQuery();

            }
        }
        catch (Exception ex)
        {
            GameLog.ELog(GameLog.MyEnum.Error, ex.Message + " " + ex.StackTrace);

        }
    }


    public static void CreateMySqlCommand(string myExecuteQuery)
    {
        _jobs.Add(myExecuteQuery);
    }

    private void OnPlayerFinishedDownloadHandler(Player Client)
    {

        if (MYSQL_ISPLAYERRegistered(Client) == 1)
        {
            NAPI.ClientEvent.TriggerClientEvent(Client, "accountLoginForm", true);
            AccountManage.LoadAccount(Client, Client.SocialClubName);
            NAPI.ClientEvent.TriggerClientEvent(Client, "clearLoginWindow", true);
        }
        else
        {
            NAPI.ClientEvent.TriggerClientEvent(Client, "accountLoginForm");

            NAPI.Entity.SetEntityPosition(Client, new Vector3(-550.3367, -213.2869, 37.64951));
            Client.Dimension = 150;
        }

    }

    [RemoteEvent("globalBrowser_status")]
    public void globalBrowser_status(Player Client, bool value)
    {
        Client.SetData<dynamic>("General_CEF", value);
    }

    [RemoteEvent("loginUser")]
    public async Task loginUserEvent(Player Client, String password)
    {

        if (Client.HasData("waitLogando"))
        {
            Client.SendNotification(Translation.notification_1);
            return;
        }

        Client.SetData<dynamic>("waitLogando", true);
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT * FROM `users` WHERE ( `socialclubname` = '" + Client.SocialClubName + "' ) and `Password` = '" + password + "'";
            query.ExecuteNonQuery();

            DataTable dt = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query))
            {
                da.Fill(dt);
                int i = 0;
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                if (i == 0)
                {

                    Client.TriggerEvent("displayerror", 0);

                    Client.ResetData("waitLogando");
                }
                else
                {


                    NAPI.ClientEvent.TriggerClientEvent(Client, "clearLoginWindow");
                    AccountManage.LoadAccount(Client, Client.SocialClubName);
                    Client.ResetData("waitLogando");
                }
                Mainpipeline.Close();

            }
        }

    }

    [RemoteEvent("registerUser")]

    public void registerUserEvent(Player Client, String password, String email, String refferal)
    {
        long time = 0;
        time = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        if (Client.HasData("waitLogando"))
        {

            //  Client.TriggerEvent("displayerror", 1, "Wait a few seconds, and try again");
            Main.DisplayErrorMessage(Client, "error", "Birkaç saniye bekleyin ve tekrar deneyin.");
            Client.SendNotification(Translation.notification_1);
            return;
        }
        Client.SetData<dynamic>("waitLogando", true);


        if (password.Length < 4 & password.Length > 30)
        {
            /// Client.TriggerEvent("displayerror", 1, "Ваш пароль должен содержать от 4 до 30 символов.");
            Main.DisplayErrorMessage(Client, "error", "Girdiğiniz şifre 4 ila 30 karakter arasında olmalıdır.");

            Client.ResetData("waitLogando");
        }
        else if (!IsValidEmail(email))
        {
            Client.TriggerEvent("displayerror", 4);

            Main.DisplayErrorMessage(Client, "error", "Geçersiz e-mail!");

            Client.ResetData("waitLogando");

        }
        else if (refferal != string.Empty && AccountManage.CheckRefferal(refferal) == false)
        {
            Main.DisplayErrorMessage(Client, "error", "Geçersiz referans!");
            return;
        }
        else if (AccountManage.CheckEmailExist(email) == false)
        {
            Client.TriggerEvent("displayerror", 5);
        }
        else
        {
            AccountManage.CreateAccount(Client, password, email, refferal);
            Client.ResetData("waitLogando");
        }


    }

    [RemoteEvent("SetCruiseValue")]
    public void Event_SetCruiseValue(Player Client, int value)
    {
        Client.SetData<dynamic>("SpeedLimitValue", value);

    }

    [RemoteEvent("SetCruiseEnable")]
    public void Event_SetCruiseValue(Player Client, bool value)
    {
        Client.SetData<dynamic>("SpeedLimitValue", value);
    }

    [RemoteEvent("keypress:F1")]
    public void KeyPressF1(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
    }

    [RemoteEvent("KeyPress:F9")]
    public static void KeyPressF9(Player Client)
    {
    }
    [RemoteEvent("KeyPress:F10")]
    public void KeyPressF10(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (Client.HasSharedData("UI_Stats") == false)
        {
            Client.SetSharedData("UI_Stats", true);
        }
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Bu işlemi gerçekleştirebilmek için yetkini yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 3)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }

        FactionManage.ShowFactionList(Client);

    }
    [RemoteEvent("keypress:F4")]
    public void KeyPressF4(Player Client)
    {

    }


    [RemoteEvent("KeyPress:F6")]
    public void KeyPressF6(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        Services.DisplayCalls(Client);
    }

    [RemoteEvent("KeyPress:F7")]
    public void KeyPressF7(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        Police.ShowMDC(Client);
    }

    [RemoteEvent("keypress:H")]
    public void KeyPressH(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (!Client.IsInVehicle && Client.GetData<dynamic>("status") == true && CANINE_SYSTEM == true)
        {

            if (Client.GetData<dynamic>("handsup") == true)
            {
                Client.SetData<dynamic>("handsup", false);

                NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mp_am_hold_up", "handsup_exit");

            }
            else
            {
                if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
                {
                    return;
                }


                Client.SetData<dynamic>("handsup", true);
                NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mp_am_hold_up", "handsup_base");
            }
        }

    }

    [RemoteEvent("TriggerIsTypingProcess")]
    public void TriggerIsTypingProcess(Player Client, bool state)
    {
        Client.SetSharedData("enableChatInput", state);
    }

    [RemoteEvent("Display_HUD")]
    public static void Display_HUD(Player Client, bool stats)
    {
        Client.TriggerEvent("toggle_player_hud", stats);
    }

    [RemoteEvent("Show_Chat")]
    public static void showChat(Player Client, bool stats)
    {
        SetChatStatus(Client, stats);
    }

    [RemoteEvent("HUD_Draw_stats")]
    public static void HUD_Draw_stats(Player Client, bool stats)
    {
        Client.TriggerEvent("HUD_Draw_stats", stats);
    }
    public static void hideall(Player Client, bool stats)
    {
        if (stats == false)
        {
            DisplayRadar(Client, false);
            disableChat(Client);
        }
        if (stats == true)
        {
            DisplayRadar(Client, true);
            enableChat(Client);
        }

        showChat(Client, stats);
        Display_HUD(Client, stats);

        HUD_Draw_stats(Client, stats);
        Client.SetSharedData("UI_Stats", !Client.GetSharedData<dynamic>("UI_Stats"));
    }

    [RemoteEvent("keypress:L")]
    public void KeyPressL(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
        {
            if (Client.Vehicle.Class == 14 || Client.Vehicle.Class == 15 || Client.Vehicle.Class == 16) { return; }
        }
        return;
    }

    [RemoteEvent("keypress:E")]
    public async void KeyPressE(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (Client.HasData("E_Timeout") && Client.GetData<dynamic>("E_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
        {
            Main.DisplaySubtitle(Client, "~y~[Antispam]", 2);
            return;
        }
        Client.SetData<dynamic>("E_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 1000);
        if (FactionManage.GetPlayerGroupID(Client) == 1)
        {
            DoorLock.DoorLSPDInteract(Client);
        }
        else if (FactionManage.GetPlayerGroupType(Client) == 3)
        {
            DoorLock.DoorSherifPelato(Client);
        }

        if (IsInRangeOfPoint(Client.Position, new Vector3(1260.08, -2566.23, 42.71), 5) && Client.IsInVehicle)
        {
            Vehicle vehicle = NAPI.Player.GetPlayerVehicle(Client);

            if (vehicle.HasData("Mashin_Owner") == false)
            {
                Main.DisplayErrorMessage(Client, "error", "Bu aracı parçalayamazsınız!");
                return;
            }
            if (vehicle.GetData<dynamic>("Mashin_Owner") == AccountManage.GetPlayerSQLID(Client))
            {
                Main.DisplayErrorMessage(Client, "error", "Kendi aracınızı neden parçalayamazsınız!");
                return;
            }

            NAPI.ClientEvent.TriggerClientEvent(Client, "client:ParcalamaOnay", vehicle.DisplayName);
        }

        if (IsInRangeOfPoint(Client.Position, new Vector3(346.57, -1012.68, -99.20), 3) && Client.Dimension == 1001)
        {
            houserobbery.HouseExit(Client);
        }
        if (IsInRangeOfPoint(Client.Position, new Vector3(1231.85, -3006.80, 9.31), 3))
        {
            houserobbery.SellItems(Client);

        }
        if (IsInRangeOfPoint(Client.Position, new Vector3(308.65, -595.32, 43.28), 3))
        {
            MedicSystem.keypresse(Client);

        }
        if (IsInRangeOfPoint(Client.Position, new Vector3(311.14, -565.65, 43.28), 2))
        {
            MedicSystem.MakeMeds(Client);
        }
        if (IsInRangeOfPoint(Client.Position, new Vector3(311.75, -561.83, 43.28), 3))
        {
            MedicSystem.MakeFAid(Client);
            return;
        }
        if (Client.Dimension == 1001)
        {
            houserobbery.GetHouseItem(Client);

        }
    
        if (Client.IsInVehicle)
        {
            FuelBusiness.CMD_benzin(Client);
        }

        ATMSystem.ATMRob(Client);
        houserobbery.hrobRob(Client);
        Inventory.PlayerPressKeyE(Client);
        RobberyNPC.keyPressE(Client);
        GarageSys.PressKeyE(Client);
        MechanicFaction.KeyPressE(Client);
      
        VShops.keypressE(Client);
        autoservis.keypresse(Client);
        autowash.keypresse(Client);
        teleporter.Teleporter(Client);
        arcadius.keypressE(Client);


        if (IsInRangeOfPoint(Client.Position, new Vector3(-83.47, 80.86, 70.55), 5) && Client.IsInVehicle)
        {
            Client.TriggerEvent("Display_vehosiguranje");
        }
        if (Client.IsInVehicle) LSCUSTOM_NEW.PressKeyE(Client);

    }

    [Command("git")]
    public static void Git(Player player)
    {
        player.Position = new Vector3(-83.47, 80.86, 70.55);
    }

    [RemoteEvent("keypress:K")]
    public void KeyPressK(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (Client.HasData("K_Timeout") && Client.GetData<dynamic>("K_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
        {
            Main.DisplaySubtitle(Client, "~y~[Antispam]", 2);
            return;
        }
        Client.SetData<dynamic>("K_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 1000);
        Vehicle vehicle = Utils.GetClosestVehicle(Client, 5.0f);

        int playerid = getIdFromClient(Client);
        if (vehicle != null && NAPI.Entity.DoesEntityExist(vehicle))
        {
            for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
            {
                if ((AccountManage.GetPlayerAdmin(Client) > 6 && AccountManage.IsAdminOnDuty(Client) == 1) || PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
                {
                    if (VehicleStreaming.GetLockState(vehicle))
                    {
                        VehicleStreaming.SetLockStatus(vehicle, false);
                        Main.EmoteMessage(Client, $"{vehicle.DisplayName} model aracın kilidini açar.");
                        Notify.Send(Client, "success", "Başarıyla aracın kilidini açtınız!", 5000);
                    }
                    else
                    {
                        VehicleStreaming.SetLockStatus(vehicle, true);
                        Main.EmoteMessage(Client, $"{vehicle.DisplayName} model aracı kilitler.");
                        Notify.Send(Client, "success", "Başarıyla aracı kilitlediniz!", 5000);
                    }
                    return;
                }
            }

            for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
            {

                if (FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_owned[i] != "Unknown" && FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_entity[i] == vehicle)
                {
                    if (VehicleStreaming.GetLockState(vehicle))
                    {
                        VehicleStreaming.SetLockStatus(vehicle, false);
                        Main.EmoteMessage(Client, $"{vehicle.DisplayName} model aracın kilidini açar.");
                        Notify.Send(Client, "success", "Başarıyla aracın kilidini açtınız!", 5000);
                    }
                    else
                    {
                        VehicleStreaming.SetLockStatus(vehicle, true);
                        Main.EmoteMessage(Client, $"{vehicle.DisplayName} model aracı kilitler.");
                        Notify.Send(Client, "success", "Başarıyla aracı kilitlediniz!", 5000);
                    }
                    return;
                }
            }
        }
        PropertySystem.PressKeyK(Client);
    }

    [RemoteEvent("keypress:bspc")]
    public void KeyPressbspc(Player Client)
    {

        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (Client.HasData("Y_Timeout") && Client.GetData<dynamic>("Y_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
        {
            Main.DisplaySubtitle(Client, "~g~[Antispam]", 2);
            return;
        }
        Client.SetData<dynamic>("Y_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 1000);

        Client.TriggerEvent("Hide_Crafting_System");
    }

    [RemoteEvent("keypress:J")]
    public void KeyPressJ(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (Client.HasData("Y_Timeout") && Client.GetData<dynamic>("Y_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
        {
            Main.DisplaySubtitle(Client, "~y~[Antispam]", 2);
            return;
        }
        Client.SetData<dynamic>("Y_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 1000);
        
    }



    [RemoteEvent("keypress:Y")]
    public void KeyPressY(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (Client.HasData("Y_Timeout") && Client.GetData<dynamic>("Y_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
        {
            Main.DisplaySubtitle(Client, "~y~[Antispam]", 2);
            return;
        }
        Client.SetData<dynamic>("Y_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 1000);

        if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
        {
            if (VehicleStreaming.GetEngineState(Client.Vehicle) == true)
            {

                VehicleStreaming.SetEngineState(Client.Vehicle, false);

            }
            else if (VehicleStreaming.GetEngineState(Client.Vehicle) == false)
            {

                if (Client.HasData("Refueling"))
                {
                    Main.SendErrorMessage(Client, "Yakıt doldurulurken motoru çalıştıramazsınız.");
                    return;
                }

                DisplaySubtitle(Client, " ", 3);


                Main.EmoteMessage(Client, "aracın anahtarını saat yönünde döndürerek motoru çalıştırmayı dener.");
                NAPI.Task.Run(() =>
                {
                    if (!Client.Exists) return;

                    if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
                    {
                        if (Client.Vehicle.Health < 300)
                        {
                            Main.SendErrorMessage(Client, "Aracın motoru hasarlı, motor çalıştırılamıyor.");
                            return;
                        }

                        if (NAPI.Data.HasEntityData(Client.Vehicle, "vehicle_colision"))
                        {

                            Main.SendErrorMessage(Client, "Motor durduruldu.");
                            return;
                        }

                        if (Main.GetVehicleFuel(Client.Vehicle) <= 2)
                        {

                            Main.SendErrorMessage(Client, "Aracın yakıtı yok, motor çalıştırılamıyor.");
                            return;
                        }
                        if (Client.Vehicle.HasData("IsInHighEnd") && Client.Vehicle.GetData<dynamic>("IsInHighEnd") == true)
                        {

                            Main.SendErrorMessage(Client, "Bu aracın anahtarlarına sahip değilsin.");
                            return;
                        }
                        if (Client.Vehicle.GetData<bool>("racveh") || Client.Vehicle.GetData<bool>("shipwar"))
                        {
                            return;
                        }

                        VehicleStreaming.SetEngineState(Client.Vehicle, true);

                        Main.EmoteMessage(Client, "aracın motorunu çalıştırdı.");
                    }
                }, delayTime: 1500);

            }
        }

        if (IsInRangeOfPoint(Client.Position, new Vector3(-202.1488, -1158.353, 23.81366), 3) || IsInRangeOfPoint(Client.Position, new Vector3(-177.1245, -1158.19, 23.81366), 3))
        {
            PlayerVehicle.ShowPlayerVehiclesToRelease(Client);
        }

        /*else if (IsInRangeOfPoint(Client.Position, new Vector3(-551.11, -189.87, 38.21), 1))
        {
            if (Main.GetPlayerMoney(Client) < 1000)
            {
                Main.DisplayErrorMessage(Client, "info", "Yeterli miktarda paran yok!");
                return;
            }
            Client.SetData<dynamic>("character_fish_lic", 720);
            Main.DisplayErrorMessage(Client, "success", "Başarıyla balıkçılık lisansı satın aldınız!");
            Main.GivePlayerMoney(Client, -1000);
            Main.SavePlayerInformation(Client);

        }*/

        else if (IsInRangeOfPoint(Client.Position, new Vector3(1110.95, 229.07, -49.63), 3))
        {
            Client.TriggerEvent("Display_casino");

        }

        else if (IsInRangeOfPoint(Client.Position, new Vector3(1104.59, 229.43, -49.62), 3) || IsInRangeOfPoint(Client.Position, new Vector3(1100.55, 231.84, -48.62), 3) || IsInRangeOfPoint(Client.Position, new Vector3(1109.61, 234.19, -49.62), 3) || IsInRangeOfPoint(Client.Position, new Vector3(1104.10, 233.07, -49.62), 3) || IsInRangeOfPoint(Client.Position, new Vector3(1117.158, 228.31, -49.62), 3) || IsInRangeOfPoint(Client.Position, new Vector3(1121.488, 232.12, -49.62), 3))
        {
            Client.TriggerEvent("Display_casino2");

        }

        else if (IsInRangeOfPoint(Client.Position, new Vector3(1143.20, 264.40, -50.64), 2) || IsInRangeOfPoint(Client.Position, new Vector3(1146.13, 261.42, -50.64), 2))
        {
            Client.TriggerEvent("Display_casino3");

        }

        else if (IsInRangeOfPoint(Client.Position, new Vector3(-712.58, -1298.56, 5.10), 4))
        {
            Client.TriggerEvent("Display_brent");

        }

        else if (IsInRangeOfPoint(Client.Position, new Vector3(31.35, -2770.85, 5.4), 4))
        {
            shipwar.stealship(Client);
        }

        else if (IsInRangeOfPoint(Client.Position, new Vector3(114.74, -1285.81, 27.96), 2))
        {
            playerCommands.privdance(Client);

        }


        else if (AccountManage.GetPlayerGroup(Client) == 1 && (IsInRangeOfPoint(Client.Position, new Vector3(467.95, -986.01, 25.72), 2)))
        {

            if (Client.GetData<dynamic>("duty") == 0) { InteractMenu_New.SendNotificationError(Client, Translation.notification_9); return; }
            if (NAPI.Player.IsPlayerInAnyVehicle(Client))
            {
                InteractMenu_New.SendNotificationError(Client, Translation.notification_10);

            }
            else
            {
                Client.TriggerEvent("Display_Polvehicles");

            }

        }
        else if (FactionManage.GetPlayerGroupID(Client) == FactionManage.FACTION_TYPE_MEDIC && IsInRangeOfPoint(Client.Position, new Vector3(338.57, -586.43, 28.79), 3))
        {

            if (Client.GetData<dynamic>("duty") == 0) { InteractMenu_New.SendNotificationError(Client, Translation.notification_9); return; }
            if (NAPI.Player.IsPlayerInAnyVehicle(Client))
            {
                InteractMenu_New.SendNotificationError(Client, Translation.notification_10);

            }
            else
            {
                Client.TriggerEvent("Display_Emsvehicles"); //medic

            }

        }
        else if (FactionManage.GetPlayerGroupID(Client) == FactionManage.FACTION_TYPE_MECHANIC && IsInRangeOfPoint(Client.Position, new Vector3(-345.3417, -123.1393, 39.00966), 3))
        {
            if (NAPI.Player.IsPlayerInAnyVehicle(Client))
            {
                InteractMenu_New.SendNotificationError(Client, Translation.notification_10);

            }
            else
            {
                Client.TriggerEvent("Display_Mehvehicles"); //mehanicar

            }

        }

        else if (AccountManage.GetPlayerGroup(Client) == 1 && IsInRangeOfPoint(Client.Position, new Vector3(471.31, -990.81, 25.73), 3))
        {
            if (Client.GetData<dynamic>("duty") == 0)
            {
                Client.SendNotification("Bu komutu kullanabilmek için işbaşında olmalısınız!");
                return;
            }
            Police.DisplayCopUniforms(Client);
            Client.Rotation = new Vector3(0, 0, 85.699543);

        }

        else if (AccountManage.GetPlayerGroup(Client) == 1 && IsInRangeOfPoint(Client.Position, new Vector3(473.29, -984.71, 25.73), 2))
        {
            if (Client.GetData<dynamic>("duty") == 0)
            {
                Client.SendNotification("Bu komutu kullanabilmek için işbaşında olmalısınız!");
                return;
            }
            Police.DisplayCopAddons(Client);
            Client.Rotation = new Vector3(0, 0, 85.699543);
        }

        else if (AccountManage.GetPlayerGroup(Client) == 2 && IsInRangeOfPoint(Client.Position, new Vector3(301.19, -596.50, 43.28), 2))
        {

            MedicSystem.DisplayMedicUniforms(Client);
            Client.Rotation = new Vector3(0, 0, 160.39);

        }

        else if (IsInRangeOfPoint(Client.Position, new Vector3(926.8, -1560.1, 30.7), 3f))
        {
            Translation.Create_Mechanic_Menu(Client);

        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(441.28094, -981.8585, 30.6896), 3))
        {
            Police.ShowCivilMenu(Client);

        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(463.86094, -1017.2485, 28.0896), 4))
        {
            Police.delpolcar(Client);
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(325.70, -557.12, 28.74), 4))
        {
            MedicSystem.delemscar(Client);
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-344.616, -130.8098, 39.00968), 4) && FactionManage.GetPlayerGroupID(Client) == 3)
        {
            Client.TriggerEvent("Display_mechdel");

        }
        else
        {
            ATMSystem.ATMShow(Client);
            BankSalary.BankShow(Client);
            PropertySystem.PressKeyY(Client);
            UsefullyRP.KeyPressY(Client);
            Rent.triggerrent(Client);
            EvSistemi.EvGirCik(Client);
            GeneralStore.SatinAl(Client);
            int count = 0;

            int business_id = 0;
            if (Client.HasData("InCCTV") && Client.GetData<dynamic>("InCCTV") == 2)
            {
                Client.ResetData("InCCTV");
                Client.TriggerEvent("Remote_End", Client.GetData<dynamic>("PLPOS"));
                Client.Transparency = 255;
                Client.TriggerEvent("freeze", false);
                Client.TriggerEvent("freezeEx", false);

            }

            foreach (var item in Security_Camera.camsaccess)
            {
                if (AccountManage.GetPlayerGroup(Client) != 1) { break; }

                if (Client.Position.DistanceTo(item.pos) < 2f)
                {
                    if (item.isinuse == false)
                    {
                        Security_Camera.ShowCameraList(Client);
                        item.isinuse = true;

                    }
                }
            }

            foreach (var business in BusinessManage.business_list)
            {
                if (IsInRangeOfPoint(Client.Position, new Vector3(-637.19, -2259.37, 5.93), 3))
                {
                    NAPI.ClientEvent.TriggerClientEvent(Client, "client:EhliyetOnay");
                }

                else if (IsInRangeOfPoint(Client.Position, new Vector3(484.21, -1001.63, 25.73), 2) && FactionManage.GetPlayerGroupID(Client) == 1)
                {
                    Client.TriggerEvent("Display_lspdguns");

                }
            }
            foreach (var faction in FactionManage.faction_data)
            {
                if (IsInRangeOfPoint(Client.Position, new Vector3(faction.faction_armory_x, faction.faction_armory_y, faction.faction_armory_z), 1))
                {
                    if (AccountManage.GetPlayerGroup(Client) != faction.faction_type)
                    {

                        return;
                    }
                    if (Client.GetData<dynamic>("duty") == 0)
                    {
                        InteractMenu_New.SendNotificationError(Client, Translation.head_notification_11);
                        return;
                    }
                    List<dynamic> menu_item_list = new List<dynamic>();
                    for (int i = 0; i < 20; i++)
                    {

                        if (faction.faction_armory_gun[i] == "0")
                        {
                            menu_item_list.Add(new { Type = 1, Name = "~w~" + i + ". ~c~Boş", Description = "", RightLabel = "" });
                        }
                        else
                        {
                            menu_item_list.Add(new { Type = 1, Name = "~w~" + i + ". ~y~" + faction.faction_armory_gun[i] + "", Description = "", RightLabel = "~r~(Ücret: " + faction.faction_armory_price[i] + "$/adet)" });
                        }

                    }

                    InteractMenu.CreateMenu(Client, "ARMORY_BUY_RESPONSE", "Çelik Yelek", "~b~" + faction.faction_name + ":", false, NAPI.Util.ToJson(menu_item_list), false);
                    return;
                }
            }


            count = 0;
            foreach (var werehouse in WerehouseManage.WereHouseData)
            {
                if (IsInRangeOfPoint(Client.Position, new Vector3(werehouse.exterior_x, werehouse.exterior_y, werehouse.exterior_z), 1))
                {
                    if (werehouse.lockStatus == true && werehouse.ownerid != AccountManage.GetPlayerGroup(Client))
                    {
                        InteractMenu_New.SendNotificationError(Client, Translation.notification_13);
                        return;
                    }

                    NAPI.Entity.SetEntityPosition(Client, new Vector3(werehouse.interior_x, werehouse.interior_y, werehouse.interior_z));
                    Client.Rotation = new Vector3(0.0f, 0.0f, werehouse.interior_a);
                    Client.Dimension = (uint)count + 500;
                }
                else if (IsInRangeOfPoint(Client.Position, new Vector3(werehouse.interior_x, werehouse.interior_y, werehouse.interior_z), 1) && NAPI.Entity.GetEntityDimension(Client) == count + 500)
                {
                    NAPI.Entity.SetEntityPosition(Client, new Vector3(werehouse.exterior_x, werehouse.exterior_y, werehouse.exterior_z));
                    Client.Rotation = new Vector3(0.0f, 0.0f, werehouse.exterior_a);
                    Client.Dimension = 0;
                }
                else if (IsInRangeOfPoint(Client.Position, new Vector3(werehouse.menu_x, werehouse.menu_y, werehouse.menu_z), 1))
                {
                    WerehouseManage.ShowWarehouseMenu(Client);
                    return;
                }
                count++;
            }
            count = 0;
            Client.TriggerEvent("fetch_nearby_atms", true);
        }
    }

    public static bool IsInRangeOfPoint(Vector3 playerPos, Vector3 target, float range)
    {
        var direct = new Vector3(target.X - playerPos.X, target.Y - playerPos.Y, target.Z - playerPos.Z);
        var len = direct.X * direct.X + direct.Y * direct.Y + direct.Z * direct.Z;
        return range * range > len;
    }

    public static void ShowTextForPlayer(Player Client, string message, int timer)
    {
        NAPI.Data.SetEntityData(Client, "ShowTextForPlayer", timer);
        NAPI.ClientEvent.TriggerClientEvent(Client, "show_text_for_player", message);
    }

    public void AFK_System()
    {



        TimerEx.SetTimer(() =>
        {
            foreach (var Player in NAPI.Pools.GetAllPlayers())
            {

                if (Player.Exists && Player.HasData("status") && Player.GetData<dynamic>("status"))
                {
                    if (Player.GetData<dynamic>("admin_duty") == 0 && Player.GetSharedData<dynamic>("Injured") == 0 && Player.GetData<dynamic>("character_ooc_prison_time") == 0 && Player.GetData<dynamic>("character_prison") == 0)
                    {
                        if (Player.GetData<dynamic>("Hunger") > 20 && Player.GetData<dynamic>("Thirsty") > 20)
                        {
                            if (Player.Health >= 20 && Player.GetData<dynamic>("IsHealing") == 1) { Player.SetData<dynamic>("IsHealing", 0); }

                            if (Player.Health < 20 && Player.HasData("IsHealing") == false || Player.GetData<dynamic>("IsHealing") == 0)
                            {
                                Player.SetData<dynamic>("IsHealing", 1);
                                if (Player.Health != 100)
                                {
                                    NAPI.Player.SetPlayerHealth(Player, Player.Health + 1);
                                }
                            }
                        }
                        if ((Player.GetData<dynamic>("Hunger") < 1 || Player.GetData<dynamic>("Thirsty") < 1) && Player.Health > 5)
                        {
                            if (Player.Health > 2 && Player.Health <= 100)
                            {
                                NAPI.Player.SetPlayerHealth(Player, Player.Health + -1);

                                Player.TriggerEvent("update_health", Player.Health, Player.Armor);

                            }

                        }
                    }
                }
            }
        }, 10000, 0);
    }

    class SaveVehiclesStruc
    {
        public Vector3 pos;
        public int sqlid;
        public double fuel;
    }
    public void AccountDataSave()
    {
        TimerEx.SetTimer(() =>
        {
            List<SaveVehiclesStruc> saveVehicles = new List<SaveVehiclesStruc>();
            foreach (var item in NAPI.Pools.GetAllVehicles())
            {
                if (item.HasData("Mashin_Owner") && item.HasData("veh_sql"))
                {
                    saveVehicles.Add(new SaveVehiclesStruc { pos = item.Position, sqlid = item.GetData<dynamic>("veh_sql"), fuel = GetVehicleFuel(item) });
                }
            }

            Task.Run(async () =>
            {

                using (MySqlConnection connection = new MySqlConnection(myConnectionString))
                {
                    await connection.OpenAsync();
                    MySqlCommand command = connection.CreateCommand();

                    foreach (var item in saveVehicles)
                    {
                        string main_query = "UPDATE vehicles SET ";
                        main_query = main_query + "`vehicle_position_x` = '" + item.pos.X.ToString() + "',";
                        main_query = main_query + "`vehicle_position_y` = '" + item.pos.Y.ToString() + "',";
                        main_query = main_query + "`vehicle_position_z` = '" + item.pos.Z.ToString() + "',";
                        main_query = main_query + "`vehicle_rotation_z` = '" + item.pos.Z.ToString() + "',";
                        main_query = main_query + "`fuel` = '" + Convert.ToInt32(item.fuel) + "'";
                        main_query = main_query + " WHERE `id` = " + item.sqlid + "";
                        command.CommandText = main_query;
                        await command.ExecuteNonQueryAsync();
                    }

                }

            });


        }, 120000, 0);

        TimerEx.SetTimer(() =>
        {
            long time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            NAPI.Task.Run(() =>
            {
                long respone = DateTimeOffset.Now.ToUnixTimeMilliseconds() + -(time + 1000);


            }, 1000);

        }, 1000, 0);

        TimerEx.SetTimer(() =>
        {
            long res = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            foreach (var Player in NAPI.Pools.GetAllPlayers())
            {
                if (AccountManage.GetPlayerConnected(Player))
                {
                    if (Player.HasData("SaveTime"))
                    {
                        if (Player.GetData<dynamic>("SaveTime") < 1)
                        {
                            SavePlayerInformation(Player);
                            Player.SetData<dynamic>("SaveTime", 12);
                        }
                        else
                        {
                            Player.SetData<dynamic>("SaveTime", (Player.GetData<dynamic>("SaveTime") - 1));
                        }

                    }
                    else
                    {
                        Player.SetData<dynamic>("SaveTime", 12);
                    }
                }
            }


        }, 10000, 0);




        TimerEx.SetTimer(() =>
        {
            try
            {

                if (Server_Minutes + 5 >= 60)
                {
                    if (Server_Hours + 1 >= 24)
                    {
                        NAPI.World.SetTime(1, 0, 0);

                        Server_Hours = 1;
                        Server_Minutes = 0;
                    }
                    else
                    {
                        NAPI.World.SetTime(Server_Hours + 1, 0, 0);


                        Server_Hours = Convert.ToByte(Server_Hours + 1);
                        Server_Minutes = 0;
                    }
                }
                else
                {

                    NAPI.World.SetTime(Server_Hours, Server_Minutes + 2, 0);
                    Server_Minutes = Convert.ToByte(Server_Minutes + 2);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }, 30000, 0);
    }

    public void GlobalTime()
    {
        try
        {
            TimerEx.SetTimer(() =>
            {
                NAPI.Data.SetWorldData("announceTime", NAPI.Data.GetWorldData("announceTime") + 1);

                if (NAPI.Data.GetWorldData("announceTime") > 2000)
                {
                    NAPI.Data.SetWorldData("announceTime", 1);
                }
                var players = NAPI.Pools.GetAllPlayers();
                foreach (var Player in players)
                {


                    if (Player.GetData<dynamic>("status") == true)
                    {
                        Player.TriggerEvent("update_health", Player.Health, Player.Armor);
                        NAPI.ClientEvent.TriggerClientEvent(Player, "update_hunger_display", (int)Player.GetData<dynamic>("Hunger"), (int)Player.GetData<dynamic>("Thirsty"));


                        if (Player.GetData<dynamic>("inEffect_weed") > 0)
                        {
                            Player.SetData<dynamic>("inEffect_weed", Player.GetData<dynamic>("inEffect_weed") - 1);

                            if (Player.GetData<dynamic>("inEffect_weed") == 0)
                            {
                                InteractMenu_New.SendNotificationInfo(Player, Translation.notification_15);
                                Player.TriggerEvent("stop_screen_effect", "DrugsMichaelAliensFight");
                                Player.SetData<dynamic>("inEffect_weed", -1);
                            }
                        }

                        if (Player.GetData<dynamic>("inEffect_heroin") > 0)
                        {
                            Player.SetData<dynamic>("inEffect_heroin", Player.GetData<dynamic>("inEffect_heroin") - 1);

                            if (Player.GetData<dynamic>("inEffect_heroin") == 0)
                            {
                                Player.TriggerEvent("setResistStage", 0);
                                InteractMenu_New.SendNotificationInfo(Player, Translation.notification_14);
                                Player.TriggerEvent("stop_screen_effect", "DrugsDrivingOut");
                                Player.TriggerEvent("screen_cocaine_off");
                                Player.SetData<dynamic>("inEffect_heroin", -1);
                            }
                        }

                        if (Player.GetData<dynamic>("character_prison") == 1)
                        {

                            if (Player.GetData<dynamic>("character_prison_time") > 0)
                            {
                                Player.SetData<dynamic>("character_prison_time", Player.GetData<dynamic>("character_prison_time") - 1);
                                Player.TriggerEvent("JailTime", Player.GetData<dynamic>("character_prison_time"));

                                if (!IsInRangeOfPoint(Player.Position, prison_spawns[Player.GetData<dynamic>("character_prison_cell")].position, 2.25f))
                                {
                                    NAPI.Entity.SetEntityPosition(Player, prison_spawns[Player.GetData<dynamic>("character_prison_cell")].position);
                                    Player.Rotation = prison_spawns[Player.GetData<dynamic>("character_prison_cell")].rotation;
                                }

                            }
                            else
                            {
                                Police.ClearPlayerCrime(Player);
                                Player.TriggerEvent("JailTime", 0);
                                UpdatePlayerClothes(Player);
                                Player.SetData<dynamic>("character_prison", 0);
                                Player.SetData<dynamic>("character_prison_time", 0);
                                Main.SendCustomChatMessasge(Player, Translation.notification_16);

                                NAPI.Entity.SetEntityPosition(Player, new Vector3(417.09, -978.70, 29.42));
                                Player.Rotation = new Vector3(0, 0, 6.041231);
                                Player.TriggerEvent("freeze", false);
                                if (NAPI.Data.GetEntityData(Player, "MainProgressText") == true)
                                {
                                    DeleteTextProgressBar(Player);
                                }

                            }
                        }

                        if (Player.GetData<dynamic>("character_ooc_prison_time") > 0)
                        {
                            Player.SetData<dynamic>("character_ooc_prison_time", Player.GetData<dynamic>("character_ooc_prison_time") - 1);
                            Player.TriggerEvent("JailTime", Player.GetData<dynamic>("character_ooc_prison_time"));

                            if (!IsInRangeOfPoint(Player.Position, new Vector3(1651.297, 2573.728, 45.56485), 17.25f))
                            {
                                NAPI.Entity.SetEntityPosition(Player, new Vector3(1651.297, 2573.728, 45.56485));
                                Player.Rotation = new Vector3(0, 0, 181.6034);
                                Player.Dimension = 255;
                            }

                            if (Player.GetData<dynamic>("character_ooc_prison_time") == 0)
                            {
                                Player.TriggerEvent("JailTime", 0);

                                Main.SendCustomChatMessasge(Player, Translation.message_08);
                                Main.SendCustomChatMessasge(Player, Translation.message_09);

                                NAPI.Entity.SetEntityPosition(Player, new Vector3(1852.602, 2585.687, 45.67206));
                                Player.Rotation = new Vector3(0, 0, 263.0871);
                                Player.Dimension = 0;

                            }
                        }

                        if (Player.GetSharedData<dynamic>("Injured") == 1 && Player.GetData<dynamic>("character_prison") == 0 && Player.GetSharedData<dynamic>("InjuredTime") > 0)
                        {
                            Player.SetSharedData("InjuredTime", Player.GetSharedData<dynamic>("InjuredTime") - 1);
                        }
                        else if (Player.GetSharedData<dynamic>("Injured") == 1 && Player.GetData<dynamic>("character_prison") == 0 && Player.GetSharedData<dynamic>("InjuredTime") <= 0)
                        {
                            Player.SetSharedData("Injured", 0);
                            NAPI.Player.SetPlayerHealth(Player, 40);
                            Player.TriggerEvent("update_health", Player.Health, Player.Armor);
                            Player.TriggerEvent("InjuredSystem:Destroy");
                            Player.TriggerEvent("freeze", false);
                            Player.TriggerEvent("freezeEx", false);
                            NAPI.Player.StopPlayerAnimation(Player);
                        }

                        if (Player.GetSharedData<dynamic>("Injured") == 2 && Player.GetData<dynamic>("character_prison") == 0)
                        {
                            Player.SetSharedData("InjuredTime", Player.GetSharedData<dynamic>("InjuredTime") - 1);

                            if (Player.GetSharedData<dynamic>("InjuredTime") < 1)
                            {
                                Player.SetSharedData("Injured", 0);
                                Player.SetSharedData("InjuredTime", 0);
                                Police.UnDragPlayer(Player);

                                NAPI.ClientEvent.TriggerClientEvent(Player, "DestroyCustomCamera");

                                Random rnd = new Random();
                                int random_spawn = rnd.Next(0, 1);
                                switch (random_spawn)
                                {
                                    case 0:
                                        {

                                            NAPI.Entity.SetEntityPosition(Player, new Vector3(322.93638, -595.65088, 43.28283));
                                            Player.Rotation = new Vector3(0, 0, 57.76836);
                                            break;
                                        }
                                    case 1:
                                        {
                                            NAPI.Entity.SetEntityPosition(Player, new Vector3(318.48638, -593.97088, 43.28283));
                                            Player.Rotation = new Vector3(0, 0, 57.76836);
                                            break;
                                        }
                                }
                                Player.Dimension = 0;

                                Player.TriggerEvent("freeze", false);
                                Player.TriggerEvent("freezeEx", false);

                                Main.SendCustomChatMessasge(Player, Translation.message_10);
                                GivePlayerMoneyBank(Player, -2500);
                                int totalmoney = GetPlayerMoney(Player);
                                GivePlayerMoney(Player, -totalmoney);

                                CharCreator.CharCreator.ApplyCharacter(Player);
                                Main.UpdatePlayerClothes(Player);

                                AccountManage.SetPlayerHunger(Player, 50.0f);
                                AccountManage.SetPlayerThirsty(Player, 40.0f);

                                NAPI.Player.SetPlayerHealth(Player, 100);
                                Player.TriggerEvent("update_health", Player.Health, Player.Armor);

                                Player.SetSharedData("character_hospital", 0);
                                WeaponManage.LoadPlayerWeaponIC(Player);

                            }
                        }

                        if (Player.Health <= 39 && Player.GetData<dynamic>("LowHealthEffect") == false)
                        {
                            Player.SetData<dynamic>("LowHealthEffect", true);

                            Utils.SetScreenEffectToPlayer(Player, "FocusIn", 2000);
                        }
                        else if (Player.Health >= 40 && NAPI.Data.HasEntityData(Player, "LowHealthEffect") == true)
                        {
                            Player.SetData<dynamic>("LowHealthEffect", false);

                            Utils.StopScreenEffectToPlayer(Player, "FocusIn");
                        }


                        if (Player.GetData<dynamic>("admin_duty") == 0 && Player.GetSharedData<dynamic>("Injured") == 0 && Player.GetData<dynamic>("character_ooc_prison_time") == 0 && Player.GetData<dynamic>("character_prison") == 0)
                        {
                            Player.SetData<dynamic>("HungerTimer", Player.GetData<dynamic>("HungerTimer") + 1);

                            if (Player.GetData<dynamic>("Hunger") > 20 && Player.GetData<dynamic>("Thirsty") > 20)
                            {
                                if (Player.Health >= 20 && Player.GetData<dynamic>("IsHealing") == 1) { Player.SetData<dynamic>("IsHealing", 0); }
                            }

                            if (Player.GetData<dynamic>("HungerTimer") >= 25)
                            {

                                Player.SetData<dynamic>("HungerTimer", 0);

                                if (Player.GetData<dynamic>("Hunger") < 1)
                                {
                                    Player.SetData<dynamic>("Hunger", 0);
                                }
                                else if (NAPI.Data.GetEntityData(Player, "character_prison") == 0) Player.SetData<dynamic>("Hunger", Player.GetData<dynamic>("Hunger") - 0.25);


                                if (Player.GetData<dynamic>("Thirsty") < 1)
                                {
                                    Player.SetData<dynamic>("Thirsty", 0);
                                }
                                else if (NAPI.Data.GetEntityData(Player, "character_prison") == 0) Player.SetData<dynamic>("Thirsty", Player.GetData<dynamic>("Thirsty") - 0.30);


                                NAPI.ClientEvent.TriggerClientEvent(Player, "update_hunger_display", (int)Player.GetData<dynamic>("Hunger"), (int)Player.GetData<dynamic>("Thirsty"));
                            }



                        }
                        if (NAPI.Data.GetEntityData(Player, "LastTransaction") > 0)
                        {
                            if (NAPI.Data.GetEntityData(Player, "LastTransaction") > 0)
                            {
                                int time = NAPI.Data.GetEntityData(Player, "LastTransaction");
                                NAPI.Data.SetEntityData(Player, "LastTransaction", --time);

                                if (NAPI.Data.GetEntityData(Player, "LastTransaction") == 0) NAPI.Data.SetEntityData(Player, "LastTransaction", -1);
                            }
                        }
                        if (Player.HasData("inVehicleInventory"))
                        {
                            if (Player.HasData("inVehicleInventory") && Player.GetData<dynamic>("inVehicleInventory") == true)
                            {
                                if (Player.HasData("vehicle_handle_inv"))
                                {
                                    Vehicle vehicle = Utils.GetClosestVehicle(Player, 3);
                                    if (vehicle != null)
                                    {
                                        if (Player.IsInVehicle)
                                        {
                                            VehicleInventory.HidePlayerVehicleInventory(Player);
                                        }
                                        else if (NAPI.Vehicle.GetVehicleHealth(vehicle) < 1)
                                        {
                                            VehicleInventory.HidePlayerVehicleInventory(Player);
                                        }

                                        if (vehicle != Player.GetData<dynamic>("vehicle_handle_inv"))
                                        {
                                            VehicleInventory.HidePlayerVehicleInventory(Player);
                                        }
                                    }
                                    else
                                    {
                                        VehicleInventory.HidePlayerVehicleInventory(Player);
                                    }

                                }
                                else
                                {
                                    VehicleInventory.HidePlayerVehicleInventory(Player);
                                }
                            }
                        }


                        if (Player.GetData<dynamic>("displayMessage_Timer") >= 0)
                        {
                            Player.SetData<dynamic>("displayMessage_Timer", Player.GetData<dynamic>("displayMessage_Timer") - 1);
                            if (Player.GetData<dynamic>("displayMessage_Timer") == 0)
                            {
                                Player.SetData<dynamic>("displayMessage_Timer", -1);
                                NAPI.Task.Run(() =>
                                {
                                    if (!Player.Exists) return;

                                    Player.TriggerEvent("displayMessage", " ");
                                }, delayTime: 1000);
                            }
                        }

                        if (Player.IsInVehicle && Player.Vehicle.HasData("TransportDuty"))
                        {
                            if (Player.Vehicle.GetData<dynamic>("TransportDuty") == true)
                            {
                                Player.Vehicle.SetData<dynamic>("TransportTime", Player.Vehicle.GetData<dynamic>("TransportTime") + 1);

                                if (Player.VehicleSeat != (int)VehicleSeat.Driver && GetPlayerMoney(Player) < (Player.GetData<dynamic>("TaxiFee") + Player.Vehicle.GetData<dynamic>("TransportPrice")))
                                {
                                    NAPI.Player.WarpPlayerOutOfVehicle(Player);
                                    Player.TriggerEvent("update_taxi_fare", false, 0, 0, false);
                                }

                                if (Player.Vehicle.GetData<dynamic>("TransportTime") > 20 && Player.IsInVehicle && Player.VehicleSeat != (int)VehicleSeat.Driver)
                                {
                                    Player.Vehicle.SetData<dynamic>("TransportTime", 0);

                                    if (Main.GetPlayerMoney(Player) < (Player.GetData<dynamic>("TaxiFee") + Player.Vehicle.GetData<dynamic>("TransportPrice")))
                                    {
                                        Player.WarpOutOfVehicle();
                                        Player.TriggerEvent("update_taxi_fare", false, 0, 0, false);
                                        goto end;
                                    }


                                    Player.SetData<dynamic>("TaxiFee", Player.GetData<dynamic>("TaxiFee") + Player.Vehicle.GetData<dynamic>("TransportPrice"));



                                    Player.Vehicle.SetData<dynamic>("TransportFee", Player.Vehicle.GetData<dynamic>("TransportFee") + Player.Vehicle.GetData<dynamic>("TransportPrice"));

                                    Player.TriggerEvent("createNewHeadNotificationAdvanced", "~w~Oran ~y~-~r~$" + Player.Vehicle.GetData<dynamic>("TransportPrice") + "");

                                }


                                if (Player.IsInVehicle && Player.VehicleSeat == (int)VehicleSeat.Driver)
                                {
                                    Player.TriggerEvent("update_taxi_fare", true, Player.Vehicle.GetData<dynamic>("TransportPrice"), Player.Vehicle.GetData<dynamic>("TransportFee"), false);
                                }
                                else if (Player.IsInVehicle) Player.TriggerEvent("update_taxi_fare", true, Player.Vehicle.GetData<dynamic>("TransportPrice"), Player.GetData<dynamic>("TaxiFee"), true);
                            }

                        }
                    end:
                        if (Player.IsInVehicle)
                        {

                        }

                        if (UsefullyRP.seatbelt[Main.getIdFromClient(Player)] == true && !Player.IsInVehicle)
                        {
                            UsefullyRP.seatbelt[Main.getIdFromClient(Player)] = false;
                            NAPI.Player.ClearPlayerAccessory(Player, 0);
                            Player.SetSharedData("helmet", -1);
                            Player.SetSharedData("helmet_texture", 0);
                            Main.UpdatePlayerClothes(Player);
                        }
                    }


                }
            }, 1000, 0, true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }
    }


    public void PlayerAccountSave()
    {
        TimerEx.SetTimer(() =>
        {
            try
            {
                var players = NAPI.Pools.GetAllPlayers();
                foreach (var Player in players)
                {
                    if (Player.GetData<dynamic>("status") == true)
                    {
                        if (Player.Health <= 19 && Player.GetSharedData<dynamic>(WalkingStyle.SharedData_Walkstyle) == WalkingStyle.Normal)
                        {

                            WalkingStyle.SetWalkStyle(Player, WalkingStyle.Injured, true);
                        }
                        else if (Player.Health >= 20 && Player.GetSharedData<dynamic>(WalkingStyle.SharedData_Walkstyle) == WalkingStyle.Injured)
                        {

                            WalkingStyle.SetWalkStyle(Player, Player.GetData<dynamic>("character_WalkStyle"), false);
                        }

                        if (Player.GetData<dynamic>("admin_duty") == 1) { goto End; }

                    End:
                        string Minutes = Server_Minutes.ToString();
                        string Hours = Server_Hours.ToString();
                        if (Server_Minutes.ToString().Length == 1)
                        {
                            Minutes = "0" + Server_Minutes;
                        }
                        if (Server_Hours.ToString().Length == 1)
                        {
                            Hours = "0" + Server_Hours;
                        }

                        Player.TriggerEvent("TimeOfDay", "" + Hours + ":" + Minutes + ""); ;

                        Player.TriggerEvent("Discord_Update", SERVER_NAME + " (Oyunda) - " + AccountManage.GetCharacterName(Player) + " (" + getIdFromClient(Player) + ") ", SERVER_WEBSITE);
                        Player.TriggerEvent("Update_Players", (NAPI.Pools.GetAllPlayers().Count).ToString(), (MAX_PLAYERS).ToString());
                        Player.TriggerEvent("EpochTime", "id:" + getIdFromClient(Player));
                    }


                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

        }, 5000, 0);
    }

    public void UpdateWeapon()
    {
        TimerEx.SetTimer(() =>
        {
            try
            {
                var players = NAPI.Pools.GetAllPlayers();
                foreach (var Player in players)
                {
                    if (Player.GetData<dynamic>("status") == true)
                    {
                        Player.TriggerEvent("UpdateMoneyBankName", GetPlayerMoney(Player), GetPlayerBank(Player), AccountManage.GetCharacterName(Player), Main.getIdFromClient(Player));
                        Player.TriggerEvent("UpdateWeaponInfo"); 
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

        }, 500, 0);
    }

    public async void CheckRoundClock()
    {
        try
        {
            while (true)
            {
                // Wait until the next round clock
                DateTime nextRoundClock = DateTime.Now.AddHours(1).AddMinutes(-DateTime.Now.Minute);
                TimeSpan delay = nextRoundClock - DateTime.Now;
                await Task.Delay(delay);

                // Check the time and trigger the event if necessary
                DateTime now = DateTime.Now;
                if (now.Minute == 0)
                {
                    houserobbery.ResetHousesRob();
                    foreach (Player pl in NAPI.Pools.GetAllPlayers())
                    {
                        if (pl.Exists == false) { continue; }

                        if (pl.GetData<dynamic>("status") == true)
                        {
                            FactionManage.PrintBandsWith10RowsOrMore();
                            if (PAYDAYMULTIPLIER == 1)
                            {
                                Translation.PayExp(pl);
                                Translation.PayDay(pl);
                            }
                            else if (PAYDAYMULTIPLIER == 2)
                            {
                                Translation.PayExp(pl);
                                Translation.PayExp(pl);
                                Translation.PayDay(pl);
                            }
                            else if (PAYDAYMULTIPLIER == 3)
                            {
                                Translation.PayExp(pl);
                                Translation.PayExp(pl);
                                Translation.PayExp(pl);
                                Translation.PayDay(pl);
                            }
                        }
                    }
                }

                if (now.Hour == 04)
                {

                    using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                    {
                        Mainpipeline.Open();

                        MySqlCommand query = new MySqlCommand("UPDATE `characters` SET `zadatak`= 0", Mainpipeline);
                        query.ExecuteNonQuery();
                        Mainpipeline.Close();

                    }
                    foreach (Player pl in NAPI.Pools.GetAllPlayers())
                    {
                        if (pl.Exists == false) { continue; }

                        if (pl.GetData<dynamic>("status") == true)
                        {
                            pl.SetData("zadatakd", 0);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle the exception here, for example by logging it or sending an alert
            Console.WriteLine("An exception occurred in CheckRoundClock: " + ex.Message);
        }
    }


    [Command("apayday", "/apayday [Payday]")]
    public void pdxCMD(Player Client, int xpmultiple)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 8)
        {
            Main.SendErrorMessage(Client, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        if (xpmultiple > 3 || xpmultiple < 1)
        {
            Main.SendErrorMessage(Client, "Payday durumu minimum 1, maksimum 3 olabilir.");
            return;
        }
        PAYDAYMULTIPLIER = xpmultiple;

    }

    public void UpdateTime()
    {
        TimerEx.SetTimer(() =>
        {
            try
            {
                DoorLock.UpdateTime();

                foreach (var veh in NAPI.Pools.GetAllVehicles())
                {
                    if (VehicleStreaming.GetEngineState(veh) == true)
                    {
                        double fuelLevel = GetVehicleFuel(veh);
                        if (fuelLevel > 0.0)
                        {
                            SetVehicleFuel(veh, fuelLevel - 0.15);
                            if (GetVehicleFuel(veh) <= 2.0)
                            {
                                SetVehicleFuel(veh, 0.0);
                                VehicleStreaming.SetEngineState(veh, false);
                            }
                        }
                    }

                    foreach (var ls in LSCUSTOM_NEW.ls_custom)
                    {
                        if (ls.in_use == true && ls.vehicle == veh)
                        {
                            if (API.Shared.GetVehicleDriver(veh) == null || !Main.IsInRangeOfPoint(veh.Position, ls.position, 5.0f))
                            {
                                ls.in_use = false;
                                ls.vehicle = null;
                                ls.label_position.Text = Translation.ls_custom_label_free;
                                veh.ResetData("lscustom_use");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }, 7000, 0);
    }

    public void DeksBugDuzelt()
    {
        TimerEx.SetTimer(() =>
        {
            try
            {
                var players = NAPI.Pools.GetAllPlayers();
                foreach (var Player in players)
                {
                    if (Player.GetData<dynamic>("status") == true)
                    {
                        if (Player.GetData<int>("galeriDimension") == -1)
                        {
                            if (Player.GetData<int>("OyuncuEv") != -1)
                            {
                                if (Player.Dimension == 0)
                                {
                                    Main.SendErrorMessage(Player, "İnterior bugu sistem tarafından otomatik olarak düzeltildi.");
                                    Player.SetData<int>("OyuncuEv", -1);
                                }
                            }
                            else if (Player.Dimension != 0)
                            {
                                if (Player.GetData<int>("OyuncuEv") == -1)
                                {
                                    Main.SendErrorMessage(Player, "İnterior bugu sistem tarafından otomatik olarak düzeltildi.");
                                    Player.Dimension = 0;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }, 2000, 0);
    }

    public static void Display_Player_NotfMenu(Player Client, string title, string MainText, string description, string color)
    {
        Client.TriggerEvent("Display_Player_NotfMenu", title, MainText, description, color);
    }
    public static void Destroy_NotfMenu(Player client)
    {
        client.TriggerEvent("Destroy_NotfMenu");
    }
    public static int GetPlayerMoney(Player Client)
    {
        return Convert.ToInt32(NAPI.Data.GetEntityData(Client, "character_money"));
    }

    public static int GetPlayerBank(Player Client)
    {
        return Convert.ToInt32(NAPI.Data.GetEntityData(Client, "character_bank"));
    }

    public static int GetSalaryFromBank(Player Client)
    {

        return Convert.ToInt32(NAPI.Data.GetEntityData(Client, "character_SalaryValue"));

    }

    public static void TakePlayerMoney(Player client, int NotNegative)
    {
        if (GetPlayerMoney(client) >= NotNegative)
        {
            GivePlayerMoney(client, -NotNegative);
        }
        else if (GetPlayerBank(client) >= NotNegative)
        {
            GivePlayerMoneyBank(client, -NotNegative);
        }
    }
    public static void GivePlayerMoney(Player Client, int value)
    {
        int islem = 2;
        if (value < 0)
        {
            islem = 1;
        }
        else if (value > 0)
        {
            islem = 2;
        }
        Client.TriggerEvent("ParaIslemEvent", islem, value);
        NAPI.Data.SetEntityData(Client, "character_money", (Convert.ToInt32(NAPI.Data.GetEntityData(Client, "character_money")) + value));
        UpdateMoneyDisplay(Client);
        Main.SavePlayerInformation(Client);
        GameLog.ELog(Client, GameLog.MyEnum.Money, " Para kazandı " + " Miktar: " + value);
    }

    public static void GiveCompanyMoney(int id, int money)
    {
        int bizmoney = 0;
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandText = ("SELECT `money` FROM `companies` WHERE `id` = '" + id + "';");
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    bizmoney = reader.GetInt32("money");
                }
            }
            Mainpipeline.Close();
        }
        int totbmoney = bizmoney + money;
        Main.CreateMySqlCommand("UPDATE `companies` SET `money` = '" + totbmoney + "'  WHERE `id` = '" + id + "';");
    }

    public static void GivePlayerMoneyBank(Player Client, int value)
    {
        //int islem = 2;
        //if (value < 0)
        //{
        //    islem = 1;
        //}
        //else if (value > 0)
        //{
        //    islem = 2;
        //}
        //Client.TriggerEvent("ParaIslemEvent", islem, value);
        NAPI.Data.SetEntityData(Client, "character_bank", (Convert.ToInt32(NAPI.Data.GetEntityData(Client, "character_bank") + value)));
        UpdateMoneyDisplay(Client);
        Main.SavePlayerInformation(Client);
        GameLog.ELog(Client, GameLog.MyEnum.Money, " Para aldı Banka: " + " Miktar: " + value);

    }

    public static void GivePlayerSalary(Player Client, int value)
    {
        int islem = 2;
        if (value < 0)
        {
            islem = 1;
        }
        else if (value > 0)
        {
            islem = 2;
        }
        Client.TriggerEvent("ParaIslemEvent", islem, value);
        NAPI.Data.SetEntityData(Client, "character_SalaryValue", (Convert.ToInt32(NAPI.Data.GetEntityData(Client, "character_SalaryValue") + value)));
        UpdateMoneyDisplay(Client);
        Main.SavePlayerInformation(Client);
        GameLog.ELog(Client, GameLog.MyEnum.Money, " Oyuncu maaş aldı: " + " Miktar: " + value);
    }

    public static void SetPlayerMoney(Player Client, int value)
    {
        NAPI.Data.SetEntityData(Client, "character_money", value);
        UpdateMoneyDisplay(Client);
        Main.SavePlayerInformation(Client);
        GameLog.ELog(Client, GameLog.MyEnum.Money, " Oyuncunun nakit parası ayarlandı: " + " Miktar: " + value);
    }

    public static void SetPlayerMoneyBank(Player Client, int value)
    {
        NAPI.Data.SetEntityData(Client, "character_bank", value);
        UpdateMoneyDisplay(Client);
        Main.SavePlayerInformation(Client);
        GameLog.ELog(Client, GameLog.MyEnum.Money, " Oyuncunun banka parası ayarlandı: " + " Miktar: " + value);
    }

    public static void UpdateMoneyDisplay(Player Client)
    {
        if (NAPI.Data.GetEntityData(Client, "character_money") < -1)
        {
            NAPI.ClientEvent.TriggerClientEvent(Client, "update_money_display", "" + NAPI.Data.GetEntityData(Client, "character_money"), NAPI.Data.GetEntityData(Client, "character_bank"));
        }
        else NAPI.ClientEvent.TriggerClientEvent(Client, "update_money_display", NAPI.Data.GetEntityData(Client, "character_money"), NAPI.Data.GetEntityData(Client, "character_bank"));
    }

    public static void EmoteMessage(Player Client, string message)
    {
        try
        {
            int playerid = getIdFromClient(Client);
            if (emote_timer[playerid] != null)
            {
                emote_timer[playerid].Kill();
                emote_timer[playerid] = null;

            }
            Client.SetSharedData("emoteTimeout", 5);
            Client.SetSharedData("emoteText", message);
            emote_timer[playerid] = TimerEx.SetTimer(() =>
            {
                if (AccountManage.GetPlayerConnected(Client))
                {

                    Client.SetSharedData("emoteTimeout", Client.GetSharedData<int>("emoteTimeout") - 1);

                    if (Client.GetSharedData<dynamic>("emoteTimeout") == 0)
                    {
                        Client.SetSharedData("emoteText", "");
                        try
                        {
                            emote_timer[playerid].Kill();
                        }
                        catch
                        {

                        }
                        emote_timer[playerid] = null;
                    }
                }

            }, 1000, 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }



    public static void g_mysql_create_character(Player Client, string character_name, sbyte age, string customization)
    {
        try
        {
            using (MySqlConnection Mainpipeline = new MySqlConnection(myConnectionString))
            {

                Mainpipeline.Open();
                MySqlCommand query = Mainpipeline.CreateCommand();
                query.CommandType = CommandType.Text;
                query.CommandText = "SELECT * FROM `characters` WHERE `name` = '" + character_name + "'";
                query.ExecuteNonQuery();
                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(query))
                {
                    da.Fill(dt);
                    int i = 0;
                    NAPI.Util.ConsoleOutput("Crash #2");

                    i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 0)
                    {
                        Client.SetData<dynamic>("firstJoinned", true);



                        string character_query = "INSERT INTO `characters` (name, age,userid, money, bank, salary, CreateCharacter, character_vip_date, character_vip_expire, LastLogin) VALUES (@name, @age,@sqlid, 0, 0, 0, @timenow, @character_vip_date, @character_vip_expire, @LastLogin);";

                        MySqlCommand CreatNewAccount = new MySqlCommand(character_query, Mainpipeline);

                        CreatNewAccount.Parameters.AddWithValue("@name", "" + character_name + "");
                        CreatNewAccount.Parameters.AddWithValue("@age", "" + age + "");
                        //CreatNewAccount.Parameters.Add("@age", MySqlDbType.Byte).Value = age;
                        CreatNewAccount.Parameters.AddWithValue("@sqlid", NAPI.Data.GetEntityData(Client, "player_sqlid"));
                        CreatNewAccount.Parameters.AddWithValue("@timenow", DateTime.Now);
                        CreatNewAccount.Parameters.AddWithValue("@character_vip_date", DateTime.Now);
                        CreatNewAccount.Parameters.AddWithValue("@character_vip_expire", DateTime.Now);
                        CreatNewAccount.Parameters.AddWithValue("@LastLogin", DateTime.Now);

                        CreatNewAccount.ExecuteNonQuery();

                        long last_insert_id = CreatNewAccount.LastInsertedId;
                        Client.SetData<dynamic>("character_sqlid", last_insert_id);

                        Main.CreateMySqlCommand("UPDATE `characters` SET `char` = '" + customization + "' WHERE name = '" + character_name + "';");

                        NAPI.Task.Run(() =>
                        {
                            if (!Client.Exists) return;

                            AccountManage.LoadCharacter(Client, (int)last_insert_id);

                            if (Client.GetData<dynamic>("creator_outfit") == 0)
                            {
                                if (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE") == 0)
                                {
                                    Client.SetClothes(3, 15, 0);
                                    Client.SetClothes(4, 21, 0);
                                    Client.SetClothes(6, 34, 0);
                                    Client.SetClothes(8, 15, 0);
                                    Client.SetClothes(11, 15, 0);

                                    Client.SetSharedData("character_torso", 15);

                                    Client.SetSharedData("character_leg", 21);
                                    Client.SetSharedData("character_leg_texture", 0);

                                    Client.SetSharedData("character_feet", 34);
                                    Client.SetSharedData("character_feet_texture", 0);

                                    Client.SetSharedData("character_undershirt", 15);
                                    Client.SetSharedData("character_undershirt_texture", 0);

                                    Client.SetSharedData("character_shirt", 11);
                                    Client.SetSharedData("character_shirt_texture", 0);

                                }
                                else
                                {
                                    Client.SetSharedData("character_torso", 15);

                                    Client.SetSharedData("character_leg", 10);
                                    Client.SetSharedData("character_leg_texture", 0);

                                    Client.SetSharedData("character_feet", 35);
                                    Client.SetSharedData("character_feet_texture", 0);

                                    Client.SetSharedData("character_undershirt", 15);
                                    Client.SetSharedData("character_undershirt_texture", 0);

                                    Client.SetSharedData("character_shirt", 15);
                                    Client.SetSharedData("character_shirt_texture", 0);

                                    Client.SetClothes(3, 15, 0);
                                    Client.SetClothes(4, 10, 0);
                                    Client.SetClothes(6, 35, 0);
                                    Client.SetClothes(8, 15, 0);
                                    Client.SetClothes(11, 15, 0);
                                }
                            }
                            else
                            {
                                Client.SetData<dynamic>("character_outfit", Client.GetData<dynamic>("creator_outfit"));
                                Outfits.SetUnisexOutfit(Client, Client.GetData<dynamic>("creator_outfit"), true);
                            }
                        }, delayTime: 300);

                    }
                    else
                    {
                        Main.SendErrorMessage(Client, "Ovde...");
                    }
                    Mainpipeline.Close();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("g_mysql_create_character");
            Console.Write(e);
        }
    }



    public static int g_mysql_get_characters_created(Player Client)
    {
        int i = 0;
        using (MySqlConnection Mainpipeline = new MySqlConnection(myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT * FROM `characters` WHERE `userid` = '" + NAPI.Data.GetEntityData(Client, "player_sqlid") + "'";
            query.ExecuteNonQuery();

            DataTable dt = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query))
            {
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
            }
            Mainpipeline.Close();
        }
        return i;
    }

    public static bool g_mysql_get_VIP_status(Player Client)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT `character_vip_expire` FROM `characters` WHERE `userid` = '" + NAPI.Data.GetEntityData(Client, "player_sqlid") + "'";

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetDateTime("character_vip_expire") > DateTime.Now)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            Mainpipeline.Close();

        }
        return false;
    }

    public static string SQLIDToName(int sqlid)
    {
        const string defaultName = "N/A";

        using (MySqlConnection connection = new MySqlConnection(myConnectionString))
        {
            connection.Open();

            using (MySqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT `name` FROM `characters` WHERE `id` = @sqlid LIMIT 1";
                command.Parameters.AddWithValue("@sqlid", sqlid);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader["name"]?.ToString();

                        if (!string.IsNullOrWhiteSpace(name))
                            return name;
                    }
                }
            }
        }

        return defaultName;
    }


    public static int MYSQL_ISPLAYERRegistered(Player player)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT `socialclubname` FROM `users` WHERE `socialclubname` = '" + player.SocialClubName + "' ORDER BY id DESC LIMIT 1";

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    return 1;

                }
            }
            Mainpipeline.Close();
        }
        return 0;
    }

    public static int g_mysql_get_Last_Character_id(Player Client)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT `id` FROM `characters` WHERE `userid` = '" + NAPI.Data.GetEntityData(Client, "player_sqlid") + "' ORDER BY id DESC LIMIT 1";

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    return reader.GetInt32("id");

                }
            }
            Mainpipeline.Close();
        }
        return -1;
    }

    [ServerEvent(Event.PlayerDamage)]
    public void OnPlayerDamage(Player player, float healthLoss, float armorLoss)
    {
        if (player.HasData("Punch_Timeout") && player.GetData<dynamic>("Punch_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
        {
            NAPI.Player.StopPlayerAnimation(player);
            return;
        }
        player.SetData<dynamic>("Punch_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 300);
    }

    [RemoteEvent("DamageSystem_OnDamagedByPed")]
    public static void DamageSystem_OnDamagedByPed(Player Client, Player target, int bone)
    {
        try
        {
            if (target.Exists && Client.Exists)
            {
                GameLog.ELog(target, GameLog.MyEnum.Damage, " wat ? " + AccountManage.GetCharacterName(Client));
            }

            WeaponHash hashcode = NAPI.Player.GetPlayerCurrentWeapon(target);
            foreach (var weapon in weapon_list)
            {
                if (weapon.model == Convert.ToString(hashcode))
                {
                    try
                    {
                        if (damageTimer[Main.getIdFromClient(Client)] != null)
                        {
                            damageTimer[Main.getIdFromClient(Client)].Kill();
                            damageTimer[Main.getIdFromClient(Client)] = null;
                        }
                    }
                    catch (Exception)
                    {

                    }

                    damageTimer[Main.getIdFromClient(Client)] = TimerEx.SetTimer(() =>
                    {

                        if (Client.GetSharedData<dynamic>("Injured") == 1)
                        {
                            return;
                        }

                        if (Client.HasSharedData("character_armor") && Client.GetSharedData<dynamic>("character_armor") == 1 && Client.GetData<dynamic>("armor_enable") == true)
                        {
                            int damdage = (int)Math.Ceiling((double)(weapon.damagePerHealth / 3));
                            Main.SendCustomChatMessasge(Client, "Kayıt edildi, " + (weapon.damagePerHealth - damdage));
                            NAPI.Player.SetPlayerHealth(Client, Client.Health - damdage);
                        }
                        else
                        {
                            NAPI.Player.SetPlayerHealth(Client, Client.Health + -weapon.damagePerHealth);
                        }

                        damageTimer[Main.getIdFromClient(Client)] = null;
                    }, 3, 1);
                    break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }
    }

    [RemoteEvent("DamageSystem_ShotPlayerAtHealth")]
    public static void DamageSystem_ShotPlayerAtHealth(Player Client, Player target, int newHealth)
    {

    }

    private void OnPlayerWeaponAmmoChangeHandler(Player Client, WeaponHash weapon, int oldAmmo)
    {

    }

    [Command("sxyz")]
    public void coords(Player Client)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 8)
        {
            Main.SendErrorMessage(Client, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        Vector3 playerPosGet = NAPI.Entity.GetEntityPosition(Client);
        var pPosX = (playerPosGet.X.ToString().Replace(',', '.') + ", ");
        var pPosY = (playerPosGet.Y.ToString().Replace(',', '.') + ", ");
        var pPosZ = (playerPosGet.Z.ToString().Replace(',', '.'));
        Vector3 playerRotGet = NAPI.Entity.GetEntityRotation(Client);
        var pRotX = (playerRotGet.X.ToString().Replace(',', '.') + ", ");
        var pRotY = (playerRotGet.Y.ToString().Replace(',', '.') + ", ");
        var pRotZ = (playerRotGet.Z.ToString().Replace(',', '.'));

        Main.SendCustomChatMessasge(Client, "Pozisyonunuz: ~y~" + playerPosGet + "~w~ Rotasyon: ~y~" + playerRotGet);
        StreamWriter coordsFile;
        if (!File.Exists("SavedCoords.txt"))
        {
            coordsFile = new StreamWriter("SavedCoords.txt");
        }
        else
        {
            coordsFile = File.AppendText("SavedCoords.txt");
        }
        Main.SendCustomChatMessasge(Client, "~r~Koordinatlar kaydedildi!");
        coordsFile.WriteLine("new Vector3(" + pPosX + pPosY + pPosZ + ")");
        coordsFile.Close();
    }

    [Command("getvhash")]
    public static void getvhashcmd(Player player)
    {
        if (AccountManage.GetPlayerAdmin(player) < 8)
        {
            Main.SendErrorMessage(player, "Bu işlemi gerçekleştirebilmek için yetkiniz yok!");
            return;
        }
        Vehicle playerVehicle = player.Vehicle;
        uint vehicleHash = playerVehicle.Model;
        player.SendChatMessage("" + vehicleHash);
        StreamWriter coordsFile;
        if (!File.Exists("SavedCoords.txt"))
        {
            coordsFile = new StreamWriter("SavedCoords.txt");
        }
        else
        {
            coordsFile = File.AppendText("SavedCoords.txt");
        }
        player.SendChatMessage("~r~Hash kaydedildi!");
        coordsFile.WriteLine("" + vehicleHash);
        coordsFile.Close();
    }

    public static async Task UpdatePlayerClothes(Player Client)
    {
        try
        {

            if (Client.GetData<dynamic>("duty") == 1 && Client.GetData<dynamic>("character_duty_outfit") != -1)
            {
                Outfits.SetUnisexOutfit(Client, Client.GetData<dynamic>("character_duty_outfit"));
                return;
            }


            var mask = NAPI.Data.GetEntitySharedData(Client, "character_mask");
            var mask_texture = NAPI.Data.GetEntitySharedData(Client, "character_mask_texture");
            var torso = NAPI.Data.GetEntitySharedData(Client, "character_torso");
            var torso_texture = NAPI.Data.GetEntitySharedData(Client, "character_torso_texture");
            var undershirt = NAPI.Data.GetEntitySharedData(Client, "character_undershirt");
            var undershirt_texture = NAPI.Data.GetEntitySharedData(Client, "character_undershirt_texture");
            var leg = NAPI.Data.GetEntitySharedData(Client, "character_leg");
            var leg_texture = NAPI.Data.GetEntitySharedData(Client, "character_leg_texture");
            var feet = NAPI.Data.GetEntitySharedData(Client, "character_feet");
            var feet_texture = NAPI.Data.GetEntitySharedData(Client, "character_feet_texture");
            var shirt = NAPI.Data.GetEntitySharedData(Client, "character_shirt");
            var shirt_texture = NAPI.Data.GetEntitySharedData(Client, "character_shirt_texture");
            var armor = NAPI.Data.GetEntitySharedData(Client, "character_armor");
            var armor_texture = NAPI.Data.GetEntitySharedData(Client, "character_armor_texture");

            var hats = NAPI.Data.GetEntitySharedData(Client, "character_hats");
            var hats_texture = NAPI.Data.GetEntitySharedData(Client, "character_hats_texture");
            var glasses = NAPI.Data.GetEntitySharedData(Client, "character_glasses");
            var glasses_texture = NAPI.Data.GetEntitySharedData(Client, "character_glasses_texture");
            var ears = NAPI.Data.GetEntitySharedData(Client, "character_ears");
            var ears_texture = NAPI.Data.GetEntitySharedData(Client, "character_ears_texture");
            var watches = NAPI.Data.GetEntitySharedData(Client, "character_watches");
            var watches_texture = NAPI.Data.GetEntitySharedData(Client, "character_watches_texture");
            var bracelets = NAPI.Data.GetEntitySharedData(Client, "character_bracelets");
            var bracelets_texture = NAPI.Data.GetEntitySharedData(Client, "character_bracelets_texutre");
            var accessories = NAPI.Data.GetEntitySharedData(Client, "character_accessories");
            var accessories_texture = NAPI.Data.GetEntitySharedData(Client, "character_accessories_texture");

            Client.SetData<dynamic>("hats_enable", false);
            Client.SetData<dynamic>("glasses_enable", false);
            Client.SetData<dynamic>("armor_enable", false);
            Client.SetAccessories(0, -1, 0);
            Client.SetAccessories(1, 0, 0);
            NAPI.Player.ClearPlayerAccessory(Client, 0);
            NAPI.Player.ClearPlayerAccessory(Client, 1);
            NAPI.Player.ClearPlayerAccessory(Client, 2);
            NAPI.Player.ClearPlayerAccessory(Client, 6);
            NAPI.Player.ClearPlayerAccessory(Client, 7);

            if ((int)NAPI.Data.GetEntitySharedData(Client, "character_armor") != 0)
            {
                Client.SetData<dynamic>("armor_enable", true);
                Client.SetClothes(9, (int)NAPI.Data.GetEntitySharedData(Client, "character_armor"), (int)NAPI.Data.GetEntitySharedData(Client, "character_armor_texture"));
            }
            if ((int)NAPI.Data.GetEntitySharedData(Client, "character_hats") != 0)
            {
                Client.SetData<dynamic>("hats_enable", true);
                Client.SetAccessories(0, (int)NAPI.Data.GetEntitySharedData(Client, "character_hats"), (int)NAPI.Data.GetEntitySharedData(Client, "character_hats_texture"));
            }

            if ((int)NAPI.Data.GetEntitySharedData(Client, "character_glasses") != 0)
            {
                Client.SetData<dynamic>("glasses_enable", true);
                Client.SetAccessories(1, (int)NAPI.Data.GetEntitySharedData(Client, "character_glasses"), (int)NAPI.Data.GetEntitySharedData(Client, "character_glasses_texture"));
            }



            if ((int)NAPI.Data.GetEntitySharedData(Client, "character_ears") != 0) Client.SetAccessories(2, (int)NAPI.Data.GetEntitySharedData(Client, "character_ears"), (int)NAPI.Data.GetEntitySharedData(Client, "character_ears_texture"));
            if ((int)NAPI.Data.GetEntitySharedData(Client, "character_watches") != 0) Client.SetAccessories(6, (int)NAPI.Data.GetEntitySharedData(Client, "character_watches"), (int)NAPI.Data.GetEntitySharedData(Client, "character_watches_texture"));


            NAPI.Player.SetPlayerClothes(Client, 1, 0, 0);



            NAPI.Player.SetPlayerClothes(Client, 9, (int)armor, (int)armor_texture);
            NAPI.Player.SetPlayerClothes(Client, 10, 0, 0);
            NAPI.Player.SetPlayerClothes(Client, 4, (int)leg, (int)leg_texture);
            NAPI.Player.SetPlayerClothes(Client, 6, (int)feet, (int)feet_texture);
            NAPI.Player.SetPlayerClothes(Client, 3, (int)torso, (int)torso_texture);
            NAPI.Player.SetPlayerClothes(Client, 8, (int)undershirt, (int)undershirt_texture);
            NAPI.Player.SetPlayerClothes(Client, 11, (int)shirt, (int)shirt_texture);
            NAPI.Player.SetPlayerClothes(Client, 7, (int)accessories, (int)accessories_texture);
        }
        catch (Exception e)
        {
            Console.Write(e);
        }
    }


    public static void SendNotificationBrowser(Player Client, string title, string message, string colourf = "danger", string position = "top", string alig = "right")
    {
        Client.TriggerEvent("SendUINotification", title, message, colourf, position, alig);
    }

    public static void DisplayErrorMessage(Player Client, string type, string message)
    {
        Notify.Send(Client, type, message, 6000);
    }
    public static void DisplaySuccess(Player Client, string type, string message, int time = 4000)
    {
        Notify.Send(Client, type, message, time);
    }

    public static void ParaGeldi(Player Client, string type, string message, int time = 4000)
    {
        Notify.Send(Client, type, message, time);
    }

    public static void ParaGitti(Player Client, string type, string message, int time = 4000)
    {
        Notify.Send(Client, type, message, time);
    }

    public static void SendJobMessage(int jobid, string msg)
    {
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var Player in players)
        {
            if (Player.GetData<dynamic>("status") == true)
            {
                if (AccountManage.GetPlayerJob(Player) == jobid)
                {
                    Main.SendCustomChatMessasge(Player, msg);
                }
            }
        }
    }


    public static void sendProxMessage(Player Client, float radius, string color, string msg)
    {
        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(radius, Client);
        foreach (Player target in proxPlayers)
        {
            Main.SendCustomChatMessasge(target, "<font color ='#" + color + "'>" + msg);
        }
        EmoteMessage(Client, msg);
    }


    public static bool IsPlayerLogged(Player Client)
    {
        return Client.GetData<dynamic>("status");
    }

    public static void StartProgressBar(Player player, int time, string imgname)
    {
        player.TriggerEvent("SetProgressBar", time, imgname);
    }


    public static void DestroyProgressBar(Player Client)
    {
        Client.TriggerEvent("DestroyProgressBar");
    }

    public static void CreateTextProgressBar(Player Client, string name, string value)
    {
        NAPI.Data.SetEntityData(Client, "MainProgressText", true);
        NAPI.ClientEvent.TriggerClientEvent(Client, "CreateMainProgress", name, value);
    }

    public static void SetTextProgressBar(Player Client, string value)
    {
        if (NAPI.Data.GetEntityData(Client, "MainProgressText") == true)
        {
            NAPI.ClientEvent.TriggerClientEvent(Client, "SetMainProgress", value);
        }
    }

    public static void DeleteTextProgressBar(Player Client)
    {
        NAPI.Data.SetEntityData(Client, "MainProgressText", false);
        NAPI.ClientEvent.TriggerClientEvent(Client, "DeleteMainProgress");
    }


    public static void ShowColorShard(Player Client, string title, string description, int bgColor, int titleColor, int timeout)
    {
        NAPI.ClientEvent.TriggerClientEvent(Client, "ShowShardMessage", title, description, bgColor, titleColor, timeout);

    }

    public static void SetVehicleFuel(Vehicle vehicle, double fuel)
    {
        if (!vehicle.HasData("vehicle_fuel"))
        {
            vehicle.SetData<dynamic>("vehicle_fuel", 0.0);
        }
        vehicle.SetData<dynamic>("vehicle_fuel", fuel);
        vehicle.SetSharedData("vehicle_fuel_client", (int)fuel);

    }

    public static double GetVehicleFuel(Vehicle vehicle)
    {
        if (!vehicle.HasData("vehicle_fuel"))
        {
            vehicle.SetData<dynamic>("vehicle_fuel", 0.0);
        }
        return vehicle.GetData<dynamic>("vehicle_fuel");
    }

    public static TimerEx[] displat_text_timer { get; set; } = new TimerEx[Main.MAX_PLAYERS];
    public static TimerEx[] paraislemtimer { get; set; } = new TimerEx[Main.MAX_PLAYERS];

    public static void DisplaySubtitle(Player Client, string text, uint time = 5)
    {
        int playerid = Main.getIdFromClient(Client);

        try
        {
            if (displat_text_timer[playerid] != null)
            {
                displat_text_timer[playerid].Kill();
            }
        }
        catch
        {

        }
        Client.SetSharedData("SubTitle", text);

        displat_text_timer[playerid] = TimerEx.SetTimer(() =>
        {
            try
            {
                Client.SetSharedData("SubTitle", " ");
                displat_text_timer[playerid] = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }


        }, time * 1000, 1);

    }

    public static void ParaIslem1(Player Client, string text, uint time = 5)
    {
        int playerid = Main.getIdFromClient(Client);

        try
        {
            if (paraislemtimer[playerid] != null)
            {
                paraislemtimer[playerid].Kill();
            }
        }
        catch
        {

        }
        Client.SetSharedData("ParaIslem", text);

        paraislemtimer[playerid] = TimerEx.SetTimer(() =>
        {
            try
            {
                Client.SetSharedData("ParaIslem", " ");
                paraislemtimer[playerid] = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }


        }, time * 1000, 1);

    }

    public static void ParaIslem2(Player Client, string text, uint time = 5)
    {
        int playerid = Main.getIdFromClient(Client);

        try
        {
            if (paraislemtimer[playerid] != null)
            {
                paraislemtimer[playerid].Kill();
            }
        }
        catch
        {

        }
        Client.SetSharedData("ParaIslem1", text);

        paraislemtimer[playerid] = TimerEx.SetTimer(() =>
        {
            try
            {
                Client.SetSharedData("ParaIslem1", " ");
                paraislemtimer[playerid] = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }


        }, time * 1000, 1);

    }

    [RemoteEvent("testdeksevent")]
    public static void Pozisyon(Player player, string pos)
    {
        NAPI.Util.ConsoleOutput(pos);
    }

    public static void DisplayTextHelp(Player Client, string text, int time)
    {
        NAPI.ClientEvent.TriggerClientEvent(Client, "displayTextHelp", text, time);
    }


    bool invalid = false;
    public bool IsValidEmail(string strIn)
    {
        invalid = false;
        if (String.IsNullOrEmpty(strIn))
            return false;

        try
        {
            strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }

        if (invalid)
            return false;

        try
        {
            return Regex.IsMatch(strIn,
                  @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                  RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    private string DomainMapper(Match match)
    {
        IdnMapping idn = new IdnMapping();

        string domainName = match.Groups[2].Value;
        try
        {
            domainName = idn.GetAscii(domainName);
        }
        catch (ArgumentException)
        {
            invalid = true;
        }
        return match.Groups[1].Value + domainName;
    }


    public static Player findPlayer(Player sender, string idOrName)
    {

        if (int.TryParse(idOrName, out int id))
        {
            return getClientFromId(sender, id);
        }

        Player returnClient = null;
        int playersCount = 0;
        foreach (var Player in NAPI.Pools.GetAllPlayers())
        {
            if (Player == null) continue;

            if (Player.Name.ToLower().Contains(idOrName.ToLower()))
            {
                if ((Player.Name.Equals(idOrName, StringComparison.OrdinalIgnoreCase)))
                {
                    return Player;
                }
                else
                {
                    playersCount++;
                    returnClient = Player;
                }
            }
        }


        if (playersCount != 1)
        {
            if (playersCount > 0)
            {
            }
            else
            {
            }
            return null;
        }

        return returnClient;
    }

    public static Player FindPlayerFromSqlid(int sqlid)
    {
        foreach (var item in NAPI.Pools.GetAllPlayers())
        {
            if (AccountManage.GetPlayerConnected(item))
            {
                if (AccountManage.GetPlayerSQLID(item) == sqlid)
                {
                    return item;
                }
            }
        }
        return null;
    }


    public static Player getClientFromId(Player sender, int id)
    {
        if (id >= MAX_PLAYERS)
        {
            return null;
        }

        foreach (Player item in NAPI.Pools.GetAllPlayers())
        {
            if (item.Value == id)
            {
                return item;
            }
        }
        return null;
    }

    public static int getIdFromClient(Player target)
    {
        if (target.Exists)
        {
            return target.Value;
        }
        return -1;
    }

    public void ResetSQLData(Player Client)
    {
        NAPI.Data.SetEntityData(Client, "character_money", 0);
        NAPI.Data.SetEntityData(Client, "character_bank", 0);
        NAPI.Data.SetEntityData(Client, "character_salary", 0);
        NAPI.Data.SetEntityData(Client, "character_exp", 0);
        NAPI.Data.SetEntityData(Client, "character_leader", 0);
        NAPI.Data.SetEntityData(Client, "character_group", 0);
        NAPI.Data.SetEntityData(Client, "character_group_rank", 0);
        NAPI.Data.SetEntityData(Client, "character_job", 0);
        NAPI.Data.SetEntityData(Client, "character_wanted_level", 0);
        NAPI.Data.SetEntityData(Client, "character_prison", 0);
        NAPI.Data.SetEntityData(Client, "character_prison_cell", 0);
        NAPI.Data.SetEntityData(Client, "character_prison_time", 0);
        NAPI.Data.SetEntitySharedData(Client, "character_hospital", 0);
        NAPI.Data.SetEntityData(Client, "character_position_x", 0);
        NAPI.Data.SetEntityData(Client, "character_position_y", 0);
        NAPI.Data.SetEntityData(Client, "character_position_z", 0);
        NAPI.Data.SetEntityData(Client, "character_rotation_z", 0);
        NAPI.Data.SetEntityData(Client, "character_business_key", 0);

        Client.SetSharedData("character_torso", 0);
        Client.SetSharedData("character_undershirt", 0);
        Client.SetSharedData("character_undershirt_texture", 0);
        Client.SetSharedData("character_leg", 0);
        Client.SetSharedData("character_leg_texture", 0);
        Client.SetSharedData("character_feet", 0);
        Client.SetSharedData("character_feet_texture", 0);
        Client.SetSharedData("character_shirt", 0);
        Client.SetSharedData("character_shirt_texture", 0);
        Client.SetSharedData("character_mask", 0);
        Client.SetSharedData("character_mask_texture", 0);
        Client.SetSharedData("character_armor", 0);
        Client.SetSharedData("character_armor_texture", 0);

        NAPI.Data.SetEntityData(Client, "character_duty_outfit", -1);


        NAPI.Data.SetEntityData(Client, "duty", 0);
        Client.SetData<dynamic>("Hunger", 100);
        Client.SetData<dynamic>("Thirsty", 100);

        Client.SetData<dynamic>("ThirstyTimer", 0);
        Client.SetData<dynamic>("HungerTimer", 0);

        Client.SetData<dynamic>("LowHealthEffect", false);
    }

    public static bool IsNumeric(string input)
    {
        return int.TryParse(input, out int test);
    }

    public static void ScreenTextUi(Player Client, string chat, int Timeout)
    {
        Client.TriggerEvent("ScreenTextUi", chat);

        NAPI.Task.Run(() =>
        {
            if (!Client.Exists) { return; }
            Client.TriggerEvent("ScreenTextUi", "StopUI");
        }, delayTime: Timeout);
    }

    [RemoteEvent("Toggle_Radio")]
    public void toggle(Player Client)
    {
        Radio.RadioSystem.ToggleRadio(Client);
    }

    [RemoteEvent("Toggle_GUI_Radio")]
    public void Toggle_GUI_Radio(Player Client)
    {
        if (Inventory.GetPlayerItemFromInventory(Client, 23) >= 1)
        {
            Client.TriggerEvent("Toggle_GUI_Radio", Client.GetSharedData<dynamic>("RadioFreq"));
        }
    }

    private const int PunchCooldownMs = 500;


    public static void PlaySoundFrontend(Player client, string audioName, string audioLibrary) => client.TriggerEvent("PlaySoundFrontend", audioName, audioLibrary);
    public static void PlaySoundClientSide(Player client, string audioName, float volume) => client.TriggerEvent("playClientSound", audioName, volume);
    public static void StopAudioClientSide(Player client) => client.TriggerEvent("StopClientSound");

    public static DateTime GetTimeNoW()
    {
        return DateTime.Now;
    }

    public static void SendPoupupMessage(Player Client, string message)
    {
        Client.TriggerEvent("createNewHeadNotificationAdvanced", message);
    }

    [RemoteEvent("add_voice_listener")]
    public void add_voice_listener(Player Client, Player target)
    {

        try
        {
            if (target.Exists)
            {
                Client.EnableVoiceTo(target);
            }
        }
        catch (Exception)
        {

        }

    }
    [RemoteEvent("remove_voice_listener")]
    public void remove_voice_listener(Player Client, Player target)
    {

        try
        {
            if (target.Exists)
            {

                Client.DisableVoiceTo(target);
            }
        }
        catch (Exception)
        {
        }

    }

    public static void SendCustomChatToAll(string message)
    {
        message = message.Replace("~w~", "<font color='#ffffff'>");
        message = message.Replace("~c~", "<font color='#999999'>");
        message = message.Replace("~y~", "<font color='#EDD415'>");
        message = message.Replace("~q~", "<font color='#8365E0'>");
        message = message.Replace("~o~", "<font color='#FF9924'>");
        message = message.Replace("~r~", "<font color='#FF0400'>");
        message = message.Replace("~g~", "<font color='#1AC211'>");
        message = message.Replace("~b~", "<font color='#2F84FA'>");
        message = message.Replace("~p~", "<font color='#FF6EE4'>");

        NAPI.Chat.SendChatMessageToAll(message);
    }

    public static void SendCustomChatMessasge(Player player, string message)
    {
        message = message.Replace("~w~", "<font color='#ffffff'>");
        message = message.Replace("~c~", "<font color='#999999'>");
        message = message.Replace("~y~", "<font color='#EDD415'>");
        message = message.Replace("~q~", "<font color='#8365E0'>");
        message = message.Replace("~o~", "<font color='#FF9924'>");
        message = message.Replace("~r~", "<font color='#FF0400'>");
        message = message.Replace("~g~", "<font color='#1AC211'>");
        message = message.Replace("~b~", "<font color='#2F84FA'>");
        message = message.Replace("~p~", "<font color='#FF6EE4'>");

        player.SendChatMessage(message);
    }

    public class PlayAnimationwithtime
    {
        public string animdictionary;
        public string animationName;
        public int flag;
        public int duration;
        public float Blendinspeed;
        public float blendoutspeed;
    }
    public static void PlayAnimation(Player player, string animdictionary, string animationName, int flag, int duration, float Blendinspeed = 8, float blendoutspeed = 1)
    {
        try
        {
            if (duration == 0)
            {
                duration = 99999999;
            }
            if (player.HasData("AnimationTimer"))
            {
                uint has = player.GetData<TimerEx>("AnimationTimer").ExecuteAfterMs;
                if (has <= 0 || has >= 999999)
                {
                    has = 1;
                }
                NAPI.Task.Run(() =>
                {
                    List<PlayAnimationwithtime> dynamics = new List<PlayAnimationwithtime>();
                    dynamics.Add(new PlayAnimationwithtime { animdictionary = animdictionary, animationName = animationName, flag = flag, duration = duration, blendoutspeed = blendoutspeed, Blendinspeed = blendoutspeed });
                    NAPI.Data.SetEntitySharedData(player, "PlayAnimationwithtime", dynamics);

                    TimerEx time = TimerEx.SetTimer(() =>
                    {
                        player.ResetData("AnimationTimer");
                    }, (uint)duration, 1);
                    player.SetData<TimerEx>("AnimationTimer", time);

                }, has);

                return;
            }
            List<PlayAnimationwithtime> dynamics = new List<PlayAnimationwithtime>();
            dynamics.Add(new PlayAnimationwithtime { animdictionary = animdictionary, animationName = animationName, flag = flag, duration = duration, blendoutspeed = blendoutspeed, Blendinspeed = blendoutspeed });
            NAPI.Data.SetEntitySharedData(player, "PlayAnimationwithtime", dynamics);
            TimerEx time = TimerEx.SetTimer(() =>
            {
                player.ResetData("AnimationTimer");
            }, (uint)duration, 1);
            player.SetData<TimerEx>("AnimationTimer", time);
        }
        catch (Exception)
        {

        }

    }

    public static void SetVehicleInformationStatus(Player player, bool status)
    {
        NAPI.ClientEvent.TriggerClientEvent(player, "setVehicleInformation", status);
    }

    public static void SavePlayerInformation(Player Client)
    {
        if (AccountManage.GetPlayerConnected(Client))
        {
            AccountManage.SaveCharacter(Client);
            WeaponManage.SaveWeapons(Client);
        }

    }

}


public class Trigger : Script
{
    public static void ClientEvent(Player client, string eventName, params object[] args)
    {
        if (Thread.CurrentThread.Name == "Main")
        {
            NAPI.ClientEvent.TriggerClientEvent(client, eventName, args);
            return;
        }
        NAPI.Task.Run(() =>
        {
            if (client == null) return;
            NAPI.ClientEvent.TriggerClientEvent(client, eventName, args);
        });
    }
    public static void ClientEventInRange(Vector3 pos, float range, string eventName, params object[] args)
    {
        if (Thread.CurrentThread.Name == "Main")
        {
            NAPI.ClientEvent.TriggerClientEventInRange(pos, range, eventName, args);
            return;
        }
        NAPI.Task.Run(() =>
        {
            NAPI.ClientEvent.TriggerClientEventInRange(pos, range, eventName, args);
        });
    }
    public static void ClientEventInDimension(uint dim, string eventName, params object[] args)
    {
        if (Thread.CurrentThread.Name == "Main")
        {
            NAPI.ClientEvent.TriggerClientEventInDimension(dim, eventName, args);
            return;
        }
        NAPI.Task.Run(() =>
        {
            NAPI.ClientEvent.TriggerClientEventInDimension(dim, eventName, args);
        });
    }
    public static void ClientEventToPlayers(Player[] players, string eventName, params object[] args)
    {
        if (Thread.CurrentThread.Name == "Main")
        {
            NAPI.ClientEvent.TriggerClientEventToPlayers(players, eventName, args);
            return;
        }
        NAPI.Task.Run(() =>
        {
            NAPI.ClientEvent.TriggerClientEventToPlayers(players, eventName, args);
        });
    }

    [RemoteEvent("WaypointUpdated")]
    public void OnWaypointUpdated(Player player, float x, float y)
    {
        if (!player.IsInVehicle) return;

        var vehicle = player.Vehicle;

        foreach (Player target in NAPI.Pools.GetAllPlayers())
        {
            if (target != null && target != player && target.IsInVehicle && target.Vehicle == vehicle)
            {
                NAPI.ClientEvent.TriggerClientEvent(target, "SetWaypoint", x, y);
            }
        }
    }

    
}


