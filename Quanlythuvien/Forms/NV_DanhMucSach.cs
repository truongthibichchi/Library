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
    public partial class NV_DanhMucSach : UserControl
    {
        private DataTable dataTable;
        private Dictionary<string, List<int>> listQuery;
        DataTable dataTableToDisplay;

        public NV_DanhMucSach()
        {
            InitializeComponent();
        }
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

        private void btnPhanPhoi_Click(object sender, EventArgs e)
        {
            if (txtNhanDe.Text == "")
            {
                MessageBox.Show("Vui lòng chọn gáy sách trước khi thực hiện thao tác", "Thông báo");
                return;
            }
            Form tmp = new Thongtinchitietgaysach(txtNhanDe.Text, txtMaGaySach.Text);
            tmp.ShowDialog();
            reloadFieldQuery();
            reDisplay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form tmp = new Themgaysach();
            tmp.ShowDialog();
            reloadFieldQuery();
            reDisplay();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaGaySach.Text == "")
            {
                MessageBox.Show("Vui lòng chọn gáy sách trước khi thực hiện thao tác", "Thông báo");
                return;
            }
                
            Form tmp = new Themcuonsach(txtMaGaySach.Text);
            tmp.ShowDialog();
            int currentRow = dgvsach.SelectedRows[0].Index;
            reloadFieldQuery();
            reDisplay();
            dgvsach.CurrentCell = dgvsach.Rows[currentRow].Cells[0] ;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaGaySach.Text == "")
            {
                MessageBox.Show("Vui lòng chọn gáy sách trước khi thực hiện thao tác", "Thông báo");
                return;
            }
            if (txtNhanDe.Text == "")
            {
                MessageBox.Show("Cập nhật thất bại, vui lòng điền đủ thông tin", "Thông báo");
                return;
            }

            string maGaySach = this.txtMaGaySach.Text;
            string nhanDe = this.txtNhanDe.Text;
            string tacGia = this.txtTacGia.Text;
            string chuDe = this.txtChuDe.Text;
            string tomTat = this.txtTomTat.Text;
            string nhaXuatBan = this.txtNhaXuatBan.Text;
            string soTrang = this.txtSoTrang.Text;
            string giaTien = this.txtGiaTien.Text;
            string namXuatBan = this.txtNamXuatBan.Text;

            if (GAYSACHBUS.Instance._Updatesach(maGaySach, nhanDe, tacGia, tomTat, chuDe, soTrang, giaTien, nhaXuatBan, namXuatBan) > 0)
            {
                if (picsach.Image != null)
                {
                    string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\img_book\";
                    if (Directory.Exists(appPath) == false)
                    {
                        Directory.CreateDirectory(appPath);
                    }

                    picsach.SizeMode = PictureBoxSizeMode.StretchImage;
                    try
                    {
                        if (fileanh.FileName != "openFileDialog1")
                        {
                            string iName = txtMaGaySach.Text + ".jpg";
                            string filepath = fileanh.FileName;

                            File.Delete(appPath + iName);
                            File.Copy(filepath, appPath + iName);
                            picsach.Image = new Bitmap(fileanh.OpenFile());
                            MessageBox.Show("Cập nhật thành công", "Thông báo");
                            reloadFieldQuery();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thành công", "Thông báo");
                            int cur = dgvsach.SelectedRows[0].Index;
                            reloadFieldQuery();
                            dgvsach.CurrentCell = dgvsach.Rows[cur].Cells[0];
                            return;
                        }

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Unable to open file " + exp.Message);
                    }
                }
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                reloadFieldQuery();
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            fileanh.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            fileanh.FilterIndex = 1;
            fileanh.RestoreDirectory = true;
            if (fileanh.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image hinhanhmoi = Image.FromFile(fileanh.FileName);
                picsach.Image = hinhanhmoi;
                picsach.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (dgvsach.SelectedRows.Count == 0)
                return;
            int currentRow = dgvsach.SelectedRows[0].Index;
            if (currentRow >= 0 && currentRow < dataTableToDisplay.Rows.Count)
            {
                reDisplay();
                return;
            }
            MessageBox.Show("Vui lòng chọn gáy sách trước khi thực hiện thao tác này.", "Thông báo");
        }
    }
}

