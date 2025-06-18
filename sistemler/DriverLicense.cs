using GTANetworkAPI;
using System;
using System.Collections.Generic;

public class DriverLicense : Script
{
    public static Vehicle[] school_vehicle { get; set; } = new Vehicle[Main.MAX_PLAYERS];
    public static ColShape[] school_checkpoint { get; set; } = new ColShape[Main.MAX_PLAYERS];
    public static TimerEx[] school_tutorial_timer { get; set; } = new TimerEx[Main.MAX_PLAYERS];

    public static List<dynamic> vehicle_rota = new List<dynamic>();

    public DriverLicense()
    {
        //

        vehicle_rota.Add(new { position = new Vector3(-944.1837, -2123.5, 8.703898), message = "none" });
        vehicle_rota.Add(new { position = new Vector3(-829.9544, -2028.022, 8.576108), message = "stop" });
        vehicle_rota.Add(new { position = new Vector3(-742.5674, -2023.223, 8.899724), message = "none" });
        vehicle_rota.Add(new { position = new Vector3(-738.4678, -1985.861, 8.266144), message = "none" });
        vehicle_rota.Add(new { position = new Vector3(-707.9315, -2055.336, 8.265034), message = "none" });
        vehicle_rota.Add(new { position = new Vector3(-662.6473, -2007.087, 6.813873), message = "none" });
        vehicle_rota.Add(new { position = new Vector3(-511.6047, -2127.009, 8.473609), message = "none" });
        vehicle_rota.Add(new { position = new Vector3(-310.9691, -2162.664, 9.758541), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(3.355392, -2108.107, 9.782333), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-239.3412, -1846.088, 28.63881), message = "chap" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-295.999, -1820.652, 25.50999), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-360.3073, -1815.429, 22.20398), message = "rast" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-398.5178, -1780.68, 20.778), message = "chap" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-447.3097, -1772.613, 19.92935), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-608.5244, -1706.17, 23.41918), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-677.8533, -1641.004, 24.05957), message = "amade-rast" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-645.1669, -1490.846, 10.16868), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-630.7711, -1323.668, 10.06636), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-546.1592, -1172.794, 18.33065), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-533.5215, -1107.218, 21.75278), message = "rast" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-392.7494, -1127.239, 28.97806), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-194.3243, -1143.863, 22.60703), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-124.2391, -1137.639, 25.19362), message = "chap" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-84.31007, -1105.868, 25.49539), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-30.33352, -974.7975, 28.81186), message = "rast" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(77.66237, -995.2123, 28.90005), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(380.5675, -1054.846, 28.72319), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(595.1594, -1033.817, 36.4143), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(721.1041, -1018.32, 29.2), message = "amade-rast" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(786.1989, -1079.161, 28.12806), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(788.62, -1185.568, 27.53081), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(788.896, -1382.555, 26.30217), message = "amade-rast" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(714.0438, -1428.806, 30.9472), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(504.2774, -1427.189, 28.83592), message = "chap" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(394.6145, -1461.515, 28.76667), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(224.8102, -1559.578, 28.74123), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(80.91921, -1649.255, 28.83596), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-48.20041, -1712.629, 28.82002), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-106.8507, -1730.798, 29.42173), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-157.5046, -1747.789, 29.49294), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-235.3508, -1816.348, 29.363), message = "chap" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-170.1603, -1910.537, 24.71361), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-9.618667, -2006.635, 11.80647), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-2.246707, -2106.729, 9.756039), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-117.4048, -2161.057, 9.757373), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-306.1678, -2158.467, 9.791425), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-574.3832, -2052.875, 5.807239), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-909.6816, -2098.477, 8.548483), message = "park_konid" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-945.3257, -2117.836, 8.792059), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-891.7947, -2059.223, 8.799081), message = "none" }); // 0, 0, 65.57136

        API.Shared.CreateTextLabel(Main.LabelColor + "(( Surucu Kursu ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(-1289.7573, -572.499, 30.573061) + new Vector3(0, 0, 0.2f), 15.0f, 0.9f, 4, new Color(221, 255, 0, 210));
    }

    public static void PressKeyY(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-1289.7573, -572.499, 30.573061), 3))
        {

            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "Teori", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 1, Name = "Kategori B", Description = "Ehliyet alımı.", RightLabel = "$1500" });
            menu_item_list.Add(new { Type = 1, Name = "Kategori D", Description = "Ehliyet alımı.", RightLabel = "$2000" });
            InteractMenu.CreateMenu(Client, "DMV_SCHOOL", "", "Sürücü Kursu", true, NAPI.Util.ToJson(menu_item_list), false);


        }
    }


    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "DMV_SCHOOL")
        {
            if (selectedIndex == 0)
            {

                Client.TriggerEvent("freezeEx", true);
                Client.Dimension = 15;
                Client.TriggerEvent("ShowDMVCamera", 1);


                Main.SendMessageWithTagToPlayer(Client, " ", " ");
                Main.SendMessageWithTagToPlayer(Client, " ", " ");
                Main.SendMessageWithTagToPlayer(Client, " ", " ");
                Main.SendMessageWithTagToPlayer(Client, " ", " ");
                Main.SendMessageWithTagToPlayer(Client, " ", " ");
                Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_VIP + "-----------------------------------------------");
                Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_VIP + " Hız Limiti ");
                Main.SendCustomChatMessasge(Client, "~b~ ~ ~y~60 KM/H~b~ yerleşim alanlarında ~");
                Main.SendCustomChatMessasge(Client, "~b~ ~ ~y~90 KM/H~b~ yerleşim alanı dışında ~");
                Main.SendCustomChatMessasge(Client, "~b~ ~ ~y~130 KM/H~b~ otoyolda ~");
                Main.SendCustomChatMessasge(Client, "~b~ ~ Yerleşim alanları şunlardır: Los Santos, Paleto Bay, Sandy Shores ~");


                NAPI.Entity.SetEntityPosition(Client, new Vector3(-878.0559, -2081.562, 8.800645));

                int tutorial_steps = 0;
                school_tutorial_timer[Main.getIdFromClient(Client)] = TimerEx.SetTimer(() =>
                {
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_LIGHTGREEN + "-----------------------------------------------");
                    tutorial_steps++;

                    switch (tutorial_steps)
                    {
                        case 1:
                            {
                                NAPI.Entity.SetEntityPosition(Client, new Vector3(79.85892, -1369.071, 29.3313));
                                Client.TriggerEvent("ShowDMVCamera", 2);
                                Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_VIP + " Trafik Kuralları ");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ ~r~Kırmızı ışık~b~ trafik ışığında ~r~STOP işareti~b~ olarak kabul edilmelidir. ~");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ ~g~Yeşil ışık~b~ trafik ışığında ~g~geçiş serbest~b~ olarak kabul edilir. ~");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ Sağdan gelen araçlar, geçiş üstünlüğüne sahiptir ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ Kavşakta trafik düzenlemede önceliği ~b~giyimli polis memuru~b~ alır. ~");
                                break;
                            }
                        case 2:
                            {
                                NAPI.Entity.SetEntityPosition(Client, new Vector3(-99.26994, -1178.103, 26.44629));
                                Client.TriggerEvent("ShowDMVCamera", 3);
                                Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_VIP + " Yolda İşaretler");
                                Main.SendCustomChatMessasge(Client, "~b~ Yolda yer alan işaretlere uymanız zorunludur ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ Sarı renkte boyalı kaldırım bölümü, sadece yük taşıyan araçların park edebileceği yerleri gösterir. ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ Kırmızı renkte boyalı kaldırım bölümü, motorlu araçların park etmesinin ve durmasının yasak olduğu alanları belirtir ~b~ ~");
                                break;
                            }
                        case 3:
                            {
                                NAPI.Entity.SetEntityPosition(Client, new Vector3(95.80418, -1043.833, 29.43804));
                                Client.TriggerEvent("ShowDMVCamera", 4);
                                Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_VIP + " Park Etme");
                                Main.SendCustomChatMessasge(Client, "~b~ Yanlış park edilmiş araçlar ~r~el konulacaktır~b~ ve ceza ödenene kadar serbest bırakılmayacaktır ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ Araç, kaldırımda park edilmemelidir, böylece trafik akışını engellememeli, engelli alanlarda park edilmemelidir ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ Aracınız bozulduğunda veya polis sizden durmanızı istediğinde, kaldırım kenarında durabilirsiniz ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ Araçları sadece belirtilen park alanlarında yasal olarak park edebilirsiniz, ~r~DEVLET servislerinin park yerleri hariç~b~ (Polis, ambulans, itfaiye, vb.) ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ Araç ~g~sağ şeritte~w~ park edilebilir, eğer yakınlarda trafik ışığı veya yaya geçidi yoksa ve park etme normal trafik akışını engellemiyorsa ~b~ ~");
                                break;
                            }
                        case 4:
                            {
                                NAPI.Entity.SetEntityPosition(Client, new Vector3(2767.7, 3917.981, 43.52993));
                                Client.TriggerEvent("ShowDMVCamera", 6);
                                Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_VIP + " Uyarı");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ San Andreas Federal Devleti'nde araç kullanırken sadece ~r~SAĞ~b~ şeritte ilerlenir ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ Araç kullanırken, sürücü ve yolcular güvenlik kemerini takmak zorundadır ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ Motosiklet kullanırken, sürücü ve yolcular uygun güvenlik kasklarını takmalıdır ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ Sürücüler, kırmızı ve/veya mavi ışıklı döner lambalar ve/veya sirenleri olan araçlara yol vermek zorundadır ~b~ ~");
                                break;
                            }
                        case 5:
                            {
                                Client.TriggerEvent("ShowDMVCamera", 7);
                                Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "[Sürüş Okulu]", "" + Main.EMBED_WHITE + "Teorik eğitimi başarıyla tamamladınız. Artık B kategorisi için sınav yapabilirsiniz.");
                                try
                                {
                                    school_tutorial_timer[Main.getIdFromClient(Client)].Kill();
                                }
                                catch
                                {

                                }
                                tutorial_steps = 0;

                                NAPI.Entity.SetEntityPosition(Client, new Vector3(-1289.7573, -572.499, 30.573061));
                                Client.TriggerEvent("freezeEx", false);
                                Client.Dimension = 0;

                                Client.SetData<dynamic>("school_tutorial", true);
                                break;
                            }
                    }

                }, 16000, 0);
            }
            else if (selectedIndex == 1)
            {
                if (Client.GetData<dynamic>("character_car_lic") > 0)
                {
                    Main.SendErrorMessage(Client, "Zaten bir ehliyetiniz var.");
                    return;
                }

                if (Main.GetPlayerMoney(Client) < 2000)
                {
                    Main.SendErrorMessage(Client, "Yeterli paranız yok, $2,000 gerekiyor.");
                    return;
                }
                if (Client.GetData<dynamic>("school_in_teste") == 1)
                {
                    return;
                }
                Main.GivePlayerMoney(Client, -1000);
                Client.SetData<dynamic>("character_car_lic", 1);
                Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_WHITE + "[Sürücü Okulu]", "B kategorisi ehliyetini aldınız.");
                Main.SavePlayerInformation(Client);
                return;

                /* school_vehicle[Main.getIdFromClient(Client)] = API.Shared.CreateVehicle(VehicleHash.Dilettante, new Vector3(-908.0166, -2044.831, 9.298999), 226.8814f, 58, 58, "Okul", 255, false, true, 0);
                 Client.SetIntoVehicle(school_vehicle[Main.getIdFromClient(Client)], (int)VehicleSeat.Driver);
                 Main.DisplayRadar(Client, true);

                 Main.SetVehicleFuel(school_vehicle[Main.getIdFromClient(Client)], 100);
                 Client.SetData<dynamic>("school_in_teste", 1);
                 Client.SetData<dynamic>("school_in_stage", 0);

                 Client.SetData<dynamic>("school_in_stages", vehicle_rota.Count);

                 Client.TriggerEvent("CreateRaceCheckpoint", vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position - new Vector3(0, 0, 1.0), vehicle_rota[Client.GetData<dynamic>("school_in_stage") + 1].position);
                 school_checkpoint[Main.getIdFromClient(Client)] = NAPI.ColShape.CreateCylinderColShape(vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position, 5.0f, 4.0f);
                */
            }
            else if (selectedIndex == 2)
            {
                if (Main.GetPlayerMoney(Client) < 2000)
                {
                    Main.SendErrorMessage(Client, "Yeterli paranız yok, $2,000 gerekiyor");
                    return;
                }

                if (Client.GetData<dynamic>("character_truck_lic") == 1)
                {
                    Main.SendErrorMessage(Client, "Zaten D kategorisi ehliyetiniz var.");
                    return;
                }

                if (Client.GetData<dynamic>("character_car_lic") == 0)
                {
                    Main.SendErrorMessage(Client, "D kategorisi için başvurabilmek için öncelikle B kategorisi ehliyetine sahip olmanız gerekiyor.");
                    return;
                }

                Client.SetData<dynamic>("character_truck_lic", 1);
                Main.GivePlayerMoney(Client, -2000);
                Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_WHITE + "[Sürücü Okulu]", "D kategorisi ehliyetini aldınız.");
            }
        }
    }


    public static void PlayerPressKeyE(Player Client)
    {
        try
        {
            // Eğer oyuncu belirli bir noktaya yakınsa, doğru aşamada ise, araçta ve doğru araç modeline sahipse
            if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-742.5674, -2023.223, 8.899724), 2) && Client.GetData<dynamic>("school_in_stage") == 2 && Client.IsInVehicle && NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)VehicleHash.Dilettante && school_vehicle[Main.getIdFromClient(Client)].Exists && Client.Vehicle == Client.Vehicle)
            {
                // Eğer oyuncu doğru aşamada (2. aşama) ve doğru araçta ise, aşamayı bir artır.
                Client.SetData<dynamic>("school_in_stage", Client.GetData<dynamic>("school_in_stage") + 1);

                // Mevcut yarış kontrol noktasını sil ve yeni kontrol noktasını oluştur
                Client.TriggerEvent("DeleteRaceCheckpoint");
                Client.TriggerEvent("CreateRaceCheckpoint", vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position - new Vector3(0, 0, 1.0), vehicle_rota[Client.GetData<dynamic>("school_in_stage") + 1].position);

                // Eski kontrol noktasını sil
                school_checkpoint[Main.getIdFromClient(Client)].Delete();
                school_checkpoint[Main.getIdFromClient(Client)] = NAPI.ColShape.CreateCylinderColShape(vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position, 5.0f, 4.0f);
            }

            // Eğer oyuncu belirtilen diğer noktada (testin bitişi) doğru aşamadaysa ve araç içindeyse:
            if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-891.7836, -2059.107, 9.300159), 2) && Client.GetData<dynamic>("school_in_stage") == Client.GetData<dynamic>("school_in_stages") - 1 && Client.IsInVehicle && NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)VehicleHash.Dilettante && school_vehicle[Main.getIdFromClient(Client)].Exists && Client.Vehicle == Client.Vehicle)
            {
                // Eğer oyuncunun yeterli parası yoksa, hata mesajı gönder.
                if (Main.GetPlayerMoney(Client) < 1000)
                {
                    Main.SendErrorMessage(Client, "Yeterli paranız yok, $1,000 gerekiyor.");
                    return;
                }

                // Oyuncudan 1000$ kes
                Main.GivePlayerMoney(Client, -1000);

                // Oyuncuya başarı mesajı göster
                Main.DisplaySubtitle(Client, "Başarıyla geçtiniz.");

                // Öğrenci aşamasını sıfırla ve okul aracını kaldır
                Client.SetData<dynamic>("school_in_stage", 0);
                school_checkpoint[Main.getIdFromClient(Client)].Delete();
                Client.TriggerEvent("DeleteRaceCheckpoint");

                // Oyuncuya başarı mesajı göster
                Main.ShowColorShard(Client, "~g~Başarıyla Geçtiniz!", "~w~Artık ehliyetiniz var!", 0, 5, 7000);

                // Oyuncuya ehliyet ver ve bilgileri kaydet
                Client.SetData<dynamic>("character_car_lic", 1);
                Main.SavePlayerInformation(Client);

                // Okul aracını sil
                try
                {
                    school_vehicle[Main.getIdFromClient(Client)].Delete();
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }
            }
        }
        catch (Exception e)
        {
            // Hata durumu
            NAPI.Util.ConsoleOutput("Player press E driver’s licence");
            Console.Write(e);
        }
    }


    public static void OnEnterDynamicArea(Player Client, ColShape area)
    {
        try
        {
            // Eğer oyuncu, belirtilen kontrol noktası (school_checkpoint) içinde, doğru aşamada (school_in_stage == 2), test aşamasında (school_in_teste == 1),
            // araçta ve doğru araç modeline sahip (Dilettante modeli) ve okul aracı (school_vehicle) varsa:
            if (school_checkpoint[Main.getIdFromClient(Client)] == area && Client.GetData<dynamic>("school_in_stage") == 2 && Client.GetData<dynamic>("school_in_teste") == 1 && Client.IsInVehicle && NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)VehicleHash.Dilettante && school_vehicle[Main.getIdFromClient(Client)].Exists)
            {
                // Oyuncuya mesaj gönder: "Aracınızı düzgün şekilde park etmelisiniz."
                // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Aracınızı düzgün şekilde park etmelisiniz.");
            }

            // Eğer oyuncu belirtilen kontrol noktasına (school_checkpoint) girmişse ve:
            // - Aşama 2 değilse (school_in_stage != 2),
            // - Testte ise (school_in_teste == 1),
            // - Araçta ise ve doğru araç modelinde ise (Dilettante),
            // - Okul aracı (school_vehicle) varsa:
            if (school_checkpoint[Main.getIdFromClient(Client)] == area && Client.GetData<dynamic>("school_in_stage") != 2 && Client.GetData<dynamic>("school_in_teste") == 1 && Client.IsInVehicle && NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)VehicleHash.Dilettante && school_vehicle[Main.getIdFromClient(Client)].Exists)
            {
                // Eğer oyuncu son aşamadaysa (son test aşaması), park etmesi gerektiğini bildir
                if (Client.GetData<dynamic>("school_in_stage") == Client.GetData<dynamic>("school_in_stages") - 1)
                {
                    // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Aracınızı düzgün şekilde park etmelisiniz.");
                }
                else
                {
                    // Eğer "stop" mesajı varsa, oyuncuya durması gerektiğini söyle
                    if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "stop")
                    {
                        // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Stop çizgisine gelince durmalısınız.");
                    }
                    // Eğer "ro be jolo" mesajı varsa, devam etmesini söyle
                    else if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "ro be jolo")
                    {
                        // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Devam edin.");
                    }
                    // Eğer "amade_rast" mesajı varsa, sağa dönmeye hazırlansın
                    else if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "amade_rast")
                    {
                        // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Hızınızı düşürün ve sağa dönmeye hazırlanın.");
                    }
                    // Eğer "amade_chap" mesajı varsa, sola dönmeye hazırlansın
                    else if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "amade_chap")
                    {
                        // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Hızınızı düşürün ve sola dönmeye hazırlanın.");
                    }
                    // Eğer "chap" mesajı varsa, sola dönmesi gerektiğini bildir
                    else if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "chap")
                    {
                        // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Sola dönün.");
                    }
                    // Eğer "rast" mesajı varsa, sağa dönmesi gerektiğini bildir
                    else if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "rast")
                    {
                        // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Sağa dönün.");
                    }
                    // Eğer "amade_Baraye_park" mesajı varsa, park etmeye hazırlansın
                    else if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "amade_Baraye_park")
                    {
                        // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Hızınızı düşürün ve sağdaki park yerine girin.");
                    }

                    // Eğer aşama 5'e geldiyse (testin son aşaması), aracı durdur ve dondur
                    if (Client.GetData<dynamic>("school_in_stage") == 5)
                    {
                        Client.TriggerEvent("StopVehicle");
                        Client.TriggerEvent("freezeVehicle", true);

                        // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Stop çizgisinin önünde durmayı unutmayın!");

                        NAPI.Task.Run(() =>
                        {
                            if (NAPI.Player.IsPlayerConnected(Client))
                            {
                                // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Sağa dönün.");
                                Client.TriggerEvent("freezeVehicle", false);
                            }
                        }, delayTime: 3000); // 3 saniye sonra aracı serbest bırak
                    }

                    // Oyuncuya bir sonraki aşama mesajını göster
                    Main.DisplaySubtitle(Client, "Tabii ki, şu anda " + Client.GetData<dynamic>("school_in_stage") + " aşamasındasınız, bir sonraki aşama: " + (Client.GetData<dynamic>("school_in_stage") + 1) + ".");
                    // Aşamayı bir artır
                    Client.SetData<dynamic>("school_in_stage", Client.GetData<dynamic>("school_in_stage") + 1);
                    // Yarış kontrol noktasını sil
                    Client.TriggerEvent("DeleteRaceCheckpoint");

                    // Eğer oyuncu son aşamada ise, yeni yarış kontrol noktasını oluştur
                    if (Client.GetData<dynamic>("school_in_stage") + 1 == Client.GetData<dynamic>("school_in_stages"))
                    {
                        Client.TriggerEvent("CreateRaceCheckpoint", vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position - new Vector3(0, 0, 1.0), vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position);
                    }
                    else
                    {
                        // Diğer kontrol noktası için yeni yarış kontrol noktası oluştur
                        Client.TriggerEvent("CreateRaceCheckpoint", vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position - new Vector3(0, 0, 1.0), vehicle_rota[Client.GetData<dynamic>("school_in_stage") + 1].position);
                    }

                    // Eski kontrol noktasını sil
                    school_checkpoint[Main.getIdFromClient(Client)].Delete();
                    // Yeni kontrol noktasını oluştur
                    school_checkpoint[Main.getIdFromClient(Client)] = NAPI.ColShape.CreateCylinderColShape(vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position, 5.0f, 4.0f);
                }
            }
        }
        catch (Exception e)
        {
            // Hata durumunda konsola mesaj yazdır
            Console.Write(e);
        }
    }




}

