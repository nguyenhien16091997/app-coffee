using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayers
{
    public class TheLoaiBLL
    {
        DAL dal;
        public TheLoaiBLL()
        {
            dal = new DAL();
        }
        public DataSet getListTheLoai()
        {
            return dal.ExecuteQueryDataSet("USP_getListTheLoai", CommandType.StoredProcedure);
        }
    }
}
