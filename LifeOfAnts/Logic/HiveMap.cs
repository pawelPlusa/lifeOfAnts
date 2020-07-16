using LifeOfAnts.Logic;
using LifeOfAnts.Logic.Actors;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace LifeOfAnts
{
    [Serializable]
    public class HiveMap
    {

        private Cell[,] _cells;
        private List<Actor> _allActors = new List<Actor>();
        //private int waspSpawnCounter;
        public HiveMap(int dimensions)
        {
            Dimensions = dimensions;
            Width = dimensions;
            Height = dimensions;
            _cells = new Cell[Width, Height];
            WaspSpawnCounter = Extensions.MyRandomNumberGenerator(10,12);
            IsWaspOnMap = false;
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    _cells[x, y] = new Cell(this,x, y);
                }
            }
        }
        
        public int WaspSpawnCounter { get; set; }
        public bool IsWaspOnMap { get; set; }
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
            for (var y = 0; y < Width; y++)
            {
                for (var x = 0; x < Height; x++)
                {
                    Cell cell = this.GetCell(x, y);
                    if (cell.Actor?.IsNotPassable ?? false)
                    {
                        if (_cells[x, y].Actor.Symbol == '8') {
                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0}", (char)(966)); 
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else { Console.Write(_cells[x, y].Actor.Symbol); }
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

        public Actor MyProperty { get; set; }

        public int Dimensions { get;  }

        public List<Actor> AllActors { get=> _allActors; set => _allActors=value; }
    }

}
