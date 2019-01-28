using System;
namespace EventStoreTest.Events
{
    public class SpellLearnedEvent : Event
    {
        public string Source { get; }
        public string Spell { get; }

        public SpellLearnedEvent(string spell, string source = "a book")
        {
            Spell = spell;
            Source = source;
        }

        public override string ToString()
        {
            return $"Learned {Spell} from {Source}";
        }
    }
}
