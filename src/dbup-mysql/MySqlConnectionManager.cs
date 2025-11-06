using System.Collections.Generic;
using DbUp.Engine.Transactions;
using MySqlConnector;


namespace DbUp.MySql
{
    /// <summary>
    /// Manages MySql database connections.
    /// </summary>
    public class MySqlConnectionManager : DatabaseConnectionManager
    {
        /// <summary>
        /// Creates a new MySql database connection.
        /// </summary>
        /// <param name="connectionString">The MySql connection string.</param>
        public MySqlConnectionManager(string connectionString) : base(new DelegateConnectionFactory(l => new MySqlConnection(connectionString)))
        {
        }

        /// <inheritdoc/>
        public override IEnumerable<string> SplitScriptIntoCommands(string scriptContents)
        {
            var commandSplitter = new MySqlCommandSplitter();
            var scriptStatements = commandSplitter.SplitScriptIntoCommands(scriptContents);
            return scriptStatements;
        }
    }
}
