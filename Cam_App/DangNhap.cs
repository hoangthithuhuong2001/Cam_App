using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cam_App
{
    public partial class formDangNhap : Form
    {
        public formDangNhap()
        {
            InitializeComponent();
        }

        //kiểm tra tài khoản đúng k
        bool CheckLogin(string userName, string passWord)
        {
            for(int i = 0; i < ListUser.Instance.ListAccountUser.Count; i++)
            {
                if(userName == ListUser.Instance.ListAccountUser[i].UserName && passWord == ListUser.Instance.ListAccountUser[i].PassWord)
                {
                    Const.AccountType = ListUser.Instance.ListAccountUser[i].AccountType;
                    return true;
                }    
            }    
            return false;
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txtTaiKhoan.Text;
            string passWord = txtMatKhau.Text;
            if(CheckLogin(userName, passWord))
            {
                form1 f = new form1();
                f.Show();
                this.Hide();
                f.LogOut += F_LogOut;
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK);
                txtTaiKhoan.Focus();
                return;
            }
           
        }

        private void F_LogOut(object sender, EventArgs e)
        {
            (sender as form1).isExit = false;
            (sender as form1).Close();
            this.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxHienThiMatKhau.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }    
            if(!checkBoxHienThiMatKhau.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }    
        }
    }
}
