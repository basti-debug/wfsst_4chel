using System.Reflection.Metadata;

namespace DB_Übung_Model
{
    public class Adresses
    {
        private string givenname;
        private string surname;
        private DateTime dayofbirth;
        private string street;
        private string zip;
        private string city;
        private int telNr;
        
        public bool Deleted { get;internal set; }
        public bool Dirty { get; set; }
        public long Id { get; set; } = -1;

    }
}