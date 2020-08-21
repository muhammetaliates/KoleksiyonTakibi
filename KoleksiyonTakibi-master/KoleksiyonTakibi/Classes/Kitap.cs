using KoleksiyonTakibi.Interface;
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
