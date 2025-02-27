using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckUpdateFirmwareConfig: EntityTypeConfiguration<GetLockMessageAckUpdateFirmware>
    {
        public GetLockMessageAckUpdateFirmwareConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_update_firmware");
        }
    }
}