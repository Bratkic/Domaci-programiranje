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

namespace Puskela
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string cs = "Data source=DESKTOP-P78IF02\\SQLEXPRESS; initial catalog=Auti; integrated security=true";
        DataTable Automobili = new DataTable();
        int red = 0;
        public void osvezi (int x)
        {
            txt_id.Text = Automobili.Rows[x]["ID"].ToString();
            txt_br_sas.Text = Automobili.Rows[x]["br_sasije"].ToString();
            txt_br_mo.Text = Automobili.Rows[x]["br_motora"].ToString();
            txt_mar.Text = Automobili.Rows[x]["marka"].ToString();
            txt_boja.Text = Automobili.Rows[x]["boja"].ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_id.Enabled = false;
            SqlConnection veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Auto", veza);
            adapter.Fill(Automobili);
            osvezi(red);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            red = 0;
            osvezi(red);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (red != 0)
            {
                red--;
                osvezi(red);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (red != Automobili.Rows.Count - 1)
            {
                red++;
                osvezi(red);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            red = Automobili.Rows.Count - 1;
            osvezi(red);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("Insert into Auto (br_sasije,br_motora,marka,boja) values ('" + txt_br_sas.Text + "' ,'" + txt_br_mo.Text + "' ,'" + txt_mar.Text + "' ,'" + txt_boja.Text + "')", veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Auto", veza);
            Automobili.Clear();
            adapter.Fill(Automobili);
            osvezi(red);
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("Delete from Auto where id="+txt_id.Text, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Auto", veza);
            Automobili.Clear();
            adapter.Fill(Automobili);
            if (red == Automobili.Rows.Count)
            {
                red--;
            }
            osvezi(red);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("Update Auto set br_sasije='" + txt_br_sas.Text + "' ,br_motora='" + txt_br_mo.Text + "',marka='" + txt_mar.Text + "',boja='" + txt_boja.Text+"' where id="+txt_id.Text, veza);
             veza.Open();
             naredba.ExecuteNonQuery();
             veza.Close();
             SqlDataAdapter adapter = new SqlDataAdapter("select * from Auto", veza);
             Automobili.Clear();
             adapter.Fill(Automobili);
             osvezi(red);
            
            //MessageBox.Show("Update Auto set br_sasije='" + txt_br_sas.Text + "' ,br_motora='" + txt_br_mo.Text + "',marka='" + txt_mar.Text + "',boja=" + txt_boja.Text + "' where id=" + txt_id.Text);
        }
    }
}
