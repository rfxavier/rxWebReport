using System;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckUpdateFirmware
    {
        public long Id { get; set; }
        public string TopicDeviceId { get; set; }
        public int Destiny { get; set; }
        public bool IsAck { get; set; }
        public string Timestamp { get; set; }

        public string UpdateFirmware { get; set; }
        public Nullable<System.DateTime> TimestampDatetime { get; set; }
        public Nullable<System.DateTime> trackLastWriteTime { get; set; }
        public Nullable<System.DateTime> trackCreationTime { get; set; }
    }
}