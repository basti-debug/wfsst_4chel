using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleModel
{
    public class Vehicle
    {
        const char SEPERATOR = '§';

        public string licensplate { get; set; }
        public double fuellevel { get; set; }

        public string location { get; set; }

        public bool avalible { get; set; }

        public string model { get; set; }

        public double totaldist { get; set; }

        public Vehicle(string Licensplate, string Location, double FuelLevel, bool IsAvailable, string Model, double TotalDist)
        {
            this.licensplate = Licensplate;
            this.location = Location;
            this.fuellevel = FuelLevel;
            this.avalible = IsAvailable;
            this.model = Model;
            this.totaldist = TotalDist;
        }

        public override string ToString()
        {
            //inline if: Bedingung ? True : false;
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
