using System;
using System.Collections.Generic;
using System.Text;

namespace KoleksiyonTakibi
{
    public class DVD : Product, IDVD
    {

        public int type { get ; set ; }

        public DVD(string ad, int yil, int cat, int type)
        {
            this.Name = ad;
            this.Cat = cat;
            this.Cat2 = type;
            this.Year = yil;
            this.type = type;
        }
        public string[] getInfo()
        {
            string[] returnValue = { this.Name, this.Year.ToString(), this.Cat.ToString(), this.type.ToString() };
            return returnValue;
        }

    }
}
