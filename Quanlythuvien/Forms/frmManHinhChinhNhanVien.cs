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
    public partial class frmManHinhChinhNhanVien : Form
    {
        public frmManHinhChinhNhanVien()
        {
            InitializeComponent();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NV_DanhMucSach temp = new NV_DanhMucSach();
            panelNV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelNV.BringToFront();
            this.Text = "Danh mục/Sách";
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NV_DanhMucSinhVien temp = new NV_DanhMucSinhVien();
            panelNV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelNV.BringToFront();
            this.Text = "Danh mục/Sinh viên";
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap dangNhap = new frmDangNhap();
            dangNhap.Show();
        }

        private void GiaosachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NV_Giaosach temp = new NV_Giaosach();
            panelNV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelNV.BringToFront();
            this.Text = "Quản lý/Giao sách";
        }

        private void quanlytraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NV_Trasach temp = new NV_Trasach();
            panelNV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelNV.BringToFront();
            this.Text = "Quản lý/Trả sách";
        }

        private void frmManHinhChinhNhanVien_Load(object sender, EventArgs e)
        {
            pnlManHinhChinh.BringToFront();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeSach temp = new frmThongKeSach();
            temp.ShowDialog();
        }

        private void mươnTraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeMuonTra temp = new frmThongKeMuonTra();
            temp.ShowDialog();
        }

        private void btnDanhMucSinhVien_Click(object sender, EventArgs e)
        {

            NV_DanhMucSinhVien temp = new NV_DanhMucSinhVien();
            panelNV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelNV.BringToFront();
            this.Text = "Danh mục/Sinh viên";
        }

        private void btnDanhMucSach_Click(object sender, EventArgs e)
        {

            NV_DanhMucSach temp = new NV_DanhMucSach();
            panelNV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelNV.BringToFront();
            this.Text = "Danh mục/Sách";
        }

        private void btnQuanLyGiaoSach_Click(object sender, EventArgs e)
        {

            NV_Giaosach temp = new NV_Giaosach();
            panelNV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelNV.BringToFront();
            this.Text = "Quản lý/Giao sách";
        }

        private void btnQuanLyTraSach_Click(object sender, EventArgs e)
        {

            NV_Trasach temp = new NV_Trasach();
            panelNV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelNV.BringToFront();
            this.Text = "Quản lý/Trả sách";
        }

        private void sáchĐangMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NV_DanhMucSachDangMuon temp = new NV_DanhMucSachDangMuon();
            panelNV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelNV.BringToFront();
            this.Text = "Quản lý sách đang mượn";
        }

        private void btnThongKeSach_Click(object sender, EventArgs e)
        {
            frmThongKeSach temp = new frmThongKeSach();
            temp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThongKeMuonTra temp = new frmThongKeMuonTra();
            temp.ShowDialog();
        }

        private void btnTrangChinh_Click(object sender, EventArgs e)
        {
            pnlManHinhChinh.BringToFront();
        }

       

        private void veChungTôiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVeChungToi temp = new frmVeChungToi();
            temp.ShowDialog();
        }

        private void btnThongKeMuonTra_Click(object sender, EventArgs e)
        {
            frmThongKeMuonTra temp = new frmThongKeMuonTra();
            temp.ShowDialog();
        }

        private void btnVeChungToi_Click(object sender, EventArgs e)
        {

            frmVeChungToi temp = new frmVeChungToi();
            temp.ShowDialog();
        }

        private void hươngDânphanHôiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sites.google.com/site/hdsdpmqltv/");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NV_DanhMucSachDangMuon temp = new NV_DanhMucSachDangMuon();
            panelNV.Controls.Add(temp);
            temp.Dock = DockStyle.Fill;
            temp.BringToFront();
            panelNV.BringToFront();
            this.Text = "Quản lý sách đang mượn";
        }
    }
}
