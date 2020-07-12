using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    public abstract class Actor:IDrawable
    {

        public Cell Cell { get; protected set; }
        public Actor(Cell cell)
        {
            Cell = cell;
            Cell.Actor = this;
        }
        public abstract Tuple<int,int> PlanMove();
        
        public virtual void Move()
        //public void Move(Tuple<int, int> nextMoveCoords)
        {
            Tuple<int, int> moveCoords = PlanMove();
            Console.WriteLine(this.Symbol + " is moving");

            Cell nextCell = Cell.GetNeighbor(moveCoords.Item1, moveCoords.Item2);

            if (!nextCell.Actor?.IsNotPassable ?? true)
            {
                Cell.Actor = null;
                nextCell.Actor = this;
                Cell = nextCell;
            }
            else
            {
                Console.WriteLine("else move");
            }
        }
        public abstract bool IsNotPassable { get; }

        /// <summary>
        /// Gets the X position
        /// </summary>
        public int X => Cell.X;

        /// <summary>
        /// Gets the Y position
        /// </summary>
        public int Y => Cell.Y;

        //public abstract string Tilename => "actor";

        public abstract char Symbol { get; }
    }
}
