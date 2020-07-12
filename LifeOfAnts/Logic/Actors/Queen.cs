using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    public class Queen:Ant
    {
        //public List<string> allFieldsType = new List<string>();
        public Queen(Cell cell) : base(cell) {
        
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
                                break;
                            case "worker":
                                cell.Ant = new Worker(cell);
                                Console.WriteLine("Worker created");
                                cell.PrintCoords();
                                break;
                            case "soldier":
                                cell.Ant = new Soldier(cell);
                                Console.WriteLine("Soldier created");
                                cell.PrintCoords();
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
            int dronePopulation = (int)(numberOfFields * 0.005);
            int workerPopulation = (int)(numberOfFields * 0.01);
            int soldierPopulation = (int)(numberOfFields * 0.03);
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
                    Console.WriteLine(kvp.Key);
                }
            }
            List<string> shuffledAllFieldsType = allFieldsType.OrderBy(x => Guid.NewGuid()).ToList();
            //shuffledAllFieldsType[(int)numberOfFields / 2] = "queen";
            //Console.WriteLine(shuffledAllFieldsType.Count());
            return shuffledAllFieldsType;


        }
        public override bool IsNotPassable => true;

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
            Console.WriteLine("Queen check for mood");
        }

    }
}
