using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace KoleksiyonTakibi
{
    class DbClass
    {

        SqlConnection sqlConn = new SqlConnection(Globals.connStr);
        DataTable tempTable;
        public DataTable select(string queryString)
        {
            tempTable = new DataTable();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString,sqlConn);
                dataAdapter.Fill(tempTable);
                return tempTable;
            }
            catch(Exception e)
            {
                return Error(e.ToString());
            }
        }

        public void Execute(string query)
        {
            try
            {
                sqlConn.Open();
                SqlCommand sqlComm = new SqlCommand(query, sqlConn);
                sqlComm.ExecuteNonQuery();
                sqlConn.Close();
            }
            catch (Exception e)
            {
                
            }
        }

        public DataTable Error(string errorMessage)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Hata");
            dt.Rows.Add(errorMessage);
            return dt;
        }

    }
}
