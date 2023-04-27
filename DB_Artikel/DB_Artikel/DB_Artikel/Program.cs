using DB_Artikel_Model;
using System.Text;

namespace DB_Artikel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArticleList articles = new ArticleList();
            ConsoleColor defColor = Console.ForegroundColor;

            //articles.Add(new Article() { Name = "Brötle", Price = 1.2 });
            //articles.Add(new Article("Semmile", 0.7));
            //articles.Add(new Article() { Name = "Säftle", Price = 2.3 });

            //articles.SaveToDB("articles.sqlite");

            articles.ReadFromDB("articles.sqlite");

            PrintTable(articles, defColor);

            // ein paar Daten ändern
            Console.WriteLine("\nEin paar Änderungen");
            articles[1].Name = "Semmeln";
            articles.Update("articles.sqlite");

            // Datensatz einfügen
            articles.Add(new Article("Kaffee", 0.5));

            // Datensatz lösen
            articles.RemoveByID(1);

            //CRUD ... Create (datensatz)

            articles.Update("articles.sqlite");

            Console.WriteLine("\nVor dem erneuten Lesen aus der DB");
            PrintTable(articles, defColor);

            articles.ReadFromDB("articles.sqlite");

            Console.WriteLine("\nNach dem erneuten Lesen aus der DB");
            PrintTable(articles, defColor);
            
            Console.WriteLine("\nWelchen Datensatz wollen sie ändern?");
            long index=long.Parse(Console.ReadLine());

            Article actArticle = articles.GetArticleByID(index);

            Console.Write("Neuer Name: ");
            actArticle.Name = Console.ReadLine();
            Console.Write("Neuer Preis: ");
            string price = Console.ReadLine();
            actArticle.Price = double.Parse(price);

            articles.Update("articles.sqlite");
            PrintTable(articles, defColor); 
        }

        private static void PrintTable(ArticleList articles, ConsoleColor defColor)
        {
            Console.WriteLine($"{"ID",4} | {"Name",-20} | Preis");
            Console.WriteLine("-----+----------------------+---------------");
            Console.OutputEncoding = Encoding.UTF8;
            foreach (Article item in articles)
            {
                Console.Write($"{item.Id,4} | ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{item.Name,-20}");
                Console.ForegroundColor = defColor;
                Console.WriteLine($" | {item.Price,10:#,##0.00} €");
            }
            Console.WriteLine("-----+----------------------+---------------");
        }
    }
}