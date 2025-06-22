using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace rxWebReport.dataObjClasses
{
    public class dsMicroset
    {
        //private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        //private static readonly string connectionString = "Server=201.16.197.252;Database=zabbix;User Id=jasaude2;Password=C4m4l340;SslMode=None;";
        private static readonly string connectionString = "Server=191.5.132.18;;Port=55336;Database=zabbix;User Id=agyliti;Password=Ag@x2020!;SslMode=None;";

        public class dadosSensor
        {
            public string Groupname { get; set; }
            public string Hostname { get; set; }
            public string Item { get; set; }
            public decimal Value { get; set; }
            public DateTime SensorDate { get; set; }
        }

        public class dadosTriggers
        {
            public int Value { get; set; }
            public int Acknowledged { get; set; }
            public DateTime Time { get; set; }
            public string Description { get; set; }
        }

        public static List<dadosSensor> GetData(string GroupName, string HostName, string Item, string InitialDate, string FinalDate)
        {
            var results = new List<dadosSensor>();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = $@"select
                                    hgrp.name as Groupname,
	                                h.name as Hostname,
                                    i.name as Item,
	                                h2.value as Value,
	                                DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') as SensorDate
                                  from
	                                hosts h
                                  inner join items i on
	                                i.hostid = h.hostid
                                  inner join hosts_groups hg on
	                                hg.hostid = h.hostid
                                  inner join hstgrp hgrp on
	                                hgrp.groupid = hg.groupid
                                  inner join history h2 on
                                    h2.itemid = i.itemid
                                  where
                                    hgrp.name = '{GroupName}'
                                    and h.name = '{HostName}'
                                    and i.name = '{Item}'
                                    and DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') BETWEEN '{InitialDate}' AND '{FinalDate}'
                                  order by h2.clock";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new dadosSensor
                            {
                                Groupname = reader.GetString("Groupname"),
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

        public static List<dadosTriggers> GetDataTriggers(string ItemPrefix, string InitialDate, string FinalDate)
        {
            var results = new List<dadosTriggers>();

            // Determine the item name filter based on ValueType
            string itemNameFilter = $@"{ItemPrefix}%";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = $@"
                                 SELECT
                                  CONVERT_TZ(FROM_UNIXTIME(e.clock), '+00:00', '+00:00') AS tm,
                                  e.value,
                                  e.acknowledged,
                                  t.description
                                FROM events e
                                  INNER JOIN triggers t
                                    ON e.objectid = t.triggerid
                                  INNER JOIN trigger_tag tt
                                    ON t.triggerid = tt.triggerid
                                WHERE e.source = 0
                                AND e.object = 0
                                AND CONVERT_TZ(FROM_UNIXTIME(e.clock), '+00:00', '+00:00') BETWEEN '{InitialDate}' AND '{FinalDate}'
                                and t.description like '{itemNameFilter}%'
                                order by e.clock";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new dadosTriggers
                            {
                                Value = reader.GetInt32("value"),
                                Acknowledged = reader.GetInt32("acknowledged"),
                                Time = reader.GetDateTime("tm"),
                                Description = reader.GetString("description")
                            });
                        }
                    }
                }
            }

            return results;
        }
    }

}
