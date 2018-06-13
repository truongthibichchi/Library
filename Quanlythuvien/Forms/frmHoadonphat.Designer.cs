namespace Quanlythuvien.Forms
{
    partial class frmHoadonphat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoadonphat));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.txtmamuon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txttienphat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radiobtndanop = new System.Windows.Forms.RadioButton();
            this.radiobtnchuanop = new System.Windows.Forms.RadioButton();
            this.dgv_hoadon = new System.Windows.Forms.DataGridView();
            this.btnLuu = new System.Windows.Forms.Button();
            this.cmbtinhtrang = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtnhapmssv = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtmahoadon = new System.Windows.Forms.TextBox();
            this.pntinhtrang = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoadon)).BeginInit();
            this.pntinhtrang.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(430, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã số sinh viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(429, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã mượn:";
            // 
            // txtMSSV
            // 
            this.txtMSSV.BackColor = System.Drawing.Color.White;
            this.txtMSSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMSSV.Location = new System.Drawing.Point(550, 140);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.ReadOnly = true;
            this.txtMSSV.Size = new System.Drawing.Size(199, 22);
            this.txtMSSV.TabIndex = 1;
            // 
            // txtmamuon
            // 
            this.txtmamuon.BackColor = System.Drawing.Color.White;
            this.txtmamuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmamuon.Location = new System.Drawing.Point(550, 221);
            this.txtmamuon.Name = "txtmamuon";
            this.txtmamuon.ReadOnly = true;
            this.txtmamuon.Size = new System.Drawing.Size(199, 22);
            this.txtmamuon.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(430, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Họ và tên:";
            // 
            // txthoten
            // 
            this.txthoten.BackColor = System.Drawing.Color.White;
            this.txthoten.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthoten.Location = new System.Drawing.Point(550, 180);
            this.txthoten.Name = "txthoten";
            this.txthoten.ReadOnly = true;
            this.txthoten.Size = new System.Drawing.Size(199, 22);
            this.txthoten.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(302, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "HÓA ĐƠN PHẠT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(429, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tổng tiền phạt:";
            // 
            // txttienphat
            // 
            this.txttienphat.BackColor = System.Drawing.Color.White;
            this.txttienphat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttienphat.Location = new System.Drawing.Point(550, 258);
            this.txttienphat.Name = "txttienphat";
            this.txttienphat.ReadOnly = true;
            this.txttienphat.Size = new System.Drawing.Size(199, 22);
            this.txttienphat.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(433, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tình trạng:";
            // 
            // radiobtndanop
            // 
            this.radiobtndanop.AutoSize = true;
            this.radiobtndanop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiobtndanop.Location = new System.Drawing.Point(550, 309);
            this.radiobtndanop.Name = "radiobtndanop";
            this.radiobtndanop.Size = new System.Drawing.Size(68, 19);
            this.radiobtndanop.TabIndex = 3;
            this.radiobtndanop.Text = "Đã nộp ";
            this.radiobtndanop.UseVisualStyleBackColor = true;
            // 
            // radiobtnchuanop
            // 
            this.radiobtnchuanop.AutoSize = true;
            this.radiobtnchuanop.Checked = true;
            this.radiobtnchuanop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiobtnchuanop.Location = new System.Drawing.Point(664, 310);
            this.radiobtnchuanop.Name = "radiobtnchuanop";
            this.radiobtnchuanop.Size = new System.Drawing.Size(78, 19);
            this.radiobtnchuanop.TabIndex = 3;
            this.radiobtnchuanop.TabStop = true;
            this.radiobtnchuanop.Text = "Chưa nộp";
            this.radiobtnchuanop.UseVisualStyleBackColor = true;
            // 
            // dgv_hoadon
            // 
            this.dgv_hoadon.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_hoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hoadon.Location = new System.Drawing.Point(12, 103);
            this.dgv_hoadon.Name = "dgv_hoadon";
            this.dgv_hoadon.ReadOnly = true;
            this.dgv_hoadon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_hoadon.Size = new System.Drawing.Size(415, 284);
            this.dgv_hoadon.TabIndex = 4;
            this.dgv_hoadon.SelectionChanged += new System.EventHandler(this.dgv_hoadon_SelectionChanged);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(550, 352);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLuu.Size = new System.Drawing.Size(72, 35);
            this.btnLuu.TabIndex = 158;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // cmbtinhtrang
            // 
            this.cmbtinhtrang.BackColor = System.Drawing.Color.White;
            this.cmbtinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtinhtrang.FormattingEnabled = true;
            this.cmbtinhtrang.Location = new System.Drawing.Point(71, 2);
            this.cmbtinhtrang.Name = "cmbtinhtrang";
            this.cmbtinhtrang.Size = new System.Drawing.Size(199, 21);
            this.cmbtinhtrang.TabIndex = 159;
            this.cmbtinhtrang.SelectedIndexChanged += new System.EventHandler(this.cmbtinhtrang_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-2, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 160;
            this.label7.Text = "Tình trạng:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nhập mã số sinh viên:";
            // 
            // txtnhapmssv
            // 
            this.txtnhapmssv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnhapmssv.Location = new System.Drawing.Point(137, 38);
            this.txtnhapmssv.Name = "txtnhapmssv";
            this.txtnhapmssv.Size = new System.Drawing.Size(199, 22);
            this.txtnhapmssv.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = ((System.Drawing.Image)(resources.GetObject("btnTim.Image")));
            this.btnTim.Location = new System.Drawing.Point(356, 33);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(63, 32);
            this.btnTim.TabIndex = 161;
            this.btnTim.Text = "Tìm";
            this.btnTim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(429, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mã hóa đơn:";
            // 
            // txtmahoadon
            // 
            this.txtmahoadon.BackColor = System.Drawing.Color.White;
            this.txtmahoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmahoadon.Location = new System.Drawing.Point(550, 103);
            this.txtmahoadon.Name = "txtmahoadon";
            this.txtmahoadon.ReadOnly = true;
            this.txtmahoadon.Size = new System.Drawing.Size(199, 22);
            this.txtmahoadon.TabIndex = 1;
            // 
            // pntinhtrang
            // 
            this.pntinhtrang.Controls.Add(this.cmbtinhtrang);
            this.pntinhtrang.Controls.Add(this.label7);
            this.pntinhtrang.Location = new System.Drawing.Point(66, 71);
            this.pntinhtrang.Name = "pntinhtrang";
            this.pntinhtrang.Size = new System.Drawing.Size(280, 26);
            this.pntinhtrang.TabIndex = 162;
            // 
            // frmHoadonphat
            // 
            this.AcceptButton = this.btnTim;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 399);
            this.Controls.Add(this.pntinhtrang);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgv_hoadon);
            this.Controls.Add(this.radiobtnchuanop);
            this.Controls.Add(this.radiobtndanop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txttienphat);
            this.Controls.Add(this.txtmahoadon);
            this.Controls.Add(this.txtmamuon);
            this.Controls.Add(this.txthoten);
            this.Controls.Add(this.txtnhapmssv);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmHoadonphat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HÓA ĐƠN PHẠT";
            this.Load += new System.EventHandler(this.frmHoadonphat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoadon)).EndInit();
            this.pntinhtrang.ResumeLayout(false);
            this.pntinhtrang.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.TextBox txtmamuon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttienphat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radiobtndanop;
        private System.Windows.Forms.RadioButton radiobtnchuanop;
        private System.Windows.Forms.DataGridView dgv_hoadon;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ComboBox cmbtinhtrang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtnhapmssv;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtmahoadon;
        private System.Windows.Forms.Panel pntinhtrang;
    }
}