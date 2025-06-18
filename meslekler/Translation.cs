using GTANetworkAPI;
using Infinity.meslekler;
using System;
using System.Collections.Generic;


public class Translation : Script
{
    public Translation()
    {
        //
        // Blips and Blips name
        //

        Entity temp_blip;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(430.7088, -983.0495, 30.71043));
        NAPI.Blip.SetBlipName(temp_blip, "Los Santos Police Departmant");
        NAPI.Blip.SetBlipSprite(temp_blip, 60);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 38);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(149.84868, -1040.7798, 29.374088));
        NAPI.Blip.SetBlipName(temp_blip, "Banka");
        NAPI.Blip.SetBlipSprite(temp_blip, 108);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 2);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(231.15, 214.62, 106.55));
        NAPI.Blip.SetBlipName(temp_blip, "Ana Banka");
        NAPI.Blip.SetBlipSprite(temp_blip, 108);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 5);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-343.64, -139.07, 60.40));
        NAPI.Blip.SetBlipName(temp_blip, "Mekanik");
        NAPI.Blip.SetBlipSprite(temp_blip, 446);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 30);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(2322.45, 4872.83, 50.00));
        NAPI.Blip.SetBlipName(temp_blip, "T1");
        NAPI.Blip.SetBlipSprite(temp_blip, 686);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 85);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(518.00, -2981.00, 50.00));
        NAPI.Blip.SetBlipName(temp_blip, "T2");
        NAPI.Blip.SetBlipSprite(temp_blip, 687);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 85);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(314.2728, -279.11133, 54.1708));
        NAPI.Blip.SetBlipName(temp_blip, "Banka");
        NAPI.Blip.SetBlipSprite(temp_blip, 108);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 2);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1212.7267, -330.8521, 37.787037));
        NAPI.Blip.SetBlipName(temp_blip, "Banka");
        NAPI.Blip.SetBlipSprite(temp_blip, 108);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 2);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(128.57, -1296.5, 29.26));
        NAPI.Blip.SetBlipName(temp_blip, "Kulüp");
        NAPI.Blip.SetBlipSprite(temp_blip, 121);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 83);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(298.61848, -584.39493, 43.50094));
        NAPI.Blip.SetBlipName(temp_blip, "Hastane");
        NAPI.Blip.SetBlipSprite(temp_blip, 153);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipColor(temp_blip, 1);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-188.8128, -1155.198, 23.04762));
        NAPI.Blip.SetBlipName(temp_blip, "Park Alanı");
        NAPI.Blip.SetBlipSprite(temp_blip, 225);
        NAPI.Blip.SetBlipColor(temp_blip, 1);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        /*temp_blip = NAPI.Blip.CreateBlip(new Vector3(903.7722, -173.3565, 74.07556));
        NAPI.Blip.SetBlipName(temp_blip, "Taksi");
        NAPI.Blip.SetBlipSprite(temp_blip, 198);
        NAPI.Blip.SetBlipColor(temp_blip, 46);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);*/

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-211.87, -1324.31, 30.89));
        NAPI.Blip.SetBlipName(temp_blip, "Tuning");
        NAPI.Blip.SetBlipSprite(temp_blip, 777);
        NAPI.Blip.SetBlipColor(temp_blip, 3);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-253.38, -2027.96, 30.10));
        NAPI.Blip.SetBlipName(temp_blip, "Arena");
        NAPI.Blip.SetBlipSprite(temp_blip, 546);
        NAPI.Blip.SetBlipColor(temp_blip, 5);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1388.17, -586.96, 32.10));
        NAPI.Blip.SetBlipName(temp_blip, "Bahamas");
        NAPI.Blip.SetBlipSprite(temp_blip, 133);
        NAPI.Blip.SetBlipColor(temp_blip, 3);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1991.71, 3055.52, 47.21));
        NAPI.Blip.SetBlipName(temp_blip, "RacePub");
        NAPI.Blip.SetBlipSprite(temp_blip, 315);
        NAPI.Blip.SetBlipColor(temp_blip, 3);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1536.50, 4637.14, 28.40));
        NAPI.Blip.SetBlipName(temp_blip, "Mantar Yeri");
        NAPI.Blip.SetBlipSprite(temp_blip, 270);
        NAPI.Blip.SetBlipColor(temp_blip, 1);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-679.30, 5834.16, 20.40));
        NAPI.Blip.SetBlipName(temp_blip, "Mantar Satışı");
        NAPI.Blip.SetBlipSprite(temp_blip, 270);
        NAPI.Blip.SetBlipColor(temp_blip, 4);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-564.77, 274.72, 84.11));
        NAPI.Blip.SetBlipName(temp_blip, "Tequilala");
        NAPI.Blip.SetBlipSprite(temp_blip, 766);
        NAPI.Blip.SetBlipColor(temp_blip, 8);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1691.06, 2566.53, 61.10));
        NAPI.Blip.SetBlipName(temp_blip, "Hapishane");
        NAPI.Blip.SetBlipSprite(temp_blip, 188);
        NAPI.Blip.SetBlipColor(temp_blip, 4);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-637.19, -2259.37, 5.93));
        NAPI.Blip.SetBlipName(temp_blip, "Sürücü Kursu");
        NAPI.Blip.SetBlipSprite(temp_blip, 498);
        NAPI.Blip.SetBlipColor(temp_blip, 2);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-580.90, -925.52, 36.83));
        NAPI.Blip.SetBlipName(temp_blip, "Weazel News");
        NAPI.Blip.SetBlipSprite(temp_blip, 817);
        NAPI.Blip.SetBlipColor(temp_blip, 61);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1041.93, -2744.39, 50.90));
        NAPI.Blip.SetBlipName(temp_blip, "Spawn");
        NAPI.Blip.SetBlipSprite(temp_blip, 120);
        NAPI.Blip.SetBlipColor(temp_blip, 4);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-294.11, -422.01, 30.23));
        NAPI.Blip.SetBlipName(temp_blip, "Plaka Kayıt");
        NAPI.Blip.SetBlipSprite(temp_blip, 764);
        NAPI.Blip.SetBlipColor(temp_blip, 7);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-83.47, 79.86, 71.55));
        NAPI.Blip.SetBlipName(temp_blip, "Sigorta");
        NAPI.Blip.SetBlipSprite(temp_blip, 662);
        NAPI.Blip.SetBlipColor(temp_blip, 53);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1200.00, -1571.00, 5.00));
        NAPI.Blip.SetBlipName(temp_blip, "GYM");
        NAPI.Blip.SetBlipSprite(temp_blip, 311);
        NAPI.Blip.SetBlipColor(temp_blip, 38);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-2866.10, 2196.34, 38.00));
        NAPI.Blip.SetBlipName(temp_blip, "Route 68 CH");
        NAPI.Blip.SetBlipSprite(temp_blip, 791);
        NAPI.Blip.SetBlipColor(temp_blip, 8);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);


        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Üniforma Dolabi ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(471.31, -990.81, 25.73 + 0.3), 5, 0.3500f, 4, new Color(0, 122, 255, 150));
        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Aksesuar Dolabi ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(473.29, -984.71, 25.73 + 0.3), 5, 0.3500f, 4, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Garaj ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(467.95, -986.01, 25.72 + 0.3), 12, 0.650f, 0, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Cephane Dolabi ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(484.21, -1001.63, 25.73 + 0.3), 12, 0.650f, 0, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Halkla Iliskiler ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(441.28094, -981.8585, 30.6896 + 0.3), 12, 0.3500f, 4, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Görev ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(1834.7035, 3690.256, 34.270626 + 0.3), 12, 0.3500f, 0, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Garaj ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(338.57, -586.43, 28.79), 12, 0.650f, 0, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Park Servisi ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(-177.1379, -1158.62, 23.81368 + 0.3), 12, 0.3500f, 0, new Color(0, 122, 255, 150));
        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Park Servisi ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(-202.0608, -1158.614, 23.81368 + 0.3), 12, 0.3500f, 0, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Kodes #1 ))~n~" + Main.LabelCommandColor + "« /hapiseat »", new Vector3(458.63, -985.65, 34.20 + 0.3), 12, 0.3500f, 0, new Color(0, 122, 255, 150));
        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Kodes #2 ))~n~" + Main.LabelCommandColor + "« /hapiseat »", new Vector3(458.34, -1008.04, 28.27 + 0.3), 12, 0.3500f, 0, new Color(0, 122, 255, 150));
        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Isbasi Noktasi ))~n~" + Main.LabelCommandColor + "« /isbasi »", new Vector3(469.00632, -988.65173, 25.729673 + 0.3), 12, 0.3500f, 0, new Color(0, 122, 255, 150));

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Surucu Kursu ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(-637.19, -2259.37, 5.93 + 0.3), 12, 0.650f, 0, new Color(0, 122, 255, 150));

        Main.crime_list.Add(new { crime_name = "Zlocin 1", crime_points = 1 });
        Main.crime_list.Add(new { crime_name = "Zlocin 2", crime_points = 2 });
        Main.crime_list.Add(new { crime_name = "Zlocin 3", crime_points = 3 });
        Main.crime_list.Add(new { crime_name = "Zlocin 4", crime_points = 3 });
        Main.crime_list.Add(new { crime_name = "Zlocin 5", crime_points = 3 });
        Main.crime_list.Add(new { crime_name = "Zlocin 6", crime_points = 5 });
        Main.crime_list.Add(new { crime_name = "Zlocin 7", crime_points = 5 });
        Main.crime_list.Add(new { crime_name = "Zlocin 8", crime_points = 7 });
        Main.crime_list.Add(new { crime_name = "Zlocin 9", crime_points = 7 });
        Main.crime_list.Add(new { crime_name = "Zlocin 10", crime_points = 10 });
        Main.crime_list.Add(new { crime_name = "Zlocin 11", crime_points = 10 });
        Main.crime_list.Add(new { crime_name = "Zlocin 12", crime_points = 10 });
        Main.crime_list.Add(new { crime_name = "Zlocin 13 ", crime_points = 15 });
        Main.crime_list.Add(new { crime_name = "Zlocin 14", crime_points = 30 });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 0, picture = "", name = "Yok", Useable = false, description = "", guest = Inventory.ITEM_TYPE_NONE, hash = 0, position = 0f, weight = 0.00f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 1, picture = "water", name = "Su", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 746336278, position = 0.9f, weight = 0.25f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 2, picture = "burger", name = "Hamburger", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4098414302, position = 1.0f, weight = 0.5f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 3, picture = "ammosniper", name = "7.62x51mm", Useable = true, description = "", guest = Inventory.ITEM_TYPE_Ammunation, hash = 1843823183, position = 1.0f, weight = 0.070f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 4, picture = "ammorifle", name = "7.62", Useable = true, description = "", guest = Inventory.ITEM_TYPE_Ammunation, hash = 1843823183, position = 1.0f, weight = 0.08f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 5, picture = "ammopump", name = "12x3mm", Useable = true, description = "", guest = Inventory.ITEM_TYPE_Ammunation, hash = 1843823183, position = 1.0f, weight = 0.100f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 6, picture = "ammopistol", name = "9mm", Useable = true, description = "", guest = Inventory.ITEM_TYPE_Ammunation, hash = 1843823183, position = 1.0f, weight = 0.04f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 7, picture = "ammosmg", name = ".45", Useable = true, description = "", guest = Inventory.ITEM_TYPE_Ammunation, hash = 1843823183, position = 1.0f, weight = 0.022f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 8, picture = "toolbox", name = "Tamir Kiti", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 3708911030, position = 0.8f, weight = 3.5f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 9, picture = "small_backpack", name = "Sırt Çantası (2)", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 1203231469, position = 0.8f, weight = 0.8f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 10, picture = "small_backpack", name = "Sırt Çantası (1)", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3300226909, position = 0.8f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 11, picture = "weed", name = "Marijuana Listesi (?)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 1696520608, position = 1.0f, weight = 0.9f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 12, picture = "weed-cigaret", name = "Marijuana", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4183981113, position = 1.0f, weight = 0.400f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 13, picture = "salt-rock", name = "Kaya Tuzu", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 3300226909, position = 0.9f, weight = 0.8f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 14, picture = "salt-powder", name = "Tuz", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 3300226909, position = 0.9f, weight = 0.6f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 15, picture = "cocain-leaves", name = "Kokain Listesi", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 1696520608, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 16, picture = "cocain", name = "Kokain", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3991509468, position = 1.0f, weight = 0.100f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 17, picture = "seed", name = "Buğday", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 3300226909, position = 0.9f, weight = 1.00f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 18, picture = "heavy-armor-vest", name = "Çelik Yelek", Useable = true, description = "", guest = Inventory.ITEM_TYPE_NONE, hash = 2515752923, position = 1.0f, weight = 5.00f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 19, picture = "c4", name = "C4", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 1876445962, position = 1.0f, weight = 2.05f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 20, picture = "drill", name = "Matkap", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3851537501, position = 1.0f, weight = 5.10f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 21, picture = "gascan", name = "Benzin Kutusu", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 242383520, position = 1.0f, weight = 8.00f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 22, picture = "first_aid_pack", name = "İlk Yardım Kiti", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 678958360, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 23, picture = "radio", name = "Radyo", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 2330564864, position = 1.0f, weight = 0.6f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 24, picture = "bboby-pin", name = "Metal İğne (?)", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1580014892, position = 1.0f, weight = 0.5f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 25, picture = "cableties", name = "Kablo Bağı", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3149903672, position = 1.0f, weight = 1.0f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 26, picture = "kod", name = "Kod", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 424800391, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 27, picture = "pills", name = "İlaç Tableti", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3538502018, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 28, picture = "picklock", name = "Maymuncuk", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 977923025, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 29, picture = "Ammonium_Nitrate", name = "Amonyum Nitrat", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1411212000, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 30, picture = "Ammonium_sulphate", name = "Amonyum Sülfat", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1411212000, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 31, picture = "Monoammonium_phosphate", name = "Monoamonyum Fosfat", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1254553771, position = 1.0f, weight = 1.0f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 32, picture = "kod", name = "Kod", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 424800391, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 33, picture = "afat-kosh", name = "Afat Kosh (?)", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3149903672, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 34, picture = "bil", name = "Kürek (?)", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1925751803, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 35, picture = "Ammonium_Nitrate", name = "Amonyum Nitrat", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1411212000, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 36, picture = "Ammonium_sulphate", name = "Amonyum Sülfat", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1411212000, position = 1.0f, weight = 1.0f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 37, picture = "Iron", name = "Demir", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3002107984, position = 1.0f, weight = 0.7f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 38, picture = "Copper", name = "Bakır", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4031179319, position = 1.0f, weight = 0.5f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 39, picture = "Silver", name = "Gümüş", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3002107984, position = 1.0f, weight = 0.6f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 40, picture = "Gold", name = "Altın", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4031179319, position = 1.0f, weight = 0.8f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 41, picture = "Platinum", name = "Platin", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3002107984, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 42, picture = "jackhammer", name = "Pense", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1360563376, position = 1.0f, weight = 5.0f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 43, picture = "Gloves_Box", name = "Boks Eldiveni", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 335898267, position = 1.0f, weight = 1f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 44, picture = "hotdog", name = "Hot Dog", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4098414302, position = 1.0f, weight = 1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 45, picture = "sandwich", name = "Sandviç", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4098414302, position = 1.0f, weight = 1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 46, picture = "cola", name = "Coca Cola", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4098414302, position = 1.0f, weight = 1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 47, picture = "redwine", name = "Kırmızı Şarap", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4098414302, position = 1.0f, weight = 1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 48, picture = "kicon", name = "Tarif Kitabı", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 2025816514, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 49, picture = "opruga", name = "Yay (?)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.8f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 50, picture = "cev_za_pusku", name = "Tüfek Çevresi (?)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 1.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 51, picture = "chip", name = "Çip (?)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 52, picture = "kevlar", name = "Kask", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 53, picture = "kundak_puske", name = "Tüfek Kundak (?)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 54, picture = "okicad", name = "Okidac (?)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 55, picture = "sarzer_za_pistolj", name = "Küçük Sanzer (?)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 56, picture = "sarzer_za_pusku", name = "Büyük Sanzer (?)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 57, picture = "snajperski_nisan", name = "Nişangah (?)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 58, picture = "usb", name = "USB", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 59, picture = "maticna_ploca", name = "Anakart", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 60, picture = "576", name = "Hack One", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 61, picture = "Spunk", name = "Sprunk", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 2973713592, position = 1.0f, weight = 0.33f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 62, picture = "eCola", name = "eCola", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 1020618269, position = 1.0f, weight = 0.33f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 63, picture = "Kafa", name = "Kahve", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3696781377, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 64, picture = "rpvc", name = "CH Coin", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 1597489407, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 65, picture = "heroin", name = "Heroin", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3991509468, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 66, picture = "opium", name = "Afyon", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3991509468, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 67, picture = "morfin", name = "Morfin", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3991509468, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 68, picture = "beer", name = "Bira", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 683570518, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 69, picture = "konjak", name = "Konyağı", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 2833294155, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 70, picture = "viski", name = "Viski", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 2833294155, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 71, picture = "votka", name = "Votka", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 2833294155, position = 1.0f, weight = 0.4f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 72, picture = "sampanjac", name = "Şampanya", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 1053267296, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 73, picture = "ccip", name = "Çip", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 74, picture = "babuska", name = "Çipura", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3708998996, position = 1.0f, weight = 0.5f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 75, picture = "saran", name = "Sazan", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3708998996, position = 1.0f, weight = 0.6f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 76, picture = "som", name = "Somon", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3708998996, position = 1.0f, weight = 0.7f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 77, picture = "pajser", name = "Levye", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 495450405, position = 1.0f, weight = 2.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 78, picture = "nakit", name = "Nakit", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 4248462993, position = 1.0f, weight = 0.1f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 79, picture = "eng1", name = "Motor Çipi", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 648185618, position = 1.0f, weight = 5.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 80, picture = "goldbar", name = "Altın Külçesi", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 4031179319, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 81, picture = "shroom", name = "Mantar", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 82, picture = "canli_yem", name = "Kurt", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 83, picture = "solucan", name = "Solucan", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 84, picture = "ekmek", name = "Ekmek", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 85, picture = "kucuk_balik", name = "Balık Parçası", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
       
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 86, picture = "karides", name = "Karides", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 87, picture = "rapala", name = "Rapala", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
     
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 88, picture = "jig", name = "Jig", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 89, picture = "buyuk_balik", name = "Büyük Balık", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
      
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 90, picture = "kalamar", name = "Kalamar", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 91, picture = "sahte_kalamar", name = "Sahte Kalamar", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 92, picture = "olta", name = "Olta", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 93, picture = "olta", name = "Olta (Küçük)", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 94, picture = "olta", name = "Olta (Orta)", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 95, picture = "olta", name = "Olta (Büyük)", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
      
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 96, picture = "fish", name = "Sazan", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 97, picture = "fish", name = "Kedi Balığı", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 98, picture = "fish", name = "Levrek (Tatlı)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 99, picture = "fish", name = "Güneş Balığı", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 100, picture = "fish", name = "Yılan Balığı", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 101, picture = "fish", name = "Uskumru", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 102, picture = "fish", name = "Palamut", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 103, picture = "fish", name = "Kaya Balığı", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 104, picture = "fish", name = "Baraküda", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 105, picture = "fish", name = "Lüfer", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
       
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 106, picture = "fish", name = "Mercan Balığı", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 107, picture = "fish", name = "Snapper", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 108, picture = "fish", name = "Orkinos (Küçük)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 109, picture = "fish", name = "Akya", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 110, picture = "fish", name = "Kılıç Balığı (Küçük)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
      
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 111, picture = "fish", name = "Mahi Mahi", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 112, picture = "fish", name = "Ton Balığı (Büyük)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 113, picture = "fish", name = "Morina", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 114, picture = "fish", name = "Mavi Marlin (Orta)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 115, picture = "fish", name = "Kılıç Balığı (Orta)", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });


    }//prop_michael_sec_id    //Page 74 KIF  //prop_fib_badge

    //
    // Others
    //
    public static string invalid_command = "~r~[!]~w~: Böyle bir komut bulunamadı. ~r~/yardim ~w~ya da ~r~/destek ~w~komutu ile yardım alabilirsiniz.";

    public static string message_error = "~r~[!]~w~";
    public static string message_info = "~y~[!]~w~";
    public static string message_warning = "~r~[!]~w~";
    public static string message_success = "~y~[!]~w~";
    public static string message_meslek = "~y~[MESLEK]~w~";


    public static string chat_mask_type = "Maske_";
    public static string chat_cellphone_type = "(Telefon)";
    public static string chat_unknow_type = "Yabancı_";

    public static string other_1 = "Bölge";
    public static string other_2 = "Boş";

    //
    // Vehicle Class
    //
    public static string DEALERSHIP_TYPE_CAR = "Galeri";
    public static string DEALERSHIP_TYPE_BIKE = "Motogaleri";
    public static string DEALERSHIP_TYPE_BOAT = "Deniz Galerisi";
    public static string DEALERSHIP_TYPE_HELLI = "Hava Galerisi";
    public static string DEALERSHIP_TYPE_TRUCK = "Kamyonet Galerisi";

    // ===============================================================
    // ===============================================================

    //
    // Business Manage
    // ** !! DO NOT DUPLICATE THESE'S NAMES !

    public static string BUSINESS_MANAGE_MENU_1 = "İsim";
    public static string BUSINESS_MANAGE_MENU_2 = "Tür";
    public static string BUSINESS_MANAGE_MENU_3 = "Tip";
    public static string BUSINESS_MANAGE_MENU_4 = "Sınıf";
    public static string BUSINESS_MANAGE_MENU_5 = "Depo Kapasitesi";
    public static string BUSINESS_MANAGE_MENU_6 = "Satış Yeri";
    public static string BUSINESS_MANAGE_MENU_7 = "Teslimat Yeri";
    public static string BUSINESS_MANAGE_MENU_8 = "Giysi Seçimi";
    public static string BUSINESS_MANAGE_MENU_9 = "Kasa";
    public static string BUSINESS_MANAGE_MENU_10 = "Silah Alış Yeri";
    public static string BUSINESS_MANAGE_MENU_11 = "Benzin İstasyonu #1";
    public static string BUSINESS_MANAGE_MENU_12 = "Benzin İstasyonu #2";
    public static string BUSINESS_MANAGE_MENU_13 = "Benzin İstasyonu #3";
    public static string BUSINESS_MANAGE_MENU_14 = "Benzin İstasyonu #4";
    public static string BUSINESS_MANAGE_MENU_15 = "Benzin İstasyonu #5";
    public static string BUSINESS_MANAGE_MENU_16 = "Benzin İstasyonu #6";
    public static string BUSINESS_MANAGE_MENU_17 = "Benzin İstasyonu #7";
    public static string BUSINESS_MANAGE_MENU_18 = "Benzin İstasyonu #8";
    public static string BUSINESS_MANAGE_MENU_19 = "Benzin İstasyonu #9";
    public static string BUSINESS_MANAGE_MENU_20 = "Etkileşim Menüsü";
    public static string BUSINESS_MANAGE_MENU_21 = "Araç Görünümü";
    public static string BUSINESS_MANAGE_MENU_22 = "Araç Satın Al";
    public static string BUSINESS_MANAGE_MENU_23 = "Kuaför / Dövme Yeri";
    public static string BUSINESS_MANAGE_MENU_24 = "Kimyasal Menü Yeri";
    public static string BUSINESS_MANAGE_MENU_25 = "Dövme Menü Yeri";

    // Business Owner Manage
    public static string BUSINESS_PLAYER_MENU_1 = "İşletme Adı";
    public static string BUSINESS_PLAYER_MENU_2 = "Kilit";
    public static string BUSINESS_PLAYER_MENU_3 = "Patron";
    public static string BUSINESS_PLAYER_MENU_4 = "Silah Fiyatını Değiştir";
    public static string BUSINESS_PLAYER_MENU_6 = "Benzin Fiyatını Değiştir";
    public static string BUSINESS_PLAYER_MENU_7 = "Ürün Siparişi Ver";
    public static string BUSINESS_PLAYER_MENU_8 = "İşletmeyi Sat";





    // ===============================================================
    // ===============================================================

    //
    // Araçla Etkileşim
    // ** !! BU İSİMLERİ TEKRAR ETMEYİN!
    public static string INTERACT_VEHICLE_MENU = "Araç Menüsü";
    public static string INTERACT_VEHICLE_MENU_1 = "Kilit";
    public static string INTERACT_VEHICLE_MENU_2 = "Tamir";
    public static string INTERACT_VEHICLE_MENU_3 = "Yakıt Doldur";
    public static string INTERACT_VEHICLE_MENU_4 = "Bagaj";
    public static string INTERACT_VEHICLE_MENU_5 = "Bagaj Arama";    ///ADD Bayad beshe to Circle
    public static string INTERACT_VEHICLE_MENU_6 = "Araçtan Çıkar";
    public static string INTERACT_VEHICLE_MENU_7 = "El Koyma";
    public static string INTERACT_VEHICLE_MENU_8 = "Ceza";

    //
    // Hedef Oyuncuyla Etkileşim
    // ** !! BU İSİMLERİ TEKRAR ETMEYİN!
    public static string INTERACT_PLAYER_TARGET_MENU = "Etkileşim";
    public static string INTERACT_PLAYER_TARGET_MENU_SUBTITLE = "~g~Etkileşim {0}";
    public static string INTERACT_PLAYER_TARGET_MENU_1 = "Para Ver";
    public static string INTERACT_PLAYER_TARGET_MENU_2 = "Kimlik Göster";
    public static string INTERACT_PLAYER_TARGET_MENU_3 = "Lisans Göster";
    public static string INTERACT_PLAYER_TARGET_MENU_4 = "Bağla";
    public static string INTERACT_PLAYER_TARGET_MENU_5 = "Taşı";
    public static string INTERACT_PLAYER_TARGET_MENU_6 = "Çek";
    public static string INTERACT_PLAYER_TARGET_MENU_7 = "Bırak";
    public static string INTERACT_PLAYER_TARGET_MENU_8 = "El Koy";
    public static string INTERACT_PLAYER_TARGET_MENU_9 = "Silahlarına El Koy";
    public static string INTERACT_PLAYER_TARGET_MENU_10 = "Arama";
    public static string INTERACT_PLAYER_TARGET_MENU_11 = "Ceza Yaz";
    public static string INTERACT_PLAYER_TARGET_MENU_12 = "Şüpheli";
    public static string INTERACT_PLAYER_TARGET_MENU_13 = "Tutukla";
    public static string INTERACT_PLAYER_TARGET_MENU_14 = "Alıkoy";
    public static string INTERACT_PLAYER_TARGET_MENU_15 = "Yaz";
    public static string INTERACT_PLAYER_TARGET_MENU_16 = "Tedavi Et";
    public static string INTERACT_PLAYER_TARGET_MENU_17 = "Reanimasyon";
    public static string INTERACT_PLAYER_TARGET_MENU_18 = "Çağır";

    public static string INTERACT_PLAYER_TARGET_MENU_19 = "Bilinmeyen 1";    ///ADD Bayad beshe to Circle
    public static string INTERACT_PLAYER_TARGET_MENU_20 = "Bilinmeyen 2";     ///ADD Bayad beshe to Circle


    //
    // Müşteri ile Etkileşim
    // ** !! BU İSİMLERİ TEKRAR ETMEYİN!
    public static string INTERACT_PLAYER_MENU = "";
    public static string INTERACT_PLAYER_MENU_5 = "Ev Al";
    public static string INTERACT_PLAYER_MENU_6 = "Ev Sat";
    //public static string INTERACT_PLAYER_MENU_7 = "Ev Yönetimi";
    public static string INTERACT_PLAYER_MENU_8 = "Çizgi Roman Al";
    public static string INTERACT_PLAYER_MENU_9 = "Çizgi Roman Sat";
    public static string INTERACT_PLAYER_MENU_10 = "Çağrıyı Kabul Et";
    public static string INTERACT_PLAYER_MENU_11 = "Çağrıyı Reddet";
    public static string INTERACT_PLAYER_MENU_12 = "Ceza Kabul Et";
    public static string INTERACT_PLAYER_MENU_13 = "Ceza Reddet";
    public static string INTERACT_PLAYER_MENU_14 = "Tedavi Kabul Et";
    public static string INTERACT_PLAYER_MENU_15 = "Tedavi Reddet";
    public static string INTERACT_PLAYER_MENU_16 = "Çal";
    public static string INTERACT_PLAYER_MENU_17 = "Bağla";
    public static string INTERACT_PLAYER_MENU_18 = "Emniyet Kemerini Tak";
    public static string INTERACT_PLAYER_MENU_19 = "Park Et";
    public static string INTERACT_PLAYER_MENU_20 = "Kilitle";
    public static string INTERACT_PLAYER_MENU_21 = "Kilidi Aç";
    public static string INTERACT_PLAYER_MENU_22 = "Bagaj";
    public static string INTERACT_PLAYER_MENU_23 = "Kruvazör Hızı";
    public static string INTERACT_PLAYER_MENU_24 = "Taksi Metresini Kapat";
    public static string INTERACT_PLAYER_MENU_25 = "Taksimetre";
    public static string INTERACT_PLAYER_MENU_26 = "İstatistikler";
    public static string INTERACT_PLAYER_MENU_27 = "Kimlik Kartı";
    public static string INTERACT_PLAYER_MENU_28 = "Lisanslar";
    // public static string INTERACT_PLAYER_MENU_29 = "Fraksiyonlar";
    public static string INTERACT_PLAYER_MENU_30 = "İş";
    public static string INTERACT_PLAYER_MENU_31 = "Maske";
    public static string INTERACT_PLAYER_MENU_32 = "Şapka";
    public static string INTERACT_PLAYER_MENU_33 = "Gözlük";
    public static string INTERACT_PLAYER_MENU_34 = "Yardım İptal Et";
    public static string INTERACT_PLAYER_MENU_35 = "Yerden Kalk";
    // public static string INTERACT_PLAYER_MENU_36 = "İş Yeri Bul";
    //  public static string INTERACT_PLAYER_MENU_37 = "Servisi Tamamla";
    public static string INTERACT_PLAYER_MENU_38 = "İşi Bitir";
    public static string INTERACT_PLAYER_MENU_39 = "GPS'i Ekin Satış Yerine Ayarla";
    public static string INTERACT_PLAYER_MENU_40 = "Günün Mesajı";
    public static string INTERACT_PLAYER_MENU_41 = "Yönetim";
    public static string INTERACT_PLAYER_MENU_42 = "Rütbeyi Değiştir";
    public static string INTERACT_PLAYER_MENU_43 = "Üye Listesi";
    public static string INTERACT_PLAYER_MENU_44 = "Organizasyondan Ayrıl";

    public static string INTERACT_PLAYER_MENU_47 = "Kısa Ad";
    public static string INTERACT_PLAYER_MENU_48 = "Organizasyon Rengi";

    public static string INTERACT_PLAYER_MENU_45 = "Cinsel İlişki";
    public static string INTERACT_PLAYER_MENU_46 = "Cinsel İlişkiyi Bitir";

    public static string INTERACT_PLAYER_MENU_49 = "Zırh";


    //
    // Commands
    //


    //
    // Shard
    //


    public static string shard_give_experience = "Şu anda {0} seviyesindesiniz, {1}.";
    public static string shard_01 = "Hastaneye tedavi için gönderildiniz.";
    public static string shard_01_title = "Başarılı!";

    public static string shard_2 = "~y~Ciddi şekilde yaralandınız!!";
    public static string shard_2_title = "Bilinç kaybı yaşadınız.";

    //
    // Mesajlar
    //
    //string.Format(Translation.message_04)

    public static string vehicle_destroy_send_mors = "Sizin {0} aracınız yok edildi, aracınızı Otopark Servisinden alabilirsiniz.";
    public static string message_taxi_driver_exit_Vehicle = "~y~*~w~ Taksi aracını terk ettiniz ve ~g~${0}~w~ ücret ödediniz.";
    public static string message_taxi_passager_exit_Vehicle = "~y~*~w~ Taksi şoförü aracı terk etti, ~g~${0}~w~ ücret ödediniz.";
    public static string message_taxi_passager_exit_vehicle_2 = "~y~*~w~ Taksi aracını terk ettiniz ve ~g~${0}~w~ ücret ödediniz.";
    public static string message_taxi_passager_exit_vehicle_3 = "~y~*~w~ {0} taksi aracını terk etti ve {1} ücret ödedi.";
    public static string message_taxi_passager_exit_vehicle_4 = "~w~Yeterli paranız yok, kilometre başına ücret ~g~${0}~w~.";


    public static string message_01 = "Aracınız bozuldu, lütfen bir tamirci çağırın!";
    public static string message_02 = "[Bölge]:~w~ {0} {1} bölgesinde öldü.";
    public static string message_03 = "[Bölge]:~w~ Üye ~g~{0}~w~ {1} bölgesinde öldü.";
    public static string message_04 = "[Bölge]:~w~ {0} {1} tarafından ~y~{2}~w~ bölgesinde öldürüldü.";
    public static string message_05 = "[Bölge]:~w~ {0} {1} kişisini ~y~{2}~w~ bölgesinde öldürdü.";
    public static string message_06 = "Bayıldınız ve acilen hastaneye sevk edildiniz.";
    public static string message_07 = "Anahtarı çevirip aracı çalıştırmayı deniyor.";
    public static string message_08 = "~c~ Verginizi ödediniz!";
    public static string message_09 = "~g~ Sunucu kurallarına uyun, aksi takdirde cezalandırılabilirsiniz!";
    public static string message_10 = "Tedavi masraflarınız: ~g~$2,500~w~!";
    public static string message_11 = "~g~[Bölge]:~w~ Bölge ~y~{0}~w~ ele geçirilebilir.";
    public static string message_12 = "~g~[Bölge]:~w~ Bölgeyi ele geçirerek ~g~$~y~{0}~w~ kazandınız.";
    public static string message_13 = "Salonda değilsiniz.";
    public static string message_14 = "Yeterli paranız yok.";
    public static string message_15 = "Şu an bu ürün mevcut değil!";
    public static string message_16 = "Salonunuzu değiştirdiniz: {0}.";
    public static string message_17 = "Şu anda bunu yapamazsınız!";

    //
    // Bildirimler
    //
    public static string notification_info_seatbelt = "Arabaya bindiniz, emniyet kemerinizi takmayı unutmayın!";
    public static string notification_enter_vehicle_ticket = "Aracınızın ~y~{0}~w~, ~g~$ {1}~w~  cezası var, cezanızı ödemek için ~g~Los Santos Police Deparmant'a gidin.";

    public static string notification_1 = "Biraz bekleyin ve tekrar deneyin!";
    public static string notification_2 = "Yanlış isim veya şifre girdiniz!";
    public static string notification_3 = "Adınız en az 4, en fazla 30 karakter olmalıdır!";
    public static string notification_4 = "Şifreniz en az 4, en fazla 30 karakter olmalıdır.";
    public static string notification_5 = "Geçersiz e-posta adresi.";
    public static string notification_6 = "Anahtarınız yok!";
    public static string notification_7 = "Eviniz " + Main.EMBED_LIGHTGREEN + "açık" + Main.EMBED_WHITE + ".";
    public static string notification_8 = "Eviniz " + Main.EMBED_RED + "kilitli" + Main.EMBED_WHITE + ".";
    public static string notification_9 = "Görevde değilsiniz.";
    public static string notification_10 = "Araçtayken bu işlemi gerçekleştiremezsiniz!";
    public static string notification_11 = "~g~Vardiyanızı başlattınız~w~.";
    public static string notification_12 = "~r~Vardiyanızı bitirdiniz~w~.";
    public static string notification_13 = "Kapılar kilitli.";
    public static string notification_14 = "Eroin etkisi geçti.";
    public static string notification_15 = "Marijuana etkisi geçti.";
    public static string notification_16 = "Artık borcunuz yok, özgür bir vatandaş oldunuz!";
    public static string notification_17 = "Kendinizi kötü hissediyorsunuz, ~y~yemek~w~ ve ~g~içmek~w~ zorundasınız!";
    public static string notification_18 = "Acıktınız, bir şeyler yemeniz gerekiyor!";
    public static string notification_19 = "Susadınız, bir şeyler içmeniz gerekiyor!";


    //
    // Head Notificationhead_notification_9
    //
    public static string head_notification_0 = "Motor kapatıldı.";
    public static string head_notification_1 = "Açık";
    public static string head_notification_2 = "Kapalı";
    public static string head_notification_3 = "Motor kapatıldı.";
    public static string head_notification_4 = "Yakıt yok.";
    public static string head_notification_5 = "Motoru çalıştırmaya çalışıyorsunuz";
    public static string head_notification_6 = "Motor arızalı";
    public static string head_notification_7 = "Motor kapatıldı";
    public static string head_notification_8 = "Yakıt bitti";
    public static string head_notification_9 = "Motor çalışıyor";
    public static string head_notification_10 = "Ürün yok";
    public static string head_notification_11 = "Göreve başlayın.";

    //
    // Etiket
    //

    public static string ls_custom_label_free = Main.LabelColor + "(( Modifiye Noktasi ))~n~" + Main.LabelCommandColor + "« E »";
    public static string ls_custom_label_free1 = Main.LabelColor + "(( Modifiye Noktasi ))~n~" + Main.LabelCommandColor + "« E »";
    public static string ls_custom_label_busy = Main.LabelColor + "(( Modifiye Noktasi ))~n~" + Main.LabelCommandColor + "« Mesgul »";

    //
    // Çizgi metni
    //
    public static string draw_engine_vehicle_off = "Motoru çalıştırmak için ~w~ ~g~[ Y ]~w~ tuşunu kullanabilirsiniz.";

    //   "";


    public static void Create_Mechanic_Menu(Player Client)
    {
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "Görev", Description = "", RightLabel = "" });

        if (AccountManage.GetPlayerJob(Client) == 7)
        {
            menu_item_list.Add(new { Type = 1, Name = "~g~Katalog", Description = "", RightLabel = "" });
        }

        InteractMenu.CreateMenu(Client, "JOB_SHIPMENT", "Kamyoncu", "~g~Siparişler:", false, NAPI.Util.ToJson(menu_item_list), false);
    }


    public static void FirstAccount_Logged(Player Client)
    {
        NAPI.Entity.SetEntityPosition(Client, new Vector3(-1038.75, -2740.24, 13.90));
        NAPI.Entity.SetEntityRotation(Client, new Vector3(0, 0, -31));
        NAPI.Entity.SetEntityDimension(Client, 0);

        Main.SetPlayerMoney(Client, 2000);
        Main.SetPlayerMoneyBank(Client, 10000);
        Client.ResetData("firstJoinned");


        CharCreator.CharCreator.SaveChar(Client);
    }
    public static void Account_Logged(Player Client)
    {
        DateTime last_login = Client.GetData<dynamic>("character_last_login");

        

        if (VIP.GetPlayerVIP(Client) != 0)
        {
            DateTime vip_expire = Client.GetData<dynamic>("character_vip_expire");
            if (vip_expire < DateTime.Now)
            {
                //   Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "[VIP]", "VIP Shoma Be Etmam Reside, Jahat Kharid Be Shop Moraje'e Konid.");
                NAPI.Data.SetEntityData(Client, "character_vip", 0);
                NAPI.Data.SetEntityData(Client, "character_vip_expire", 0);

            }
            else
            {
                //      Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "[VIP]", "Shoma " + Main.EMBED_VIP + " VIP  " + Main.EMBED_WHITE + "Hastid. Etebar VIP Shoma Ta Tarikh: " + Main.EMBED_LIGHTGREEN + "" + vip_expire.ToString("dd/MM/yyyy HH:mm:ss") + "" + Main.EMBED_WHITE + "Mibashad.");
            }
        }

        // if (AccountManage.GetPlayerGroup(Client) != 0 && FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_motd != "") Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "[Faction]", FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_motd);
    }



    public static void PayExp(Player Client)
    {
        if (VIP.GetPlayerVIP(Client) == 1)
        {
            int new_exp = (Client.GetData<dynamic>("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY) + (int)(0.20 * (Client.GetData<dynamic>("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY));
        }

        if (VIP.GetPlayerVIP(Client) == 1)
        {
            int new_exp = (Client.GetData<dynamic>("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY) + (int)(0.20 * (Client.GetData<dynamic>("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY));
            Main.GivePlayerEXP(Client, new_exp);
        }
        else
        {
            Main.GivePlayerEXP(Client, Client.GetData<dynamic>("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY);
        }
        Client.SetSharedData("character_level", Client.GetData<dynamic>("character_level"));
    }

    public static void PayDay(Player Client)
    {
        if (Client.GetData<dynamic>("status") == true)
        {
            int maas = 2000, olusummaasi = 0;
            Random rnd = new Random();
            int vergi = rnd.Next(250, 400);

            Main.SendCustomChatMessasge(Client, $"<font color='#66ED00'>---------------------------------------------------------------------");
            Main.SendCustomChatMessasge(Client, $"<font color='#AFAFAF'>Saatlik Maaş: <font color='#00BD00'> ${maas.ToString("N0")}");
            if (FactionManage.GetPlayerGroupID(Client) == FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupID(Client) == FactionManage.FACTION_TYPE_MEDIC)
            {
                olusummaasi = FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_salary[AccountManage.GetPlayerRank(Client)];
                Main.SendCustomChatMessasge(Client, $"<font color='#AFAFAF'>Oluşum Maaşı: <font color='#00BD00'> ${olusummaasi.ToString("N0")}"); 
            }
            Main.SendCustomChatMessasge(Client, $"<font color='#AFAFAF'>Vatandaşlık Vergisi: <font color='#f00014'> $-{vergi.ToString("N0")}");

            int toplam = maas + olusummaasi;
            int vergiyicikart = toplam - vergi;
            Main.GivePlayerMoneyBank(Client, vergiyicikart);
            Main.SendCustomChatMessasge(Client, $"<font color='#AFAFAF'>Toplam Kazanç: <font color='#00BD00'> ${vergiyicikart.ToString("N0")}");
            Main.SendCustomChatMessasge(Client, $"<font color='#66ED00'>---------------------------------------------------------------------");

            Main.SavePlayerInformation(Client);

            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.GetData<dynamic>("Owner_set") == true)
                {
                    Main.CreateMySqlCommand("UPDATE `vehicles` SET `veh_osiguranje` = `veh_osiguranje` - 1 WHERE `veh_osiguranje` > 0");
                }
            }
        }
    }



    public static void ShowPlayerStats(Player target, Player client)
    {
        int level = client.GetData<dynamic>("character_level");
        int exp = client.GetData<dynamic>("character_exp");
        int rpvpoints = client.GetData<dynamic>("character_credits");
        int skill = client.GetData<dynamic>("jobskill");
        string referral = client.GetData<dynamic>("refferal");
        int carlic = client.GetData<dynamic>("character_car_lic");
        int motolic = client.GetData<dynamic>("character_moto_lic");
        int gunlic = client.GetData<dynamic>("character_gun_lic");
        string organisation = FactionManage.faction_data[AccountManage.GetPlayerGroup(client)].faction_name;
        string orgrank = FactionManage.faction_data[AccountManage.GetPlayerGroup(client)].faction_rank[AccountManage.GetPlayerRank(client)];
        string adminrank = adminCommands.GetPlayerAdminRank(client);
        int age = client.GetData<dynamic>("character_age");

        string vip = "Yok";
        if (VIP.GetPlayerVIP(client) >= 1) vip = "Var";

        if (organisation == "Staff") organisation = "Yok";
        if (orgrank == "nema") orgrank = "Yok";

        string aehliyet = "Yok";
        if (carlic >= 1) aehliyet = "Yok";

        string mehliyet = "Yok";
        if (motolic >= 1) mehliyet = "Yok";

        string gehliyet = "Yok";
        if (gunlic >= 1) gehliyet = "Var";

        string numara = "Yok";
        if (client.HasData("character_cellphone"))
        {
            numara = client.GetData<int>("character_cellphone").ToString();
        }

        int bank = NAPI.Data.GetEntityData(client, "character_bank");
        int money = NAPI.Data.GetEntityData(client, "character_money");

        Main.SendCustomChatMessasge(target, $"<font color='#66ED00'>//----------------------- {AccountManage.GetCharacterName(client)} ({client.Handle}) -----------------------//");
        Main.SendCustomChatMessasge(target, $"<font color='#CCE6E6'>[HESAP]<font color='#FFFFFF'> SQLID: <font color='#C2A2DA'>{client.GetData<dynamic>("character_sqlid")} <font color='#FFFFFF'>- Seviye: <font color='#C2A2DA'>{level} <font color='#FFFFFF'>- Deneyim Puanı: <font color='#C2A2DA'>{exp}");
        Main.SendCustomChatMessasge(target, $"<font color='#CCE6E6'>[HESAP]<font color='#FFFFFF'> Yönetici Seviyesi: <font color='#C2A2DA'>{adminrank} <font color='#FFFFFF'>- V.I.P: <font color='#C2A2DA'>{vip} <font color='#FFFFFF'>- OOC Bakiye: <font color='#C2A2DA'>{rpvpoints}");
        Main.SendCustomChatMessasge(target, $"<font color='#CCE6E6'>[KARAKTER]<font color='#FFFFFF'> Yaş: <font color='#C2A2DA'>{age} <font color='#FFFFFF'>- Birlik: <font color='#C2A2DA'>{organisation} <font color='#FFFFFF'>- Rütbe: <font color='#C2A2DA'>{orgrank}");
        Main.SendCustomChatMessasge(target, $"<font color='#CCE6E6'>[KARAKTER]<font color='#FFFFFF'> Araç Ehliyeti: <font color='#C2A2DA'>{aehliyet} <font color='#FFFFFF'>- Motor Ehliyeti: <font color='#C2A2DA'>{mehliyet} <font color='#FFFFFF'>- Silah Lisansı: <font color='#C2A2DA'>{gehliyet}");
        Main.SendCustomChatMessasge(target, $"<font color='#CCE6E6'>[KARAKTER]<font color='#FFFFFF'> Telefon: <font color='#C2A2DA'>{numara} <font color='#FFFFFF'>- Cüzdan: <font color='#C2A2DA'>{money} <font color='#FFFFFF'>- Banka: <font color='#C2A2DA'>{bank}");

    }
}

