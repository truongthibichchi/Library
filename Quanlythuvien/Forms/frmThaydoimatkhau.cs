using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanlythuvien.BLL;
using Quanlythuvien.DTO;

namespace Quanlythuvien.Forms
{
    public partial class frmThaydoimatkhau : Form
    {
        public frmThaydoimatkhau()
        {
            InitializeComponent();
        }
        public static string flagMSSV;

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if (txtmatkhaumoi.Text != txtxacnhanmatkhau.Text)
            {
                lblthongbao.Text = "Xác nhận mật khẩu không đúng!";
                Cleartextbox();
            }
            else
            {
                if (TAIKHOANBUS.Instance._Doimatkhau(flagMSSV,txtmatkhaucu.Text,txtmatkhaumoi.Text) <= 0)
                {
                    lblthongbao.Text = "Mật khẩu không đúng!";
                    Cleartextbox();
                }
                else
                {
                    MessageBox.Show("Thay đổi thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                    
                }

            }
        }

        private void frmThaydoimatkhau_Load(object sender, EventArgs e)
        {
            flagMSSV = frmManhinhchinhSinhVien.flagMSSV;
            lblthongbao.Text = "";
        }

        private void Cleartextbox()
        {
            txtmatkhaucu.Clear();
            txtmatkhaumoi.Clear();
            txtxacnhanmatkhau.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
