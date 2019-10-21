using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessLogicLayers
{
    public class NguyeLieuBLL
    {
        DAL dal;
        public NguyeLieuBLL()
        {
            dal = new DAL();
        }
        public DataSet LayDanhSachNguyenlieu()
        {
            return dal.ExecuteQueryDataSet("USP_getListNguyenLieu", CommandType.StoredProcedure);
        }
        public bool DeleteNguyenLieu(ref string err, String nguyenLieuID)
        {
            return dal.MyExecuteNonQuery("USP_DeleteNguyenLieu", CommandType.StoredProcedure,
                ref err, new SqlParameter("@nguyenLieuID", nguyenLieuID));
        }
        public bool UpdateNguyenLieu(ref String err,String nguyenLieuID, String tenNguyenLieu,
            int soLuong, String donVi, int gia)
        {
            return dal.MyExecuteNonQuery("USP_UpdateNguyenLieu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@nguyenLieuID", nguyenLieuID), 
                new SqlParameter("@tenNguyenLieu", tenNguyenLieu),
                new SqlParameter("@soLuong", soLuong),
                new SqlParameter("@donVi", donVi),
                new SqlParameter("@gia", gia));
        }
        public bool InsertNguyenLieu(ref String err, String nguyenLieuID, String tenNguyenLieu,
            int soLuong, String donVi, int gia)
        {
            return dal.MyExecuteNonQuery("USP_InsertNguyenLieu", CommandType.StoredProcedure, ref err,
                new SqlParameter("@nguyenLieuID", nguyenLieuID),
                new SqlParameter("@tenNguyenLieu", tenNguyenLieu),
                new SqlParameter("@soLuong", soLuong), 
                new SqlParameter("@donVi", donVi),
                new SqlParameter("@gia", gia));
        }
        public bool CheckLikeIDNguyenLieu(String nguyenLieuID)
        {
            DataSet ds = new DataSet();
            bool bl = false;
            ds = dal.ExecuteQueryDataSet("select dbo.UF_KiemTraIDNguyenLieuDaCo (N'"+ nguyenLieuID +"')", CommandType.Text);
            if (ds.Tables[0].Rows[0][0].ToString().Equals("True"))
            {
                bl = true;
            }
            return bl;
        }
        public DataSet getDonViFromNguyenLieu(string nguyenLieuID)
        {
           
            return dal.ExecuteQueryDataSet("select dbo.UF_LayDonViTuNguyenLieu (N'"+nguyenLieuID+"')", CommandType.Text);
        }
    }
}
