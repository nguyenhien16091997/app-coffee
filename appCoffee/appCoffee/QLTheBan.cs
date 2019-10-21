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
    public partial class QLTheBan : Form
    {
        TheBanBLL tbbll = new TheBanBLL();
        public QLTheBan()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            DataSet dstb = new DataSet();
            txtTenThe.Clear();

            dstb=tbbll.getListTheBan();

            datagridTheBan.DataSource = dstb.Tables[0];

            txtTenThe.DataBindings.Clear();
            txtIdOld.DataBindings.Clear();

            txtTenThe.DataBindings.Add("Text", dstb.Tables[0], "theBanID");
            txtIdOld.DataBindings.Add("Text", dstb.Tables[0], "theBanID");


        }      

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            txtTenThe.Clear();

            btnHoanThanh.Visible = true;
            btnInsert.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnHuy.Enabled = true;
        }
        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if (tbbll.KiemTraTrungTaiKhoan(txtTenThe.Text))
            {
                MessageBox.Show("Tên này đã có rồi vui lòng nhập tên khác !!!");
            }
            else {
                if (!tbbll.InsertTheBan(txtTenThe.Text))
                {
                    MessageBox.Show("Thêm không thành công vui lòng liên hệ chúng tôi !!!");
                }
                else
                    MessageBox.Show("Thêm thành công !!!");
                LoadData();
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenThe.Clear();

            btnHoanThanh.Visible = false;
            btnInsert.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnHuy.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbbll.KiemTraTrungTaiKhoan(txtTenThe.Text))
            {
                MessageBox.Show("Tên này đã có rồi vui lòng nhập tên khác !!!");
            }
            else
            {
                if (!tbbll.UpdateTheBan(txtIdOld.Text, txtTenThe.Text))
                {
                    MessageBox.Show("update thất bại !!!");
                }
                else
                {
                    MessageBox.Show("thành công !!!");
                }
            }
            
            LoadData();
        }
    }
}
