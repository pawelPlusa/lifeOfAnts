using LifeOfAnts.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts
{
    public class HiveMap
    {
        private readonly Cell[,] _cells;
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
