using System;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckDevLock
    {
        public long Id { get; set; }
        public string TopicDeviceId { get; set; }
        public int Destiny { get; set; }
        public bool DevLock { get; set; }
        public string Timestamp { get; set; }
        public bool IsAck { get; set; }
        public Nullable<System.DateTime> TimestampDatetime { get; set; }
        public Nullable<System.DateTime> trackLastWriteTime { get; set; }
        public Nullable<System.DateTime> trackCreationTime { get; set; }
    }
}