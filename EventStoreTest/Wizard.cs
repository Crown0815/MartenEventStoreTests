using System;
using System.Collections.Generic;
using EventStoreTest.Events;

namespace EventStoreTest
{
    public class Wizard : Entity
    {
        public string Name { get; private set; }

        public ICollection<string> Spells { get; } = new List<string>();
        public ICollection<string> SpellSources { get; } = new List<string>();

        public Wizard(string name = "Unknown Wizard", Guid id = default(Guid)) : base(id)
        {
            Name = name;
        }

        public Wizard() : this("Unknown Wizard")
        {

        }

        public void Apply(NamedEvent namedEvent)
        {
            Name = namedEvent.NewName;
        }

        public void Apply(SpellLearnedEvent spellLearnedEvent)
        {
            Spells.Add(spellLearnedEvent.Spell);
            SpellSources.Add(spellLearnedEvent.Source);
        }

        public override string ToString()
        {
            return $"{Name}: Master of {string.Join(", ", Spells)}";
        }
    }
}
