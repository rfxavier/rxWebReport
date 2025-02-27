using rxWebReport.Models;
using System;
using System.Collections.Generic;

namespace rxWebReport.Domain.Entities
{
    public partial class GetLockLoja
    {
        public long id { get; set; }
        public string cod_loja { get; set; }
        public string cod_cliente { get; set; }
        public string nome { get; set; }
        public Nullable<System.DateTime> trackLastWriteTime { get; set; }
        public Nullable<System.DateTime> trackCreationTime { get; set; }
        public string razao_social { get; set; }
        public string cnpj { get; set; }
        public string endereco { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string CEP { get; set; }
        public Nullable<decimal> latitude { get; set; }
        public Nullable<decimal> longitude { get; set; }
        public string pessoa_contato { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}
