using System.Data.SQLite;
using System.Globalization;

namespace DB_Artikel_Model
{
    public class ArticleList : List<Article>
    {
        // Install-Package system.data.sqlite -> vorher library markieren
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

        public void Update(string filename)
        {
            SQLiteConnection conn = CreateConnection(filename);

            SQLiteCommand cmd = new SQLiteCommand(conn);
            foreach (Article item in this)
            {
                if (item.Dirty) // Datensatz wurde geändert
                {
                    cmd.CommandText = $"UPDATE article " +
                        $"SET name='{item.Name}', price={item.Price.ToString(CultureInfo.GetCultureInfo("en-US"))} " +
                        $"WHERE id={item.Id}";
                    // oder besser zur Vermeidung von SQL injections:
                    cmd.CommandText = "UPDATE article SET name=$NAME, price=$PRICE WHERE id=$ID";
                    cmd.Parameters.AddWithValue("$NAME", item.Name);
                    cmd.Parameters.AddWithValue("$PRICE", item.Price);
                    cmd.Parameters.AddWithValue("$ID", item.Id);
                    cmd.ExecuteNonQuery();
                }
                if (item.Deleted) // als gelöscht markiert
                {
                    cmd.CommandText = "DELETE FROM article WHERE id=$ID";
                    cmd.Parameters.AddWithValue("$ID", item.Id);
                    cmd.ExecuteNonQuery ();
                }
                if(item.Id == -1) // neuer Datensatz
                {
                    cmd.CommandText = "INSERT INTO article(name,price) VALUES($NAME, $PRICE); SELECT last_insert_rowid();";
                    cmd.Parameters.AddWithValue("$NAME", item.Name);
                    cmd.Parameters.AddWithValue("$PRICE", item.Price);
                    item.Id = (long)cmd.ExecuteScalar();

                    item.Dirty = false;

                }
            }
            conn.Close();

            // jetzt noch alle als zu löschend markierte Items aus der Collection entfernen

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Deleted)
                {
                    Remove(this[i]);
                }
            }
        }

        public void ReadFromDB(string filename)
        {
            Clear();
            SQLiteConnection conn = CreateConnection(filename);

            SQLiteCommand cmd = new SQLiteCommand(conn);

            cmd.CommandText = "SELECT name, price, id FROM article";
            SQLiteDataReader sQLiteDataReader = cmd.ExecuteReader();

            while (sQLiteDataReader.Read())
            {
                Article article = new Article(sQLiteDataReader.GetString(0), sQLiteDataReader.GetDouble(1));
                long id = sQLiteDataReader.GetInt64(2);
                article.Id = id;
                Add(article);
            }

            conn.Close();
        }

        public void SaveToDB(string filename)
        {
            SQLiteConnection conn = CreateConnection(filename);

            SQLiteCommand cmd = new SQLiteCommand(conn);

            // lösche - falls vorhanden - die Tabelle article
            cmd.CommandText = "DROP TABLE IF EXISTS article";
            cmd.ExecuteNonQuery();

            // Erzeuge die Tabelle article mit den Feldern id, name und price
            cmd.CommandText = "CREATE TABLE article(id INTEGER PRIMARY KEY, name TEXT, price DOUBLE)";
            cmd.ExecuteNonQuery();  // führe das SQL Kommando aus

            foreach (Article item in this)
            {
                // ACHTUNG: Dezimaltrennzeichen beachten -> für de-AT wird nämlich ',' als Dezimaltrenner verwendet
                cmd.CommandText = $"INSERT INTO article(name, price) " +
                    $"VALUES('{item.Name}', {item.Price.ToString(CultureInfo.GetCultureInfo("en-US"))})" +
                    $"SELECT last_insert_rowid();"; // die id des gerade eingefügten Datensatzes
                item.Id = (long)cmd.ExecuteScalar();
            }

            conn.Close();
        }

        public void RemoveByID(long id)
        {
            foreach(var item in this)
            {
                if (item.Id == id)
                {
                    item.Deleted = true;
                    break;
                }
            }
        }

        public Article GetArticleByID(long id)
        {
            foreach (var item in this)
            {
                
                if ( item.Id == id)
                {
                    return item;
                }
                
            }

            return null;
        }
    }
}
    