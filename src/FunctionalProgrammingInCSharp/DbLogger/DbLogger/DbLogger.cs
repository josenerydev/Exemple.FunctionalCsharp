using Dapper;

using System;
using System.Collections.Generic;
using System.Data;

using static DbLogger.ConnectionHelper;

namespace DbLogger
{
    public class DbLogger
    {
        private readonly string _connString;

        public DbLogger(string connString)
            => _connString = connString;

        public void Log(LogMessage message)
            => Connect(_connString, c => c.Execute("sp_create_log",
                message, commandType: CommandType.StoredProcedure));

        public IEnumerable<LogMessage> GetLogs(DateTime since)
            => Connect(_connString,
                c => c.Query<LogMessage>(@"SELECT * FROM [Logs] WHERE [Timestamp] > @since", new { since }));
    }
}
