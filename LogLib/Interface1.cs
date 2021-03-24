using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLib
{
    interface ILogger
    {

        DataTable GetAllLog();
        void AddLog(string islem, string details, string durum, string kategori);
        void DeleteLog();





    }
}
