namespace MicroserviceEvents
{
    public class UserFoundEvent : BaseEvent
    {
        public string Name { get; set; }

        public string RoleName { get; set; }
    }
}
