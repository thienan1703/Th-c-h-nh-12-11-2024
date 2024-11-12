using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaSach
{
    public partial class HeThong : Form
    {
        public HeThong()
        {
            InitializeComponent();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loạiSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            // Chuyển về form đăng nhập
            this.Hide();
            dangnhap loginForm = new dangnhap();
            loginForm.Show();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sach sachForm = new Sach();
            sachForm.Show();
        }

        private void loạiSáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoaiSach loaiSachForm = new LoaiSach();
            loaiSachForm.Show();
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Mở form HoaDon
            HoaDon hoaDonForm = new HoaDon();
            hoaDonForm.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeBaoCao thongKeForm = new ThongKeBaoCao();
            thongKeForm.Show();
        }
    }
}
