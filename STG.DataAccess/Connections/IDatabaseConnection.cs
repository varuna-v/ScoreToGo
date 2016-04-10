using System.Data;
using System.Data.SqlClient;

namespace STG.DataAccess.Connections
{
    public interface IDatabaseConnection
    {
        DataTable ExecuteQuery(string query, SqlParameter[] parameters);

        void ExecuteNonQuery(string query, SqlParameter[] parameters);
    }
}
