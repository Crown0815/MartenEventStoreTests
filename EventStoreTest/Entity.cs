using System;
namespace EventStoreTest
{
    public class Entity : IEntity
    { 
        public Guid Id { get; }

        public Entity (Guid id = default(Guid))
        {
            Id = id == default(Guid) ? Guid.NewGuid() : id;
        }
    }
}
