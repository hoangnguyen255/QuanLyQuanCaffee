using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaffee
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void Sanpham_Load(object sender, EventArgs e)
        {
            btnAmericano.Enabled = false;
        }

        private void btnCupcake_Click(object sender, EventArgs e)
        {
            btnCupcake.Text = "39000";
        }

        private void btnEspresso_Click(object sender, EventArgs e)
        {

        }

        private void btnMocha_Click(object sender, EventArgs e)
        {

        }

        private void btnAmericano_Click(object sender, EventArgs e)
        {

        }

        private void btnFlan_Click(object sender, EventArgs e)
        {

        }

        private void btnGoiMon_Click(object sender, EventArgs e)
        {
            btnAmericano.Enabled = true;

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
    