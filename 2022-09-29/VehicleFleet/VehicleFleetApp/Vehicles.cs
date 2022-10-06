using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VehicleFleetApp
{
    internal class Vehicles
    {
        private List<Vehicle> item; 

        public List<Vehicle> Items
        {
            get { return item; }
        }

        public Vehicles()
        {
            item = new List<Vehicle>();
        }

        public void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Vehicle item in item)
                {
                    writer.WriteLine(item.Serialize());
                }
                writer.Close();
            }
        }

        public void Open(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                Items.Clear();

                while (!reader.EndOfStream)
                {
                    Items.Add(Vehicle.Parse(reader.ReadLine()));
                }
                reader.Close();
            }
        }
    }
}
