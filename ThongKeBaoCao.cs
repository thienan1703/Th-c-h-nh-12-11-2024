using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaSach
{
    public partial class ThongKeBaoCao : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=NhaSach;Integrated Security=True";
        public ThongKeBaoCao()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ThongKeBaoCao_Load(object sender, EventArgs e)
        {
            LoadThongKeData();
        }


        private void LoadThongKeData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MONTH(hd.NgayLap) AS Thang, " +
                               "SUM(ct.SoLuong) AS TongSoLuongBan, " +
                               "SUM(ct.SoLuong * ct.DonGia) AS DoanhThu " +
                               "FROM HoaDon hd " +
                               "JOIN ChiTietHoaDon ct ON hd.MaHoaDon = ct.MaHoaDon " +
                               "GROUP BY MONTH(hd.NgayLap) " +
                               "ORDER BY Thang";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvThongKe.DataSource = dataTable;
            }
        }
    }
}
