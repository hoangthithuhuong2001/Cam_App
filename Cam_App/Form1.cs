using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cam_App
{
    public partial class form1 : Form
    {
        public bool isExit = true;
        public event EventHandler LogOut;
        public form1()
        {
            InitializeComponent();
        }
        //hàm phân quyền admin
        void Decentralization()
        {
            if(Const.AccountType == false)
            {
                toolstripDangKy.Enabled = false;
            }
        }    

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDangKy f = new formDangKy();
            f.Show();
        }
    //region Event
        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isExit)
            {
                if (MessageBox.Show("Bạn muốn thoát chương trình", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
        private void form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
                Application.Exit();
        }

        private void form1_Load(object sender, EventArgs e)
        {
            Decentralization();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOut(this, new EventArgs()); //hàm ủy thác
        }

        private void toolstripDangKy_Click(object sender, EventArgs e)
        {
            formDangKy f = new formDangKy();
            f.ShowDialog();
        }
    }
}