namespace rxWebReport.Domain.Entities
{
    public partial class GetLockLojaClienteRedeView
    {
        public long id_loja { get; set; }
        public string cod_loja { get; set; }
        public string nome_loja { get; set; }
        public long id_cliente { get; set; }
        public string cod_cliente { get; set; }
        public string nome_cliente { get; set; }
        public long id_rede { get; set; }
        public string cod_rede { get; set; }
        public string nome_rede { get; set; }
    }
}
