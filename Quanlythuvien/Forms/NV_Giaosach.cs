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
using System.IO;

namespace Quanlythuvien.Forms
{
    public partial class NV_Giaosach : UserControl
    {
        public NV_Giaosach()
        {
            InitializeComponent();
        }
        public bool flagdagiaosach;
        private static NV_Giaosach _instance;
        public static NV_Giaosach Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NV_Giaosach();
                return _instance;
            }
        }

        private void UserControlNV_Giaosach_Load(object sender, EventArgs e)
        {
            Setupdatagridview();
        }
        private void Setupdatagridview()
        {
            dgv_giaosach.AutoGenerateColumns = false;
            if (dgv_giaosach.ColumnCount == 0)
            {
                dgv_giaosach.ColumnCount = 7;
                dgv_giaosach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                dgv_giaosach.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                dgv_giaosach.Columns[0].Name = "masosinhvien";
                dgv_giaosach.Columns[0].HeaderText = "MSSV";
                dgv_giaosach.Columns[0].Width = 100;
                dgv_giaosach.Columns[0].DataPropertyName = "MATAIKHOAN";

                dgv_giaosach.Columns[1].Name = "Hoten";
                dgv_giaosach.Columns[1].HeaderText = "HỌ TÊN";
                dgv_giaosach.Columns[1].Width = 200;
                dgv_giaosach.Columns[1].DataPropertyName = "HOTEN";

                dgv_giaosach.Columns[2].Name = "masach";
                dgv_giaosach.Columns[2].HeaderText = "MÃ SÁCH";
                dgv_giaosach.Columns[2].Width = 100;
                dgv_giaosach.Columns[2].DataPropertyName = "MASACH";

                dgv_giaosach.Columns[3].Name = "nhande";
                dgv_giaosach.Columns[3].HeaderText = "NHAN ĐỀ";
                dgv_giaosach.Columns[3].Width = 200;
                dgv_giaosach.Columns[3].DataPropertyName = "NHANDE";

                dgv_giaosach.Columns[4].Name = "tacgia";
                dgv_giaosach.Columns[4].HeaderText = "TÁC GIẢ";
                dgv_giaosach.Columns[4].Width = 200;
                dgv_giaosach.Columns[4].DataPropertyName = "TACGIA";

                dgv_giaosach.Columns[5].Name = "ngaymuon";
                dgv_giaosach.Columns[5].HeaderText = "NGÀY MƯỢN";
                dgv_giaosach.Columns[5].Width = 100;
                dgv_giaosach.Columns[5].DataPropertyName = "NGAYMUON";

                dgv_giaosach.Columns[6].Name = "hantra";
                dgv_giaosach.Columns[6].HeaderText = "HẠN TRẢ";
                dgv_giaosach.Columns[6].Width = 100;
                dgv_giaosach.Columns[6].DataPropertyName = "HANTRA";

            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            Removebindingtextbox();
            try 
            {
                if (!string.IsNullOrEmpty(txtMSSV.Text))
                {
                    if (SINHVIENBUS.Instance._Kiemtramasosinhvien(txtMSSV.Text))
                    {
                        DataTable dt = CUONSACHBUS.Instance._TimkiemsachSVdangmuon(txtMSSV.Text);
                        dgv_giaosach.DataSource = dt;
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        Bindingtextbox();
                        LoadBookImage();
                        LoadSVImage();
                    }
                    else MessageBox.Show("Mã số sinh viên không đúng!!!", "Thông báo");
                }
                else MessageBox.Show("Hãy nhập mã số sinh viên", "Thông báo");

            }

            catch 
            {
                MessageBox.Show("Lỗi. Hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        
        private void LoadBookImage()
        {
            picsach.SizeMode = PictureBoxSizeMode.StretchImage;
            var filePath = @"img_book\" + txtmasach.Text + ".jpg";
            try
            {
                picsach.Image = Image.FromFile(filePath);

            }
            catch
            {
                picsach.Image = Image.FromFile(@"img_book\default.jpg");
            }

        }

        private void LoadSVImage()
        {
            picSV.Visible = true;
            picSV.SizeMode = PictureBoxSizeMode.StretchImage;

            if (txtMSSV.Text == "") return;

            var filePath = @"img_SV\" + txtMSSV.Text + ".jpg";

            if (File.Exists(filePath))
            {
                using (FileStream f = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    picSV.Image = Image.FromStream(f);
                }
            }
            else
            {
                picSV.Image = new Bitmap(@"img_SV\default.jpg");
            }

        }
        
        private void Bindingtextbox()
        {
            txtHoVaTen.DataBindings.Add("Text", dgv_giaosach.DataSource, "HOTEN");
            txtmasinhvien.DataBindings.Add("Text", dgv_giaosach.DataSource, "MATAIKHOAN");
            txtmamuon.DataBindings.Add("Text", dgv_giaosach.DataSource, "MAMUON");
            txtmasach.DataBindings.Add("Text", dgv_giaosach.DataSource, "MASACH");
            txtTenSach.DataBindings.Add("Text", dgv_giaosach.DataSource, "NHANDE");
            dtmNgayMuon.DataBindings.Add("Text", dgv_giaosach.DataSource, "NGAYMUON");
            dtmHanTra.DataBindings.Add("Text", dgv_giaosach.DataSource, "HANTRA");
            chkDaGiaoSach.DataBindings.Add("Checked", dgv_giaosach.DataSource, "TINHTRANGGIAO");
         

        }

        private void Removebindingtextbox()
        {
            txtmasinhvien.DataBindings.Clear();
            txtHoVaTen.DataBindings.Clear();
            txtmamuon.DataBindings.Clear();
            txtmasach.DataBindings.Clear();
            txtTenSach.DataBindings.Clear();
            dtmNgayMuon.DataBindings.Clear();
            dtmHanTra.DataBindings.Clear();
            chkDaGiaoSach.DataBindings.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (CHITIETPHIEUMUONBUS.Instance._Kiemtratinhtranggiaosach(txtmamuon.Text , Convert.ToInt32(txtmasach.Text)))
            {
                MessageBox.Show("Sách này đã được giao!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (chkDaGiaoSach.Checked == true)
                {
                    if (CHITIETPHIEUMUONBUS.Instance._Luutinhtranggiaosach(txtmamuon.Text, Convert.ToInt32(txtmasach.Text)) > 0)
                    {
                        MessageBox.Show("Lưu thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy xác nhận giao sách!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void Cleartextbox()
        {
            txtmasinhvien.Clear();
            txtHoVaTen.Clear();
            txtmamuon.Clear();
            txtmasach.Clear();
            txtTenSach.Clear();
            dtmHanTra.ResetText();
            dtmNgayMuon.ResetText();
            chkDaGiaoSach.Checked = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            dgv_giaosach.DataSource = null;
            Cleartextbox();
            txtMSSV.Text = "";
        }

        private void txtMSSV_TextChanged(object sender, EventArgs e)
        {
            dgv_giaosach.DataSource = null;
            Cleartextbox();

        }

       
       
    }

}
