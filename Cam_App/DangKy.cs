using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Cam_App
{
    public partial class formDangKy : Form
    {
        List<string> listAccountType = new List<string>() { "Quan ly", "Nhan Vien" };
        int index = -1;
        public formDangKy()
        {
            InitializeComponent();
        }

        void LoadListUser()
        {
            dtgvUser.DataSource = null;
            dtgvUser.DataSource = ListUser.Instance.ListAccountUser;
            dtgvUser.Refresh();
        }

        private void formDangKy_Load(object sender, EventArgs e)
        {
            cboLoaitaikhoan.DataSource = listAccountType;
            LoadListUser();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string userName = txtTaiKhoan.Text;
            string passWord = txtMatKhau.Text;
            bool accountType = false;

            switch (cboLoaitaikhoan.Text)
            {
                case "Quan ly":
                    accountType = true;
                    break;
                case "Nhan Vien":
                    accountType = false;
                    break;
            }

            ListUser.Instance.ListAccountUser.Add(new User(userName, passWord, accountType));
            LoadListUser();

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn 1 bản ghi");
                return;
            }    
                
            string userName = txtTaiKhoan.Text;
            string passWord = txtMatKhau.Text;
            bool accountType = false;

            switch (cboLoaitaikhoan.Text)
            {
                case "Quan ly":
                    accountType = true;
                    break;
                case "Nhan Vien":
                    accountType = false;
                    break;
            }
            ListUser.Instance.ListAccountUser[index].UserName = userName;
            ListUser.Instance.ListAccountUser[index].PassWord = passWord;
            ListUser.Instance.ListAccountUser[index].AccountType = accountType;
            LoadListUser();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn 1 bản ghi");
                return;
            }
            ListUser.Instance.ListAccountUser.RemoveAt(index);
            LoadListUser();
        }

        private void dtgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;

            if (index < 0)
                return;

            txtTaiKhoan.Text = dtgvUser.Rows[index].Cells[0].Value.ToString();
            txtMatKhau.Text = dtgvUser.Rows[index].Cells[1].Value.ToString();

            switch (ListUser.Instance.ListAccountUser[index].AccountType)
            {
                case true: cboLoaitaikhoan.Text = "Quan ly";
                    break;
                case false: cboLoaitaikhoan.Text = "Nhan Vien";
                    break;
            }
        }

        
    }
}
