using KoleksiyonTakibi.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KoleksiyonTakibi.Classes
{
    public class Kitap : Product, IKitap
    {
        public int type { get ; set ; }

        public Kitap(string name,int year,int cat,int kitapType)
        {
            this.Name = name;
            this.Year = year;
            this.Cat = cat;
            this.Cat2 = kitapType;
            this.type = type;
        }

        public string[] getInfo()
        {
            string[] returnValue = { this.Name, this.Year.ToString(), this.Cat.ToString(), this.type.ToString() };
            return returnValue;
        }
    }
}
