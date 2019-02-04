using System;
using System.Collections.Generic;
using EventStoreTest.Events;
using Marten.Events;

namespace EventStoreTest
{
    public class Wizard : EventSourced
    {
        public const string DEFAULT_NAME = "Unknown Wizard";

        public string Name { get; private set; }

        public ICollection<string> Spells { get; } = new List<string>();
        public ICollection<string> SpellSources { get; } = new List<string>();

        public Wizard(string name = DEFAULT_NAME, Guid id = default(Guid)) : base(id)
        {
            Name = name;
        }

        public Wizard() : this(DEFAULT_NAME){ }

        public void Apply(Event<NamedEvent> @event)
        {
            if (@event.Version != Version + 1) return;
            Name = @event.Data.NewName;
            Version++;
        }

        public void Apply(Event<SpellLearnedEvent> @event)
        {
            if (@event.Version != Version + 1) return;
            Spells.Add(@event.Data.Spell);
            SpellSources.Add(@event.Data.Source);
            Version++;
        }

        public override string ToString()
        {
            return $"{Name}: Master of {string.Join(", ", Spells)}";
        }
    }
}
