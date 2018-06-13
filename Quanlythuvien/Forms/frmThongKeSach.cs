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
    public partial class frmThongKeSach : Form
    {
        public frmThongKeSach()
        {
            InitializeComponent();
        }

        private void frmThongKeSach_Load(object sender, EventArgs e)
        {
            //report tất cả cách sách.
            this.USP_TKTATCASACHTableAdapter.Fill(this.DataSet1.USP_TKTATCASACH);
            this.rptTatCaSach.RefreshReport();
            this.rptTatCaSach.Dock = DockStyle.Fill;
            this.rptTatCaSach.BringToFront();
            //report sách hư hỏng hoặc đã mất.
            this.USP_TKSACHHUHONG_DAMATTableAdapter.Fill(this.DataSet1.USP_TKSACHHUHONG_DAMAT);
            this.rptSachHuHong_DaMat.RefreshReport();
            //report tổng sách theo từng năm.
            this.USP_TKTONGSACHTHEOTUNGNAMTableAdapter.Fill(this.DataSet1.USP_TKTONGSACHTHEOTUNGNAM);
            this.rptTongSachTheoTungNam.RefreshReport();
            //report top 10 sách được mượn nhiều nhất.
            this.USP_TKTOP10SACHDUOCMUONTableAdapter.Fill(this.DataSet1.USP_TKTOP10SACHDUOCMUON);
            this.rptTop10SachDuocMuon.RefreshReport();
        }

        private void btnTatCaSach_Click(object sender, EventArgs e)
        {
            this.rptTatCaSach.Dock = DockStyle.Fill;
            this.rptTatCaSach.BringToFront();
            this.Text = "Thống kê sách/Tất cả sách";
        }

        private void btnSachDuocMuonNhieuNhat_Click(object sender, EventArgs e)
        {
            this.rptTop10SachDuocMuon.Dock = DockStyle.Fill;
            this.rptTop10SachDuocMuon.BringToFront();
            this.Text = "Thống kê sách/Sách được mượn nhiều nhất";
        }

        private void btnTongSachTheoTungNam_Click(object sender, EventArgs e)
        {
            this.rptTongSachTheoTungNam.Dock = DockStyle.Fill;
            this.rptTongSachTheoTungNam.BringToFront();
            this.Text = "Thống kê sách/Tổng sách theo từng năm";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.rptSachHuHong_DaMat.Dock = DockStyle.Fill;
            this.rptSachHuHong_DaMat.BringToFront();
            this.Text = "Thống kê sách/Sách bị hư hỏng/mất";
        }
    }
}
