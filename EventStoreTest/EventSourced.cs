using System;
namespace EventStoreTest
{
    public class EventSourced : Entity
    {
        public int Version { get; protected set; } = 0;

        public EventSourced(Guid id = default(Guid)) : base(id) { }
    }
}
