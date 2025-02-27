using System;

namespace rxWebReport.Domain.Entities
{
    public partial class GetLockRede
    {
        public long id { get; set; }
        public string cod_rede { get; set; }
        public string nome { get; set; }
        public Nullable<System.DateTime> trackLastWriteTime { get; set; }
        public Nullable<System.DateTime> trackCreationTime { get; set; }
    }
}
