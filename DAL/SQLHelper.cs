using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SP2FUN.DAL
{
    class SQLHelper
    {
    
        private static string connStr = GetConnectionString.DbStatus;
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] param)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
             
                    cmd.Parameters.AddRange(param);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        sda.Fill(dt);
                        return dt;
                    }
                }

            }
        }
    }
}
