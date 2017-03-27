using System.Configuration;
using Akka.Configuration;
using Akka.Persistence.TestKit.Journal;
using Xunit.Abstractions;

namespace Akka.Persistence.Cassandra.Tests
{
    public class CassandraJournalSpec : JournalSpec
    {
        private static readonly Config JournalConfig = ConfigurationFactory.ParseString($@"
            akka.persistence.journal.plugin = ""cassandra-journal""
            akka.test.single-expect-default = 10s
            cassandra-sessions.default.contact-points = [ ""{ ConfigurationManager.AppSettings["cassandraContactPoint"] }"" ]
        ");

        public CassandraJournalSpec(ITestOutputHelper output)
            : base(JournalConfig, "CassandraJournalSystem", output: output)
        {
            TestSetupHelpers.ResetJournalData(Sys);
            Initialize();
        }
        
        protected override void Dispose(bool disposing)
        {
            TestSetupHelpers.ResetJournalData(Sys);
            base.Dispose(disposing);
        }
    }
}
