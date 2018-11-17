// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Threading;

namespace AttachedConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!!");
            Thread.Sleep(10000);
            Console.WriteLine("10 seconds");
            Thread.Sleep(10000);
            Console.WriteLine("20 seconds");

            Console.WriteLine("Enter app code:");
            var code = Console.ReadLine();
            Console.WriteLine($"Entered code is: {code}");
            Console.WriteLine("##############");
            Console.ReadLine();
        }
    }
}
