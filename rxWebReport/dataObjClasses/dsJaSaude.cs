using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace rxWebReport.dataObjClasses
{
    public class dsJaSaude
    {
        //private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        private static readonly string connectionString = "Server=201.16.197.252;Database=zabbix;User Id=jasaude2;Password=C4m4l340;SslMode=None;";

        public class dadosSensor
        {
            public string Hostname { get; set; }
            public string Item { get; set; }
            public string MeasurementType { get; set; }
            public decimal Value { get; set; }
            public DateTime SensorDate { get; set; }
        }

        public class dadosSensorPivoted
        {
            public string Hostname { get; set; }
            public string Item { get; set; }
            public decimal ValueTemperature { get; set; }
            public decimal ValueHumidity { get; set; }
            public DateTime SensorDate { get; set; }
        }

        public static List<dadosSensor> GetData(string InitialDate, string FinalDate)
        {
            var results = new List<dadosSensor>();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = $@"select h.name as Hostname, i.name Item, h2.value Value, DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') as SensorDate from hosts h inner join items i on i.hostid = h.hostid inner join history h2 on h2.itemid = i.itemid where h.name like 'TTU%' and i.name LIKE 'TTU%' and DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') between '{InitialDate}' AND '{FinalDate}'";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader.GetString("Item");
                            string measurementType = itemName.EndsWith("Temperatura") ? "Temperatura" :
                                                     itemName.EndsWith("Humidade") ? "Humidade" : "";

                            results.Add(new dadosSensor
                            {
                                Hostname = reader.GetString("Hostname"),
                                Item = reader.GetString("Item"),
                                MeasurementType = measurementType,
                                Value = reader.GetDecimal("Value"),
                                SensorDate = reader.GetDateTime("SensorDate")
                            });
                        }
                    }
                }
            }

            return results;
        }

        public static List<dadosSensor> GetData(string ItemPrefix, string InitialDate, string FinalDate)
        {
            var results = new List<dadosSensor>();

            // Determine the item name filter based on ValueType
            string itemNameFilter = $@"{ItemPrefix}%";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = $@"select h.name as Hostname, i.name Item, h2.value Value, DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') as SensorDate from hosts h inner join items i on i.hostid = h.hostid inner join history h2 on h2.itemid = i.itemid where h.name like 'TTU%' and i.name LIKE '{itemNameFilter}' and DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') between '{InitialDate}' AND '{FinalDate}'";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader.GetString("Item");
                            string measurementType = itemName.EndsWith("Temperatura") ? "Temperatura" :
                                                     itemName.EndsWith("Humidade") ? "Humidade" : "";

                            results.Add(new dadosSensor
                            {
                                Hostname = reader.GetString("Hostname"),
                                Item = reader.GetString("Item"),
                                MeasurementType = measurementType,
                                Value = reader.GetDecimal("Value"),
                                SensorDate = reader.GetDateTime("SensorDate")
                            });
                        }
                    }
                }
            }

            return results;
        }

        public static List<dadosSensor> GetData(string ItemPrefix, string ValueType, string InitialDate, string FinalDate)
        {
            var results = new List<dadosSensor>();

            // Determine the item name filter based on ValueType
            string itemNameFilter = ValueType == "T" ? $@"{ItemPrefix}%Temperatura" : "TTU%Humidade";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = $@"select h.name as Hostname, i.name Item, h2.value Value, DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') as SensorDate from hosts h inner join items i on i.hostid = h.hostid inner join history h2 on h2.itemid = i.itemid where h.name like 'TTU%' and i.name LIKE '{itemNameFilter}' and DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') between '{InitialDate}' AND '{FinalDate}'";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new dadosSensor
                            {
                                Hostname = reader.GetString("Hostname"),
                                Item = reader.GetString("Item"),
                                Value = reader.GetDecimal("Value"),
                                SensorDate = reader.GetDateTime("SensorDate")
                            });
                        }
                    }
                }
            }

            return results;
        }

        public static List<dadosSensorPivoted> GetDataPivoted(string ItemPrefix, string InitialDate, string FinalDate)
        {
            var results = new List<dadosSensorPivoted>();
            var intermediateData = new Dictionary<(string ItemBase, DateTime SensorDate), dadosSensorPivoted>();

            // Determine the item name filter based on ItemPrefix
            string itemNameFilter = $@"{ItemPrefix}%";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = $@"
                                SELECT h.name AS Hostname, 
                                       i.name AS Item, 
                                       h2.value AS Value, 
                                       DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') AS SensorDate
                                FROM hosts h
                                INNER JOIN items i ON i.hostid = h.hostid
                                INNER JOIN history h2 ON h2.itemid = i.itemid
                                WHERE h.name LIKE 'TTU%' 
                                AND i.name LIKE '{itemNameFilter}' 
                                AND DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') 
                                BETWEEN '{InitialDate}' AND '{FinalDate}'";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader.GetString("Item");
                            DateTime sensorDate = reader.GetDateTime("SensorDate");
                            string itemBase = itemName.EndsWith("Temperatura") ? itemName.Substring(0, itemName.Length - "Temperatura".Length) :
                                              itemName.EndsWith("Humidade") ? itemName.Substring(0, itemName.Length - "Humidade".Length) : itemName;

                            if (!intermediateData.ContainsKey((itemBase, sensorDate)))
                            {
                                intermediateData[(itemBase, sensorDate)] = new dadosSensorPivoted
                                {
                                    Hostname = reader.GetString("Hostname"),
                                    Item = itemBase,
                                    SensorDate = sensorDate
                                };
                            }

                            var pivotedData = intermediateData[(itemBase, sensorDate)];

                            if (itemName.EndsWith("Temperatura"))
                            {
                                pivotedData.ValueTemperature = reader.GetDecimal("Value");
                            }
                            else if (itemName.EndsWith("Humidade"))
                            {
                                pivotedData.ValueHumidity = reader.GetDecimal("Value");
                            }
                        }
                    }
                }
            }

            // Collect the final list from the dictionary
            results.AddRange(intermediateData.Values);

            return results;
        }


    }
}