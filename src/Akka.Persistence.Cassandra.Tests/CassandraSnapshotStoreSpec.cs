using Akka.Configuration;
using Akka.Persistence.TestKit.Snapshot;
using System.Configuration;

namespace Akka.Persistence.Cassandra.Tests
{
    public class CassandraSnapshotStoreSpec : SnapshotStoreSpec
    {
        private static readonly Config SnapshotConfig = ConfigurationFactory.ParseString($@"
            akka.persistence.snapshot-store.plugin = ""cassandra-snapshot-store""
            akka.test.single-expect-default = 10s
            cassandra-sessions.default.contact-points = [ ""{ ConfigurationManager.AppSettings["cassandraContactPoint"] }"" ]
        ");

        public CassandraSnapshotStoreSpec()
            : base(SnapshotConfig, "CassandraSnapshotSystem")
        {
            TestSetupHelpers.ResetSnapshotStoreData(Sys);
            Initialize();
        }

        protected override void Dispose(bool disposing)
        {
            TestSetupHelpers.ResetSnapshotStoreData(Sys);
            base.Dispose(disposing);
        }
    }
}