// WebConsole (https://github.com/hirov-anton/web-console)
// See LICENSE file in the solution root for full license information
// Copyright (c) 2018 Anton Hirov

using System;
using System.Web;

namespace WebConsole.Core
{
    public interface IApplicationStorage<T> where T : class
    {
        T this[string key] { get; set; }
        void Action(string key, Action<T> action);
    }

    public class ApplicationStorage<T> : IApplicationStorage<T> where T : class
    {
        private readonly HttpApplicationState state = HttpContext.Current.Application;

        public T this[string key]
        {
            get => Get(key);
            set => Set(key, value);
        }

        public void Action(string key, Action<T> action)
        {
            state.Lock();

            action.Invoke((T) state[key]);
            state.UnLock();
        }

        private T Get(string key)
        {
            state.Lock();

            var value = (T)state[key];
            state.UnLock();
            return value;
        }

        private void Set(string key, T value)
        {
            state.Lock();

            state[key] = value;
            state.UnLock();
        }
    }
}