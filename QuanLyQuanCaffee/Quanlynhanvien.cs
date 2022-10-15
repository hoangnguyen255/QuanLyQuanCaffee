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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyQuanCaffee
{
    public partial class frmQuanlynhanvien : Form
    {
        SqlConnection con;
        public frmQuanlynhanvien()
        {
            InitializeComponent();
        }

        private void Quanlynhanvien_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            btnLuu.Enabled = false;
            if (ketnoi("DESKTOP-M0KCUVC\\BVSONXNB", "QuanLyQuanCaffee") == true)
            {
                laydulieu_len_listview();
                NapBangCapVaoComboBox();
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
                MessageBox.Show("Loi cap nhat CSDL");
                return false;
            }
        }

        void laydulieu_len_listview()
        {
            string s = "Select * from NHANVIEN n, CHUCVU b where n.MaChucVu= b.MaChucVu";
            DataTable dt = new DataTable();
            dt = truyvan(s);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = listView1.Items.Add(dt.Rows[i]["MaNhanVien"].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i]["TenChucVu"].ToString());
            }
        }
        void NapBangCapVaoComboBox()
        {
            string s = "Select TenChucVu from ChucVu";
            DataTable dt = new DataTable();
            dt = truyvan(s);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbbChucVu.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        void xoa()
        {
            txtMaNV.Clear();
            txtHoten.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtDiachi.Clear();
            txtSodienthoai.Clear();
            cbbChucVu.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        //ham xoa het noi dung textbox
        void reset()
        {
            txtDiachi.Text = txtSodienthoai.Text = txtHoten.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            //comboBox1.SelectedIndex = ;
        }
        //kiem tra xem nguoi dung da nhap du thong tin
        //bool kiemtra()
        //{
        //   if (txtDiaChi.Text == "" || txtDienThoai.Text == "" || txtHoten.Text = "")
        //   {
        //       return true;
        //   }
        //   return false;
        //}



        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            reset();
            groupBox1.Enabled = false;
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txtMaNV.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txtHoten.Text = listView1.SelectedItems[0].SubItems[1].Text;
                dtpNgaySinh.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txtDiachi.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txtSodienthoai.Text = listView1.SelectedItems[0].SubItems[4].Text;
                cbbChucVu.SelectedIndex = cbbChucVu.FindString(listView1.SelectedItems[0].SubItems[5].Text);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            xoa();
            groupBox1.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            //btnHuy.Enabled = true;          
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (ketnoi("DESKTOP-M0KCUVC\\BVSONXNB", "QuanLyQuanCaffee") == false)
            {
                MessageBox.Show("Nhan OK de thoat", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            //string mnv = txtMaNV.Text;
            string ht = txtHoten.Text;
            string ns = dtpNgaySinh.Value.ToShortDateString();
            string dc = txtDiachi.Text;
            string sdt = txtSodienthoai.Text;
            string bc = (cbbChucVu.SelectedIndex + 1).ToString();
            string s = "insert into NHANVIEN values(N'" + ht + "','" + ns + "',N'" + dc + "','" + sdt + "','" + bc + "')";
            if (themxoasua(s) == true)
            {
                listView1.Items.Clear();
                laydulieu_len_listview();
            }
            reset();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hay chon mot dong de xoa");
                return;
            }
            if (ketnoi("DESKTOP-M0KCUVC\\BVSONXNB", "QuanLyQuanCaffee") == false)
            {
                MessageBox.Show("Nhan OK de thoat", "Ket noi khong thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            foreach (ListViewItem i in listView1.SelectedItems)
            {
                string s = "delete from NHANVIEN where MaNhanVien = N'" + i.SubItems[0].Text + "'";
                //Console.WriteLine(s);
                SqlCommand cmd = new SqlCommand(s, con);
                themxoasua(s);
            }
            con.Close();
            listView1.Items.Clear();
            laydulieu_len_listview();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            txtMaNV.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = true;
            btnLuu.Enabled = true;
            //btnHuy.Enabled = true;
            if (ketnoi("DESKTOP-M0KCUVC\\BVSONXNB", "QuanLyQuanCaffee") == false)
            {
                MessageBox.Show(" Nhấn OK để thoát chương trình ", " không kết nối CSDL được ! ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show(" Chưa chọn dòng dữ liệu cần cập nhật ");
                return;
            }
            string ht = txtHoten.Text;
            string ns = dtpNgaySinh.Value.ToShortDateString();
            string dc = txtDiachi.Text;
            string sdt = txtSodienthoai.Text;
            string bc = (cbbChucVu.SelectedIndex + 1).ToString();
            string s = "update NHANVIEN set Hotennhanvien = N'" + ht + "',ngaysinh ='" + ns + "',Diachi=N'" + dc + "',Dienthoai= '" + sdt + "',MaBangCap ='" + bc + "'where manhanvien = N'" + txtMaNV.Text + "'";
            //Console.WriteLine(s ) ;
            if (themxoasua(s) == true)
            {
                con.Close();
                listView1.Items.Clear();
                laydulieu_len_listview();
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Ban co muon thoat khong?", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void frmQuanlynhanvien_Load(object sender, EventArgs e)
        {

        }
    }
}
