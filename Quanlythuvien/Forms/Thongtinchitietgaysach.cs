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
    public partial class Thongtinchitietgaysach : Form
    {
        private string maGaySach;
        private DataTable dataTable;
        private Dictionary<string, List<int>> listQuery;
        DataTable dataTableToDisplay;        

        public Thongtinchitietgaysach(string name, string id)
        {
            InitializeComponent();
            this.maGaySach = id;
            this.Text = name;
            Setupdatagridview();
        }

        private void reloadFieldSearch()
        {
            switch (fieldSearch.SelectedIndex)
            {
                case 0:
                    dataTable = CUONSACHBUS.Instance._ArrayOfId(maGaySach);
                    fieldQuery.DataSource = dataTable.AsEnumerable().Select(r => r.Field<int>("MASACH").ToString()).ToList();
                    break;
                case 1:
                    listQuery = new Dictionary<string, List<int>>();
                    dataTable = CUONSACHBUS.Instance._ArrayOfStatus(maGaySach);
                    var result1 = dataTable.AsEnumerable().Select(r => r.Field<int>("TINHTRANG")).ToList();
                    for (int i = 0; i < result1.Count; i++)
                    {
                        string str = "";
                        switch (result1[i])
                        {
                            case 0:
                                str = "Có sẵn";
                                break;
                            case 1:
                                str = "Đang mượn";
                                break;
                            case 2:
                                str = "Bị hỏng";
                                break;
                            case 3:
                                str = "Đã mất";
                                break;
                            default:
                                break;
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
                    fieldQuery.DataSource = listQuery.Keys.ToList();
                    break;
                case 2:
                    listQuery = new Dictionary<string, List<int>>();
                    dataTable = CUONSACHBUS.Instance._ArrayOfArea(maGaySach);
                    var result2 = dataTable.AsEnumerable().Select(r => r.Field<int>("VITRI")).ToList();
                    for (int i = 0; i < result2.Count; i++)
                    {
                        string str = "";
                        switch (result2[i])
                        {
                            case 0:
                                str = "Kho mượn";
                                break;
                            case 1:
                                str = "Kho đọc";
                                break;
                            default:
                                break;
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
                    fieldQuery.DataSource = listQuery.Keys.ToList();
                    break;
                default:
                    break;
            }
        }
        private void fieldSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadFieldSearch();
        }

        private void RemoveText()
        {
            txtMaCuonSach.Text = "";
            cmbViTri.SelectedIndex = -1;
            cmbTinhTrang.SelectedIndex = -1;
        }

        private void Setupdatagridview()
        {
            dgvCuonSach.AutoGenerateColumns = false;
            if (dgvCuonSach.ColumnCount == 0)
            {
                dgvCuonSach.ColumnCount = 3;
                dgvCuonSach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                dgvCuonSach.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                dgvCuonSach.Columns[0].Name = "macuonsach";
                dgvCuonSach.Columns[0].HeaderText = "MÃ SÁCH";
                dgvCuonSach.Columns[0].Width = 207;
                dgvCuonSach.Columns[0].DataPropertyName = "MÃ SÁCH";

                dgvCuonSach.Columns[1].Name = "tinhtrang";
                dgvCuonSach.Columns[1].HeaderText = "TÌNH TRẠNG";
                dgvCuonSach.Columns[1].Width = 207;
                dgvCuonSach.Columns[1].DataPropertyName = "TÌNH TRẠNG";

                dgvCuonSach.Columns[2].Name = "vitri";
                dgvCuonSach.Columns[2].HeaderText = "VỊ TRÍ";
                dgvCuonSach.Columns[2].Width = 207;
                dgvCuonSach.Columns[2].DataPropertyName = "VỊ TRÍ";
            }
        }

        private void Thongtinchitietgaysach_Load(object sender, EventArgs e)
        {
            fieldSearch.SelectedIndex = 0;
        }

        private void reloadFieldQuery()
        {
            Setupdatagridview();
            if (fieldQuery.SelectedIndex == -1)
            {
                return;
            }
            var lst = new List<int>();
            dgvCuonSach.Rows.Clear();

            switch (fieldSearch.SelectedIndex)
            {
                case 0:
                    lst.Add(int.Parse(fieldQuery.SelectedValue.ToString()));
                    break;
                case 1:
                    foreach (int item in listQuery[fieldQuery.SelectedValue.ToString()])
                        lst.Add(dataTable.Rows[item].Field<int>("MASACH"));
                    break;
                case 2:
                    foreach (int item in listQuery[fieldQuery.SelectedValue.ToString()])
                        lst.Add(dataTable.Rows[item].Field<int>("MASACH"));
                    break;
                default:
                    break;
            }

            dataTableToDisplay = CUONSACHBUS.Instance._getInfoOfListId(lst);
            foreach (DataRow row in dataTableToDisplay.Rows)
            {
                string tinhtrang = "";
                switch (row.Field<int>("TINHTRANG"))
                {
                    case 0:
                        tinhtrang = "Có sẵn";
                        break;
                    case 1:
                        tinhtrang = "Đang mượn";
                        break;
                    case 2:
                        tinhtrang = "Bị hỏng";
                        break;
                    case 3:
                        tinhtrang = "Đã mất";
                        break;
                    default:
                        break;
                }

                string vitri = "";
                switch (row.Field<int>("VITRI"))
                {
                    case 0:
                        vitri = "Kho mượn";
                        break;
                    case 1:
                        vitri = "Kho đọc";
                        break;
                    default:
                        break;
                }
                this.dgvCuonSach.Rows.Add(row.Field<int>("MASACH"), tinhtrang, vitri);
            }
        }

        private void fieldQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadFieldQuery();
        }

        private void reDisplay()
        {
            if (dataTableToDisplay == null)
                return;
            if (dgvCuonSach.SelectedRows.Count == 0)
                return;
            int currentRow = dgvCuonSach.SelectedRows[0].Index;
            if (currentRow >= 0 && currentRow < dataTableToDisplay.Rows.Count)
            {
                DataRow r = dataTableToDisplay.Rows[currentRow];
                txtMaCuonSach.Text = r.Field<int>("MASACH").ToString();
                cmbTinhTrang.SelectedIndex = r.Field<int>("TINHTRANG");
                cmbViTri.SelectedIndex = r.Field<int>("VITRI");
            }
            else
            {
                RemoveText();
            }
        }

        private void dgvCuonSach_SelectionChanged(object sender, EventArgs e)
        {
            reDisplay();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form tmp = new Themcuonsach(maGaySach);
            tmp.ShowDialog();
        }

        private void cmbTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbViTri_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dataTableToDisplay == null)
                return;
            if (dgvCuonSach.SelectedRows.Count == 0)
                return;
            int currentRow = dgvCuonSach.SelectedRows[0].Index;
            if (currentRow >= 0 && currentRow < dataTableToDisplay.Rows.Count)
            {
                DataRow r = dataTableToDisplay.Rows[currentRow];
                if(r.Field<int>("TINHTRANG") == 1)
                {
                    MessageBox.Show("Sách đang hiện đang được mượn nên không thể cập nhật tình trạng.", "Thông báo");
                    int cur = dgvCuonSach.SelectedRows[0].Index;
                    reloadFieldQuery();
                    dgvCuonSach.CurrentCell = dgvCuonSach.Rows[cur].Cells[0];
                    return;
                }

                if(cmbTinhTrang.SelectedIndex == 1)
                {
                    MessageBox.Show("Không thể cập nhật, bởi vì sách có tình trạng là đang mượn khi và chỉ khi sinh viên đăng ký mượn sách.", "Thông báo");
                    return;
                }
                if (CUONSACHBUS.Instance._Updatesach(Convert.ToInt32(txtMaCuonSach.Text), Convert.ToInt32(cmbTinhTrang.SelectedIndex), Convert.ToInt32(cmbViTri.SelectedIndex)) > 0)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    int cur = dgvCuonSach.SelectedRows[0].Index;
                    reloadFieldQuery();
                    dgvCuonSach.CurrentCell = dgvCuonSach.Rows[cur].Cells[0];
                    return;
                }
                else MessageBox.Show("Lỗi");
            }

            
        }
    }
}
