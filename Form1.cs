
/////----------------------------------------------------------------------------------
//ProjectName                : SP2FUN
//File Name					 : SP2FUN 
//Description	             : The tool can convert MSSQL server stored procedure to the Data Acess Layer function of  ADO.NET 
//Dev Ver                    : VS.NET 2010 C#
//Author		             : Kevin YU (jsyu@gmail.com)
//Create Date                : 2014/12/20
//NowVer                     : 0.0.1      
//Confidentiality level      :  This project is open source
//---------------------------------------------------------------------------
//Modification Log	:
//Vers        QaNum       Date        By          Notes
//---------------------------------------------------------------------------
//0.0.1	                 2014/12/20        Source Create
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SP2FUN.BLL;
using System.Text.RegularExpressions;
using System.Collections;

namespace SP2FUN
{
    public partial class mainFrmSP2Fun : Form
    {
        public mainFrmSP2Fun()
        {
            InitializeComponent();
        }

        private void mainFrmSP2Fun_Load(object sender, EventArgs e)
        {
            BLLGetData gData = new BLLGetData();
            DataTable dt = gData.GetSpList();

            cboSPList.DisplayMember = "spName";
            cboSPList.ValueMember = "spText";
            cboSPList.DataSource = dt;
        }

        private void cboSPList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSP.Text = cboSPList.SelectedValue.ToString();

        }

        //Stored Procedure Convet to DAL Layer Function 
        private void btnConvertSP2Fun_Click(object sender, EventArgs e)
        {
            try
            {
                int i = txtSP.Text.Trim().ToUpper().IndexOf("BEGIN");
                int j = txtSP.Text.Trim().ToUpper().LastIndexOf("END");

                //=== Read Template ===
                System.IO.StreamReader myFile = new System.IO.StreamReader(@"Template.txt");

                string myString = myFile.ReadToEnd();
                myFile.Close();

                //===Replace Template Tags===
                StringBuilder tagBuff = new StringBuilder();
                StringBuilder pramsBuff = new StringBuilder();
                tagBuff.Append(txtSP.Text.Trim().Substring(i + 5, j - (i + 5)));
                myString = ReplaceTag(myString, "TAG2", tagBuff.ToString());

                BLLGetData gData = new BLLGetData();
                DataTable dt = gData.GetSpparameters(cboSPList.Text);
                string sFunParms = "";
                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    sFunParms += SqlTypeString2CsharpTypeString(dt.Rows[iRow]["DATA_TYPE"].ToString()) + " " + dt.Rows[iRow]["PARAMETER_NAME"].ToString().Replace("@", "") + " ,";


                    if (dt.Rows[iRow]["CHARACTER_OCTET_LENGTH"].ToString() == "")
                    {
                        pramsBuff.Append("        cmd.Parameters.Add(\"" + dt.Rows[iRow]["PARAMETER_NAME"].ToString() + "\", SqlDbType." + BLLSqlDbTypeToCSharpType.SqlTypeString2SqlType(dt.Rows[iRow]["DATA_TYPE"].ToString()) + ").Value = " + dt.Rows[iRow]["PARAMETER_NAME"].ToString().Replace("@", "") + ";  " + Environment.NewLine);
                    }
                    else
                    {
                        pramsBuff.Append("        cmd.Parameters.Add(\"" + dt.Rows[iRow]["PARAMETER_NAME"].ToString() + "\", SqlDbType." + BLLSqlDbTypeToCSharpType.SqlTypeString2SqlType(dt.Rows[iRow]["DATA_TYPE"].ToString()) + "," + dt.Rows[iRow]["CHARACTER_OCTET_LENGTH"].ToString() + ").Value = " + dt.Rows[iRow]["PARAMETER_NAME"].ToString().Replace("@", "") + ";  " + Environment.NewLine);
                    }

                }

                myString = ReplaceTag(myString, "TAG3", sFunParms.TrimEnd(','));
                myString = ReplaceTag(myString, "TAG1", pramsBuff.ToString());


                txtFun.Text = myString;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private string ReplaceTag(string content, string tagName, string replaceData)
        {
            return content.Replace("[" + tagName + "]", replaceData);
        }


        public static Type SqlTypeString2CsharpType(string sqlTypeString)
        {
            SqlDbType dbTpe = BLLSqlDbTypeToCSharpType.SqlTypeString2SqlType(sqlTypeString);

            return BLLSqlDbTypeToCSharpType.SqlType2CsharpType(dbTpe);
        }


        public static string SqlTypeString2CsharpTypeString(string sqlTypeString)
        {
            Type type = SqlTypeString2CsharpType(sqlTypeString);

            return type.Name;
        }

        private void txtFun_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && (e.KeyCode == Keys.A))
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
                e.Handled = true;
            }

        }

    }
}
