// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Threading;

namespace ExternalConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Launching 010101 console...");
            var y = GetCount("y");
            var x = GetCount("x");

            Console.WriteLine("Long output:");
            Console.WriteLine();

            var rand = new Random();
            for (var i = 1; i <= y; i++)
            {
                for (var j = 1; j <= x; j++)
                {
                    Console.Write(rand.Next(0, 2));
                }
                Console.WriteLine();
                Thread.Sleep(200);
            }
            Console.WriteLine(GetDivider(x));
            Console.ReadLine();
        }

        private static int GetCount(string name)
        {
            Console.WriteLine($"Enter {name} count (max 100):");
            var line = Console.ReadLine();
            var isSuccessful = int.TryParse(line, out var count);
            if (!isSuccessful || count <= 0 || count >= 100)
                count = 100;
            return count;
        }

        private static string GetDivider(int x)
        {
            var extraDivider = string.Empty;
            var count = 0;
            if (x > 11)
            {
                count = x / 2 - 5;
                if (x % 2 != 0)
                    extraDivider = "#";
            }
            var divider = new string('#', count);
            return $"{divider} finished {divider}{extraDivider}";
        }
    }
}
