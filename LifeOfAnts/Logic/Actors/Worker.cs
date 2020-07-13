using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    [Serializable]
    public class Worker:Ant
    {
        public Worker(Cell cell) : base(cell) { }


        public override bool IsNotPassable => true;

        public override char Symbol => 'W';

        public override void GenerateAnts(ref HiveMap map)
        {
            throw new NotImplementedException();
        }

        public override Tuple<int, int> PlanMove()
        {
            //Tuple<int, int> currentCoords = new Tuple<int, int>(Cell.X, Cell.Y);
            //int currentX = Cell.X;
            //int currentY = Cell.Y;
            List<(int,int)> movingOptions = new List<(int,int)>
            {
                (1,0),(0,1),(-1,0),(0,-1)
            };
            Random diece = new Random();
            int randomisedNumber = diece.Next(0, 4);
            Console.WriteLine("RN: {0}",randomisedNumber);
            int nextCellX = Cell.X + movingOptions[randomisedNumber].Item1;
            int nextCellY = Cell.Y + movingOptions[randomisedNumber].Item2;
            if (nextCellX < 0 || nextCellY < 0 || nextCellX >Cell.ActualMap.Dimensions - 1
                || nextCellY > Cell.ActualMap.Dimensions - 1)
            {
                return new Tuple<int, int>(Cell.X, Cell.Y);
            }
            else
            {
                return new Tuple<int, int>(nextCellX, nextCellY);
            }
        }
    }
}
