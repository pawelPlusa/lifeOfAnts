using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    [Serializable]
    class Wasp : Actor

       
    {
        public Wasp(Cell cell) : base(cell) {
            Console.WriteLine("Wasp created at: {0},{1}", this.Cell.X, this.Cell.Y);
            cell.ActualMap.IsWaspOnMap = true;
            IsWaspIsKilled = false;
        }
        ~Wasp()
        {
            IsNotPassable = false;
            Console.WriteLine("wasp destructor");
        }

        public override char Symbol => '8';

        public override Tuple<int, int> PlanMove()
        {
            return new Tuple<int, int>(this.Cell.X, this.Cell.Y);
        }

        //public override void Move()
        //{
        //    if (IsWaspIsKilled)
        //    {
        //        //Actor wasp = Cell.ActualMap.AllActors[waspIndex];
        //        //wasp.Cell = new Cell(Cell.ActualMap, WaspX, WaspY);
        //        //Console.WriteLine("wasp coords" + wasp.X + "," + wasp.Y);
        //        this.Cell.Actor.IsNotPassable = false;
        //        this.Cell.Actor = null;
        //    }
        //}

        public bool IsWaspIsKilled { get; set; }

    }
}
