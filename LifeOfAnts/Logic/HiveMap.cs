using LifeOfAnts.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts
{
    [Serializable]
    public class HiveMap
    {
        private Cell[,] _cells;
        private string testString = "org";
        public HiveMap(int dimensions)
        {
            Dimensions = dimensions;
            Width = dimensions;
            Height = dimensions;
            _cells = new Cell[Width, Height];
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    _cells[x, y] = new Cell(this,x, y);
                }
            }
        }
        public HiveMap ShallowCopy()
        {
            return (HiveMap)this.MemberwiseClone();
        }
        public HiveMap DeepCopy()
        {
            HiveMap copy = (HiveMap)this.MemberwiseClone();
            copy._cells = new Cell[Width, Height];
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    copy._cells[x, y] = this.GetCell(x, y);
                }
            }
            return copy;
        }


        public void DrawMap()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    Cell cell = this.GetCell(x, y);
                    if (cell.Actor?.IsNotPassable ?? false)
                    {
                        Console.Write(_cells[x, y].Actor.Symbol);
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine("");
            }
        }        
        public Cell GetCell(int x, int y) => _cells[x, y];
        public int Width { get; }
        public int Height { get; }

        public int Dimensions { get;  }
    }

}
