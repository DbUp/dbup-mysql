using DbUp.Tests.Common;

namespace DbUp.MySql.Tests;

public class NoPublicApiChanges : NoPublicApiChangesBase
{
    public NoPublicApiChanges()
        : base(typeof(MySqlExtensions).Assembly)
    {
    }
}
