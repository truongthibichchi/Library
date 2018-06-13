using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanlythuvien.Utilities;
using Quanlythuvien.BLL;
using System.IO;
using Quanlythuvien.DAO;

namespace Quanlythuvien.Forms
{
    public partial class NV_DanhMucSachSinhVien : UserControl
    {
        private DataTable dataTable;
        private Dictionary<string, List<int>> listQuery;
        DataTable dataTableToDisplay;

        public NV_DanhMucSachSinhVien()
        {
            InitializeComponent();

        }
        public static string flagMSSV;
        private static NV_DanhMucSach _instance;
        public static NV_DanhMucSach Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NV_DanhMucSach();
                return _instance;
            }
        }

        private void NV_DanhMucSach_Load(object sender, EventArgs e)
        {
            fieldSearchComboBox2.SelectedIndex = 0;
            flagMSSV = frmManhinhchinhSinhVien.flagMSSV;
        }

        private void RemoveText()
        {
            txtMaGaySach.Text = "";
            txtNhanDe.Text = "";
            txtTacGia.Text = "";
            txtTomTat.Text = "";
            txtChuDe.Text = "";
            txtNhaXuatBan.Text = "";
            txtTongSo.Text = "";
            txtDangMuon.Text = "";
            txtCoSan.Text = "";
            txtCoSanDeMuon.Text = "";
            txtCoSanDeDoc.Text = "";
            txtDaMat.Text = "";
            txtBiHong.Text = "";
            txtNamXuatBan.Text = "";
            txtGiaTien.Text = "";
            txtNhaXuatBan.Text = "";
            txtSoTrang.Text = "";
        }

        private void Setupdatagridview()
        {
            dgvsach.AutoGenerateColumns = false;
            if (dgvsach.ColumnCount == 0)
            {
                dgvsach.ColumnCount = 4;
                dgvsach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                dgvsach.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                dgvsach.Columns[0].Name = "masach";
                dgvsach.Columns[0].HeaderText = "MÃ GÁY SÁCH";
                dgvsach.Columns[0].Width = 104;
                dgvsach.Columns[0].DataPropertyName = "MÃ GÁY SÁCH";

                dgvsach.Columns[1].Name = "nhande";
                dgvsach.Columns[1].HeaderText = "NHAN ĐỀ";
                dgvsach.Columns[1].Width = 404;
                dgvsach.Columns[1].DataPropertyName = "NHANDE";

                dgvsach.Columns[3].Name = "chude";
                dgvsach.Columns[3].HeaderText = "CHỦ ĐỀ";
                dgvsach.Columns[3].Width = 204;
                dgvsach.Columns[3].DataPropertyName = "CHUDE";

                dgvsach.Columns[2].Name = "tacgia";
                dgvsach.Columns[2].HeaderText = "TÁC GIẢ";
                dgvsach.Columns[2].Width = 204;
                dgvsach.Columns[2].DataPropertyName = "TACGIA";
            }
        }

        private void reloadFieldSearch()
        {
            switch (fieldSearchComboBox2.SelectedIndex)
            {
                case 0:
                    dataTable = GAYSACHBUS.Instance._ArrayOfId();
                    fieldQueryComboBox1.DataSource = dataTable.AsEnumerable().Select(r => r.Field<int>("MAGAYSACH").ToString()).ToList();
                    break;
                case 1:
                    dataTable = GAYSACHBUS.Instance._ArrayOfBookName();
                    fieldQueryComboBox1.DataSource = dataTable.AsEnumerable().Select(r => r.Field<string>("NHANDE")).ToList();
                    break;
                case 2:
                    listQuery = new Dictionary<string, List<int>>();
                    dataTable = GAYSACHBUS.Instance._ArrayOfAuthorName();
                    var resultOfQuery = dataTable.AsEnumerable().Select(r => r.Field<string>("TACGIA")).ToList();
                    for (int i = 0; i < resultOfQuery.Count; i++)
                    {
                        foreach (var author in resultOfQuery[i].Split(',').ToList<string>())
                        {
                            var str = author.Trim();
                            if (listQuery.ContainsKey(str))
                            {
                                listQuery[str].Add(i);
                            }
                            else
                            {
                                List<int> id = new List<int>();
                                id.Add(i);
                                listQuery.Add(str, id);
                            }
                        }
                    }
                    fieldQueryComboBox1.DataSource = listQuery.Keys.ToList();
                    break;
                case 3:
                    listQuery = new Dictionary<string, List<int>>();
                    dataTable = GAYSACHBUS.Instance._ArrayOfTopicName();
                    var result = dataTable.AsEnumerable().Select(r => r.Field<string>("CHUDE")).ToList();
                    for (int i = 0; i < result.Count; i++)
                    {
                        foreach (var topic in result[i].Split(',').ToList<string>())
                        {
                            var str = topic.Trim();
                            if (listQuery.ContainsKey(str))
                            {
                                listQuery[str].Add(i);
                            }
                            else
                            {
                                List<int> id = new List<int>();
                                id.Add(i);
                                listQuery.Add(str, id);
                            }
                        }
                    }
                    fieldQueryComboBox1.DataSource = listQuery.Keys.ToList();
                    break;
                case 4:
                    listQuery = new Dictionary<string, List<int>>();
                    dataTable = GAYSACHBUS.Instance._ArrayOfPublisher();
                    var result4 = dataTable.AsEnumerable().Select(r => r.Field<string>("NHAXUATBAN")).ToList();
                    for (int i = 0; i < result4.Count; i++)
                    {
                        var str = result4[i];
                        if (str == "")
                        {
                            str = "Chưa có thông tin nhà xuất bản";
                        }
                        if (listQuery.ContainsKey(str))
                        {
                            listQuery[str].Add(i);
                        }
                        else
                        {
                            List<int> id = new List<int>();
                            id.Add(i);
                            listQuery.Add(str, id);
                        }
                    }
                    fieldQueryComboBox1.DataSource = listQuery.Keys.ToList();
                    break;
                case 5:
                    listQuery = new Dictionary<string, List<int>>();
                    dataTable = GAYSACHBUS.Instance._ArrayOfSummary();
                    var result5 = dataTable.AsEnumerable().Select(r => r.Field<string>("TOMTAT")).ToList();
                    for (int i = 0; i < result5.Count; i++)
                    {
                        var str = result5[i];
                        if (str == "")
                        {
                            str = "Chưa có thông tin tóm tắt";
                        }
                        if (listQuery.ContainsKey(str))
                        {
                            listQuery[str].Add(i);
                        }
                        else
                        {
                            List<int> id = new List<int>();
                            id.Add(i);
                            listQuery.Add(str, id);
                        }
                    }
                    fieldQueryComboBox1.DataSource = listQuery.Keys.ToList();
                    break;
                case 6:
                    listQuery = new Dictionary<string, List<int>>();
                    dataTable = GAYSACHBUS.Instance._ArrayOfPublisherYear();
                    var result6 = dataTable.AsEnumerable().Select(r => r.Field<int>("NAMXUATBAN").ToString()).ToList();
                    for (int i = 0; i < result6.Count; i++)
                    {
                        var str = result6[i];
                        if (str == "")
                        {
                            str = "Chưa có thông tin năm xuất bản";
                        }
                        if (listQuery.ContainsKey(str))
                        {
                            listQuery[str].Add(i);
                        }
                        else
                        {
                            List<int> id = new List<int>();
                            id.Add(i);
                            listQuery.Add(str, id);
                        }
                    }
                    fieldQueryComboBox1.DataSource = listQuery.Keys.ToList();
                    break;
                default:
                    break;
            }
            fieldQueryComboBox1.SelectedIndex = 0;

        }

        private void fieldSearchComboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            reloadFieldSearch();
        }

        private void reDisplay()
        {
            if (dgvsach.SelectedRows.Count == 0)
                return;
            int currentRow = dgvsach.SelectedRows[0].Index;
            if (currentRow >= 0 && currentRow < dataTableToDisplay.Rows.Count)
            {
                DataRow r = dataTableToDisplay.Rows[currentRow];
                txtMaGaySach.Text = r.Field<int>("MAGAYSACH").ToString();
                txtNhanDe.Text = r.Field<string>("NHANDE");
                txtTacGia.Text = r.Field<string>("TACGIA");
                txtTomTat.Text = r.Field<string>("TOMTAT");
                txtChuDe.Text = r.Field<string>("CHUDE");
                txtNhaXuatBan.Text = r.Field<string>("NHAXUATBAN");
                txtTongSo.Text = r.Field<int>("TONGSO").ToString();
                txtDangMuon.Text = r.Field<int>("DANGMUON").ToString();
                txtCoSan.Text = r.Field<int>("COSAN").ToString();
                txtCoSanDeMuon.Text = r.Field<int>("COSANDEMUON").ToString();
                txtCoSanDeDoc.Text = r.Field<int>("COSANDEDOC").ToString();
                txtDaMat.Text = r.Field<int>("DAMAT").ToString();
                txtBiHong.Text = r.Field<int>("BIHONG").ToString();
                txtNamXuatBan.Text = r.Field<int>("NAMXUATBAN").ToString();
                txtGiaTien.Text = r.Field<decimal>("GIATIEN").ToString();
                txtNhaXuatBan.Text = r.Field<string>("NHAXUATBAN");
                txtSoTrang.Text = r.Field<int>("SOTRANG").ToString();
                LoadBookImage();
            }
            else
            {
                RemoveText();
            }
        }

        private void dgvsach_SelectionChanged(object sender, EventArgs e)
        {
            reDisplay();   
        }
        private void LoadBookImage()
        {
            picsach.Visible = true;
            picsach.SizeMode = PictureBoxSizeMode.StretchImage;

            if (string.IsNullOrEmpty(txtMaGaySach.Text)) return;

            var filePath = @"img_book\" + txtMaGaySach.Text + ".jpg";

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

        private void reloadFieldQuery()
        {
            Setupdatagridview();
            if (fieldQueryComboBox1.SelectedIndex == -1)
            {
                return;
            }
            var lst = new List<int>();
            dgvsach.Rows.Clear();
            switch (fieldSearchComboBox2.SelectedIndex)
            {
                case 0:
                    lst.Add(fieldQueryComboBox1.SelectedIndex + 1);
                    break;
                case 1:
                    lst.Add(dataTable.Rows[fieldQueryComboBox1.SelectedIndex].Field<int>("MAGAYSACH"));
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    foreach (int item in listQuery[fieldQueryComboBox1.SelectedValue.ToString()])
                        lst.Add(dataTable.Rows[item].Field<int>("MAGAYSACH"));
                    break;
                default:
                    break;
            }

            dataTableToDisplay = GAYSACHBUS.Instance._getInfoOfListId(lst);
            foreach (DataRow row in dataTableToDisplay.Rows)
                this.dgvsach.Rows.Add(row.Field<int>("MAGAYSACH"), row.Field<string>("NHANDE"), row.Field<string>("TACGIA"), row.Field<string>("CHUDE"));
        }

        private void fieldQueryComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadFieldQuery();
        }

        private void btnChonMuon_Click(object sender, EventArgs e)
        {
            
        }


        private void btnDangKyCho_Click(object sender, EventArgs e)
        {

            //Global.list_idle.Add(txtMaGaySach.Text);
            reloadFieldQuery();
            reDisplay();
        }

        private void btnmuon_Click(object sender, EventArgs e)
        {
            if (txtDangMuon.Text == "0" && txtCoSanDeDoc.Text == txtCoSan.Text)
            {
                MessageBox.Show("Tài liệu này không được mượn", "Thông báo");
                return;
            }
            if (txtDangMuon.Text != "0" && txtCoSanDeMuon.Text == "0")
            {
                MessageBox.Show("Tài liệu này đã hết số lượng tồn để mượn. Hãy thêm vào hàng chờ", "Thông báo");
                return;
            }
            if (TAIKHOANBUS.Instance.Kiemtrasachtontaitrongphieumuon(flagMSSV, txtMaGaySach.Text))
            {
                if (TAIKHOANBUS.Instance.Kiemtradieukienmuon_cho(flagMSSV))
                {
                    int var = CUONSACHBUS.Instance._LayMaSachCoTheMuon(txtMaGaySach.Text);
                    if (PHIEUMUONBUS.Instance._Taophieumuon(flagMSSV) >= 0 && CHITIETPHIEUMUONBUS.Instance._Taoctphieumuon(var, flagMSSV) > 0 && CUONSACHBUS.Instance._Updatetinhtrangsachmuon(var) > 0)
                    {
                        MessageBox.Show("Đăng ký mượn thành công", "Thông báo");
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
            reloadFieldQuery();
            reDisplay();
        }

        private void btnthemhangcho_Click(object sender, EventArgs e)
        {
            if (txtDangMuon.Text == "0" && txtCoSanDeMuon.Text == "0")
            {
                MessageBox.Show("Tài liệu này không được mượn", "Thông báo");
                return;
            }
            if (txtCoSanDeMuon.Text != "0")
            {
                MessageBox.Show("Tài liệu này có sẵn. Hãy nhấn Mượn", "Thông báo");
                return;
            }
            int var = CUONSACHBUS.Instance._LayMaSachNamTrongKhoMuon(txtMaGaySach.Text);
            if (TAIKHOANBUS.Instance.Kiemtrasachtontaitrongphieumuon(flagMSSV, txtMaGaySach.Text))
            {

                if (TAIKHOANBUS.Instance.Kiemtradieukienmuon_cho(flagMSSV))
                {

                    if (DANHSACHHANGCHOBUS.Instance._Themsachvaohangcho(flagMSSV, Convert.ToInt32(txtMaGaySach.Text)) > 0)
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
}