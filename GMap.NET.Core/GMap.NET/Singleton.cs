using System;
using System.Diagnostics;
using System.Reflection;

namespace GMap.NET
{

    /// <summary>
    /// generic for singletons
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : new()
    {
        // ctor
        protected Singleton()
        {
            if (Instance != null)
            {
                throw (new Exception("You have tried to create a new singleton class where you should have instanced it. Replace your \"new class()\" with \"class.Instance\""));
            }
        }

        public static T Instance
        {
            get
            {
                if (SingletonCreator.exception != null)
                {
                    throw SingletonCreator.exception;
                }
                return SingletonCreator.instance;
            }
        }

        class SingletonCreator
        {
            static SingletonCreator()
            {
                try
                {
                    instance = new T();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        exception = ex.InnerException;
                    }
                    else
                    {
                        exception = ex;
                    }
                    Trace.WriteLine("Singleton: " + exception);
                }
            }
            public static readonly T instance;
            public static readonly Exception exception;
        }
    }
}
