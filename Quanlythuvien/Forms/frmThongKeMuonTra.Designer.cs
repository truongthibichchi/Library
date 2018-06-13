namespace Quanlythuvien.Forms
{
    partial class frmThongKeMuonTra
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
            this.USP_TKLUOTMUONSACHTHEOSVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new Quanlythuvien.Forms.DataSet1();
            this.USP_TKSINHVIENTREHANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptLuotMuonSachTheoSinhVien = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptSVTreHan = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_TKLUOTMUONSACHTHEOSVTableAdapter = new Quanlythuvien.Forms.DataSet1TableAdapters.USP_TKLUOTMUONSACHTHEOSVTableAdapter();
            this.USP_TKSINHVIENTREHANTableAdapter = new Quanlythuvien.Forms.DataSet1TableAdapters.USP_TKSINHVIENTREHANTableAdapter();
            this.grbLuotMuonSachTheoSV = new System.Windows.Forms.GroupBox();
            this.grbSVTreHan = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TKLUOTMUONSACHTHEOSVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TKSINHVIENTREHANBindingSource)).BeginInit();
            this.grbLuotMuonSachTheoSV.SuspendLayout();
            this.grbSVTreHan.SuspendLayout();
            this.SuspendLayout();
            // 
            // USP_TKLUOTMUONSACHTHEOSVBindingSource
            // 
            this.USP_TKLUOTMUONSACHTHEOSVBindingSource.DataMember = "USP_TKLUOTMUONSACHTHEOSV";
            this.USP_TKLUOTMUONSACHTHEOSVBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_TKSINHVIENTREHANBindingSource
            // 
            this.USP_TKSINHVIENTREHANBindingSource.DataMember = "USP_TKSINHVIENTREHAN";
            this.USP_TKSINHVIENTREHANBindingSource.DataSource = this.DataSet1;
            // 
            // rptLuotMuonSachTheoSinhVien
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_TKLUOTMUONSACHTHEOSVBindingSource;
            this.rptLuotMuonSachTheoSinhVien.LocalReport.DataSources.Add(reportDataSource1);
            this.rptLuotMuonSachTheoSinhVien.LocalReport.ReportEmbeddedResource = "Quanlythuvien.Forms.reportLuotMuonSachTheoSinhVien.rdlc";
            this.rptLuotMuonSachTheoSinhVien.Location = new System.Drawing.Point(13, 19);
            this.rptLuotMuonSachTheoSinhVien.Name = "rptLuotMuonSachTheoSinhVien";
            this.rptLuotMuonSachTheoSinhVien.Size = new System.Drawing.Size(289, 416);
            this.rptLuotMuonSachTheoSinhVien.TabIndex = 0;
            // 
            // rptSVTreHan
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.USP_TKSINHVIENTREHANBindingSource;
            this.rptSVTreHan.LocalReport.DataSources.Add(reportDataSource2);
            this.rptSVTreHan.LocalReport.ReportEmbeddedResource = "Quanlythuvien.Forms.reportSVTreHan.rdlc";
            this.rptSVTreHan.Location = new System.Drawing.Point(18, 21);
            this.rptSVTreHan.Name = "rptSVTreHan";
            this.rptSVTreHan.Size = new System.Drawing.Size(555, 181);
            this.rptSVTreHan.TabIndex = 1;
            // 
            // USP_TKLUOTMUONSACHTHEOSVTableAdapter
            // 
            this.USP_TKLUOTMUONSACHTHEOSVTableAdapter.ClearBeforeFill = true;
            // 
            // USP_TKSINHVIENTREHANTableAdapter
            // 
            this.USP_TKSINHVIENTREHANTableAdapter.ClearBeforeFill = true;
            // 
            // grbLuotMuonSachTheoSV
            // 
            this.grbLuotMuonSachTheoSV.Controls.Add(this.rptLuotMuonSachTheoSinhVien);
            this.grbLuotMuonSachTheoSV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbLuotMuonSachTheoSV.ForeColor = System.Drawing.Color.Blue;
            this.grbLuotMuonSachTheoSV.Location = new System.Drawing.Point(-1, 12);
            this.grbLuotMuonSachTheoSV.Name = "grbLuotMuonSachTheoSV";
            this.grbLuotMuonSachTheoSV.Size = new System.Drawing.Size(334, 583);
            this.grbLuotMuonSachTheoSV.TabIndex = 3;
            this.grbLuotMuonSachTheoSV.TabStop = false;
            this.grbLuotMuonSachTheoSV.Text = "Lượt mượn sách theo sinh viên";
            // 
            // grbSVTreHan
            // 
            this.grbSVTreHan.Controls.Add(this.rptSVTreHan);
            this.grbSVTreHan.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSVTreHan.ForeColor = System.Drawing.Color.Blue;
            this.grbSVTreHan.Location = new System.Drawing.Point(339, 12);
            this.grbSVTreHan.MaximumSize = new System.Drawing.Size(623, 583);
            this.grbSVTreHan.MinimumSize = new System.Drawing.Size(623, 583);
            this.grbSVTreHan.Name = "grbSVTreHan";
            this.grbSVTreHan.Size = new System.Drawing.Size(623, 583);
            this.grbSVTreHan.TabIndex = 4;
            this.grbSVTreHan.TabStop = false;
            this.grbSVTreHan.Text = "Danh sách sinh viên trễ hạn";
            // 
            // frmThongKeMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 593);
            this.Controls.Add(this.grbSVTreHan);
            this.Controls.Add(this.grbLuotMuonSachTheoSV);
            this.Name = "frmThongKeMuonTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê mượn/trả";
            this.Load += new System.EventHandler(this.frmThongKeMuonTra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_TKLUOTMUONSACHTHEOSVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TKSINHVIENTREHANBindingSource)).EndInit();
            this.grbLuotMuonSachTheoSV.ResumeLayout(false);
            this.grbSVTreHan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer rptLuotMuonSachTheoSinhVien;
        private Microsoft.Reporting.WinForms.ReportViewer rptSVTreHan;
        private System.Windows.Forms.BindingSource USP_TKLUOTMUONSACHTHEOSVBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.USP_TKLUOTMUONSACHTHEOSVTableAdapter USP_TKLUOTMUONSACHTHEOSVTableAdapter;
        private System.Windows.Forms.BindingSource USP_TKSINHVIENTREHANBindingSource;
        private DataSet1TableAdapters.USP_TKSINHVIENTREHANTableAdapter USP_TKSINHVIENTREHANTableAdapter;
        private System.Windows.Forms.GroupBox grbLuotMuonSachTheoSV;
        private System.Windows.Forms.GroupBox grbSVTreHan;
    }
}