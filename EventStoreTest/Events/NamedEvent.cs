using System;
namespace EventStoreTest.Events
{
    public class NamedEvent : Event
    {
        public string NewName { get; }

        public NamedEvent(string newName)
        {
            NewName = newName;
        }
    }
}
