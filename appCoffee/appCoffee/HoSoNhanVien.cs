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
namespace appCoffee
{
    public partial class HoSoNhanVien : Form
    {
        NguoiDungBLL nguoiDungBLL = new NguoiDungBLL();
        ChucVuBLL chucVuBLL = new ChucVuBLL();

        DataSet ds;
        DataSet dscv;
        
        public HoSoNhanVien()
        {

            InitializeComponent();
            ds = new DataSet();
            dscv = new DataSet();
            LoadData();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        public void LoadData()
        {
            if (ds != null)
            {
                ds.Clear();
                dscv.Clear();
            }
            dscv = chucVuBLL.getListChucVu();
            tbChucVu.DataSource = dscv.Tables[0];
            tbChucVu.DisplayMember = "tenChucVu";
            tbChucVu.ValueMember = "chucVuID";
            
            ds = nguoiDungBLL.ListUser();
            datagridNguyenLieu.DataSource = ds.Tables[0];

            // binding 
            txtTaiKhoan.Enabled = false;
            XoaText();

            txtTaiKhoan.DataBindings.Clear();
            txtHoTen.DataBindings.Clear();
            txtDanToc.DataBindings.Clear();
            txtDienThoai.DataBindings.Clear();
            txtNoiO.DataBindings.Clear();
            tbChucVu.DataBindings.Clear();
            tbGioiTinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Clear();
            dtpNgayVaoLam.DataBindings.Clear();
            txtPassword.DataBindings.Clear();
            nudLuongGio.DataBindings.Clear();

            txtTaiKhoan.DataBindings.Add("Text", ds.Tables[0], "taiKhoan");
            txtHoTen.DataBindings.Add("Text", ds.Tables[0], "hoTen");
            txtDanToc.DataBindings.Add("Text", ds.Tables[0], "danToc");
            txtDienThoai.DataBindings.Add("Text", ds.Tables[0], "dienThoai");
            txtNoiO.DataBindings.Add("Text", ds.Tables[0], "noiO");            
                     
            tbChucVu.DataBindings.Add("SelectedValue", ds.Tables[0], "chucVuID");
            tbGioiTinh.DataBindings.Add("Text", ds.Tables[0], "gioiTinh");
            dtpNgaySinh.DataBindings.Add("Text", ds.Tables[0], "ngaySinh");
            dtpNgayVaoLam.DataBindings.Add("Text", ds.Tables[0], "ngayBatDau");
            txtPassword.DataBindings.Add("Text", ds.Tables[0], "matKhau");
            nudLuongGio.DataBindings.Add("Text", ds.Tables[0], "luongGioHT");

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            panelGrid.Size = new System.Drawing.Size(880, 570);
            btnChange.Visible = false;
            btnHide.Visible = true;
        }       

        private void btnHide_Click(object sender, EventArgs e)
        {
            panelGrid.Size = new System.Drawing.Size(363, 570);
            btnChange.Visible = true;
            btnHide.Visible = false;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            String err= "nguoiDungBLL.DeleteNguoiDung(ref err,txtTaiKhoan.Text.Trim());";
            if(!nguoiDungBLL.DeleteNguoiDung(ref err, txtTaiKhoan.Text.Trim()))
            {
                MessageBox.Show(err);
            }
            else
            {
                MessageBox.Show("Xóa Thành công !!!");
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String err = "";
            if (!nguoiDungBLL.UpdateNguoiDung(ref err, txtTaiKhoan.Text.Trim(),
                txtPassword.Text.Trim(), txtHoTen.Text.Trim(), txtNoiO.Text.Trim()
                , txtDienThoai.Text.Trim(), tbGioiTinh.Text, tbChucVu.SelectedValue.ToString(), 
                txtDanToc.Text.Trim(),
                dtpNgaySinh.Value.ToString("yyyy/MM/dd"), dtpNgayVaoLam.Value.ToString("yyyy/MM/dd"),Convert.ToInt32(Math.Round(nudLuongGio.Value))))
            {
                MessageBox.Show("Cập nhật thất bại !!!");
            }
            else
            {
                MessageBox.Show("Cập nhật thành công !!!");
               
            }
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            panelGrid.Enabled = false;
            btnHuy.Enabled = true;
            btnXong.Enabled = true;
            btnThemMoi.Enabled = false;
            btnUpdate.Enabled = false;
            txtTaiKhoan.Enabled = true;

            txtTaiKhoan.Clear();
            txtHoTen.Clear();
            txtDanToc.Clear();
            txtDienThoai.Clear();
            txtNoiO.Clear();
            txtPassword.Clear();
            dtpNgayVaoLam.Value = DateTime.Now;
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelGrid.Enabled = true;
            btnChange.Enabled = true;
            btnThemMoi.Enabled = true;
            btnUpdate.Enabled = true;
            btnXong.Enabled = false;
            btnHuy.Enabled = false;
            LoadData();
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            String err = "";
           if(nguoiDungBLL.KiemTraTrungTaiKhoan(txtTaiKhoan.Text))
            {
                MessageBox.Show("Tài khoản đã có, Vui lòng nhập tài khoản có có nội dung khác !!!");
            }
            else
            {
                
                if (!nguoiDungBLL.ThemNguoiDung(ref err, txtTaiKhoan.Text,
                    txtPassword.Text, txtHoTen.Text, txtNoiO.Text, txtDienThoai.Text,
                    tbGioiTinh.Text, tbChucVu.SelectedValue.ToString(), txtDanToc.Text,
                     dtpNgaySinh.Value.ToString("yyyy/MM/dd"), dtpNgayVaoLam.Value.ToString("yyyy/MM/dd"), 
                     Convert.ToInt32(Math.Round(nudLuongGio.Value))))
                {
                    MessageBox.Show("Cập nhật thất bại rồi !!!");
                }
                else
                {
                    XoaText();
                    MessageBox.Show("Cập nhật thành công !!!");                   
                }
            }
        }
        private void XoaText()
        {            
            txtTaiKhoan.Clear();
            txtHoTen.Clear();
            txtDanToc.Clear();
            txtDienThoai.Clear();
            txtNoiO.Clear();
            txtPassword.Clear();
        }
    } 
}
