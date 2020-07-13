using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    [Serializable]
    public class Drone : Ant
    {
        public Drone(Cell cell) : base(cell) { }
        public override bool IsNotPassable => true;

        public override char Symbol => 'D';

        public override Tuple<int, int> PlanMove()
        {
            throw new NotImplementedException();
        }

        public override void GenerateAnts(ref HiveMap map)
        {
            throw new NotImplementedException();
        }

        public int Counter { get; set; }
    }
}
