using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace 安永水果超市管理系统
{
    class DBAccess
    {
        public static SqlConnection EXE_cn()
        {
            //连接对象设置
            SqlConnection cn = new SqlConnection("server=.;database=storeMIS;Integrated Security=True");
            return cn;
        }
        //断开式访问
        public static DataSet EXE_DS(string strcmd)
        {
           
                SqlConnection cn = EXE_cn();
                SqlDataAdapter da = new SqlDataAdapter(strcmd, EXE_cn());
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            

        }

        //连接式访问
        public static bool EXE_select(string strcmd)
        {
            //执行查询，如果有结果返回true,否则就是false
            SqlConnection cn = EXE_cn();
            SqlCommand cmd = new SqlCommand(strcmd, cn);
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                if (cmd.ExecuteReader().HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            finally
            {
                if (cn.State == ConnectionState.Open)

                    cn.Close();

            }

        }

        public static bool EXE_update(string strcmd)
        {
            //执行查询，如果有结果返回true,否则就是false
            SqlConnection cn = EXE_cn();
            SqlCommand cmd = new SqlCommand(strcmd, cn);
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

    }
}
