using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using KoleksiyonTakibi.Classes;

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
    public partial class main : Form
    {
        DbClass dbClass = new DbClass();
        
        List<ComboBoxItem> catList = null;
        public main()
        {
            
            InitializeComponent();

            refreshTable();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            catList = new List<ComboBoxItem>();//kategori listesini oluştur

            comboBox1.Items.Clear(); // combobox temizle

            DataTable dt = dbClass.Select("select * from tur order by id desc");// sorguyu tabloya aktar
            foreach (DataRow satir in dt.Rows)// datatable ı datarow olarak oku
            {
                catList.Add(new ComboBoxItem(satir[1].ToString(), satir[0].ToString()));// kategorilistesine comboboxitem ekle
               
            }
            comboBox1.DisplayMember = "getValue";//görünen değeri gösterecek olan method ismi
            comboBox1.ValueMember = "getData";//arkaplan değerini gösterecek olan methos ismi
            comboBox1.DataSource = catList;//combobox1 veri kaynağını kategorilistesinden al
            comboBox1.SelectedIndex = 0;//0.indexi seç
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            addEdit newForm = new addEdit();
            Globals.add = true;
            newForm.Show();//ekleme formunu göster
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();//çıkış butonu
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Globals.ID != -1)//eğer bir satır seçiliyse
            {
                addEdit newForm = new addEdit();
                Globals.add = false;
                newForm.Show();//düzenleme formunu aç
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() != "")// boş bir yere tıklanmadıysa
            {
                Globals.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());//static ve global id değişkenine id tanımla
            }
            else
            {
                Globals.ID = -1;//boş bir yere tıklanınca -1 e eşitle
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = null;//null datatable oluştur

            int index = Convert.ToInt32(((ComboBoxItem)comboBox1.SelectedItem).getData);
           switch (index)//combobox verisini seç
            {
                case 1002://eğer 1002 id li seçildi ise
                    dt = dbClass.Select("select c.id, c.ad,t.ad,t2.ad,c.yil from collection c inner join tur t on c.tur = t.id inner join tur2 t2 on c.tur2 = t2.id where t.blok = 0 and t2.blok = 0");
                  
                break;
                default://diğerleri seçildi ise
                    dt = dbClass.Select("select c.id, c.ad,t.ad,t2.ad,c.yil from collection c inner join tur t on c.tur = t.id inner join tur2 t2 on c.tur2 = t2.id where t.blok = 0 and t2.blok = 0 and c.tur = " + index.ToString());
                break;
            }
            dataGridView1.DataSource = dt;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Globals.ID != -1 )//eğer boş bir yer seçilmedi ise
            {
                if(MessageBox.Show("İşlemi gerçekleştirmek isteidiğinize emin misiniz?","Silme İşlemi",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dbClass.Execute("delete from collection where id= " + Globals.ID);//sorguyu çalıştır
                    Globals.productList.Remove(Globals.ID);//product listten sil
                }
            }
        }

        private void refreshTable()
        {

            //tüm ürünleri listeleyen veya yenileyen fonksiyon
            DataTable dt = dbClass.Select("select c.id as id, c.ad as ad,t.ad as turisim,t2.ad as tur2isim,c.yil as yil,c.tur as tur,c.tur2 as tur2 from collection c inner join tur t on c.tur = t.id inner join tur2 t2 on c.tur2 = t2.id where t.blok = 0 and t2.blok = 0");
            foreach (DataRow satir in dt.Rows)
            {
                Product p = null;
                if (satir["tur"].ToString() == "1")
                {
                    p = new DVD(satir["ad"].ToString(), Convert.ToInt32(satir["yil"].ToString()), Convert.ToInt32(satir["tur"].ToString()), Convert.ToInt32(satir["tur2"].ToString()));
                }
                else if (satir["tur"].ToString() == "2")
                {
                    p = new Dergi(satir["ad"].ToString(), Convert.ToInt32(satir["yil"].ToString()), Convert.ToInt32(satir["tur"].ToString()), Convert.ToInt32(satir["tur2"].ToString()));
                }
                else if (satir["tur"].ToString() == "4")
                {
                    p = new Kitap(satir["ad"].ToString(), Convert.ToInt32(satir["yil"].ToString()), Convert.ToInt32(satir["tur"].ToString()), Convert.ToInt32(satir["tur2"].ToString()));
                }
                Globals.productList.Add(Convert.ToInt32(satir[0].ToString()),p);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            settings s = new settings();
            s.Show();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            
        }
    }
}
