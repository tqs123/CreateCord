using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCord
{
    public class PGCreateCode : ICreateType
    {
        IDataBase iDB = null;

        public DataTable GetData(string tableName)
        {
            string sql = string.Format(@"select * from {0}", tableName);
            return iDB.getDataTable(sql);
        }

        public PGCreateCode(string DataBaseName)
        {
            iDB = new PGHelperSQL(DataBaseName);
        }
        /// <summary>
        /// 根据某一个表获取所有的列
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetColumns(string tableName)
        {
            string sql = string.Format(@"select column_name as name,data_type as type from information_schema.columns where table_schema='public' and table_name='{0}'", tableName);
            return iDB.getDataTable(sql);
        }

        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataBases()
        {
            string sql = @" select datname as name  from pg_database where datname !='template1' and datname !='template0'";
            return iDB.getDataTable(sql);

        }

        /// <summary>
        /// 更具数据库查询对应的表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTables()
        {
            string sql = @"SELECT   tablename as name   FROM   pg_tables WHERE   tablename   NOT   LIKE   'pg%'  AND tablename NOT LIKE 'sql_%' ORDER   BY   tablename;";
            return iDB.getDataTable(sql);
        }
    }
}
