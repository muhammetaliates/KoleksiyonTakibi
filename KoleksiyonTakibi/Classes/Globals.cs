using System;
using System.Collections.Generic;
using System.Text;

namespace KoleksiyonTakibi
{
    public static class Globals
    {
        public static string connStr = "Data Source=localhost;Initial Catalog=collectiondb;";
        public static bool add = false;
        public static int ID = -1;
        public static IDictionary<int, Product> productList = new Dictionary<int, Product>();
        public static Product globalProduct = null;
        
    }
}
