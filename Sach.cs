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
    public partial class Sach : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=NhaSach;Integrated Security=True";
        public Sach()
        {
            InitializeComponent();
        }
        private void LoadSachData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Sach ORDER BY TenSach";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvSach.DataSource = dataTable;
            }
        }
        private void Sach_Load(object sender, EventArgs e)
        {
            LoadSachData();
            LoadLoaiSachComboBox();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Sach (TenSach, TacGia, GiaBan, SoLuong, MoTa, MaLoaiSach) " +
                               "VALUES (@TenSach, @TacGia, @GiaBan, @SoLuong, @MoTa, @MaLoaiSach)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenSach", txtTenSach.Text);
                command.Parameters.AddWithValue("@TacGia", txtTacGia.Text);
                command.Parameters.AddWithValue("@GiaBan", Convert.ToDecimal(txtGiaBan.Text));
                command.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(txtSoLuong.Text));
                command.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                command.Parameters.AddWithValue("@MaLoaiSach", cboLoaiSach.SelectedValue);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                LoadSachData();
                MessageBox.Show("Đã thêm sách thành công!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSach.SelectedRows.Count > 0)
            {
                int maSach = Convert.ToInt32(dgvSach.SelectedRows[0].Cells["MaSach"].Value);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Sach SET TenSach = @TenSach, TacGia = @TacGia, GiaBan = @GiaBan, " +
                                   "SoLuong = @SoLuong, MoTa = @MoTa, MaLoaiSach = @MaLoaiSach WHERE MaSach = @MaSach";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenSach", txtTenSach.Text);
                    command.Parameters.AddWithValue("@TacGia", txtTacGia.Text);
                    command.Parameters.AddWithValue("@GiaBan", Convert.ToDecimal(txtGiaBan.Text));
                    command.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(txtSoLuong.Text));
                    command.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                    command.Parameters.AddWithValue("@MaLoaiSach", cboLoaiSach.SelectedValue);
                    command.Parameters.AddWithValue("@MaSach", maSach);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    LoadSachData();
                    MessageBox.Show("Đã cập nhật sách thành công!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSach.SelectedRows.Count > 0)
            {
                int maSach = Convert.ToInt32(dgvSach.SelectedRows[0].Cells["MaSach"].Value);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Sach WHERE MaSach = @MaSach";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaSach", maSach);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    LoadSachData();
                    MessageBox.Show("Đã xóa sách thành công!");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Sach WHERE MaLoaiSach = @MaLoaiSach";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@MaLoaiSach", cboLoaiSach.SelectedValue);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvSach.DataSource = dataTable;
            }
        }
        private void LoadLoaiSachComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MaLoaiSach, TenLoaiSach FROM LoaiSach";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cboLoaiSach.DataSource = dataTable;
                cboLoaiSach.DisplayMember = "TenLoaiSach";
                cboLoaiSach.ValueMember = "MaLoaiSach";
            }
        }

    }
}
