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
    public partial class dangnhap : Form
    {
        string connectionString = "Data Source=.;Initial Catalog=NhaSach;Integrated Security=True";

        public dangnhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Kiểm tra xem các ô nhập liệu có trống không
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kết nối tới cơ sở dữ liệu và kiểm tra thông tin đăng nhập
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM Users WHERE Username=@Username AND Password=@Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int result = (int)command.ExecuteScalar();

                    if (result == 1)
                    {
                        // Đăng nhập thành công
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HeThong mainForm = new HeThong();
                        mainForm.Show();
                        this.Hide(); // Ẩn form đăng nhập sau khi thành công
                    }
                    else
                    {
                        // Đăng nhập thất bại
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}
