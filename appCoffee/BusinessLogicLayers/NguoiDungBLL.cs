using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessLogicLayers
{
    public class NguoiDungBLL
    {
        DAL dal;
        public NguoiDungBLL()
        {
            dal = new DAL();
        }
        public bool CheckLogin(String userName, String password)
        {
            if(dal.ExecuteQueryDataSet("select dbo.UF_CheckLogin (N'"+userName+"', N'" + password + "')", CommandType.Text).Tables[0].Rows[0][0].ToString().Equals("1"))
            {
                return true;
            }
            return false;            
        }
        public DataSet ListUser()
        {      
            return dal.ExecuteQueryDataSet("USP_getListNguoiDung", CommandType.Text);
        }
        public bool DeleteNguoiDung(ref String err, String taiKhoan)
        {
            return dal.MyExecuteNonQuery("USP_DeleteNguoiDung", CommandType.StoredProcedure,ref err, new SqlParameter("@taiKhoan", taiKhoan));
        }
        public bool UpdateNguoiDung(ref String err, String taikhoan, String matKhau,
            String hoTen, String noiO, String dienThoai, String gioiTinh,
            String chucVuID, String danToc, String ngaySinh, String ngayBatDau, int luongGioHT)
        {
            return dal.MyExecuteNonQuery("USP_UpdateNguoiDung", CommandType.StoredProcedure, ref err
                , new SqlParameter("@taiKhoan", taikhoan)
                , new SqlParameter("@matKhau", matKhau), new SqlParameter("@hoTen", hoTen)
                , new SqlParameter("@noiO", noiO)
                , new SqlParameter("@dienThoai", dienThoai), new SqlParameter("@gioiTinh", gioiTinh)
                , new SqlParameter("@chucVuID", chucVuID), new SqlParameter("@danToc", danToc)
                , new SqlParameter("@ngaySinh", ngaySinh), new SqlParameter("@ngayBatDau", ngayBatDau)
                , new SqlParameter("@luongGioHT", luongGioHT));
        }
        public bool KiemTraTrungTaiKhoan(String taiKhoan)
        {
            DataSet ds = new DataSet();
            bool bl = false;
            ds = dal.ExecuteQueryDataSet("select dbo.UF_KiemTraTaiKhoanDaCo (N'" + taiKhoan + "')", CommandType.Text);
            if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
            {
                bl = true;
            }
            return bl;
        }   
        public bool ThemNguoiDung(ref String err, String taikhoan, String matKhau,
            String hoTen, String noiO, String dienThoai, String gioiTinh,
            String chucVuID, String danToc, String ngaySinh, String ngayBatDau, int luongGioHT)
        {            
            return dal.MyExecuteNonQuery("USP_InsertNguoiDung", CommandType.StoredProcedure, ref err,
                new SqlParameter("@taiKhoan", taikhoan)
                , new SqlParameter("@matKhau", matKhau)
                , new SqlParameter("@hoTen", hoTen)
                , new SqlParameter("@noiO", noiO)
                , new SqlParameter("@dienThoai", dienThoai)
                , new SqlParameter("@gioiTinh", gioiTinh)
                , new SqlParameter("@chucVuID", chucVuID)
                , new SqlParameter("@danToc", danToc)
                , new SqlParameter("@ngaySinh", ngaySinh)
                , new SqlParameter("@ngayBatDau", ngayBatDau)
                , new SqlParameter("@luongGioHT", luongGioHT));
        }
        public DataSet GetRowFromTaiKhoan(string taiKhoan)
        {
            return dal.ExecuteQueryDataSet("USP_GetNguoiDungFromID", CommandType.StoredProcedure, new SqlParameter("@taiKhoan", taiKhoan));
        }
    }
}
