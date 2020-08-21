using System;
using System.Collections.Generic;
using System.Text;

namespace KoleksiyonTakibi
{
    public static class Globals
    {
        //Global değişkenleri burada saklıyoruz static olması kullanım kolaylığı sağlıyor.
        //Globals.ID yazarak değişkenin get set işlemleri yapılabiliyor.
        public static string connStr = "Data Source=localhost;Initial Catalog=collectiondb;uid=kdr35;pwd=kadir123";
        public static bool add = false;
        public static int ID = -1;
        public static IDictionary<int, Product> productList = new Dictionary<int, Product>();
        public static Product globalProduct = null;
        
    }
}
