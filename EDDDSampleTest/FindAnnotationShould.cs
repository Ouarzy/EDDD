using System.Collections.Generic;
using System.Reflection;
using EDDD;
using EDDDSample;
using NFluent;
using NUnit.Framework;

namespace EDDDSampleTest
{
    [TestFixture]
    public class FindAnnotationShould
    {
        private readonly Assembly _targetAssembly = Assembly.GetAssembly(typeof(MyShinyDomainEvent));

        [Test]
        public void ListAllEvents()
        {
            var events = FindAnnotation.AllEvents(_targetAssembly);

            Check.That(events).ContainsExactly(new List<string> { "MyThirdDomainEvent", "MyOtherDomainEvent", "MyShinyDomainEvent" });
        }

        [Test]
        public void ListAllHandlers()
        {
            var handlers = FindAnnotation.AllHandlers(_targetAssembly);

            Check.That(handlers).ContainsExactly(new List<string> { "MyOtherEventHandler", "MyShinyEventHandler"});
        }

        [Test]
        public void ListAllHandlersOfThisEvent()
        {
            var handlers = FindAnnotation.AllHandlersForEvent(_targetAssembly, "MyShinyDomainEvent");
            
            Check.That(handlers).ContainsExactly(new List<string> { "MyShinyEventHandler"});
        }

        [Test]
        public void ListAllHandlersForAnotherEventIncludingAHandlerManagingSeveralEvents()
        {
            var handlers = FindAnnotation.AllHandlersForEvent(_targetAssembly, "MyOtherDomainEvent");
            
            Check.That(handlers).ContainsExactly(new List<string> { "MyOtherEventHandler", "MyShinyEventHandler" });
        }
    }
}
