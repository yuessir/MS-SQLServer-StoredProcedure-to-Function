using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SP2FUN.DAL;
using System.Data.SqlClient;

namespace SP2FUN.BLL
{
    class BLLGetData
    {
        public DataTable GetSpparameters(string spName)
        {
            string sSQL = @"
                select * from information_schema.parameters
                where specific_name=@spName
            ";
            SqlParameter parm = new SqlParameter("@spName", spName);
           DataTable dt = SQLHelper.ExecuteQuery(sSQL, parm);
            return dt;
        }
        public DataTable GetSpList()
        {
            string sSQL = @"
            SELECT OBJECT_NAME(object_id) AS spName,
                   OBJECT_DEFINITION(object_id) as spText
            FROM sys.procedures
            order by spName 
            ";
            DataTable dt = SQLHelper.ExecuteQuery(sSQL);
            return dt;
        }
 
    }
}
