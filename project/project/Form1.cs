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

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string UserName, password;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-7AA80CV\SQLEXPRESS; Initial Catalog=Projectdb; Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        { }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                string sql = "Select * from WalletBalance Where UserName=@username AND password=@pass";
                SqlParameter prm1 = new SqlParameter("username", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("pass", textBox2.Text.Trim());
                SqlCommand command1 = new SqlCommand(sql, baglanti);
                command1.Parameters.Add(prm1);
                command1.Parameters.Add(prm2);
                UserName = textBox1.Text;
                password = textBox2.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command1);

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Form2 fr = new Form2();
                    fr.Show();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Giriş");
            }
        }

     
    }
}
