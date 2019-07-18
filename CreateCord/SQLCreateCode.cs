using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCord
{
    public class SQLCreateCode : ICreateType
    {

        IDataBase iDB = null;



        public SQLCreateCode(string DataBaseName)
        {
            iDB = new SQLHelperSQL(DataBaseName);
        }

        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataBases()
        {
            string sql = @" select dbid id,name from sysdatabases where dbid>6";
            return iDB.getDataTable(sql);

        }
        /// <summary>
        /// 更具数据库查询对应的表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTables()
        {
            string sql = string.Format("select name from sysobjects   where  type='U' order by name  asc");
            return iDB.getDataTable(sql);
        }
        /// <summary>
        /// 根据某一个表获取所有的列
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetColumns(string tableName)
        {

            string sql = string.Format(@"select COLUMN_NAME AS name ,DATA_TYPE as type from INFORMATION_SCHEMA.COLUMNS  where table_name='{0}'", tableName);
            return iDB.getDataTable(sql);
        }
        public DataTable GetData(string tableName)
        {
            string sql = string.Format(@"select * from {0}", tableName);
            return iDB.getDataTable(sql);
        }
    }
}
