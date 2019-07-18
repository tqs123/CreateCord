using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCord
{
    public class PGHelperSQL : IDataBase
    {

        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString;

        public PGHelperSQL(string ConnectionStrings)
        {
            connectionString = ConnectionStrings;
        }
        public DataTable getDataTable(string sql)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            // 打开一个数据库连接，在执行相关SQL之前调用   
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "dt");
            DataTable dt = ds.Tables["dt"];


            //关闭一个数据库连接，在执行完相关SQL之后调用   
            conn.Close();

            return dt;


        }
    }
}
