using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Puzzle2016_Day1:Puzzle
    {
        Direction myDirection = Direction.North;

        int myPositionX = 0;
        int myPositionY = 0;

        List<Location> myVisitedLocations= new List<Location>();

        private Location? myFirstVisitedLocation= null;

        private struct Location
        {
            public int X;
            public int Y;
        } 

        private enum Direction
        {
            North, East, South, West
        }

        void AddStepsX(int count)
        {
            for (int i = 0; i < count; i++)
            {
                myPositionX++;

                Location loc= new Location() {X= myPositionX, Y=myPositionY};

                if(!myVisitedLocations.Contains(loc))
                    myVisitedLocations.Add(loc);
                else if (myFirstVisitedLocation == null)
                    myFirstVisitedLocation = loc;
            }
        }

        void RemoveStepsX(int count)
        {
            for (int i = 0; i < count; i++)
            {
                myPositionX--;

                Location loc = new Location() { X = myPositionX, Y = myPositionY };

                if (!myVisitedLocations.Contains(loc))
                    myVisitedLocations.Add(loc);
                else if (myFirstVisitedLocation == null)
                    myFirstVisitedLocation = loc;
            }
        }

        void AddStepsY(int count)
        {
            for (int i = 0; i < count; i++)
            {
                myPositionY++;

                Location loc = new Location() { X = myPositionX, Y = myPositionY };

                if (!myVisitedLocations.Contains(loc))
                    myVisitedLocations.Add(loc);
                else if (myFirstVisitedLocation == null)
                    myFirstVisitedLocation = loc;
            }
        }

        void RemoveStepsY(int count)
        {
            for (int i = 0; i < count; i++)
            {
                myPositionY--;

                Location loc = new Location() { X = myPositionX, Y = myPositionY };

                if (!myVisitedLocations.Contains(loc))
                    myVisitedLocations.Add(loc);
                else if (myFirstVisitedLocation == null)
                    myFirstVisitedLocation = loc;
            }
        }

        public string Resolve()
        {
            var movements = input.Replace(" ", "").Split(',');

            foreach (var movement in movements)
            {
                int steps = int.Parse(movement.Remove(0, 1));
                switch (myDirection)
                {
                    case Direction.North:
                        if (movement[0] == 'L')
                        {
                            myDirection = Direction.West;
                            RemoveStepsX(steps);
                        }
                        else//R
                        {
                            myDirection = Direction.East;
                            AddStepsX(steps);
                        }
                        break;
                    case Direction.East:
                        if (movement[0] == 'L')
                        {
                            myDirection = Direction.North;
                            AddStepsY(steps);
                        }
                        else//R
                        {
                            myDirection = Direction.South;
                            RemoveStepsY(steps);
                        }      
                    break;
                    case Direction.South:
                        if (movement[0] == 'L')
                        {
                            myDirection = Direction.East;
                            AddStepsX(steps);
                        }
                        else//R
                        {
                            myDirection = Direction.West;
                            RemoveStepsX(steps);
                        }
                    break;
                    case Direction.West:
                        if (movement[0] == 'L')
                        {
                            myDirection = Direction.South;
                            RemoveStepsY(steps);
                        }
                        else//R
                        {
                            myDirection = Direction.North;
                            AddStepsY(steps);
                        }
                    break;
                }
            }

            int nbrOfBlocksAway = Math.Abs(myPositionY) + Math.Abs(myPositionX);

            int nbrOfBlocksAwayOfFirstLocation = Math.Abs(myFirstVisitedLocation.Value.X) + Math.Abs(myFirstVisitedLocation.Value.Y);

            return $"Easter Bunny HQ is {nbrOfBlocksAway} blocks away.\nThe first location I visited twice is {nbrOfBlocksAwayOfFirstLocation} blocks away.";
        }

        private string input= $"L3, R2, L5, R1, L1, L2, L2, R1, R5, R1, L1, L2, R2, R4, L4, L3, L3, R5, L1, R3, L5, L2, R4, L5, R4, R2, L2, L1, R1, L3, L3, R2, R1, L4, L1, L1, R4, R5, R1, L2, L1, R188, R4, L3, R54, L4, R4, R74, R2, L4, R185, R1, R3, R5, L2, L3, R1, L1, L3, R3, R2, L3, L4, R1, L3, L5, L2, R2, L1, R2, R1, L4, R5, R4, L5, L5, L4, R5, R4, L5, L3, R4, R1, L5, L4, L3, R5, L5, L2, L4, R4, R4, R2, L1, L3, L2, R5, R4, L5, R1, R2, R5, L2, R4, R5, L2, L3, R3, L4, R3, L2, R1, R4, L5, R1, L5, L3, R4, L2, L2, L5, L5, R5, R2, L5, R1, L3, L2, L2, R3, L3, L4, R2, R3, L1, R2, L5, L3, R4, L4, R4, R3, L3, R1, L3, R5, L5, R1, R5, R3, L1";
    }
}
