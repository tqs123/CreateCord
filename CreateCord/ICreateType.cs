using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCord
{
    public interface ICreateType
    {
        DataTable GetDataBases();

        DataTable GetTables();


        DataTable GetColumns(string tableName);

        DataTable GetData(string tableName);
    }
}
