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
    public partial class QLNguyenLieu : Form
    {
        NguyeLieuBLL nlbbl = new NguyeLieuBLL();
        
        DataSet dsnl;
        
        public QLNguyenLieu()
        {

            InitializeComponent();
            LoadData();
        }

        private void QLNguyenLieu_Load(object sender, EventArgs e)
        {

        }

       

        private void btnChange1_Click(object sender, EventArgs e)
        {
            panelGrid.Size = new System.Drawing.Size(363, 377);
            btnChange1.Visible = false;
            btnChange2.Visible = true;
            
        }
        private void btnChange2_Click(object sender, EventArgs e)
        {
            panelGrid.Size = new System.Drawing.Size(600, 377);
            btnChange1.Visible = true;
            btnChange2.Visible = false;
        }
        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            if (dsnl != null)
            {
                dsnl.Clear();
                dsnl.Clear();
            }
            dsnl = nlbbl.LayDanhSachNguyenlieu();         

            datagridNguyenLieu.DataSource = dsnl.Tables[0];

            // binding 
            txtTaiKhoan.Enabled = false;
            XoaText();

            txtMaSP.DataBindings.Clear();
            txtTenSP.DataBindings.Clear();
            nuGia.DataBindings.Clear();
            nuSoLuong.DataBindings.Clear();
            cbDonVi.DataBindings.Clear();

            txtMaSP.DataBindings.Add("Text",dsnl.Tables[0], "nguyenLieuID");
            txtTenSP.DataBindings.Add("Text", dsnl.Tables[0], "tenNguyenLieu");
            nuGia.DataBindings.Add("Text", dsnl.Tables[0], "gia");
            nuSoLuong.DataBindings.Add("Text", dsnl.Tables[0], "soLuong");
            cbDonVi.DataBindings.Add("Text", dsnl.Tables[0], "donVi");


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void XoaText()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();            
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            XoaText();
            panelGrid.Enabled = false;
            btn_Huy.Enabled = true;
            btn_Xong.Enabled = true;
            btn_Insert.Enabled = false;
            btn_Update.Enabled = false;
        }

        private void btn_Xong_Click(object sender, EventArgs e)
        {
            String err = "";
            if (nlbbl.CheckLikeIDNguyenLieu(txtMaSP.Text.Trim()))
            {
                MessageBox.Show("Tài khoản đã có, Vui lòng nhập tài khoản có có nội dung khác !!!");
            }
            else
            {

                if (!nlbbl.InsertNguyenLieu(ref err, txtMaSP.Text,
                    txtTenSP.Text, 
                    Convert.ToInt32(Math.Round(nuSoLuong.Value)),
                    cbDonVi.Text, 
                    Convert.ToInt32(Math.Round(nuGia.Value))))
                {
                    MessageBox.Show("Cập nhật thất bại rồi !!!");
                }
                else
                {
                    XoaText();
                    MessageBox.Show("Cập nhật thành công !!!");
                }
            }
            LoadData();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            panelGrid.Enabled = true;         
            btn_Insert.Enabled = true;
            btn_Update.Enabled = true;
            btn_Xong.Enabled = false;
            btn_Huy.Enabled = false;
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string err = "";
            if(!nlbbl.DeleteNguyenLieu(ref err, txtMaSP.Text))
            {
                MessageBox.Show("Xóa thất bại rồi !!!");
            }
            else
            {
               
                MessageBox.Show("Thành công rồi :)");

            }
            LoadData();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            String err = "";
            if (!nlbbl.UpdateNguyenLieu(ref err, txtMaSP.Text,
                    txtTenSP.Text,
                    Convert.ToInt32(Math.Round(nuSoLuong.Value)),
                    cbDonVi.Text,
                    Convert.ToInt32(Math.Round(nuGia.Value))))
            {
                MessageBox.Show("Cập nhật thất bại !!!");
            }
            else
            {
                MessageBox.Show("Cập nhật thành công !!!");

            }
            LoadData();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cập nhật thành công !!!");
        }
    }
}
