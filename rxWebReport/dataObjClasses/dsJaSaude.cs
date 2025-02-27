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
            public string nome { get; set; }
            public string item { get; set; }

            public decimal valor { get; set; }
            public DateTime date { get; set; }
        }

        public static List<dadosSensor> GetData()
        {
            var results = new List<dadosSensor>();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("select h.name as Nome, i.name item, h2.value as Temperatura, DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') as Data from hosts h inner join items i on i.hostid = h.hostid inner join history h2 on h2.itemid =i.itemid where h.name like 'TTU%' and i.name LIKE 'TTU%' and DATE_FORMAT(FROM_UNIXTIME(h2.clock), '%Y-%m-%d %H:%i:%s') between '2025-02-21' and '2025-02-22'", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new dadosSensor
                            {
                                nome = reader.GetString("Nome"),
                                item  = reader.GetString("item"),
                                valor = reader.GetDecimal("Temperatura"),
                                date = reader.GetDateTime("Data")
                            });
                        }
                    }
                }
            }

            return results;
        }
    }
}