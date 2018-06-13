namespace Quanlythuvien.Forms
{
    partial class Thongtinchitietgaysach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Thongtinchitietgaysach));
            this.fileanh = new System.Windows.Forms.OpenFileDialog();
            this.btnThem = new System.Windows.Forms.Button();
            this.fieldQuery = new Quanlythuvien.Forms.SuggestComboBox();
            this.labelFieldSearch = new System.Windows.Forms.Label();
            this.lbltimkiem = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvCuonSach = new System.Windows.Forms.DataGridView();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.lblDanhMucSach = new System.Windows.Forms.Label();
            this.txtMaCuonSach = new System.Windows.Forms.TextBox();
            this.labelMaCuonSach = new System.Windows.Forms.Label();
            this.txtflag_hientrang = new System.Windows.Forms.TextBox();
            this.labelTinhTrang = new System.Windows.Forms.Label();
            this.labelViTri = new System.Windows.Forms.Label();
            this.cmbTinhTrang = new System.Windows.Forms.ComboBox();
            this.cmbViTri = new System.Windows.Forms.ComboBox();
            this.fieldSearch = new Quanlythuvien.Forms.SuggestComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuonSach)).BeginInit();
            this.SuspendLayout();
            // 
            // fileanh
            // 
            this.fileanh.FileName = "openFileDialog1";
            this.fileanh.RestoreDirectory = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(176, 145);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(121, 32);
            this.btnThem.TabIndex = 177;
            this.btnThem.Text = "Thêm bản sao";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // fieldQuery
            // 
            this.fieldQuery.FilterRule = null;
            this.fieldQuery.FormattingEnabled = true;
            this.fieldQuery.Location = new System.Drawing.Point(371, 27);
            this.fieldQuery.Name = "fieldQuery";
            this.fieldQuery.PropertySelector = null;
            this.fieldQuery.Size = new System.Drawing.Size(111, 21);
            this.fieldQuery.SuggestBoxHeight = 96;
            this.fieldQuery.SuggestListOrderRule = null;
            this.fieldQuery.TabIndex = 175;
            this.fieldQuery.SelectedIndexChanged += new System.EventHandler(this.fieldQuery_SelectedIndexChanged);
            // 
            // labelFieldSearch
            // 
            this.labelFieldSearch.AutoSize = true;
            this.labelFieldSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelFieldSearch.Location = new System.Drawing.Point(143, 30);
            this.labelFieldSearch.Name = "labelFieldSearch";
            this.labelFieldSearch.Size = new System.Drawing.Size(95, 13);
            this.labelFieldSearch.TabIndex = 159;
            this.labelFieldSearch.Text = "Trường tìm kiếm:";
            // 
            // lbltimkiem
            // 
            this.lbltimkiem.AutoSize = true;
            this.lbltimkiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltimkiem.Location = new System.Drawing.Point(426, 55);
            this.lbltimkiem.Name = "lbltimkiem";
            this.lbltimkiem.Size = new System.Drawing.Size(0, 15);
            this.lbltimkiem.TabIndex = 152;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(-18, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 14);
            this.panel1.TabIndex = 155;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(252, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 21);
            this.label5.TabIndex = 154;
            this.label5.Text = "THÔNG TIN CHI TIẾT";
            // 
            // dgvCuonSach
            // 
            this.dgvCuonSach.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCuonSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuonSach.Location = new System.Drawing.Point(1, 194);
            this.dgvCuonSach.Name = "dgvCuonSach";
            this.dgvCuonSach.ReadOnly = true;
            this.dgvCuonSach.RowTemplate.Height = 35;
            this.dgvCuonSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuonSach.Size = new System.Drawing.Size(665, 477);
            this.dgvCuonSach.TabIndex = 133;
            this.dgvCuonSach.SelectionChanged += new System.EventHandler(this.dgvCuonSach_SelectionChanged);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
            this.btnCapNhat.Location = new System.Drawing.Point(360, 145);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(122, 32);
            this.btnCapNhat.TabIndex = 148;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // lblDanhMucSach
            // 
            this.lblDanhMucSach.AutoSize = true;
            this.lblDanhMucSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhMucSach.Location = new System.Drawing.Point(216, 3);
            this.lblDanhMucSach.Name = "lblDanhMucSach";
            this.lblDanhMucSach.Size = new System.Drawing.Size(237, 21);
            this.lblDanhMucSach.TabIndex = 143;
            this.lblDanhMucSach.Text = "THÔNG TIN PHÂN PHỐI SÁCH";
            // 
            // txtMaCuonSach
            // 
            this.txtMaCuonSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtMaCuonSach.Location = new System.Drawing.Point(117, 105);
            this.txtMaCuonSach.Name = "txtMaCuonSach";
            this.txtMaCuonSach.ReadOnly = true;
            this.txtMaCuonSach.Size = new System.Drawing.Size(121, 22);
            this.txtMaCuonSach.TabIndex = 140;
            this.txtMaCuonSach.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMaCuonSach
            // 
            this.labelMaCuonSach.AutoSize = true;
            this.labelMaCuonSach.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelMaCuonSach.Location = new System.Drawing.Point(29, 110);
            this.labelMaCuonSach.Name = "labelMaCuonSach";
            this.labelMaCuonSach.Size = new System.Drawing.Size(82, 13);
            this.labelMaCuonSach.TabIndex = 139;
            this.labelMaCuonSach.Text = "Mã cuốn sách:";
            // 
            // txtflag_hientrang
            // 
            this.txtflag_hientrang.Location = new System.Drawing.Point(767, 524);
            this.txtflag_hientrang.Name = "txtflag_hientrang";
            this.txtflag_hientrang.Size = new System.Drawing.Size(100, 20);
            this.txtflag_hientrang.TabIndex = 156;
            // 
            // labelTinhTrang
            // 
            this.labelTinhTrang.AutoSize = true;
            this.labelTinhTrang.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelTinhTrang.Location = new System.Drawing.Point(262, 109);
            this.labelTinhTrang.Name = "labelTinhTrang";
            this.labelTinhTrang.Size = new System.Drawing.Size(64, 13);
            this.labelTinhTrang.TabIndex = 180;
            this.labelTinhTrang.Text = "Tình trạng:";
            // 
            // labelViTri
            // 
            this.labelViTri.AutoSize = true;
            this.labelViTri.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelViTri.Location = new System.Drawing.Point(496, 110);
            this.labelViTri.Name = "labelViTri";
            this.labelViTri.Size = new System.Drawing.Size(34, 13);
            this.labelViTri.TabIndex = 181;
            this.labelViTri.Text = "Vị trí:";
            // 
            // cmbTinhTrang
            // 
            this.cmbTinhTrang.FormattingEnabled = true;
            this.cmbTinhTrang.Items.AddRange(new object[] {
            "Có sẵn",
            "Đang mượn",
            "Bị hỏng",
            "Đã mất"});
            this.cmbTinhTrang.Location = new System.Drawing.Point(332, 107);
            this.cmbTinhTrang.Name = "cmbTinhTrang";
            this.cmbTinhTrang.Size = new System.Drawing.Size(121, 21);
            this.cmbTinhTrang.TabIndex = 182;
            this.cmbTinhTrang.SelectedIndexChanged += new System.EventHandler(this.cmbTinhTrang_SelectedIndexChanged);
            // 
            // cmbViTri
            // 
            this.cmbViTri.FormattingEnabled = true;
            this.cmbViTri.Items.AddRange(new object[] {
            "Kho mượn",
            "Kho đọc"});
            this.cmbViTri.Location = new System.Drawing.Point(536, 107);
            this.cmbViTri.Name = "cmbViTri";
            this.cmbViTri.Size = new System.Drawing.Size(121, 21);
            this.cmbViTri.TabIndex = 183;
            this.cmbViTri.SelectedIndexChanged += new System.EventHandler(this.cmbViTri_SelectedIndexChanged);
            // 
            // fieldSearch
            // 
            this.fieldSearch.FilterRule = null;
            this.fieldSearch.FormattingEnabled = true;
            this.fieldSearch.Items.AddRange(new object[] {
            "Mã cuốn sách",
            "Tình trạng",
            "Vị trí"});
            this.fieldSearch.Location = new System.Drawing.Point(245, 27);
            this.fieldSearch.Name = "fieldSearch";
            this.fieldSearch.PropertySelector = null;
            this.fieldSearch.Size = new System.Drawing.Size(121, 21);
            this.fieldSearch.SuggestBoxHeight = 96;
            this.fieldSearch.SuggestListOrderRule = null;
            this.fieldSearch.TabIndex = 185;
            this.fieldSearch.SelectedIndexChanged += new System.EventHandler(this.fieldSearch_SelectedIndexChanged);
            // 
            // Thongtinchitietgaysach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 672);
            this.Controls.Add(this.fieldSearch);
            this.Controls.Add(this.cmbViTri);
            this.Controls.Add(this.cmbTinhTrang);
            this.Controls.Add(this.labelViTri);
            this.Controls.Add(this.labelTinhTrang);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.fieldQuery);
            this.Controls.Add(this.labelFieldSearch);
            this.Controls.Add(this.lbltimkiem);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvCuonSach);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.lblDanhMucSach);
            this.Controls.Add(this.txtMaCuonSach);
            this.Controls.Add(this.labelMaCuonSach);
            this.Controls.Add(this.txtflag_hientrang);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Thongtinchitietgaysach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thongtinchitietgaysach";
            this.Load += new System.EventHandler(this.Thongtinchitietgaysach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuonSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileanh;
        private System.Windows.Forms.Button btnThem;
        private SuggestComboBox fieldQuery;
        private System.Windows.Forms.Label labelFieldSearch;
        private System.Windows.Forms.Label lbltimkiem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvCuonSach;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label lblDanhMucSach;
        private System.Windows.Forms.TextBox txtMaCuonSach;
        private System.Windows.Forms.Label labelMaCuonSach;
        private System.Windows.Forms.TextBox txtflag_hientrang;
        private System.Windows.Forms.Label labelTinhTrang;
        private System.Windows.Forms.Label labelViTri;
        private System.Windows.Forms.ComboBox cmbTinhTrang;
        private System.Windows.Forms.ComboBox cmbViTri;
        private SuggestComboBox fieldSearch;
    }
}