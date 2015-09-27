using System.Collections.Generic;
using EDDD;

namespace EDDDSample
{
    [Handler("MyOtherDomainEvent")]
    public class MyOtherEventHandler : IHandle<MyOtherDomainEvent>
    {
        public void Handle<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}