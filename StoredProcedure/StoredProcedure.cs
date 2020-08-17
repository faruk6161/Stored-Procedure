//////////////////////////////////////////////////////////////////
//    					     			                        //
//                	Coded by Faruk OKSUZ			            //
//                              				                //
//////////////////////////////////////////////////////////////////
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

namespace StoredProcedure
{
    public partial class StoredProcedure : Form
    {
        public StoredProcedure()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=.;Initial Catalog=StoredProcedure;Integrated Security=True");
        SqlDataAdapter adtr;
        DataTable tablo = new DataTable();
        SqlCommand komut;
        DialogResult dialog;
        private void KayitListele()
        {
            tablo.Clear();
            adtr = new SqlDataAdapter("KayitListele", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            KayitListele();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("Ekle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@yoneticiid", Convert.ToInt32(txtYoneticiId.Text));
            komut.Parameters.AddWithValue("@kullaniciadi", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarıyla eklendi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KayitListele();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            dialog = new DialogResult();       
            dialog = MessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz ?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (dialog==DialogResult.Yes)
            {
                baglanti.Open();
                komut = new SqlCommand("Sil", baglanti);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@yoneticiid", dataGridView1.CurrentRow.Cells["yoneticiid"].Value);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Seçili kayıt başarıyla silindi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt silmekten vazgeçildi !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            KayitListele();              
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("Guncelle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@yoneticiid", Convert.ToInt32(txtYoneticiId.Text));
            komut.Parameters.AddWithValue("@kullaniciadi", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Seçili kayıt başarıyla güncellendi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            KayitListele();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtYoneticiId.Text = dataGridView1.CurrentRow.Cells["yoneticiid"].Value.ToString();
            txtKullaniciAdi.Text = dataGridView1.CurrentRow.Cells["kullaniciadi"].Value.ToString();
            txtSifre.Text = dataGridView1.CurrentRow.Cells["sifre"].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells["ad"].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells["soyad"].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is TextBox)
                {
                    Controls[i].Text = "";
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            komut = new SqlCommand("Ara",baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@ad", txtAra.Text);
            adtr = new SqlDataAdapter(komut);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;                
        }
    }
}
