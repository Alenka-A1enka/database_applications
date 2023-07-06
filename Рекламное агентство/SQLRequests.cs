using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Рекламное_агентство
{
    class SQLRequests
    {
        public static List<string> SelectRequest(string request, string[] myargs = null,
            string[] args = null)
        {
            List<string> result_list = new List<string>();

            var sqlConnection = new SqlConnection
               (ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString);
            sqlConnection.Open();
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand
                    (request, sqlConnection);

                if (myargs != null)
                    for (int i = 0; i < myargs.Length; i++)
                    {
                        command.Parameters.AddWithValue(myargs[i], args[i]);
                    }

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result_list.Add(Convert.ToString(reader[0]));
                }
            }
            catch { }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }
            return result_list;
        }
    }
}
