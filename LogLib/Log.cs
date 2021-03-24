using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace LogLib
{
    public class LogInfo:ILogger
    {
        public string islem { get; set; }
        public string sonuc { get; set; }
        public string islemTuru { get; set; }

        public DataTable GetAllLog()
        {//Tüm kayıtları getirme. 
            SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=LogData;integrated security=true");
            if (connection.State==ConnectionState.Closed)
            {
            connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * from Logs",connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable tab = new DataTable();
            tab.Load(reader);
            reader.Close();
            connection.Close();
            return tab;
        }
        public void AddLog(string islem,string details,string durum,string kategori)
        {
            //Yapılan işlemin cins ve kategoriye göre kayıt edilmesi.
            SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=LogData;integrated security=true");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            var local = DateTime.Now;
            var utc = local.ToUniversalTime();
            SqlCommand command = new SqlCommand("Insert into Logs values(@islem,@kategori,@islemturu,@islemZamani,@sonuc)", connection);
            command.Parameters.AddWithValue("@islem", details);
            command.Parameters.AddWithValue("@sonuc", durum);
            command.Parameters.AddWithValue("@islemturu",islem );
            command.Parameters.AddWithValue("@kategori",kategori );
            command.Parameters.AddWithValue("@islemZamani", utc.ToLocalTime().ToString());
           

            command.ExecuteNonQuery();
            connection.Close();
            
        }
        public void DeleteLog()
        {//Kayıtları silme. / riskli.
            SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=LogData;integrated security=true");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Delete from Logs", connection);
            command.ExecuteNonQuery();
            connection.Close();
            

        }

        
    }
    
}
