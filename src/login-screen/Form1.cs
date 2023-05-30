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
using System.Diagnostics.Tracing;

namespace login_screen
{
    public partial class login : Form
    {
        // Tạo kết nối global
        SqlConnection conn = new SqlConnection(@"Data Source=PC-AN;Initial Catalog=QLSinhVien;Integrated Security=True");

        public login()
        {
            InitializeComponent();
        }

        /// 
        /// Connect database 
        ///
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //
        // Test box
        //
        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        //
        // Button
        //
        private void loginButton_Click(object sender, EventArgs e)
        {



            string _user = username.Text.Trim();
            Console.WriteLine("USER NAME: " + _user);
            // truong hop ly neu chuoi la varchar, nvarchar
            // choi la ki tu co dau
            // string co luu duoc unicode ???
            string _password = password.Text.Trim();
            Console.WriteLine("PASS WORD: "+ _password);

            string querry =
                "IF(" +
                "   EXISTS( SELECT SV.MASV" +
                "           FROM SINHVIEN SV" +
                "           WHERE SV.TENDN LIKE N'" + _user + "' AND SV.MATKHAU = HASHBYTES('MD5', N'" + _password + "'))" +
                "   OR" +
                "   EXISTS( SELECT NV.MANV" +
                "           FROM NHANVIEN NV" +
                "           WHERE NV.TENDN LIKE N'" + _user + "' AND NV.MATKHAU = HASHBYTES('SHA1', N'" + _password + "'))) " +
                "SELECT 1 ELSE SELECT 0";

            try
            {
                conn.Open();

                Console.WriteLine(querry);
                SqlCommand cmd = new SqlCommand(querry, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read() == true)
                {
                    if (reader.GetValue(0).ToString() == "1")
                    {
                        MessageBox.Show("Login Success!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        username.Text = "";
                        password.Text = "";
                        username.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Login!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        username.Text = "";
                        password.Text = "";
                        username.Focus();
                    }
                }

                reader.Close();
                cmd.Dispose();
                conn.Close();
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("Cannot connect to DB!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void ExitBtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Check box
        private void checkBoxPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPas.Checked)
            {
                password.PasswordChar = '\0';
            }
            else password.PasswordChar = '*'; 
        }


        //
        // No important
        //

        private void panel_image1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
