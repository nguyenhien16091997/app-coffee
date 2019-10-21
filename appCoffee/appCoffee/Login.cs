using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayers;

namespace appCoffee
{
    public partial class Login : Form
    {
        public static string taiKhoanForm;
        NguoiDungBLL ub = new NguoiDungBLL();
        public Login()
        {
            
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tb_username.Text.Clone();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            
            string userName = tb_username.Text.Trim();
            string password = tb_pass.Text.Trim();

            taiKhoanForm = userName;

            bool bl= ub.CheckLogin(userName,password);
                     
            Admin fm = new Admin();
            if (bl)
            {
                tb_username.Clear();
                tb_pass.Clear();
                this.Hide();
                fm.ShowDialog();
                this.Show();
            }
            else
            {
                tb_username.Clear();
                tb_pass.Clear();

                MessageBox.Show("Tai Khoan hoac Mat Khau sai vui long nhap lai!");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void tb_username_Click(object sender, EventArgs e)
        {
            tb_username.Clear();
        }

        private void tb_pass_Click(object sender, EventArgs e)
        {
            tb_pass.Clear();
            tb_pass.PasswordChar = '*';
        }
    }
}
