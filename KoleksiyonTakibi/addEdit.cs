﻿using KoleksiyonTakibi.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


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
    public partial class addEdit : Form
    {
        public addEdit()
        {
            InitializeComponent();
        }

        DbClass DbClass = new DbClass();
        List<ComboBoxItem> comboBox1Data = new List<ComboBoxItem>();
        List<ComboBoxItem> comboBox2Data;


        private void addEdit_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            DataTable dt = DbClass.Select("select * from tur");//select sorgusunu çalıştırıp datatable a aktarıyoruz.
            foreach (DataRow row in dt.Rows) // gelen tabloyu datarow şeklinde okuyoruz
            {
                comboBox1Data.Add(new ComboBoxItem(row[1].ToString(), row[0].ToString())); //combobox1data listesine verilerimizi aktarıyoruz
            }

            comboBox1.DisplayMember = "getValue";//görünen değerlerin çağırıldığı fonksiyon
            comboBox1.ValueMember = "getData";//arkaplan değerlerinin çağırıldığı fonksiyon
            comboBox1.DataSource = comboBox1Data;//combobox1 de görünecek olan değerlerin combobox1data dan geldiğini gösteriyoruz


            if (Globals.add == true)//eğer main formdan gelen veri ekleme ise 
            {
                this.Text = "Ekle";//başlığı değiştir
                comboBox1.SelectedIndex = 0;//combobox seçilen indexi 0 a ayarla

            }
            else//düzenleme seçildi ise
            {
                this.Text = "Düzenle";//Başlığı değiştir
                string query = "select c.id,c.ad,c.tur,c.tur2,c.yil from collection c inner join tur t on c.tur = t.id inner join tur2 t2 on c.tur2 = t2.id where c.id ="+ Globals.ID;
                
                DataTable editTable = DbClass.Select(query);
                Globals.globalProduct = Globals.productList[Globals.ID];

                textBox1.Text = Globals.globalProduct.Name.ToString();
                for (int i = 0; i < comboBox1.Items.Count; i++)//kategori isimlerini for döngüsü ile aktarıyoruz
                {
                    if(((ComboBoxItem)comboBox1.Items[i]).getData == Globals.globalProduct.Cat.ToString()) // eğer combobox data değeri ile eşit ise
                    {
                        comboBox1.SelectedIndex = i; //gelen değerin combobox değeri karşılığını seç
                    }
                }
                for (int i = 0; i < comboBox2.Items.Count; i++)
                {
                    if (((ComboBoxItem)comboBox2.Items[i]).getData == Globals.globalProduct.Cat2.ToString())
                    {
                        comboBox2.SelectedIndex = i;
                    }
                }

                
                textBox4.Text = Globals.globalProduct.Year.ToString();//gelen verinin yıl değerini textbox a aktar
            }
      
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Globals.add == true)
            {
                //kategori isimlerini listele
                comboBox2Data = new List<ComboBoxItem>();
                comboBox2Data.Clear();
                string query = "select * from tur2 where tur = " + ((ComboBoxItem)comboBox1.SelectedItem).getData;
                DataTable dt = DbClass.Select(query);
                foreach (DataRow row in dt.Rows)
                {
                    comboBox2Data.Add(new ComboBoxItem(row[1].ToString(), row[0].ToString()));
                }
                comboBox2.DisplayMember = "getValue";
                comboBox2.ValueMember = "getData";
                comboBox2.DataSource = comboBox2Data;
            }
            else
            {
                //kategori isimlerini listele
                comboBox2Data = new List<ComboBoxItem>();
                comboBox2Data.Clear();
                string id = ((ComboBoxItem)comboBox1.SelectedItem).getData;
                string query = "select * from tur2 where tur = " + id;
                DataTable dt = DbClass.Select(query);
                foreach (DataRow row in dt.Rows)
                {
                    comboBox2Data.Add(new ComboBoxItem(row[1].ToString(), row[0].ToString()));
                }
                comboBox2.DisplayMember = "getValue";
                comboBox2.ValueMember = "getData";
                comboBox2.DataSource = comboBox2Data;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(Globals.add == true)//ekleme seçildi ise

            {
                if (textBox1.Text != "" || comboBox1.SelectedIndex != -1 || comboBox2.SelectedIndex != -1 || textBox4.Text != "")//veriler boş veya -1 değil ise
                {
                    string query = "insert into [dbo].[collection] ([ad],[tur],[tur2],[yil]) values ('" + textBox1.Text + "','" + ((ComboBoxItem)comboBox1.SelectedItem).getData + "','" + ((ComboBoxItem)comboBox2.SelectedItem).getData + "','" + textBox4.Text + "')";
                    DbClass.Execute(query);//sadece sorgu çalıştır
                    Product p = null;// boş bir product tanımla
                    if (((ComboBoxItem)comboBox1.SelectedItem).getData == "1")
                    {
                        
                        p= new DVD(
                            textBox1.Text,
                            Convert.ToInt32(textBox4.Text),
                            Convert.ToInt32(((ComboBoxItem)comboBox1.SelectedItem).getData),
                            Convert.ToInt32(((ComboBoxItem)comboBox2.SelectedItem).getData));

                    }
                    else if(((ComboBoxItem)comboBox1.SelectedItem).getData == "2")
                    {
                        p = new Kitap(
                            textBox1.Text,
                            Convert.ToInt32(textBox4.Text),
                            Convert.ToInt32(((ComboBoxItem)comboBox1.SelectedItem).getData),
                            Convert.ToInt32(((ComboBoxItem)comboBox2.SelectedItem).getData));

                    }
                    else if(((ComboBoxItem)comboBox1.SelectedItem).getData == "4")
                    {
                        p = new Dergi(
                             textBox1.Text,
                             Convert.ToInt32(textBox4.Text),
                             Convert.ToInt32(((ComboBoxItem)comboBox1.SelectedItem).getData),
                             Convert.ToInt32(((ComboBoxItem)comboBox2.SelectedItem).getData));

                    }
                    DataTable dt = DbClass.Select("select top 1 id from collection order by id desc");
                    int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Globals.productList.Add(id,p); //productList dictionarysine ekle
                    MessageBox.Show("Başarılı!");
                }
            }
            else
            {
                if (textBox1.Text != "" || comboBox1.SelectedIndex != -1 || comboBox2.SelectedIndex != -1 || textBox4.Text != "")
                {
                    string query = "update [dbo].[collection] set [ad]='" + textBox1.Text + "' ,[tur] = '" + ((ComboBoxItem)comboBox1.SelectedItem).getData + "' ,[tur2] ='" + ((ComboBoxItem)comboBox2.SelectedItem).getData + "' ,[yil] = '" + textBox4.Text + "' where id="+Globals.ID;
                    DbClass.Execute(query);//sorguyu çalıştır


                    MessageBox.Show("Başarılı!");
                }

            }
        }
    }
}
