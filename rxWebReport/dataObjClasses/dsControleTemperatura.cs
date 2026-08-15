using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace rxWebReport.dataObjClasses
{
    public class dsControleTemperatura
    {
        //private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        private static readonly string connectionString = "Server=201.16.197.252;Database=zabbix;User Id=jasaude2;Password=C4m4l340;SslMode=None;";

        public class dadosSensor
        {
            public string Groupname { get; set; }
            public string Hostname { get; set; }
            public string Item { get; set; }
            public decimal Value { get; set; }
            public DateTime SensorDate { get; set; }
            public bool HasData { get; set; }
        }

        public static List<dadosSensor> GetData(string GroupName, string HostName, string Item, string InitialDate, string FinalDate)
        {
            var results = new List<dadosSensor>();

            string connString = connectionString;

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = $@"select
                                    hgrp.name as Groupname,
	                                h.name as Hostname,
                                    i.name as Item,
	                                h2.value as Value,
	                                DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') as SensorDate,
                                    hi.type
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
                                  left outer join host_inventory hi ON 
                                    h.hostid = hi.hostid 
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
    }
}
