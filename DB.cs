using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace storeMIS
{
    class DB
    {
        public static SqlConnection Create_conn()
        {
            SqlConnection cn = new SqlConnection("server=.;database=storeMIS;Integrated Security=True");
            return cn;
        }
        //更新操作
        public static bool Execute_update(string str1)
        {
            SqlConnection cn = Create_conn();
            SqlCommand cmd = new SqlCommand(str1, cn);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }
        //检查数据库有无指定信息
        public static bool Execute_select(string str1)
        {
            SqlConnection cn = Create_conn();
            SqlCommand cmd = new SqlCommand(str1, cn);
            try
            {
                if (cn.State == ConnectionState.Closed) 
                    cn.Open();
                return cmd.ExecuteReader().HasRows;                
            }
            catch
            {
                return false;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }
        //断开式读大量数据
        public static DataSet Execute_DS(string str1) 
        {
            SqlConnection cn = Create_conn();
            SqlDataAdapter da = new SqlDataAdapter(str1, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
