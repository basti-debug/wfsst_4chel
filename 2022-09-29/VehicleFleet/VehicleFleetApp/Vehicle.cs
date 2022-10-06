using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFleetApp
{
    class Vehicle
    {
        const char SEPERATOR = '§';

        private string licensplate
        {
            get { return licensplate; }
            set { licensplate = value; }
        }
        private double fuellevel
        {
            get { return fuellevel; }
            set { fuellevel = value; }
        }

        private string location
        {
            get { return location; }
            set { location = value; }
        }

        private bool avalible
        {
            get { return avalible; }
            set { avalible = value; }
        }

        private string model
        {
            get { return model; }
            set { model = value; }
        }

        private double totaldist
        {
            get { return totaldist; }
            set { totaldist = value; }
        }

        public Vehicle(string licenseplate, string location, double fuelLevel, bool isAvailable, string model, double totalDist)
        {
            this.licensplate = licenseplate;
            this.location = location;
            this.fuellevel = fuelLevel;
            this.avalible = isAvailable;
            this.model = model;
            this.totaldist = totalDist;
        }

        public override string ToString()
        {
            string avail = avalible ? "" : "Nicht ";
            return $"{model}  ({licensplate}): {avail} verfügbar";
        }

        /// <summary>
        /// saves objectdata in one string 
        /// </summary>
        /// <returns>object as string</returns>
        public string Serialize()
        {
            return $"{licensplate}{SEPERATOR}{location}{SEPERATOR}" +
                $"{fuellevel}{SEPERATOR}{avalible}{SEPERATOR}{model}{SEPERATOR}{totaldist}";
        }

        public static Vehicle Parse(string data)
        {
            string[] tokens = data.Split(SEPERATOR);
            return new Vehicle(tokens[0], tokens[1], double.Parse(tokens[2]), bool.Parse(tokens[3]), tokens[4], double.Parse(tokens[5]));
        }
    }
}
