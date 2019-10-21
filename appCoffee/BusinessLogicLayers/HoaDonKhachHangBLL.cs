using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogicLayers
{
    public class HoaDonKhachHangBLL
    {
        DAL dal;
        public HoaDonKhachHangBLL()
        {
            dal = new DAL();
        }
        public bool InsertHoaDonKhachHang(String theBanID)
        {
            DataSet ds = new DataSet();
            ds = dal.ExecuteQueryDataSet("select dbo.UF_CheckTheTheoHoaDonForInsertHoaDonKhachHang(N'"+theBanID+"')", CommandType.Text);
            string s = ds.Tables[0].Rows[0][0].ToString();
            if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
            {
                return false;
            }
            else
            {
                string err = "";
                return dal.MyExecuteNonQuery("USP_InsertHoaDonKhachHang", CommandType.StoredProcedure, ref err, new SqlParameter("@theBanID", theBanID));

            }
            
        }
        public DataSet getRowFromTheBan(String theBanID)
        {
            return dal.ExecuteQueryDataSet("USP_GetRowFromTheIDInHoaDonKhachHang", CommandType.StoredProcedure, new SqlParameter("@theBanID", theBanID));
        }
        public bool UpdateGiamGia(int hoaDonID, float giamGia)
        {
            string err = "";
            return dal.MyExecuteNonQuery("USP_UpdateGiamGiaToHoaDonKhachHang", CommandType.StoredProcedure, ref err, new SqlParameter("@hoaDonID", hoaDonID),
                new SqlParameter("@giamGia", giamGia));
        }
        public bool UpdatePhiPhuThu(int hoaDonID, float phiPhuThu)
        {
            string err = "";
            return dal.MyExecuteNonQuery("USP_UpdatePhiPhuThuToHoaDonKhachHang", CommandType.StoredProcedure, ref err, new SqlParameter("@hoaDonID", hoaDonID),
                new SqlParameter("@phiPhuThu", phiPhuThu));
        }
        public DataSet getRowFromHoaDonID(int hoaDonID)
        {
            return dal.ExecuteQueryDataSet("USP_GetRowHoaDonKhachHangFromHoaDonID", CommandType.StoredProcedure, new SqlParameter("@hoaDonID", hoaDonID));
        }
        public bool UpdateHoaDonKhachHang(int hoaDonID, string theBanID, string taiKhoan, float sdt, float tongTien )
        {
            string err = "";
            return dal.MyExecuteNonQuery("USP_UpdateHoaDonKhachHang", CommandType.StoredProcedure, ref err,
                new SqlParameter("@hoaDonID", hoaDonID),
                new SqlParameter("@theBanID", theBanID),
                new SqlParameter("@taiKhoan", taiKhoan),
                new SqlParameter("@khachHangID", sdt),
                new SqlParameter("@tongTien", tongTien),
                new SqlParameter("@ngaytao", DateTime.UtcNow.Date.ToString("dd/MM/yyyy")),
                new SqlParameter("@ngayCapNhat", DateTime.UtcNow.Date.ToString("dd/MM/yyyy")));
        }     
    }
}
