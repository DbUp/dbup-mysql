using DbUp.Support;

namespace DbUp.MySql
{
    /// <summary>
    /// Parses Sql Objects and performs quoting functions
    /// </summary>
    public class MySqlObjectParser : SqlObjectParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlObjectParser"/> class.
        /// </summary>
        public MySqlObjectParser() : base("`", "`")
        {
        }
    }
}
