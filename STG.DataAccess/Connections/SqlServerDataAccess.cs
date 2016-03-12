using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace STG.DataAccess.Connections
{
    public class SqlServerDataAccess
    {
        private static SqlServerDataAccess dataAccess = null;

        private SqlConnection connection = null;

        private SqlServerDataAccess(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public static SqlServerDataAccess GetInstance(string connectionString)
        {
            if (dataAccess == null)
                dataAccess = new SqlServerDataAccess(connectionString);
            return dataAccess;
        }

        public void Open()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        public void Dispose()
        {
            if (connection.State != ConnectionState.Closed)
                this.connection.Close();
        }

        public DataSet ExecuteProcedureReader(string StoredProcName, Hashtable parameterList)
        {
            DataSet objresultSet = new DataSet();
            SqlDataAdapter objSqlDataAdapter = null;
            int counter = 0;
            var objSqlCommand = new SqlCommand(StoredProcName, connection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            if (parameterList != null)
            {
                foreach (string parametername in parameterList.Keys)
                {
                    objSqlCommand.Parameters.AddWithValue(parametername, parameterList[parametername]);

                    if (parametername.StartsWith("@OUT_"))
                        objSqlCommand.Parameters[counter].Direction = ParameterDirection.Output;
                    else
                        objSqlCommand.Parameters[counter].Direction = ParameterDirection.Input;

                    counter++;
                }
            }

            objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);

            objSqlDataAdapter.Fill(objresultSet);


            return objresultSet;
        }

        public int ExecuteNonQueryProcedure(string StoredProcName, Hashtable parameterList)
        {
            int returnValue = 0;
            int counter = 0;

            var objSqlCommand = new SqlCommand(StoredProcName, connection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            if (parameterList != null)
            {
                foreach (string parametername in parameterList.Keys)
                {
                    objSqlCommand.Parameters.AddWithValue(parametername, parameterList[parametername]);

                    if (parametername.StartsWith("@OUT_"))
                        objSqlCommand.Parameters[counter].Direction = ParameterDirection.Output;
                    else
                        objSqlCommand.Parameters[counter].Direction = ParameterDirection.Input;
                    counter++;
                }
            }
            returnValue = objSqlCommand.ExecuteNonQuery();
            return returnValue;
        }
    }
}
