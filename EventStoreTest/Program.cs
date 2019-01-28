using System;
using System.Linq;
using EventStoreTest.Events;
using Marten;

namespace EventStoreTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var id = CreateTestWizard();
            var wizard = LoadTestWizard(id);
            var wizardHistory = LoadWizardHistory(id);

            Console.WriteLine(wizard);
            Console.WriteLine(wizardHistory);

        }

        public static Guid CreateTestWizard()
        {
            var store = DocumentStore.For(_ =>
            {
                _.Connection("host=localhost;database=felixkroner;password=mypassword;username=felixkroner");
            });

            var wizardId = Guid.NewGuid();

            using (var session = store.OpenSession())
            {
                var learnedExpelliamus = new SpellLearnedEvent("Expelliamus", "Professor Lockhard");
                var learnedAlohomora = new SpellLearnedEvent("Alohomora", "Hermione");

                // Start a brand new stream and commit the new events as 
                // part of a transaction
                session.Events.StartStream<Wizard>(wizardId, learnedAlohomora, learnedExpelliamus);
                Console.WriteLine(learnedExpelliamus);
                Console.WriteLine(learnedAlohomora);
                session.SaveChanges();

                // Append more events to the same stream
                var learnedMiau = new SpellLearnedEvent("Miau", "Luna");
                var named = new NamedEvent("Luna Lovegood");
                session.Events.Append(wizardId, learnedMiau, named);
                Console.WriteLine(learnedMiau);
                session.SaveChanges();
            }
            return wizardId;
        }

        public static Wizard LoadTestWizard(Guid wizardId)
        {
            var store = DocumentStore.For("host=localhost;database=felixkroner;password=mypassword;username=felixkroner");

            Wizard wizard = null;
            using (var session = store.OpenSession())
            {
                wizard = session.Events.AggregateStream<Wizard>(wizardId);
            }

            return wizard;
        }

        public static WizardHistory LoadWizardHistory(Guid wizardId)
        {
            var store = DocumentStore.For("host=localhost;database=felixkroner;password=mypassword;username=felixkroner");

            WizardHistory wizard = null;
            using (var session = store.OpenSession())
            {
                wizard = session.Events.AggregateStream<WizardHistory>(wizardId);
            }

            return wizard;
        }
    }
}
