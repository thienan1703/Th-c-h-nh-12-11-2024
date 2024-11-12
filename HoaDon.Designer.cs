namespace NhaSach
{
    partial class HoaDon
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
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.cboSach = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnThemHoaDonbtnThemHoaDon = new System.Windows.Forms.Button();
            this.btnSuaHoaDon = new System.Windows.Forms.Button();
            this.btnXoaHoaDon = new System.Windows.Forms.Button();
            this.btnTimKiemHoaDon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(349, 12);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.Size = new System.Drawing.Size(392, 212);
            this.dgvHoaDon.TabIndex = 0;
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(170, 24);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(121, 21);
            this.cboKhachHang.TabIndex = 1;
            // 
            // cboSach
            // 
            this.cboSach.FormattingEnabled = true;
            this.cboSach.Location = new System.Drawing.Point(170, 59);
            this.cboSach.Name = "cboSach";
            this.cboSach.Size = new System.Drawing.Size(121, 21);
            this.cboSach.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chọn khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chọn sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số Lượng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(170, 86);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(173, 20);
            this.txtSoLuong.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tổng tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(170, 112);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(173, 20);
            this.txtTongTien.TabIndex = 8;
            // 
            // btnThemHoaDonbtnThemHoaDon
            // 
            this.btnThemHoaDonbtnThemHoaDon.Location = new System.Drawing.Point(24, 155);
            this.btnThemHoaDonbtnThemHoaDon.Name = "btnThemHoaDonbtnThemHoaDon";
            this.btnThemHoaDonbtnThemHoaDon.Size = new System.Drawing.Size(97, 34);
            this.btnThemHoaDonbtnThemHoaDon.TabIndex = 9;
            this.btnThemHoaDonbtnThemHoaDon.Text = "Thêm hóa đơn";
            this.btnThemHoaDonbtnThemHoaDon.UseVisualStyleBackColor = true;
            this.btnThemHoaDonbtnThemHoaDon.Click += new System.EventHandler(this.btnThemHoaDonbtnThemHoaDon_Click);
            // 
            // btnSuaHoaDon
            // 
            this.btnSuaHoaDon.Location = new System.Drawing.Point(157, 155);
            this.btnSuaHoaDon.Name = "btnSuaHoaDon";
            this.btnSuaHoaDon.Size = new System.Drawing.Size(97, 34);
            this.btnSuaHoaDon.TabIndex = 10;
            this.btnSuaHoaDon.Text = "Sửa hóa đơn";
            this.btnSuaHoaDon.UseVisualStyleBackColor = true;
            this.btnSuaHoaDon.Click += new System.EventHandler(this.btnSuaHoaDon_Click);
            // 
            // btnXoaHoaDon
            // 
            this.btnXoaHoaDon.Location = new System.Drawing.Point(24, 214);
            this.btnXoaHoaDon.Name = "btnXoaHoaDon";
            this.btnXoaHoaDon.Size = new System.Drawing.Size(97, 37);
            this.btnXoaHoaDon.TabIndex = 11;
            this.btnXoaHoaDon.Text = "Xóa hóa đơn";
            this.btnXoaHoaDon.UseVisualStyleBackColor = true;
            this.btnXoaHoaDon.Click += new System.EventHandler(this.btnXoaHoaDon_Click);
            // 
            // btnTimKiemHoaDon
            // 
            this.btnTimKiemHoaDon.Location = new System.Drawing.Point(157, 214);
            this.btnTimKiemHoaDon.Name = "btnTimKiemHoaDon";
            this.btnTimKiemHoaDon.Size = new System.Drawing.Size(97, 37);
            this.btnTimKiemHoaDon.TabIndex = 12;
            this.btnTimKiemHoaDon.Text = "Tìm kiếm hóa đơn";
            this.btnTimKiemHoaDon.UseVisualStyleBackColor = true;
            this.btnTimKiemHoaDon.Click += new System.EventHandler(this.btnTimKiemHoaDon_Click);
            // 
            // HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTimKiemHoaDon);
            this.Controls.Add(this.btnXoaHoaDon);
            this.Controls.Add(this.btnSuaHoaDon);
            this.Controls.Add(this.btnThemHoaDonbtnThemHoaDon);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSach);
            this.Controls.Add(this.cboKhachHang);
            this.Controls.Add(this.dgvHoaDon);
            this.Name = "HoaDon";
            this.Text = "HoaDon";
            this.Load += new System.EventHandler(this.HoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.ComboBox cboSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnThemHoaDonbtnThemHoaDon;
        private System.Windows.Forms.Button btnSuaHoaDon;
        private System.Windows.Forms.Button btnXoaHoaDon;
        private System.Windows.Forms.Button btnTimKiemHoaDon;
    }
}