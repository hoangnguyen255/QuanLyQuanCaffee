using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;
using ZXing;
using System.Drawing.Drawing2D;

namespace QuanLyQuanCaffee
{

    public partial class frmSanPham : Form
    {
        SqlConnection con;
        public frmSanPham()
        {
            InitializeComponent();
        }
        private void enableFalse()
        {
            btnAmericano.Enabled = false;
            btnBacxiu.Enabled = false;
            btnCaphedenda.Enabled = false;
            btnCaphephin.Enabled = false;
            btnCaphesuanong.Enabled = false;
            btnCaphesuada.Enabled = false;
            btnCaphetrung.Enabled = false;
            btnCapuccino.Enabled = false;
            btnChocolateTarts.Enabled = false;
            btnCookies.Enabled = false;
            btnCupcake.Enabled = false;
            btnDonut.Enabled = false;
            btnEspresso.Enabled = false;
            btnFlan.Enabled = false;
            btnMaracon.Enabled = false;
            btnMocha.Enabled = false;
            btnMoussecake.Enabled = false;
            btnMuffin.Enabled = false;
            btnSuachuanepcam.Enabled = false;
            btnSuachuaphucbontu.Enabled = false;
            btnTiramisu.Enabled = false;
            btnTradaocamsa.Enabled = false;
            btnTravai.Enabled = false;
            btnCroissant.Enabled = false;

        }
        private void enableTrue()
        {
            btnAmericano.Enabled = true;
            btnBacxiu.Enabled = true;
            btnCaphedenda.Enabled = true;
            btnCaphephin.Enabled = true;
            btnCaphesuanong.Enabled = true;
            btnCaphesuada.Enabled = true;
            btnCaphetrung.Enabled = true;
            btnCapuccino.Enabled = true;
            btnChocolateTarts.Enabled = true;
            btnCookies.Enabled = true;
            btnCupcake.Enabled = true;
            btnDonut.Enabled = true;
            btnEspresso.Enabled = true;
            btnFlan.Enabled = true;
            btnMaracon.Enabled = true;
            btnMocha.Enabled = true;
            btnMoussecake.Enabled = true;
            btnMuffin.Enabled = true;
            btnSuachuanepcam.Enabled = true;
            btnSuachuaphucbontu.Enabled = true;
            btnTiramisu.Enabled = true;
            btnTradaocamsa.Enabled = true;
            btnTravai.Enabled = true;
            btnCroissant.Enabled = true;

        }

        private void Sanpham_Load(object sender, EventArgs e)
        {
            enableFalse();
            txtSoLuong.Text = 1.ToString();
            txtTongTien.Text = 0.ToString();
            groupBox1.Enabled = false;
           
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
        public Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
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

        private void btnCupcake_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenBakery,GiaTien from MenuBakery where MaBakery='MaCupcake'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnEspresso_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaEspresso'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text=dt.Rows[0][0].ToString();
                txtGiaTien.Text=dt.Rows[0][1].ToString();

            }

        }

        private void btnMocha_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;

            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaMocha'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnAmericano_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;

            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaAmericano'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnFlan_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenBakery,GiaTien from MenuBakery where MaBakery='MaFlan'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnGoiMon_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            groupBox1.Enabled = true;
            enableTrue();
            dgvHoaDon.Rows.Clear();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTinhTien.Enabled = false;

            txtTongTien.Text = 0.ToString();
        }

        private void btnCapuccino_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaCapuccino'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnCaphedenda_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaCaphedenda'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnCaphesuada_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaCaphesuada'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnCaphesuanong_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaCaphesuanong'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnCaphephin_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaCaphephin'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnBacxiu_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaBacXiu'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnCaphetrung_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaCaphetrung'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnSuachuanepcam_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaSuachuanepcam'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnSuachuaphucbontu_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaSuachuaphucbontu'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnTradaocamsa_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaTradaocamsa'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnTravai_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenDrinks,GiaTien from MenuDrinks where MaDrinks='MaTravai'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnTiramisu_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenBakery,GiaTien from MenuBakery where MaBakery='MaTiramisu'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnMaracon_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenBakery,GiaTien from MenuBakery where MaBakery='MaMaracon'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnMoussecake_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenBakery,GiaTien from MenuBakery where MaBakery='MaMoussecake'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnMuffin_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenBakery,GiaTien from MenuBakery where MaBakery='MaMuffin'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnChocolateTarts_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenBakery,GiaTien from MenuBakery where MaBakery='MaChocolateTarts'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnCookies_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenBakery,GiaTien from MenuBakery where MaBakery='MaCookies'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnDonut_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenBakery,GiaTien from MenuBakery where MaBakery='MaDonut'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void btnCroissant_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCong.Enabled = true;
            txtSoLuong.Enabled = true;
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == true)
            {
                string s = "select TenBakery,GiaTien from MenuBakery where MaBakery='MaCroissant'";
                DataTable dt = new DataTable();
                dt = truyvan(s);
                txtTenSanPham.Text = dt.Rows[0][0].ToString();
                txtGiaTien.Text = dt.Rows[0][1].ToString();

            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            txtSoLuong.Text = (int.Parse(txtSoLuong.Text) + 1).ToString();

        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            txtSoLuong.Text = (int.Parse(txtSoLuong.Text) - 1).ToString();

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == 1.ToString())
            {
                btnTru.Enabled = false;
            }
            else
            {
                btnTru.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int index = dgvHoaDon.Rows.Add();

            dgvHoaDon.Rows[index].Cells[0].Value = txtTenSanPham.Text;
            dgvHoaDon.Rows[index].Cells[1].Value = txtGiaTien.Text;
            dgvHoaDon.Rows[index].Cells[2].Value = txtSoLuong.Text;
            dgvHoaDon.Rows[index].Cells[3].Value = (int.Parse(txtSoLuong.Text) * int.Parse(txtGiaTien.Text));
            txtTongTien.Text = 0.ToString();
            btnXoa.Enabled = true;
            btnTinhTien.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            //Tính tổng tiền
            for (int i = 0; i < dgvHoaDon.Rows.Count-1 ; i++)
            {               
                txtTongTien.Text = (int.Parse(txtTongTien.Text) +int.Parse(dgvHoaDon.Rows[i].Cells[3].Value.ToString())).ToString();
            }
            //Tạo MÃ QR MoMo
            var qrcode_text = $"2|99|{"0946786967"}|||0|0|{txtTongTien.Text.Trim()}";//gán dữ liệu cho biến string qrcode_text

            BarcodeWriter barcodeWriter = new BarcodeWriter();//khởi tao 1 biến viết mã 
            EncodingOptions encodingOptions = new EncodingOptions() { Width = 200, Height = 200, Margin = 0, PureBarcode = false };//khơi tạo 1 mã có dài và rộng là 200
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();//khởi tạo kết xuất mã được kết xuất bằng bitmap
            barcodeWriter.Options = encodingOptions;//khởi tạo tùy chọn mã hóa
            barcodeWriter.Format = BarcodeFormat.QR_CODE;//khởi tạp format mã hóa là 1 mã qr
            Bitmap bitmap = barcodeWriter.Write(qrcode_text);//khởi tạo 1 biến bitmap có chứa dữ liệu của qrcode_text;
            Bitmap logo = resizeImage(Properties.Resources.logo_momo, 64, 64) as Bitmap;//gán cái logo của mogo có được truyền vào khu vưc có dài và rộng =64
            Graphics g = Graphics.FromImage(bitmap);//khởi tạo 1 đồ họa g là 1 from image có dữ liệu của bitmap
            g.DrawImage(logo, new Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));//vẽ các điểm 
            picQRPay.Image = bitmap;

            //Lưu Hoá đơn vào SQL
            if (ketnoi("DESKTOP-K542EP2\\NNH", "QuanLyQuanCaffee") == false)
            {
                MessageBox.Show("Nhan OK de thoat", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            DateTime ngay = DateTime.Now;
            string tt = int.Parse(txtTongTien.Text).ToString();
            string s = "insert into HOADON values(N'" + ngay + "',N'" + tt + "')";
            themxoasua(s);
            enableFalse();
            btnTinhTien.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {


            try
            {
                txtTenSanPham.Enabled = true;
                int selectedRow = GetSelectedRow(txtTenSanPham.Text);
                dgvHoaDon.Rows.RemoveAt(selectedRow);
            }
            catch(Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
        }

        private int GetSelectedRow(string text)
        {

            for(int i = 0; i < dgvHoaDon.Rows.Count ;i++)
            {
                if (dgvHoaDon.Rows[i].Cells[0].Value.ToString()==text)
                {
                    return i;
                }
            }
            return - 1;
        }  
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenSanPham.Enabled = true;

            int i = e.RowIndex;
            txtTenSanPham.Text = dgvHoaDon.Rows[i].Cells[0].Value.ToString();
            txtGiaTien.Text = dgvHoaDon.Rows[i].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvHoaDon.Rows[i].Cells[2].Value.ToString();
            txtTenSanPham.Enabled=false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int selectedRow = GetSelectedRow(txtTenSanPham.Text);
           
            dgvHoaDon.Rows[selectedRow].Cells[1].Value = txtGiaTien.Text;
            dgvHoaDon.Rows[selectedRow].Cells[2].Value = txtSoLuong.Text;
            dgvHoaDon.Rows[selectedRow].Cells[3].Value = (int.Parse(txtSoLuong.Text) * int.Parse(txtGiaTien.Text));
            txtTongTien.Text = 0.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmCuaHang ch = new frmCuaHang();
            this.Hide();
            ch.ShowDialog();
        }

        private void picQRPay_Click(object sender, EventArgs e)
        {

        }
    }
    
}
//////////////////////////////////
// Code SQL bảng MenuDinks + MenuBakery
////////////////////////////////////
///*USE [master]
//GO
///****** Object:  Database [QuanLyQuanCaffee]    Script Date: 08/10/2022 12:15:03 SA ******/
//CREATE DATABASE[QuanLyQuanCaffee]
// CONTAINMENT = NONE
// ON  PRIMARY 
//( NAME = N'QuanLyQuanCaffee', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.BVSONXNB\MSSQL\DATA\QuanLyQuanCaffee.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
// LOG ON
//(NAME = N'QuanLyQuanCaffee_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.BVSONXNB\MSSQL\DATA\QuanLyQuanCaffee_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
// WITH CATALOG_COLLATION = DATABASE_DEFAULT
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET COMPATIBILITY_LEVEL = 150
//GO
//IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
//begin
//EXEC[QuanLyQuanCaffee].[dbo].[sp_fulltext_database] @action = 'enable'
//end
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET ANSI_NULL_DEFAULT OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET ANSI_NULLS OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET ANSI_PADDING OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET ANSI_WARNINGS OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET ARITHABORT OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET AUTO_CLOSE OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET AUTO_SHRINK OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET AUTO_UPDATE_STATISTICS ON 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET CURSOR_CLOSE_ON_COMMIT OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET CURSOR_DEFAULT  GLOBAL 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET CONCAT_NULL_YIELDS_NULL OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET NUMERIC_ROUNDABORT OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET QUOTED_IDENTIFIER OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET RECURSIVE_TRIGGERS OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET DISABLE_BROKER 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET DATE_CORRELATION_OPTIMIZATION OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET TRUSTWORTHY OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET ALLOW_SNAPSHOT_ISOLATION OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET PARAMETERIZATION SIMPLE 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET READ_COMMITTED_SNAPSHOT OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET HONOR_BROKER_PRIORITY OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET RECOVERY FULL 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET MULTI_USER 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET PAGE_VERIFY CHECKSUM  
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET DB_CHAINING OFF 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF)
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET TARGET_RECOVERY_TIME = 60 SECONDS 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET DELAYED_DURABILITY = DISABLED 
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET ACCELERATED_DATABASE_RECOVERY = OFF  
//GO
//EXEC sys.sp_db_vardecimal_storage_format N'QuanLyQuanCaffee', N'ON'
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET QUERY_STORE = OFF
//GO
//USE [QuanLyQuanCaffee]
//GO
///****** Object:  Table [dbo].[MenuBakery]    Script Date: 08/10/2022 12:15:04 SA ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[MenuBakery] (

//    [MaBakery][nchar](20) NOT NULL,

//    [TenBakery] [nvarchar] (100) NULL,
//	[GiaTien][int] NULL,
// CONSTRAINT[PK_MenuBakery] PRIMARY KEY CLUSTERED 
//(

//    [MaBakery] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[MenuDrinks]    Script Date: 08/10/2022 12:15:04 SA ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[MenuDrinks] (

//    [MaDrinks][nchar](20) NOT NULL,

//    [TenDrinks] [nvarchar] (100) NULL,
//	[GiaTien][int] NULL,
// CONSTRAINT[PK_MenuDrinks] PRIMARY KEY CLUSTERED 
//(

//    [MaDrinks] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
//INSERT[dbo].[MenuBakery] ([MaBakery], [TenBakery], [GiaTien]) VALUES(N'MaChocolateTarts    ', N'Chocolate tarts', 15000)
//INSERT[dbo].[MenuBakery]([MaBakery], [TenBakery], [GiaTien]) VALUES(N'MaCookies           ', N'Cookies', 9000)
//INSERT[dbo].[MenuBakery]([MaBakery], [TenBakery], [GiaTien]) VALUES(N'MaCroissant         ', N'Croissant', 19000)
//INSERT[dbo].[MenuBakery]([MaBakery], [TenBakery], [GiaTien]) VALUES(N'MaCupcake           ', N'Cupcake', 20000)
//INSERT[dbo].[MenuBakery]([MaBakery], [TenBakery], [GiaTien]) VALUES(N'MaDonut             ', N'Donut', 15000)
//INSERT[dbo].[MenuBakery]([MaBakery], [TenBakery], [GiaTien]) VALUES(N'MaFlan              ', N'Flan', 19000)
//INSERT[dbo].[MenuBakery]([MaBakery], [TenBakery], [GiaTien]) VALUES(N'MaMaracon           ', N'Maracon', 9000)
//INSERT[dbo].[MenuBakery]([MaBakery], [TenBakery], [GiaTien]) VALUES(N'MaMausseCake        ', N'Mausse cake', 39000)
//INSERT[dbo].[MenuBakery]([MaBakery], [TenBakery], [GiaTien]) VALUES(N'MaMuffin            ', N'Muffin', 20000)
//INSERT[dbo].[MenuBakery]([MaBakery], [TenBakery], [GiaTien]) VALUES(N'MaTiramisu          ', N'Tiramisu', 39000)
//GO
//INSERT[dbo].[MenuDrinks] ([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaAmericano         ', N'Americano', 39000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaBacXiu            ', N'Bạc xỉu', 29000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaCaPheDenDa        ', N'Cà phê đen đá', 25000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaCaPhePhin         ', N'Cà phê phin', 29000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaCaPheSuaDa        ', N'Cà phê sữa đá', 25000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaCaPheSuaNong      ', N'Cà phê sữa nóng', 25000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaCaPheTrung        ', N'Cà phê trứng', 29000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaCapuccino         ', N'Capuccino', 39000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaEspresso          ', N'Espresso', 39000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaMocha             ', N'Mocha', 39000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaSuaChuaNepCam     ', N'Sữa chua nếp cẩm', 29000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaSuaChuaPhucBonTu  ', N'Sữa chua phúc bồn tử', 29000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaTraDaoCamSa       ', N'Trà đào cam sả', 29000)
//INSERT[dbo].[MenuDrinks]([MaDrinks], [TenDrinks], [GiaTien]) VALUES(N'MaTraVai            ', N'Trà vải', 29000)
//GO
//USE[master]
//GO
//ALTER DATABASE [QuanLyQuanCaffee] SET READ_WRITE 
//GO
//USE [QuanLyQuanCaffee]
//GO
///****** Object:  Table [dbo].[HOADON]    Script Date: 10/16/2022 12:20:23 AM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE [dbo].[HOADON] (

//    [MaHD][int] IDENTITY(1, 1) NOT NULL,

//    [Ngay] [datetime] NULL,
//	[TongTien][int] NULL,
// CONSTRAINT[PK_testHD] PRIMARY KEY CLUSTERED 
//(

//    [MaHD] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO

