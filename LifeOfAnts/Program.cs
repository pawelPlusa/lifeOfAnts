using System;
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
            _map = HiveMapLoader.InitiateMap(10);
           // _map.DrawMap();
            string pause = Console.ReadLine();
            //_map2 = HiveMapLoader.UpdateMap(_map);
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
            
            //foreach(string test111 in test1.allFieldsType)
            //{
            //    Console.WriteLine(test111);
            //}
            //_map = new HiveMap(203,203);

        }
        public bool ShouldContinue { get; set; }
    }
}
