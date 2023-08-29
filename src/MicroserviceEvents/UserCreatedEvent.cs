using System;

namespace MicroserviceEvents
{
    public class UserCreatedEvent : BaseEvent
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
