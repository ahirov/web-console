// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;

namespace WebConsole.Core.Job.Info
{
    public interface IJobIdProvider
    {
        string GetId();
    }

    public class JobIdProvider : IJobIdProvider
    {
        public string GetId()
        {
            var bytes = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(bytes)
                          .Replace("/", "a")
                          .Replace("+", "z")
                          .Substring(0, 22)
                          .ToUpper();
        }
    }
}