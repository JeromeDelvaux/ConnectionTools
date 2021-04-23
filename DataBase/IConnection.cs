using System;
using System.Collections.Generic;
using System.Data;

namespace ConnectionTools.DataBase
{
    public interface IConnection
    {
        int ExecuteNonQuery(Commands command);
        IEnumerable<TResult> ExecuteReader<TResult>(Commands command, Func<IDataRecord, TResult> selector);
        object ExecuteScalar(Commands command);
        DataTable GetDataTable(Commands command);
    }
}