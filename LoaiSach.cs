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
    public partial class LoaiSach : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=NhaSach;Integrated Security=True";

        public LoaiSach()
        {
            InitializeComponent();
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO LoaiSach (TenLoaiSach, MoTa) VALUES (@TenLoaiSach, @MoTa)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenLoaiSach", txtTenLoaiSach.Text);
                command.Parameters.AddWithValue("@MoTa", txtMoTa.Text);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                LoadLoaiSachData();
                MessageBox.Show("Đã thêm loại sách thành công!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLoaiSach.SelectedRows.Count > 0)
            {
                int maLoaiSach = Convert.ToInt32(dgvLoaiSach.SelectedRows[0].Cells["MaLoaiSach"].Value);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE LoaiSach SET TenLoaiSach = @TenLoaiSach, MoTa = @MoTa WHERE MaLoaiSach = @MaLoaiSach";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenLoaiSach", txtTenLoaiSach.Text);
                    command.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                    command.Parameters.AddWithValue("@MaLoaiSach", maLoaiSach);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    LoadLoaiSachData();
                    MessageBox.Show("Đã cập nhật loại sách thành công!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLoaiSach.SelectedRows.Count > 0)
            {
                int maLoaiSach = Convert.ToInt32(dgvLoaiSach.SelectedRows[0].Cells["MaLoaiSach"].Value);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM LoaiSach WHERE MaLoaiSach = @MaLoaiSach";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaLoaiSach", maLoaiSach);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    LoadLoaiSachData();
                    MessageBox.Show("Đã xóa loại sách thành công!");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM LoaiSach WHERE TenLoaiSach LIKE '%' + @TenLoaiSach + '%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@TenLoaiSach", txtTenLoaiSach.Text);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvLoaiSach.DataSource = dataTable;
            }
        }
        private void LoadLoaiSachData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM LoaiSach ORDER BY TenLoaiSach";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvLoaiSach.DataSource = dataTable;
            }
        }

        // Gọi phương thức này khi form load
        private void LoaiSach_Load(object sender, EventArgs e)
        {
            LoadLoaiSachData();
        }

    }
}
