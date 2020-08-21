using KoleksiyonTakibi.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KoleksiyonTakibi
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }
        DbClass dbClass = new DbClass();
        bool catKont = false, turKont = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                comboBox1.Enabled = true;
                catKont = true;
            }
            else
            {
                catKont = false;
                comboBox1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                turKont = true;
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
            }
            else
            {
                turKont = false;
                checkBox1.Checked = false;
                checkBox1.Enabled = true;
                comboBox2.Enabled = false;
            }
        }
        List<ComboBoxItem> comboBox1Data;
        List<ComboBoxItem> comboBox2Data;
        
        public void listBoxYenile()
        {
            DataTable dt = null;
            listBox1.Items.Clear();
            dt = dbClass.select("select * from tur where blok = 1");
            foreach (DataRow row1 in dt.Rows)
            {
                listBox1.Items.Add(new ListBoxItem(row1[1].ToString(), row1[0].ToString()));
            }
            listBox1.DisplayMember = "getValue";
            listBox1.ValueMember = "getData";

            listBox2.Items.Clear();
            dt = dbClass.select("select * from tur2 where blok = 1");
            foreach (DataRow row1 in dt.Rows)
            {
                listBox2.Items.Add(new ListBoxItem(row1[1].ToString(), row1[0].ToString()));
            }
            listBox2.DisplayMember = "getValue";
            listBox2.ValueMember = "getData";
        }

        private void settings_Load(object sender, EventArgs e)
        {
            comboBox1Data = new List<ComboBoxItem>();
            comboBox1.Items.Clear();
            DataTable dt = dbClass.select("select * from tur");
            foreach (DataRow row in dt.Rows)
            {
                comboBox1Data.Add(new ComboBoxItem(row[1].ToString(), row[0].ToString()));
            }

            comboBox1.DisplayMember = "getValue";
            comboBox1.ValueMember = "getData";
            comboBox1.DataSource = comboBox1Data;


            listBoxYenile();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2Data = new List<ComboBoxItem>();
            comboBox2Data.Clear();
            string id = ((ComboBoxItem)comboBox1.SelectedItem).getData;
            string query = "select * from tur2 where tur = " + id;
            DataTable dt = dbClass.select(query);
            foreach (DataRow row in dt.Rows)
            {
                comboBox2Data.Add(new ComboBoxItem(row[1].ToString(), row[0].ToString()));
            }
            comboBox2.DisplayMember = "getValue";
            comboBox2.ValueMember = "getData";
            comboBox2.DataSource = comboBox2Data;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int getID = Convert.ToInt32(((ListBoxItem)listBox1.SelectedItem).getData);
            dbClass.Execute("update tur set blok = '0' where id=" + getID.ToString());

            listBoxYenile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int getID = Convert.ToInt32(((ListBoxItem)listBox2.SelectedItem).getData);
            dbClass.Execute("update tur2 set blok = '0' where id=" + getID.ToString());

            listBoxYenile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(catKont == true)
            {
                dbClass.Execute("update tur set blok = '1' where id=" + ((ComboBoxItem)comboBox1.SelectedItem).getData);
            }
            else if(turKont == true)
            {
                dbClass.Execute("update tur2 set blok = '1' where id=" + ((ComboBoxItem)comboBox2.SelectedItem).getData);
            }

            listBoxYenile();

        }
    }
}
