using System;
using System.Collections.Generic;
using System.Text;

namespace KoleksiyonTakibi
{
    public abstract class Product
    {

        private string name;
        private int year;
        private int cat;
        private int cat2;
        public string Name { get => name; set => name = value; }
        public int Year { get => year; set => year = value; }
        public int Cat { get => cat; set => cat = value; }
        public int Cat2 { get => cat2; set => cat2 = value; }
        public string[] getInfo() {
            string[] emptyArray = { };
            return emptyArray;
        }
      
    }
}
