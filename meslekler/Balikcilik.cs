using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using GTANetworkAPI;

namespace Infinity.meslekler
{
    internal class Balikcilik : Script
    {
        public const int KUCUK_GEREKENLEVEL = 1;
        public const int ORTA_GEREKENLEVEL = 2;
        public const int BUYUK_GEREKENLEVEL = 3;

        public const int OLTA_DEFAULT = 92;
        public const int OLTA_KUCUK = 93;
        public const int OLTA_ORTA = 94;
        public const int OLTA_BUYUK = 95;

        public const int YEM_YOK = 0;
        public const int YEM_KURT = 82;
        public const int YEM_SOLUCAN = 83;
        public const int YEM_EKMEK = 84;
        public const int YEM_BALIKPARCASI = 85;
        public const int YEM_KARIDES = 86;
        public const int YEM_RAPALA = 87;
        public const int YEM_JIG = 88;
        public const int YEM_BUYUKBALIK = 89;
        public const int YEM_KALAMAR = 90;
        public const int YEM_SAHTEKALAMAR = 91;

        public const int BALIK_SAZAN = 96;
        public const int BALIK_KEDIBALIGI = 97;
        public const int BALIK_LEVREK = 98;
        public const int BALIK_GUNESBALIGI = 99;
        public const int BALIK_YILANBALIGI = 100;

        public const int BALIK_USKUMRU = 101;
        public const int BALIK_PALAMUT = 102;
        public const int BALIK_KAYABALIGI = 103;
        public const int BALIK_BARAKUDA = 104;
        public const int BALIK_LUFER = 105;

        public const int BALIK_MERCANBALIGI = 106;
        public const int BALIK_SNAPPER = 107;
        public const int BALIK_KUCUKORKINOS = 108;
        public const int BALIK_AKYA = 109;
        public const int BALIK_KILICBALIGI = 110;

        public const int BALIK_MAHIMAHI = 111;
        public const int BALIK_BUYUKTONBALIGI = 112;
        public const int BALIK_MORINA = 113;
        public const int BALIK_ORTAMAVIMARLIN = 114;
        public const int BALIK_ORTAKILICBALIGI = 115;

        public const double SAZAN_MIN_ORAN = 0.5;
        public const double SAZAN_MAX_ORAN = 2;
        public const double KEDIBALIGI_MIN_ORAN = 0.3;
        public const double KEDIBALIGI_MAX_ORAN = 1.5;
        public const double LEVREK_MIN_ORAN = 0.4;
        public const double LEVREK_MAX_ORAN = 1.8;
        public const double GUNESBALIGI_MIN_ORAN = 0.1;
        public const double GUNESBALIGI_MAX_ORAN = 0.5;
        public const double YILANBALIGI_MIN_ORAN = 0.8;
        public const double YILANBALIGI_MAX_ORAN = 2.5;

        public const double USKUMRU_MIN_ORAN = 0.5;
        public const double USKUMRU_MAX_ORAN = 2;
        public const double PALAMUT_MIN_ORAN = 1;
        public const double PALAMUT_MAX_ORAN = 3;
        public const double KAYABALIGI_MIN_ORAN = 0.3;
        public const double KAYABALIGI_MAX_ORAN = 2.5;
        public const double BARAKUDA_MIN_ORAN = 1.5;
        public const double BARAKUDA_MAX_ORAN = 4;
        public const double LUFER_MIN_ORAN = 2;
        public const double LUFER_MAX_ORAN = 5;

        public const double MERCANBALIGI_MIN_ORAN = 3;
        public const double MERCANBALIGI_MAX_ORAN = 8;
        public const double SNAPPER_MIN_ORAN = 2;
        public const double SNAPPER_MAX_ORAN = 7;
        public const double KUCUKORKINOS_MIN_ORAN = 5;
        public const double KUCUKORKINOS_MAX_ORAN = 15;
        public const double AKYA_MIN_ORAN = 10;
        public const double AKYA_MAX_ORAN = 25;
        public const double KILICBALIGI_MIN_ORAN = 8;
        public const double KILICBALIGI_MAX_ORAN = 20;

        public const double MAHIMAHI_MIN_ORAN = 15;
        public const double MAHIMAHI_MAX_ORAN = 30;
        public const double BUYUKTONBALIGI_MIN_ORAN = 20;
        public const double BUYUKTONBALIGI_MAX_ORAN = 50;
        public const double MORINA_MIN_ORAN = 25;
        public const double MORINA_MAX_ORAN = 60;
        public const double ORTAMAVIMARLIN_MIN_ORAN = 30;
        public const double ORTAMAVIMARLIN_MAX_ORAN = 70;
        public const double ORTAKILICBALIGI_MIN_ORAN = 40;
        public const double ORTAKILICBALIGI_MAX_ORAN = 90;

        public const int LEVEL_2_GEREKEN_EXP = 120;
        public const int LEVEL_3_GEREKEN_EXP = 310;
        public const int LEVEL_4_GEREKEN_EXP = 580;
        public const int LEVEL_5_GEREKEN_EXP = 700;
        public const int LEVEL_6_GEREKEN_EXP = 940;


        [Command("testkomut")]
        public static void TestKomut(Player player)
        {
            Inventory.GiveItemToInventory(player, BALIK_MAHIMAHI, 1, 1, 0, -1, true, 0.4);
            Inventory.GiveItemToInventory(player, BALIK_BUYUKTONBALIGI, 10, 1, 0, -1, true, 0.4);
            Inventory.GiveItemToInventory(player, BALIK_MORINA, 10, 1, 0, -1, true, 0.4);
            Inventory.GiveItemToInventory(player, BALIK_ORTAMAVIMARLIN, 10, 1, 0, -1, true, 0.4);
            Inventory.GiveItemToInventory(player, BALIK_ORTAKILICBALIGI, 10, 1, 0, -1, true, 0.4); 
        }

        /*
            Karides
            Rapala
            Jig
            Büyük Balık
            Kalamar
            Sahte Kalamar
        */

        public static int YemKontrol(Player player)
        {
            int totalyem = 0;
            int ekmek = Inventory.GetItemCount(player, "Ekmek");
            int kurt = Inventory.GetItemCount(player, "Kurt");
            int solucan = Inventory.GetItemCount(player, "Solucan");
            int balikparcasi = Inventory.GetItemCount(player, "Balık Parçası");
            int karides = Inventory.GetItemCount(player, "Karides");
            int rapala = Inventory.GetItemCount(player, "Rapala");
            int jig = Inventory.GetItemCount(player, "Jig");
            int buyukbalik = Inventory.GetItemCount(player, "Büyük Balık");
            int kalamar = Inventory.GetItemCount(player, "Kalamar");
            int sahtekalamar = Inventory.GetItemCount(player, "Sahte Kalamar");


            if (player.GetData<int>("Olta") == OLTA_DEFAULT)
            {
                if (ekmek >= 1)
                {
                    totalyem += ekmek;
                }
                if (solucan >= 1)
                {
                    totalyem += solucan;
                }
            }
            else if (player.GetData<int>("Olta") == OLTA_KUCUK)
            {
                if (ekmek >= 1)
                {
                    totalyem += ekmek;
                }
                if (solucan >= 1)
                {
                    totalyem += solucan;
                }
                if (karides >= 1)
                {
                    totalyem += karides;
                }
                if (balikparcasi >= 1)
                {
                    totalyem += balikparcasi;
                }
                if (rapala >= 1)
                {
                    totalyem += rapala;
                }
            }
            else if (player.GetData<int>("Olta") == OLTA_ORTA)
            {
                if (ekmek >= 1)
                {
                    totalyem += ekmek;
                }
                if (solucan >= 1)
                {
                    totalyem += solucan;
                }
                if (karides >= 1)
                {
                    totalyem += karides;
                }
                if (balikparcasi >= 1)
                {
                    totalyem += balikparcasi;
                }
                if (rapala >= 1)
                {
                    totalyem += rapala;
                }
                if (jig >= 1)
                {
                    totalyem += jig;
                }
                if (sahtekalamar >= 1)
                {
                    totalyem += sahtekalamar;
                }
            }
            else if (player.GetData<int>("Olta") == OLTA_BUYUK)
            {
                if (ekmek >= 1)
                {
                    totalyem += ekmek;
                }
                if (solucan >= 1)
                {
                    totalyem += solucan;
                }
                if (karides >= 1)
                {
                    totalyem += karides;
                }
                if (balikparcasi >= 1)
                {
                    totalyem += balikparcasi;
                }
                if (rapala >= 1)
                {
                    totalyem += rapala;
                }
                if (jig >= 1)
                {
                    totalyem += jig;
                }
                if (buyukbalik >= 1)
                {
                    totalyem += buyukbalik;
                }
                if (kalamar >= 1)
                {
                    totalyem += kalamar;
                }
                if (kurt >= 1)
                {
                    totalyem += kurt;
                }
            }
            return totalyem;
        }

        public static bool YemUygunluk(Player player, string yem)
        {
            int olta = player.GetData<int>("Olta");
            if (olta == OLTA_DEFAULT)
            {
                if (yem == "Ekmek" || yem == "Solucan") return true;
                else return false;
            }
            else if (olta == OLTA_KUCUK)
            {
                if (yem == "Ekmek" || yem == "Solucan" || yem == "Karides" || yem == "Rapala" || yem == "Balık Parçası") return true;
                else return false;
            }
            else if (olta == OLTA_ORTA)
            {
                if (yem == "Ekmek" || yem == "Solucan" || yem == "Karides" || yem == "Rapala" || yem == "Balık Parçası" || yem == "Jig" || yem == "Sahte Kalamar") return true;
                else return false;
            }
            else if (olta == OLTA_BUYUK)
            {
                if (yem == "Ekmek" || yem == "Solucan" || yem == "Karides" || yem == "Rapala" || yem == "Balık Parçası" || yem == "Jig" || yem == "Sahte Kalamar" || yem == "Büyük Balık" || yem == "Kalamar" || yem == "Kurt") return true;
                else return false;
            }
            return false;
        }

        public static double SansFaktoru(Player player)
        {
            double sans = 55.0;

            if (player.GetData<int>("Olta") == OLTA_BUYUK)
            {
                sans = 62.5;

                if (Polygon.BalikLimitKontrol(player))
                {
                    sans -= 25.0;
                }
                return sans;
                
            }

            if (player.GetData<int>("Olta") == OLTA_ORTA)
            {
                sans = 60;

                if (Polygon.BalikLimitKontrol(player))
                {
                    sans -= 25.0;
                }
                return sans;
                
            }

            if (player.GetData<int>("Olta") == OLTA_KUCUK)
            {
                sans = 57.5;

                if (Polygon.BalikLimitKontrol(player))
                {
                    sans -= 25.0;
                }
                return sans;
                
            }

            if (player.GetData<int>("Olta") == OLTA_DEFAULT)
            {
                sans = 55;

                if (Polygon.BalikLimitKontrol(player))
                {
                    sans -= 25.0;
                }
                return sans;
                
            }

            return sans;
        }

        public static void OltaKullan(Player player, int olta)
        {
            if (player.GetData<dynamic>("playerCuffed") != 0 || player.GetSharedData<dynamic>("Injured") >= 1)
            {
                Main.SendErrorMessage(player, "Kelepçeliyken/yaralıyken olta kullanamazsınız.");
                return;
            }

            if (olta == OLTA_DEFAULT) Main.SendServerMessage(player, "Başarıyla oltayı kullanmaya başladınız.");
            if (olta == OLTA_KUCUK) Main.SendServerMessage(player, "Başarıyla küçük oltayı kullanmaya başladınız.");
            if (olta == OLTA_ORTA) Main.SendServerMessage(player, "Başarıyla orta oltayı kullanmaya başladınız.");
            if (olta == OLTA_BUYUK) Main.SendServerMessage(player, "Başarıyla büyük oltayı kullanmaya başladınız.");

            player.SetData("Olta", olta);
        }

        public static string YemAdiCek(int yem)
        {
            string isim = "";
            switch (yem)
            {
                case YEM_KURT:
                    {
                        isim = "Kurt";
                        break;
                    }
                case YEM_SOLUCAN:
                    {
                        isim = "Solucan";
                        break;
                    }
                case YEM_EKMEK:
                    {
                        isim = "Ekmek";
                        break;
                    }
                case YEM_BALIKPARCASI:
                    {
                        isim = "Balık Parçası";
                        break;
                    }
                case YEM_KARIDES:
                    {
                        isim = "Karides";
                        break;
                    }
                case YEM_RAPALA:
                    {
                        isim = "Rapala";
                        break;
                    }
                case YEM_JIG:
                    {
                        isim = "Jig";
                        break;
                    }
                case YEM_BUYUKBALIK:
                    {
                        isim = "Büyük Balık";
                        break;
                    }
                case YEM_KALAMAR:
                    {
                        isim = "Kalamar";
                        break;
                    }
                case YEM_SAHTEKALAMAR:
                    {
                        isim = "Sahte Kalamar";
                        break;
                    }
            }
            return isim;
        }
        public static void YemKullan(Player player, int yem)
        {
            if (player.GetData<dynamic>("playerCuffed") != 0 || player.GetSharedData<dynamic>("Injured") >= 1)
            {
                Main.SendErrorMessage(player, "Kelepçeliyken/yaralıyken yem kullanamazsınız.");
                return;
            }

            if (player.GetData<int>("Olta") != OLTA_DEFAULT && player.GetData<int>("Olta") != OLTA_KUCUK && player.GetData<int>("Olta") != OLTA_ORTA && player.GetData<int>("Olta") != OLTA_BUYUK)
            {
                Main.SendErrorMessage(player, "Elinizde olta yok.");
                return;
            }

            if (YemUygunluk(player, YemAdiCek(yem)) == false)
            {
                Main.SendErrorMessage(player, "Seçmek istediğiniz yem, elinizdeki oltaya uygun değil.");
                return;
            }

            Main.SendServerMessage(player, "Başarıyla '" + YemAdiCek(yem) + "' adlı yemi kullanmaya başladınız.");
            player.SetData("SecilenYem", yem);
        }

        [Command("baliklevelduzenle", "~y~[!]~w~: /baliklevelduzenle [İsim/ID] [Level]")]
        public static void BalikLevelDuzenle(Player player, string isimid, int level)
        {
            if (player.GetData<dynamic>("admin_duty") == 0)
            {
                Main.SendErrorMessage(player, "Bu komutu kullanabilmek için iş başında olmalısınız, /aduty komutu ile iş başına geçebilirsiniz.");
                return;
            }
            if (AccountManage.GetPlayerAdmin(player) <= 7)
            {
                return;
            }

            if (level < 1 || level > 5)
            {
                Main.SendErrorMessage(player, "Level 1-5 arasında olmalıdır!");
                return;
            }

            Player target = Main.findPlayer(player, isimid);
            if (target != null)
            {
                Main.SendSuccessMessage(player, AccountManage.GetCharacterName(target) + " adlı oyuncunun balıkçılık seviyesi " + level + " olarak düzenlendi!");
                Main.SendSuccessMessage(target, AccountManage.GetCharacterName(player) + " adlı yetkili tarafından balıkçılık seviyeniz " + level + " olarak düzenlendi!");
                target.SetData("BalikLevel", level);
            }
        }

        [Command("baliktut")]
        public static void BalikTut(Player player)
        {
            if (player.GetData<int>("Olta") != OLTA_DEFAULT && player.GetData<int>("Olta") != OLTA_KUCUK && player.GetData<int>("Olta") != OLTA_ORTA && player.GetData<int>("Olta") != OLTA_BUYUK)
            {
                Main.SendErrorMessage(player, "Elinizde olta yok.");
                return;
            }

            if (player.GetData<int>("SecilenYem") == YEM_YOK)
            {
                Main.SendErrorMessage(player, "Herhangi bir yem kullanmıyorsunuz.");
                return;
            }

            if (YemUygunluk(player, YemAdiCek(player.GetData<int>("SecilenYem"))) == false)
            {
                Main.SendErrorMessage(player, "Seçtiğiniz yem, elinizdeki oltaya uygun değil.");
                return;
            }

            if (Polygon.BolgeKontrol(player) != Polygon.ZoneType.Balıkçılık)
            {
                Main.SendErrorMessage(player, "Burada balık tutamazsınız.");
                return;
            }

            if (Polygon.BolgeLevel(player) > player.GetData<int>("BalikLevel"))
            {
                Main.SendErrorMessage(player, "Burada balık tutmak için en az " + Polygon.BolgeLevel(player) + " balıkçılık seviyesine sahip olmalısınız.");
                return;
            }

            player.SetData("BalikTutuyor", true);
            NAPI.ClientEvent.TriggerClientEvent(player, "client:BalikBrowser");
        }

        [RemoteEvent("server:BalikOyunBitti")]
        public static void BalikOyunBitti(Player player, bool status)
        {
            Inventory.RemoveItem(player, YemAdiCek(player.GetData<int>("SecilenYem")), 1);
            if (Inventory.GetItemCount(player, YemAdiCek(player.GetData<int>("SecilenYem"))) <= 0)
            {
                player.SetData("SecilenYem", YEM_YOK);
                Main.SendErrorMessage(player, "Yeminiz bitti.");
            }

            if (player.GetData<bool>("BalikTutuyor") == false)
            {
                Main.CreateMySqlCommand("UPDATE `users` SET `isban` = '1' ,banreason='Hile Kullanımı', passq='01.01.2090',bannedby='Sistem' WHERE socialclubname='" + player.SocialClubName + "';");
                Main.SendCustomChatToAll("~r~ADM: " + AccountManage.GetCharacterName(player) + " adlı oyuncu, Sistem tarafından 'Hile Kullanımı' sebebiyle sunucudan yasaklandı!");
                player.Kick();
                return;
            }

            if (status)
            {
                player.SetData("BalikTutuyor", false);
                double sans = SansFaktoru(player);
                if (SansIseYaradimi(sans))
                {
                    BalikTutuldu(player);
                }
                else
                {
                    Main.SendErrorMessage(player, "Oltaya balık gelmedi.");
                }
            }
        }

        public static void BalikTutuldu(Player player)
        {
            switch (player.GetData<int>("Olta"))
            {
                case OLTA_DEFAULT:
                    {
                        Random random = new Random();
                        int roll = random.Next(0, 100);

                        if (roll >= 0 && roll <= 34)
                        {
                            double kilo = GetRandomNumber(SAZAN_MIN_ORAN, SAZAN_MAX_ORAN); 
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_SAZAN, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_SAZAN, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Sazan' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 35 && roll <= 64)
                        {
                            double kilo = GetRandomNumber(KEDIBALIGI_MIN_ORAN, KEDIBALIGI_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);
                            
                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_KEDIBALIGI, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_KEDIBALIGI, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Kedi Balığı' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 65 && roll <= 84)
                        {
                            double kilo = GetRandomNumber(LEVREK_MIN_ORAN, LEVREK_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);
         
                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_LEVREK, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_LEVREK, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Levrek' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 85 && roll <= 94)
                        {
                            double kilo = GetRandomNumber(GUNESBALIGI_MIN_ORAN, GUNESBALIGI_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);
                           
                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_GUNESBALIGI, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_GUNESBALIGI, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Güneş Balığı' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 95 && roll <= 99)
                        {
                            double kilo = GetRandomNumber(YILANBALIGI_MIN_ORAN, YILANBALIGI_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);
                           
                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_YILANBALIGI, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_YILANBALIGI, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Yılanbalığı' balığı tuttunuz. Kilo: " + kilo);
                        }
                        break;
                    }
                case OLTA_KUCUK:
                    {

                        Random random = new Random();
                        int roll = random.Next(0, 100);

                        if (roll >= 0 && roll <= 34)
                        {
                            double kilo = GetRandomNumber(USKUMRU_MIN_ORAN, USKUMRU_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_USKUMRU, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_USKUMRU, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Uskumru' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 35 && roll <= 64)
                        {
                            double kilo = GetRandomNumber(PALAMUT_MIN_ORAN, PALAMUT_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_PALAMUT, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_PALAMUT, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Palamut' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 65 && roll <= 84)
                        {
                            double kilo = GetRandomNumber(KAYABALIGI_MIN_ORAN, KAYABALIGI_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_KAYABALIGI, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_KAYABALIGI, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Kaya Balığı' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 85 && roll <= 94)
                        {
                            double kilo = GetRandomNumber(BARAKUDA_MIN_ORAN, BARAKUDA_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_BARAKUDA, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_BARAKUDA, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Baraküda' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 95 && roll <= 99)
                        {
                            double kilo = GetRandomNumber(LUFER_MIN_ORAN, LUFER_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_LUFER, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_LUFER, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Lüfer' balığı tuttunuz. Kilo: " + kilo);
                        }
                        break;
                    }
                case OLTA_ORTA:
                    {
                        Random random = new Random();
                        int roll = random.Next(0, 100);

                        if (roll >= 0 && roll <= 34)
                        {
                            double kilo = GetRandomNumber(MERCANBALIGI_MIN_ORAN, MERCANBALIGI_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_MERCANBALIGI, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_MERCANBALIGI, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Mercan Balığı' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 35 && roll <= 64)
                        {
                            double kilo = GetRandomNumber(SNAPPER_MIN_ORAN, SNAPPER_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_SNAPPER, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_SNAPPER, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Snapper' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 65 && roll <= 84)
                        {
                            double kilo = GetRandomNumber(KUCUKORKINOS_MIN_ORAN, KUCUKORKINOS_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_KUCUKORKINOS, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_KUCUKORKINOS, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Küçük Orkinos' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 85 && roll <= 94)
                        {
                            double kilo = GetRandomNumber(AKYA_MIN_ORAN, AKYA_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_AKYA, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_AKYA, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Akya' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 95 && roll <= 99)
                        {
                            double kilo = GetRandomNumber(KILICBALIGI_MIN_ORAN, KILICBALIGI_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_KILICBALIGI, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_KILICBALIGI, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Kılıç Balığı' balığı tuttunuz. Kilo: " + kilo);
                        }
                        break;
                    }
                case OLTA_BUYUK:
                    {
                        Random random = new Random();
                        int roll = random.Next(0, 100);

                        if (roll >= 0 && roll <= 34)
                        {
                            double kilo = GetRandomNumber(MAHIMAHI_MIN_ORAN, MAHIMAHI_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_MAHIMAHI, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_MAHIMAHI, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Mahi Mahi' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 35 && roll <= 64)
                        {
                            double kilo = GetRandomNumber(BUYUKTONBALIGI_MIN_ORAN, BUYUKTONBALIGI_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_BUYUKTONBALIGI, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_BUYUKTONBALIGI, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Ton Balığı (Büyük)' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 65 && roll <= 84)
                        {
                            double kilo = GetRandomNumber(MORINA_MIN_ORAN, MORINA_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_MORINA, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_MORINA, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Morina' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 85 && roll <= 94)
                        {
                            double kilo = GetRandomNumber(ORTAMAVIMARLIN_MIN_ORAN, ORTAMAVIMARLIN_MAX_ORAN);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_ORTAMAVIMARLIN, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_ORTAMAVIMARLIN, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Mavi Marlin (Orta)' balığı tuttunuz. Kilo: " + kilo);
                        }
                        else if (roll >= 95 && roll <= 99)
                        {
                            double kilo = GetRandomNumber(40, 90);
                            kilo = Math.Round(kilo, 2);

                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, BALIK_ORTAKILICBALIGI, 1, Inventory.Max_Inventory_Weight(player), true, kilo))
                            {
                                return;
                            }

                            Inventory.GiveItemToInventory(player, BALIK_ORTAKILICBALIGI, 1, 1, 0, -1, true, kilo);
                            Main.SendServerMessage(player, "'Kılıç Balığı (Orta)' balığı tuttunuz. Kilo: " + kilo);
                        }
                        break;
                    }
            }
        }

        [Command("exptest")]
        public static void EXPTest(Player player, int exp)
        {
            int mevcut = player.GetData<int>("BalikEXP");
            player.SetData("BalikEXP", mevcut += exp);
            Main.SendServerMessage(player, "EXP Test: " + player.GetData<int>("BalikEXP"));
            BalikPayday(player);
        }

        public static void BalikPayday(Player player)
        {
            int exp = player.GetData<int>("BalikEXP");
            int level = player.GetData<int>("BalikLevel");

            int artacakexp;
            artacakexp = 1;

            player.SetData("BalikEXP", exp += artacakexp);
            Main.SendServerMessage(player, "EXP Miktarınız: " + player.GetData<int>("BalikEXP"));

            switch (player.GetData<int>("BalikLevel"))
            {
                case 1:
                    {
                        if (player.GetData<int>("BalikEXP") >= LEVEL_2_GEREKEN_EXP)
                        {
                            int leveldeks = player.GetData<int>("BalikLevel");
                            player.SetData("BalikLevel", leveldeks += 1);
                            player.SetData("BalikEXP", 0);
                            Main.SendServerMessage(player, "Balıkçılık seviyeniz artarak '" + player.GetData<int>("BalikLevel") + "' oldu.");
                            Main.SendServerMessage(player, "Yeni seviye için " + LEVEL_3_GEREKEN_EXP + " EXP kazanmanız gerekmekte.");
                        }
                        break;
                    }
                case 2:
                    {
                        if (player.GetData<int>("BalikEXP") >= LEVEL_3_GEREKEN_EXP)
                        {
                            int leveldeks = player.GetData<int>("BalikLevel");
                            player.SetData("BalikLevel", leveldeks += 1);
                            player.SetData("BalikEXP", 0);
                            Main.SendServerMessage(player, "Balıkçılık seviyeniz artarak '" + player.GetData<int>("BalikLevel") + "' oldu.");
                            Main.SendServerMessage(player, "Yeni seviye için " + LEVEL_4_GEREKEN_EXP + " EXP kazanmanız gerekmekte.");
                        }
                        break;
                    }
                case 3:
                    {
                        if (player.GetData<int>("BalikEXP") >= LEVEL_4_GEREKEN_EXP)
                        {
                            int leveldeks = player.GetData<int>("BalikLevel");
                            player.SetData("BalikLevel", leveldeks += 1);
                            player.SetData("BalikEXP", 0);
                            Main.SendServerMessage(player, "Balıkçılık seviyeniz artarak '" + player.GetData<int>("BalikLevel") + "' oldu.");
                            Main.SendServerMessage(player, "Yeni seviye için " + LEVEL_5_GEREKEN_EXP + " EXP kazanmanız gerekmekte.");
                        }
                        break;
                    }
                case 4:
                    {
                        if (player.GetData<int>("BalikEXP") >= LEVEL_5_GEREKEN_EXP)
                        {
                            int leveldeks = player.GetData<int>("BalikLevel");
                            player.SetData("BalikLevel", leveldeks += 1);
                            player.SetData("BalikEXP", 0);
                            Main.SendServerMessage(player, "Balıkçılık seviyeniz artarak '" + player.GetData<int>("BalikLevel") + "' oldu.");
                            Main.SendServerMessage(player, "Yeni seviye için " + LEVEL_6_GEREKEN_EXP + " EXP kazanmanız gerekmekte.");
                        }
                        break;
                    }
            }
        }

        static Random random = new Random();
        static bool SansIseYaradimi(double chance)
        {
            double roll = random.NextDouble() * 100;
            return roll <= chance;
        }

        static Random randomDouble = new Random();
        static double GetRandomNumber(double minimum, double maximum)
        {
            return randomDouble.NextDouble() * (maximum - minimum) + minimum;
        }

    }
}