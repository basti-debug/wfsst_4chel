using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Data.SQLite;
using System.Diagnostics;

namespace ChatserverLib
{
    public class TCP_Chatserver
    {
        public TcpListener Listener { get; set; }

        public Socket Socket { get; set; }

        public TCP_Chatserver(int port)
        {
            Listener=new TcpListener(IPAddress.Any, port);
            // IPAddress.Any ... jede lokale IP-Adresse (also jedes Interface) wird abgehört
        }


        #region DB
        public SQLiteConnection CreateConnection(string filename)
        {
            SQLiteConnection conn = new SQLiteConnection($"Data Source={filename}");
            try
            {
                conn.Open();
            }
            catch (Exception exp)
            {
                using (StreamWriter log = new StreamWriter("Error.log", true))
                {
                    string msg;
                    FileInfo fi = new FileInfo(filename);
                    if (!Directory.Exists(fi.Directory.FullName))
                    {
                        msg = "Pfad existiert nicht";
                    }
                    else
                    {
                        msg = "unbekannter Fehler";
                    }
                    log.WriteLine($"{DateTime.Now}: {msg}");
                }
                throw exp;
            }

            return conn;
        }

        public void initalisetable(string filename)
        {
            SQLiteConnection conn = CreateConnection(filename);

            SQLiteCommand cmd = new SQLiteCommand(conn);


            cmd.CommandText = "DROP TABLE IF EXISTS message";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE message(id INTEGER PRIMARY KEY, user TEXT, msg TEXT, time TIMESTAMP)";
            cmd.ExecuteNonQuery();  

            cmd.CommandText = "DROP TABLE IF EXISTS logindata";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE logindata(id INTEGER PRIMARY KEY, name TEXT, password TEXT)";
            cmd.ExecuteNonQuery();


            // Test LoginDaten 
            cmd.CommandText = "INSERT INTO logindata(name, password) VALUES('admin', 'admin')"; 
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        
        public bool requestDB(string filename, string name, string password)
        {
            SQLiteConnection conn = CreateConnection(filename);

            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "SELECT name, password FROM logindata";
            SQLiteDataReader sQLiteDataReader = cmd.ExecuteReader();

            while (sQLiteDataReader.Read())
            {
                if (sQLiteDataReader.GetString(0) == name && sQLiteDataReader.GetString(1) == password)
                {
                    Debug.WriteLine("Data found");
                    return true;
                }
                else
                {
                    Debug.WriteLine("Data not found");
                    return false;
                }
            }
            return false;
        }

        public void logmessage(string filename, string user, string msg)
        {
            SQLiteConnection conn = CreateConnection(filename);

            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = $"INSERT INTO message(user, msg, time) VALUES('{user}', '{msg}', CURRENT_TIMESTAMP)";
            cmd.ExecuteNonQueryAsync();
        }


        #endregion


        public bool start()
        {
            try
            {
                Listener.Start();
                Socket = Listener.AcceptSocket();

                Console.WriteLine(
                    $"Verbindung gestartet: {Socket.LocalEndPoint} <-> {Socket.RemoteEndPoint}");
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return false;
                throw;
            }
        }

        public void Listen(string user, string filename)
        {
            NetworkStream stream = new NetworkStream(Socket);
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            string msg;

            do
            {
                msg = reader.ReadLine();
                Console.WriteLine(msg);
                writer.WriteLine(msg);
                writer.Flush();


                logmessage(filename, user, msg);
            } while (msg != "%");
        }

        public bool login(string filename) {             
            
                   NetworkStream stream = new NetworkStream(Socket);
                   StreamReader reader = new StreamReader(stream);
                   StreamWriter writer = new StreamWriter(stream);
                  
                   writer.Write("Username: ");
                   writer.Flush();

            string username = reader.ReadLine();
            writer.Write("Password: ");
            writer.Flush();
            string password = reader.ReadLine();
            
            if (requestDB(filename,username,password) == true)
            {
                writer.WriteLine("Login successful");
                writer.Flush();
                return true;
            }
            else
            {
                writer.WriteLine("Login failed");
                writer.Flush();
                return false;
            }

        }
    }
}