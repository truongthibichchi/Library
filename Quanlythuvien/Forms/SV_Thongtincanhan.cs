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
    public partial class UserControlSV_Thongtincanhan : UserControl
    {
        private static string flagMSSV;
        public UserControlSV_Thongtincanhan()
        {
            InitializeComponent();
        }
        private static UserControlSV_Thongtincanhan _instance;
        public static UserControlSV_Thongtincanhan Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControlSV_Thongtincanhan();
                return _instance;
            }

        }

        private void UserControlSV_Thongtincanhan_Load(object sender, EventArgs e)
        {
            flagMSSV = frmManhinhchinhSinhVien.flagMSSV;
            pnSV_chinhsua.Visible = false;
            Diable_textbox();
            LoadthongtinSV_textbox(flagMSSV);
            LoadSVImage();
        }

        private void LoadthongtinSV_textbox(string mataikhoan)
        {

            DataTable dt = SINHVIENBUS.Instance._LaythongtinSVbymaTK(flagMSSV);
            txtMSSV.Text = Convert.ToString(dt.Rows[0][0]);
            txthoten.Text = (string)dt.Rows[0][1];
            txtdiachi.Text = (string)dt.Rows[0][2];
            dtmngaysinh.Value = Convert.ToDateTime(dt.Rows[0][3]);
            txtgioitinh.Text = (string)dt.Rows[0][4];
            txtkhoa.Text = (string)dt.Rows[0][5];
            txtlop.Text = (string)dt.Rows[0][6];
            txtSDT.Text = '0' + Convert.ToString(dt.Rows[0][7]);
            txtemail.Text = (string)dt.Rows[0][8];
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

        private void btndoimatkhau_Click(object sender, EventArgs e)
        {
            frmThaydoimatkhau frmmatkhau = new frmThaydoimatkhau();
            frmmatkhau.ShowDialog();
        }

        private void btnchinhsua_Click(object sender, EventArgs e)
        {
            pnSV_chinhsua.Visible = true;
            Enable_textbox();
        }

        private void Diable_textbox()
        {
            txtdiachi.Enabled = false;
            txtSDT.Enabled = false;
            txtemail.Enabled = false;
        }

        private void Enable_textbox()
        {
            txtdiachi.Enabled = true;
            txtSDT.Enabled = true;
            txtemail.Enabled = true;
        }
        private void btnhuybo_Click(object sender, EventArgs e)
        {
            pnSV_chinhsua.Visible = false;
            Diable_textbox();

        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            int sdt;
            if (string.IsNullOrEmpty(txtSDT.Text)) sdt = 0;
            else sdt = Convert.ToInt32(txtSDT.Text);
            if( SINHVIENBUS.Instance._UpdatethongtinSV(flagMSSV,txtdiachi.Text, txtemail.Text,sdt ) > 0 )
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }
            pnSV_chinhsua.Visible = false;
            Diable_textbox();
        }

       

    }
}
