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

    public class ChiTietHoaDonKhachHangBLL
    {
        DAL dal;
        public ChiTietHoaDonKhachHangBLL()
        {
            dal = new DAL();
        }
        public DataSet GetListChiTietHoaDonFromHoaDonID(int hoaDonID)
        {
            return dal.ExecuteQueryDataSet("USP_GetListChiTietHoaDonFromHoaDon", CommandType.StoredProcedure, new SqlParameter("@hoaDonID",hoaDonID));
        }
        public bool InsertChiTietHoaDon(int hoaDonID, string monID, string theBanID)
        {
            
            DataSet ds = new DataSet();
            ds = dal.ExecuteQueryDataSet("select dbo.UF_CheckChiTietHoaDonHad ("+hoaDonID+",N'"+monID+"',N'"+theBanID+"')", CommandType.Text);
            if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
            {
                string err = "";
                return dal.MyExecuteNonQuery("USP_UpdateGiaSoLuongChiTietHoaDon", CommandType.StoredProcedure, ref err, new SqlParameter("@hoaDonID", hoaDonID), new SqlParameter("@monID", monID));
            }
            else
            {
                string err = "";
                return dal.MyExecuteNonQuery("USP_InsertChiTietHoaDon", CommandType.StoredProcedure, ref err, new SqlParameter("@hoaDonID", hoaDonID), new SqlParameter("@monID", monID), new SqlParameter("theBanID", theBanID));
            }          
        }
        public bool deleteChiTietHoaDon(int hoaDonID, String monID)
        {
            String err = "";
            return dal.MyExecuteNonQuery("USP_AcceptGiaSoLuongChiTietHoaDon", CommandType.StoredProcedure, ref err, new SqlParameter("@hoaDonID", hoaDonID), new SqlParameter("@monID", monID));
        }
    }
}
