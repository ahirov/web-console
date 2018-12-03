// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AttachedConsole
{
    public class Program
    {
        private static readonly Dictionary<string, Action> actions =
                            new Dictionary<string, Action>
        {
            {"--help", ExecuteHelp },
            {"--run",  ExecuteRun }
        };

        private static void Main(string[] args)
        {
            var arg = args.FirstOrDefault()
                        ?? string.Empty;
            if (actions.ContainsKey(arg))
                actions[arg].Invoke();
            else
                actions["--help"].Invoke();
            Console.ReadLine();
        }

        private static void ExecuteHelp()
        {
            Console.WriteLine(@"Command args:
--help (default)
--run");
        }

        private static void ExecuteRun()
        {
            Console.WriteLine("Enter iterations number: (from 1 to 10, default - 4)");
            var number = Console.ReadLine();

            var isSuccessful = int.TryParse(number, out var iterations);
            if (!isSuccessful || iterations <= 0 || iterations >= 11)
                iterations = 4;

            Console.WriteLine($"Entered code is: {iterations}");
            Console.WriteLine("Simulation of calculations is started!");
            for (var i = 1; i <= iterations; i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine($"{2 * i} seconds");
            }
            Console.WriteLine("#### finished ####");
        }
    }
}