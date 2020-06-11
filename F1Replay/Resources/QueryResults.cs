using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace F1Replay.Resources
{
    class QueryResults
    {
        public static DataTable Get(SqlConnection connection, string command)
        {
            connection.Open();
            using SqlCommand cmd = new SqlCommand(command, connection)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            connection.Close();

            return dt;
        }
    }
}
