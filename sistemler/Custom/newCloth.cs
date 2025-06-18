using GTANetworkAPI;
using System.Collections.Generic;
using System.Threading.Tasks;

public class newCloth : Script
{
    class ClothesList_Structer
    {
        public int clothe_gender;
        public int id;
        public string clothe_class;
        public int clothe_Id;
        public int price;
        public int clothe_Texture;
    }


    static List<ClothesList_Structer> clothes_list = new List<ClothesList_Structer>();
    public class MarkerInfo
    {
        public int MarkerType { get; set; }
        public Vector3 Position { get; set; }
        public float Rotation { get; set; }
    }

    public static List<MarkerInfo> kiyafetci = new List<MarkerInfo>();

    public newCloth()
    {
        kiyafetci.Add(new MarkerInfo { MarkerType = 1, Position = new Vector3(-1182.1285, -764.73395, 17.326084), Rotation = 123f });
        kiyafetci.Add(new MarkerInfo { MarkerType = 1, Position = new Vector3(-1182.1285, -764.73395, 17.326084), Rotation = 169f });
        foreach (var atm in kiyafetci)
        {
            NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( Kiyafet Dukkani ))~n~" + Main.LabelCommandColor + "« Y »", atm.Position, 16, 0.600f, 0, new Color(0, 122, 255, 150));

            Entity temp_blip;
            temp_blip = NAPI.Blip.CreateBlip(atm.Position);
            NAPI.Blip.SetBlipName(temp_blip, "Kıyafet Dükkanı");
            NAPI.Blip.SetBlipSprite(temp_blip, 628);
            NAPI.Blip.SetBlipColor(temp_blip, 25);
            NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);
        }


        System.Random rnd = new System.Random();


        //Female

        //Torso
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 3, clothe_class = "Gövde", clothe_Id = 204, clothe_Texture = 0, price = rnd.Next(55, 90) });

        ///Top
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 0, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 1, clothe_Texture = 6, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 2, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 3, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 5, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 6, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 7, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 8, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 9, clothe_Texture = 14, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 10, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 11, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 13, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 14, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 15, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 16, clothe_Texture = 6, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 17, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 18, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 19, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 20, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 21, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 22, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 23, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 24, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 25, clothe_Texture = 10, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 26, clothe_Texture = 12, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 27, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 28, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 29, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 30, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 31, clothe_Texture = 6, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 32, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 33, clothe_Texture = 8, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 34, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 35, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 36, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 37, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 38, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 39, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 40, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 41, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 42, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 43, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 44, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 45, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 46, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 47, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 49, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 50, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 51, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 52, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 53, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 54, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 55, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 56, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 57, clothe_Texture = 8, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 58, clothe_Texture = 8, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 59, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 60, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 61, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 62, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 63, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 64, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 65, clothe_Texture = 10, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 66, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 67, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 68, clothe_Texture = 19, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 69, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 70, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 71, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 72, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 73, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 74, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 75, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 76, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 77, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 78, clothe_Texture = 7, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 79, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 80, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 81, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 83, clothe_Texture = 6, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 84, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 85, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 86, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 87, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 88, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 89, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 90, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 91, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 92, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 93, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 94, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 95, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 96, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 97, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 98, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 99, clothe_Texture = 10, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 100, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 101, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 102, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 103, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 104, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 105, clothe_Texture = 7, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 106, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 108, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 109, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 110, clothe_Texture = 9, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 111, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 112, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 113, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 114, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 115, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 116, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 117, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 118, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 119, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 120, clothe_Texture = 16, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 121, clothe_Texture = 16, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 122, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 123, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 124, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 125, clothe_Texture = 9, price = rnd.Next(55, 90) });

        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 126, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 127, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 128, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 129, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 130, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 131, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 132, clothe_Texture = 6, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 133, clothe_Texture = 9, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 134, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 135, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 136, clothe_Texture = 7, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 137, clothe_Texture = 14, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 138, clothe_Texture = 10, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 139, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 140, clothe_Texture = 9, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 141, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 142, clothe_Texture = 13, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 143, clothe_Texture = 13, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 145, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 146, clothe_Texture = 9, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 147, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 148, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 149, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 150, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 151, clothe_Texture = 7, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 152, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 153, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 154, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 155, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 156, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 157, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 158, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 159, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 160, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 161, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 162, clothe_Texture = 6, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 163, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 164, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 165, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 166, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 167, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 168, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 169, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 170, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 171, clothe_Texture = 7, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 172, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 173, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 181, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 185, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 186, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 187, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 189, clothe_Texture = 12, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 190, clothe_Texture = 10, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 191, clothe_Texture = 10, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 192, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 193, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 194, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 195, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 197, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 198, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 199, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 202, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 204, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 205, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 206, clothe_Texture = 12, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 207, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 208, clothe_Texture = 16, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 209, clothe_Texture = 16, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 210, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 211, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 212, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 213, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 214, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 215, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 216, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 217, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 218, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 219, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 220, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 221, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 222, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 223, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 224, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 225, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 226, clothe_Texture = 23, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 227, clothe_Texture = 14, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 228, clothe_Texture = 14, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 229, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 230, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 231, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 232, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 233, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 234, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 235, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 236, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 239, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 240, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 242, clothe_Texture = 9, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 243, clothe_Texture = 9, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 244, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 245, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 246, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 247, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 248, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 249, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 250, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 251, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 252, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 253, clothe_Texture = 9, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 255, clothe_Texture = 25, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 256, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 257, clothe_Texture = 14, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 258, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 259, clothe_Texture = 4, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 260, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 261, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 262, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 263, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 264, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 265, clothe_Texture = 14, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 266, clothe_Texture = 13, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 267, clothe_Texture = 11, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 270, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 272, clothe_Texture = 6, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 273, clothe_Texture = 0, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 275, clothe_Texture = 3, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 276, clothe_Texture = 1, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 277, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 282, clothe_Texture = 12, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 283, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 284, clothe_Texture = 15, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 285, clothe_Texture = 5, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 286, clothe_Texture = 2, price = rnd.Next(55, 90) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 11, clothe_class = "Vücut", clothe_Id = 287, clothe_Texture = 6, price = rnd.Next(55, 90) });
        ///Tamam Nashode

        //Shoes
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 0, clothe_Texture = 3, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 1, clothe_Texture = 15, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 2, clothe_Texture = 15, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 3, clothe_Texture = 15, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 4, clothe_Texture = 3, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 5, clothe_Texture = 1, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 6, clothe_Texture = 3, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 7, clothe_Texture = 15, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 8, clothe_Texture = 15, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 9, clothe_Texture = 3, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 10, clothe_Texture = 3, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 11, clothe_Texture = 3, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 13, clothe_Texture = 15, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 14, clothe_Texture = 15, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 15, clothe_Texture = 15, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 16, clothe_Texture = 11, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 17, clothe_Texture = 0, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 18, clothe_Texture = 2, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 19, clothe_Texture = 11, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 20, clothe_Texture = 11, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 21, clothe_Texture = 9, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 22, clothe_Texture = 15, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 23, clothe_Texture = 2, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 24, clothe_Texture = 0, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 25, clothe_Texture = 0, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 26, clothe_Texture = 0, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 27, clothe_Texture = 0, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 28, clothe_Texture = 0, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 29, clothe_Texture = 2, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 30, clothe_Texture = 0, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 31, clothe_Texture = 0, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 32, clothe_Texture = 4, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 33, clothe_Texture = 7, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 36, clothe_Texture = 1, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 37, clothe_Texture = 3, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 38, clothe_Texture = 4, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 39, clothe_Texture = 4, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 40, clothe_Texture = 0, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 41, clothe_Texture = 11, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 42, clothe_Texture = 11, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 43, clothe_Texture = 7, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 44, clothe_Texture = 7, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 45, clothe_Texture = 10, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 46, clothe_Texture = 10, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 47, clothe_Texture = 9, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 48, clothe_Texture = 11, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 49, clothe_Texture = 1, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 50, clothe_Texture = 1, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 51, clothe_Texture = 5, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 52, clothe_Texture = 5, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 53, clothe_Texture = 1, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 54, clothe_Texture = 5, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 55, clothe_Texture = 5, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 56, clothe_Texture = 2, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 57, clothe_Texture = 2, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 58, clothe_Texture = 10, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 59, clothe_Texture = 1, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 60, clothe_Texture = 11, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 61, clothe_Texture = 2, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 62, clothe_Texture = 25, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 63, clothe_Texture = 17, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 64, clothe_Texture = 7, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 65, clothe_Texture = 7, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 66, clothe_Texture = 7, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 67, clothe_Texture = 13, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 68, clothe_Texture = 6, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 69, clothe_Texture = 6, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 70, clothe_Texture = 6, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 71, clothe_Texture = 11, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 72, clothe_Texture = 25, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 73, clothe_Texture = 25, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 74, clothe_Texture = 25, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 75, clothe_Texture = 25, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 76, clothe_Texture = 25, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 77, clothe_Texture = 8, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 78, clothe_Texture = 1, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 79, clothe_Texture = 25, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 80, clothe_Texture = 25, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 81, clothe_Texture = 25, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 82, clothe_Texture = 13, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 83, clothe_Texture = 1, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 84, clothe_Texture = 1, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 85, clothe_Texture = 2, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 86, clothe_Texture = 2, price = rnd.Next(190, 280) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 6, clothe_class = "Ayakkabı", clothe_Id = 87, clothe_Texture = 19, price = rnd.Next(190, 280) });


        //Hats
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 0, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 1, clothe_Texture = 0, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 4, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 5, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 6, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 7, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 9, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 12, clothe_Texture = 0, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 13, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 14, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 15, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 20, clothe_Texture = 6, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 21, clothe_Texture = 6, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 22, clothe_Texture = 6, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 23, clothe_Texture = 1, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 26, clothe_Texture = 13, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 27, clothe_Texture = 13, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 28, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 29, clothe_Texture = 4, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 36, clothe_Texture = 5, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 43, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 44, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 53, clothe_Texture = 1, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 54, clothe_Texture = 7, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 55, clothe_Texture = 25, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 56, clothe_Texture = 9, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 58, clothe_Texture = 2, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 61, clothe_Texture = 9, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 63, clothe_Texture = 9, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 64, clothe_Texture = 0, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 65, clothe_Texture = 0, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 75, clothe_Texture = 20, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 82, clothe_Texture = 6, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 93, clothe_Texture = 9, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 94, clothe_Texture = 9, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 95, clothe_Texture = 9, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 101, clothe_Texture = 9, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 102, clothe_Texture = 19, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 103, clothe_Texture = 25, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 104, clothe_Texture = 25, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 105, clothe_Texture = 25, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 106, clothe_Texture = 25, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 107, clothe_Texture = 25, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 108, clothe_Texture = 3, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 109, clothe_Texture = 6, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 119, clothe_Texture = 25, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 129, clothe_Texture = 18, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 130, clothe_Texture = 18, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 131, clothe_Texture = 3, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 134, clothe_Texture = 23, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 135, clothe_Texture = 23, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 141, clothe_Texture = 25, price = rnd.Next(190, 240) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 12, clothe_class = "Şapka", clothe_Id = 142, clothe_Texture = 25, price = rnd.Next(190, 240) });

        //Pants
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 1, clothe_Texture = 15, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 2, clothe_Texture = 2, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 3, clothe_Texture = 15, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 4, clothe_Texture = 15, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 6, clothe_Texture = 2, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 7, clothe_Texture = 2, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 8, clothe_Texture = 15, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 9, clothe_Texture = 15, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 10, clothe_Texture = 2, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 11, clothe_Texture = 15, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 12, clothe_Texture = 15, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 14, clothe_Texture = 1, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 15, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 16, clothe_Texture = 12, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 17, clothe_Texture = 11, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 18, clothe_Texture = 1, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 19, clothe_Texture = 4, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 20, clothe_Texture = 2, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 21, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 23, clothe_Texture = 12, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 24, clothe_Texture = 12, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 25, clothe_Texture = 12, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 26, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 27, clothe_Texture = 15, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 28, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 29, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 30, clothe_Texture = 4, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 31, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 32, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 33, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 34, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 36, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 37, clothe_Texture = 6, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 38, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 39, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 40, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 41, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 42, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 43, clothe_Texture = 4, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 44, clothe_Texture = 4, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 45, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 47, clothe_Texture = 6, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 48, clothe_Texture = 1, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 49, clothe_Texture = 1, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 50, clothe_Texture = 4, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 51, clothe_Texture = 4, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 52, clothe_Texture = 2, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 53, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 54, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 55, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 56, clothe_Texture = 5, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 57, clothe_Texture = 7, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 58, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 59, clothe_Texture = 2, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 60, clothe_Texture = 15, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 61, clothe_Texture = 9, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 62, clothe_Texture = 11, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 63, clothe_Texture = 11, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 64, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 65, clothe_Texture = 2, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 66, clothe_Texture = 10, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 67, clothe_Texture = 13, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 68, clothe_Texture = 9, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 69, clothe_Texture = 11, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 70, clothe_Texture = 9, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 71, clothe_Texture = 17, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 72, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 75, clothe_Texture = 2, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 78, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 79, clothe_Texture = 10, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 80, clothe_Texture = 7, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 81, clothe_Texture = 2, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 82, clothe_Texture = 7, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 83, clothe_Texture = 2, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 84, clothe_Texture = 5, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 85, clothe_Texture = 3, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 87, clothe_Texture = 15, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 88, clothe_Texture = 2, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 89, clothe_Texture = 23, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 90, clothe_Texture = 23, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 91, clothe_Texture = 23, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 92, clothe_Texture = 25, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 93, clothe_Texture = 9, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 94, clothe_Texture = 13, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 95, clothe_Texture = 19, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 96, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 97, clothe_Texture = 25, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 98, clothe_Texture = 11, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 99, clothe_Texture = 1, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 100, clothe_Texture = 25, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 101, clothe_Texture = 25, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 102, clothe_Texture = 20, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 103, clothe_Texture = 6, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 104, clothe_Texture = 13, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 105, clothe_Texture = 1, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 106, clothe_Texture = 7, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 107, clothe_Texture = 11, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 108, clothe_Texture = 15, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 109, clothe_Texture = 18, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 110, clothe_Texture = 17, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 111, clothe_Texture = 0, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 112, clothe_Texture = 11, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 113, clothe_Texture = 19, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 114, clothe_Texture = 15, price = rnd.Next(300, 420) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 4, clothe_class = "Pantolon", clothe_Id = 112, clothe_Texture = 11, price = rnd.Next(300, 420) });

        //Gözlük
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 0, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 1, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 2, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 3, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 4, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 6, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 7, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 8, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 9, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 10, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 11, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 14, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 16, clothe_Texture = 6, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 17, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 18, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 19, clothe_Texture = 10, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 20, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 21, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 22, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 23, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 24, clothe_Texture = 10, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 25, clothe_Texture = 9, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 27, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 30, clothe_Texture = 11, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 13, clothe_class = "Gözlük", clothe_Id = 31, clothe_Texture = 19, price = rnd.Next(190, 450) });



        //UnderShirt
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 0, clothe_Texture = 15, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 1, clothe_Texture = 15, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 5, clothe_Texture = 1, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 11, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 13, clothe_Texture = 15, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 15, clothe_Texture = 6, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 18, clothe_Texture = 3, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 19, clothe_Texture = 3, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 20, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 21, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 22, clothe_Texture = 4, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 23, clothe_Texture = 12, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 24, clothe_Texture = 5, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 25, clothe_Texture = 15, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 26, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 27, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 28, clothe_Texture = 8, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 29, clothe_Texture = 4, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 30, clothe_Texture = 3, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 31, clothe_Texture = 1, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 32, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 37, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 38, clothe_Texture = 15, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 39, clothe_Texture = 15, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 40, clothe_Texture = 9, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 41, clothe_Texture = 9, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 42, clothe_Texture = 3, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 44, clothe_Texture = 1, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 45, clothe_Texture = 17, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 46, clothe_Texture = 17, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 47, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 48, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 49, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 50, clothe_Texture = 17, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 51, clothe_Texture = 1, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 52, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 53, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 54, clothe_Texture = 1, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 55, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 56, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 57, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 58, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 59, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 60, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 61, clothe_Texture = 3, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 62, clothe_Texture = 3, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 63, clothe_Texture = 3, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 64, clothe_Texture = 4, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 65, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 66, clothe_Texture = 5, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 67, clothe_Texture = 5, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 68, clothe_Texture = 11, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 69, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 70, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 71, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 72, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 73, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 74, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 75, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 76, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 77, clothe_Texture = 7, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 78, clothe_Texture = 5, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 79, clothe_Texture = 5, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 80, clothe_Texture = 5, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 82, clothe_Texture = 15, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 83, clothe_Texture = 15, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 84, clothe_Texture = 15, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 85, clothe_Texture = 15, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 86, clothe_Texture = 19, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 87, clothe_Texture = 6, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 88, clothe_Texture = 25, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 89, clothe_Texture = 6, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 90, clothe_Texture = 25, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 91, clothe_Texture = 6, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 92, clothe_Texture = 9, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 93, clothe_Texture = 9, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 94, clothe_Texture = 9, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 95, clothe_Texture = 9, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 96, clothe_Texture = 9, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 97, clothe_Texture = 9, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 98, clothe_Texture = 9, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 99, clothe_Texture = 9, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 100, clothe_Texture = 2, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 101, clothe_Texture = 1, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 102, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 103, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 104, clothe_Texture = 17, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 106, clothe_Texture = 16, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 107, clothe_Texture = 16, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 108, clothe_Texture = 16, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 109, clothe_Texture = 16, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 110, clothe_Texture = 16, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 111, clothe_Texture = 16, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 112, clothe_Texture = 16, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 113, clothe_Texture = 16, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 114, clothe_Texture = 16, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 115, clothe_Texture = 16, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 116, clothe_Texture = 16, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 117, clothe_Texture = 16, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 118, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 119, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 120, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 121, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 122, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 123, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 124, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 125, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 126, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 127, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 128, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 129, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 130, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 131, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 132, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 133, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 134, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 135, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 136, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 137, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 138, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 139, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 140, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 141, clothe_Texture = 23, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 142, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 143, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 144, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 145, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 146, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 147, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 148, clothe_Texture = 13, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 149, clothe_Texture = 11, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 150, clothe_Texture = 11, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 151, clothe_Texture = 25, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 162, clothe_Texture = 20, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 163, clothe_Texture = 20, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 164, clothe_Texture = 20, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 165, clothe_Texture = 20, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 166, clothe_Texture = 20, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 167, clothe_Texture = 20, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 168, clothe_Texture = 20, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 169, clothe_Texture = 20, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 170, clothe_Texture = 20, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 171, clothe_Texture = 20, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 172, clothe_Texture = 20, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 173, clothe_Texture = 20, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 175, clothe_Texture = 11, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 176, clothe_Texture = 11, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 178, clothe_Texture = 21, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 179, clothe_Texture = 21, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 180, clothe_Texture = 21, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 181, clothe_Texture = 21, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 182, clothe_Texture = 21, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 183, clothe_Texture = 21, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 185, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 193, clothe_Texture = 0, price = rnd.Next(190, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 8, clothe_class = "Tişört", clothe_Id = 194, clothe_Texture = 0, price = rnd.Next(190, 450) });


        /// Accessori
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 3, clothe_Texture = 5, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 0, clothe_Texture = 0, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 6, clothe_Texture = 5, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 7, clothe_Texture = 1, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 9, clothe_Texture = 0, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 10, clothe_Texture = 3, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 11, clothe_Texture = 3, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 12, clothe_Texture = 2, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 13, clothe_Texture = 5, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 14, clothe_Texture = 3, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 15, clothe_Texture = 4, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 17, clothe_Texture = 3, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 18, clothe_Texture = 3, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 19, clothe_Texture = 0, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 20, clothe_Texture = 15, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 21, clothe_Texture = 2, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 22, clothe_Texture = 15, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 23, clothe_Texture = 2, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 26, clothe_Texture = 2, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 27, clothe_Texture = 2, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 28, clothe_Texture = 15, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 83, clothe_Texture = 2, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 84, clothe_Texture = 0, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 85, clothe_Texture = 0, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 86, clothe_Texture = 1, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 87, clothe_Texture = 9, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 88, clothe_Texture = 2, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 103, clothe_Texture = 0, price = rnd.Next(256, 354) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 1, id = 7, clothe_class = "Aksesuar", clothe_Id = 104, clothe_Texture = 0, price = rnd.Next(256, 354) });

        ///MALE
        //Tops
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 0, clothe_Texture = 5, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 1, clothe_Texture = 8, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 2, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 3, clothe_Texture = 15, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 4, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 5, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 6, clothe_Texture = 11, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 7, clothe_Texture = 15, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 8, clothe_Texture = 14, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 9, clothe_Texture = 15, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 10, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 11, clothe_Texture = 1, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 12, clothe_Texture = 11, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 13, clothe_Texture = 5, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 14, clothe_Texture = 15, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 16, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 17, clothe_Texture = 5, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 18, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 19, clothe_Texture = 1, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 20, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 21, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 22, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 23, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 24, clothe_Texture = 12, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 25, clothe_Texture = 9, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 27, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 28, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 29, clothe_Texture = 7, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 30, clothe_Texture = 7, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 31, clothe_Texture = 7, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 32, clothe_Texture = 7, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 33, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 34, clothe_Texture = 1, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 35, clothe_Texture = 6, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 36, clothe_Texture = 5, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 37, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 38, clothe_Texture = 4, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 39, clothe_Texture = 1, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 40, clothe_Texture = 1, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 41, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 42, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 43, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 44, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 45, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 46, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 47, clothe_Texture = 1, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 48, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 49, clothe_Texture = 4, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 50, clothe_Texture = 4, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 51, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 52, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 53, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 54, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 56, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 57, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 58, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 59, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 60, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 61, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 62, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 63, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 64, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 65, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 66, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 67, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 68, clothe_Texture = 5, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 69, clothe_Texture = 5, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 70, clothe_Texture = 11, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 71, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 72, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 73, clothe_Texture = 18, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 74, clothe_Texture = 10, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 75, clothe_Texture = 10, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 76, clothe_Texture = 4, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 77, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 78, clothe_Texture = 15, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 79, clothe_Texture = 4, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 80, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 81, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 82, clothe_Texture = 15, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 83, clothe_Texture = 4, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 84, clothe_Texture = 5, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 85, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 86, clothe_Texture = 4, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 87, clothe_Texture = 11, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 88, clothe_Texture = 11, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 90, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 91, clothe_Texture = 6, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 93, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 94, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 95, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 96, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 97, clothe_Texture = 1, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 98, clothe_Texture = 1, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 99, clothe_Texture = 4, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 100, clothe_Texture = 4, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 101, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 102, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 103, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 104, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 105, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 106, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 107, clothe_Texture = 4, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 108, clothe_Texture = 10, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 110, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 111, clothe_Texture = 5, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 112, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 113, clothe_Texture = 3, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 115, clothe_Texture = 0, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 116, clothe_Texture = 2, price = rnd.Next(300, 401) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 117, clothe_Texture = 15, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 117, clothe_Texture = 15, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 118, clothe_Texture = 9, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 119, clothe_Texture = 11, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 120, clothe_Texture = 11, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 121, clothe_Texture = 11, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 122, clothe_Texture = 13, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 123, clothe_Texture = 2, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 124, clothe_Texture = 0, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 125, clothe_Texture = 0, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 126, clothe_Texture = 14, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 127, clothe_Texture = 14, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 128, clothe_Texture = 9, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 129, clothe_Texture = 0, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 130, clothe_Texture = 0, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 131, clothe_Texture = 0, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 132, clothe_Texture = 0, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 133, clothe_Texture = 0, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 134, clothe_Texture = 2, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 135, clothe_Texture = 6, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 136, clothe_Texture = 6, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 137, clothe_Texture = 2, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 138, clothe_Texture = 2, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 139, clothe_Texture = 7, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 140, clothe_Texture = 14, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 141, clothe_Texture = 10, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 142, clothe_Texture = 2, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 143, clothe_Texture = 9, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 144, clothe_Texture = 13, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 145, clothe_Texture = 13, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 146, clothe_Texture = 8, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 147, clothe_Texture = 9, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 148, clothe_Texture = 11, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 149, clothe_Texture = 9, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 150, clothe_Texture = 11, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 151, clothe_Texture = 5, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 152, clothe_Texture = 15, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 153, clothe_Texture = 25, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 154, clothe_Texture = 7, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 155, clothe_Texture = 3, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 156, clothe_Texture = 5, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 157, clothe_Texture = 3, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 158, clothe_Texture = 2, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 159, clothe_Texture = 1, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 160, clothe_Texture = 1, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 161, clothe_Texture = 3, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 162, clothe_Texture = 3, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 163, clothe_Texture = 0, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 164, clothe_Texture = 2, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 165, clothe_Texture = 6, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 166, clothe_Texture = 5, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 167, clothe_Texture = 15, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 168, clothe_Texture = 2, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 169, clothe_Texture = 3, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 170, clothe_Texture = 3, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 171, clothe_Texture = 1, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 172, clothe_Texture = 3, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 173, clothe_Texture = 3, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 174, clothe_Texture = 3, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 175, clothe_Texture = 2, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 176, clothe_Texture = 0, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 177, clothe_Texture = 6, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 178, clothe_Texture = 10, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 179, clothe_Texture = 3, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 180, clothe_Texture = 2, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 181, clothe_Texture = 5, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 182, clothe_Texture = 0, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 183, clothe_Texture = 5, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 184, clothe_Texture = 3, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 185, clothe_Texture = 3, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 186, clothe_Texture = 10, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 187, clothe_Texture = 12, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 188, clothe_Texture = 10, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 189, clothe_Texture = 10, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 192, clothe_Texture = 11, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 193, clothe_Texture = 25, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 195, clothe_Texture = 2, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 196, clothe_Texture = 15, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 198, clothe_Texture = 8, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 199, clothe_Texture = 7, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 200, clothe_Texture = 25, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 202, clothe_Texture = 4, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 203, clothe_Texture = 25, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 204, clothe_Texture = 12, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 205, clothe_Texture = 4, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 206, clothe_Texture = 23, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 207, clothe_Texture = 23, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 208, clothe_Texture = 23, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 209, clothe_Texture = 23, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 210, clothe_Texture = 23, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 211, clothe_Texture = 23, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 213, clothe_Texture = 23, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 214, clothe_Texture = 23, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 215, clothe_Texture = 23, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 216, clothe_Texture = 23, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 217, clothe_Texture = 14, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 218, clothe_Texture = 14, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 219, clothe_Texture = 25, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 220, clothe_Texture = 25, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 221, clothe_Texture = 25, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 222, clothe_Texture = 25, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 223, clothe_Texture = 15, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 224, clothe_Texture = 15, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 225, clothe_Texture = 1, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 226, clothe_Texture = 0, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 227, clothe_Texture = 13, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 228, clothe_Texture = 19, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 229, clothe_Texture = 11, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 230, clothe_Texture = 11, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 231, clothe_Texture = 0, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 232, clothe_Texture = 9, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 233, clothe_Texture = 9, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 234, clothe_Texture = 25, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 235, clothe_Texture = 11, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 236, clothe_Texture = 11, price = rnd.Next(300, 401) });///Natamam
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 11, clothe_class = "Vücut", clothe_Id = 237, clothe_Texture = 25, price = rnd.Next(300, 401) });///Natamam
                                                                                                                                                                          ///Natamam

                                                                                                                                                                          ///Torso
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 3, clothe_class = "Gövde", clothe_Id = 163, clothe_Texture = 0, price = rnd.Next(50, 75) });
        ///Aksesuars 
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 10, clothe_Texture = 2, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 11, clothe_Texture = 2, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 12, clothe_Texture = 2, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 16, clothe_Texture = 2, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 17, clothe_Texture = 2, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 18, clothe_Texture = 0, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 19, clothe_Texture = 0, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 20, clothe_Texture = 4, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 21, clothe_Texture = 12, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 22, clothe_Texture = 14, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 23, clothe_Texture = 12, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 24, clothe_Texture = 15, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 25, clothe_Texture = 15, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 26, clothe_Texture = 15, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 27, clothe_Texture = 15, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 28, clothe_Texture = 15, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 29, clothe_Texture = 15, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 30, clothe_Texture = 5, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 31, clothe_Texture = 5, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 32, clothe_Texture = 22, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 34, clothe_Texture = 3, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 35, clothe_Texture = 3, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 36, clothe_Texture = 0, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 37, clothe_Texture = 15, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 38, clothe_Texture = 15, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 39, clothe_Texture = 15, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 42, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 43, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 44, clothe_Texture = 0, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 45, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 46, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 47, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 48, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 49, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 50, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 51, clothe_Texture = 0, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 52, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 53, clothe_Texture = 0, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 54, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 55, clothe_Texture = 10, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 74, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 75, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 76, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 77, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 78, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 79, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 80, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 81, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 82, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 83, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 84, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 85, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 86, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 87, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 88, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 89, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 90, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 91, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 92, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 93, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 94, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 113, clothe_Texture = 0, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 114, clothe_Texture = 0, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 115, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 116, clothe_Texture = 9, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 117, clothe_Texture = 9, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 118, clothe_Texture = 0, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 119, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 120, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 121, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 122, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 123, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 124, clothe_Texture = 1, price = rnd.Next(130, 190) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 7, clothe_class = "Aksesuar", clothe_Id = 130, clothe_Texture = 0, price = rnd.Next(130, 190) });

        //UnderShirt
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 0, clothe_Texture = 8, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 1, clothe_Texture = 8, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 2, clothe_Texture = 5, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 3, clothe_Texture = 2, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 4, clothe_Texture = 2, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 5, clothe_Texture = 2, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 6, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 7, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 8, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 9, clothe_Texture = 7, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 10, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 11, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 12, clothe_Texture = 11, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 13, clothe_Texture = 5, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 14, clothe_Texture = 14, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 15, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 16, clothe_Texture = 2, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 17, clothe_Texture = 5, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 18, clothe_Texture = 2, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 19, clothe_Texture = 3, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 20, clothe_Texture = 3, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 21, clothe_Texture = 4, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 22, clothe_Texture = 4, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 23, clothe_Texture = 2, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 24, clothe_Texture = 2, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 25, clothe_Texture = 12, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 26, clothe_Texture = 12, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 27, clothe_Texture = 9, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 28, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 29, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 30, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 31, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 32, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 33, clothe_Texture = 6, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 34, clothe_Texture = 6, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 35, clothe_Texture = 6, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 36, clothe_Texture = 6, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 37, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 38, clothe_Texture = 1, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 39, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 40, clothe_Texture = 5, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 41, clothe_Texture = 4, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 42, clothe_Texture = 2, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 43, clothe_Texture = 3, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 44, clothe_Texture = 1, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 45, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 46, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 47, clothe_Texture = 3, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 48, clothe_Texture = 3, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 49, clothe_Texture = 1, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 50, clothe_Texture = 1, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 51, clothe_Texture = 8, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 52, clothe_Texture = 8, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 53, clothe_Texture = 1, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 54, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 60, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 61, clothe_Texture = 3, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 62, clothe_Texture = 3, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 63, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 64, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 65, clothe_Texture = 18, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 66, clothe_Texture = 18, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 67, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 68, clothe_Texture = 3, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 43, clothe_Texture = 3, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 69, clothe_Texture = 4, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 70, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 71, clothe_Texture = 5, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 72, clothe_Texture = 5, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 73, clothe_Texture = 2, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 74, clothe_Texture = 5, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 75, clothe_Texture = 5, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 76, clothe_Texture = 8, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 79, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 80, clothe_Texture = 15, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 81, clothe_Texture = 25, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 82, clothe_Texture = 22, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 83, clothe_Texture = 25, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 84, clothe_Texture = 22, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 85, clothe_Texture = 25, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 86, clothe_Texture = 22, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 87, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 88, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 89, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 90, clothe_Texture = 1, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 91, clothe_Texture = 23, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 92, clothe_Texture = 25, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 93, clothe_Texture = 1, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 94, clothe_Texture = 1, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 95, clothe_Texture = 1, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 96, clothe_Texture = 17, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 98, clothe_Texture = 23, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 99, clothe_Texture = 23, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 100, clothe_Texture = 23, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 102, clothe_Texture = 23, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 103, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 104, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 105, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 106, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 107, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 108, clothe_Texture = 13, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 109, clothe_Texture = 11, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 110, clothe_Texture = 11, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 111, clothe_Texture = 25, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 112, clothe_Texture = 5, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 113, clothe_Texture = 5, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 114, clothe_Texture = 5, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 116, clothe_Texture = 5, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 117, clothe_Texture = 23, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 118, clothe_Texture = 23, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 119, clothe_Texture = 23, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 120, clothe_Texture = 23, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 121, clothe_Texture = 23, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 123, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 130, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 132, clothe_Texture = 20, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 133, clothe_Texture = 20, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 134, clothe_Texture = 20, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 135, clothe_Texture = 20, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 136, clothe_Texture = 20, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 137, clothe_Texture = 1, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 138, clothe_Texture = 21, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 139, clothe_Texture = 21, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 140, clothe_Texture = 21, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 141, clothe_Texture = 21, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 142, clothe_Texture = 21, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 143, clothe_Texture = 1, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 144, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 145, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 146, clothe_Texture = 13, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 147, clothe_Texture = 13, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 148, clothe_Texture = 13, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 149, clothe_Texture = 13, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 150, clothe_Texture = 13, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 151, clothe_Texture = 1, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 157, clothe_Texture = 0, price = rnd.Next(200, 300) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 8, clothe_class = "Tişört", clothe_Id = 158, clothe_Texture = 0, price = rnd.Next(200, 300) });

        //Pant
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 0, clothe_Texture = 15, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 1, clothe_Texture = 15, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 3, clothe_Texture = 15, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 4, clothe_Texture = 2, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 5, clothe_Texture = 15, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 6, clothe_Texture = 2, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 7, clothe_Texture = 15, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 8, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 9, clothe_Texture = 15, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 10, clothe_Texture = 2, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 12, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 13, clothe_Texture = 2, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 15, clothe_Texture = 15, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 16, clothe_Texture = 11, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 17, clothe_Texture = 10, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 18, clothe_Texture = 10, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 19, clothe_Texture = 1, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 20, clothe_Texture = 3, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 21, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 22, clothe_Texture = 12, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 23, clothe_Texture = 12, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 24, clothe_Texture = 6, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 25, clothe_Texture = 6, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 26, clothe_Texture = 11, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 28, clothe_Texture = 15, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 29, clothe_Texture = 2, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 30, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 32, clothe_Texture = 3, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 33, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 34, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 35, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 36, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 37, clothe_Texture = 3, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 38, clothe_Texture = 3, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 39, clothe_Texture = 3, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 40, clothe_Texture = 3, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 41, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 42, clothe_Texture = 7, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 43, clothe_Texture = 1, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 45, clothe_Texture = 6, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 47, clothe_Texture = 2, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 48, clothe_Texture = 2, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 49, clothe_Texture = 4, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 50, clothe_Texture = 3, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 51, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 52, clothe_Texture = 3, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 53, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 54, clothe_Texture = 6, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 55, clothe_Texture = 3, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 56, clothe_Texture = 7, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 57, clothe_Texture = 2, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 58, clothe_Texture = 15, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 59, clothe_Texture = 9, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 60, clothe_Texture = 11, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 61, clothe_Texture = 12, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 62, clothe_Texture = 3, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 63, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 64, clothe_Texture = 10, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 65, clothe_Texture = 13, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 66, clothe_Texture = 9, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 67, clothe_Texture = 11, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 68, clothe_Texture = 9, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 69, clothe_Texture = 17, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 70, clothe_Texture = 3, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 71, clothe_Texture = 5, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 72, clothe_Texture = 5, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 73, clothe_Texture = 5, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 74, clothe_Texture = 5, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 75, clothe_Texture = 7, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 76, clothe_Texture = 7, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 77, clothe_Texture = 10, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 78, clothe_Texture = 7, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 79, clothe_Texture = 2, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 80, clothe_Texture = 7, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 81, clothe_Texture = 2, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 82, clothe_Texture = 9, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 83, clothe_Texture = 3, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 84, clothe_Texture = 10, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 85, clothe_Texture = 2, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 86, clothe_Texture = 22, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 87, clothe_Texture = 22, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 88, clothe_Texture = 22, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 89, clothe_Texture = 25, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 90, clothe_Texture = 9, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 91, clothe_Texture = 13, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 92, clothe_Texture = 19, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 93, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 94, clothe_Texture = 24, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 95, clothe_Texture = 11, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 96, clothe_Texture = 1, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 97, clothe_Texture = 25, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 98, clothe_Texture = 25, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 99, clothe_Texture = 6, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 100, clothe_Texture = 13, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 101, clothe_Texture = 1, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 102, clothe_Texture = 17, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 103, clothe_Texture = 17, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 104, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 105, clothe_Texture = 11, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 106, clothe_Texture = 19, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 107, clothe_Texture = 15, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 108, clothe_Texture = 11, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 109, clothe_Texture = 17, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 110, clothe_Texture = 11, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 111, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 112, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 113, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 114, clothe_Texture = 13, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 115, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 116, clothe_Texture = 9, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 117, clothe_Texture = 10, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 118, clothe_Texture = 25, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 119, clothe_Texture = 10, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 120, clothe_Texture = 1, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 121, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 122, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 123, clothe_Texture = 0, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 124, clothe_Texture = 19, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 125, clothe_Texture = 19, price = rnd.Next(350, 450) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 4, clothe_class = "Pantolon", clothe_Id = 126, clothe_Texture = 0, price = rnd.Next(350, 450) });

        //Shoes
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 1, clothe_Texture = 15, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 2, clothe_Texture = 1, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 3, clothe_Texture = 15, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 4, clothe_Texture = 2, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 5, clothe_Texture = 4, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 6, clothe_Texture = 1, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 7, clothe_Texture = 15, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 8, clothe_Texture = 15, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 9, clothe_Texture = 15, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 10, clothe_Texture = 14, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 11, clothe_Texture = 15, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 12, clothe_Texture = 15, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 14, clothe_Texture = 15, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 15, clothe_Texture = 15, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 16, clothe_Texture = 11, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 17, clothe_Texture = 0, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 18, clothe_Texture = 1, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 19, clothe_Texture = 0, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 21, clothe_Texture = 11, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 22, clothe_Texture = 11, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 23, clothe_Texture = 15, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 24, clothe_Texture = 0, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 25, clothe_Texture = 0, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 26, clothe_Texture = 15, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 27, clothe_Texture = 0, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 28, clothe_Texture = 5, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 29, clothe_Texture = 0, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 30, clothe_Texture = 1, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 31, clothe_Texture = 4, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 32, clothe_Texture = 15, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 34, clothe_Texture = 0, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 35, clothe_Texture = 1, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 36, clothe_Texture = 3, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 37, clothe_Texture = 4, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 38, clothe_Texture = 4, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 39, clothe_Texture = 0, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 40, clothe_Texture = 11, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 41, clothe_Texture = 0, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 42, clothe_Texture = 9, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 43, clothe_Texture = 7, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 44, clothe_Texture = 10, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 45, clothe_Texture = 10, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 46, clothe_Texture = 9, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 47, clothe_Texture = 11, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 48, clothe_Texture = 1, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 49, clothe_Texture = 1, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 50, clothe_Texture = 5, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 51, clothe_Texture = 5, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 52, clothe_Texture = 1, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 53, clothe_Texture = 5, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 56, clothe_Texture = 1, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 57, clothe_Texture = 11, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 58, clothe_Texture = 2, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 59, clothe_Texture = 25, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 60, clothe_Texture = 7, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 61, clothe_Texture = 7, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 62, clothe_Texture = 7, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 63, clothe_Texture = 7, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 64, clothe_Texture = 14, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 65, clothe_Texture = 6, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 66, clothe_Texture = 6, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 67, clothe_Texture = 25, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 68, clothe_Texture = 9, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 69, clothe_Texture = 25, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 70, clothe_Texture = 25, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 71, clothe_Texture = 25, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 72, clothe_Texture = 25, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 73, clothe_Texture = 25, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 74, clothe_Texture = 1, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 75, clothe_Texture = 25, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 76, clothe_Texture = 25, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 77, clothe_Texture = 25, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 78, clothe_Texture = 13, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 79, clothe_Texture = 1, price = rnd.Next(240, 330) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 6, clothe_class = "Ayakkabı", clothe_Id = 80, clothe_Texture = 1, price = rnd.Next(240, 330) });


        ///Hats
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 0, clothe_Texture = 7, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 1, clothe_Texture = 0, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 2, clothe_Texture = 7, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 3, clothe_Texture = 3, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 4, clothe_Texture = 1, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 5, clothe_Texture = 1, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 6, clothe_Texture = 7, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 7, clothe_Texture = 7, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 12, clothe_Texture = 2, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 13, clothe_Texture = 7, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 14, clothe_Texture = 7, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 15, clothe_Texture = 7, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 20, clothe_Texture = 5, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 21, clothe_Texture = 7, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 22, clothe_Texture = 1, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 23, clothe_Texture = 0, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 24, clothe_Texture = 0, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 24, clothe_Texture = 0, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 25, clothe_Texture = 2, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 26, clothe_Texture = 13, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 27, clothe_Texture = 13, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 28, clothe_Texture = 5, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 29, clothe_Texture = 7, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 30, clothe_Texture = 1, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 31, clothe_Texture = 0, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 32, clothe_Texture = 0, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 33, clothe_Texture = 0, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 34, clothe_Texture = 0, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 35, clothe_Texture = 0, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 36, clothe_Texture = 0, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 37, clothe_Texture = 5, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 44, clothe_Texture = 7, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 45, clothe_Texture = 7, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 54, clothe_Texture = 1, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 55, clothe_Texture = 24, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 56, clothe_Texture = 9, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 58, clothe_Texture = 3, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 76, clothe_Texture = 20, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 77, clothe_Texture = 20, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 83, clothe_Texture = 3, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 94, clothe_Texture = 9, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 95, clothe_Texture = 9, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 96, clothe_Texture = 15, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 103, clothe_Texture = 19, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 104, clothe_Texture = 25, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 105, clothe_Texture = 25, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 106, clothe_Texture = 25, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 107, clothe_Texture = 25, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 108, clothe_Texture = 25, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 109, clothe_Texture = 10, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 110, clothe_Texture = 10, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 120, clothe_Texture = 25, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 130, clothe_Texture = 18, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 131, clothe_Texture = 18, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 132, clothe_Texture = 3, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 135, clothe_Texture = 23, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 136, clothe_Texture = 23, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 139, clothe_Texture = 2, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 140, clothe_Texture = 2, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 142, clothe_Texture = 25, price = rnd.Next(170, 260) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 12, clothe_class = "Şapka", clothe_Id = 143, clothe_Texture = 25, price = rnd.Next(170, 260) });


        //Gözlük
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 2, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 3, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 4, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 5, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 7, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 8, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 9, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 10, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 12, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 13, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 15, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 16, clothe_Texture = 9, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 17, clothe_Texture = 9, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 18, clothe_Texture = 10, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 19, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 20, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 21, clothe_Texture = 0, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 22, clothe_Texture = 0, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 23, clothe_Texture = 9, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 25, clothe_Texture = 7, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 28, clothe_Texture = 11, price = rnd.Next(180, 239) });
        clothes_list.Add(new ClothesList_Structer { clothe_gender = 0, id = 13, clothe_class = "Gözlük", clothe_Id = 29, clothe_Texture = 19, price = rnd.Next(180, 239) });

    }


    [RemoteEvent("Preview_Clothes")]
    public static void Preview_Clothes(Player Client, int id, int clothid, int textid)
    {
        switch ((int)Client.GetData<dynamic>("Clothes_id_selected"))
        {
            case 12:
                Client.SetAccessories(0, clothid, textid);
                break;
            case 13:
                Client.SetAccessories(1, clothid, textid);
                break;
            default:
                Client.SetClothes(id, clothid, textid);
                break;
        }
    }

    public static void ShowClothesMainMenu(Player client)
    {
        client.TriggerEvent("ShowMainClothMenu");
    }

    [RemoteEvent("Cloth_Store")]
    public static void ShowClothSelectMenu(Player Client, int id)
    {
        int data = (int)NAPI.Data.GetEntitySharedData(Client, "CHARACTER_ONLINE_GENRE");

        Task.Run(() =>
        {

            if (id == 0)
            {

            }
            List<ClothesList_Structer> temp = new List<ClothesList_Structer>();

            //Female
            if (data == 1)
            {
                foreach (var cl in clothes_list)
                {
                    if (cl.clothe_gender == 1 && cl.id == id)
                    {
                        switch (id)
                        {
                            case 3:
                                for (int i = 0; i < cl.clothe_Id - 1; i++)
                                {
                                    if (i == 17)
                                    {
                                        continue;
                                    }
                                    temp.Add(new ClothesList_Structer { clothe_gender = 0, id = 3, clothe_class = "Gövde", clothe_Id = i, clothe_Texture = 0, price = cl.price });
                                }
                                break;
                            default:
                                temp.Add(cl);
                                break;
                        }
                    }
                }
            }
            else///Male
            {
                foreach (var cl in clothes_list)
                {
                    if (cl.clothe_gender == 0 && cl.id == id)
                    {
                        switch (id)
                        {
                            case 3:
                                for (int i = 0; i < cl.clothe_Id - 1; i++)
                                {
                                    temp.Add(new ClothesList_Structer { clothe_gender = 0, id = 3, clothe_class = "Gövde", clothe_Id = i, clothe_Texture = 0, price = cl.price });
                                }
                                break;
                            default:
                                temp.Add(cl);
                                break;
                        }
                    }
                }
            }
            NAPI.Task.Run(() =>
            {
                Client.SetData<dynamic>("Clothes_activeIndex", -1);
                Client.SetData<dynamic>("Clothes_id_selected", id);
                Client.SetData<dynamic>("Clothes_activeTypeIndex", -1);

                Client.TriggerEvent("Display_Cloth_Selector", NAPI.Util.ToJson(temp));

                Client.TriggerEvent("ps_BodyCamera");
            });

        });

    }

    [RemoteEvent("Buy_Clothes")]
    public static void BuyClothes(Player Client, int id, int clothid, int textid,int item_price)
    {
        long time = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
        

        if (id == -1 || clothid == -1 || textid == -1)
        {
            Main.SendErrorMessage(Client, "Geçerli bir kıyafet seçin.");
        }
        else
        {
            if (Main.GetPlayerBank(Client) < item_price)
            {
                Main.SendErrorMessage(Client, "Bu ürünü satın almak için yeterli miktarda paranız yok.");
                return;
            }
            
            Main.GivePlayerMoneyBank(Client, -item_price);

            string name = "Unknown";

            switch (id)
            {
                case 3:
                    Client.SetSharedData("character_torso", clothid);
                    name = "Gövde";
                    break;
                case 11:
                    Client.SetSharedData("character_shirt", clothid);
                    Client.SetSharedData("character_shirt_texture", textid);
                    name = "Üst Giyim";
                    break;
                case 8:
                    Client.SetSharedData("character_undershirt", clothid);
                    Client.SetSharedData("character_undershirt_texture", textid);
                    name = "İç Giyim";
                    break;
                case 4:
                    Client.SetSharedData("character_leg", clothid);
                    Client.SetSharedData("character_leg_texture", textid);
                    name = "Pantolon";
                    break;
                case 6:
                    Client.SetSharedData("character_feet", clothid);
                    Client.SetSharedData("character_feet_texture", textid);
                    name = "Ayakkabı";
                    break;
                case 7:
                    Client.SetSharedData("character_Aksesuars", clothid);
                    Client.SetSharedData("character_Aksesuars_texture", textid);
                    name = "Aksesuar";
                    break;
                case 12:
                    Client.SetSharedData("character_hats", clothid);
                    Client.SetSharedData("character_hats_texture", textid);
                    name = "Şapka";
                    break;
                case 13:
                    Client.SetSharedData("character_Gözlükes", clothid);
                    Client.SetSharedData("character_Gözlükes_texture", textid);
                    name = "Gözlük";
                    break;
                default:
                    break;
            }

            Main.SendSuccessMessage(Client, "Başarıyla yeni kıyafet satın aldınız. ~r~(-$" + item_price + ")");

        }
    }

    [RemoteEvent("BackToMainClothMenu")]
    public static void ClothesCloseMenu(Player Client)
    {
        Client.TriggerEvent("ps_DestroyCamera");
        Main.UpdatePlayerClothes(Client);
    }

    [RemoteEvent("Update_Player_Clothes")]
    public static void Update_Player_Clothes(Player Client)
    {
        Main.UpdatePlayerClothes(Client);
    }

    [Command("getcloth")]
    public void getcloth(Player player, int id, int variation)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Bu komutu kullanabilmek için işbaşında olmalısınız, /aduty komutu ile işbaşına geçebilirsiniz.");
            return;
        }
        player.TriggerEvent("getNumberOfTextureVariations", id, variation);
    }




}
