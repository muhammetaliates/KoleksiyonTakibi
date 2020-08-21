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
        public DataTable Select(string queryString)//bu komut ile çalıştırılan komutu datatable olarak döndürüyoruz
        {
            tempTable = new DataTable();
            //yeni bir datatable oluşturarak veritabanından gelen verileri burada saklıyoruz.
            try // try catch yapısı ile hata kontrolü yapıyoruz
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString,sqlConn); //sqldataadapter kullanarak querystringi tablo yapısına dönüştürürken kolaylık sağlıyoruz
                dataAdapter.Fill(tempTable); //boş tabloyu gelen veriler ile dolduruyoruz
                return tempTable; // tabloyu döndürüyoruz
            }
            catch(Exception e)
            {
                return Error(e.ToString());
            }
        }

        public void Execute(string query) //tablo yapısına ihtiyaç duymadan sadece komut çalıştırmak istediğimiz zaman bu komutu kullanıyoruz.
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

        public DataTable Error(string errorMessage)// Hata olması durumunda programın hata vermesini engellemek ve hata analizi yapmak için gelen hatayı tabloya dolduruyoruz.
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Hata");
            dt.Rows.Add(errorMessage);
            return dt;
        }

    }
}
