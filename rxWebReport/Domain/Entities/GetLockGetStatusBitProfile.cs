using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rxWebReport.Domain.Entities
{
    public class GetLockGetStatusBitProfile
    {
        public long Id { get; set; }
        public string StatusType { get; set; } // DeviceStatus, BillMachineStatus, BillMachineError
        public int Bit { get; set; } // 0...31
        public string Caption { get; set; }

    }
}