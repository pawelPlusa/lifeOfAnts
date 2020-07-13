using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeOfAnts
{
    class PopulateMap
    {
        public List<string> allFieldsType = new List<string>();
        //public Dictionary<string, int> dataToPopulate = new Dictionary<string, int>();

        //public PopulateMap(int dimensions) {
        //    allFieldsType = PopulateList(dimensions);
        //    //
        //     }

        //public List<string> AllFieldsType { get;  }
        //public List<string> PopulateList(int dimensions)
        //{
        //    double numberOfFields = Math.Pow(dimensions, 2);
        //    int dronePopulation = (int)(numberOfFields * 0.005);
        //    int workerPopulation = (int)(numberOfFields * 0.01);
        //    int soldierPopulation = (int)(numberOfFields * 0.03);
        //    int emptyFields = (int)numberOfFields - (dronePopulation+workerPopulation+soldierPopulation);
        //    Console.WriteLine($"no fields:{numberOfFields}, drone: {dronePopulation}, worker: {workerPopulation}, soldier:{soldierPopulation}" +
        //        $"all insects sum:{dronePopulation+workerPopulation+soldierPopulation}, empty fields: {emptyFields}");


        //    var dataToPopulate = new Dictionary<string, int>()
        //    {
        //    {"drone", dronePopulation },
        //    {"worker", workerPopulation },
        //    {"soldier", soldierPopulation },
        //    {"empty", emptyFields }
        //    };
        //    foreach (KeyValuePair<string, int> kvp in dataToPopulate)
        //    {

        //        for (int i = 0; i < kvp.Value; i++)
        //        {
        //            allFieldsType.Add(kvp.Key);
        //            //Console.WriteLine(kvp.Key);
        //        }
        //    }
        //    List<string> shuffledAllFieldsType = allFieldsType.OrderBy(x => Guid.NewGuid()).ToList();
        //    shuffledAllFieldsType[(int)numberOfFields/2]= "queen";
        //    //Console.WriteLine(shuffledAllFieldsType.Count());
        //    return shuffledAllFieldsType;
            

        //}


    }
}
