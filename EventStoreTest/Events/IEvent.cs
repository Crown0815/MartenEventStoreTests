using System;
namespace EventStoreTest
{
    public interface IEvent : IEntity
    {
        DateTime TimeStamp { get; }
    }
}
