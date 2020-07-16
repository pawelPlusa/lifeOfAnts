using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    [Serializable]
    public class Queen:Ant
    {
        private int moodCounter;
        private bool readyForMating;
        private int matingCounter;
        private bool injected;
        //public List<string> allFieldsType = new List<string>();
        public Queen(Cell cell) : base(cell) {
            Console.WriteLine("CRFEATING QUEEN");
            MoodCounter = RandomMoodSetter();
            ReadyForMating = false;
            Injected = false;
            MatingCounter = 0;
            
        }
        public int MatingCounter { get; set; }
        public bool Injected { get; set; }
        public bool ReadyForMating { get; set; }
        public int MoodCounter { get; set; }
        private int RandomMoodSetter()
        {
            Random numberGenerator = new Random();
            //int moodCounter = numberGenerator.Next(50, 101);
            //return moodCounter;
            return numberGenerator.Next(10, 20);
        }
        public override void GenerateAnts(ref HiveMap map)
        {

            List<string> listOfPopulatedFields = PopulateList(map.Dimensions);
            int listCounter = 0;
            for(int x = 0; x<map.Dimensions; x++)
            {
                for (int y = 0; y < map.Dimensions; y++)
                {
                    Cell cell = map.GetCell(x, y);
                    if (!cell.Ant?.IsNotPassable ?? true)
                    {
                        //Console.WriteLine("chuj");
                        switch (listOfPopulatedFields[listCounter])
                        {
                            case "drone":
                                cell.Ant = new Drone(cell);
                                Console.WriteLine("Drone created");
                                cell.PrintCoords();
                                map.AllActors.Add(cell.Ant);

                                break;
                            case "worker":
                                cell.Ant = new Worker(cell);
                                Console.WriteLine("Worker created");

                                cell.PrintCoords();
                                map.AllActors.Add(cell.Ant);
                                break;
                            case "soldier":
                                cell.Ant = new Soldier(cell);
                                Console.WriteLine("Soldier created");
                                cell.PrintCoords();
                                map.AllActors.Add(cell.Ant);
                                break;

                        }
                        
                    }
                    else { }
                    listCounter++;

                }
            }
            map.DrawMap();


        }
        public List<string> PopulateList(int dimensions)
        {
            List<string> allFieldsType = new List<string>();
            double numberOfFields = Math.Pow(dimensions, 2);
            int dronePopulation = (int)(numberOfFields * 0.02);
            int workerPopulation = (int)(numberOfFields * 0.02);
            int soldierPopulation = (int)(numberOfFields * 0.02);
            int emptyFields = (int)numberOfFields - (dronePopulation + workerPopulation + soldierPopulation);
            Console.WriteLine($"no fields:{numberOfFields}, drone: {dronePopulation}, worker: {workerPopulation}, soldier:{soldierPopulation}" +
                $"all insects sum:{dronePopulation + workerPopulation + soldierPopulation}, empty fields: {emptyFields}");


            var dataToPopulate = new Dictionary<string, int>()
            {
            {"drone", dronePopulation },
            {"worker", workerPopulation },
            {"soldier", soldierPopulation },
            {"empty", emptyFields }
            };
            foreach (KeyValuePair<string, int> kvp in dataToPopulate)
            {

                for (int i = 0; i < kvp.Value; i++)
                {
                    allFieldsType.Add(kvp.Key);
                    //Console.WriteLine(kvp.Key);
                }
            }
            List<string> shuffledAllFieldsType = allFieldsType.OrderBy(x => Guid.NewGuid()).ToList();
            //shuffledAllFieldsType[(int)numberOfFields / 2] = "queen";
            //Console.WriteLine(shuffledAllFieldsType.Count());
            return shuffledAllFieldsType;


        }
        //public override bool IsNotPassable => true;

        public override char Symbol => 'Q';

        public override Tuple<int, int> PlanMove()
        {
            throw new NotImplementedException();
        }
        //public new bool Move() {
        //    //instead of move Queen has mood generator
        //    return true;
        //}
        public override void Move()
        {
            //instead of move Queen has mood generator
            Console.WriteLine("");
            
            if (MoodCounter > 0)
            {
                Console.WriteLine("Mood counter: {0}", MoodCounter);
                MoodCounter--;
            }
            else
            {
                Console.WriteLine("READY FOR MATING");
                ReadyForMating = true;
            }

            if (Injected && MatingCounter < 10) 
            { 
                ++MatingCounter; 
                Console.WriteLine("RFM:"+ReadyForMating); 
                MoodCounter = 100; 
            }
            else if (Injected && MatingCounter == 10)
            {
                Console.WriteLine("Reseting after mating");
                MoodCounter = RandomMoodSetter();
                Injected = false;
                MatingCounter = 0;
                ReadyForMating = false;
            }
        }

    }
}
