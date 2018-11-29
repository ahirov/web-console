// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;

namespace WebConsole.Core.Job.Exceptions
{
    public class JobNotFoundException : Exception
    {
        private readonly int id;

        public JobNotFoundException(int id)
        {
            this.id = id;
        }

        public override string Message => $"Job with id {id} not found!!!";
    }
}