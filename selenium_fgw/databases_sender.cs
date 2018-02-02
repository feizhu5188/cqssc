using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Npgsql;
using System.Data;
using NpgsqlTypes;

namespace selenium_fgw
{
    public class databases_sender
    {
        
            public static void kaijianghao_sender_mssql(string qihao,string kaijianghao, string n1, string n2, string n3, string n4,string n5)
            {
                using (SqlConnection mycon = new SqlConnection())
                {

                    mycon.ConnectionString = ConfigurationManager.ConnectionStrings["zhineng_shishicai"].ConnectionString;
                    using (SqlCommand mycom = new SqlCommand())
                    {
                        mycon.Open();
                        mycom.Connection = mycon;
                        mycom.CommandType = CommandType.Text;
                        mycom.CommandText = "insert into shishicai_kaijianghao_caiji (qihao,kaijianghao,n1,n2,n3,n4,n5)values(@qihao,@kaijianghao,@n1,@n2,@n3,@n4,@n5)";
                        mycom.Parameters.Add(new SqlParameter("@qihao", SqlDbType.VarChar));
                        mycom.Parameters["@qihao"].Direction = ParameterDirection.Input;
                        mycom.Parameters["@qihao"].Value = qihao;
                        mycom.Parameters.Add(new SqlParameter("@kaijianghao", SqlDbType.VarChar));
                        mycom.Parameters["@kaijianghao"].Direction = ParameterDirection.Input;
                        mycom.Parameters["@kaijianghao"].Value = kaijianghao;
                        mycom.Parameters.Add(new SqlParameter("@n1", SqlDbType.VarChar));
                        mycom.Parameters["@n1"].Direction = ParameterDirection.Input;
                        mycom.Parameters["@n1"].Value = n1;
                        mycom.Parameters.Add(new SqlParameter("@n2", SqlDbType.VarChar));
                        mycom.Parameters["@n2"].Direction = ParameterDirection.Input;
                        mycom.Parameters["@n2"].Value = n2;
                        mycom.Parameters.Add(new SqlParameter("@n3", SqlDbType.VarChar));
                        mycom.Parameters["@n3"].Direction = ParameterDirection.Input;
                        mycom.Parameters["@n3"].Value = n3;
                        mycom.Parameters.Add(new SqlParameter("@n4", SqlDbType.VarChar));
                        mycom.Parameters["@n4"].Direction = ParameterDirection.Input;
                        mycom.Parameters["@n4"].Value = n4;
                        mycom.Parameters.Add(new SqlParameter("@n5", SqlDbType.VarChar));
                        mycom.Parameters["@n5"].Direction = ParameterDirection.Input;
                        mycom.Parameters["@n5"].Value = n5;
                        mycom.ExecuteNonQuery();

                    }

                }

            }

            public static void kaijianghao_sender_npgsql(string qihao, string n1, string n2, string n3, string n4)
            {
                using (NpgsqlConnection mycon = new NpgsqlConnection())
                {
                    mycon.ConnectionString = ConfigurationManager.ConnectionStrings["zhinengjihuanpg_saiche"].ConnectionString;
                    using (NpgsqlCommand mycom = new NpgsqlCommand())
                    {
                    mycon.Open();
                    mycom.Connection = mycon;
                    mycom.CommandType = CommandType.Text;
                    mycom.CommandTimeout = 90;
                    mycom.CommandText = "insert into public.tb_base_data_car(periods,ten,nine,eight,seven)values(@qihao,@n1,@n2,@n3,@n4)   ";
                    mycom.Parameters.Add(new NpgsqlParameter("@qihao", NpgsqlDbType.Varchar));
                    mycom.Parameters["@qihao"].Direction = ParameterDirection.Input;
                    mycom.Parameters["@qihao"].Value = qihao;
                    mycom.Parameters.Add(new NpgsqlParameter("@n1", NpgsqlDbType.Varchar));
                    mycom.Parameters["@n1"].Direction = ParameterDirection.Input;
                    mycom.Parameters["@n1"].Value = n1;
                    mycom.Parameters.Add(new NpgsqlParameter("@n2", NpgsqlDbType.Varchar));
                    mycom.Parameters["@n2"].Direction = ParameterDirection.Input;
                    mycom.Parameters["@n2"].Value = n2;
                    mycom.Parameters.Add(new NpgsqlParameter("@n3", NpgsqlDbType.Varchar));
                    mycom.Parameters["@n3"].Direction = ParameterDirection.Input;
                    mycom.Parameters["@n3"].Value = n3;
                    mycom.Parameters.Add(new NpgsqlParameter("@n4", NpgsqlDbType.Varchar));
                    mycom.Parameters["@n4"].Direction = ParameterDirection.Input;
                    mycom.Parameters["@n4"].Value = n4;
                    mycom.ExecuteNonQuery();


                }

                }

            }


      


    }
}
