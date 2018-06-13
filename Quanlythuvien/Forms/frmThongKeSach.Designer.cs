namespace Quanlythuvien.Forms
{
    partial class frmThongKeSach
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.USP_TKSACHHUHONG_DAMATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new Quanlythuvien.Forms.DataSet1();
            this.USP_TKTONGSACHTHEOTUNGNAMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_TKTOP10SACHDUOCMUONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_TKTATCASACHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.rptSachHuHong_DaMat = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptTongSachTheoTungNam = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptTop10SachDuocMuon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptTatCaSach = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnTatCaSach = new System.Windows.Forms.Button();
            this.USP_TKTATCASACHTableAdapter = new Quanlythuvien.Forms.DataSet1TableAdapters.USP_TKTATCASACHTableAdapter();
            this.USP_TKTOP10SACHDUOCMUONTableAdapter = new Quanlythuvien.Forms.DataSet1TableAdapters.USP_TKTOP10SACHDUOCMUONTableAdapter();
            this.USP_TKTONGSACHTHEOTUNGNAMTableAdapter = new Quanlythuvien.Forms.DataSet1TableAdapters.USP_TKTONGSACHTHEOTUNGNAMTableAdapter();
            this.USP_TKSACHHUHONG_DAMATTableAdapter = new Quanlythuvien.Forms.DataSet1TableAdapters.USP_TKSACHHUHONG_DAMATTableAdapter();
            this.btnSachDuocMuonNhieuNhat = new System.Windows.Forms.Button();
            this.btnTongSachTheoTungNam = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TKSACHHUHONG_DAMATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TKTONGSACHTHEOTUNGNAMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TKTOP10SACHDUOCMUONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TKTATCASACHBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // USP_TKSACHHUHONG_DAMATBindingSource
            // 
            this.USP_TKSACHHUHONG_DAMATBindingSource.DataMember = "USP_TKSACHHUHONG_DAMAT";
            this.USP_TKSACHHUHONG_DAMATBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_TKTONGSACHTHEOTUNGNAMBindingSource
            // 
            this.USP_TKTONGSACHTHEOTUNGNAMBindingSource.DataMember = "USP_TKTONGSACHTHEOTUNGNAM";
            this.USP_TKTONGSACHTHEOTUNGNAMBindingSource.DataSource = this.DataSet1;
            // 
            // USP_TKTOP10SACHDUOCMUONBindingSource
            // 
            this.USP_TKTOP10SACHDUOCMUONBindingSource.DataMember = "USP_TKTOP10SACHDUOCMUON";
            this.USP_TKTOP10SACHDUOCMUONBindingSource.DataSource = this.DataSet1;
            // 
            // USP_TKTATCASACHBindingSource
            // 
            this.USP_TKTATCASACHBindingSource.DataMember = "USP_TKTATCASACH";
            this.USP_TKTATCASACHBindingSource.DataSource = this.DataSet1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rptSachHuHong_DaMat);
            this.panel1.Controls.Add(this.rptTongSachTheoTungNam);
            this.panel1.Controls.Add(this.rptTop10SachDuocMuon);
            this.panel1.Controls.Add(this.rptTatCaSach);
            this.panel1.Location = new System.Drawing.Point(2, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 599);
            this.panel1.TabIndex = 0;
            // 
            // rptSachHuHong_DaMat
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_TKSACHHUHONG_DAMATBindingSource;
            this.rptSachHuHong_DaMat.LocalReport.DataSources.Add(reportDataSource1);
            this.rptSachHuHong_DaMat.LocalReport.ReportEmbeddedResource = "Quanlythuvien.Forms.reportSachHuHong_DaMat.rdlc";
            this.rptSachHuHong_DaMat.Location = new System.Drawing.Point(390, 20);
            this.rptSachHuHong_DaMat.Name = "rptSachHuHong_DaMat";
            this.rptSachHuHong_DaMat.Size = new System.Drawing.Size(396, 246);
            this.rptSachHuHong_DaMat.TabIndex = 3;
            // 
            // rptTongSachTheoTungNam
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.USP_TKTONGSACHTHEOTUNGNAMBindingSource;
            this.rptTongSachTheoTungNam.LocalReport.DataSources.Add(reportDataSource2);
            this.rptTongSachTheoTungNam.LocalReport.ReportEmbeddedResource = "Quanlythuvien.Forms.reportTongSachTheoTungNam.rdlc";
            this.rptTongSachTheoTungNam.Location = new System.Drawing.Point(271, 20);
            this.rptTongSachTheoTungNam.Name = "rptTongSachTheoTungNam";
            this.rptTongSachTheoTungNam.ShowToolBar = false;
            this.rptTongSachTheoTungNam.Size = new System.Drawing.Size(396, 246);
            this.rptTongSachTheoTungNam.TabIndex = 2;
            // 
            // rptTop10SachDuocMuon
            // 
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.USP_TKTOP10SACHDUOCMUONBindingSource;
            this.rptTop10SachDuocMuon.LocalReport.DataSources.Add(reportDataSource3);
            this.rptTop10SachDuocMuon.LocalReport.ReportEmbeddedResource = "Quanlythuvien.Forms.reportTop10SachDuocMuon.rdlc";
            this.rptTop10SachDuocMuon.Location = new System.Drawing.Point(140, 20);
            this.rptTop10SachDuocMuon.Name = "rptTop10SachDuocMuon";
            this.rptTop10SachDuocMuon.Size = new System.Drawing.Size(396, 246);
            this.rptTop10SachDuocMuon.TabIndex = 1;
            // 
            // rptTatCaSach
            // 
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.USP_TKTATCASACHBindingSource;
            this.rptTatCaSach.LocalReport.DataSources.Add(reportDataSource4);
            this.rptTatCaSach.LocalReport.ReportEmbeddedResource = "Quanlythuvien.Forms.reportTatCaSach.rdlc";
            this.rptTatCaSach.Location = new System.Drawing.Point(10, 20);
            this.rptTatCaSach.Name = "rptTatCaSach";
            this.rptTatCaSach.Size = new System.Drawing.Size(396, 246);
            this.rptTatCaSach.TabIndex = 0;
            // 
            // btnTatCaSach
            // 
            this.btnTatCaSach.ForeColor = System.Drawing.Color.Blue;
            this.btnTatCaSach.Location = new System.Drawing.Point(198, 4);
            this.btnTatCaSach.Name = "btnTatCaSach";
            this.btnTatCaSach.Size = new System.Drawing.Size(97, 38);
            this.btnTatCaSach.TabIndex = 1;
            this.btnTatCaSach.Text = "Tất cả sách";
            this.btnTatCaSach.UseVisualStyleBackColor = true;
            this.btnTatCaSach.Click += new System.EventHandler(this.btnTatCaSach_Click);
            // 
            // USP_TKTATCASACHTableAdapter
            // 
            this.USP_TKTATCASACHTableAdapter.ClearBeforeFill = true;
            // 
            // USP_TKTOP10SACHDUOCMUONTableAdapter
            // 
            this.USP_TKTOP10SACHDUOCMUONTableAdapter.ClearBeforeFill = true;
            // 
            // USP_TKTONGSACHTHEOTUNGNAMTableAdapter
            // 
            this.USP_TKTONGSACHTHEOTUNGNAMTableAdapter.ClearBeforeFill = true;
            // 
            // USP_TKSACHHUHONG_DAMATTableAdapter
            // 
            this.USP_TKSACHHUHONG_DAMATTableAdapter.ClearBeforeFill = true;
            // 
            // btnSachDuocMuonNhieuNhat
            // 
            this.btnSachDuocMuonNhieuNhat.ForeColor = System.Drawing.Color.Blue;
            this.btnSachDuocMuonNhieuNhat.Location = new System.Drawing.Point(325, 4);
            this.btnSachDuocMuonNhieuNhat.Name = "btnSachDuocMuonNhieuNhat";
            this.btnSachDuocMuonNhieuNhat.Size = new System.Drawing.Size(105, 38);
            this.btnSachDuocMuonNhieuNhat.TabIndex = 2;
            this.btnSachDuocMuonNhieuNhat.Text = "Sách được mượn nhiều nhất";
            this.btnSachDuocMuonNhieuNhat.UseVisualStyleBackColor = true;
            this.btnSachDuocMuonNhieuNhat.Click += new System.EventHandler(this.btnSachDuocMuonNhieuNhat_Click);
            // 
            // btnTongSachTheoTungNam
            // 
            this.btnTongSachTheoTungNam.ForeColor = System.Drawing.Color.Blue;
            this.btnTongSachTheoTungNam.Location = new System.Drawing.Point(457, 4);
            this.btnTongSachTheoTungNam.Name = "btnTongSachTheoTungNam";
            this.btnTongSachTheoTungNam.Size = new System.Drawing.Size(98, 38);
            this.btnTongSachTheoTungNam.TabIndex = 3;
            this.btnTongSachTheoTungNam.Text = "Tổng sách theo từng năm";
            this.btnTongSachTheoTungNam.UseVisualStyleBackColor = true;
            this.btnTongSachTheoTungNam.Click += new System.EventHandler(this.btnTongSachTheoTungNam_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(577, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = "Sách hư hỏng/bị mất";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmThongKeSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 645);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnTongSachTheoTungNam);
            this.Controls.Add(this.btnSachDuocMuonNhieuNhat);
            this.Controls.Add(this.btnTatCaSach);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(994, 684);
            this.MinimumSize = new System.Drawing.Size(994, 684);
            this.Name = "frmThongKeSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê sách";
            this.Load += new System.EventHandler(this.frmThongKeSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_TKSACHHUHONG_DAMATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TKTONGSACHTHEOTUNGNAMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TKTOP10SACHDUOCMUONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TKTATCASACHBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer rptTatCaSach;
        private System.Windows.Forms.Button btnTatCaSach;
        private System.Windows.Forms.BindingSource USP_TKTATCASACHBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.USP_TKTATCASACHTableAdapter USP_TKTATCASACHTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer rptTop10SachDuocMuon;
        private System.Windows.Forms.BindingSource USP_TKTOP10SACHDUOCMUONBindingSource;
        private DataSet1TableAdapters.USP_TKTOP10SACHDUOCMUONTableAdapter USP_TKTOP10SACHDUOCMUONTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer rptTongSachTheoTungNam;
        private System.Windows.Forms.BindingSource USP_TKTONGSACHTHEOTUNGNAMBindingSource;
        private DataSet1TableAdapters.USP_TKTONGSACHTHEOTUNGNAMTableAdapter USP_TKTONGSACHTHEOTUNGNAMTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer rptSachHuHong_DaMat;
        private System.Windows.Forms.BindingSource USP_TKSACHHUHONG_DAMATBindingSource;
        private DataSet1TableAdapters.USP_TKSACHHUHONG_DAMATTableAdapter USP_TKSACHHUHONG_DAMATTableAdapter;
        private System.Windows.Forms.Button btnSachDuocMuonNhieuNhat;
        private System.Windows.Forms.Button btnTongSachTheoTungNam;
        private System.Windows.Forms.Button button2;
    }
}