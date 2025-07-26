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
            public string Trigger_tag { get; set; }
            public string Trigger_value { get; set; }
        }

        public class dadosJustificativas
        {
            public string Distribuidor { get; set; }
            public string Sensor { get; set; }
            public DateTime DataEvento { get; set; }
            public string Mensagem { get; set; }
            public DateTime DataMensagem { get; set; }
            public string Query { get; set; }
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

        public static List<dadosTriggers> GetDataTriggers(string TriggerTag, string InitialDate, string FinalDate)
        {
            var results = new List<dadosTriggers>();

            if (TriggerTag != "")
            {

                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = $@"
                                 SELECT
                                  CONVERT_TZ(FROM_UNIXTIME(e.clock), '+00:00', '+00:00') AS tm,
                                  e.value,
                                  e.acknowledged,
                                  t.description, tt.tag trigger_tag, tt.value trigger_value
                                FROM events e
                                  INNER JOIN triggers t
                                    ON e.objectid = t.triggerid
                                  INNER JOIN trigger_tag tt
                                    ON t.triggerid = tt.triggerid
                                WHERE e.source = 0
                                AND e.object = 0
                                AND CONVERT_TZ(FROM_UNIXTIME(e.clock), '+00:00', '+00:00') BETWEEN '{InitialDate}' AND '{FinalDate}'
                                and tt.tag = '{TriggerTag}'
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
                                    Description = reader.GetString("description"),
                                    Trigger_tag = reader.GetString("trigger_tag"),
                                    Trigger_value = reader.GetString("trigger_value")
                                });
                            }
                        }
                    }
                }

            }

            return results;
        }

        public static List<dadosJustificativas> GetDataJustificativas(string HostName, string InitialDate, string FinalDate)
        {
            var results = new List<dadosJustificativas>();

            if (HostName != "")
            {

                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = $@"
                                    SELECT
                                      h.name as 'Distribuidor',
                                      e.name as 'Sensor',
                                      DATE_FORMAT(FROM_UNIXTIME(e.clock), '%Y-%m-%d %H:%i:%s') as 'DataEvento',
                                      max(a.message) as 'Mensagem',
                                      DATE_FORMAT(FROM_UNIXTIME(a.clock), '%Y-%m-%d %H:%i:%s') as 'DataMensagem' 
                                    FROM hosts h 
                                      inner join items i on i.hostid = h.hostid
                                      inner join functions f on f.itemid = i.itemid
                                      inner join triggers t on t.triggerid = f.triggerid 
                                      inner join events e on e.objectid = t.triggerid
                                      inner join acknowledges a on a.eventid = e.eventid
                                    WHERE h.name in ('{HostName}') and DATE_FORMAT(FROM_UNIXTIME(e.clock), '%Y-%m-%d %H:%i:%s') between '{InitialDate}' AND '{FinalDate}' and a.userid = 23
                                    -- WHERE (h.name in ('{HostName}') or 0=0) and DATE_FORMAT(FROM_UNIXTIME(e.clock), '%Y-%m-%d %H:%i:%s') between '{InitialDate}' AND '{FinalDate}' and ((a.userid = 23) or 0=0)
                                    GROUP BY
                                      h.name,
                                      e.name,
                                      a.message,
                                      e.clock,
                                      a.clock
                                     ORDER BY 
                                     e.clock,
                                     a.clock";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new dadosJustificativas
                                {
                                    Distribuidor = reader.GetString("Distribuidor"),
                                    Sensor = reader.GetString("Sensor"),
                                    DataEvento = reader.GetDateTime("DataEvento"),
                                    Mensagem = reader.GetString("Mensagem"),
                                    DataMensagem = reader.GetDateTime("DataMensagem"),
                                    Query = query
                                });
                            }
                        }
                    }

                    //results.Add(new dadosJustificativas
                    //{
                    //    Distribuidor = "",
                    //    Sensor = "",
                    //    DataEvento = DateTime.Now,
                    //    Mensagem = "",
                    //    DataMensagem = DateTime.Now,
                    //    Query = query
                    //});
                }

            }

            return results;
        }
    }
}
