// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;

namespace WebConsole.Core.Exceptions
{
    public class JobConfigMissingDataException : Exception
    {
        public override string Message => "The jobs.xml file is not completed!!!";
    }
}