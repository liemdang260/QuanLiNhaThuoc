using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace WindowsFormsApp2
{
    public class KetNoiSQL
    {
        private static string kn = "Data Source=LAPTOP-H5HCODH8;Initial Catalog=QLNHATHUOC;Integrated Security=True";//thay the bang duong dan toi server cua minh
        public static SqlConnection GetDBConnection()
        {
            string connectString = kn;
            SqlConnection conn = new SqlConnection(connectString);
            return conn;
        }

        private static bool KiemTraKN(SqlConnection connec)
        {
            bool kq = false;
            try
            {
                connec.Open();
                kq = true;
                connec.Close();
            }
            catch (Exception ex)
            {
                kq = false;
            }
            return kq;
            
        }
        /// <summary>
        /// dung cho ham select
        /// </summary>
        /// <param name="sql_query"></param>
        public static void Query(string sql_query)//select
        {
            using (SqlConnection connect = GetDBConnection())
            {
                //Console.OutputEncoding = Encoding.UTF8;
                if (!KiemTraKN(connect))
                    return;
                connect.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql_query,connect);

                    using (DbDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                int index_mahd = rd.GetOrdinal("MAHD");
                                long mahd = Convert.ToInt64(rd.GetValue(index_mahd));

                                int index_makh = rd.GetOrdinal("MAKH");
                                long makh = Convert.ToInt32(rd.GetValue(index_makh));
                                Console.WriteLine(mahd + "\t" + makh);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connect.Close();
                    connect.Dispose();
                }
            }

        }

        /// <summary>
        /// dung cho ham insert,delete,update
        /// </summary>
        /// <param name="sql_query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static int NonQuery(string sql_query,params SqlParameter[] parameter)
        {
            
            SqlConnection connect = GetDBConnection();
            if (!KiemTraKN(connect))
                return -1;
            SqlCommand cmd = new SqlCommand(sql_query, connect);
            cmd.Parameters.AddRange(parameter);
            int row_count = 0;
            try
            {
                connect.Open();
                row_count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                row_count = 0;
            }
            finally
            {
                connect.Close();
                connect.Dispose();
            }
            return row_count;
        }

    }
}
//Data Source=LAPTOP-H5HCODH8;Initial Catalog=QLNHATHUOC;Integrated Security=True