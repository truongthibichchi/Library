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
using Quanlythuvien.Utilities;
using System.IO;
namespace Quanlythuvien.Forms
{
    public partial class NV_DanhMucSinhVien : UserControl
    {
        public NV_DanhMucSinhVien()
        {
            InitializeComponent();
        }

        BindingSource SinhvienList = new BindingSource();
        private static NV_DanhMucSinhVien _instance;
        public static NV_DanhMucSinhVien Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NV_DanhMucSinhVien();
                return _instance;
            }
        }
        private string flag;
        private string temp;

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmthemsinhvien temp = new frmthemsinhvien();
            temp.ShowDialog();
        }

        private void UserControlNV_DanhMucSinhVien_Load(object sender, EventArgs e)
        {
            Loadcmbkhoa(cmb_khoa);
            Loadgioitinh();
            Setupdatagridview();
            dgvsinhvien.DataSource = SinhvienList;
            LoadSinhvienList();
            Bindingtextbox();
            pnKhoa.Visible = false;
            pnMSSV.Visible = false;
        }

        private void LoadSinhvienList()
        {
            SinhvienList.DataSource = SINHVIENBUS.Instance._Hienthitatcasinhvien();
        }


        private void LoadSinhVienListByKhoa(string khoa)
        {
            SinhvienList.DataSource = SINHVIENBUS.Instance._Laythongtinsinhvientheokhoa(khoa);
        }


        private void Loadcmbkhoa(ComboBox temp)
        {
            ComboBoxItem item1 = new ComboBoxItem("Khoa học và kỹ thuật thông tin", "Khoa học và kỹ thuật thông tin");
            ComboBoxItem item2 = new ComboBoxItem("Công nghệ phần mềm", "Công nghệ phần mềm");
            ComboBoxItem item3 = new ComboBoxItem("Hệ thống thông tin", "Hệ thống thông tin");
            ComboBoxItem item4 = new ComboBoxItem("Khoa học máy tính", "Khoa học máy tính");
            ComboBoxItem item5 = new ComboBoxItem("Kĩ thuật máy tính", "Kĩ thuật máy tính");
            ComboBoxItem item6 = new ComboBoxItem("Truyền thông và mạng máy tính", "Truyền thông và mạng máy tính");
            temp.Items.Add(item1);
            temp.Items.Add(item2);
            temp.Items.Add(item3);
            temp.Items.Add(item4);
            temp.Items.Add(item5);
            temp.Items.Add(item6);

            temp.DisplayMember = "Text";
            temp.ValueMember = "Value";
        }

        private void Loadgioitinh()
        {
            ComboBoxItem item1 = new ComboBoxItem("Nam", "Nam");
            ComboBoxItem item2 = new ComboBoxItem("Nữ", "Nữ");
            cmbgioitinh.Items.Add(item1);
            cmbgioitinh.Items.Add(item2);
            cmbgioitinh.DisplayMember = "Text";
            cmbgioitinh.ValueMember = "Value";
        }



        private void Bindingtextbox()
        {
            txthoten.DataBindings.Add(new Binding("Text", dgvsinhvien.DataSource, "HOTEN"));
            txtEmail.DataBindings.Add(new Binding("Text", dgvsinhvien.DataSource, "EMAIL"));
            txtlop.DataBindings.Add(new Binding("Text", dgvsinhvien.DataSource, "LOP"));
            txtMSSV.DataBindings.Add(new Binding("Text", dgvsinhvien.DataSource, "MASINHVIEN"));
            txtSoDienThoai.DataBindings.Add(new Binding("Text", dgvsinhvien.DataSource, "SDT"));
            cmb_khoa.DataBindings.Add(new Binding("Text", dgvsinhvien.DataSource, "KHOA"));
            dtngaysinh.DataBindings.Add(new Binding("Text", dgvsinhvien.DataSource, "NGAYSINH"));
            cmbgioitinh.DataBindings.Add(new Binding("Text", dgvsinhvien.DataSource, "GIOITINH"));
            txtdiachi.DataBindings.Add(new Binding("Text", dgvsinhvien.DataSource, "DIACHI"));
        }

        private void Removebindingtextbox()
        {
            txthoten.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtlop.DataBindings.Clear();
            txtMSSV.DataBindings.Clear();
            txtSoDienThoai.DataBindings.Clear();
            cmb_khoa.DataBindings.Clear();
            dtngaysinh.DataBindings.Clear();
            cmbgioitinh.DataBindings.Clear();
            txtdiachi.DataBindings.Clear();
        }

        private void Setupdatagridview()
        {
            dgvsinhvien.AutoGenerateColumns = false;
            if (dgvsinhvien.ColumnCount == 0)
            {
                dgvsinhvien.ColumnCount = 4;
                dgvsinhvien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                dgvsinhvien.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                dgvsinhvien.Columns[0].Name = "mssv";
                dgvsinhvien.Columns[0].HeaderText = "MÃ SỐ SINH VIÊN";
                dgvsinhvien.Columns[0].Width = 200;
                dgvsinhvien.Columns[0].DataPropertyName = "MASINHVIEN";

                dgvsinhvien.Columns[1].Name = "hoten";
                dgvsinhvien.Columns[1].HeaderText = "HỌ VÀ TÊN";
                dgvsinhvien.Columns[1].Width = 200;
                dgvsinhvien.Columns[1].DataPropertyName = "HOTEN";

                dgvsinhvien.Columns[2].Name = "lop";
                dgvsinhvien.Columns[2].HeaderText = "LỚP";
                dgvsinhvien.Columns[2].Width = 250;
                dgvsinhvien.Columns[2].DataPropertyName = "LOP";

                dgvsinhvien.Columns[3].Name = "khoa";
                dgvsinhvien.Columns[3].HeaderText = "KHOA";
                dgvsinhvien.Columns[3].Width = 300;
                dgvsinhvien.Columns[3].DataPropertyName = "KHOA";
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


        private void btnhienthitatca_Click(object sender, EventArgs e)
        {

            flag = "all";
            Removebindingtextbox();
            dgvsinhvien.DataSource = SINHVIENBUS.Instance._Hienthitatcasinhvien();
            Setupdatagridview();
            if (cmb_khoa.Items.Count == 0) Loadcmbkhoa(cmb_khoa);
            if (cmbgioitinh.Items.Count == 0) Loadgioitinh();
            Bindingtextbox();
            LoadSVImage();
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            bool flag = false;
            temp = txtMSSV.Text;
            if (!string.IsNullOrEmpty(txtMSSV.Text))
            {
                if (SINHVIENBUS.Instance._UpdatethongtinSV_NV(txthoten.Text, txtlop.Text, (cmbgioitinh.SelectedItem as ComboBoxItem).Value, DateTime.ParseExact(dtngaysinh.Text, "dd/MM/yyyy", null), (cmb_khoa.SelectedItem as ComboBoxItem).Value, txtEmail.Text, Convert.ToInt32(txtSoDienThoai.Text), Convert.ToInt32(txtMSSV.Text), txtdiachi.Text) > 0)
                {
                    if (picSV.Image != null)
                    {
                        string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\img_SV\";
                        if (Directory.Exists(appPath) == false)
                        {
                            Directory.CreateDirectory(appPath);
                        }

                        picSV.SizeMode = PictureBoxSizeMode.StretchImage;
                        ;
                        try
                        {
                            if (fileanh.FileName != "openFileDialog1")
                            {
                                string iName = txtMSSV.Text + ".jpg";
                                string filepath = fileanh.FileName;

                                File.Delete(appPath + iName);
                                File.Copy(filepath, appPath + iName);
                                picSV.Image = new Bitmap(fileanh.OpenFile());
                                MessageBox.Show("Cập nhật thành công", "Thông báo");
                                LoadSinhvienList();
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật thành công", "Thông báo");

                            }
                            flag = true;

                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("Unable to open file " + exp.Message);
                        }
                    }
                    else MessageBox.Show("Cập nhật thành công", "Thông báo");

                }
                else
                {
                    MessageBox.Show("Lỗi", "Thông báo");
                    flag = true;
                }
                    
            }
            if(flag)
            {
                LoadSinhvienList();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMSSV.Text))
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa chứ?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                if (SINHVIENBUS.Instance._DeleteSinhvien(txtMSSV.Text) > 0)
                {
                    try
                    {
                        string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\img_SV\";
                        string iName = txtMSSV.Text + ".jpg";
                        File.Delete(appPath + iName);
                        MessageBox.Show("Xóa thành công!!!");
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi");
                    }

                }
                else MessageBox.Show("Lỗi!!!");
            }
            else MessageBox.Show("Thông tin trống. Không thể xóa", "Thông báo");
            if (flag == "all")
            {
                dgvsinhvien.DataSource = SINHVIENBUS.Instance._Hienthitatcasinhvien();
            }
            else if (flag == "MSSV")
            {
                SinhvienList.DataSource = SINHVIENBUS.Instance._TimkiemsinhvienbyMSSV(txtnhapMSSV.Text);
            }
            else if (pnKhoa.Visible == true)
            {
                LoadSinhVienListByKhoa((cmbkhoa.SelectedItem as ComboBoxItem).Value);

            }
            else LoadSinhvienList();
            LoadSVImage();

        }

        private void Cleartextbox()
        {
            txthoten.Clear();
            txtEmail.Clear();
            txtlop.Clear();
            txtMSSV.Clear();
            txtSoDienThoai.Clear();
            cmb_khoa.Items.Clear();
            dtngaysinh.ResetText();
            cmbgioitinh.Items.Clear();
            txtdiachi.Clear();
            cmbkhoa.Items.Clear();
            Loadcmbkhoa(cmbkhoa);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            LoadSinhvienList();
        }

        private void dgvsinhvien_SelectionChanged_1(object sender, EventArgs e)
        {
            LoadSVImage();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            fileanh.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            fileanh.FilterIndex = 1;
            fileanh.RestoreDirectory = true;
            if (fileanh.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image imageSV = Image.FromFile(fileanh.FileName);
                picSV.Image = imageSV;
                picSV.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btntimMSSV_Click(object sender, EventArgs e)
        {
            Thaydoibutton();
            txtnhapMSSV.Clear();
            flag = "MSSV";
            pnKhoa.Visible = false;
            pnMSSV.Visible = true;
            pnMSSV.Location = new Point(465, 33);
        }

        private void btntimtheokhoa_Click(object sender, EventArgs e)
        {
            Thaydoibutton();
            flag = "Khoa";
            pnMSSV.Visible = false;
            pnKhoa.Visible = true;
            if (cmbkhoa.Items.Count == 0) Loadcmbkhoa(cmbkhoa);
            pnKhoa.Location = new Point(465, 33);
        }

        private void btnMSSV_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!string.IsNullOrEmpty(txtnhapMSSV.Text))
                {
                    dt = SINHVIENBUS.Instance._TimkiemsinhvienbyMSSV(txtnhapMSSV.Text);
                    dgvsinhvien.DataSource = dt;
                    Setupdatagridview();
                    if (cmb_khoa.Items.Count == 0) Loadcmbkhoa(cmb_khoa);
                    if (cmbgioitinh.Items.Count == 0) Loadgioitinh();
                    Removebindingtextbox();
                    Bindingtextbox();
                    LoadSVImage();
                }
                else MessageBox.Show("Hãy nhập Mã số sinh viên!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dt.Rows.Count == 0)
                {
                    Cleartextbox();
                    picSV.Image = null;
                    MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch { }
        }
        // Khi thay đổi giữa các button thì dữ liệu sẽ được reset
        private void Thaydoibutton()
        {
            Removebindingtextbox();
            Cleartextbox();
            dgvsinhvien.DataSource = null;
            picSV.Image = null;
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(cmbkhoa.Text))
            {
                dt = SINHVIENBUS.Instance._Laythongtinsinhvientheokhoa((cmbkhoa.SelectedItem as ComboBoxItem).Value);
                dgvsinhvien.DataSource = dt;

                Setupdatagridview();
                Removebindingtextbox();
                if (cmb_khoa.Items.Count == 0) Loadcmbkhoa(cmb_khoa);
                if (cmbgioitinh.Items.Count == 0) Loadgioitinh();
                Bindingtextbox();
                LoadSVImage();
            }
            else MessageBox.Show("Hãy chọn khoa cần tìm kiếm!!!");
            if (dt.Rows.Count == 0)
            {
                Cleartextbox();
                picSV.Image = null;
                MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}