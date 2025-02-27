//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using MySql.Data.MySqlClient;

//namespace rxWebReport.dataObjClasses
//{
//    public class dsJaSaude
//    {
//        private string connectionString;

//        public dsJaSaude()
//        {
//            // Get connection string from web.config
//            //connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
//        }

//        public class dadosSensor
//        {
//            public string nome { get; set; }
//            public string item { get; set; }

//            public decimal valor { get; set; }
//            public DateTime date { get; set; }
//        }

//        //public static List<dadosSensor> GetData()
//        //{
//        //    var results = new List<dadosSensor>();

//        //    using (var conn = new MySqlConnection(connectionString))
//        //    {
//        //        conn.Open();

//        //    }

//        //    return results;
//        //}
//    }
//}