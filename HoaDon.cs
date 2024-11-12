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
    public partial class HoaDon : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=NhaSach;Integrated Security=True";

        public HoaDon()
        {
            InitializeComponent();
        }
        private void LoadHoaDonData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT hd.MaHoaDon, hd.NgayLap, kh.TenKhachHang, SUM(ct.SoLuong * ct.DonGia) AS TongTien " +
                               "FROM HoaDon hd " +
                               "JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang " +
                               "JOIN ChiTietHoaDon ct ON hd.MaHoaDon = ct.MaHoaDon " +
                               "GROUP BY hd.MaHoaDon, hd.NgayLap, kh.TenKhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvHoaDon.DataSource = dataTable;
            }
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDonData();
            LoadKhachHangComboBox();
            LoadSachComboBox();
        }

        private void btnThemHoaDonbtnThemHoaDon_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Bắt đầu transaction để thực hiện nhiều lệnh SQL
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Thêm hóa đơn
                    string queryHoaDon = "INSERT INTO HoaDon (NgayLap, MaKhachHang) VALUES (@NgayLap, @MaKhachHang); SELECT SCOPE_IDENTITY();";
                    SqlCommand commandHoaDon = new SqlCommand(queryHoaDon, connection, transaction);
                    commandHoaDon.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                    commandHoaDon.Parameters.AddWithValue("@MaKhachHang", cboKhachHang.SelectedValue);

                    int maHoaDon = Convert.ToInt32(commandHoaDon.ExecuteScalar());

                    // Thêm chi tiết hóa đơn
                    string queryChiTiet = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaSach, SoLuong, DonGia) VALUES (@MaHoaDon, @MaSach, @SoLuong, @DonGia)";
                    SqlCommand commandChiTiet = new SqlCommand(queryChiTiet, connection, transaction);
                    commandChiTiet.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    commandChiTiet.Parameters.AddWithValue("@MaSach", cboSach.SelectedValue);
                    commandChiTiet.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(txtSoLuong.Text));

                    // Lấy đơn giá sách
                    string queryDonGia = "SELECT GiaBan FROM Sach WHERE MaSach = @MaSach";
                    SqlCommand commandDonGia = new SqlCommand(queryDonGia, connection, transaction);
                    commandDonGia.Parameters.AddWithValue("@MaSach", cboSach.SelectedValue);
                    int donGia = Convert.ToInt32(commandDonGia.ExecuteScalar());
                    commandChiTiet.Parameters.AddWithValue("@DonGia", donGia);

                    commandChiTiet.ExecuteNonQuery();

                    // Xác nhận transaction thành công
                    transaction.Commit();

                    LoadHoaDonData();
                    MessageBox.Show("Đã thêm hóa đơn thành công!");
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, rollback transaction
                    transaction.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnSuaHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                int maHoaDon = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["MaHoaDon"].Value);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Cập nhật thông tin hóa đơn
                        string query = "UPDATE HoaDon SET MaKhachHang = @MaKhachHang WHERE MaHoaDon = @MaHoaDon";
                        SqlCommand command = new SqlCommand(query, connection, transaction);
                        command.Parameters.AddWithValue("@MaKhachHang", cboKhachHang.SelectedValue);
                        command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                        command.ExecuteNonQuery();
                        transaction.Commit();

                        LoadHoaDonData();
                        MessageBox.Show("Đã cập nhật hóa đơn thành công!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                int maHoaDon = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["MaHoaDon"].Value);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Xóa chi tiết hóa đơn trước
                        string queryChiTiet = "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
                        SqlCommand commandChiTiet = new SqlCommand(queryChiTiet, connection, transaction);
                        commandChiTiet.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        commandChiTiet.ExecuteNonQuery();

                        // Xóa hóa đơn
                        string queryHoaDon = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
                        SqlCommand commandHoaDon = new SqlCommand(queryHoaDon, connection, transaction);
                        commandHoaDon.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        commandHoaDon.ExecuteNonQuery();

                        transaction.Commit();
                        LoadHoaDonData();
                        MessageBox.Show("Đã xóa hóa đơn thành công!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        private void btnTimKiemHoaDon_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT hd.MaHoaDon, hd.NgayLap, kh.TenKhachHang, SUM(ct.SoLuong * ct.DonGia) AS TongTien " +
                               "FROM HoaDon hd " +
                               "JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang " +
                               "JOIN ChiTietHoaDon ct ON hd.MaHoaDon = ct.MaHoaDon " +
                               "WHERE kh.MaKhachHang = @MaKhachHang " +
                               "GROUP BY hd.MaHoaDon, hd.NgayLap, kh.TenKhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@MaKhachHang", cboKhachHang.SelectedValue);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvHoaDon.DataSource = dataTable;
            }
        }
        private void LoadKhachHangComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MaKhachHang, TenKhachHang FROM KhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cboKhachHang.DataSource = dataTable;
                cboKhachHang.DisplayMember = "TenKhachHang";
                cboKhachHang.ValueMember = "MaKhachHang";
            }
        }

        private void LoadSachComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MaSach, TenSach FROM Sach";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cboSach.DataSource = dataTable;
                cboSach.DisplayMember = "TenSach";
                cboSach.ValueMember = "MaSach";
            }
        }

    }
}
