using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Security.Cryptography.X509Certificates;

namespace DB_Übung_Model
{
    public class AdressList : List<Adresses>
    {
        public SQLiteConnection CreateConnection(string filename)
        {
            SQLiteConnection conn = new SQLiteConnection($"Data Source={filename}");
            try
            {
                conn.Open();
            }
            catch (Exception exp)
            { 
                using(StreamWriter log = new StreamWriter(filename))
                {
                    string msg;
                    FileInfo fi = new FileInfo(filename);
                    if(!Directory.Exists(fi.Directory.FullName)) 
                    {
                        msg = "Pfad existiert nicht";
                    }
                    else
                    {
                        msg = "unbekannter Fehler";
                    }
                    log.WriteLine($"{DateTime.Now}:{msg}");
                }
                throw exp;

            }
            return conn;
        }

        public void Update(string filename)
        {
            SQLiteConnection conn = CreateConnection(filename);
            SQLiteCommand cmd = new SQLiteCommand(conn);
            foreach (Adresses item in this)
            {
                if(item.Dirty)
                {
                    cmd.CommandText=
                }
            }
        }
    }

    
}
