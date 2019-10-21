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
    public partial class QLThucDon : Form
    {
        ChiTietMonBLL ctmbll = new ChiTietMonBLL();
        TheLoaiBLL tlbll = new TheLoaiBLL();
        MonBLL mbbl = new MonBLL();
        NguyeLieuBLL nlbll = new NguyeLieuBLL();
  
        public QLThucDon()
        {
            InitializeComponent();
            LoadData();
        }

        private void mouseEnter(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = Color.Red;
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = Color.White;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

       


        private void cbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void LoadData()
        {
            txtTrangThai.Enabled = false;

            DataSet dsTheLoai = new DataSet();
            dsTheLoai = tlbll.getListTheLoai();

            cbTheLoai.DataSource = dsTheLoai.Tables[0];
            cbTheLoai.DisplayMember = "tenTheLoai";
            cbTheLoai.ValueMember = "theLoaiID";

            cbTheLoai2.DataSource = dsTheLoai.Tables[0];
            cbTheLoai2.DisplayMember = "tenTheLoai";
            cbTheLoai2.ValueMember = "theLoaiID";

            

            DataSet dsm = new DataSet();
            dsm = mbbl.getListMon();
            datagridMon.DataSource = dsm.Tables[0];

            txtIDMon.DataBindings.Clear();
            txtTenMon.DataBindings.Clear();
            txtTrangThai.DataBindings.Clear();
            cbTheLoai.DataBindings.Clear();
            nudGia.DataBindings.Clear();
            dtpCapNhat.DataBindings.Clear();
            txtTrangThai.DataBindings.Clear();
            txtMonID2.DataBindings.Clear();
            lbTenMon.DataBindings.Clear();

            txtIDMon.DataBindings.Add("Text", dsm.Tables[0], "monID");
            txtTenMon.DataBindings.Add("Text", dsm.Tables[0], "tenMon");
            cbTheLoai.DataBindings.Add("SelectedValue", dsm.Tables[0], "theLoaiID");
            nudGia.DataBindings.Add("Text", dsm.Tables[0], "gia");
            dtpCapNhat.DataBindings.Add("Text", dsm.Tables[0], "lanCapNhatGiaCuoiCung");
            txtTrangThai.DataBindings.Add("Text", dsm.Tables[0], "trangThai");
            txtMonID2.DataBindings.Add("Text", dsm.Tables[0], "monID");
            lbTenMon.DataBindings.Add("Text", dsm.Tables[0], "tenMon");
        }     

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }            

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_Delete_Click_1(object sender, EventArgs e)
        {
            if (!mbbl.DeleteMon(txtMonID2.Text))
            {
                MessageBox.Show("Xóa không thành công !!!");
            }
            else
            {
                MessageBox.Show("Xóa" +
                    " thành công !!!");
            }
        }

        private void btnHide_Click_1(object sender, EventArgs e)
        {
            panelGrid.Size = new System.Drawing.Size(363, 554);
            btnShow.Visible = true;
            btnHide.Visible = false;
        }

        private void btnShow_Click_1(object sender, EventArgs e)
        {
            panelGrid.Size = new System.Drawing.Size(900, 554);
            btnShow.Visible = false;
            btnHide.Visible = true;
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            panelGrid.Enabled = false;
            btnExit.Enabled = true;
            btnDone.Enabled = true;
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;

            txtIDMon.Clear();
            txtTenMon.Clear();
            txtTrangThai.Visible = false;
            dtpCapNhat.Visible = false;
            nudGia.Visible = false;
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (!mbbl.UpdateMon(txtMonID2.Text, txtIDMon.Text, txtTenMon.Text, cbTheLoai2.SelectedValue.ToString(), Convert.ToInt32(Math.Round(nudGia.Value)), dtpCapNhat.Value.ToString("yyyyMMdd")))
            {
                MessageBox.Show("update không thành công !!!");
            }
            else
            {
                MessageBox.Show("update" +
                    " thành công !!!");
            }
        }

        private void btnDone_Click_1(object sender, EventArgs e)
        {
            if (!mbbl.InsertMon(txtIDMon.Text, txtTenMon.Text, cbTheLoai.SelectedValue.ToString(), Convert.ToInt32(Math.Round(nudGia.Value)), dtpCapNhat.Value.ToString("yyyyMMdd")))
            {
                MessageBox.Show("Thêm không thành công !!!");
            }
            else
            {
                MessageBox.Show("Thêm thành công !!!");
            }
            LoadData();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            panelGrid.Enabled = true;
            btnExit.Enabled = false;
            btnDone.Enabled = false;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = true;

            txtTrangThai.Visible = true;
            dtpCapNhat.Visible = true;
            nudGia.Visible = true;

            LoadData();
        }

        private void btnAddNguyenLieu_Click(object sender, EventArgs e)
        {

        }

        private void lbTenMon_TextChanged(object sender, EventArgs e)
        {
            loadDataGridChiTietMon(txtIDMon.Text);
        }
        private void loadDataGridChiTietMon(string monID)
        {

            DataSet dsNguyenLieu = new DataSet();
            dsNguyenLieu = nlbll.LayDanhSachNguyenlieu();
            cbNguyenLieu.DataSource = dsNguyenLieu.Tables[0];
            cbNguyenLieu.DisplayMember = "tenNguyenLieu";
            cbNguyenLieu.ValueMember = "nguyenLieuID";


            DataSet dsctm = new DataSet();
            dsctm = ctmbll.getListChiTietMon(monID);

            datagridMon1.DataSource = dsctm.Tables[0];

            cbNguyenLieu.DataBindings.Clear();
            nudSoLuong.DataBindings.Clear();
            cbDonVi.DataBindings.Clear();
            txtNguyenLieuID.DataBindings.Clear();

            cbNguyenLieu.DataBindings.Add("SelectedValue", dsctm.Tables[0], "nguyenLieuID");
            nudSoLuong.DataBindings.Add("Text", dsctm.Tables[0], "soLuong");
            cbDonVi.DataBindings.Add("Text", dsctm.Tables[0], "donVi");
            txtNguyenLieuID.DataBindings.Add("Text", dsctm.Tables[0], "nguyenLieuID");
        }

        private void btnAddNguyenLieu_Click_1(object sender, EventArgs e)
        {
            panelChiTiet.Enabled = false;
            btnExit2.Enabled = true;
            btnDone2.Enabled = true;
            btnInsert2.Enabled = false;
            btnUpdate2.Enabled = false;

            cbNguyenLieu.Enabled = true;
            btnDelete2.Enabled = false;


        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            panelChiTiet.Enabled = true;
            btnExit2.Enabled = false;
            btnDone2.Enabled = false;
            btnInsert2.Enabled = true;
            btnUpdate2.Enabled = true;

            cbNguyenLieu.Enabled = false;
            btnDelete2.Enabled = true;

            LoadData();
        }

        private void btnDone2_Click(object sender, EventArgs e)
        {
            if(ctmbll.checkLikeChiTietMon(txtMonID2.Text, cbNguyenLieu.SelectedValue.ToString()))
            {
                MessageBox.Show("Nguyên liệu này đã có ! Vui lòng chọn nguyên liệu khác :)");
            }
            else
            {
                if (!ctmbll.insertChiTietMon(txtMonID2.Text, cbNguyenLieu.SelectedValue.ToString(), Convert.ToInt32(Math.Round(nudSoLuong.Value)), cbDonVi.SelectedIndex.ToString()))
                {
                    MessageBox.Show("Thêm không thành công !!!");
                }
                else {
                    MessageBox.Show("Thêm thành công !!!");
                }
                loadDataGridChiTietMon(txtMonID2.Text);
            }
            
        }

        private void cbNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsdv = new DataSet();
            if (cbNguyenLieu.SelectedValue !=null)
            {
                dsdv = nlbll.getDonViFromNguyenLieu(cbNguyenLieu.SelectedValue.ToString());
                cbDonVi.SelectedItem = dsdv.Tables[0].Rows[0][0].ToString();
            }           
           
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (!ctmbll.deleteChiTietMon(txtMonID2.Text, cbNguyenLieu.SelectedValue.ToString()))
            {
                MessageBox.Show("Xóa không thành công !!!");
            }
            else
            {
                MessageBox.Show("Xóa thành công !!!");
            }
            loadDataGridChiTietMon(txtMonID2.Text);
        }

        private void btnReLoad2_Click(object sender, EventArgs e)
        {
            loadDataGridChiTietMon(txtMonID2.Text);
        }

        private void btnUpdate2_Click(object sender, EventArgs e)
        {
            if (!ctmbll.updateChiTietMon(txtMonID2.Text, txtNguyenLieuID.Text, Convert.ToInt32(Math.Round(nudSoLuong.Value))))
            {
                MessageBox.Show("update không thành công !!!");
            }
            else
            {
                MessageBox.Show("update thành công !!!");
            }
            loadDataGridChiTietMon(txtMonID2.Text);
        }
    }
}
