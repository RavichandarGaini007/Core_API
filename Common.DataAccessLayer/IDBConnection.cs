using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataAccessLayer
{
    public interface IDBConnection
    {
        string GetConnection();
        string GetConnection(string db_name);
    }
}
