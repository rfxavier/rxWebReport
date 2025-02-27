using System;

namespace rxWebReport.Domain.Entities
{
    public partial class GetLockCofreUser
    {
        public long id { get; set; }
        public string id_cofre { get; set; }
        public string data_user { get; set; }
        public string nome { get; set; }
        public Nullable<System.DateTime> trackLastWriteTime { get; set; }
        public Nullable<System.DateTime> trackCreationTime { get; set; }
        public string sobrenome { get; set; }
        public string passwd { get; set; }
        public bool enable { get; set; }
        public string access_level { get; set; }
    }
}
