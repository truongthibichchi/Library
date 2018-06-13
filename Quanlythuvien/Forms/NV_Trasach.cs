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

namespace Quanlythuvien.Forms
{
    public partial class NV_Trasach : UserControl
    {
        public NV_Trasach()
        {
            InitializeComponent();

        }
        private static NV_Trasach _instance;
        public static NV_Trasach Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NV_Trasach();
                return _instance;
            }
        }

        public static string flagsinhvien;
        public double tienphatsach = QUYDINHBUS.Instance._Laytienphatsach();
        public double tienphatquahan = QUYDINHBUS.Instance._Laytienphatquahan();
        Double tienphat = 0;


        private void UC_NVDanhsachtrasach_Load(object sender, EventArgs e)
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
                dgv_giaosach.RowTemplate.Height = 30;

            }
        }

        private void Bindingtextbox()
        {
            txtMSSV.DataBindings.Add("Text", dgv_giaosach.DataSource, "MATAIKHOAN");
            txtHoVaTen.DataBindings.Add("Text", dgv_giaosach.DataSource, "HOTEN");
            txtmamuon.DataBindings.Add("Text", dgv_giaosach.DataSource, "MAMUON");
            txtMaSach.DataBindings.Add("Text", dgv_giaosach.DataSource, "MASACH");
            txtTenSach.DataBindings.Add("Text", dgv_giaosach.DataSource, "NHANDE");
            txtgiatien.DataBindings.Add("Text", dgv_giaosach.DataSource, "GIATIEN");
            dtmNgayMuon.DataBindings.Add("Text", dgv_giaosach.DataSource, "NGAYMUON");
            dtmHanTra.DataBindings.Add("Text", dgv_giaosach.DataSource, "HANTRA");
            chkDaGiaoSach.DataBindings.Add("Checked", dgv_giaosach.DataSource, "TINHTRANGGIAO");

        }

        private void Removebindingtextbox()
        {
            txtMSSV.DataBindings.Clear();
            txtHoVaTen.DataBindings.Clear();
            txtmamuon.DataBindings.Clear();
            txtMaSach.DataBindings.Clear();
            txtTenSach.DataBindings.Clear();
            txtgiatien.DataBindings.Clear();
            dtmNgayMuon.DataBindings.Clear();
            dtmHanTra.DataBindings.Clear();
            chkDaGiaoSach.DataBindings.Clear();
        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            Removebindingtextbox();

            if (txtMSSV.Text != "")
            {

                if (SINHVIENBUS.Instance._Kiemtramasosinhvien(txtMSSV.Text))
                {
                    DataTable dt = CUONSACHBUS.Instance._TimkiemsachSVdangmuon(txtMSSV.Text);
                    dgv_giaosach.DataSource = dt;
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu hiển thị!!!", "Thông báo");
                        return;
                    }
                    Bindingtextbox();
                    flagsinhvien = txtMSSV.Text;
                }
                else MessageBox.Show("Mã số sinh viên không đúng!!!", "Thông báo");
            }
            else MessageBox.Show("Hãy nhập mã số sinh viên", "Thông báo");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chkDaGiaoSach.Checked == false)
            {
                MessageBox.Show("Sách chưa giao, không thể xác nhận trả", "Thông báo");
                return;
            }
            else
            {
                int hientrang;
                int songayquahan;
                if (DateTime.Compare(dtmngaytra.Value, dtmHanTra.Value) < 0)// Nếu ngày trả trước hạn trả
                {
                    songayquahan = 0;
                }
                else songayquahan = (int)(dtmngaytra.Value - dtmHanTra.Value).TotalDays;

                if (radiobtnnguyenven.Checked)
                {
                    hientrang = 0;
                    tienphat = songayquahan * tienphatquahan;
                }
                else
                {
                    if (radiobtnhuhong.Checked)
                    {
                        hientrang = 2;
                        tienphat = Convert.ToDouble(txtgiatien.Text) * tienphatsach + songayquahan * tienphatquahan;
                    }
                    else
                    {
                        if (radiobtnmat.Checked)
                        {
                            hientrang = 3;
                            tienphat = Convert.ToDouble(txtgiatien.Text) * tienphatsach + songayquahan * tienphatquahan;
                        }
                        else
                        {
                            MessageBox.Show("Chưa đánh giá hiện trạng sách!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }


                if (ckbdatrasach.Checked == true)
                {
                    if (PHIEUTRABUS.Instance._Taophieutra(txtMSSV.Text, txtmamuon.Text, dtmngaytra.Value) >= 0 && CHITIETPHIEUTRABUS.Instance._Taoctphieutra(txtmamuon.Text, Convert.ToInt32(txtMaSach.Text), hientrang, tienphat) > 0)
                    {
                        if (tienphat != 0)
                        {
                            if (HOADONPHATBUS.Instance._Laphoadonphat(txtmamuon.Text, tienphat) == 0)
                            {
                                MessageBox.Show("Lỗi");
                                return;
                            }

                        }
                        var magaysach = CUONSACHBUS.Instance._Laymagaysachbangmasach(Convert.ToInt32(txtMaSach.Text));
                        DANHSACHHANGCHOBUS.Instance._Updatehangcho_trasach(Convert.ToInt32(txtMaSach.Text), magaysach);
                        MessageBox.Show("Trả sách thành công", "Thông báo");
                        dgv_giaosach.DataSource = CUONSACHBUS.Instance._TimkiemsachSVdangmuon(txtMSSV.Text);
                        Cleartextbox();
                        Removebindingtextbox();
                        Bindingtextbox();

                    }
                    else
                        MessageBox.Show("Lỗ!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else MessageBox.Show("Yêu cầu xác nhận việc trả sách!!!");
            }
        }


        private void btnlaphoadon_Click(object sender, EventArgs e)
        {
            frmHoadonphat hoadon = new frmHoadonphat();
            hoadon.ShowDialog();
        }

        private void Cleartextbox()
        {
            txtHoVaTen.Clear();
            txtmamuon.Clear();
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtgiatien.Clear();
            dtmNgayMuon.ResetText();
            dtmngaytra.ResetText();
            dtmHanTra.ResetText();
        }

    }

}
