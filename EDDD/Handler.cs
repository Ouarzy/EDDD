using System.Collections.Generic;
using System.Linq;

namespace EDDD
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class Handler : System.Attribute
    {
        private readonly IEnumerable<string> _events;

        public Handler(params string[] eventses)
        {
            _events = eventses;
        }

        public bool IsFor(string eventName)
        {
            return _events.Contains(eventName);
        }
    }
}
