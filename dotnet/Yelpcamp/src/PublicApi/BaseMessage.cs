using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yelpcamp.PublicApi
{
    public class BaseMessage
    {
        protected Guid _correlationId = Guid.NewGuid();
        public Guid CorrelationId() => _correlationId;
    }
}
