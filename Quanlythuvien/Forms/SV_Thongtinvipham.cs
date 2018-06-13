using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanlythuvien.BLL;
using Quanlythuvien.DTO;

namespace Quanlythuvien.Forms
{
    public partial class SV_Thongtinvipham : UserControl
    {
        private DataTable dt;
        public SV_Thongtinvipham()
        {
            InitializeComponent();
        }
        private static string flagMSSV;
        private void SV_Thongtinvipham_Load(object sender, EventArgs e)
        {
            flagMSSV = frmManhinhchinhSinhVien.flagMSSV;
            if (HOADONPHATBUS.Instance._Tongsolanvipham(flagMSSV) == 0)
            {
                lblthongbao.Text = "Không có thông tin vi phạm";
                pnthongtinvipham.Visible = false;
                return;
            }
            
            Setupdatagridview();
            dt = HOADONPHATBUS.Instance._GetthongtinhoadonphatbyMSSV(flagMSSV);
            dgv_hoadon.DataSource = dt;
            LoadthongtinSV_textbox(flagMSSV);
            LoadSVImage();
            txtsolanvipham.Text = HOADONPHATBUS.Instance._Tongsolanvipham(flagMSSV).ToString();
            if (dt.Rows.Count > 0)
            {
                txtmahoadon.Text = dt.Rows[0].Field<string>("MAHOADON");
                txtmamuon.Text = dt.Rows[0].Field<string>("MAMUON");
                txttienphat.Text = dt.Rows[0].Field<decimal>("TONGTIENPHAT").ToString();
                dtmngaymuon.Text = dt.Rows[0].Field<DateTime>("NGAYMUON").ToString();
                if (!dt.Rows[0].Field<bool>("TINHTRANGNOP"))
                {
                    radiobtnchuanop.Checked = true;
                    radiobtndanop.Checked = false;
                }
                else
                {
                    radiobtnchuanop.Checked = false;
                    radiobtndanop.Checked = true;
                }
            }
        }

        private void LoadthongtinSV_textbox(string mataikhoan)
        {

            DataTable dt = SINHVIENBUS.Instance._LaythongtinSVbymaTK(flagMSSV);
            txtMSSV.Text = Convert.ToString(dt.Rows[0][0]);
            txthoten.Text = (string)dt.Rows[0][1];
            txtkhoa.Text = (string)dt.Rows[0][5];
            txtlop.Text = (string)dt.Rows[0][6];
        }

        private void LoadSVImage()
        {
            picSV.Visible = true;
            picSV.SizeMode = PictureBoxSizeMode.StretchImage;
            var filePath = @"img_SV\" + txtMSSV.Text + ".jpg";
            try
            {
                picSV.Image = Image.FromFile(filePath);

            }
            catch
            {
                picSV.Image = Image.FromFile(@"img_SV\default.jpg");
            }
        }

        private void Bindingtextbox()
        {
            txtmahoadon.DataBindings.Add("Text", dgv_hoadon.DataSource, "MAHOADON");
            txtmamuon.DataBindings.Add("Text", dgv_hoadon.DataSource, "MAMUON");
            dtmngaymuon.DataBindings.Add("Value", dgv_hoadon.DataSource, "NGAYMUON");
            txttienphat.DataBindings.Add("Text", dgv_hoadon.DataSource, "TONGTIENPHAT");
            radiobtndanop.DataBindings.Add("Checked", dgv_hoadon.DataSource, "TINHTRANGNOP");
        }

        private void Setupdatagridview()
        {
            dgv_hoadon.AutoGenerateColumns = false;
            if (dgv_hoadon.ColumnCount == 0)
            {
                dgv_hoadon.ColumnCount = 3;
                dgv_hoadon.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                dgv_hoadon.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                dgv_hoadon.Columns[0].Name = "mahoadon";
                dgv_hoadon.Columns[0].HeaderText = "MÃ HÓA ĐƠN";
                dgv_hoadon.Columns[0].Width = 150;
                dgv_hoadon.Columns[0].DataPropertyName = "MAHOADON";

                dgv_hoadon.Columns[1].Name = "mamuon";
                dgv_hoadon.Columns[1].HeaderText = "MÃ MƯỢN";
                dgv_hoadon.Columns[1].Width = 150;
                dgv_hoadon.Columns[1].DataPropertyName = "MAMUON";

                dgv_hoadon.Columns[2].Name = "tienphat";
                dgv_hoadon.Columns[2].HeaderText = "TIỀN PHẠT";
                dgv_hoadon.Columns[2].Width = 200;
                dgv_hoadon.Columns[2].DataPropertyName = "TONGTIENPHAT";
            }
        }

        private void dgv_hoadon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_hoadon.SelectedRows.Count == 0)
                return;
            int currentRow = dgv_hoadon.SelectedRows[0].Index;

            if (currentRow >= 0 && currentRow < dt.Rows.Count)
            {
                DataRow r = dt.Rows[currentRow];
                if (dt.Rows.Count > 0)
                {
                    txtmahoadon.Text = r.Field<string>("MAHOADON");
                    txtmamuon.Text = r.Field<string>("MAMUON");
                    txttienphat.Text = r.Field<decimal>("TONGTIENPHAT").ToString();
                    dtmngaymuon.Text = r.Field<DateTime>("NGAYMUON").ToString();
                    if (!r.Field<bool>("TINHTRANGNOP"))
                    {
                        radiobtnchuanop.Checked = true;
                        radiobtndanop.Checked = false;
                    }
                    else
                    {
                        radiobtnchuanop.Checked = false;
                        radiobtndanop.Checked = true;
                    }
                }
            }
            else
            {
                txtmahoadon.Text = "";
                txtmamuon.Text = "";
                txttienphat.Text = "";
                dtmngaymuon.Text = "";
                radiobtnchuanop.Checked = false;
                radiobtndanop.Checked = false;
            }
        }
    }
}
