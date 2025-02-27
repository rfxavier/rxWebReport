using System;

namespace rxWebReport.Domain.Entities
{
    public partial class GetLockMovimento
    {
        public long id { get; set; }
        public string data_type { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public Nullable<System.DateTime> trackLastWriteTime { get; set; }
        public Nullable<System.DateTime> trackCreationTime { get; set; }
    }
}
