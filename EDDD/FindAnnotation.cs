using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EDDD
{
    public static class FindAnnotation
    {
        public static IEnumerable<string> AllHandlers(Assembly targetAssembly)
        {
            return GetClassesWithThisAnnotationInThisAssembly<Handler>(targetAssembly);
        }

        private static IEnumerable<Type> AllHandlersByType(Assembly targetAssembly)
        {
            return GetClassesWithThisAnnotationInThisAssemblyByType<Handler>(targetAssembly);
        }

        public static IEnumerable<string> AllEvents(Assembly targetAssembly)
        {
            return GetClassesWithThisAnnotationInThisAssembly<Event>(targetAssembly);
        }

        public static IEnumerable<string> AllHandlersForEvent(Assembly targetAssembly, string eventName)
        {
            var allHandlersType = AllHandlersByType(targetAssembly);
            var handlersForThisEvent = GetHandlersOfThisEvent(allHandlersType, eventName);

            return handlersForThisEvent;
        }

        private static IEnumerable<string> GetHandlersOfThisEvent(IEnumerable<Type> handlersType, string eventName)
        {
            var handlers = new List<string>();

            foreach (var handlerType in handlersType)
            {
                Handler attributeHandler = Attribute.GetCustomAttributes(handlerType).OfType<Handler>().First();
                if (attributeHandler.IsFor(eventName))
                {
                    handlers.Add(handlerType.Name);
                }
            }

            return handlers;
        }

        private static IEnumerable<string> GetClassesWithThisAnnotationInThisAssembly<T>(Assembly target) where T : Attribute
        {
            List<string> list = new List<string>();
            foreach (var type in target.GetTypes())
            {
                if (HasAnnotation<T>(type))
                    list.Add(type.Name);
            }
            return list;
        }

        private static IEnumerable<Type> GetClassesWithThisAnnotationInThisAssemblyByType<T>(Assembly target) where T : Attribute
        {
            var list = new List<Type>();
            foreach (var type in target.GetTypes())
            {
                if (HasAnnotation<T>(type))
                    list.Add(type);
            }
            return list;
        }

        private static bool HasAnnotation<T>(Type type) where T : Attribute
        {
            return Attribute.GetCustomAttributes(type).OfType<T>().Any();
        }
    }
}
