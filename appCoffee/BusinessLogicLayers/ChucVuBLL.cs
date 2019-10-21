using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayers
{
    public class ChucVuBLL
    {
        DAL dal ;
        public ChucVuBLL()
        {
            dal = new DAL();
        }
        public DataSet getListChucVu()
        {
            return dal.ExecuteQueryDataSet("select*from ChucVu", CommandType.Text, null);
        }

    }
}
