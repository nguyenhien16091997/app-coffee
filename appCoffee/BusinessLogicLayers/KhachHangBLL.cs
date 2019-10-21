using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayers
{
    public class KhachHangBLL
    {
        DAL dal;
        public KhachHangBLL()
        {
            dal = new DAL();
        }
        public bool CheckExists(float sdt)
        {
            if (dal.ExecuteQueryDataSet("select dbo.UF_CheckSDTKhachHang (" + sdt + ")",CommandType.Text).Tables[0].Rows[0][0].ToString().Equals("1"))
            {
                return true;
            }
            return false;
        }
        public float GetTichLuy(float sdt)
        {
            return Convert.ToInt32(dal.ExecuteQueryDataSet("select dbo.UF_GetTichLuy (" + sdt + ")", CommandType.Text).Tables[0].Rows[0][0]);
         
        }
    }
}
