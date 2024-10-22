using System.Threading.Tasks;
using Assent;
using DbUp.Tests.Common;
using DbUp.Tests.Common.RecordingDb;
using Shouldly;
using Xunit;

namespace DbUp.MySql.Tests
{
    public class MySqlSupportTests
    {
        [Fact]
        public void CanHandleDelimiter()
        {
            var logger = new CaptureLogsLogger();
            var recordingDbConnection = new RecordingDbConnection(logger);
            var upgrader = DeployChanges.To
                .MySqlDatabase(new TestConnectionManager(recordingDbConnection))
                .LogTo(logger)
                .WithScript("Script0003", @"USE `test`;
DROP procedure IF EXISTS `testSproc`;

DELIMITER $$

USE `test`$$
CREATE PROCEDURE `testSproc`(
        IN   ssn                    VARCHAR(32)
     )
BEGIN

    SELECT id
    FROM   customer as c
    WHERE  c.ssn = ssn ;

END$$").Build();

            var result = upgrader.PerformUpgrade();

            result.Successful.ShouldBe(true);
            this.Assent(logger.Log, new Configuration().UsingSanitiser(Scrubbers.ScrubDates));
        }
    }
}
