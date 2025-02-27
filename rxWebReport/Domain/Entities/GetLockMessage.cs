using System;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessage
    {
        public long id { get; set; }
        public string info_id { get; set; }
        public string info_ip { get; set; }
        public string info_mac { get; set; }
        public string info_json { get; set; }
        public string data_hash { get; set; }
        public string data_tmst_begin { get; set; }
        public string data_tmst_end { get; set; }
        public string data_user { get; set; }
        public string data_type { get; set; }
        public Nullable<decimal> data_currency_total { get; set; }
        public Nullable<long> data_currency_bill_2 { get; set; }
        public Nullable<long> data_currency_bill_5 { get; set; }
        public Nullable<long> data_currency_bill_10 { get; set; }
        public Nullable<long> data_currency_bill_20 { get; set; }
        public Nullable<long> data_currency_bill_50 { get; set; }
        public Nullable<long> data_currency_bill_100 { get; set; }
        public Nullable<long> data_currency_bill_200 { get; set; }
        public Nullable<long> data_currency_bill_rejected { get; set; }
        public Nullable<long> data_currency_envelope { get; set; }
        public Nullable<decimal> data_currency_envelope_total { get; set; }
        public string id_cofre { get; set; }
        public Nullable<System.DateTime> trackLastWriteTime { get; set; }
        public Nullable<System.DateTime> trackCreationTime { get; set; }
        public Nullable<System.DateTime> data_tmst_begin_datetime { get; set; }
        public Nullable<System.DateTime> data_tmst_end_datetime { get; set; }
        public string cod_loja { get; set; }
        public string cod_cliente { get; set; }
        public string cod_rede { get; set; }
        public Nullable<long> data_currency_bill { get; set; }
        public Nullable<long> data_currency_bill_total { get; set; }
        public Nullable<decimal> data_sensor { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string user_lastname { get; set; }
        public Nullable<decimal> balance { get; set; }
        public bool limit_deposit_enabled { get; set; }
        public Nullable<decimal> limit_deposit_value { get; set; }
        public string balance_id { get; set; }
    }
}
