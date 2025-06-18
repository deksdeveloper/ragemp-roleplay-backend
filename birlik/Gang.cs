using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Linq;

class GangueManage : Script
{

    public static void DisplayCreateGangueMenu(Player Client, bool firstTime = false)
    {
        if (firstTime == true)
        {
            Client.SetData<dynamic>("gangue_name", "Bilinmeyen");
            Client.SetData<dynamic>("gangue_abreviacao", "Bilinmeyen");
            Client.SetData<dynamic>("gangue_color", "FFFFFF");

            Client.SetData<dynamic>("gangue_hierarquia_0", "Yeni Üye");
            Client.SetData<dynamic>("gangue_hierarquia_1", "Gangster");
            Client.SetData<dynamic>("gangue_hierarquia_2", "Yardımcı");
            Client.SetData<dynamic>("gangue_hierarquia_3", "Güvenilir Kişi");
            Client.SetData<dynamic>("gangue_hierarquia_4", "Yedek Şef");
            Client.SetData<dynamic>("gangue_hierarquia_5", "Şef");
        }

        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Organizasyon Adı", Description = "", RightLabel = "~c~" + Client.GetData<dynamic>("gangue_name") });
        menu_item_list.Add(new { Type = 1, Name = "Kısa Adı", Description = "", RightLabel = "~c~" + Client.GetData<dynamic>("gangue_abreviacao") });
        menu_item_list.Add(new { Type = 1, Name = "Organizasyon Rengi", Description = "", RightLabel = "~c~" + Client.GetData<dynamic>("gangue_color") });
        menu_item_list.Add(new { Type = 1, Name = "Rütbeler", Description = "", RightLabel = ">>" });
        menu_item_list.Add(new { Type = 1, Name = "Organizasyonu Oluştur", Description = "", RightLabel = "" });

        InteractMenu.CreateMenu(Client, "PLAYER_FACTION_CREATE", "Faction", "~b~Organizasyon Oluştur", false, NAPI.Util.ToJson(menu_item_list), false);
    }

    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "PLAYER_FACTION_CREATE")
        {
            switch (selectedIndex)
            {
                case 0:
                    {
                        InteractMenu.User_Input(Client, "input_player_faction_create", "Organizasyon Adı", Client.GetData<dynamic>("gangue_name"));
                        InteractMenu.CloseDynamicMenu(Client);
                        break;
                    }
                case 1:
                    {
                        InteractMenu.User_Input(Client, "input_player_faction_abbrev", "Kısa Ad, örn: RM", Client.GetData<dynamic>("gangue_abreviacao"));
                        InteractMenu.CloseDynamicMenu(Client);
                        break;
                    }
                case 2:
                    {
                        InteractMenu.User_Input(Client, "input_player_faction_color", "Renk, örn: FFFF00", Client.GetData<dynamic>("gangue_color"));
                        InteractMenu.CloseDynamicMenu(Client);
                        break;
                    }
                case 3:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        for (int i = 0; i < 6; i++)
                        {
                            menu_item_list.Add(new { Type = 1, Name = "Rütbe " + i + ".", Description = "", RightLabel = "~w~" + Client.GetData<dynamic>("gangue_hierarquia_" + i) });
                        }
                        InteractMenu.CreateMenu(Client, "PLAYER_FACTION_HIERARQUIA", "Organizasyon", "~b~Rütbeler", false, NAPI.Util.ToJson(menu_item_list), false);
                        break;
                    }
                case 4:
                    {
                        if (Client.GetData<dynamic>("gangue_name") == "Bilinmeyen")
                        {
                            Main.SendErrorMessage(Client, "Organizasyon adını girmeniz gerekmektedir.");
                            return;
                        }
                        if (Client.GetData<dynamic>("gangue_abreviacao") == "Bilinmeyen")
                        {
                            Main.SendErrorMessage(Client, "Organizasyon kısa adını girmeniz gerekmektedir.");
                            return;
                        }
                        if (Client.GetData<dynamic>("gangue_color") == "FFFFFF")
                        {
                            Main.SendErrorMessage(Client, "Organizasyon rengini girmeniz gerekmektedir. Ziyaret edin: ~y~www.Colorpicker.com ~w~, burada çeşitli renkler bulabilirsiniz. Örnek: ~b~CCFF00~w~.");
                            return;
                        }

                        for (int i = 20; i < FactionManage.MAX_FACTIONS; i++)
                        {
                            if (FactionManage.faction_data[i].faction_name == "Bilinmeyen")
                            {
                                FactionManage.faction_data[i].faction_name = Convert.ToString(Client.GetData<dynamic>("gangue_name"));
                                FactionManage.faction_data[i].faction_abbrev = Client.GetData<dynamic>("gangue_abreviacao");
                                FactionManage.faction_data[i].faction_color = Client.GetData<dynamic>("gangue_color");

                                FactionManage.faction_data[i].faction_type = 4;

                                FactionManage.faction_data[i].faction_rank[0] = Client.GetData<dynamic>("gangue_hierarquia_0");
                                FactionManage.faction_data[i].faction_rank[1] = Client.GetData<dynamic>("gangue_hierarquia_1");
                                FactionManage.faction_data[i].faction_rank[2] = Client.GetData<dynamic>("gangue_hierarquia_2");
                                FactionManage.faction_data[i].faction_rank[3] = Client.GetData<dynamic>("gangue_hierarquia_3");
                                FactionManage.faction_data[i].faction_rank[4] = Client.GetData<dynamic>("gangue_hierarquia_4");
                                FactionManage.faction_data[i].faction_rank[5] = Client.GetData<dynamic>("gangue_hierarquia_5");

                                NAPI.Data.SetEntityData(Client, "character_leader", i);
                                NAPI.Data.SetEntityData(Client, "character_group", i);
                                NAPI.Data.SetEntityData(Client, "character_group_rank", 5);

                                Main.SendCustomChatMessasge(Client, "Organizasyonu ~g~" + Client.GetData<dynamic>("gangue_name") + "~w~ olarak oluşturdunuz.");
                                Main.SendCustomChatMessasge(Client, "Komutları görmek için ~y~/help gang~w~ komutunu kullanın.");
                                FactionManage.SaveFaction(i);
                                FactionManage.SaveFactionRanks(i);
                                return;
                            }
                        }
                        Main.SendErrorMessage(Client, "Şu anda organizasyon oluşturulamıyor!");
                        break;
                    }
            }
        }
        else if (callbackId == "PLAYER_FACTION_HIERARQUIA")
        {
            Client.SetData<dynamic>("customListItem", selectedIndex);
            InteractMenu.User_Input(Client, "input_player_faction_hierarquia", "Rütbe Adı", Client.GetData<dynamic>("gangue_hierarquia_" + selectedIndex));
            InteractMenu.CloseDynamicMenu(Client);
        }
    }

    public static void OnInputResponse(Player Client, String response, String inputtext)
    {
        switch (response)
        {
            case "input_player_faction_create":
                Client.SetData<dynamic>("gangue_name", inputtext);
                DisplayCreateGangueMenu(Client);
                break;
            case "input_player_faction_abbrev":
                Client.SetData<dynamic>("gangue_abreviacao", inputtext);
                DisplayCreateGangueMenu(Client);
                break;
            case "input_player_faction_color":
                Client.SetData<dynamic>("gangue_color", inputtext);
                DisplayCreateGangueMenu(Client);
                break;
            case "input_player_faction_hierarquia":

                int index = Client.GetData<dynamic>("customListItem");
                if (inputtext.Count() < 4)
                {
                    Main.SendErrorMessage(Client, "Rütbe adı en az 3 karakter içermelidir.");
                    DisplayCreateGangueMenu(Client);
                    return;
                }
                Client.SetData<dynamic>("gangue_hierarquia_" + index, inputtext);

                // Menüyi tekrar göster
                List<dynamic> menu_item_list = new List<dynamic>();
                for (int i = 0; i < 6; i++)
                {
                    menu_item_list.Add(new { Type = 1, Name = "Rütbe " + i + ".", Description = "", RightLabel = "~w~" + Client.GetData<dynamic>("gangue_hierarquia_" + i) });
                }
                InteractMenu.CreateMenu(Client, "PLAYER_FACTION_HIERARQUIA", "Faction", "~b~Hiyerarşi", false, NAPI.Util.ToJson(menu_item_list), false);
                break;
        }
    }

    public static void OnMenuReturnClose(Player Client, String callbackId)
    {
        if (callbackId == "PLAYER_FACTION_HIERARQUIA")
        {
            DisplayCreateGangueMenu(Client);
        }
    }
}
