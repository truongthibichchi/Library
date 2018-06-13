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
    public partial class NV_DanhMucSachDangMuon : UserControl
    {
        private DataTable dataTable;
        private DataTable dataTableToDisplay;
        private Dictionary<string, List<int>> listQuery;

        public NV_DanhMucSachDangMuon()
        {
            InitializeComponent();
        }
        private static NV_DanhMucSachDangMuon _instance;
        public static NV_DanhMucSachDangMuon Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NV_DanhMucSachDangMuon();
                return _instance;
            }
        }

        private void NV_DanhMucSachDangMuon_Load(object sender, EventArgs e)
        {
            fieldSearchComboBox2.SelectedIndex = 0;
        }

        private void RemoveText()
        {
            txtMaSach.Text = "";
            txtMaGaySach.Text = "";
            txtNhanDe.Text = "";
            txtTacGia.Text = "";
            txtChuDe.Text = "";
            txtNhaXuatBan.Text = "";
            txtNamXuatBan.Text = "";
            txtGiaTien.Text = "";
            txtNhaXuatBan.Text = "";

            txtHoVaTen.Text = "";
            txtKhoa.Text = "";
            txtLop.Text = "";
            txtMaSoSinhVien.Text = "";
            txtMaPhieuMuon.Text = "";
            txtNgayMuon.Text = "";
            txtHanTra.Text = "";   
            txtTinhTrangGiao.Text = "";
            txtTinhTrangQuaHan.Text = "";
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
                dgvsach.Columns[0].HeaderText = "MÃ SÁCH";
                dgvsach.Columns[0].Width = 104;
                dgvsach.Columns[0].DataPropertyName = "MÃ SÁCH";

                dgvsach.Columns[1].Name = "nhande";
                dgvsach.Columns[1].HeaderText = "NHAN ĐỀ";
                dgvsach.Columns[1].Width = 404;
                dgvsach.Columns[1].DataPropertyName = "NHANDE";

                dgvsach.Columns[2].Name = "masv";
                dgvsach.Columns[2].HeaderText = "MÃ SỐ SINH VIÊN MƯỢN";
                dgvsach.Columns[2].Width = 204;
                dgvsach.Columns[2].DataPropertyName = "MASV";

                dgvsach.Columns[3].Name = "tensv";
                dgvsach.Columns[3].HeaderText = "HỌ VÀ TÊN SINH VIÊN MƯỢN";
                dgvsach.Columns[3].Width = 204;
                dgvsach.Columns[3].DataPropertyName = "TENSV";
            }
        }

        private void reloadFieldSearch()
        {
            switch (fieldSearchComboBox2.SelectedIndex)
            {
                case 0:
                    dataTable = GAYSACHBUS.Instance._ArrayMuonOfMaCuonSach();
                    fieldQueryComboBox1.DataSource = dataTable.AsEnumerable().Select(r => r.Field<int>("MASACH").ToString()).ToList();
                    break;
                case 1: 
                    listQuery = new Dictionary<string, List<int>>();
                    dataTable = GAYSACHBUS.Instance._ArrayMuonOfMaGaySach();
                    var resultOfQuery = dataTable.AsEnumerable().Select(r => r.Field<int>("MAGAYSACH").ToString()).ToList();
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
                case 2:
                    listQuery = new Dictionary<string, List<int>>();
                    dataTable = GAYSACHBUS.Instance._ArrayMuonOfMaSinhVien();
                    var resultOfQuery2 = dataTable.AsEnumerable().Select(r => r.Field<string>("MATAIKHOAN").ToString()).ToList();
                    for (int i = 0; i < resultOfQuery2.Count; i++)
                    {
                        foreach (var author in resultOfQuery2[i].Split(',').ToList<string>())
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
                    dataTable = GAYSACHBUS.Instance._ArrayMuonOfHanTra();
                    var resultOfQuery3 = dataTable.AsEnumerable().Select(r => r.Field<DateTime>("HANTRA")).ToList();
                    DateTime currentDateTime = DateTime.Now;
                    currentDateTime.ToString("MM/dd/yyyy HH:mm:ss");
                    for (int i = 0; i < resultOfQuery3.Count; i++)
                    {
                        var str = "";
                        if (resultOfQuery3[i].ToString("MM/dd/yyyy HH:mm:ss").CompareTo(currentDateTime.ToString("MM/dd/yyyy HH:mm:ss")) == 1)
                        {
                            str = "Còn hạn mượn";
                        }
                        else
                        {
                            str = "Quá hạn mượn";
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
            try
            {
                fieldQueryComboBox1.SelectedIndex = 0;
            }
            catch
            {
                return;
            }
        }

        private void reDisplay()
        {
            if (dgvsach.SelectedRows.Count == 0)
                return;
            int currentRow = dgvsach.SelectedRows[0].Index;

            if (currentRow >= 0 && currentRow < dataTableToDisplay.Rows.Count)
            {
                DataRow r = dataTableToDisplay.Rows[currentRow];
                txtMaSach.Text = r.Field<int>("MASACH").ToString();
                txtMaGaySach.Text = r.Field<int>("MAGAYSACH").ToString();
                txtNhanDe.Text = r.Field<string>("NHANDE");
                txtTacGia.Text = r.Field<string>("TACGIA");
                txtChuDe.Text = r.Field<string>("CHUDE");
                txtNhaXuatBan.Text = r.Field<string>("NHAXUATBAN");
                txtNamXuatBan.Text = r.Field<int>("NAMXUATBAN").ToString();
                txtGiaTien.Text = r.Field<decimal>("GIATIEN").ToString();
                txtNhaXuatBan.Text = r.Field<string>("NHAXUATBAN");

                txtHoVaTen.Text = r.Field<string>("HOTEN");
                txtKhoa.Text = r.Field<string>("KHOA");
                txtLop.Text = r.Field<string>("LOP");
                txtMaSoSinhVien.Text = r.Field<string>("MATAIKHOAN");
                txtMaPhieuMuon.Text = r.Field<string>("MAMUON");
                txtNgayMuon.Text = r.Field<DateTime>("NGAYMUON").ToString();
                txtHanTra.Text = r.Field<DateTime>("HANTRA").ToString();
                if (r.Field<bool>("TINHTRANGGIAO"))
                {
                    txtTinhTrangGiao.Text = "Đã giao";
                }
                else
                {
                    txtTinhTrangGiao.Text = "Chưa giao";
                }

                DateTime currentDateTime = DateTime.Now;
                currentDateTime.ToString("MM/dd/yyyy HH:mm:ss");
                if (r.Field<DateTime>("HANTRA").ToString("MM/dd/yyyy HH:mm:ss").CompareTo(currentDateTime.ToString("MM/dd/yyyy HH:mm:ss")) == 1)
                {
                    txtTinhTrangQuaHan.Text = "Còn hạn mượn";
                }
                else
                {
                    txtTinhTrangQuaHan.Text = "Quá hạn mượn";
                }
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

        private void reloadFieldQuery()
        {
            dataTableToDisplay = dataTable.Clone();
            dataTableToDisplay.Rows.Clear();
            Setupdatagridview();
            if (fieldQueryComboBox1.SelectedIndex == -1)
            {
                return;
            }
            dgvsach.Rows.Clear();
            switch (fieldSearchComboBox2.SelectedIndex)
            {
                case 0:
                    //lst.Add(fieldQueryComboBox1.SelectedIndex + 1);
                    var row = dataTable.Rows[fieldQueryComboBox1.SelectedIndex + 1];
                    this.dgvsach.Rows.Add(row.Field<int>("MASACH"), row.Field<string>("NHANDE"), row.Field<string>("MATAIKHOAN"), row.Field<string>("HOTEN"));
                    dataTableToDisplay.ImportRow(dataTable.Rows[fieldQueryComboBox1.SelectedIndex]);
                    break;
                case 1:
                case 2:
                case 3:
                    foreach (int item in listQuery[fieldQueryComboBox1.SelectedValue.ToString()])
                    {
                        var row1 = dataTable.Rows[item];
                        bool flag = false;
                        foreach (DataRow r in this.dataTableToDisplay.Rows)
                        {
                            if (row1.Field<int>("MASACH") == r.Field<int>("MASACH"))
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            continue;
                        }
                        this.dgvsach.Rows.Add(row1.Field<int>("MASACH"), row1.Field<string>("NHANDE"), row1.Field<string>("MATAIKHOAN"), row1.Field<string>("HOTEN"));
                        dataTableToDisplay.ImportRow(dataTable.Rows[item]);
                    }
                    break;
                default:
                    break;
            }
            reDisplay();
        }

        private void fieldQueryComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadFieldQuery();
        }

        private void NV_DanhMucSachDangMuon_Load_1(object sender, EventArgs e)
        {
            fieldSearchComboBox2.SelectedIndex = 0;
        }

        private void fieldSearchComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadFieldSearch();
        }

        private void fieldQueryComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            reloadFieldQuery();
        }

        private void dgvsach_SelectionChanged_1(object sender, EventArgs e)
        {
            reDisplay();  
        }
    }
}

