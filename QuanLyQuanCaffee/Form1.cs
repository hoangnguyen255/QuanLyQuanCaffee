using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyQuanCaffee
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        //
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K542EP2\NNH;Initial Catalog=QuanLyQuanCaffee;Integrated Security=True");
        //Form đăng nhập hiện lên lúc bắt đầu
        private void Form1_Load(object sender, EventArgs e)
            {
            }
       
        public static string ID_USER = "";
        //Sự kiện khi nhấn vào nút đăng nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {           
            ID_USER = getID(txtTenDangNhap.Text, txtMatKhau.Text);
            if (ID_USER != "")
            {             
                frmCuaHang frm = new frmCuaHang();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản và mật khẩu không đúng !");
            }

        }

            //Sự kiện khi nhấn vào nút tạo tài khoản
            private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
            {
                //Hiện frm tạo tài khoản
                frmTaoTaiKhoan frm = new frmTaoTaiKhoan();
                frm.ShowDialog();
            }

            //Sự kiện khi nhấn vào nút đăng nhập không cần mật khẩu
            private void btnDangNhapKCMK_Click(object sender, EventArgs e)
            {
                //Hiện frm cửa hàng
                frmCuaHang frm = new frmCuaHang();
                this.Hide();
                frm.ShowDialog();

            }
        private string getID(string username, string pass)
        {
            string id = "";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_user WHERE user_name ='" + username + "' and pass='" + pass + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["id_user"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return id;

        }
        
    }
}
