using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    [Serializable]
    public class Drone : Ant
    {
        private int matingCounter;
        public Drone(Cell cell) : base(cell) {
            MatingCounter = 0;
        }
        public int MatingCounter { get; set; }

        //public override bool IsNotPassable => true;

        public override char Symbol => 'D';

        public override Tuple<int, int> PlanMove()
        {
            int QueenX = Cell.ActualMap.AllActors[0].X;
            int QueenY = Cell.ActualMap.AllActors[0].Y;
            int DroneX = this.X;
            int DroneY = this.Y;
            //Casting actor to Queen to use Queen methods - IS OTHER WAY?????????????????????????????????????????
            // **********************************************
            Queen queen = (Queen)(Cell.ActualMap.AllActors[0]);

            if (!this.Cell.ActualMap.IsWaspOnMap)
            {
                //if for checking if next to queen
                if ((Math.Abs(QueenX - DroneX) == 1 && Math.Abs(QueenY - DroneY) == 0) ||
                (Math.Abs(QueenX - DroneX) == 0 && Math.Abs(QueenY - DroneY) == 1))
                {
                    //if for checking if ready for mating
                    //if yes statring mating counter
                    //if not/finished beeing kicked


                    if (queen.ReadyForMating)
                    {
                        //Console.WriteLine(queen.ReadyForMating);
                        Console.WriteLine("Time for meeting");
                        MatingCounter++;
                        queen.ReadyForMating = false;
                        queen.Injected = true;

                        return new Tuple<int, int>(DroneX, DroneY);
                    }
                    else if (MatingCounter > 0 && MatingCounter < 10)
                    {
                        MatingCounter++;
                        Console.WriteLine("Mating in progress for: {0} turns", MatingCounter);
                        return new Tuple<int, int>(DroneX, DroneY);
                    }
                    else
                    {
                        //Console.WriteLine("Kicked");
                        MatingCounter = 0;
                        Tuple<int, int> whereKickDrone = DroneKickOutCoords();
                        return whereKickDrone;

                        //is any way to shorten it to one line like something like this:
                        //return new Tuple<int, int>(DroneKickOutCoords());

                    }
                }
                // how drone is heading towards Queen
                if (QueenX > DroneX && (!this.Cell.GetNeighbor(DroneX + 1, DroneY).Actor?.IsNotPassable ?? true))
                {
                    return new Tuple<int, int>(DroneX + 1, DroneY);
                }
                else if (QueenX < DroneX && (!this.Cell.GetNeighbor(DroneX - 1, DroneY).Actor?.IsNotPassable ?? true))
                {
                    return new Tuple<int, int>(DroneX - 1, DroneY);
                }
                else if (QueenY > DroneY && (!this.Cell.GetNeighbor(DroneX, DroneY + 1).Actor?.IsNotPassable ?? true))
                {
                    return new Tuple<int, int>(DroneX, DroneY + 1);
                }
                else if (QueenY < DroneY && (!this.Cell.GetNeighbor(DroneX, DroneY - 1).Actor?.IsNotPassable ?? true))
                {
                    return new Tuple<int, int>(DroneX, DroneY - 1);
                }
                else { return new Tuple<int, int>(DroneX, DroneY); }
            } else { return new Tuple<int, int>(DroneX, DroneY); }

        }
        public Tuple<int,int> DroneKickOutCoords()
        {
            int QueenX = Cell.ActualMap.AllActors[0].X;
            int QueenY = Cell.ActualMap.AllActors[0].Y;
            List<(int,int)> possibleKickoutCoords = new List<(int, int)>
            { (0,QueenY), (QueenX,QueenY*2-1), (QueenX*2-1, QueenY), (QueenX,0) };
            List<(int, int)> shuffledKickoutCoords = possibleKickoutCoords.OrderBy(x => Guid.NewGuid()).ToList();
           
            // checking if kickout cell is free if not removes from list and takes next last untill free or empty list

            while (shuffledKickoutCoords.Count > 0)
            {
                if (this.Cell.GetNeighbor(shuffledKickoutCoords[shuffledKickoutCoords.Count - 1].Item1,
                    shuffledKickoutCoords[shuffledKickoutCoords.Count - 1].Item2).Actor?.IsNotPassable ?? false)
                {
                    //Console.WriteLine("Field {0} was occupied",shuffledKickoutCoords[shuffledKickoutCoords.Count-1] );
                    shuffledKickoutCoords.RemoveAt(shuffledKickoutCoords.Count - 1);
                }
                else
                {
                    Console.WriteLine("Drone kickout");
                    return new Tuple<int, int>(shuffledKickoutCoords[shuffledKickoutCoords.Count - 1].Item1,
                    shuffledKickoutCoords[shuffledKickoutCoords.Count - 1].Item2);
                }

            }
            return new Tuple<int, int>(this.X, this.Y)

            ;
        }
        public override void GenerateAnts(ref HiveMap map)
        {
            throw new NotImplementedException();
        }

        public int Counter { get; set; }
    }
}
