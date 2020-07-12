using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    public class Soldier : Ant
    {
        public Soldier(Cell cell) : base(cell) { }
        public override bool IsNotPassable => true;

        public override char Symbol => 'S';

        //public override void Move()
        //{ }


        public override void GenerateAnts(ref HiveMap map)
        {
            throw new NotImplementedException();
        }

        public override Tuple<int, int> PlanMove()
        {
            throw new NotImplementedException();
        }
    }
}
