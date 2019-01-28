using System;
using System.Collections.Generic;
using EventStoreTest.Events;

namespace EventStoreTest
{
    public class WizardHistory : Entity
    {
        public ICollection<string> WizardNamings { get; } = new List<string>();

        public WizardHistory()
        {
        }

        public void Apply(NamedEvent namedEvent)
        {
            WizardNamings.Add($"The new wizard {namedEvent.NewName} was born on {namedEvent.TimeStamp.ToShortDateString()} at {namedEvent.TimeStamp.ToShortTimeString()}");
        }

        public override string ToString()
        {
            return $"History of {string.Join(", ", WizardNamings)}";
        }
    }

}
