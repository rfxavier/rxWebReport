using System;

namespace rxWebReport.Domain.Entities
{
    public class GetLockApiLog
    {
        public long Id { get; set; }
        public string ApiName { get; set; }
        public string UserName { get; set; }
        public string CofreId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Error { get; set; }
        public string Response { get; set; }
        public Nullable<System.DateTime> TrackLastWriteTime { get; set; }
        public Nullable<System.DateTime> TrackCreationTime { get; set; }
    }
}