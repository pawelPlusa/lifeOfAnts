using LifeOfAnts.Logic.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
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
            map.AllActors.Add(queenCell.Ant);
            //why i cannot acces queen methods when queenCell.Ant = new Queen(..)
            queenCell.Ant.GenerateAnts(ref map);
            return map;
        }

        public static HiveMap UpdateMap(HiveMap map)


        {
            //Console.WriteLine(map.AllActors.Count);
            //foreach(Actor singleActor in map.AllActors)
            //{
            //    Console.WriteLine(singleActor);
            //}
            if (map.WaspSpawnCounter > 0) { map.WaspSpawnCounter--; Console.WriteLine("Wasp Counter: {0}",map.WaspSpawnCounter); }
            else {
                map.WaspSpawnCounter = Extensions.MyRandomNumberGenerator(30,60);
                bool isWaspCreated = false;
                while (!isWaspCreated)
                {
                    int waspX = Extensions.MyRandomNumberGenerator(0, map.Dimensions-1);
                    int waspY = Extensions.MyRandomNumberGenerator(0, map.Dimensions-1);
                    if(!map.GetCell(waspX,waspY).Actor?.IsNotPassable ?? true && !map.IsWaspOnMap)
                    {
                        Cell cell = map.GetCell(waspX, waspY);
                        cell.Actor = new Wasp(cell);
                        map.AllActors.Add(cell.Actor);
                        isWaspCreated = true;
                        
                    }
                }
                
            }
            // adding ToList() makes copy so any changes in List (like remove Wasp) 
            // should not end wit Exception
            foreach (Actor singleActor in map.AllActors.ToList())
            {
                singleActor.Move();
            }
            map.DrawMap();
            //need to divide loops to old map/new map to avoid moving more than once
            //Console.WriteLine("entering update map");
            //HiveMap updatedMap = map.DeepCloneExtensions();
            //Console.WriteLine("updated map draw before update:");
            //updatedMap.DrawMap();
            //for (var x = 0; x < updatedMap.Dimensions; x++)
            //{
            //    for (var y = 0; y < updatedMap.Dimensions; y++)
            //    {
            //        Cell cell = updatedMap.GetCell(x, y);
            //        if(cell.Actor?.IsNotPassable ?? false)
            //        {
            //            cell.Actor.Move();
            //        }
            //    }
            //}
            
            //Console.WriteLine("updated ORG map draw after update:");
            //map.DrawMap();
            //Console.WriteLine("updated map draw after update:");
            //updatedMap.DrawMap();
            return map;
        }

    }
}
