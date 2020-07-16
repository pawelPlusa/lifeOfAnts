using System;
using System.Text;
using LifeOfAnts.Logic;

namespace LifeOfAnts
{
    public class Program
    {
        private HiveMap _map;
        //private HiveMap _map2;
        //private int roundCounter;
        //private bool shouldContinue = true;

        public static void Main()
        {
            new Program();
        }

        private Program()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.White;
            _map = HiveMapLoader.InitiateMap(20);
            string pause = Console.ReadLine();
            do { _map = HiveMapLoader.UpdateMap(_map);
                string userInput = Console.ReadLine();
                if (userInput == "q")
                {
                    ShouldContinue = true;
                }
            }
            while (!ShouldContinue);
            

        }
        public bool ShouldContinue { get; set; }
    }
}
