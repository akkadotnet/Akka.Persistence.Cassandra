using Akka.Configuration;
using Akka.Persistence.TestKit.Snapshot;
using System.Configuration;
using Xunit.Abstractions;

namespace Akka.Persistence.Cassandra.Tests
{
    public class CassandraSnapshotStoreSpec : SnapshotStoreSpec
    {
        private static readonly Config SnapshotConfig = ConfigurationFactory.ParseString($@"
            akka.persistence.snapshot-store.plugin = ""cassandra-snapshot-store""
            akka.test.single-expect-default = 10s
            cassandra-sessions.default.contact-points = [ ""{ ConfigurationManager.AppSettings["cassandraContactPoint"] }"" ]
        ");

        public CassandraSnapshotStoreSpec(ITestOutputHelper output)
            : base(SnapshotConfig, "CassandraSnapshotSystem", output: output)
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