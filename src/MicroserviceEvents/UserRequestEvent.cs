using System;

namespace MicroserviceEvents
{
    public class UserRequestEvent : BaseEvent
    {
        public Guid User { get; set; }
    }
}
