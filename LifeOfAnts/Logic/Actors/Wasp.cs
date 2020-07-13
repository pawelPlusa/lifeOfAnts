using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    [Serializable]
    class Wasp : Actor

       
    {
        public Wasp(Cell cell) : base(cell) { }
        public override bool IsNotPassable => throw new NotImplementedException();

        public override char Symbol => throw new NotImplementedException();

        public override Tuple<int, int> PlanMove()
        {
            throw new NotImplementedException();
        }
    }
}
