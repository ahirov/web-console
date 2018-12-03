// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;

namespace AttachedConsoleWithError
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(@"Launching console with an error...
The specified error message: NullReferenceException");
            throw new NullReferenceException();
        }
    }
}