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
