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
    public partial class frm_TinhTien : Form
    {
        KhachHangBLL khbll = new KhachHangBLL();
        HoaDonKhachHangBLL hdkhbll = new HoaDonKhachHangBLL();
        public frm_TinhTien()
        {
            InitializeComponent();
            LoadData();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (txtTienKhachDua.Text == "")
            {
                MessageBox.Show("Hãy nhập số tiền !!!");
            }
            else
            {
                if (txtSDT.Text != "")
                {
                     if (!hdkhbll.UpdateHoaDonKhachHang(Convert.ToInt32(Admin.hoaDonIDForm), Admin.theBanIDForm, Admin.taiKhoanForm, Convert.ToInt64(txtSDT.Text), Convert.ToInt64(lbTongTien.Text)))
                                    {
                                        MessageBox.Show("Sảy ra lỗi vui lòng liên hệ !!!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Đã thanh toán !!! cảm ơn quý khách");
                                        this.Close();
                                    }
                }
                else
                {
                    if (!hdkhbll.UpdateHoaDonKhachHang(Convert.ToInt32(Admin.hoaDonIDForm), Admin.theBanIDForm, Admin.taiKhoanForm, Convert.ToInt64(txtSDT.Text), 0))
                    {
                        MessageBox.Show("Sảy ra lỗi vui lòng liên hệ !!!");
                    }
                    else
                    {
                        MessageBox.Show("Đã thanh toán !!! cảm ơn quý khách");
                        this.Close();
                    }
                }


            }

        }
        public void LoadData()
        {
            DataSet ds = new DataSet();
            
            ds = hdkhbll.getRowFromHoaDonID(Convert.ToInt32(Admin.hoaDonIDForm));
            lbGiaTam.Text = ds.Tables[0].Rows[0]["tongTien"].ToString();           
            
            txtGiamGia.Text = ds.Tables[0].Rows[0]["giamGia"].ToString();
            txtPhiPhuThu.Text = ds.Tables[0].Rows[0]["phiPhuThu"].ToString();
           
        }
        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (lbGiaTam.Text != "" && txtGiamGia.Text != "" && txtPhiPhuThu.Text != "")
            {
                lbTongTien.Text = (Convert.ToInt32(lbGiaTam.Text) - ((Convert.ToInt32(lbGiaTam.Text) * Convert.ToInt32(txtGiamGia.Text)) / 100) + Convert.ToInt32(txtPhiPhuThu.Text)).ToString();
                hdkhbll.UpdateGiamGia(Convert.ToInt32(Admin.hoaDonIDForm), Convert.ToInt32(txtGiamGia.Text));
            }
            else if (lbGiaTam.Text != "" && txtGiamGia.Text == "" && txtPhiPhuThu.Text != "")
            {
                lbTongTien.Text = (Convert.ToInt32(lbGiaTam.Text) + Convert.ToInt32(txtPhiPhuThu.Text)).ToString();

                hdkhbll.UpdateGiamGia(Convert.ToInt32(Admin.hoaDonIDForm), 0);
            }
        }

        private void txtPhiPhuThu_TextChanged(object sender, EventArgs e)
        {
            if (lbGiaTam.Text != "" && txtGiamGia.Text != "" && txtPhiPhuThu.Text != "")
            {
                lbTongTien.Text = (Convert.ToInt32(lbGiaTam.Text) - ((Convert.ToInt32(lbGiaTam.Text) * Convert.ToInt32(txtGiamGia.Text)) / 100) + Convert.ToInt32(txtPhiPhuThu.Text)).ToString();
                hdkhbll.UpdatePhiPhuThu(Convert.ToInt32(Admin.hoaDonIDForm), Convert.ToInt32(txtPhiPhuThu.Text));
            }
            else if (lbGiaTam.Text != "" && txtGiamGia.Text != "" && txtPhiPhuThu.Text == "")
            {
                lbTongTien.Text = (Convert.ToInt32(lbGiaTam.Text) - ((Convert.ToInt32(lbGiaTam.Text) * Convert.ToInt32(txtGiamGia.Text)) / 100)).ToString();
                hdkhbll.UpdatePhiPhuThu(Convert.ToInt32(Admin.hoaDonIDForm), 0);
            }
        }

        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {               
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if(Convert.ToInt32((sender as TextBox).Text.Length) > 15)
            {
                e.Handled = true;
            }
            
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (lbTongTien.Text!="" && txtTienKhachDua.Text!="")
            {
                lbTienDu.Text = (Convert.ToInt32(txtTienKhachDua.Text) - Convert.ToInt32(lbTongTien.Text)).ToString();
                
            }
        }

        private void lbTongTien_TextChanged(object sender, EventArgs e)
        {
            if (lbTongTien.Text != "" && txtTienKhachDua.Text != "")
            {
                lbTienDu.Text = (Convert.ToInt32(txtTienKhachDua.Text) - Convert.ToInt32(lbTongTien.Text)).ToString();

            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text != "")
            {
                if (khbll.CheckExists(Convert.ToInt64(txtSDT.Text)))
                {
                    lbTichLuy.Text = (khbll.GetTichLuy(Convert.ToInt64(txtSDT.Text))).ToString();
                    label5.Text = "welcome";
                }
                else
                {
                    label5.Text = "KH lần đầu tiên ";
                    lbTichLuy.Text = "0";
                }
            }

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
               
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Convert.ToInt32((sender as TextBox).Text.Length) > 15)
            {
                e.Handled = true;
            }
        }
    }
}
