using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2016.Day4
{
    public class Puzzle2016_Day4 : Puzzle
    {
        public string Resolve()
        {
            int sum= 0;

            var realRooms = new List<Room>();

            foreach (var line in File.ReadAllLines("2016\\Inputs\\Input_2016_Day4.txt"))
            {
                var room= new Room(line);

                if (room.IsReal())
                {
                    realRooms.Add(room);

                    var decypheredRoom = room.Decypher();

                    if (decypheredRoom.Contains("north"))
                    { 
                        Console.WriteLine($"North Pole objects are stored in sector ID {room.SectorID}");
                    }
                    
                }
            }

            return $"Sum of the sector IDs of the real rooms: {realRooms.Select(room => room.SectorID).Sum()}";
        }
    }
}
