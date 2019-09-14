using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMySite.Models.SQLModel
{
    public interface ISQLSession
    {
        List<List<String>> queryTable(string TableName);
        List<String> queryColumn(string TableName, string ColumnName);

    }
}
