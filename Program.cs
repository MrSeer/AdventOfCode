﻿using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
            Puzzle myPuzzle= new Puzzle2016_Day1();

            Console.WriteLine(myPuzzle.Resolve());

            Console.ReadKey();
        }
    }
}