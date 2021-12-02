using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Coursework.business;
using Microsoft.VisualBasic.FileIO;

namespace Coursework.data
{
    /// <summary>
    /// <para>Sealed class representing a store</para>
    /// <para>Design pattern: Singleton</para>
    /// <para>Handles CSV I/O</para>
    /// </summary>
    public sealed class Store
    {
        private FileInfo _courierPath;  //File path to courier CSV file
        private FileInfo _parcelPath;   //File path to parcel CSV file
        private TextFieldParser _parser; //Parser for CSV files

        private static Store _instance; //Static object instance (Singleton) 

        /// <summary>
        /// <para>Private base constructor (Singleton)</para>
        /// <para>Defines attributes</para>
        /// <para>Checks if CSV files exist otherwise creates them</para>
        /// </summary>
        private Store() 
        {
            if (!File.Exists("couriers.csv"))
            {
                File.Create("couriers.csv").Close(); //Since FileCreate opens up a stream, it needs to be closed afterwards
            }
            if (!File.Exists("parcels.csv"))
            {
                File.Create("parcels.csv").Close(); //Since FileCreate opens up a stream, it needs to be closed afterwards
            }

            _courierPath = new FileInfo("couriers.csv");
            _parcelPath = new FileInfo("parcels.csv");

        }

        /// <summary>
        /// <para>GetInstance method (Singleton not thread safe)</para>
        /// <para>Controls instantiation</para>
        /// </summary>
        /// <param name="subject">Subject to be observed (Observer)</param>
        /// <returns>Single Store instance</returns>
        public static Store GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Store();
            }
            return _instance;
        }

        /// <summary>
        /// <para>Exports all couriers and parcels into CSV files</para>
        /// </summary>
        /// <param name="couriers">Dictionary of couriers </param>
        /// <param name="parcels">Dictionary of parcels</param>
        public void Save(Dictionary<string, Courier> couriers ,Dictionary<string, Parcel> parcels)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            //Save all the courier into csv
            var allCouriers = couriers.Values.ToList();
            foreach (Courier c in allCouriers)
            {
                stringBuilder.AppendLine(c.ToCSV());
            }

            File.WriteAllText(_courierPath.FullName, stringBuilder.ToString());

            stringBuilder.Clear();

            //Save all the parcels into csv
            var allParcels = parcels.Values.ToList();
            foreach (Parcel p in allParcels)
            {
                stringBuilder.AppendLine(p.ToCSV());
            }
            File.WriteAllText(_parcelPath.FullName, stringBuilder.ToString());
        }

        /// <summary>
        /// <para>Imports all parcels from CSV file</para>
        /// <para>Uses Microsoft.VisualBasic.FileIO.TextFieldParser to parse CSV fields</para>
        /// </summary>
        /// <returns>Dictionary of imported parcels</returns>
        public Dictionary<string, Parcel> LoadParcels()
        {
            Dictionary<string, Parcel> parcels = new Dictionary<string, Parcel>();

            string[] rows = File.ReadAllLines(_parcelPath.FullName);
            foreach (string row in rows)
            {
                List<string> columns = new List<string>();
                using (_parser = new TextFieldParser(new StringReader(row)))
                {
                    _parser.SetDelimiters(",");
                    _parser.HasFieldsEnclosedInQuotes = true;
                    columns = _parser.ReadFields().ToList();

                }
                Parcel parcel = new Parcel(columns[0], columns[1], columns[2], columns[3], columns[4]);
                parcels.Add(columns[0], parcel);
            }
            return parcels;
        }

        /// <summary>
        /// <para>Imports all couriers from CSV file </para>
        /// <para>Uses Microsoft.VisualBasic.FileIO.TextFieldParser to parse CSV fields</para>
        /// </summary>
        /// <returns>Dictionary of imported couriers</returns>
        public Dictionary<string, Courier> LoadCouriers()
        {
            Dictionary<string, Courier> couriers = new Dictionary<string, Courier>();

            string[] rows = File.ReadAllLines(_courierPath.FullName);
            foreach (string row in rows)
            {
                List<string> columns = new List<string>();
                using (_parser = new TextFieldParser(new StringReader(row))) {
                    _parser.SetDelimiters(",");
                    columns = _parser.ReadFields().ToList();
                }

                switch (columns[0])
                {
                    case "VanCourier":
                        List<string> areas = new List<string>();
                        for (int i = 2; i < columns.Count; i++)
                        {
                            areas.Add(columns[i]);
                        }
                        VanCourier vanCourier = new VanCourier(columns[1], areas);
                        couriers.Add(vanCourier.Id, vanCourier);
                        break;
                    case "CycleCourier":
                        CycleCourier cycleCourier = new CycleCourier(columns[1], columns[2]);
                        couriers.Add(cycleCourier.Id, cycleCourier);
                        break;
                    case "WalkingCourier":
                        WalkingCourier walkingCourier = new WalkingCourier(columns[1], columns[2]);
                        couriers.Add(walkingCourier.Id, walkingCourier);
                        break;
                }
            }
            return couriers;
        }

        /// <summary>
        /// <para>Links all parcels with their respective couriers</para>
        /// <para>Assigns all related parcels to their assigned couriers</para>
        /// </summary>
        /// <param name="couriers">Dictionary of couriers</param>
        /// <param name="parcels">Dictionary of parcels</param>
        public void LinkCourierAndParcel(ref Dictionary<string, Courier> couriers, Dictionary<string, Parcel> parcels)
        {
            foreach (Parcel p in parcels.Values)
            {
                couriers[p.CourierId].AddParcel(p);
            }
        }
    }
}
