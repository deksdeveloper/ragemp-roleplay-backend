using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
class XMR : Script
{
    /*public class XmrEnum : IEquatable<XmrEnum>
    {
        public int id { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public string stream { get; set; }
        public dynamic carid { get; set; }
        public bool car { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            XmrEnum objAsPart = obj as XmrEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(XmrEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

  
    public static List<XmrEnum> xmr_playing = new List<XmrEnum>();
    //public static List xmr_radios = new List<dynamic>();*/


    public static int MAX_RADIOS = 10;

    public class XmrEnum : IEquatable<XmrEnum>
    {
        public int id { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public string stream { get; set; }
        public int carid { get; set; }
        public int sahip_sql { get; set; }

        [JsonIgnore]
        public int sql_id { get; set; }

        [JsonIgnore]
        public Entity objeto { get; set; }

        [JsonIgnore]
        public TextLabel label { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            XmrEnum objAsPart = obj as XmrEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(XmrEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<XmrEnum> xmr_radios = new List<XmrEnum>();
    public static List<dynamic> list_of_radios = new List<dynamic>();


    public static void XMRs()
    {
        list_of_radios.Add(new { name = "Ugasi", url = "" });
        list_of_radios.Add(new { name = "Krajiski radio", url = "http://falcon.shoutca.st:8531/stream" });
        list_of_radios.Add(new { name = "Naxi Radio", url = "https://naxi128ssl.streaming.rs:9152/;stream.nsv" });
        list_of_radios.Add(new { name = "Radio Puls", url = "https://uk1.listen2myradio.com:2199/listen.php?port=8312&type=s2&mount=/stream" });
        list_of_radios.Add(new { name = "Radio Sarajevo", url = "https://securestreams5.autopo.st:1853/stream" });
        list_of_radios.Add(new { name = "Radio B92", url = "http://stream.b92.net:7999/radio-b92.mp3" });
        list_of_radios.Add(new { name = "Radio TDI", url = "https://streaming.tdiradio.com/tdiradio.mp3" });
        list_of_radios.Add(new { name = "Radio Banovina", url = "https://audio.radio-banovina.hr:7000/stream" });
        list_of_radios.Add(new { name = "Radio JAT", url = "https://streaming.radiojat.rs/radiojat.mp3" });
        list_of_radios.Add(new { name = "Radio Kosava", url = "https://main.radiokosava.rs/stream" });
        list_of_radios.Add(new { name = "Radio Morava", url = "https://e3.radiomorava.rs/radio/8000/radiomorava128.mp3" });
        list_of_radios.Add(new { name = "Radio Pingvin", url = "https://uzivo.radiopingvin.com/domaci1" });
        list_of_radios.Add(new { name = "Radio Karolina", url = "https://streaming.karolina.rs/karolina.mp3" });
        list_of_radios.Add(new { name = "SuperFm", url = "https://onair.superfm.rs/superfm.mp3" });
        list_of_radios.Add(new { name = "Cool Radio", url = "http://live.coolradio.rs:80" });
        list_of_radios.Add(new { name = "Radio SKAY", url = "http://live.coolradio.rs:80" });
        list_of_radios.Add(new { name = "Naxi House radio", url = "http://naxidigital-house128.streaming.rs:8000/" });
        list_of_radios.Add(new { name = "PLAY Radio", url = "http://stream.playradio.rs:8001/play.aac" });
        list_of_radios.Add(new { name = "PLAY PARTY", url = "http://stream.playradio.rs:80/party.aac" });
        list_of_radios.Add(new { name = "Radio uzice", url = "http://uzice.yunethosting.net:8000/stream" });
        list_of_radios.Add(new { name = "BelleAmie FOLK", url = "http://92.60.230.200:5040/;" });
        list_of_radios.Add(new { name = "Radio Human", url = "http://109.206.96.11:8000/;" });



        for (int i = 0; i < MAX_RADIOS; i++)
        {
            xmr_radios.Add(new XmrEnum { id = i, x = 0, y = 0, z = 0, stream = "null", carid = 0, sql_id = -1 });
        }

    }

    public static async System.Threading.Tasks.Task LoadRadiosXMR(Player Client)
    {
        Client.TriggerEvent("LoadXMR", API.Shared.ToJson(xmr_radios));
    }

    public static void OnPlayerDisconnect(Player Client)
    {
        for (int i = 0; i < MAX_RADIOS; i++)
        {
            if (xmr_radios[i].sql_id == AccountManage.GetPlayerSQLID(Client) && xmr_radios[i].carid == 0)
            {
                xmr_radios[i].sql_id = -1;
                xmr_radios[i].carid = 0;
                xmr_radios[i].x = 0;
                xmr_radios[i].y = 0;
                xmr_radios[i].z = 0;
                xmr_radios[i].stream = "null";
                xmr_radios[i].objeto.Delete();
                xmr_radios[i].label.Delete();
                Client.TriggerEvent("RemoveRadio", i);
            }
        }
    }

    [Command("aradyo")]
    public static void ARadyo(Player Client)
    {
        if (Client.IsInVehicle)
        {
            if (NAPI.Player.GetPlayerVehicleSeat(Client) == 0)
            {

                int playerid = Main.getIdFromClient(Client);

                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                {
                    if (PlayerVehicle.vehicle_data[playerid].state[index] == 1)
                    {
                        if (PlayerVehicle.vehicle_data[playerid].handle[index].Exists && PlayerVehicle.vehicle_data[playerid].handle[index] == Client.Vehicle)
                        {
                            Client.Vehicle.SetSharedData("vehicle_radio_id", PlayerVehicle.vehicle_data[playerid].index[index]);

                            NAPI.Util.ConsoleOutput("ID: " + Client.Vehicle.GetSharedData<int>("vehicle_radio_id"));
                            NAPI.ClientEvent.TriggerClientEvent(Client, "client:RadyoSecimi");
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            Main.SendErrorMessage(Client, "Bu komutu sadece araçta kullanabilirsiniz.");
            return;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////


    [RemoteEvent("server:RadyoSecildi")]
    public static void RadyoSecildi(Player player, bool status, int secilen)
    {
        if (player.IsInVehicle)
        {
            if (status)
            {
                string isim = "";
                string url = "";

                switch (secilen)
                {
                    case 0:
                        {
                            SetStationVehicle(player, "31", "31");
                            break;
                        }
                    case 1:
                        {
                            isim = "Rock Flacm";
                            url = "https://stream.radioparadise.com/rock-flacm";
                            SetStationVehicle(player, url, isim);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                            break;
                        }
                    case 2:
                        {
                            isim = "Mellow Flacm";
                            url = "http://stream.radioparadise.com/mellow-flacm";
                            SetStationVehicle(player, url, isim);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                            break;
                        }
                    case 3:
                        {
                            isim = "Super Stereo";
                            url = "http://icecast.centaury.cl:7570/SuperStereoHiRes1";
                            SetStationVehicle(player, url, isim);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                            break;
                        }
                    case 4:
                        {
                            isim = "Hiline Pop";
                            url = "http://mediaserv30.live-streams.nl:8086/live";
                            SetStationVehicle(player, url, isim);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                            break;
                        }
                    case 5:
                        {
                            isim = "Soma";
                            url = "http://ice2.somafm.com/bootliquor-320-mp3";
                            SetStationVehicle(player, url, isim);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                            break;
                        }
                    case 6:
                        {
                            isim = "95B FM";
                            url = "https://streams.95bfm.com/stream112";
                            SetStationVehicle(player, url, isim);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                            break;
                        }
                    case 7:
                        {
                            isim = "Magic Radio";
                            url = "http://flac.magic-radio.net/flac";
                            SetStationVehicle(player, url, isim);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                            break;
                        }
                    case 8:
                        {
                            isim = "Hiline Jazz";
                            url = "http://mediaserv38.live-streams.nl:8006/stream";
                            SetStationVehicle(player, url, isim);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                            break;
                        }
                    case 9:
                        {
                            isim = "Party Vibe:: Reggae";
                            url = "http://94.130.242.5:8000/stream";
                            SetStationVehicle(player, url, isim);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                            break;
                        }
                    case 10:
                        {
                            isim = "Party Vibe: Rap";
                            url = "http://94.130.242.5:8016/stream";
                            SetStationVehicle(player, url, isim);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                            break;
                        }
                    case 11:
                        {
                            isim = "Party Vibe: Drum & Bass";
                            url = "http://94.130.242.5:8004/stream";
                            SetStationVehicle(player, url, isim);
                            NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                            break;
                        }
                    case 12:
                        {
                            NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoOzelURL");
                            break;
                        }
                }

            }
            return;
        }
        int radio_id = -1;

        for (int i = 0; i < MAX_RADIOS; i++)
        {
            if (xmr_radios[i].sql_id == AccountManage.GetPlayerSQLID(player) && xmr_radios[i].carid == 0)
            {
                radio_id = i;
                break;
            }
        }
        if (radio_id == -1)
        {
            return;
        }

        if (status)
        {
            string isim = "";
            string url = "";

            switch (secilen)
            {
                case 0:
                    {
                        SetBoombox(player, "31", "31");
                        break;
                    }
                case 1:
                    {
                        isim = "Rock Flacm";
                        url = "https://stream.radioparadise.com/rock-flacm";
                        SetBoombox(player, url, isim);
                        NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                        break;
                    }
                case 2:
                    {
                        isim = "Mellow Flacm";
                        url = "http://stream.radioparadise.com/mellow-flacm";
                        SetBoombox(player, url, isim);
                        NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                        break;
                    }
                case 3:
                    {
                        isim = "Super Stereo";
                        url = "http://icecast.centaury.cl:7570/SuperStereoHiRes1";
                        SetBoombox(player, url, isim);
                        NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                        break;
                    }
                case 4:
                    {
                        isim = "Hiline Pop";
                        url = "http://mediaserv30.live-streams.nl:8086/live";
                        SetBoombox(player, url, isim);
                        NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                        break;
                    }
                case 5:
                    {
                        isim = "Soma";
                        url = "http://ice2.somafm.com/bootliquor-320-mp3";
                        SetBoombox(player, url, isim);
                        NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                        break;
                    }
                case 6:
                    {
                        isim = "95B FM";
                        url = "https://streams.95bfm.com/stream112";
                        SetBoombox(player, url, isim);
                        NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                        break;
                    }
                case 7:
                    {
                        isim = "Magic Radio";
                        url = "http://flac.magic-radio.net/flac";
                        SetBoombox(player, url, isim);
                        NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                        break;
                    }
                case 8:
                    {
                        isim = "Hiline Jazz";
                        url = "http://mediaserv38.live-streams.nl:8006/stream";
                        SetBoombox(player, url, isim);
                        NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                        break;
                    }
                case 9:
                    {
                        isim = "Party Vibe:: Reggae";
                        url = "http://94.130.242.5:8000/stream";
                        SetBoombox(player, url, isim);
                        NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                        break;
                    }
                case 10:
                    {
                        isim = "Party Vibe: Rap";
                        url = "http://94.130.242.5:8016/stream";
                        SetBoombox(player, url, isim);
                        NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                        break;
                    }
                case 11:
                    {
                        isim = "Party Vibe: Drum & Bass";
                        url = "http://94.130.242.5:8004/stream";
                        SetBoombox(player, url, isim);
                        NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                        break;
                    }
                case 12:
                    {
                        NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoOzelURL");
                        break;
                    }
            }

        }
    }

    [RemoteEvent("server:OzelURLGirildi")]
    public static void OzelURLGirildi(Player player, bool status, string url)
    {
        if (status)
        {
            if (url.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
            {
                if (player.IsInVehicle)
                {
                    SetStationVehicle(player, url, "Özel URL");
                }
                SetBoombox(player, url, "Özel URL");
                NAPI.ClientEvent.TriggerClientEvent(player, "client:RadyoKapat");
                return;
            }
            else
            {
                Notify.Send(player, "error", "Sadece .MP3 uzantılı URL yazabilirsiniz.", 5000);
                return;
            }
        }
    }

    [Command("boombox", "~y~[!]~w~: /boombox [Seçenek - koy, al, istasyon]")]
    public static void CMD_Boombox(Player Client, string islem)
    {
        if (islem == "koy")
        {
            int radio_id = -1;
            for (int i = 0; i < MAX_RADIOS; i++)
            {
                if (xmr_radios[i].sql_id == AccountManage.GetPlayerSQLID(Client) && xmr_radios[i].carid == 0)
                {
                    radio_id = i;
                    break;
                }
            }
            if (radio_id == -1)
            {
                for (int i = 0; i < MAX_RADIOS; i++)
                {
                    if (xmr_radios[i].sql_id == -1 && xmr_radios[i].carid == 0)
                    {
                        radio_id = i;
                        break;
                    }
                }
            }
            if (radio_id == -1)
            {
                Main.SendErrorMessage(Client, "Bunu yapamazsınız!");
                return;
            }

            if (xmr_radios[radio_id].stream == "null")
            {

                xmr_radios[radio_id].carid = 0;
                xmr_radios[radio_id].sql_id = AccountManage.GetPlayerSQLID(Client);
                xmr_radios[radio_id].x = Client.Position.X;
                xmr_radios[radio_id].y = Client.Position.Y;
                xmr_radios[radio_id].z = Client.Position.Z;
                xmr_radios[radio_id].stream = "http://66.85.88.174:80/hitlist";

                foreach (var target in API.Shared.GetAllPlayers())
                {
                    target.TriggerEvent("AddRadio", radio_id, Client.Position.X, Client.Position.Y, Client.Position.Z, xmr_radios[radio_id].stream, xmr_radios[radio_id].carid);
                }


                xmr_radios[radio_id].objeto = API.Shared.CreateObject(2819992632, Client.Position - new Vector3(0, 0, 1.0f), new Vector3(0, 0, 0), 0);

                xmr_radios[radio_id].label = API.Shared.CreateTextLabel(Main.LabelColor + "(( Boombox ))" + Main.NewLine + Main.LabelCommandColor + "« /boombox »", xmr_radios[radio_id].objeto.Position + new Vector3(0, 0, 0.45f), 8.0f, 0.25f, 4, new Color(0, 122, 255, 150));
            }
        }
        else if (islem == "al")
        {
            
            for (int i = 0; i < MAX_RADIOS; i++)
            {
                if (xmr_radios[i].sql_id == AccountManage.GetPlayerSQLID(Client) && xmr_radios[i].carid == 0)
                {
                    xmr_radios[i].sql_id = -1;
                    xmr_radios[i].carid = 0;
                    foreach (var pl in NAPI.Player.GetPlayersInRadiusOfPosition(50, new Vector3(xmr_radios[i].x, xmr_radios[i].y, xmr_radios[i].z)))
                    {
                        pl.TriggerEvent("RemoveRadio", i);
                    }
                    xmr_radios[i].x = 0;
                    xmr_radios[i].y = 0;
                    xmr_radios[i].z = 0;
                    xmr_radios[i].stream = "null";
                    xmr_radios[i].objeto.Delete();
                    xmr_radios[i].label.Delete();
                }
            }
        }
        else if (islem == "istasyon")
        {
            int radio_id = -1;
            for (int i = 0; i < MAX_RADIOS; i++)
            {
                if (xmr_radios[i].sql_id == AccountManage.GetPlayerSQLID(Client) && xmr_radios[i].carid == 0)
                {
                    radio_id = i;
                    break;
                }
            }

            if (radio_id == -1)
            {
                Main.SendErrorMessage(Client, "Boombox'unuz yok!");
                return;
            }

            NAPI.ClientEvent.TriggerClientEvent(Client, "client:RadyoSecimi");
        }
        else Main.SendErrorMessage(Client, "Hatalı seçenek girdiniz.");
    }

    public static void SetStationVehicle(Player Client, string stream, string isim)
    {
        if (Client.IsInVehicle)
        {
            int radio_id = -1;
            for (int i = 0; i < MAX_RADIOS; i++)
            {
                if (xmr_radios[i].carid == Client.Vehicle.GetSharedData<dynamic>("vehicle_radio_id") && xmr_radios[i].sql_id == -1)
                {
                    radio_id = i;

                    break;
                }
            }

            if (radio_id == -1)
            {
                for (int i = 0; i < MAX_RADIOS; i++)
                {
                    if (xmr_radios[i].carid == 0 && xmr_radios[i].sql_id == -1)
                    {
                        radio_id = i;
                        break;
                    }
                }
            }

            if (radio_id == -1)
            {
                Main.SendErrorMessage(Client, "Bunu yapamazsınız!");
                return;
            }

            if (xmr_radios[radio_id].stream == "null")
            {
                xmr_radios[radio_id].carid = Client.Vehicle.GetSharedData<dynamic>("vehicle_radio_id");
                xmr_radios[radio_id].x = Client.Position.X;
                xmr_radios[radio_id].y = Client.Position.Y;
                xmr_radios[radio_id].z = Client.Position.Z;
                xmr_radios[radio_id].stream = stream;

                foreach (var target in API.Shared.GetAllPlayers())
                {
                    target.TriggerEvent("AddRadio", radio_id, Client.Position.X, Client.Position.Y, Client.Position.Z, xmr_radios[radio_id].stream, xmr_radios[radio_id].carid);
                }

            }
            else
            {

                xmr_radios[radio_id].carid = Client.Vehicle.GetSharedData<dynamic>("vehicle_radio_id");
                xmr_radios[radio_id].x = Client.Position.X;
                xmr_radios[radio_id].y = Client.Position.Y;
                xmr_radios[radio_id].z = Client.Position.Z;
                xmr_radios[radio_id].stream = stream;

                foreach (var target in API.Shared.GetAllPlayers())
                {
                    target.TriggerEvent("EditRadio", radio_id, stream);
                }

            }

            List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(45, Client);
            foreach (Player target in proxPlayers)
            {
                target.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, target) + " radyo istasyonunu değiştirir.");
            }

        }
    }

    public static void SetBoombox(Player Client, string stream, string isim)
    {

        int radio_id = -1;

        for (int i = 0; i < MAX_RADIOS; i++)
        {
            if (xmr_radios[i].sql_id == AccountManage.GetPlayerSQLID(Client) && xmr_radios[i].carid == 0)
            {
                radio_id = i;
                break;
            }
        }
        if (radio_id == -1)
        {
            return;
        }
        if (xmr_radios[radio_id].stream != "null")
        {
            xmr_radios[radio_id].carid = 0;
            xmr_radios[radio_id].sql_id = AccountManage.GetPlayerSQLID(Client);
            xmr_radios[radio_id].x = Client.Position.X;
            xmr_radios[radio_id].y = Client.Position.Y;
            xmr_radios[radio_id].z = Client.Position.Z;
            xmr_radios[radio_id].stream = stream;

            foreach (var target in API.Shared.GetAllPlayers())
            {
                target.TriggerEvent("EditRadio", radio_id, stream);
            }

            List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(10, Client);
            foreach (Player target in proxPlayers)
            {
                if (target.GetData<dynamic>("status") == true)
                {
                    target.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, target) + " müzik kutusunu başka bir radyo istasyonuna çevirir.");
                }
            }
        }
    }

    

    /*[Command("setstation2")]
    public static void Command(Player Client)
    {
        PlayVehicleRadio(Client, "http://tunein4.streamguys1.com/hhbeafree5");wwww

    }*/

    /*
    public static void UpdateRadio(Player Client)
    {
        List xmr_radios = new List<dynamic>();
        for (int i = 0; i < MAX_RADIOS; i++)
        {
            if (xmr_playing[i].stream != null)
            {

                if(xmr_playing[i].car == true)
                {
                    xmr_radios.Add(new { id = i, x = Client.Position.X, y = Client.Position.Y, z = Client.Position.Z, stream = xmr_playing[i].stream, carid = Client.Vehicle.GetSharedData<dynamic>("vehicle_radio_id") });
                }
                else
                {
                    xmr_radios.Add(new { id = i, x = Client.Position.X, y = Client.Position.Y, z = Client.Position.Z, stream = xmr_playing[i].stream, carid = "null" });
                }
            }
        }
        Client.TriggerEvent("LoadXMR", API.Shared.ToJson(xmr_radios));

    }

    public static void PlayVehicleRadio(Player Client, string stream)
    {
        if(Client.IsInVehicle)
        {
            for(int i = 0; i < MAX_RADIOS; i++)
            {
                if (xmr_playing[i].stream == null)
                {
                    xmr_playing[i].stream = stream;
                    Client.TriggerEvent("AddRadio", i, Client.Position.X, Client.Position.Y, Client.Position.Z, stream, Client.Vehicle.Handle);
                    xmr_playing.Add(new XmrEnum { id = i, x = Client.Position.X, y = Client.Position.Y, z = Client.Position.Z, stream = stream, carid = Client.Vehicle.GetSharedData<dynamic>("vehicle_radio_id"), car = true });
                    UpdateRadio(Client);
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < MAX_RADIOS; i++)
            {
                if (xmr_playing[i].stream == null)
                {
                    xmr_playing[i].stream = stream;
                    Client.TriggerEvent("AddRadio", i, Client.Position.X, Client.Position.Y, Client.Position.Z, stream, null);
                    xmr_playing.Add(new XmrEnum { id = i, x = Client.Position.X, y = Client.Position.Y, z = Client.Position.Z, stream = stream, carid = null, car = false });
                    UpdateRadio(Client);
                    return;
                }
            }
        }
    }

    [RemoteEvent("SelectionRadioStationByName")]
    public static void SelectionRadioStationByName(Player Client, string text)
    {

        PlayVehicleRadio(Client, "Teste");
    }*/
}

