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

namespace Not_Kayıt_sistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hasan\DbNotkayıt.mdf;Integrated Security=True;Connect Timeout=30");
        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotkayıtDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotkayıtDataSet.TBLDERS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS(OGRNUMARA,OGRAD,OGRSOYAD)values (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1", MskNumara.Text);
            komut.Parameters.AddWithValue("@p2", TxtAd.Text);
            komut.Parameters.AddWithValue("@p3", TxtSad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ögrenci Sisteme Eklendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotkayıtDataSet.TBLDERS);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            MskNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtSad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtS1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtS2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtS3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, sınav1, sınav2, sınav3;
            string durum;
            sınav1 = Convert.ToDouble(TxtS1.Text);
            sınav2 = Convert.ToDouble(TxtS2.Text);
            sınav3 = Convert.ToDouble(TxtS3.Text);

            ortalama = (sınav1 + sınav2 + sınav3) / 3;
            LblOrt.Text = ortalama.ToString();

            if(ortalama>=50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set OGRS1=@p1, OGRS2=@p2, OGRS3=@p3, ORTALAMA=@p4,DURUM=@p5 WHERE OGRNUMARA=@p6",baglanti );
            komut.Parameters.AddWithValue("@p1", TxtS1.Text);
            komut.Parameters.AddWithValue("@p2", TxtS2.Text);
            komut.Parameters.AddWithValue("@p3", TxtS3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(LblOrt.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.Parameters.AddWithValue("@p6", MskNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotkayıtDataSet.TBLDERS);

        }
    }
}
