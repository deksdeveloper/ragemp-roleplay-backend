﻿using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

class UsefullyRP : Script
{
    public static List<dynamic> mask_list = new List<dynamic>();
    public static List<dynamic> helmet_list = new List<dynamic>();

    public static bool[] seatbelt { get; set; } = new bool[Main.MAX_PLAYERS];
    // public static bool[] mask { get; set; } = new bool[Main.MAX_PLAYERS];


    public UsefullyRP()
    {
        mask_list.Add(new { Name = "Kafatası 1", variation = 2, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Kafatası 2", variation = 2, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Kafatası 3", variation = 2, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Kafatası 4", variation = 2, texture = 3, price = 450 });

        mask_list.Add(new { Name = "Maymun 1", variation = 3, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maymun 2", variation = 5, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Maymun 3", variation = 5, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Maymun 4", variation = 5, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Maymun 5", variation = 5, texture = 3, price = 450 });

        mask_list.Add(new { Name = "Hokey 1", variation = 4, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Hokey 2", variation = 4, texture = 1, price = 650 });
        mask_list.Add(new { Name = "Hokey 3", variation = 4, texture = 2, price = 650 });
        mask_list.Add(new { Name = "Hokey 4", variation = 4, texture = 3, price = 650 });
        mask_list.Add(new { Name = "Hokey 5", variation = 14, texture = 0, price = 750 });
        mask_list.Add(new { Name = "Hokey 6", variation = 14, texture = 1, price = 750 });
        mask_list.Add(new { Name = "Hokey 7", variation = 14, texture = 2, price = 750 });
        mask_list.Add(new { Name = "Hokey 8", variation = 14, texture = 3, price = 750 });
        mask_list.Add(new { Name = "Hokey 9", variation = 14, texture = 4, price = 750 });
        mask_list.Add(new { Name = "Hokey 10", variation = 14, texture = 5, price = 750 });
        mask_list.Add(new { Name = "Hokey 11", variation = 14, texture = 6, price = 750 });
        mask_list.Add(new { Name = "Hokey 12", variation = 14, texture = 7, price = 750 });
        mask_list.Add(new { Name = "Hokey 13", variation = 14, texture = 8, price = 650 });
        mask_list.Add(new { Name = "Hokey 14", variation = 14, texture = 9, price = 750 });
        mask_list.Add(new { Name = "Hokey 15", variation = 14, texture = 10, price = 750 });
        mask_list.Add(new { Name = "Hokey 16", variation = 14, texture = 11, price = 750 });
        mask_list.Add(new { Name = "Hokey 17", variation = 14, texture = 12, price = 750 });
        mask_list.Add(new { Name = "Hokey 18", variation = 14, texture = 13, price = 750 });
        mask_list.Add(new { Name = "Hokey 19", variation = 14, texture = 14, price = 750 });
        mask_list.Add(new { Name = "Hokey 20", variation = 14, texture = 15, price = 750 });
        mask_list.Add(new { Name = "Hokey 21", variation = 15, texture = 0, price = 750 });
        mask_list.Add(new { Name = "Hokey 22", variation = 15, texture = 1, price = 750 });
        mask_list.Add(new { Name = "Hokey 23", variation = 15, texture = 2, price = 750 });
        mask_list.Add(new { Name = "Hokey 24", variation = 15, texture = 3, price = 750 });
        mask_list.Add(new { Name = "Hokey 25", variation = 16, texture = 0, price = 750 });
        mask_list.Add(new { Name = "Hokey 26", variation = 16, texture = 1, price = 750 });
        mask_list.Add(new { Name = "Hokey 27", variation = 16, texture = 2, price = 750 });
        mask_list.Add(new { Name = "Hokey 28", variation = 16, texture = 3, price = 750 });
        mask_list.Add(new { Name = "Hokey 29", variation = 16, texture = 4, price = 750 });
        mask_list.Add(new { Name = "Hokey 30", variation = 16, texture = 5, price = 750 });
        mask_list.Add(new { Name = "Hokey 31", variation = 16, texture = 6, price = 750 });
        mask_list.Add(new { Name = "Hokey 32", variation = 16, texture = 7, price = 750 });
        mask_list.Add(new { Name = "Hokey 33", variation = 16, texture = 8, price = 750 });
        mask_list.Add(new { Name = "Hokey 34", variation = 113, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Hokey 35", variation = 113, texture = 1, price = 650 });
        mask_list.Add(new { Name = "Hokey 36", variation = 113, texture = 2, price = 650 });
        mask_list.Add(new { Name = "Hokey 37", variation = 113, texture = 3, price = 650 });
        mask_list.Add(new { Name = "Hokey 38", variation = 113, texture = 4, price = 750 });
        mask_list.Add(new { Name = "Hokey 39", variation = 113, texture = 5, price = 750 });
        mask_list.Add(new { Name = "Hokey 40", variation = 113, texture = 6, price = 750 });
        mask_list.Add(new { Name = "Hokey 41", variation = 113, texture = 7, price = 750 });
        mask_list.Add(new { Name = "Hokey 42", variation = 113, texture = 8, price = 750 });
        mask_list.Add(new { Name = "Hokey 43", variation = 113, texture = 9, price = 750 });
        mask_list.Add(new { Name = "Hokey 44", variation = 113, texture = 10, price = 750 });
        mask_list.Add(new { Name = "Hokey 45", variation = 113, texture = 11, price = 750 });
        mask_list.Add(new { Name = "Hokey 46", variation = 113, texture = 12, price = 650 });
        mask_list.Add(new { Name = "Hokey 47", variation = 113, texture = 13, price = 750 });
        mask_list.Add(new { Name = "Hokey 48", variation = 113, texture = 14, price = 750 });
        mask_list.Add(new { Name = "Hokey 49", variation = 113, texture = 15, price = 750 });
        mask_list.Add(new { Name = "Hokey 50", variation = 113, texture = 16, price = 750 });
        mask_list.Add(new { Name = "Hokey 51", variation = 113, texture = 17, price = 750 });
        mask_list.Add(new { Name = "Hokey 52", variation = 113, texture = 18, price = 750 });
        mask_list.Add(new { Name = "Hokey 53", variation = 113, texture = 19, price = 750 });
        mask_list.Add(new { Name = "Hokey 54", variation = 113, texture = 20, price = 750 });
        mask_list.Add(new { Name = "Hokey 55", variation = 113, texture = 21, price = 750 });
        mask_list.Add(new { Name = "Hokey 56", variation = 113, texture = 22, price = 750 });


        mask_list.Add(new { Name = "Black Devil 1", variation = 7, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Black Devil 2", variation = 7, texture = 1, price = 650 });
        mask_list.Add(new { Name = "Black Devil 3", variation = 7, texture = 2, price = 650 });
        mask_list.Add(new { Name = "Black Devil 4", variation = 7, texture = 3, price = 650 });

        mask_list.Add(new { Name = "Santa clause 1", variation = 8, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Santa clause 2", variation = 8, texture = 1, price = 650 });
        mask_list.Add(new { Name = "Santa clause 3", variation = 8, texture = 2, price = 650 });
        mask_list.Add(new { Name = "Santa clause 4", variation = 76, texture = 0, price = 650 });

        mask_list.Add(new { Name = "Unknown-1 1", variation = 11, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Unknown-1 2", variation = 11, texture = 1, price = 650 });
        mask_list.Add(new { Name = "Unknown-1 3", variation = 11, texture = 2, price = 650 });

        mask_list.Add(new { Name = "Cat 1", variation = 17, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Cat 2", variation = 17, texture = 1, price = 650 });

        mask_list.Add(new { Name = "Little Wolf 1", variation = 18, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Little Wolf 2", variation = 18, texture = 1, price = 650 });

        mask_list.Add(new { Name = "Owl 1", variation = 19, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Owl 2", variation = 19, texture = 1, price = 650 });

        mask_list.Add(new { Name = "Weasel 1", variation = 20, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Weasel 2", variation = 20, texture = 1, price = 650 });

        mask_list.Add(new { Name = "Bear 1", variation = 21, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Bear 2", variation = 21, texture = 1, price = 650 });

        mask_list.Add(new { Name = "Buffalo 1", variation = 22, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Buffalo 2", variation = 22, texture = 1, price = 650 });

        mask_list.Add(new { Name = "Cow 1", variation = 23, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Cow 2", variation = 23, texture = 1, price = 650 });

        mask_list.Add(new { Name = "Eagle 1", variation = 24, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Eagle 2", variation = 24, texture = 1, price = 650 });

        mask_list.Add(new { Name = "Turkey 1", variation = 25, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Turkey 2", variation = 25, texture = 1, price = 650 });

        mask_list.Add(new { Name = "Wolf 1", variation = 26, texture = 0, price = 650 });
        mask_list.Add(new { Name = "Wolf 2", variation = 26, texture = 1, price = 650 });

        mask_list.Add(new { Name = "Penguin 1", variation = 26, texture = 0, price = 650 });

        mask_list.Add(new { Name = "Pro Mask 1", variation = 28, texture = 0, price = 900 });
        mask_list.Add(new { Name = "Pro Mask 2", variation = 28, texture = 1, price = 900 });
        mask_list.Add(new { Name = "Pro Mask 3", variation = 28, texture = 2, price = 900 });
        mask_list.Add(new { Name = "Pro Mask 4", variation = 28, texture = 3, price = 900 });
        mask_list.Add(new { Name = "Pro Mask 5", variation = 28, texture = 4, price = 900 });

        mask_list.Add(new { Name = "Devil Skull 1", variation = 29, texture = 0, price = 750 });
        mask_list.Add(new { Name = "Devil Skull 2", variation = 29, texture = 1, price = 750 });
        mask_list.Add(new { Name = "Devil Skull 3", variation = 29, texture = 2, price = 750 });
        mask_list.Add(new { Name = "Devil Skull 4", variation = 29, texture = 3, price = 750 });
        mask_list.Add(new { Name = "Devil Skull 5", variation = 29, texture = 4, price = 750 });

        mask_list.Add(new { Name = "Biscuits 1", variation = 31, texture = 0, price = 700 });
        mask_list.Add(new { Name = "Biscuits 2", variation = 75, texture = 0, price = 700 });
        mask_list.Add(new { Name = "Biscuits 3", variation = 76, texture = 0, price = 700 });

        mask_list.Add(new { Name = "Robber 1", variation = 35, texture = 0, price = 750 });

        mask_list.Add(new { Name = "Gas Mask 1", variation = 36, texture = 0, price = 1500 });
        mask_list.Add(new { Name = "Gas Mask 2", variation = 38, texture = 0, price = 1500 });
        mask_list.Add(new { Name = "Gas Mask 3", variation = 46, texture = 0, price = 1500 });

        mask_list.Add(new { Name = "RED Devil 1", variation = 68, texture = 0, price = 800 });
        mask_list.Add(new { Name = "RED Devil 2", variation = 68, texture = 1, price = 800 });
        mask_list.Add(new { Name = "RED Devil 3", variation = 68, texture = 2, price = 800 });
        mask_list.Add(new { Name = "RED Devil 4", variation = 72, texture = 0, price = 800 });
        mask_list.Add(new { Name = "RED Devil 5", variation = 72, texture = 1, price = 800 });
        mask_list.Add(new { Name = "RED Devil 6", variation = 72, texture = 2, price = 800 });



        mask_list.Add(new { Name = "Clown 1", variation = 95, texture = 0, price = 800 });
        mask_list.Add(new { Name = "Clown 2", variation = 95, texture = 1, price = 800 });
        mask_list.Add(new { Name = "Clown 3", variation = 95, texture = 2, price = 800 });
        mask_list.Add(new { Name = "Clown 4", variation = 95, texture = 3, price = 800 });
        mask_list.Add(new { Name = "Clown 5", variation = 95, texture = 4, price = 800 });
        mask_list.Add(new { Name = "Clown 6", variation = 95, texture = 5, price = 800 });
        mask_list.Add(new { Name = "Clown 7", variation = 95, texture = 6, price = 800 });
        mask_list.Add(new { Name = "Clown 8", variation = 95, texture = 7, price = 800 });

        mask_list.Add(new { Name = "Beaut Skull 1", variation = 99, texture = 0, price = 800 });
        mask_list.Add(new { Name = "Beaut Skull 2", variation = 99, texture = 1, price = 800 });
        mask_list.Add(new { Name = "Beaut Skull 3", variation = 99, texture = 2, price = 800 });
        mask_list.Add(new { Name = "Beaut Skull 4", variation = 99, texture = 3, price = 800 });
        mask_list.Add(new { Name = "Beaut Skull 5", variation = 99, texture = 4, price = 800 });
        mask_list.Add(new { Name = "Beaut Skull 6", variation = 99, texture = 5, price = 800 });

        mask_list.Add(new { Name = "Bandana 1", variation = 51, texture = 0, price = 450 });
        mask_list.Add(new { Name = "Bandana 2", variation = 51, texture = 1, price = 450 });
        mask_list.Add(new { Name = "Bandana 3", variation = 51, texture = 2, price = 450 });
        mask_list.Add(new { Name = "Bandana 4", variation = 51, texture = 3, price = 450 });
        mask_list.Add(new { Name = "Bandana 5", variation = 51, texture = 4, price = 450 });
        mask_list.Add(new { Name = "Bandana 6", variation = 51, texture = 5, price = 450 });
        mask_list.Add(new { Name = "Bandana 7", variation = 51, texture = 6, price = 450 });
        mask_list.Add(new { Name = "Bandana 8", variation = 51, texture = 7, price = 450 });
        mask_list.Add(new { Name = "Bandana 9", variation = 51, texture = 8, price = 450 });
        mask_list.Add(new { Name = "Bandana 10", variation = 51, texture = 9, price = 450 });

        mask_list.Add(new { Name = "Ninja Maske 1", variation = 54, texture = 0, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 2", variation = 54, texture = 1, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 3", variation = 54, texture = 2, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 4", variation = 54, texture = 3, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 5", variation = 54, texture = 4, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 6", variation = 54, texture = 5, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 7", variation = 54, texture = 6, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 8", variation = 54, texture = 7, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 9", variation = 54, texture = 8, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 54, texture = 9, price = 560 });

        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 0, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 1, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 2, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 3, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 4, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 5, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 6, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 7, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 8, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 9, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 10, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 11, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 12, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 13, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 14, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 15, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 16, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 17, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 18, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 19, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 20, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 21, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 22, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 23, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 24, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 104, texture = 25, price = 560 });

        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 0, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 1, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 2, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 3, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 4, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 5, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 6, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 7, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 8, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 9, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 10, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 11, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 12, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 13, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 14, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 15, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 16, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 17, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 18, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 19, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 20, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 21, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 22, price = 560 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 105, texture = 23, price = 560 });

        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 0, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 1, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 2, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 3, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 4, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 5, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 6, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 7, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 8, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 9, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 10, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 11, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 12, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 13, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 14, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 15, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 16, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 17, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 18, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 19, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 20, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 21, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 22, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 23, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 24, price = 800 });
        mask_list.Add(new { Name = "Ninja Maske 10", variation = 115, texture = 25, price = 800 });



        mask_list.Add(new { Name = "Haydut Maskesi 1", variation = 57, texture = 0, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 2", variation = 57, texture = 1, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 3", variation = 57, texture = 2, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 4", variation = 57, texture = 3, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 5", variation = 57, texture = 4, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 6", variation = 57, texture = 5, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 7", variation = 57, texture = 6, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 8", variation = 57, texture = 7, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 9", variation = 57, texture = 8, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 10", variation = 57, texture = 9, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 11", variation = 57, texture = 10, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 12", variation = 57, texture = 11, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 13", variation = 57, texture = 12, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 14", variation = 57, texture = 13, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 15", variation = 57, texture = 14, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 16", variation = 57, texture = 15, price = 880 });
        mask_list.Add(new { Name = "Haydut Maskesi 17", variation = 57, texture = 16, price = 880 });

        mask_list.Add(new { Name = "Koruyucu Ninja Maskesi", variation = 37, texture = 0, price = 1250 });

        mask_list.Add(new { Name = "Kahraman Maskesi 1", variation = 43, texture = 0, price = 1150 });
        mask_list.Add(new { Name = "Kahraman Maskesi  2", variation = 44, texture = 0, price = 1150 });
        mask_list.Add(new { Name = "Kahraman Maskesi 3", variation = 45, texture = 0, price = 1150 });

        helmet_list.Add(new { Name = "Kask  1", variation = 16, texture = 0, price = 1050 });
        helmet_list.Add(new { Name = "kask  2", variation = 16, texture = 1, price = 1050 });
        helmet_list.Add(new { Name = "kask  3", variation = 16, texture = 2, price = 1050 });
        helmet_list.Add(new { Name = "kask  4", variation = 16, texture = 3, price = 1050 });
        helmet_list.Add(new { Name = "kask  5", variation = 16, texture = 4, price = 1050 });
        helmet_list.Add(new { Name = "kask  6", variation = 16, texture = 5, price = 1050 });
        helmet_list.Add(new { Name = "kask  7", variation = 16, texture = 6, price = 1050 });
        helmet_list.Add(new { Name = "Kask  8", variation = 16, texture = 7, price = 1050 });

        helmet_list.Add(new { Name = "Gelişmiş Kask 1", variation = 17, texture = 0, price = 850 });
        helmet_list.Add(new { Name = "Gelişmiş Kask 2", variation = 17, texture = 1, price = 850 });
        helmet_list.Add(new { Name = "Gelişmiş Kask 3", variation = 17, texture = 2, price = 850 });
        helmet_list.Add(new { Name = "Gelişmiş Kask 4", variation = 17, texture = 3, price = 850 });
        helmet_list.Add(new { Name = "Gelişmiş Kask 5", variation = 17, texture = 4, price = 850 });
        helmet_list.Add(new { Name = "Gelişmiş Kask 6", variation = 17, texture = 5, price = 850 });
        helmet_list.Add(new { Name = "Gelişmiş Kask 7", variation = 17, texture = 6, price = 850 });
        helmet_list.Add(new { Name = "Gelişmiş Kask 8", variation = 17, texture = 7, price = 850 });

        helmet_list.Add(new { Name = "Vizörsüz Kask 1", variation = 18, texture = 0, price = 1600 });
        helmet_list.Add(new { Name = "Vizörsüz Kask 2", variation = 18, texture = 1, price = 1600 });
        helmet_list.Add(new { Name = "Vizörsüz Kask 3", variation = 18, texture = 2, price = 1600 });
        helmet_list.Add(new { Name = "Vizörsüz Kask 4", variation = 18, texture = 3, price = 1600 });
        helmet_list.Add(new { Name = "Vizörsüz Kask 5", variation = 18, texture = 4, price = 1600 });
        helmet_list.Add(new { Name = "Vizörsüz Kask 6", variation = 18, texture = 5, price = 1600 });
        helmet_list.Add(new { Name = "Vizörsüz Kask 7", variation = 18, texture = 6, price = 1600 });
        helmet_list.Add(new { Name = "Vizörsüz Kask 8", variation = 18, texture = 7, price = 1600 });

        helmet_list.Add(new { Name = "Açık Vizörlü Kask", variation = 48, texture = 0, price = 1750 });
        helmet_list.Add(new { Name = "Açık Vizörlü Kask", variation = 49, texture = 0, price = 1750 });

        helmet_list.Add(new { Name = "Koruyucu Kask", variation = 50, texture = 0, price = 10000 });
        helmet_list.Add(new { Name = "Koruyucu Kask 2", variation = 52, texture = 0, price = 10000 });
        helmet_list.Add(new { Name = "Gelişmiş Kask 1", variation = 51, texture = 0, price = 15000 });
        helmet_list.Add(new { Name = "Gelişmiş Kask 2", variation = 53, texture = 0, price = 15000 });


        //-1336.596, -1279.008, 4.856604

        Entity temp_blip;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1336.596, -1279.008, 4.856604));
        NAPI.Blip.SetBlipName(temp_blip, "ProtectX");
        NAPI.Blip.SetBlipSprite(temp_blip, 362);
        NAPI.Blip.SetBlipColor(temp_blip, 33);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        NAPI.TextLabel.CreateTextLabel(Main.LabelColor + "(( ProtectX ))~n~" + Main.LabelCommandColor + "« Y »", new Vector3(-1336.596, -1279.008, 4.856604), 16, 0.600f, 0, new Color(0, 122, 255, 150));
    }
    [ServerEvent(Event.PlayerConnected)]   
    public void OnPlayerConnected(Player Client)
    {
        for (int i = 0; i < Main.MAX_PLAYERS; i++)
        {
            Client.SetSharedData("know_player_" + i, -1);
            Client.SetSharedData("know_name_" + i, -1);

        }
    }



    public static void ModalConfirm(Player Client, string response)
    {

        if (response == "Hooker_System")
        {
            Player pl = Client.GetData<dynamic>("Hooker_Partner");
            if (Client.Vehicle.EngineStatus == false) { Main.DisplayErrorMessage(Client, "error", "Aracın motorunu kapatmalı ve tenha bir alana geçmelisiniz."); }
            if (pl.Exists && pl.Vehicle == Client.Vehicle && pl.VehicleSeat == (int)VehicleSeat.RightFront && Client.VehicleSeat == (int)VehicleSeat.Driver)
            {
                switch ((int)Client.GetData<dynamic>("Hooker_Offer"))
                {
                    case 0:
                      
                        Client.PlayAnimation("mini@prostitutes@sexlow_veh", "low_car_bj_loop_player", (int)animationCommands.AnimationFlags.Loop);
                        pl.PlayAnimation("mini@prostitutes@sexlow_veh", "low_car_bj_loop_female", (int)animationCommands.AnimationFlags.Loop);
                        pl.SetData<dynamic>("ForceAnim", true);
                        Client.SetData<dynamic>("ForceAnim", true);
                        //  pl.TriggerEvent("TanabCuff", true);
                        // Client.TriggerEvent("TanabCuff", true);
                        Client.SetData<dynamic>("Hooker_Active",true);
                        pl.SetData<dynamic>("Hooker_Active", true);

                        NAPI.Task.Run(() =>
                        {
                            pl.ResetData("ForceAnim");
                            Client.ResetData("ForceAnim");
                            pl.ResetData("Hooker_Active");
                            Client.ResetData("Hooker_Active");

                            pl.ResetData("Hooker_Partner");
                            Client.ResetData("Hooker_Partner");
                            pl.StopAnimation();
                            Client.StopAnimation();
                            if (pl.Health >= 11)
                            {
                                NAPI.Player.SetPlayerHealth(pl, pl.Health - 10);
                            }
                        }, 120000);

                        break;
                    case 1:
                        Client.PlayAnimation("mini@prostitutes@sexlow_veh", "low_car_sex_loop_player", (int)animationCommands.AnimationFlags.Loop);
                        pl.PlayAnimation("mini@prostitutes@sexlow_veh", "low_car_sex_loop_female", (int)animationCommands.AnimationFlags.Loop);
                        pl.SetData<dynamic>("ForceAnim", true);
                        Client.SetData<dynamic>("ForceAnim", true);

                        Client.SetData<dynamic>("Hooker_Active", true);
                        pl.SetData<dynamic>("Hooker_Active", true);
                        NAPI.Task.Run(() =>
                        {
                            if (pl.Exists && pl.HasData("Hooker_Active"))
                            {
                                pl.ResetData("ForceAnim");
                                pl.ResetData("Hooker_Active");
                                pl.ResetData("Hooker_Partner");
                                pl.StopAnimation();

                            }
                            if (Client.Exists && Client.HasData("Hooker_Active"))
                            {
                                Client.ResetData("ForceAnim");
                                Client.ResetData("Hooker_Active");

                                Client.ResetData("Hooker_Partner");
                                Client.StopAnimation();

                            }
                            
                            
                        }, 120000);
                        break;
                    default:
                        break;
                }

            }
            else
            {
                Main.SendCustomChatToAll("Şu anda bunu yapamazsınız.");

            }
        }

    }



    public static void KeyPressY(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-1336.596, -1279.008, 4.856604), 3.0f))
        {
            if (Client.IsInVehicle)
            {
                return;
            }
            if (Client.GetSharedData<dynamic>("using_mask") == true)
            {
                Main.SendErrorMessage(Client, "Bu mağazayı kullanamazsınız.");
                return;
            }
            List<dynamic> menu_item_list = new List<dynamic>();

            List<string> temp_mask = new List<string>();
            List<string> temp_helmet = new List<string>();
            int count = 0;
            foreach (var clothes in mask_list)
            {
                temp_mask.Add(count.ToString());
                count++;
            }
            count = 0;
            foreach (var clothes in helmet_list)
            {
                temp_helmet.Add(count.ToString());
                count++;
            }
        
    


            menu_item_list.Add(new { Type = 6, Name = "Kask", Description = "", List = temp_helmet, StartIndex = 0 });
            menu_item_list.Add(new { Type = 6, Name = "Maske", Description = "", List = temp_mask, StartIndex = 0 });

            InteractMenu.CreateMenu(Client, "MASK_AND_HELMET_STORE", "ProtectX", "~g~", true, NAPI.Util.ToJson(menu_item_list), false);

         //   InteractMenu.CreateMenu(Client, "MASK_AND_HELMET_STORE", "Movie Mask", "~b~OPTIONS:", true, NAPI.Util.ToJson(menu_item_list), false);
            Client.TriggerEvent("ps_BodyCamera");
            Client.TriggerEvent("ps_SetCamera", 2);
            Client.TriggerEvent("FreezeEx", true);
        }
    }

    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        int.TryParse(valueList, out int value);

        if (objectName == "Maske")
        {
            if (Main.GetPlayerMoney(Client) < mask_list[value].price)
            {
                Main.SendErrorMessage(Client, "Yeterli paranız yok.");
                NAPI.Player.SetPlayerClothes(Client, 1, 0, 0);
                Main.UpdatePlayerClothes(Client);
                return;
            }

            Main.GivePlayerMoney(Client, -mask_list[value].price);
            Main.SendSuccessMessage(Client, "Başarıyla Maske satın aldınız! " + Main.EMBED_LIGHTGREEN + "(/maske)" + Main.EMBED_WHITE + "");

            NAPI.Data.SetEntitySharedData(Client, "character_mask", mask_list[value].variation);
            NAPI.Data.SetEntitySharedData(Client, "character_mask_texture", mask_list[value].texture);
            NAPI.Player.SetPlayerClothes(Client, 1, 0, 0);
            Main.UpdatePlayerClothes(Client);
        }
        else if (objectName == "Kask") 
        {
            if (Main.GetPlayerMoney(Client) < helmet_list[value].price)
            {
                Main.SendErrorMessage(Client, "Yeterli paranız yok.");
                NAPI.Player.ClearPlayerAccessory(Client, 0);
                Main.UpdatePlayerClothes(Client);
                return;
            }

            Main.GivePlayerMoney(Client, -helmet_list[value].price);
            Main.SendSuccessMessage(Client, "Başarıyla Kask satın aldınız! " + Main.EMBED_LIGHTGREEN + "(/kask)" + Main.EMBED_WHITE + "");

            NAPI.Data.SetEntitySharedData(Client, "character_helmet", helmet_list[value].variation);
            NAPI.Data.SetEntitySharedData(Client, "character_helmet_texture", helmet_list[value].texture);
            NAPI.Player.ClearPlayerAccessory(Client, 0);
            Main.UpdatePlayerClothes(Client);
        }
    


}

public static void IndexChangeMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        int.TryParse(valueList, out int value);
        if (objectName == "Maske")
        {
            NAPI.Player.SetPlayerClothes(Client, 1, mask_list[value].variation, mask_list[Convert.ToInt32(value)].texture);
        }
        else if (objectName == "Kask")
        {
            NAPI.Player.SetPlayerAccessory(Client, 0, helmet_list[value].variation, helmet_list[Convert.ToInt32(value)].texture);
        }

    }

    public static void OnMenuReturnClose(Player Client, String callbackId)
    {
        Client.TriggerEvent("FreezeEx", false);

        Client.TriggerEvent("ps_DestroyCamera");
        if (callbackId == "MASK_AND_HELMET_STORE")
        {
            NAPI.Player.SetPlayerClothes(Client, 1, 0, 0);
            NAPI.Player.ClearPlayerAccessory(Client, 0);
            Main.UpdatePlayerClothes(Client);
        }
    }

    [Command("ustunucikar", Alias = "tshirt,ceket,ust,sweet,ustgiyim")]
    public static void CMD_TOP_off(Player Client)
    {
        if (Client.HasData("duty") && Client.GetData<dynamic>("duty") == 1)
        {
            Main.DisplayErrorMessage(Client, "error", "Görevdeyken kıyafetlerinizi çıkaramazsınız.");
            return;
        }

        if (Client.HasData("character_shirt_status") == false || Client.GetData<dynamic>("character_shirt_status") != 0)
        
            
        
    

        {
        //    Main.EmoteMessage(Client, " Снимай блузку.");

            switch ((PedHash)Client.Model)
            {
                case PedHash.FreemodeFemale01:
                    NAPI.Player.SetPlayerClothes(Client, 3, 15, 0);
                    NAPI.Player.SetPlayerClothes(Client, 11, 15, 0);
                    NAPI.Player.SetPlayerClothes(Client, 8, 15, 0);
                    break;
                case PedHash.FreemodeMale01:
                    NAPI.Player.SetPlayerClothes(Client, 3, 15, 0);
                    NAPI.Player.SetPlayerClothes(Client, 8, 15, 0);
                    NAPI.Player.SetPlayerClothes(Client, 11, 15, 0);
                    break;
                default:
                    break;
            }

            NAPI.Data.SetEntityData(Client, "character_shirt_status", 0);
        }
        else
        {

        //    Main.EmoteMessage(Client, "Наденьте блузку.");

            NAPI.Data.SetEntityData(Client, "character_shirt_status", 1);
            NAPI.Player.SetPlayerClothes(Client, 11, Client.GetSharedData<dynamic>("character_shirt"), Client.GetSharedData<dynamic>("character_shirt_texture"));
            NAPI.Player.SetPlayerClothes(Client, 8, Client.GetSharedData<dynamic>("character_undershirt"), Client.GetSharedData<dynamic>("character_undershirt_texture"));
            NAPI.Player.SetPlayerClothes(Client, 3, Client.GetSharedData<dynamic>("character_torso"), 0);


        }
    }

    [Command("pantalon", Alias = "altgiyim,darpantolon,altcikart")]
    public static void CMD_Pants_off(Player Client)
    {
        if (Client.HasData("duty") && Client.GetData<dynamic>("duty") == 1)
        {
            Main.DisplayErrorMessage(Client, "error", "Görevdeyken kıyafet çıkaramazsınız.");
            return;
        }
        if (Client.HasData("character_leg_status") == false || Client.GetData<dynamic>("character_leg_status") != 0)
        {
            switch ((PedHash)Client.Model)
            {
                case PedHash.FreemodeFemale01:
                    NAPI.Player.SetPlayerClothes(Client, 4, 15, 0);
                    break;
                case PedHash.FreemodeMale01:
                    NAPI.Player.SetPlayerClothes(Client, 4, 61, 0);
                    break;
                default:
                    break;
            }

            NAPI.Data.SetEntityData(Client, "character_leg_status", 0);
        }
        else
       
        {

          //  Main.EmoteMessage(Client, "Наденьте штаны.");

            NAPI.Data.SetEntityData(Client, "character_leg_status", 1);
            NAPI.Player.SetPlayerClothes(Client, 4, Client.GetSharedData<dynamic>("character_leg"), Client.GetSharedData<dynamic>("character_leg_texture"));
        }
    }

    //accs
    [Command("aksesuar", Alias = "accessories,accs")]
    public static void CMD_Acc_off(Player Client)
    {

        if (Client.HasData("character_accessories_status") == false || Client.GetData<dynamic>("character_accessories_status") != 0)
        {
           //Main.EmoteMessage(Client, " Снимите лишнюю одежду.");

            switch ((PedHash)Client.Model)
            {
                case PedHash.FreemodeFemale01:
                    NAPI.Player.SetPlayerClothes(Client, 7, 0, 0);
                    break;
                case PedHash.FreemodeMale01:
                    NAPI.Player.SetPlayerClothes(Client, 7, 0, 0);
                    break;
                default:
                    break;
            }

            NAPI.Data.SetEntityData(Client, "character_accessories_status", 0);
        }
        else
        {

          //  Main.EmoteMessage(Client, "Lebas Ezafe ra poshid.");

            NAPI.Data.SetEntityData(Client, "character_accessories_status", 1);
            NAPI.Player.SetPlayerClothes(Client, 7, Client.GetSharedData<dynamic>("character_accessories"), Client.GetSharedData<dynamic>("character_accessories_texture"));
        }
    }

    [Command("ayakkabi", Alias = "terlik,bot,shoe")]
    public static void CMD_shoes_off(Player Client)
    {
        if (Client.HasData("duty") && Client.GetData<dynamic>("duty") == 1)
        {
            Main.DisplayErrorMessage(Client, "error", "Görevde olduğunuz için ayakkabı çıkaramazsınız.");
            return;
        }
        if (Client.HasData("character_feet_status") == false || Client.GetData<dynamic>("character_feet_status") != 0)
        {
              //Main.EmoteMessage(Client, " Ayakkabı çıkarılıyor.");

            switch ((PedHash)Client.Model)
            {
                case PedHash.FreemodeFemale01:
                    NAPI.Player.SetPlayerClothes(Client, 6, 35, 0);
                    break;
                case PedHash.FreemodeMale01:
                    NAPI.Player.SetPlayerClothes(Client, 6, 34, 0);
                    break;
                default:
                    break;
            }

            NAPI.Data.SetEntityData(Client, "character_feet_status", 0);
        }

        else
        {

         //   Main.EmoteMessage(Client, "Носить обувь.");

            NAPI.Data.SetEntityData(Client, "character_feet_status", 1);
            NAPI.Player.SetPlayerClothes(Client, 6, Client.GetSharedData<dynamic>("character_feet"), Client.GetSharedData<dynamic>("character_feet_texture"));
        }
    }

    [Command("maske", Alias = "mask")]
    public static void CMD_Mascara(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "character_mask") == 0)
        {
            InteractMenu_New.SendNotificationError(Client, "Maskeniz yok.");
            return;
        }
        if (Client.GetSharedData<dynamic>("using_mask"))
        {
            Main.EmoteMessage(Client, "yüzündeki maskeyi çıkartır.");

            NAPI.Player.SetPlayerClothes(Client, 1, 0, 0);
            NAPI.Data.SetEntitySharedData(Client, "using_mask", false);
        }
        else
        {
            var temp_mask = NAPI.Data.GetEntitySharedData(Client, "character_mask");
            var temp_mask_texture = NAPI.Data.GetEntitySharedData(Client, "character_mask_texture");

            Main.EmoteMessage(Client, "maskeyi yüzüne takar.");

            NAPI.Data.SetEntitySharedData(Client, "using_mask", true);
            NAPI.Player.SetPlayerClothes(Client, 1, (int)temp_mask, (int)temp_mask_texture);
        }
    }

    public static void CMD_Mascara(Player Client,bool state)
    {
        if (state == false)
        {
            NAPI.Data.SetEntitySharedData(Client, "using_mask", false);
        }
        else
        {
            NAPI.Data.SetEntitySharedData(Client, "using_mask", true);
        }
    }

    public static void RemoveMaskFromPlayer(Player Client)
    {
        NAPI.Player.SetPlayerClothes(Client, 1, 0, 0);
        NAPI.Data.SetEntitySharedData(Client, "using_mask", false);
    }

    [Command("kask", Alias = "helmet")]
    public static void CMD_capacete(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "character_helmet") == 0)
        {
            InteractMenu_New.SendNotificationError(Client, "Kaskınız yok.");
            return;
        }
        if (seatbelt[Main.getIdFromClient(Client)])
        {
            Main.EmoteMessage(Client, "kaskı başından çıkarır.");
            seatbelt[Main.getIdFromClient(Client)] = false;
            NAPI.Player.ClearPlayerAccessory(Client, 0);
            Client.SetSharedData("helmet", -1);
            Client.SetSharedData("helmet_texture", 0);
            Main.UpdatePlayerClothes(Client);
        }
        else
        {
            var helmet = NAPI.Data.GetEntitySharedData(Client, "character_helmet");
            var helmet_texture = NAPI.Data.GetEntitySharedData(Client, "character_helmet_texture");

            Main.EmoteMessage(Client, "kaskı başına geçirir.");

            seatbelt[Main.getIdFromClient(Client)] = true;
            NAPI.Player.SetPlayerAccessory(Client, 0, (int)helmet, (int)helmet_texture);

            Client.SetSharedData("helmet", helmet);
            Client.SetSharedData("helmet_texture", helmet_texture);
        }
    }


    [RemoteEvent("helmet_sync")]
    public static void CapaceteSync(Player Client)
    {
        foreach (var entity in API.Shared.GetAllPlayers())
        {
            entity.TriggerEvent("helmet_falses");
            if (entity.GetData<dynamic>("status") == true && seatbelt[Main.getIdFromClient(entity)])
            {
                var helmet = NAPI.Data.GetEntitySharedData(entity, "character_helmet");
                var helmet_texture = NAPI.Data.GetEntitySharedData(entity, "character_helmet_texture");

                NAPI.Player.SetPlayerAccessory(entity, 0, (int)helmet, (int)(int)helmet_texture);
            }
        }
    }
    [Command("emniyetkemeri", Alias = "sb,seatbelt,em", GreedyArg = true)]
    public static void CMD_seatbelt(Player Client)
    {
        if (!Client.IsInVehicle)
        {
            InteractMenu_New.SendNotificationError(Client, "Araçta değilsiniz.");
            return;
        }

        if (Client.Vehicle.Class == 8 || Client.Vehicle.Class == 13)
        {
            InteractMenu_New.SendNotificationError(Client, "Bu araçta emniyet kemeri takamazsınız.");
            return;
        }

        if (seatbelt[Main.getIdFromClient(Client)])
        {
            Main.DisplayErrorMessage(Client, "info", "Emniyet kemerini çıkardınız.");

            Main.EmoteMessage(Client, "emniyet kemerini çıkartır.");
            seatbelt[Main.getIdFromClient(Client)] = false;
        }
        else
        {
            Main.DisplayErrorMessage(Client, "info", "Emniyet kemerini taktınız.");

            Main.EmoteMessage(Client, "emniyet kemerini takar.");
            seatbelt[Main.getIdFromClient(Client)] = true;
        }
    }

    [Command("kemerkontrol", "~y~[!]~w~: /kemerkontrol [ID/İsim]", Alias = "checkbelt, kk", GreedyArg = true)]
    public void CMD_checarcinto(Player Client, string idOrName)
    {
        Player target = Main.findPlayer(Client, idOrName);
        if (target == null)
        {
            Main.SendErrorMessage(Client, "Geçersiz ID.");
            return;
        }

        if (!target.IsInVehicle)
        {
            Main.SendErrorMessage(Client, "Oyuncu araçta değil.");
            return;
        }

        if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 10.0f))
        {
            Main.SendErrorMessage(Client, "Oyuncu çok uzakta.");
            return;
        }

        if (seatbelt[Main.getIdFromClient(Client)])
        {
            Main.SendInfoMessage(Client, "~c~Oyuncunun emniyet kemeri takılı.");
        }
        else
        {
            Main.SendInfoMessage(Client, "~c~Oyuncunun emniyet kemeri takılı değil.");
        }
    }

    public static void SendRoleplayAction(Player Client, string msg)
    {
        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(10, Client);
        foreach (Player target in proxPlayers)
        {
            target.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* <font color ='#C2A2DA'> " + GetPlayerNameToTarget(Client, target) + "", "<font color ='#C2A2DA'>" + msg);
        }
        Main.EmoteMessage(Client, msg);
    }

    public static string GetPlayerNameToTarget(Player Client, Player target)
    {
        if (Client.GetSharedData<dynamic>("using_mask"))
        {
            return "Maske_" + AccountManage.GetPlayerSQLID(Client);
        }
        else
        {
            bool can_pass = true;
            for (int index = 0; index < Main.MAX_PLAYERS; index++)
            {
                if (target.GetSharedData<dynamic>("know_player_" + index) == AccountManage.GetPlayerSQLID(Client))
                {
                    return target.GetSharedData<dynamic>("know_name_" + index);

                }
            }

            if (can_pass == true)
            {
                if (Client == target)
                {
                    return AccountManage.GetCharacterName(Client);
                }
                else
                {
                    return AccountManage.GetCharacterName(Client);
                }
            }
        }
        return AccountManage.GetCharacterName(Client);
    }
}

