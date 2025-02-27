using rxWebReport.Models;
using System;
using System.Collections.Generic;

namespace rxWebReport.Domain.Entities
{
    public class GetLockCofre
    {
        public long id { get; set; }
        public string id_cofre { get; set; }
        public string nome { get; set; }
        public string serie { get; set; }
        public string tipo { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string tamanho_malote { get; set; }
        public Nullable<System.DateTime> trackLastWriteTime { get; set; }
        public Nullable<System.DateTime> trackCreationTime { get; set; }
        public string cod_loja { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}
