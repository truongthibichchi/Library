using Quanlythuvien.BLL;
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
    public partial class Themcuonsach : Form
    {
        private string maGaySach = "";
        public Themcuonsach(string maGaySach)
        {
            InitializeComponent();
            this.Text = "Thêm bản sao";
            this.maGaySach = maGaySach;
            this.cmbViTri.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int soLuong = int.Parse(textBox1.Text);
                CUONSACHBUS.Instance._NhapCuonSach(maGaySach, soLuong, cmbViTri.SelectedIndex);
                this.Close();
                MessageBox.Show("Đã thêm sách thành công");
            }
            catch
            {
                MessageBox.Show("Thêm sách thất bại, vui lòng kiểm tra lại thuộc tính số lượng");
                return;
            }
        }
    }
}
