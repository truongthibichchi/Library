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

namespace Quanlythuvien.Forms
{
    public partial class frmHoadonphat : Form
    {
        public frmHoadonphat()
        {
            InitializeComponent();
        }

        private void frmHoadonphat_Load(object sender, EventArgs e)
        {
            pntinhtrang.Visible = false;
            Setupdatagridview();
           
        }

        private int flag, temp;
        private void Loadcomboboxtinhtrang()
        {
            ComboBoxItem item1 = new ComboBoxItem("1", "Đã nộp");
            ComboBoxItem item2 = new ComboBoxItem("0", "Chưa nộp");
            cmbtinhtrang.Items.Add(item1);
            cmbtinhtrang.Items.Add(item2);
            cmbtinhtrang.DisplayMember = "Text";
            cmbtinhtrang.ValueMember = "Value";
        }

        private void Setupdatagridview()
        {
            dgv_hoadon.AutoGenerateColumns = false;
            if (dgv_hoadon.ColumnCount == 0)
            {
                dgv_hoadon.ColumnCount = 3;
                dgv_hoadon.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                dgv_hoadon.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                dgv_hoadon.Columns[0].Name = "masosinhvien";
                dgv_hoadon.Columns[0].HeaderText = "MSSV";
                dgv_hoadon.Columns[0].Width = 100;
                dgv_hoadon.Columns[0].DataPropertyName = "MATAIKHOAN";

                dgv_hoadon.Columns[1].Name = "mamuon";
                dgv_hoadon.Columns[1].HeaderText = "MÃ MƯỢN";
                dgv_hoadon.Columns[1].Width = 150;
                dgv_hoadon.Columns[1].DataPropertyName = "MAMUON";

                dgv_hoadon.Columns[2].Name = "tienphat";
                dgv_hoadon.Columns[2].HeaderText = "TIỀN PHẠT";
                dgv_hoadon.Columns[2].Width = 150;
                dgv_hoadon.Columns[2].DataPropertyName = "TONGTIENPHAT";

            }
        }

        private void Bindingtextbox()
        {
            Removebindingtextbox();
            txtmahoadon.DataBindings.Add("Text", dgv_hoadon.DataSource, "MAHOADON");
            txtMSSV.DataBindings.Add("Text", dgv_hoadon.DataSource, "MASINHVIEN");
            txthoten.DataBindings.Add("Text", dgv_hoadon.DataSource, "HOTEN");
            txtmamuon.DataBindings.Add("Text", dgv_hoadon.DataSource, "MAMUON");
            txttienphat.DataBindings.Add("Text", dgv_hoadon.DataSource, "TONGTIENPHAT");
            radiobtndanop.DataBindings.Add("Checked", dgv_hoadon.DataSource, "TINHTRANGNOP");

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (SINHVIENBUS.Instance._Kiemtramasosinhvien(txtnhapmssv.Text))
            {
                dgv_hoadon.DataSource = HOADONPHATBUS.Instance._GetthongtinhoadonphatbyMSSV(txtnhapmssv.Text);
                pntinhtrang.Visible = true;
                if(cmbtinhtrang.Items.Count==0)
                    Loadcomboboxtinhtrang();
                Bindingtextbox();
                
            }
            
        }

        private void Removebindingtextbox()
        {
            txtmahoadon.DataBindings.Clear();
            txtMSSV.DataBindings.Clear();
            txthoten.DataBindings.Clear();
            txtmamuon.DataBindings.Clear();
            txttienphat.DataBindings.Clear();
            radiobtndanop.DataBindings.Clear();
            
        }

        private void cmbtinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cleartextbox();
            dgv_hoadon.DataSource = HOADONPHATBUS.Instance._GetthongtinhoadonphatbyMSSV_tinhtrang(txtnhapmssv.Text, Convert.ToInt32((cmbtinhtrang.SelectedItem as ComboBoxItem).Value));
            Removebindingtextbox();
            Bindingtextbox();
        }
     
        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            if (radiobtnchuanop.Checked) temp = 0;
            if (radiobtndanop.Checked) temp = 1;
            if((flag == 1) && (temp == 0))
            {
                MessageBox.Show("Hóa đơn này đã nộp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (HOADONPHATBUS.Instance._Updatetinhtrangnophoadon(temp, txtmahoadon.Text) > 0)
            {
                MessageBox.Show("Lưu thành công", "Thông báo");
                Removebindingtextbox();
                dgv_hoadon.DataSource = HOADONPHATBUS.Instance._GetthongtinhoadonphatbyMSSV(txtMSSV.Text);
                Bindingtextbox();

            }
            else MessageBox.Show("Lỗi","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void Cleartextbox()
        {
            txtMSSV.Clear();
            txthoten.Clear();
            txtmahoadon.Clear();
            txtmamuon.Clear();
            txttienphat.Clear();
            radiobtnchuanop.Checked = false;
            radiobtndanop.Checked = false;

        }

        private void dgv_hoadon_SelectionChanged(object sender, EventArgs e)
        {
            if (radiobtndanop.Checked == true)
            {
                radiobtnchuanop.Checked = false;
                flag = 1;
            }
            if (radiobtndanop.Checked == false)
            {
                radiobtnchuanop.Checked = true;
                flag = 0;
            }

        }
      
    
    }
}
