using System;
using System.Data;
using System.Data.SqlClient;

using static DbLogger.F;

namespace DbLogger
{
    public static class ConnectionHelper
    {
        public static TR Connect<TR>(string connString, Func<IDbConnection, TR> f)
            => Using(new SqlConnection(connString),
                conn =>
                {
                    conn.Open();
                    return f(conn);
                });
    }
}
