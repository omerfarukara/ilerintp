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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            timer1.Start();

        }
        public static string UserName, password;
        int sayac = 0;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CJENQD5\SQLEXPRESS; Initial Catalog=WalletBalancedb; Integrated Security=True");

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            guna2CircleProgressBar1.Value = sayac;
            label3.Text = sayac.ToString();

            if (sayac % 60 == 0)
            {
                int b = Convert.ToInt32(label7.Text);
                b--;
                label7.Text = Convert.ToString(b);
            }

            if (sayac==3600)
            {
                timer1.Stop();
                Application.Exit();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.UserName;
            textBox2.Text = Form1.password;


            baglanti.Open();
            SqlCommand command2 = new SqlCommand();
            command2.Connection = baglanti;
            command2.CommandText = "SELECT * FROM WalletBalance WHERE UserName='" + textBox1.Text + "'";
            SqlDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                textBox3.Text = reader["money"].ToString();
            }
            baglanti.Close();
            label7.Text = textBox3.Text;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            guna2Button3.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = Form1.UserName;
            textBox2.Text = Form1.password;

            baglanti.Open();
            string register = "Update WalletBalance set money=@money where UserName=@username AND password=@pass";
            SqlParameter prm1 = new SqlParameter("username", textBox1.Text.Trim());
            SqlParameter prm2 = new SqlParameter("pass", textBox2.Text.Trim());
            SqlCommand command = new SqlCommand(register, baglanti);
            command.Parameters.Add(prm1);
            command.Parameters.Add(prm2);
            UserName = textBox1.Text;
            password = textBox2.Text;
            command.Parameters.AddWithValue("@money",label7.Text);
            command.ExecuteNonQuery();
            baglanti.Close();
            Application.Exit();
        }
    }
}
