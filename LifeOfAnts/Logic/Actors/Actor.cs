using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts.Logic.Actors
{
    [Serializable]
    public abstract class Actor:IDrawable
    {

        public Cell Cell { get; protected set; }
        public Actor(Cell cell)
        {
            Cell = cell;
            Cell.Actor = this;
            IsNotPassable = true;
        }
        public Queen Queen;
        
        //Method which would be different for derived classes
        //thanks to that approach all classes can implement same Move method 
        //(except Queen -> look for queen Move Method comment) 
        public abstract Tuple<int,int> PlanMove();
        
        public virtual void Move()
        {
            Tuple<int, int> moveCoords = PlanMove();

            Cell nextCell = Cell.GetNeighbor(moveCoords.Item1, moveCoords.Item2);

            if (!nextCell.Actor?.IsNotPassable ?? true)
            {
                Cell.Actor = null;
                nextCell.Actor = this;
                Cell = nextCell;
            }
            else
            {
                //Console.WriteLine("else move");
            }
        }
        public virtual bool IsNotPassable { get; set; }


        /// <summary>
        /// Gets the X position
        /// </summary>
        public int X => Cell.X;

        /// <summary>
        /// Gets the Y position
        /// </summary>
        public int Y => Cell.Y;


        public abstract char Symbol { get; }
    }
}
