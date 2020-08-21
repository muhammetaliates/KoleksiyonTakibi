using System;
using System.Collections.Generic;
using System.Text;

/**************************

**	SAKARYA ÜNİVERSİTESİ
**	BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ

**	BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ

**	NESNEYE DAYALI PROGRAMLAMA DERSİ
**	2019-2020 YAZ DÖNEMİ

**

**	PROJE NUMARASI.........: 01
**	ÖĞRENCİ ADI............: MUHAMMET ALİ ATEŞ		

**	ÖĞRENCİ NUMARASI.......: B151200040

**	DERSİN ALINDIĞI GRUP...: A

**************************/
namespace KoleksiyonTakibi.Classes
{
    public class ComboBoxItem
    {
        public string value;
        public string data;

        public ComboBoxItem(string value, string data)
        {
            this.value = value;
            this.data = data;
        }

        public string getValue
        {
            get { return this.value;  }
        }
        public string getData
        {
            get { return this.data; }
        }
    }
}
