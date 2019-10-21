using System.Data;


namespace DataAccessLayer
{
    public class DAL
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter adp;

        string strConnect =
            "Data Source=(local);Initial Catalog=Northwind;Integrated Security=True";
        public DAL()
        {
            cnn = new SqlConnection(strConnect);
            cmd = cnn.CreateCommand();
        }
        // methods
        // Select query
        public DataSet ExecuteQueryDataSet(
            string strSQL, CommandType ct,
            params SqlParameter[] p)
        {
            cmd.CommandType = ct;
            cmd.CommandText = strSQL;

            adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adp.Fill(ds);

            return ds;
        }
        // return XML
        public string ExecuteQueryXML(
            string strSQL,
            CommandType ct,
            params SqlParameter[] p)
        {
            cmd.CommandType = ct;
            cmd.CommandText = strSQL;

            adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adp.Fill(ds);

            return ds.GetXml();
        }
        // action query: Insert|delete|update|...
        public bool MyExecuteNonQuery(
            string strSQL, CommandType ct,
            ref string error,
            params SqlParameter[] param)
        {
            bool f = false; // done?

            cnn.Open();

            cmd.Parameters.Clear();
            cmd.CommandType = ct;
            cmd.CommandText = strSQL;

            foreach (SqlParameter p in param)
                cmd.Parameters.Add(p);

            try
            {
                cmd.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                cnn.Close();
            }

            return f;
        }
    }
}
