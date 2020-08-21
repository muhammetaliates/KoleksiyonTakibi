﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KoleksiyonTakibi.Classes
{
    public class ListBoxItem
    {
        public string value;
        public string data;

        public ListBoxItem(string value, string data)
        {
            this.value = value;
            this.data = data;
        }

        public string getValue
        {
            get { return this.value; }
        }
        public string getData
        {
            get { return this.data; }
        }
    }
}
