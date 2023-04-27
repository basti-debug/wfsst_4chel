namespace DB_Artikel_Model
{
    public class Article
    {
        private string name;
        private double price;

        public Article(string name, double price) : this()
        {
            Name = name;
            Price = price;
        }

        public Article()
        {
            Dirty = false;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                Dirty = true;
            }
        }

        public double Price
        {
            get => price;
            set
            {
                price = value;
                Dirty = true;
            }
        }

        public bool Dirty { get; set; }
        public long Id { get; set; } = -1;
        public bool Deleted { get; internal set; }

        public override string ToString()
        {
            return $"ID: {Id} - {Name}: {Price:0.00}€";
        }
    }
}