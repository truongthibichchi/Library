using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlythuvien.Forms
{
    public partial class frmManhinhchinhSinhVien : Form
    {
        public frmManhinhchinhSinhVien()
        {
            InitializeComponent();
        }
        public static string flagMSSV;
       
 
        public frmManhinhchinhSinhVien(string flag)
        {
            InitializeComponent();
            flagMSSV = flag;
        }


        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panelSV.Controls.Clear();
            UserControlSV_Thongtincanhan temp = new UserControlSV_Thongtincanhan();
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelSV.BringToFront();
            this.Text = "Thông tin tài khoản/Thông tin cá nhân";           
        }

        private void sáchĐangĐượcMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSV.Controls.Clear();
            SV_Tracuu_Sach_Ten temp = new SV_Tracuu_Sach_Ten();
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            this.Text = "Tra cứu/Sách/Theo tình trạng";
        }

        private void thôngTinMượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSV.Controls.Clear();
            SV_Sachdangmuon temp = new SV_Sachdangmuon();
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelSV.BringToFront();
            this.Text = "Thông tin cá nhân/Danh sách tài liệu đang mượn";
        }


        private void danhSáchTàiLiệuHàngChờToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSV.Controls.Clear();
            SV_Danhsachhangcho temp = new SV_Danhsachhangcho();
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelSV.BringToFront();
            this.Text = "Thông tin tài khoản/Danh sách tài liệu hàng chờ";
            
        }


        private void thôngTinViPhạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSV.Controls.Clear();
            SV_Thongtinvipham temp = new SV_Thongtinvipham();
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelSV.BringToFront();  
            this.Text = "Thông tin tài khoản/Thông tin vi phạm";
        }

        private void quiĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSV.Controls.Clear();
            UC_SV_Qui_định temp = new UC_SV_Qui_định(this);
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelSV.BringToFront();
            this.Text = "Tra cứu/Qui định";
        }

        private void frmManhinhchinhSinhVien_Load(object sender, EventArgs e)
        {
            lblMSSV.Text = flagMSSV;
            pnlManHinhChinh.BringToFront();
        }

        private void frmManhinhchinhSinhVien_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void DangxuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void frmManhinhchinhSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NV_DanhMucSachSinhVien temp = new NV_DanhMucSachSinhVien();
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelSV.BringToFront();
            this.Text = "Danh mục/Sách";
        }

        private void btnTraCuuSach_Click(object sender, EventArgs e)
        {

            NV_DanhMucSachSinhVien temp = new NV_DanhMucSachSinhVien();
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelSV.BringToFront();
            this.Text = "Danh mục/Sách";
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            panelSV.Controls.Clear();
            UserControlSV_Thongtincanhan temp = new UserControlSV_Thongtincanhan();
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelSV.BringToFront();
            this.Text = "Thông tin tài khoản/Thông tin cá nhân";
        }

        private void btnDanhSachTaiLieuDangMuon_Click(object sender, EventArgs e)
        {

            panelSV.Controls.Clear();
            SV_Sachdangmuon temp = new SV_Sachdangmuon();
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelSV.BringToFront();
            this.Text = "Thông tin cá nhân/Danh sách tài liệu đang mượn";
        }

        private void btnDanhSachTaiLieuDangCho_Click(object sender, EventArgs e)
        {

            panelSV.Controls.Clear();
            SV_Danhsachhangcho temp = new SV_Danhsachhangcho();
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelSV.BringToFront();
            this.Text = "Thông tin tài khoản/Danh sách tài liệu hàng chờ";
        }

        private void btnThongTinViPham_Click(object sender, EventArgs e)
        {

            panelSV.Controls.Clear();
            SV_Thongtinvipham temp = new SV_Thongtinvipham();
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelSV.BringToFront();
            this.Text = "Thông tin tài khoản/Thông tin vi phạm";
        }

        private void btnTraCuuQuyDinh_Click(object sender, EventArgs e)
        {

            panelSV.Controls.Clear();
            UC_SV_Qui_định temp = new UC_SV_Qui_định(this);
            panelSV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelSV.BringToFront();
            this.Text = "Tra cứu/Qui định";
        }

        private void btnTrangChinh_Click(object sender, EventArgs e)
        {
            this.pnlManHinhChinh.BringToFront();
        }
    }
}
