using LifeOfAnts.Logic.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeOfAnts.Logic
{
    public static class HiveMapLoader
    {
        public static HiveMap InitiateMap(int dimensions)
        {

            HiveMap map = new HiveMap(dimensions);
            Cell queenCell = map.GetCell(dimensions / 2, dimensions / 2);
            queenCell.Ant = new Queen(queenCell);
            queenCell.PrintCoords();
            //why i cannot acces queen methods when queenCell.Ant = new Queen(..)
            queenCell.Ant.GenerateAnts(ref map);
            return map;
        }

        public static HiveMap UpdateMap(HiveMap map)
        {
            //need to divide loops to old map/new map to avoid moving more than once
            Console.WriteLine("entering update map");
            HiveMap updatedMap = map.DeepCloneExtensions();
            Console.WriteLine("updated map draw before update:");
            updatedMap.DrawMap();
            for (var x = 0; x < updatedMap.Dimensions; x++)
            {
                for (var y = 0; y < updatedMap.Dimensions; y++)
                {
                    Cell cell = updatedMap.GetCell(x, y);
                    if(cell.Actor?.IsNotPassable ?? false)
                    {
                        cell.Actor.Move();
                    }
                }
            }
            
            Console.WriteLine("updated ORG map draw after update:");
            map.DrawMap();
            Console.WriteLine("updated map draw after update:");
            updatedMap.DrawMap();
            return updatedMap;
        }

    }
}
