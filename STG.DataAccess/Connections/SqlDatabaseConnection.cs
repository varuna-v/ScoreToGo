using System.Data;
using System.Data.SqlClient;

namespace STG.DataAccess.Connections
{
    public class SqlDatabaseConnection : IDatabaseConnection
    {
        private const string ConnectionString = "Data Source=tcp:scoretogo.database.windows.net,1433;Initial Catalog=ScoreToGo;Integrated Security=False;User Id=STGAdmin@scoretogo;Password=boVV1713#;Encrypt=True;TrustServerCertificate=False;MultipleActiveResultSets=True";

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            var command = new SqlCommand();
            DataTable dataTable = null;
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(ConnectionString))
            using (var adapter = new SqlDataAdapter())
            {
                command.Connection = connection;
                command.CommandText = query;
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);
            }
            dataTable = dataSet.Tables[0];
            return dataTable;
        }

        public void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            var command = new SqlCommand();
            using (var connection = new SqlConnection(ConnectionString))
            using (var adapter = new SqlDataAdapter())
            {
                command.Connection = connection;
                command.CommandText = query;
                command.Parameters.AddRange(parameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
        }
    }
}
