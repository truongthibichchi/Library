using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanlythuvien.DAO;
using Quanlythuvien.BLL;

namespace Quanlythuvien.Forms
{
    public partial class SV_Danhsachhangcho : UserControl
    {
        public SV_Danhsachhangcho()
        {
            InitializeComponent();
        }
        private static string flagMSSV;
        private static SV_Danhsachhangcho _instance;
        public static SV_Danhsachhangcho Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SV_Danhsachhangcho();
                return _instance;
            }
        }

        private void UserControlSV_danhsachhangcho_Load(object sender, EventArgs e)
        {
            flagMSSV = frmManhinhchinhSinhVien.flagMSSV;
            DataTable dt =  DANHSACHHANGCHOBUS.Instance._Laythongtinsachhangcho(flagMSSV);
            if (dt.Rows.Count == 0)
            {
                pnsachhangcho.Visible = false;
                lblthongbao.Text = "Không có tài liệu nào trong hàng chờ";
            }
            else
            {
                lblthongbao.Visible = false;
                pnsachhangcho.Visible = true;
            }
            Setupdatagridview();
            BindingSachTextbox();
        }

        private void Setupdatagridview()
        {
            dgvSV_sachhangcho.AutoGenerateColumns = false;
            if (dgvSV_sachhangcho.ColumnCount == 0)
            {
                dgvSV_sachhangcho.ColumnCount = 4;
                dgvSV_sachhangcho.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                dgvSV_sachhangcho.Columns[0].Name = "masach";
                dgvSV_sachhangcho.Columns[0].HeaderText = "MÃ GÁY SÁCH";
                dgvSV_sachhangcho.Columns[0].Width = 90;
                dgvSV_sachhangcho.Columns[0].DataPropertyName = "MAGAYSACH";

                dgvSV_sachhangcho.Columns[1].Name = "Tensach";
                dgvSV_sachhangcho.Columns[1].HeaderText = "NHAN ĐỀ";
                dgvSV_sachhangcho.Columns[1].Width = 300;
                dgvSV_sachhangcho.Columns[1].DataPropertyName = "NHANDE";

                dgvSV_sachhangcho.Columns[2].Name = "tacgia";
                dgvSV_sachhangcho.Columns[2].HeaderText = "TÁC GIẢ";
                dgvSV_sachhangcho.Columns[2].Width = 350;
                dgvSV_sachhangcho.Columns[2].DataPropertyName = "TACGIA";

                dgvSV_sachhangcho.Columns[3].Name = "ngaydangky";
                dgvSV_sachhangcho.Columns[3].HeaderText = "NGÀY ĐĂNG KÝ";
                dgvSV_sachhangcho.Columns[3].Width = 90;
                dgvSV_sachhangcho.Columns[3].DataPropertyName = "NGAYDK";



            }
        }

        private void BindingSachTextbox()
        {

            dgvSV_sachhangcho.DataSource = DANHSACHHANGCHOBUS.Instance._Laythongtinsachhangcho(flagMSSV);
            txtgiatien.DataBindings.Add("Text", dgvSV_sachhangcho.DataSource, "GIATIEN");
            txtmagaysach.DataBindings.Add("Text", dgvSV_sachhangcho.DataSource, "MAGAYSACH");
            txtnamxuatban.DataBindings.Add("Text", dgvSV_sachhangcho.DataSource, "NAMXUATBAN");
            txtnhaxuatban.DataBindings.Add("Text", dgvSV_sachhangcho.DataSource, "NHAXUATBAN");
            txttacgia.DataBindings.Add("Text", dgvSV_sachhangcho.DataSource, "TACGIA");
            txttensach.DataBindings.Add("Text", dgvSV_sachhangcho.DataSource, "NHANDE");
            txttomtat.DataBindings.Add("Text", dgvSV_sachhangcho.DataSource, "TOMTAT");
            cmbngaydangky.DataBindings.Add("Text", dgvSV_sachhangcho.DataSource, "NGAYDK");
            txtsoluot.DataBindings.Add("Text", dgvSV_sachhangcho.DataSource, "STT");
  
        }
        private void RemoveBinding()
        {

            txtgiatien.DataBindings.Clear();
            txtmagaysach.DataBindings.Clear();
            txtnamxuatban.DataBindings.Clear();
            txtnhaxuatban.DataBindings.Clear();
            txttacgia.DataBindings.Clear();
            txttensach.DataBindings.Clear();
            txttomtat.DataBindings.Clear();
            cmbhantragannhat.DataBindings.Clear();
            cmbngaydangky.DataBindings.Clear();
            txtsoluot.DataBindings.Clear();


        }

        private void LoadBookImage()
        {
            picsach.SizeMode = PictureBoxSizeMode.StretchImage;
            var filePath = @"img_book\" + txtmagaysach.Text + ".jpg";
            try
            {
                picsach.Image = Image.FromFile(filePath);

            }
            catch
            {
                picsach.Image = Image.FromFile(@"img_book\default.jpg");
            }

        }

        private void dgvSV_sachhangcho_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                LoadBookImage();
                if (!string.IsNullOrEmpty(txtmagaysach.Text))
                {
                    DateTime dt = PHIEUMUONBUS.Instance._Layhantracuasachhangcho(txtmagaysach.Text);
                    cmbhantragannhat.Text = Convert.ToString(dt);
                    cmbngaymuon.Value = cmbhantragannhat.Value.AddMonths((Convert.ToInt32(txtsoluot.Text) -1 ) * 3);
                }
                else
                    cmbhantragannhat.Text = null;
            }
            catch
            {
                MessageBox.Show("Lỗi!!!");
            }
        }

        private void btnhuymuon_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn hủy chờ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (DANHSACHHANGCHOBUS.Instance._Updatehangcho(flagMSSV, Convert.ToInt32(txtmagaysach.Text)) > 0)
                {
                    MessageBox.Show("Xóa thành công", "Thông báo");
                   
                    var dt = DANHSACHHANGCHOBUS.Instance._Laythongtinsachhangcho(flagMSSV);
                    dgvSV_sachhangcho.DataSource = dt;
                    if (dt.Rows.Count == 0)
                    {
                        pnsachhangcho.Visible = false;
                        lblthongbao.Text = "Không có tài liệu nào trong hàng chờ ";
                        lblthongbao.Visible = true;
                    }
                    RemoveBinding();
                    BindingSachTextbox();
                }
                else MessageBox.Show("Lỗi!!!", "Thông báo");
            }
            

        }

        private void dgvSV_sachhangcho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnsachhangcho_Paint(object sender, PaintEventArgs e)
        {

        }

       

       
    }
}
