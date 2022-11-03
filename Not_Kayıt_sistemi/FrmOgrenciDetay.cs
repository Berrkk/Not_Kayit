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
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hasan\DbNotkayıt.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLDERS where OGRNUmara=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAd.Text = dr[2].ToString() + "" + dr[3].ToString();
                lblS1.Text = dr[4].ToString();
                lblS2.Text = dr[5].ToString();
                lblS3.Text = dr[6].ToString();
                lblO.Text = dr[7].ToString();
                lblDurum.Text = dr[8].ToString();
                if (lblDurum.Text == "True")

                {

                    lblDurum.Text = "Gecti";

                }

                else

                {

                    lblDurum.Text = "Kaldi";

                }

            }
            baglanti.Close();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
