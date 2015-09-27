using EDDD;

namespace EDDDSample
{
    [Handler("MyShinyDomainEvent", "MyOtherDomainEvent")]
    public class MyShinyEventHandler : IHandle<MyShinyDomainEvent>
    {
        public void Handle<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}
