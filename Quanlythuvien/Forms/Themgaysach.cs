using Quanlythuvien.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlythuvien.Forms
{
    public partial class Themgaysach : Form
    {
        private int idNew;

        //-------------Suggest fill------------
        private DataTable dataTableTacGia;
        private Dictionary<string, List<int>> listQueryTacGia;

        private DataTable dataTableChuDe;
        private Dictionary<string, List<int>> listQueryChuDe;

        private DataTable dataTableNhaXB;
        private Dictionary<string, List<int>> listQueryNhaXB;

        private DataTable dataTableTomTat;
        private Dictionary<string, List<int>> listQueryTomTat;

        private DataTable dataTableNamXB;
        private Dictionary<string, List<int>> listQueryNamXB;



        //-------------Suggest fill------------
        public Themgaysach()
        {
            InitializeComponent();
            this.Text = "Thêm gáy sách";
            idNew = GAYSACHBUS.Instance._Taogaysach();
            this.txtMaGaySach.Text = idNew.ToString();
        }

        private void clearText()
        {
            txtSoTrang.Text = "";
            txtNhanDe.Text = "";
            txtTacGia.Text = "";
            txtTomTat.Text = "";
            txtChuDe.Text = "";
            txtNhaXuatBan.Text = "";
            txtNamXuatBan.Text = "";
            txtGiaTien.Text = "";
            txtNhaXuatBan.Text = "";
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            fileanh.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            fileanh.FilterIndex = 1;
            fileanh.RestoreDirectory = true;
            if (fileanh.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image picsachmoi = Image.FromFile(fileanh.FileName);
                picsach.Image = picsachmoi;
                picsach.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if(txtNhanDe.Text == "")
            {
                MessageBox.Show("Nhan đề vui lòng không được để trống", "Thông báo");
                return;
            }
            try
            {
                string maGaySach = this.txtMaGaySach.Text;
                string nhanDe = this.txtNhanDe.Text;
                string tacGia = this.txtTacGia.Text;
                string chuDe = this.txtChuDe.Text;
                string tomTat = this.txtTomTat.Text;
                string nhaXuatBan = this.txtNhaXuatBan.Text;
                string soTrang = this.txtSoTrang.Text;
                string giaTien = this.txtGiaTien.Text;
                string namXuatBan = this.txtNamXuatBan.Text;

                if (GAYSACHBUS.Instance._Insertsach(maGaySach, nhanDe, tacGia, tomTat, chuDe, soTrang, giaTien, nhaXuatBan, namXuatBan) > 0)
                {
                    
                    //Lưu ảnh 
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
                            string iName = txtMaGaySach.Text + ".jpg";
                            string filepath = fileanh.FileName;

                            File.Copy(filepath, appPath + iName);
                            picsach.Image = new Bitmap(fileanh.OpenFile());
                            MessageBox.Show("Thêm thành công", "Thông báo");
                            clearText();
                            idNew = GAYSACHBUS.Instance._Taogaysach();
                            this.txtMaGaySach.Text = idNew.ToString();
                            picsach.Image = null;
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("Unable to open file " + exp.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        clearText();
                        idNew = GAYSACHBUS.Instance._Taogaysach();
                        this.txtMaGaySach.Text = idNew.ToString();

                    }
                }
            }
            catch
            {
                MessageBox.Show("Nhập thiếu thông tin sách!!!", "Thông báo");
            }
        }

        private void reloadFieldSearch()
        {
            listQueryTacGia = new Dictionary<string, List<int>>();
            dataTableTacGia = GAYSACHBUS.Instance._ArrayOfAuthorName();
            var resultOfQuery = dataTableTacGia.AsEnumerable().Select(r => r.Field<string>("TACGIA")).ToList();
            for (int i = 0; i < resultOfQuery.Count; i++)
            {
                foreach (var author in resultOfQuery[i].Split(',').ToList<string>())
                {
                    var str = author.Trim();
                    if (listQueryTacGia.ContainsKey(str))
                    {
                        listQueryTacGia[str].Add(i);
                    }
                    else
                    {
                        List<int> id = new List<int>();
                        id.Add(i);
                        listQueryTacGia.Add(str, id);
                    }
                }
            }
            fieldTacGia.DataSource = listQueryTacGia.Keys.ToList();


 
            listQueryChuDe = new Dictionary<string, List<int>>();
            dataTableChuDe = GAYSACHBUS.Instance._ArrayOfTopicName();
            var result = dataTableChuDe.AsEnumerable().Select(r => r.Field<string>("CHUDE")).ToList();
            for (int i = 0; i < result.Count; i++)
            {
                foreach (var topic in result[i].Split(',').ToList<string>())
                {
                    var str = topic.Trim();
                    if (listQueryChuDe.ContainsKey(str))
                    {
                        listQueryChuDe[str].Add(i);
                    }
                    else
                    {
                        List<int> id = new List<int>();
                        id.Add(i);
                        listQueryChuDe.Add(str, id);
                    }
                }
            }
            fieldChuDe.DataSource = listQueryChuDe.Keys.ToList();


            listQueryNhaXB = new Dictionary<string, List<int>>();
            dataTableNhaXB = GAYSACHBUS.Instance._ArrayOfPublisher();
            var result4 = dataTableNhaXB.AsEnumerable().Select(r => r.Field<string>("NHAXUATBAN")).ToList();
            for (int i = 0; i < result4.Count; i++)
            {
                var str = result4[i];
                if (str == "")
                {
                    continue;
                }
                if (listQueryNhaXB.ContainsKey(str))
                {
                    listQueryNhaXB[str].Add(i);
                }
                else
                {
                    List<int> id = new List<int>();
                    id.Add(i);
                    listQueryNhaXB.Add(str, id);
                }
            }
            fieldNhaXuatBan.DataSource = listQueryNhaXB.Keys.ToList();


            listQueryTomTat = new Dictionary<string, List<int>>();
            dataTableTomTat = GAYSACHBUS.Instance._ArrayOfSummary();
            var result5 = dataTableTomTat.AsEnumerable().Select(r => r.Field<string>("TOMTAT")).ToList();
            for (int i = 0; i < result5.Count; i++)
            {
                var str = result5[i];
                if (str == "")
                {
                    str = "Chưa có thông tin tóm tắt";
                }
                if (listQueryTomTat.ContainsKey(str))
                {
                    listQueryTomTat[str].Add(i);
                }
                else
                {
                    List<int> id = new List<int>();
                    id.Add(i);
                    listQueryTomTat.Add(str, id);
                }
            }
            fieldTomTat.DataSource = listQueryTomTat.Keys.ToList();


            listQueryNamXB = new Dictionary<string, List<int>>();
            dataTableNamXB = GAYSACHBUS.Instance._ArrayOfPublisherYear();
            var result6 = dataTableNamXB.AsEnumerable().Select(r => r.Field<int>("NAMXUATBAN").ToString()).ToList();
            for (int i = 0; i < result6.Count; i++)
            {
                var str = result6[i];
                if (str == "")
                {
                    continue;
                }
                if (listQueryNamXB.ContainsKey(str))
                {
                    listQueryNamXB[str].Add(i);
                }
                else
                {
                    List<int> id = new List<int>();
                    id.Add(i);
                    listQueryNamXB.Add(str, id);
                }
            }
            fieldNamXuatBan.DataSource = listQueryNamXB.Keys.ToList();
        }

        private void Themgaysach_Load(object sender, EventArgs e)
        {
            reloadFieldSearch();
            clearText();
        }

        private void fieldTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtTacGia.Text == "")
            {
                this.txtTacGia.Text += fieldTacGia.SelectedValue;
                return;
            }
            this.txtTacGia.Text += ", " + fieldTacGia.SelectedValue;
        }

        private void fieldChuDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtChuDe.Text == "")
            {
                this.txtChuDe.Text += fieldChuDe.SelectedValue;
                return;
            }
            this.txtChuDe.Text += ", " + fieldChuDe.SelectedValue;
        }

        private void fieldNhaXuatBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtNhaXuatBan.Text = "";
            this.txtNhaXuatBan.Text += fieldNhaXuatBan.SelectedValue;
        }

        private void fieldNamXuatBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtNamXuatBan.Text = "";
            this.txtNamXuatBan.Text += fieldNamXuatBan.SelectedValue;
        }

        private void fieldTomTat_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fieldTomTat.Text = "";
            this.txtTomTat.Text += fieldTomTat.SelectedValue;
        }
    }
}
