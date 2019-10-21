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
using Bunifu.Framework.UI;

namespace appCoffee
{
   
    public partial class Admin : Form
    {

        public static string taiKhoanForm;
        public static string hoaDonIDForm;
        public static string theBanIDForm;

   
        TheBanBLL tbll = new TheBanBLL();
        TheLoaiBLL tlbll = new TheLoaiBLL();
        MonBLL mbll = new MonBLL();
        HoaDonKhachHangBLL hdkhbll = new HoaDonKhachHangBLL();
        ChiTietHoaDonKhachHangBLL cthdkhbll = new ChiTietHoaDonKhachHangBLL();
        bool bl = false;
        public Admin()
        {        
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            taiKhoanForm = Login.taiKhoanForm;
            LoadData();
        }     
        private void Menu_Click_1(object sender, EventArgs e)
        {
            if (bl == false)
            {
                pn_Menu.Location = new Point(0, 0);
                pn_Menu.Dock = DockStyle.Left;
                bl = true;
            }
            else
            {
                pn_Menu.Dock = DockStyle.None;
                pn_Menu.Location = new Point(-322, 0);
                bl = false;
            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            frm_TinhTien frm = new frm_TinhTien();
            frm.ShowDialog();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {
            

        }

        private void thucdonClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            QLThucDon qltd = new QLThucDon();
            qltd.ShowDialog();
        }

        private void TheBanClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            QLTheBan qLtb = new QLTheBan();
            qLtb.ShowDialog();
        }

        private void thethanhvienClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void HoSoNhanVienClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            HoSoNhanVien hsnv = new HoSoNhanVien();
            hsnv.ShowDialog();
        }

        private void it_BangLuongClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            QLBangLuong qlbl = new QLBangLuong();
            qlbl.ShowDialog();
        }

        private void NguyenLieuClick(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            QLNguyenLieu qlnl = new QLNguyenLieu();
            qlnl.ShowDialog();
        }
        private void LoadData()
        {
            pn_Menu.Dock = DockStyle.None;
            pn_Menu.Location = new Point(-322, 0);
            bl = false;

            panel2.Enabled = false;
            //button bàn
            sidePanel2.Enabled = false;
            LoadButtonTheBan();

            // button Nhom Mon an
            DataSet dsnma = new DataSet();
            dsnma = tlbll.getListTheLoai();
            foreach(DataRow j in dsnma.Tables[0].Rows)
            {

                BunifuThinButton2 btnNhomThucDon = new BunifuThinButton2();
                btnNhomThucDon.ActiveBorderThickness = 1;
                btnNhomThucDon.ActiveCornerRadius = 20;
                btnNhomThucDon.ActiveFillColor = System.Drawing.Color.White;
                btnNhomThucDon.ActiveForecolor = System.Drawing.Color.Sienna;
                btnNhomThucDon.ActiveLineColor = System.Drawing.Color.Transparent;
                btnNhomThucDon.BackColor = System.Drawing.Color.Gainsboro;
                btnNhomThucDon.ButtonText = j["tenTheLoai"].ToString();
                
                btnNhomThucDon.Cursor = System.Windows.Forms.Cursors.Hand;
                btnNhomThucDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnNhomThucDon.ForeColor = System.Drawing.Color.Sienna;
                btnNhomThucDon.IdleBorderThickness = 1;
                btnNhomThucDon.IdleCornerRadius = 20;
                btnNhomThucDon.IdleFillColor = System.Drawing.Color.Transparent;
                btnNhomThucDon.IdleForecolor = System.Drawing.Color.Sienna;
                btnNhomThucDon.IdleLineColor = System.Drawing.Color.Transparent;
                btnNhomThucDon.Location = new System.Drawing.Point(5, 5);
                btnNhomThucDon.Margin = new System.Windows.Forms.Padding(5);
                btnNhomThucDon.Name = "btnNhomThucDon";
                btnNhomThucDon.Size = new System.Drawing.Size(75, 36);
                btnNhomThucDon.TabIndex = 0;
                btnNhomThucDon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                btnNhomThucDon.Click += new EventHandler(btnTheLoai_click);

                flowLayoutPanel2.Controls.Add(btnNhomThucDon);
            }

        }
        public void LoadButtonTheBan()
        {
            flowLayoutPanel1.Controls.Clear();
            DataSet ds = tbll.getListTheBan();
            foreach (DataRow i in ds.Tables[0].Rows)
            {
                BunifuTileButton bunifuTileButton1 = new BunifuTileButton();
                bunifuTileButton1.BackColor = System.Drawing.Color.White;
                bunifuTileButton1.color = System.Drawing.Color.White;
                if (i["trangThai"].ToString().Equals("có người"))
                {
                    bunifuTileButton1.BackColor = System.Drawing.Color.Silver;
                    bunifuTileButton1.color = System.Drawing.Color.Silver;
                }
                if (lbTenBan.Text != null)
                {
                    if (i["theBanID"].ToString().Equals(lbTenBan.Text.ToString()))
                    {
                        bunifuTileButton1.BackColor = System.Drawing.Color.LightSteelBlue;
                        bunifuTileButton1.color = System.Drawing.Color.LightSteelBlue;
                    }
                }
                bunifuTileButton1.colorActive = System.Drawing.Color.LightGray;
                bunifuTileButton1.Cursor = System.Windows.Forms.Cursors.Hand;
                bunifuTileButton1.Font = new System.Drawing.Font("Sitka Heading", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bunifuTileButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
                bunifuTileButton1.Image = Image.FromFile(@"D:\Phân tích và thiết kế hệ thống thông tin\appCoffee\Pictures\png\hot-coffee.png");
                bunifuTileButton1.ImagePosition = 15;
                bunifuTileButton1.ImageZoom = 50;
                bunifuTileButton1.LabelPosition = 32;
                bunifuTileButton1.LabelText = i["theBanID"].ToString();
                bunifuTileButton1.Location = new System.Drawing.Point(7, 6);
                bunifuTileButton1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
                bunifuTileButton1.Name = "bunifuTileButton1";
                bunifuTileButton1.Size = new System.Drawing.Size(80, 92);
                bunifuTileButton1.TabIndex = 0;
                bunifuTileButton1.Click += new EventHandler(buttonTheBan_click);
                flowLayoutPanel1.Controls.Add(bunifuTileButton1);
            }
        }
        private void buttonTheBan_click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            sidePanel2.Enabled = true;
            BunifuTileButton btn= sender as BunifuTileButton;
            hdkhbll.InsertHoaDonKhachHang(btn.LabelText.ToString());

            DataSet ds = new DataSet();
            ds = hdkhbll.getRowFromTheBan(btn.LabelText.ToString());


            lbTenBan.Text = ds.Tables[0].Rows[0]["theBanID"].ToString();
            lbHoaDonID.Text = ds.Tables[0].Rows[0]["hoaDonID"].ToString();
            txtGiamGia.Text = ds.Tables[0].Rows[0]["giamGia"].ToString();
            txtPhiPhuThu.Text = ds.Tables[0].Rows[0]["phiPhuThu"].ToString();
            lbGiaTam.Text = ds.Tables[0].Rows[0]["tongTien"].ToString();

            LoadHoaDonKhachHang(Convert.ToInt32(lbHoaDonID.Text));
            LoadButtonTheBan();
            lbTongTien.Text = (Convert.ToInt32(lbGiaTam.Text) - (Convert.ToInt32(lbGiaTam.Text) * Convert.ToInt32(txtGiamGia.Text)) / 100 + Convert.ToInt32(txtPhiPhuThu.Text)).ToString();
        }
        private void UpdateLabelGiaTam(String theBanID)
        {
            DataSet ds = new DataSet();
            ds = hdkhbll.getRowFromTheBan(theBanID);
            lbGiaTam.Text = ds.Tables[0].Rows[0]["tongTien"].ToString();
        }
        private void btnTheLoai_click(object sender, EventArgs e)
        {
            flowLayoutPanel3.Controls.Clear();
            BunifuThinButton2 btn = sender as BunifuThinButton2;
            DataSet ds = new DataSet();
       
            ds = mbll.getListMonFromTheLoai(btn.ButtonText.ToString());
          

            foreach (DataRow k in ds.Tables[0].Rows)
            {
                BunifuTileButton btnMon = new BunifuTileButton();
                btnMon.BackColor = System.Drawing.Color.White;
                btnMon.color = System.Drawing.Color.White;
                btnMon.colorActive = System.Drawing.Color.LightGray;
                btnMon.Cursor = System.Windows.Forms.Cursors.Hand;
                btnMon.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnMon.ForeColor = System.Drawing.Color.Black;
                btnMon.Image = Image.FromFile(@"D:\Phân tích và thiết kế hệ thống thông tin\appCoffee\Pictures\png\002-hot-coffee-rounded-cup-on-a-plate-from-side-view.png");
                btnMon.ImagePosition = 16;
                btnMon.ImageZoom = 50;
                btnMon.LabelPosition = 33;
                btnMon.LabelText = k["tenMon"].ToString();
                btnMon.Location = new System.Drawing.Point(6, 5);
                btnMon.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
                btnMon.Name = k["monID"].ToString();
                btnMon.Size = new System.Drawing.Size(64, 84);
                btnMon.TabIndex = 1;
                flowLayoutPanel3.Controls.Add(btnMon);
                btnMon.Click += new EventHandler(btnMon_click);
            }            
        }
        private void btnMon_click(object sender, EventArgs e)
        {
           
            BunifuTileButton btnMon= sender as BunifuTileButton;
            cthdkhbll.InsertChiTietHoaDon(Convert.ToInt32(lbHoaDonID.Text), btnMon.Name.ToString(), lbTenBan.Text.ToString());
            LoadButtonTheBan();

            LoadHoaDonKhachHang(Convert.ToInt32(lbHoaDonID.Text));
            UpdateLabelGiaTam(lbTenBan.Text);
        }
        private void LoadHoaDonKhachHang(int hoaDonID)
        {
            flowLayoutPanel4.Controls.Clear();
            DataSet ds1 = new DataSet();
            ds1 = cthdkhbll.GetListChiTietHoaDonFromHoaDonID(hoaDonID);

            foreach (DataRow dtr in ds1.Tables[0].Rows)
            {
                BunifuImageButton btnDeleteMon = new BunifuImageButton();
                btnDeleteMon.BackColor = System.Drawing.Color.Transparent;
                btnDeleteMon.Image = Image.FromFile(@"D:\Phân tích và thiết kế hệ thống thông tin\appCoffee\Pictures\png\icon.png");
                btnDeleteMon.ImageActive = null;
                btnDeleteMon.Location = new System.Drawing.Point(5, 9);
                btnDeleteMon.Name = dtr["monID"].ToString();
                btnDeleteMon.Click += new EventHandler(btnDeleteMonClick);

                btnDeleteMon.Size = new System.Drawing.Size(18, 15);
                btnDeleteMon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                btnDeleteMon.TabIndex = 13;
                btnDeleteMon.TabStop = false;
                btnDeleteMon.Zoom = 10;

                Label lbTenMon = new Label();
                lbTenMon.AutoSize = true;
                lbTenMon.Location = new System.Drawing.Point(38, 10);
                lbTenMon.Name = "lbTenMon" ;
                lbTenMon.Size = new System.Drawing.Size(49, 13);
                lbTenMon.TabIndex = 14;
                lbTenMon.Text = dtr["tenMon"].ToString();

                Label lbSoLuong = new Label();
                lbSoLuong.AutoSize = true;
                lbSoLuong.Location = new System.Drawing.Point(253, 2);
                lbSoLuong.Name = "lbSoLuong" ;
                lbSoLuong.Size = new System.Drawing.Size(13, 13);
                lbSoLuong.TabIndex = 16;
                lbSoLuong.Text = dtr["soLuong"].ToString();

                BunifuSeparator bunifuSeparator3 = new BunifuSeparator();
                bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
                bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
                bunifuSeparator3.LineThickness = 1;
                bunifuSeparator3.Location = new System.Drawing.Point(236, 8);
                bunifuSeparator3.Name = "bunifuSeparator3" ;
                bunifuSeparator3.Size = new System.Drawing.Size(43, 9);
                bunifuSeparator3.TabIndex = 15;
                bunifuSeparator3.Transparency = 255;
                bunifuSeparator3.Vertical = false;

                Label lbGia = new Label();
                lbGia.AutoSize = true;
                lbGia.Location = new System.Drawing.Point(239, 17);
                lbGia.Name = "lbGia";
                lbGia.Size = new System.Drawing.Size(40, 13);
                lbGia.TabIndex = 17;
                lbGia.Text = dtr["gia"].ToString();

                BunifuSeparator bunifuSeparator2 = new BunifuSeparator();
                bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
                bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
                bunifuSeparator2.LineThickness = 1;
                bunifuSeparator2.Location = new System.Drawing.Point(2, 24);
                bunifuSeparator2.Name = "bunifuSeparator2";
                bunifuSeparator2.Size = new System.Drawing.Size(287, 20);
                bunifuSeparator2.TabIndex = 12;
                bunifuSeparator2.Transparency = 255;
                bunifuSeparator2.Vertical = false;

                Panel panel7 = new Panel();
                panel7.Dock = System.Windows.Forms.DockStyle.Top;
                panel7.Location = new System.Drawing.Point(3, 3);
                panel7.Name = "panel7" ;
                panel7.Size = new System.Drawing.Size(290, 45);
                panel7.TabIndex = 1;
                panel7.Controls.Add(btnDeleteMon);
                panel7.Controls.Add(lbTenMon);
                panel7.Controls.Add(lbSoLuong);
                panel7.Controls.Add(bunifuSeparator3);
                panel7.Controls.Add(lbGia);
                panel7.Controls.Add(bunifuSeparator2);

                flowLayoutPanel4.Controls.Add(panel7);
            }
        }
        private void btnDeleteMonClick(object sender, EventArgs e)
        {
          
            BunifuImageButton btnDeleteMonClick = sender as BunifuImageButton;
            
            if (cthdkhbll.deleteChiTietHoaDon(Convert.ToInt32(lbHoaDonID.Text), btnDeleteMonClick.Name.ToString()))
            {
                MessageBox.Show("xóa đồ ăn trong Hóa đơn thành công !!!");
            }
            else
            {
                MessageBox.Show("không thành công !!! vui lòng liên hệ đến Hiền");
            }
            
            LoadHoaDonKhachHang(Convert.ToInt32(lbHoaDonID.Text));
            LoadButtonTheBan();
            UpdateLabelGiaTam(lbTenBan.Text);
        }
        private void txtPhiPhuThu_KeyPress(object sender, KeyPressEventArgs e)
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
            if (Convert.ToInt32((sender as TextBox).Text.Length) > 10)
            {
                e.Handled = true;
            }

        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
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
            if (Convert.ToInt32((sender as TextBox).Text.Length) > 10)
            {
                e.Handled = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (lbGiaTam.Text != "" && txtGiamGia.Text != "" && txtPhiPhuThu.Text != "")
            {
                lbTongTien.Text = (Convert.ToInt32(lbGiaTam.Text) - ((Convert.ToInt32(lbGiaTam.Text) * Convert.ToInt32(txtGiamGia.Text)) / 100) + Convert.ToInt32(txtPhiPhuThu.Text)).ToString();
                
                hdkhbll.UpdateGiamGia(Convert.ToInt32(lbHoaDonID.Text), Convert.ToInt32(txtGiamGia.Text));
            }
            else if(lbGiaTam.Text != "" && txtGiamGia.Text == "" && txtPhiPhuThu.Text != "")
            {
                lbTongTien.Text = (Convert.ToInt32(lbGiaTam.Text) + Convert.ToInt32(txtPhiPhuThu.Text)).ToString();

                hdkhbll.UpdateGiamGia(Convert.ToInt32(lbHoaDonID.Text), 0);
            }
        }

        private void txtPhiPhuThu_TextChanged(object sender, EventArgs e)
        {
            if (lbGiaTam.Text != "" && txtGiamGia.Text != "" && txtPhiPhuThu.Text != "")
            {
                lbTongTien.Text = (Convert.ToInt32(lbGiaTam.Text) - ((Convert.ToInt32(lbGiaTam.Text) * Convert.ToInt32(txtGiamGia.Text)) / 100) + Convert.ToInt32(txtPhiPhuThu.Text)).ToString();
                hdkhbll.UpdatePhiPhuThu(Convert.ToInt32(lbHoaDonID.Text), Convert.ToInt32(txtPhiPhuThu.Text));
            }
            else if(lbGiaTam.Text != "" && txtGiamGia.Text != "" && txtPhiPhuThu.Text == "")
            {
                lbTongTien.Text = (Convert.ToInt32(lbGiaTam.Text) - ((Convert.ToInt32(lbGiaTam.Text) * Convert.ToInt32(txtGiamGia.Text)) / 100)).ToString();
                hdkhbll.UpdatePhiPhuThu(Convert.ToInt32(lbHoaDonID.Text), 0);
            }
        }

        private void txtGiamGia_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtPhiPhuThu_Leave(object sender, EventArgs e)
        {
           
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lbGiaTam_TextChanged(object sender, EventArgs e)
        {
            if (lbGiaTam.Text != "" && txtGiamGia.Text != "" && txtPhiPhuThu.Text != "")
            {
                lbTongTien.Text = (Convert.ToInt32(lbGiaTam.Text) - ((Convert.ToInt32(lbGiaTam.Text) * Convert.ToInt32(txtGiamGia.Text)) / 100) + Convert.ToInt32(txtPhiPhuThu.Text)).ToString();

            }
        }

        private void reload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            theBanIDForm = lbTenBan.Text;
            hoaDonIDForm = lbHoaDonID.Text;
            frm_TinhTien frm_Tinh = new frm_TinhTien();
            frm_Tinh.Text ="HÓA ĐƠN KHÁCH HÀNG: "+ lbHoaDonID.Text;
           
            frm_Tinh.ShowDialog();

            LoadData();
        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("hi");
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hi");
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void btn_ThongTinCaNhan_Click(object sender, EventArgs e)
        {
            ThongTinCaNhan frm = new ThongTinCaNhan();
            frm.Show();
        }
    }
}
