using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLib
{
    class OracleLogger : ILogger
    {
        public void AddLog(string islem, string details, string durum, string kategori)
        {
            throw new NotImplementedException();
        }

        public void DeleteLog()
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllLog()
        {
            throw new NotImplementedException();
        }
    }
}
