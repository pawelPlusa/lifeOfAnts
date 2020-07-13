using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    [Serializable]
    public class Soldier : Ant
    {
        private int _whichMoveDir = 0;
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
            _whichMoveDir = (_whichMoveDir < movingOptions.Count-1) ? ++_whichMoveDir : 0;
            int nextCellX = Cell.X + movingOptions[_whichMoveDir].Item1;
            int nextCellY = Cell.Y + movingOptions[_whichMoveDir].Item2;

            if (nextCellX < 0 || nextCellY < 0 || nextCellX > Cell.ActualMap.Dimensions - 1
                || nextCellY > Cell.ActualMap.Dimensions - 1)
            {
                return new Tuple<int, int>(Cell.X, Cell.Y);
            }
            else
            {
                return new Tuple<int, int>(nextCellX, nextCellY);
            }
        }

        //public override void Move()
        //{
        //    Console.WriteLine("Move from soldeir");
        //}
    }
}
