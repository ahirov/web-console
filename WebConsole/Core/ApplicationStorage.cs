// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Web;

namespace WebConsole.Core
{
    public interface IApplicationStorage<out T> where T : class, new()
    {
        void Invoke(string key, Action<T> action);
    }

    public class ApplicationStorage<T> : IApplicationStorage<T> where T : class, new()
    {
        private readonly HttpApplicationState state = HttpContext.Current.Application;

        public void Invoke(string key, Action<T> action)
        {
            state.Lock();

            action.Invoke((T) state[key]
                      ?? (T) (state[key] = new T()));
            state.UnLock();
        }
    }
}