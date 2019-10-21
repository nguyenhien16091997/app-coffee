using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayers
{
    public class ChiTietMonBLL
    {
        DAL dal;
        public ChiTietMonBLL()
        {
            dal = new DAL();
        }
        public DataSet getListChiTietMon(String monID)
        {
            return dal.ExecuteQueryDataSet("USP_getListChiTietMon", CommandType.StoredProcedure, new SqlParameter("@monID", monID));
        }
        public bool deleteChiTietMon(string monID, String nguyenLieuID)
        {
            string err = "";
            return dal.MyExecuteNonQuery("USP_DeleteChiTietMon", CommandType.StoredProcedure, ref err, new SqlParameter("@monID", monID), new SqlParameter("@nguyenLieu", nguyenLieuID));
        }
        public bool updateChiTietMon(String monID, String nguyenLieuID, int soluong)
        {
            string err = "";
            return dal.MyExecuteNonQuery("USP_UpdateChiTietMon", CommandType.StoredProcedure, ref err, new SqlParameter("@monID", monID),
                new SqlParameter("@nguyenLieuID", nguyenLieuID),
                new SqlParameter("@soLuong", soluong));
        }
        public bool checkLikeChiTietMon(String monID, String nguyenLieuID)
        {
            bool bl = false;       
            DataSet ds = new DataSet();
            ds= dal.ExecuteQueryDataSet("select dbo.UF_CheckLikeChiTietMon (N'" + monID + "', N'" + nguyenLieuID + "')",CommandType.Text);
            if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
            {
                bl = true;
            }
            return bl;
        }
        public bool insertChiTietMon(String monID, String nguyenLieuID, int soLuong, String donVi)
        {
            string err = "";
            return dal.MyExecuteNonQuery("USP_InsertChiTietMon", CommandType.StoredProcedure, ref err,
                new SqlParameter("@monID", monID),
                new SqlParameter("@nguyenLieuID", nguyenLieuID),
                new SqlParameter("@soLuong", soLuong),
                new SqlParameter("@donVi", donVi));
        }
    }
}
