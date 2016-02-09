#### 1.0.7 Feb 08 2016 ####
Place holder for next version.

#### 1.0.6 Feb 08 2016 ####
Upgrades to Akka.NET v1.0.6 internally.

#### 1.0.5 Dec 14 2015 ####
Upgrades to Akka.NET v1.0.5 internally.

#### 1.0.4 August 07 2015 ####

#### 1.0.3 June 12 2015 ####
**Bugfix release for Akka.NET v1.0.2.**

This release addresses an issue with Akka.Persistence.SqlServer and Akka.Persistence.PostgreSql where both packages were missing a reference to Akka.Persistence.Sql.Common. 

In Akka.NET v1.0.3 we've packaged Akka.Persistence.Sql.Common into its own NuGet package and referenced it in the affected packages.

#### 1.0.2 June 2 2015
Initial Release of Akka.Persistence.PostgreSql

Fixes & Changes - Akka.Persistence
* [Renamed GuaranteedDelivery classes to AtLeastOnceDelivery](https://github.com/akkadotnet/akka.net/pull/984)
* [Changes in Akka.Persistence SQL backend](https://github.com/akkadotnet/akka.net/pull/963)
* [PostgreSQL persistence plugin for both event journal and snapshot store](https://github.com/akkadotnet/akka.net/pull/971)
* [Cassandra persistence plugin](https://github.com/akkadotnet/akka.net/pull/995)

**New Features:**

**Akka.Persistence.PostgreSql** and **Akka.Persistence.Cassandra**
Akka.Persistence now has two additional concrete implementations for PostgreSQL and Cassandra! You can install either of the packages using the following commandline:

[Akka.Persistence.PostgreSql Configuration Docs](https://github.com/akkadotnet/akka.net/tree/dev/src/contrib/persistence/Akka.Persistence.PostgreSql)
```
PM> Install-Package Akka.Persistence.PostgreSql
```
