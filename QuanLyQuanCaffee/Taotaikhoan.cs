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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyQuanCaffee
{
    public partial class frmTaoTaiKhoan : Form
    {
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }
        //
        SqlConnection con;
        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == false)
            {
                MessageBox.Show("Nhấn OK để thoát", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (txtID.Text == "" && txtMatkhau.Text == "" && txtTendangnhap.Text == "" && txtTennguoidung.Text == "")
            {
                MessageBox.Show("Mời nhập đầy đủ giá trị!", "Thông báo");
            }
            if(txtID.Text == 1.ToString() || txtID.Text == 2.ToString())
            {
         
                string id = txtID.Text;
                string tnd = txtTennguoidung.Text;
                string tdn = txtTendangnhap.Text;
                string mk = txtMatkhau.Text;
                string s = "insert into tbl_user values('" + id + "',N'" + tnd + "',N'" + tdn + "','" + mk + "')";
                if (themxoasua(s) == true)
                {
                    MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                reset();
            }
            else { 
            MessageBox.Show("ID chỉ được nhập 1 hoặc 2!", "Thông báo");
        }
            
           
        }

        void reset()
        {
            txtID.Text = txtMatkhau.Text = txtTendangnhap.Text= txtTennguoidung.Text = "";
            
            //comboBox1.SelectedIndex = ;
        }
        //Sự kiện click nút thoát để ẩn đi form đăng kí tài khoản
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        bool themxoasua(string s)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Tên đăng nhập đa tồn tại!");
                return false;
            }
        }
        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                //laydulieu_len_listview();
                //NapBangCapVaoComboBox();
            }
            else
            {
                MessageBox.Show("Nhan OK de thoat", "Ket noi khong thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
        }
        public bool ketnoi(String server, String database)// ktra ket noi thanh cong hay ko?
        {
            try//ket noi duoc
            {
                string s = "Data source=" + server + ";database=" + database + ";Integrated Security = true";
                con = new SqlConnection(s);
                con.Open();
                return true;
            }
            catch (Exception e)//ko ket noi duoc
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //thong bao loi chi tiet
                MessageBox.Show(e.Message);
                return false;
            }
        }
        DataTable truyvan(String s)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter(s, con);// thuc hien cau truy van qua sqldataadapter 
                                                //dataset ds = new dataset();
                da.Fill(ds, "KQ");// do vao ds
                con.Close();
                return ds.Tables["KQ"];
            }
            catch
            {
                MessageBox.Show("Loi truy van CSDL");
                return new DataTable();// new truy van khong duoc tra ve 1 bang rong
            }
        }
    }
}
