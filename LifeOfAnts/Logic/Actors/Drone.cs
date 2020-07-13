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
            int QueenX = Cell.ActualMap.AllActors[0].X;
            int QueenY = Cell.ActualMap.AllActors[0].Y;
            int DroneX = this.X;
            int DroneY = this.Y;
            if((Math.Abs(QueenX-DroneX)==1 && Math.Abs(QueenY - DroneY) == 0) || 
                Math.Abs(QueenX - DroneX) == 0 && Math.Abs(QueenY - DroneY) == 1)
            {
                Console.WriteLine("Time for meeting");
                return new Tuple<int, int>(DroneX, DroneY);
            }

            if(QueenX>DroneX && (!this.Cell.GetNeighbor(DroneX+1,DroneY).Actor?.IsNotPassable ?? true))
            {
                return new Tuple<int, int>(DroneX + 1, DroneY);
            }
            else if(QueenX<DroneX && (!this.Cell.GetNeighbor(DroneX-1,DroneY).Actor?.IsNotPassable ?? true))
            {
                return new Tuple<int, int>(DroneX - 1, DroneY);
            }
            else if(QueenY>DroneY && (!this.Cell.GetNeighbor(DroneX,DroneY+1).Actor?.IsNotPassable ?? true))
            {
                return new Tuple<int, int>(DroneX, DroneY + 1);
            }
            else if(QueenY<DroneY && (!this.Cell.GetNeighbor(DroneX, DroneY -1).Actor?.IsNotPassable ?? true))
            {
                return new Tuple<int, int>(DroneX, DroneY - 1);
            }
            else { return new Tuple<int, int>(DroneX, DroneY); }

        }

        public override void GenerateAnts(ref HiveMap map)
        {
            throw new NotImplementedException();
        }

        public int Counter { get; set; }
    }
}
