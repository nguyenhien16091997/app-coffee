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
    public class MonBLL
    {
        DAL dal;
        public MonBLL()
        {
            dal = new DAL();
        }
        public DataSet getListMon()
        {
            return dal.ExecuteQueryDataSet("USP_getListMon", CommandType.StoredProcedure);
        }
        public bool InsertMon(String monID, String tenMon, String theLoaiID, int gia, string lanCapNhatCuoiCung)
        {
            String err = "";
            return dal.MyExecuteNonQuery("USP_InsertMon", CommandType.StoredProcedure, ref err,
                new SqlParameter("@monID", monID),
                new SqlParameter("@tenMon", tenMon),
                new SqlParameter("@theLoaiID", theLoaiID),
                new SqlParameter("@gia", gia),
                new SqlParameter("@lanCapNhatCuoiCung", lanCapNhatCuoiCung));
        }
        public bool DeleteMon(String monID)
        {
            String err = "";
            return dal.MyExecuteNonQuery("USP_DeleteMon", CommandType.StoredProcedure, ref err, new SqlParameter("@monID", monID));
        }
        public bool UpdateMon(String monIDOld, String monIDNew, String tenMon, String theLoaiID, int gia, string lanCapNhatCuoiCung)
        {
            String err = "";
            return dal.MyExecuteNonQuery("USP_UpdateMon", CommandType.StoredProcedure, ref err,
                new SqlParameter("@monIDNew", monIDNew),
                new SqlParameter("@monIDOld", monIDOld),
                new SqlParameter("@tenMon", tenMon),
                new SqlParameter("@theLoaiID", theLoaiID),
                new SqlParameter("@gia", gia),
                new SqlParameter("@lanCapNhatGiaCuoiCung", lanCapNhatCuoiCung));

        }
        public DataSet getListMonFromTheLoai(String tenTheloai)
        {
            return dal.ExecuteQueryDataSet("USP_getListFromTheLoai", CommandType.StoredProcedure, new SqlParameter("@tenTheLoai", tenTheloai));
        }
    }
}
