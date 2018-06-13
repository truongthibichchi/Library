namespace Quanlythuvien.Forms
{
    partial class frmDangNhap
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.llblQuenMK = new System.Windows.Forms.LinkLabel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.txttaikhoan = new System.Windows.Forms.TextBox();
            this.lblmessage = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.lblmatkhau = new System.Windows.Forms.Label();
            this.lbltaikhoan = new System.Windows.Forms.Label();
            this.picKhoa = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKhoa)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.llblQuenMK);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnDangNhap);
            this.panel1.Controls.Add(this.txtmatkhau);
            this.panel1.Controls.Add(this.txttaikhoan);
            this.panel1.Controls.Add(this.lblmessage);
            this.panel1.Controls.Add(this.lblThongBao);
            this.panel1.Controls.Add(this.lblmatkhau);
            this.panel1.Controls.Add(this.lbltaikhoan);
            this.panel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(199, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 238);
            this.panel1.TabIndex = 0;
            // 
            // llblQuenMK
            // 
            this.llblQuenMK.AutoSize = true;
            this.llblQuenMK.Location = new System.Drawing.Point(119, 201);
            this.llblQuenMK.Name = "llblQuenMK";
            this.llblQuenMK.Size = new System.Drawing.Size(86, 13);
            this.llblQuenMK.TabIndex = 12;
            this.llblQuenMK.TabStop = true;
            this.llblQuenMK.Text = "Quên mật khẩu?";
            this.llblQuenMK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblQuenMK_LinkClicked);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(170, 164);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(89, 164);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(75, 23);
            this.btnDangNhap.TabIndex = 10;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click_1);
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Location = new System.Drawing.Point(82, 96);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.PasswordChar = '*';
            this.txtmatkhau.Size = new System.Drawing.Size(163, 20);
            this.txtmatkhau.TabIndex = 9;
            this.txtmatkhau.UseSystemPasswordChar = true;
            // 
            // txttaikhoan
            // 
            this.txttaikhoan.Location = new System.Drawing.Point(82, 50);
            this.txttaikhoan.Name = "txttaikhoan";
            this.txttaikhoan.Size = new System.Drawing.Size(163, 20);
            this.txttaikhoan.TabIndex = 8;
            // 
            // lblmessage
            // 
            this.lblmessage.AutoSize = true;
            this.lblmessage.ForeColor = System.Drawing.Color.Red;
            this.lblmessage.Location = new System.Drawing.Point(34, 131);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(0, 13);
            this.lblmessage.TabIndex = 7;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Location = new System.Drawing.Point(31, 24);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(0, 13);
            this.lblThongBao.TabIndex = 1;
            // 
            // lblmatkhau
            // 
            this.lblmatkhau.AutoSize = true;
            this.lblmatkhau.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblmatkhau.Location = new System.Drawing.Point(21, 99);
            this.lblmatkhau.Name = "lblmatkhau";
            this.lblmatkhau.Size = new System.Drawing.Size(55, 13);
            this.lblmatkhau.TabIndex = 1;
            this.lblmatkhau.Text = "Mật khẩu:";
            // 
            // lbltaikhoan
            // 
            this.lbltaikhoan.AutoSize = true;
            this.lbltaikhoan.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lbltaikhoan.Location = new System.Drawing.Point(21, 53);
            this.lbltaikhoan.Name = "lbltaikhoan";
            this.lbltaikhoan.Size = new System.Drawing.Size(58, 13);
            this.lbltaikhoan.TabIndex = 1;
            this.lbltaikhoan.Text = "Tài khoản:";
            // 
            // picKhoa
            // 
            this.picKhoa.Image = global::Quanlythuvien.Properties.Resources.Password_80;
            this.picKhoa.Location = new System.Drawing.Point(12, 36);
            this.picKhoa.Name = "picKhoa";
            this.picKhoa.Size = new System.Drawing.Size(159, 199);
            this.picKhoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKhoa.TabIndex = 1;
            this.picKhoa.TabStop = false;
            // 
            // frmDangNhap
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 263);
            this.Controls.Add(this.picKhoa);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG NHẬP";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKhoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Label lblmatkhau;
        private System.Windows.Forms.Label lbltaikhoan;
        private System.Windows.Forms.PictureBox picKhoa;
        private System.Windows.Forms.Label lblmessage;
        private System.Windows.Forms.LinkLabel llblQuenMK;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.TextBox txttaikhoan;
    }
}