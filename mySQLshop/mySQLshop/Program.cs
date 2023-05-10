using System.Data.SQLite;
public class DBFunctions
{
    static public SQLiteConnection establishConnection(string filename)
    {
        SQLiteConnection conn = new SQLiteConnection($"Data Source={filename}");
        conn.Open();
        return conn;
    }

    static public void CreateTable(string filename)
    {
        SQLiteConnection conn = new SQLiteConnection($"Data Source={filename}");
        SQLiteCommand cmd = new SQLiteCommand(conn);
        conn.Open();
        cmd.CommandText = "DROP TABLE IF EXISTS bread";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "CREATE TABLE bread(id int, name string, price int)";
        cmd.ExecuteNonQuery();

        conn.Close();
    }

    static public void addItems(string filename, string tablename, int id, string itemname, int price) 
    {
        SQLiteConnection conn = new SQLiteConnection($"Data Source={filename}");
        SQLiteCommand cmd = new SQLiteCommand(conn);

        conn.Open();

        cmd.CommandText = "INSERT INTO bread values ($ID, $IName, $Price)";

        cmd.Parameters.AddWithValue("$ID", id);
        cmd.Parameters.AddWithValue("$IName", itemname);
        cmd.Parameters.AddWithValue("$price", price);
        cmd.ExecuteNonQuery();

        conn.Close();
    }

    static public void showitems (string filename,string TNAME) 
    {
        SQLiteConnection conn = new SQLiteConnection($"Data Source={filename}");
        string sql = "SELECT * FROM bread";
        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
        conn.Open ();
      
        SQLiteDataReader reader = cmd.ExecuteReader();
        
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string itemname = reader.GetString(1);
            int price = reader.GetInt32(2);
            
            Console.WriteLine("ID: {0}, Name: {1}, Price:{2}",id,itemname,price);

        }
        reader.Close();
        conn.Close();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("mySQL Shop Test: ");

        CreateTable("articles.sqlite");
        addItems("articles.sqlite", "bread", 1, "Koffer", 25);
        showitems("articles.sqlite","bread");

        Console.ReadLine();

    }
    

}


