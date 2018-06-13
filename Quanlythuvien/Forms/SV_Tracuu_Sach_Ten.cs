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
using System.IO;


namespace Quanlythuvien.Forms
{
    public partial class SV_Tracuu_Sach_Ten : UserControl
    {
        public SV_Tracuu_Sach_Ten()
        {
            InitializeComponent();
        }
        public static string flagMSSV;
        private static SV_Tracuu_Sach_Ten _instance;
        public static SV_Tracuu_Sach_Ten Instance
        {
            get
            {
                if (_instance == null)
                _instance = new SV_Tracuu_Sach_Ten();
                return _instance;
            }
        }

      
        public void Setupdatagridview()
        {
            dgvsach.AutoGenerateColumns = false;
            if (dgvsach.ColumnCount == 0)
            {
                dgvsach.ColumnCount = 4;
                dgvsach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                dgvsach.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                dgvsach.Columns[0].Name = "masach";
                dgvsach.Columns[0].HeaderText = "MÃ SÁCH";
                dgvsach.Columns[0].Width = 100;
                dgvsach.Columns[0].DataPropertyName = "MASACH";

                dgvsach.Columns[1].Name = "nhande";
                dgvsach.Columns[1].HeaderText = "NHAN ĐỀ";
                dgvsach.Columns[1].Width = 200;
                dgvsach.Columns[1].DataPropertyName = "NHANDE";

                dgvsach.Columns[2].Name = "tacgia";
                dgvsach.Columns[2].HeaderText = "TÁC GIẢ";
                dgvsach.Columns[2].Width = 300;
                dgvsach.Columns[2].DataPropertyName = "TACGIA";

                dgvsach.Columns[3].Name = "tomtat";
                dgvsach.Columns[3].HeaderText = "TÓM TẮT";
                dgvsach.Columns[3].Width = 400;
                dgvsach.Columns[3].DataPropertyName = "TOMTAT";
            }
        }

        public void BindingSachTextbox()
        {
            var dt = dgvsach.DataSource;
            txtchude.DataBindings.Add("Text", dgvsach.DataSource, "TENCHUDE");
            txtgiatien.DataBindings.Add("Text", dgvsach.DataSource, "GIATIEN");
            txtmasach.DataBindings.Add("Text", dgvsach.DataSource, "MASACH");
            txtnamxuatban.DataBindings.Add("Text", dgvsach.DataSource, "NAMXUATBAN");
            txtnhaxuatban.DataBindings.Add("Text", dgvsach.DataSource, "NHAXUATBAN");
            txttacgia.DataBindings.Add("Text", dgvsach.DataSource, "TACGIA");
            txttensach.DataBindings.Add("Text", dgvsach.DataSource, "NHANDE");
            txttomtat.DataBindings.Add("Text", dgvsach.DataSource, "TOMTAT");
            txtsotrang.DataBindings.Add("Text", dgvsach.DataSource, "SOTRANG");
            ckbduocmuon.DataBindings.Add("Checked", dgvsach.DataSource, "DUOCMUON");
            ckbtinhtrang.DataBindings.Add("Checked", dgvsach.DataSource, "TINHTRANG");
            txtflag_hientrang.DataBindings.Add("Text", dgvsach.DataSource, "HIENTRANGSACH");
            if (txtflag_hientrang.Text == "-1")
            {
                radiobtnmat.Checked = true;
            }
            else if (txtflag_hientrang.Text == "0")
            {
                radiobtnhuhong.Checked = true;

            }
            else radiobtnnguyenven.Checked = true;

        }
        public void RemoveBindingTextbox()
        {
            txtchude.DataBindings.Clear();
            txtgiatien.DataBindings.Clear();
            txtmasach.DataBindings.Clear();
            txtnamxuatban.DataBindings.Clear();
            txtnhaxuatban.DataBindings.Clear();
            txtsotrang.DataBindings.Clear();
            txttacgia.DataBindings.Clear();
            txttensach.DataBindings.Clear();
            txttomtat.DataBindings.Clear();
            ckbduocmuon.DataBindings.Clear();
            ckbtinhtrang.DataBindings.Clear();
            txtflag_hientrang.DataBindings.Clear();
           

        }

        private void LoadBookImage()
        {
            picsach.Visible = true;
            picsach.SizeMode = PictureBoxSizeMode.StretchImage;

            if (string.IsNullOrEmpty(txtmasach.Text)) return;

            var filePath = @"img_book\" + txtmasach.Text + ".jpg";

            if (File.Exists(filePath))
            {
                using (FileStream f = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    picsach.Image = Image.FromStream(f);
                }
            }
            else
            {
                picsach.Image = new Bitmap(@"img_book\default.jpg");
            }

        }


        private void Cleartextbox()
        {
            txttensach.Clear();
            txtchude.Clear();
            txtgiatien.Clear();
            txtmasach.Clear();
            txtnamxuatban.Clear();
            txtnhaxuatban.Clear();
            txtsotrang.Clear();
            txttacgia.Clear();
            txttomtat.Clear();
            ckbduocmuon.Checked = false;
            ckbtinhtrang.Checked = false;
            picsach.Visible = false;
            radiobtnhuhong.Checked = false;
            radiobtnmat.Checked = false;
            radiobtnnguyenven.Checked = false;

        }

        private void cmbtinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cleartextbox();
            dgvsach.DataSource = null;
        }

        private void dgvsach_SelectionChanged(object sender, EventArgs e)
        {
            LoadBookImage();

        }

        private void btnmuon_Click(object sender, EventArgs e)
        {

            if (ckbtinhtrang.Checked == true)
            {
                MessageBox.Show("Tài liệu này đã được mượn. Hãy thêm vào hàng chờ", "Thông báo");
            }
            else
                if (ckbduocmuon.Checked == true)
                {
                    if (TAIKHOANBUS.Instance.Kiemtrasachtontaitrongphieumuon(flagMSSV, txtmasach.Text))
                    {
                        if (TAIKHOANBUS.Instance.Kiemtradieukienmuon_cho(flagMSSV))
                        {

                            if (PHIEUMUONBUS.Instance._Taophieumuon(flagMSSV) >= 0 && CHITIETPHIEUMUONBUS.Instance._Taoctphieumuon(Convert.ToInt32(txtmasach.Text), flagMSSV) > 0 && CUONSACHBUS.Instance._Updatetinhtrangsachmuon(Convert.ToInt32(txtmasach.Text)) > 0)
                            {

                                MessageBox.Show("Đăng ký mượn thành công", "Thông báo");
                                dgvsach.DataSource = CUONSACHBUS.Instance._Timkiemtheotensach(txtnhande.Text);
                                RemoveBindingTextbox();
                                BindingSachTextbox();
                            }
                            else
                                MessageBox.Show("Đăng ký mượn không thành công", "Thông báo");
                        }
                        else MessageBox.Show("Bạn không đủ điều kiện mượn sách", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không thể đăng kí 2 sách cùng loại!!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                else MessageBox.Show("Tài liệu này không được mượn", "Thông báo");
       }

        private void btnthemhangcho_Click(object sender, EventArgs e)
        {
            if (ckbduocmuon.Checked == false)
                MessageBox.Show("Tài liệu này không được mượn", "Thông báo");
            if (ckbtinhtrang.Checked == false)
                MessageBox.Show("Tài liệu này có sẵn. Hãy nhấn Mượn", "Thông báo");
            if (ckbduocmuon.Checked == true && ckbtinhtrang.Checked == true)
            {
                if (PHIEUMUONBUS.Instance._Kiemtraphieumuon_sach(flagMSSV, Convert.ToInt32(txtmasach.Text)))
                {

                    if (TAIKHOANBUS.Instance.Kiemtradieukienmuon_cho(flagMSSV))
                    {

                        if (DANHSACHHANGCHOBUS.Instance._Themsachvaohangcho(flagMSSV, Convert.ToInt32(txtmasach.Text)) > 0)
                        {
                            MessageBox.Show("Thêm vào hàng chờ thành công", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi !! Tài liệu này đã có trong hàng chờ của bạn", "Thông báo");
                        }

                    }

                    else MessageBox.Show("Bạn không thế đăng kí chờ.Hàng chờ và sách đang mượn đã đủ số lượng qui định!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                else MessageBox.Show("Bạn đã mượn tài liệu này. Không thể thêm vào hàng chờ", "Thông báo");
            }
        }

        private void txtnhande_TextChanged(object sender, EventArgs e)
        {
            picsach.Visible = false;
        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            Cleartextbox();
            DataTable dt = CUONSACHBUS.Instance._Timkiemtheotensach(txtnhande.Text);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy tài liệu nào!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvsach.DataSource = CUONSACHBUS.Instance._Getallsach();
                txtnhande.Clear();
            }
            else dgvsach.DataSource = dt;
            RemoveBindingTextbox();
            BindingSachTextbox();
            LoadBookImage();
        }

        private void SV_Tracuu_Sach_Ten_Load(object sender, EventArgs e)
        {
            Setupdatagridview();
            flagMSSV = frmManhinhchinhSinhVien.flagMSSV;
            RemoveBindingTextbox();
            dgvsach.DataSource = CUONSACHBUS.Instance._Getallsach();
            BindingSachTextbox();
            picsach.Hide();
        }






    }
}
