using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    [Serializable]
    public class Soldier : Ant
    {
        private int _whichMoveDir = 0;
        public Soldier(Cell cell) : base(cell) {        }
        // public override bool IsNotPassable => true;

        public override char Symbol => 'S';

        //public override void Move()
        //{ }


        public override void GenerateAnts(ref HiveMap map)
        {
            throw new NotImplementedException();
        }

        public override Tuple<int, int> PlanMove()
        {
 
            if (!this.Cell.ActualMap.IsWaspOnMap)
            {
                List<(int, int)> movingOptions = new List<(int, int)>
            {
                (1,0),(0,1),(-1,0),(0,-1)
            };
                _whichMoveDir = (_whichMoveDir < movingOptions.Count - 1) ? ++_whichMoveDir : 0;
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
            } else
            {
                int waspIndex = 0;
                for(int i = 0; i<Cell.ActualMap.AllActors.Count; i++)
                {
                    if (Cell.ActualMap.AllActors[i].Symbol == '8')
                    {
                        waspIndex = i;
                    }
                }
                int SoldierX = this.X;
                int SoldierY = this.Y;

                int WaspX = Cell.ActualMap.AllActors[waspIndex].X;
                int WaspY = Cell.ActualMap.AllActors[waspIndex].Y;

                if ((Math.Abs(WaspX - SoldierX) == 1 && Math.Abs(WaspY - SoldierY) == 0) ||
                (Math.Abs(WaspX - SoldierX) == 0 && Math.Abs(WaspY - SoldierY) == 1))
                {
                    Console.WriteLine("Killing wasp!");
                    //is any way to make it shorter? use destructor? Get rid only Cell.Actor = null?
                    //Cell waspCell = Cell.ActualMap.GetCell(WaspX, WaspY);
                    //waspCell = new Cell(Cell.ActualMap, WaspX,WaspY);
                    //Console.WriteLine(Cell.ActualMap.GetCell(WaspX, WaspY).Actor.GetType());
                    
                    Actor wasp = Cell.ActualMap.AllActors[waspIndex];
                    //wasp.Cell = new Cell(Cell.ActualMap, WaspX, WaspY);
                    Console.WriteLine("wasp coords" + wasp.X + ","+ wasp.Y);
                    //wasp.Cell.Actor.IsNotPassable = false;
                    wasp.Cell.Actor = null;
                    wasp.Cell.Actor.IsNotPassable = false;
                    
                    
                    
                    
                    Cell.ActualMap.AllActors.RemoveAt(waspIndex);
                    foreach(Actor singleAct in Cell.ActualMap.AllActors)
                    {
                        Console.WriteLine(singleAct);
                    }
                    
                    Cell.ActualMap.IsWaspOnMap = false;
                    Cell.ActualMap.WaspSpawnCounter = Extensions.MyRandomNumberGenerator(10, 12);

                    return new Tuple<int, int>(SoldierX, SoldierY);
                }

                if (WaspX > SoldierX && (!this.Cell.GetNeighbor(SoldierX + 1, SoldierY).Actor?.IsNotPassable ?? true))
                {
                    return new Tuple<int, int>(SoldierX + 1, SoldierY);
                }
                else if (WaspX < SoldierX && (!this.Cell.GetNeighbor(SoldierX - 1, SoldierY).Actor?.IsNotPassable ?? true))
                {
                    return new Tuple<int, int>(SoldierX - 1, SoldierY);
                }
                else if (WaspY > SoldierY && (!this.Cell.GetNeighbor(SoldierX, SoldierY + 1).Actor?.IsNotPassable ?? true))
                {
                    return new Tuple<int, int>(SoldierX, SoldierY + 1);
                }
                else if (WaspY < SoldierY && (!this.Cell.GetNeighbor(SoldierX, SoldierY - 1).Actor?.IsNotPassable ?? true))
                {
                    return new Tuple<int, int>(SoldierX, SoldierY - 1);
                }
                else { return new Tuple<int, int>(SoldierX, SoldierY); }



                Console.WriteLine("Heading towards Wasp");
                return new Tuple<int, int>(Cell.X, Cell.Y);
            }
        }

        //public override void Move()
        //{
        //    Console.WriteLine("Move from soldeir");
        //}
    }
}
