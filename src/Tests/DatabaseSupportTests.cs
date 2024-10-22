using DbUp.Builder;
using DbUp.Tests.Common;

namespace DbUp.MySql.Tests;

public class DatabaseSupportTests : DatabaseSupportTestsBase
{
    public DatabaseSupportTests() : base()
    {
    }

    protected override UpgradeEngineBuilder DeployTo(SupportedDatabases to)
        => to.MySqlDatabase("");

    protected override UpgradeEngineBuilder AddCustomNamedJournalToBuilder(UpgradeEngineBuilder builder, string schema, string tableName)
        => builder.JournalTo(
            (connectionManagerFactory, logFactory)
                => new MySqlTableJournal(connectionManagerFactory, logFactory, schema, tableName)
        );
}
