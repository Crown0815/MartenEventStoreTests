using System;
namespace EventStoreTest
{
    public abstract class Event : Entity, IEvent
    {
        public DateTime TimeStamp { get; }

        protected Event(Guid id = default(Guid), DateTime timeStamp = default(DateTime)) : base(id)
        {
            TimeStamp = timeStamp == default(DateTime) ? DateTime.Now : timeStamp;
        }
    }
}
