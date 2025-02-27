using System;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckGetInfoView
    {
        public long Id { get; set; }
        public string TopicDeviceId { get; set; }
        public string CofreNome { get; set; }
        public int Destiny { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCNPJ { get; set; }
        public string DeviceSN { get; set; }
        public string DeviceFirmVersion { get; set; }
        public bool DeviceBlocked { get; set; }
        public string BillMachineType { get; set; }
        public string BillMachineSN { get; set; }
        public bool IsAck { get; set; }
        public string Timestamp { get; set; }
        public decimal Level { get; set; }

        public Nullable<System.DateTime> TimestampDatetime { get; set; }
        public Nullable<System.DateTime> trackLastWriteTime { get; set; }
        public Nullable<System.DateTime> trackCreationTime { get; set; }
    }
}