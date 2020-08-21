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
