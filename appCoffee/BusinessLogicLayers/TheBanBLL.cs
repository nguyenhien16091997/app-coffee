using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayers
{
    public class TheBanBLL
    {
        DAL dal;
        public TheBanBLL()
        {
            dal = new DAL();
        }
        public DataSet getListTheBan()
        {
            return dal.ExecuteQueryDataSet("USP_getListTheBan", CommandType.StoredProcedure);
        }
        public bool InsertTheBan(String theBanID)
        {
            string err = "";
            return dal.MyExecuteNonQuery("USP_InsertTheBan", CommandType.StoredProcedure,ref err ,new SqlParameter("@theBanID", theBanID));
        }
        public bool KiemTraTrungTaiKhoan(String theBanID)
        {
            DataSet ds = new DataSet();
            bool bl = false;
            ds = dal.ExecuteQueryDataSet("select dbo.UF_KiemTraIDTheDaCo (N'" + theBanID + "')", CommandType.Text);
            if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
            {
                bl = true;
            }
            return bl;
        }
        public bool UpdateTheBan(string theBanIDOld, String theBanIDNew)
        {
            string err = "";
            return dal.MyExecuteNonQuery("USP_UpdateTheBan", CommandType.StoredProcedure, ref err ,new SqlParameter("@theBanIDOld", theBanIDOld), new SqlParameter("theBanIDNew", theBanIDNew));
        }
    }
}
