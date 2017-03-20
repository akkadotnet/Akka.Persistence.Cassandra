using System.Configuration;
using Akka.Configuration;
using Akka.Persistence.TestKit.Journal;

namespace Akka.Persistence.Cassandra.Tests
{
    public class CassandraJournalSpec : JournalSpec
    {
        private static readonly Config JournalConfig = ConfigurationFactory.ParseString($@"
            akka.persistence.journal.plugin = ""cassandra-journal""
            akka.test.single-expect-default = 10s
            cassandra-sessions.default.contact-points = [ ""{ ConfigurationManager.AppSettings["cassandraContactPoint"] }"" ]
        ");

        public CassandraJournalSpec()
            : base(JournalConfig, "CassandraJournalSystem")
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
