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
using Outlook = Microsoft.Office.Interop.Outlook;


namespace Quanlythuvien.Forms
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private static frmDangNhap _instance;
        public static frmDangNhap Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmDangNhap();
                return _instance;
            }
        }

      
        
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txttaikhoan.Clear();
            txtmatkhau.Clear();
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            if (!TAIKHOANBUS.Instance._Kiemtrataikhoan(txttaikhoan.Text, txtmatkhau.Text))
            {
                lblmessage.Text = "Tài khoản và mật khẩu không đúng";
                txtmatkhau.Clear();
                txttaikhoan.Clear();
                txttaikhoan.Focus();
            }
            else
            {
                if ((int)TAIKHOANBUS.Instance._Kiemtraloaitaikhoan(txttaikhoan.Text) == 0)
                {
                    this.Hide();
                    frmManHinhChinhNhanVien frmnhanvien = new frmManHinhChinhNhanVien();
                    frmnhanvien.ShowDialog();
                    this.Show();
                    lblmessage.Text = "";
                }
                else
                {
                    this.Hide();
                    frmManhinhchinhSinhVien frmsinhvien = new frmManhinhchinhSinhVien(txttaikhoan.Text);
                    frmsinhvien.ShowDialog();
                    this.Show();
                    lblmessage.Text = "";
                }
            }
        }


        public  void TaoEmail()
        {         
            Outlook.Application app = new Outlook.Application();
            Outlook.MailItem Email = app.CreateItem(Outlook.OlItemType.olMailItem);
            Email.Subject = string.Format("[Reset mật khẩu thư viện]");
            Email.To = "thuvien@abc.edu.vn";
            Email.Importance = Outlook.OlImportance.olImportanceHigh;
            Email.Display(false);
        }

        private void llblQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           DialogResult drKetQua= MessageBox.Show("Trong trường hợp quên mật khẩu, bạn sẽ phải gởi Email đến thuvien@abc.edu.vn để xin reset lại mật khẩu. Bạn tiếp tục chứ!(Tốn vài giây để kết nối!)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (drKetQua == DialogResult.Yes)
            {
                TaoEmail();
            }                              
        }
    }
}
