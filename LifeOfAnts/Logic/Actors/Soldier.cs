using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    [Serializable]
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
            List<(int, int)> movingOptions = new List<(int, int)>
            {
                (1,0),(0,1),(-1,0),(0,-1)
            };
            Random diece = new Random();
            int randomisedNumber = diece.Next(0, 3);
            int nextCellX = Cell.X + movingOptions[randomisedNumber].Item1;
            int nextCellY = Cell.Y + movingOptions[randomisedNumber].Item2;
            return new Tuple<int, int>(nextCellX, nextCellY);
        }

        public override void Move()
        {
            Console.WriteLine("Move from soldeir");
        }
    }
}
