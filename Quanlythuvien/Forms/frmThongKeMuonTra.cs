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
    public partial class frmThongKeMuonTra : Form
    {
        public frmThongKeMuonTra()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmThongKeMuonTra_Load(object sender, EventArgs e)
        {
           
            rptLuotMuonSachTheoSinhVien.Dock = DockStyle.Fill;
            rptSVTreHan.Dock = DockStyle.Fill;
            

            //report ds sinh viên trễ hạn.          
            this.USP_TKSINHVIENTREHANTableAdapter.Fill(this.DataSet1.USP_TKSINHVIENTREHAN);
            this.rptSVTreHan.RefreshReport();

            //report tổng lượt mượn sách theo sinh viên.
            this.USP_TKLUOTMUONSACHTHEOSVTableAdapter.Fill(this.DataSet1.USP_TKLUOTMUONSACHTHEOSV);
            this.rptLuotMuonSachTheoSinhVien.RefreshReport();
        }

       
    }
}
