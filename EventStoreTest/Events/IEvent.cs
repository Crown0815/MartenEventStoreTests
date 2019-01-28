using System;
namespace EventStoreTest.Events
{
    public interface IEvent : IEntity
    {
        DateTime TimeStamp { get; }
    }
}
