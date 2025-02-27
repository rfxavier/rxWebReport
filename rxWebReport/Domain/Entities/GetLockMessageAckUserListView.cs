using System;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckUserListView
    {
        public long Id { get; set; }
        public string TopicDeviceId { get; set; }
        public string CofreNome { get; set; }
        public int Destiny { get; set; }
        public int Total { get; set; }
        public int UserIndex { get; set; }
        public int UserId { get; set; }
        public bool UserEnable { get; set; }
        public string UserAccessLevel { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserPasswd { get; set; }
        public string Timestamp { get; set; }
        public bool IsAck { get; set; }
        public Nullable<System.DateTime> TimestampDatetime { get; set; }
        public Nullable<System.DateTime> trackLastWriteTime { get; set; }
        public Nullable<System.DateTime> trackCreationTime { get; set; }
    }
}