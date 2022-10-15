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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QuanLyQuanCaffee
{
    public partial class QuanLyNguyenLieu : Form
    {
        SqlConnection con;
        
        public QuanLyNguyenLieu()
        {
            InitializeComponent();
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            if (ketnoi("DESKTOP-M0KCUVC\\BVSONXNB", "QuanLyQuanCaffee") == true)
            {
                laydulieu_len_DataGridView();
                NapMaHangVaoComboBox();
            }
            else
            {
                MessageBox.Show("Nhan OK de thoat", "Ket noi khong thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
            btnXoa.Enabled = false;
            btnSua.Enabled = false;          
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
        void laydulieu_len_DataGridView()
        {
            dataGridView1.Rows.Clear();
            string s = "Select * from SanPham";
            DataTable dt = new DataTable();
            dt = truyvan(s);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = dt.Rows[i][0].ToString();
                dataGridView1.Rows[index].Cells[1].Value = dt.Rows[i][1].ToString();
                dataGridView1.Rows[index].Cells[2].Value = dt.Rows[i][2].ToString();
                dataGridView1.Rows[index].Cells[3].Value = dt.Rows[i][3].ToString();
                dataGridView1.Rows[index].Cells[4].Value = dt.Rows[i][4].ToString();


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
        void NapMaHangVaoComboBox()
        {
            string s = "Select MaHang from SanPham";
            DataTable dt = new DataTable();
            dt = truyvan(s);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbMaHang.Items.Add(dt.Rows[i][0].ToString());
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
        void xoa()
        {
            txtGiaTien.Clear();
            txtTenHang.Clear();
            txtNhaCungCap.Clear();
            txtSoluong.Clear();
            cmbMaHang.Text = "";
        }
        public bool checkRong()
        {
            if(txtGiaTien.Text == "" || txtTenHang.Text == "" || txtNhaCungCap.Text == "" 
              || txtSoluong.Text == "" || txtGia.Text == "" || cmbMaHang.Text == "")
            {
                return true;
            }
            return false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkRong())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (ketnoi("DESKTOP-M0KCUVC\\BVSONXNB", "QuanLyQuanCaffee") == false)
                {
                    MessageBox.Show("Nhan OK de thoat", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                if (int.Parse(txtGiaTien.Text) < 0)
                {
                    MessageBox.Show("Vui lòng nhập lại giá tiền(không âm)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                if (int.Parse(txtSoluong.Text) < 0)
                {
                    MessageBox.Show("Vui lòng nhập lại số lượng(không âm)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string th = txtTenHang.Text;
                    string gt = txtGiaTien.Text;
                    string ncc = txtNhaCungCap.Text;
                    string mh = cmbMaHang.Text;
                    string slt = int.Parse(txtSoluong.Text).ToString();
                    string s = "insert into SanPham values(N'" + mh + "',N'" + th + "',N'" + ncc + "','" + gt + "','" + slt + "')";
                    if (themxoasua(s) == true)
                    {
                        dataGridView1.Rows.Clear();
                        laydulieu_len_DataGridView();
                    }
                    xoa();
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }              
                }
                
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                cmbMaHang.Text = row.Cells[0].Value.ToString();
                txtTenHang.Text = row.Cells[1].Value.ToString();
                txtNhaCungCap.Text = row.Cells[2].Value.ToString();
                txtGiaTien.Text = row.Cells[3].Value.ToString();
                txtSoluong.Text = row.Cells[4].Value.ToString();    
            }
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            
            if (ketnoi("DESKTOP-M0KCUVC\\BVSONXNB", "QuanLyQuanCaffee") == false)
            {
                MessageBox.Show("Nhan OK de thoat", "Ket noi khong thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() == cmbMaHang.Text)
                {
                    string mh = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string s = "delete from SanPham where MaHang = N'" + mh + "'";
                    //Console.WriteLine(s);
                    if (themxoasua(s) == true)
                    {
                        con.Close();
                        dataGridView1.Rows.Clear();
                        laydulieu_len_DataGridView();
                    }
                }               
            }
            xoa();


        }
        

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkRong())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ketnoi("DESKTOP-M0KCUVC\\BVSONXNB", "QuanLyQuanCaffee") == false)
                {
                    MessageBox.Show(" Nhấn OK để thoát chương trình ", " không kết nối CSDL được ! ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                if (int.Parse(txtGiaTien.Text) < 0)
                {
                    MessageBox.Show("Vui lòng nhập lại giá tiền(không âm)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (int.Parse(txtSoluong.Text) < 0)
                    {
                        MessageBox.Show("Vui lòng nhập lại số lượng(không âm)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (dataGridView1.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(" Chưa chọn dòng dữ liệu cần cập nhật ");
                            return;
                        }
                        string th = txtTenHang.Text;
                        string ncc = txtNhaCungCap.Text;
                        string gia = int.Parse(txtGiaTien.Text).ToString();
                        string slt = int.Parse(txtSoluong.Text).ToString();
                        string s = "update SanPham set TenHang = N'" + th + "',NhaCungCap ='" + ncc + "',Gia ='" + gia + "',SoLuongTon ='" + slt + "'where MaHang = N'" + cmbMaHang.Text + "'";
                        //Console.WriteLine(s ) ;
                        if (themxoasua(s) == true)
                        {
                            con.Close();
                            dataGridView1.Rows.Clear();
                            laydulieu_len_DataGridView();
                        }
                    }
                }

            }
            
            

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (ketnoi("DESKTOP-M0KCUVC\\BVSONXNB", "QuanLyQuanCaffee") == false)
            {
                MessageBox.Show(" Nhấn OK để thoát chương trình ", " không kết nối CSDL được ! ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string tk = txtTimKiem.Text;    
            string s = "select * from SanPham ";
            s += "where TenHang like N'%" + tk + "%'";
            s += "OR NhaCungCap like N'%" + tk + "%'";
            s += "OR Gia like N'%" + tk + "%'";
            s += "OR MaHang like N'%" + tk + "%'";
            s += "OR SoLuongTon like N'%" + tk + "%'"; 

            if (themxoasua(s) == true)
            {
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                dt = truyvan(s);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridView1.Rows[index].Cells[1].Value = dt.Rows[i][1].ToString();
                    dataGridView1.Rows[index].Cells[2].Value = dt.Rows[i][2].ToString();
                    dataGridView1.Rows[index].Cells[3].Value = dt.Rows[i][3].ToString();
                    dataGridView1.Rows[index].Cells[4].Value = dt.Rows[i][4].ToString();

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void cmbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
//GO
//CREATE TABLE [dbo].[SanPham] (

//    [MaHang][nchar](20) NOT NULL,

//    [TenHang] [nvarchar] (250) NULL,
//	[NhaCungCap][nvarchar] (500) NULL,
//	[Gia][int] NULL,
// CONSTRAINT[PK_SanPham] PRIMARY KEY CLUSTERED 
//(

//    [MaHang] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
//INSERT[dbo].[SanPham] ([MaHang], [TenHang], [NhaCungCap], [Gia]) VALUES(N'Ma01                ', N'Cà phê', N'Trung Nguyên coffee', 3000000)
//INSERT[dbo].[SanPham]([MaHang], [TenHang], [NhaCungCap], [Gia]) VALUES(N'Ma02                ', N'Bánh ngọt', N'Tiệm bánh thập cẩm ', 1000000)
//INSERT[dbo].[SanPham]([MaHang], [TenHang], [NhaCungCap], [Gia]) VALUES(N'Ma03                ', N'Hộp trà các loại', N'Trà thái nguyên', 2000000)
//GO

