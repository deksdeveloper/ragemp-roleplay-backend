using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
class Services : Script
{

    public class ServiceEnum : IEquatable<ServiceEnum>
    {
        public int id { get; set; }
        public Player caller { get; set; }
        public int active { get; set; }
        public int faction { get; set; }
        public int job { get; set; }
        public DateTime dateTime { get; set; }
        public Vector3 position { get; set; }

        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ServiceEnum objAsPart = obj as ServiceEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(ServiceEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<ServiceEnum> service_system = new List<ServiceEnum>();

    public Services()
    {
        for (int i = 0; i < 100; i++)
        {
            service_system.Add(new ServiceEnum { id = i, caller = null, active = 0, faction = 0, job = 0, position = new Vector3() });
        }
    }

    public static void Remove_Service(Player player)
    {
        foreach (var service in service_system)
        {
            if (service.active == 1 && service.caller == player)
            {

                service.active = 0;
                service.faction = 0;
                service.job = 0;
                service.position = new Vector3();
                service.caller = null;

            }
        }
    }

    public static void Call_Service(Player player, int number)
    {
        foreach (var service in service_system)
        {
            if (service.caller == null && service.active == 0)
            {
                player.TriggerEvent("service_accept", number);

                service.caller = player;
                service.active = 1;
                service.position = player.Position;
                service.dateTime = DateTime.Now;


                if (number == 911)
                {
                    service.job = 0;
                    service.faction = 1;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData<dynamic>("status") == true && AccountManage.GetPlayerGroup(police) == 1)
                        {
                            police.SendNotification("~b~[MERKEZ]~n~~n~~w~Vatandaş:~g~ " + AccountManage.GetCharacterName(player) + "~n~~w~Telefon:~g~ " + TelefonSistem.GetPlayerNumber(player) + "");
                        }
                    }
                    InteractMenu_New.SendNotificationInfo(player, "Lütfen bir süre bekleyin, sonra tekrar aramayı deneyebilirsiniz.");
                }
                else if (number == 912)
                {
                    service.job = 0;
                    service.faction = 2;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData<dynamic>("status") == true && AccountManage.GetPlayerGroup(police) == 2)
                        {
                            police.SendNotification("~b~[MERKEZ]~n~~n~~w~Vatandaş:~g~ " + AccountManage.GetCharacterName(player) + "~n~~w~Telefon:~g~ " + TelefonSistem.GetPlayerNumber(player) + "");
                        }
                    }
                    InteractMenu_New.SendNotificationInfo(player, "Lütfen bir süre bekleyin, sonra tekrar aramayı deneyebilirsiniz.");
                }
                else if (number == 913)
                {
                    service.faction = 6;
                    service.job = 0;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData<dynamic>("status") == true && FactionManage.GetPlayerGroupType(player) == 6)
                        {
                            police.SendNotification("~y~[MERKEZ]~n~~n~~w~Vatandaş:~g~ " + AccountManage.GetCharacterName(player) + "~n~~w~Telefon:~g~ " + TelefonSistem.GetPlayerNumber(player) + "");
                        }
                    }
                    InteractMenu_New.SendNotificationInfo(player, "Lütfen bir süre bekleyin, sonra tekrar aramayı deneyebilirsiniz.");
                }

            else if (number == 914)
                {
                    service.faction = 5;
                    service.job = 0;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData<dynamic>("status") == true && FactionManage.GetPlayerGroupType(police) == 5)
                        {
                            police.SendNotification("~y~[MERKEZ]~n~~n~~w~Vatandaş:~g~ " + AccountManage.GetCharacterName(player) + "~n~~w~Telefon:~g~ " + TelefonSistem.GetPlayerNumber(player) + "");
                        }
                    }
                    InteractMenu_New.SendNotificationInfo(player, "Tekrar aramadan önce biraz bekleyin.");
                }
                return;

            }
        }
        player.SendNotification("Hata: Acil servisi zaten aradınız!");
        player.TriggerEvent("service_cancel");
    }

    public static void DisplayCalls(Player player)
    {

        if (AccountManage.GetPlayerGroup(player) == 1)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && AccountManage.GetPlayerGroup(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = " " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " metre uzaklıkta." });
                }
            }
            player.TriggerEvent("Display_Calls", "", API.Shared.ToJson(menu_item_list));
        }
        else if (AccountManage.GetPlayerGroup(player) == 2)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && AccountManage.GetPlayerGroup(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = " " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " metre uzaklıkta." });
                }
            }
            player.TriggerEvent("Display_Calls", "Acil Yardım - Çağrılar", API.Shared.ToJson(menu_item_list));
        }
        else if (FactionManage.GetPlayerGroupType(player) == 6)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && FactionManage.GetPlayerGroupType(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = " " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " metre uzaklıkta." });
                }
            }
            player.TriggerEvent("Display_Calls", "Mekanikler - Çağrılar", API.Shared.ToJson(menu_item_list));
        }
        else if (FactionManage.GetPlayerGroupType(player) == 5)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && FactionManage.GetPlayerGroupType(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = " " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " metre uzaklıkta." });
                }
            }
            player.TriggerEvent("Display_Calls", "Taksi - Çağrılar", API.Shared.ToJson(menu_item_list));
        }   }


        [RemoteEvent("Service_Track_Server")]
    public static void Service_Track_Server(Player player, int id)
    {
        if (service_system[id].active == 1)
        {
            InteractMenu_New.SendNotificationInfo(service_system[id].caller, "Görevli çağrınızı kabul etti. Lütfen bulunduğunuz yerden ayrılmayın, aksi takdirde çağrı iptal edilecektir!");

            player.SendNotification("GPS konumu ~b~" + AccountManage.GetCharacterName(service_system[id].caller) + "~w~ yerleştirildi ve o şu anda ~c~" + service_system[id].position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + "m uzaklıkta.");
            player.TriggerEvent("gps_set_loc", service_system[id].position.X, service_system[id].position.Y);
        }
    }

    [RemoteEvent("Service_Remove_Server")]
    public static void Service_Remove_Server(Player player, int id)
    {
        if (service_system[id].active == 1)
        {
            player.SendNotification("Çağrı ~c~#" + id + "~w~ iptal edildi.");
            player.SendNotification("Çağrınız iptal edildi.");

            service_system[id].caller.TriggerEvent("service_cancel");

            service_system[id].job = 0;
            service_system[id].active = 0;
            service_system[id].faction = 0;
            service_system[id].position = new Vector3();

            service_system[id].caller = null;
            DisplayCalls(player);
        }
    }
}

