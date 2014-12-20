using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SP2FUN.DAL;

namespace SP2FUN
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           

            bool bStatus = ConnectionHelper.ShowDbStatus(GetConnectionString.DbStatus);

            mainFrmSP2Fun mainFrm = new mainFrmSP2Fun();
            if (bStatus == true)
            {

                Application.Run(new mainFrmSP2Fun());
            }
            else
            {

                MessageBox.Show("Please Set Connection strings for SQL Server.");
            }

           

        }
    }
}
