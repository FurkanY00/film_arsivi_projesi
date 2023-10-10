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

namespace film_arsivim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-KPC6PV7\SQLEXPRESS;Initial Catalog=filmarsivim;Integrated Security=True");
        void filmler()
        {
            SqlDataAdapter da =new SqlDataAdapter("select *from tblfılımler",baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void txtfilmad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into tblfılımler (ad,kategori,lınk) values (@p1,@p2,@p3) ", baglantı);
            komut.Parameters.AddWithValue("@p1", txtfilmad.Text);
            komut.Parameters.AddWithValue("@p2",txtkatagori.Text);
            komut.Parameters.AddWithValue("@p3",txtlink.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("film listenize eklendi","bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            filmler();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }
        public int SECİLEN;

        private string link ;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SECİLEN = dataGridView1.SelectedCells[0].RowIndex;
            link = dataGridView1.Rows[SECİLEN].Cells[3].Value.ToString();
            webBrowser1.Navigate(link);
        }

        private void btnhakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BU PROJE FURKAN YILMAZ TARAFINDAN KODLANDI", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btncıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnrenkdegistir_Click(object sender, EventArgs e)
        {
            
            Random Random = new Random();
            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Salmon};
            int randomındex = Random.Next(colors.Length);
            this.BackColor = colors[randomındex];
        }

        private void btnislemler_Click(object sender, EventArgs e)
        {

            tamekran tamekran = new tamekran();
            tamekran.link = link;
            tamekran.Show();
           
        }
    }
}
