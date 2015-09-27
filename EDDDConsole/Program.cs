using System;
using System.Collections.Generic;
using System.Reflection;
using EDDD;

namespace EDDDConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an assembly name:");
            var assemblyName = Console.ReadLine();


            while (true)
            {
                Console.WriteLine("Enter an event name:");
                var eventName = Console.ReadLine();

                IEnumerable<string> handlers;

                if (!string.IsNullOrEmpty(eventName))
                {
                    handlers = FindAnnotation.AllHandlersForEvent(Assembly.Load(assemblyName), eventName);
                }
                else
                {
                    handlers = FindAnnotation.AllHandlers(Assembly.Load(assemblyName));
                }

                foreach (var handler in handlers)
                {
                    Console.WriteLine("----->" + handler);
                }
            }
        }
    }
}
