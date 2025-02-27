using System;

namespace rxWebReport.Domain.Entities
{
    public partial class GetLockSaldoCofreView
    {
        public long id { get; set; }
        public Nullable<System.DateTime> data_tmst_end_datetime { get; set; }
        public string id_cofre { get; set; }
        public string cofre_nome { get; set; }
        public string info_id { get; set; }
        public Nullable<decimal> balance { get; set; }
        public string balance_id { get; set; }
        public string cod_loja { get; set; }
        public long id_loja { get; set; }
        public string cod_cliente { get; set; }
        public long id_cliente { get; set; }
    }
}
