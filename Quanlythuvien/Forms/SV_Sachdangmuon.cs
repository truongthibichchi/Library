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
    public partial class SV_Sachdangmuon : UserControl
    {
        public SV_Sachdangmuon()
        {
            InitializeComponent();
        }
        public static string flagMSSV;
        private static SV_Sachdangmuon _instance;
        public static SV_Sachdangmuon Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SV_Sachdangmuon();
                return _instance;
            }
        }

        private void UserControlSV_Sachdangmuon_Load(object sender, EventArgs e)
        {
            flagMSSV = frmManhinhchinhSinhVien.flagMSSV;
            Setupdatagridview();
            DataTable dt =  CUONSACHBUS.Instance._TimkiemsachSVdangmuon(flagMSSV);
            dgvSV_sach.DataSource = CUONSACHBUS.Instance._TimkiemsachSVdangmuon(flagMSSV);
            if(dt.Rows.Count==0)
            {
                pnsachdangmuon.Visible = false;
                lblthongbao.Text = "Không có tài liệu nào đang mượn";
            }
            else
            {
                lblthongbao.Visible = false;
                pnsachdangmuon.Visible = true;
            }
            BindingSachTextbox();

           
        }

        private void Setupdatagridview()
        {
            dgvSV_sach.AutoGenerateColumns = false;
            if (dgvSV_sach.ColumnCount == 0)
            {
                dgvSV_sach.ColumnCount = 4;
                dgvSV_sach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                dgvSV_sach.Columns[0].Name = "mamuon";
                dgvSV_sach.Columns[0].HeaderText = "MÃ MƯỢN";
                dgvSV_sach.Columns[0].Width = 100;
                dgvSV_sach.Columns[0].DataPropertyName = "MAMUON";

                dgvSV_sach.Columns[1].Name = "masach";
                dgvSV_sach.Columns[1].HeaderText = "MÃ SÁCH";
                dgvSV_sach.Columns[1].Width = 100;
                dgvSV_sach.Columns[1].DataPropertyName = "MASACH";

                dgvSV_sach.Columns[2].Name = "Tensach";
                dgvSV_sach.Columns[2].HeaderText = "NHAN ĐỀ";
                dgvSV_sach.Columns[2].Width = 300;
                dgvSV_sach.Columns[2].DataPropertyName = "NHANDE";

                dgvSV_sach.Columns[3].Name = "chude";
                dgvSV_sach.Columns[3].HeaderText = "TÁC GIẢ";
                dgvSV_sach.Columns[3].Width = 350;
                dgvSV_sach.Columns[3].DataPropertyName = "TACGIA";

            }

        }
        
        private void BindingSachTextbox()
        {
            var dt = dgvSV_sach.DataSource;
            txtgiatien.DataBindings.Add("Text", dgvSV_sach.DataSource, "GIATIEN");
            txtmasach.DataBindings.Add("Text", dgvSV_sach.DataSource, "MASACH");
            txtnamxuatban.DataBindings.Add("Text", dgvSV_sach.DataSource, "NAMXUATBAN");
            txtnhaxuatban.DataBindings.Add("Text", dgvSV_sach.DataSource, "NHAXUATBAN");
            txttacgia.DataBindings.Add("Text", dgvSV_sach.DataSource, "TACGIA");
            txttensach.DataBindings.Add("Text", dgvSV_sach.DataSource, "NHANDE");
            txttomtat.DataBindings.Add("Text", dgvSV_sach.DataSource, "TOMTAT");
            cmbngaymuon.DataBindings.Add("Text", dgvSV_sach.DataSource, "NGAYMUON");
            cmbngaytra.DataBindings.Add("Text", dgvSV_sach.DataSource,"HANTRA");
            txtmamuon.DataBindings.Add("Text", dgvSV_sach.DataSource, "MAMUON");
            txtflagtinhtrang.DataBindings.Add("Text", dgvSV_sach.DataSource, "TINHTRANGGIAO");
            if (txtflagtinhtrang.Text == "True")
            {
                ckbdalay.Checked = true;
                ckbdalay.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                ckbdalay.ForeColor = Color.Red;
                ckbchualay.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                ckbchualay.ForeColor = Color.Black;
                ckbchualay.Checked = false;
            }
            else if (txtflagtinhtrang.Text == "False")
            {
                ckbchualay.Checked = true;
                ckbchualay.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                ckbchualay.ForeColor = Color.Red;
                ckbdalay.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                ckbdalay.ForeColor = Color.Black;
                ckbdalay.Checked = false;
            }
            
        }

        private void RemoveBinding()
        {
            txtmamuon.DataBindings.Clear();
            txtgiatien.DataBindings.Clear();
            txtmasach.DataBindings.Clear();
            txtnamxuatban.DataBindings.Clear();
            txtnhaxuatban.DataBindings.Clear();
            txttacgia.DataBindings.Clear();
            txttensach.DataBindings.Clear();
            txttomtat.DataBindings.Clear();
            cmbngaymuon.DataBindings.Clear();
            cmbngaytra.DataBindings.Clear();
            ckbdalay.Checked = false;
            ckbchualay.Checked = false;
            txtflagtinhtrang.DataBindings.Clear();
           
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
       
        private void dgvSV_sach_SelectionChanged(object sender, EventArgs e)
        {
            LoadBookImage();
            if (txtflagtinhtrang.Text == "True")
            {
                ckbdalay.Checked = true;
                ckbchualay.Checked = false;
            }
            else if (txtflagtinhtrang.Text == "False")
            {
                ckbchualay.Checked = true;
                ckbdalay.Checked = false;
            }
            
        }

        private void btnhuymuon_Click(object sender, EventArgs e)
        {
            if(ckbchualay.Checked == true)
            {
                var result = MessageBox.Show("Bạn có muốn hủy mượn sách không?", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (PHIEUMUONBUS.Instance._Huyphieumuonsach(txtmamuon.Text, Convert.ToInt32(txtmasach.Text)) > 0)
                    {
                        var magaysach = CUONSACHBUS.Instance._Laymagaysachbangmasach(Convert.ToInt32(txtmasach.Text));
                        DANHSACHHANGCHOBUS.Instance._Updatehangcho_huymuon(Convert.ToInt32(txtmasach.Text) , magaysach);
                        MessageBox.Show("Hủy thành công!", "Thông báo", MessageBoxButtons.OK);
                        var dt = CUONSACHBUS.Instance._TimkiemsachSVdangmuon(flagMSSV);
                        dgvSV_sach.DataSource = dt;
                        if (dt.Rows.Count == 0) 
                        {
                            pnsachdangmuon.Visible = false;
                            lblthongbao.Text = "Không có tài liệu nào được mượn";
                            lblthongbao.Visible = true;
                        }
                        RemoveBinding();
                        BindingSachTextbox();

                    }
                    else
                    {
                        MessageBox.Show("Hủy thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            else MessageBox.Show("Sách đã được nhận, không thể hủy mượn!");
                
            }

       

       
            
        }


    }


