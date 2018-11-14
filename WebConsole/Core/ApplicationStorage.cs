// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System.Web;

namespace WebConsole.Core
{
    public interface IApplicationStorage<T> where T : class
    {
        T this[string key] { get; set; }
    }

    public class ApplicationStorage<T> : IApplicationStorage<T> where T : class
    {
        public T this[string key]
        {
            get { return Get(key, HttpContext.Current.Application); }
            set { Set(key, value, HttpContext.Current.Application); }
        }

        private static T Get(string key, HttpApplicationState application)
        {
            application.Lock();

            var result = application[key];
            application.UnLock();
            return (T)result;
        }

        private static void Set(string key, T value, HttpApplicationState application)
        {
            application.Lock();

            application[key] = value;
            application.UnLock();
        }
    }
}
