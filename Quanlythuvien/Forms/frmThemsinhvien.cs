using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanlythuvien.Utilities;
using Quanlythuvien.BLL;
using System.IO;

namespace Quanlythuvien.Forms
{
    public partial class frmthemsinhvien : Form
    {
        public frmthemsinhvien()
        {
            InitializeComponent();
        }

        private void frmThemsinhvien_Load(object sender, EventArgs e)
        {
            Loadcmbkhoa();
            Loadgioitinh();

        }
        private void Loadcmbkhoa()
        {
            ComboBoxItem item1 = new ComboBoxItem("Khoa học và kỹ thuật thông tin", "Khoa học và kỹ thuật thông tin");
            ComboBoxItem item2 = new ComboBoxItem("Công nghệ phần mềm", "Công nghệ phần mềm");
            ComboBoxItem item3 = new ComboBoxItem("Hệ thống thông tin", "Hệ thống thông tin");
            ComboBoxItem item4 = new ComboBoxItem("Khoa học máy tính", "Khoa học máy tính");
            ComboBoxItem item5 = new ComboBoxItem("Khoa học và kĩ thuật thông tin", "Khoa học và kĩ thuật thông tin");
            ComboBoxItem item6 = new ComboBoxItem("Kĩ thuật máy tính", "Kĩ thuật máy tính");
            ComboBoxItem item7 = new ComboBoxItem("Truyền thông và mạng máy tính", "Truyền thông và mạng máy tính");
            cmbkhoa.Items.Add(item1);
            cmbkhoa.Items.Add(item2);
            cmbkhoa.Items.Add(item3);
            cmbkhoa.Items.Add(item4);
            cmbkhoa.Items.Add(item5);
            cmbkhoa.Items.Add(item6);
            cmbkhoa.Items.Add(item7);
            cmbkhoa.DisplayMember = "Text";
            cmbkhoa.ValueMember = "Value";
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

        
        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                var mssv = txtmssv.Text;
                var ten = txthoten.Text;
                var lop = txtlop.Text;
                string khoa;
                if (!string.IsNullOrEmpty(cmbkhoa.Text))
                {
                    khoa = (cmbkhoa.SelectedItem as ComboBoxItem).Value;
                }
                else
                    khoa = "";
                string gioitinh;
                if(!string.IsNullOrEmpty(cmbgioitinh.Text))
                {
                    gioitinh = (cmbgioitinh.SelectedItem as ComboBoxItem).Value;
                }
                else 
                     gioitinh = "";
                var ngaysinh = Convert.ToDateTime(dtpngaysinh.Value);
                var email = txtEmail.Text;
                int sdt;
                if (string.IsNullOrEmpty(txtsdt.Text)) sdt = 0;
                else sdt = Convert.ToInt32(txtsdt.Text);
                var diachi = txtdiachi.Text;

                if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(lop) || string.IsNullOrEmpty(khoa) || string.IsNullOrEmpty(gioitinh))
                {

                    lblthongbao.Text = "Các mục * không được bỏ trống";
                    Cleartextbox();
                    Loadcmbkhoa();
                    Loadgioitinh();
                    return;
                }

                if (SINHVIENBUS.Instance._Addsinhvien(mssv, ten, lop, khoa, gioitinh, ngaysinh, email,sdt, diachi) > 0)
                {
                    if(picAnhThe.Image != null)
                    {
                        string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\img_SV\";
                            if (Directory.Exists(appPath) == false)
                            {
                                Directory.CreateDirectory(appPath);
                            }
                            try
                            {
                                string iName = txtmssv.Text + ".jpg"; 
                                string filepath = fileanh.FileName;   

                                File.Copy(filepath, appPath + iName); 
                                picAnhThe.Image = new Bitmap(fileanh.OpenFile());
                                MessageBox.Show("Thêm thành công", "Thông báo");
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show("Unable to open file " + exp.Message);
                            }
                    }
                    else MessageBox.Show("Thêm thành công", "Thông báo");
                    
                }
                else
                    MessageBox.Show("Lỗi");
            }
            catch
            {
                MessageBox.Show("Lỗi !!!");
            }
            Cleartextbox();
            picAnhThe.Image = null;
            

        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            Cleartextbox();
            picAnhThe.Image = null;
        }

        private void Cleartextbox()
        {
            txtdiachi.Clear();
            txtEmail.Clear();
            txthoten.Clear();
            txtlop.Clear();
            txtmssv.Clear();
            txtsdt.Clear();
            cmbgioitinh.Items.Clear();
            cmbkhoa.Items.Clear();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            fileanh.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            fileanh.FilterIndex = 1;
            fileanh.RestoreDirectory = true;
            if (fileanh.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image picsachmoi = Image.FromFile(fileanh.FileName);
                picAnhThe.Image = picsachmoi;
                picAnhThe.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        
    }
}
