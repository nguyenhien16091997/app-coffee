using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayers;
using System.Data;

namespace appCoffee
{
    
    public partial class ThongTinCaNhan : Form
    {
        NguoiDungBLL ndbll = new NguoiDungBLL();
        public ThongTinCaNhan()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            DataSet ds = new DataSet();
            ds = ndbll.GetRowFromTaiKhoan(Login.taiKhoanForm);
            txtTaiKhoan.Text = ds.Tables[0].Rows[0]["taiKhoan"].ToString();
            txtHoTen.Text = ds.Tables[0].Rows[0]["hoTen"].ToString();
            txtNoiO.Text = ds.Tables[0].Rows[0]["noiO"].ToString();
            txtDienThoai.Text = ds.Tables[0].Rows[0]["dienThoai"].ToString();
            txtDanToc.Text = ds.Tables[0].Rows[0]["danToc"].ToString();
            txtPassword.Text = ds.Tables[0].Rows[0]["matKhau"].ToString();
            tbGioiTinh.Text = ds.Tables[0].Rows[0]["gioiTinh"].ToString();
            txtChucVu.Text = ds.Tables[0].Rows[0]["chucVuID"].ToString();
            dtpNgaySinh.Text = ds.Tables[0].Rows[0]["ngaySinh"].ToString();
            dtpNgayVaoLam.Text = ds.Tables[0].Rows[0]["ngayBatDau"].ToString();
            txtSoGioLamThangNay.Text = ds.Tables[0].Rows[0]["ngayBatDau"].ToString();
           // txtTongLuong.Text = ds.Tables[0].Rows[0]["ngayBatDau"].ToString();
            txtLuongGio.Text = ds.Tables[0].Rows[0]["luongGioHT"].ToString();
           
        }
    }
}
