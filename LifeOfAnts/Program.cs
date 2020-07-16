﻿using System;
using LifeOfAnts.Logic;

namespace LifeOfAnts
{
    public class Program
    {
        private HiveMap _map;
        private HiveMap _map2;
        private int roundCounter;
        private bool shouldContinue = true;

        public static void Main()
        {
            new Program();
        }

        private Program()
        {
            _map = HiveMapLoader.InitiateMap(20);
            string pause = Console.ReadLine();
            do { _map = HiveMapLoader.UpdateMap(_map);
                //_map.DrawMap();
                //_map2.DrawMap();
                string userInput = Console.ReadLine();

                if (userInput == "q")
                {
                    ShouldContinue = false;
                }
            }
            while (!ShouldContinue);
            

        }
        public bool ShouldContinue { get; set; }
    }
}
