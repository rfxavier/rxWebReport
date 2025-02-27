using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckGetStatusConfig: EntityTypeConfiguration<GetLockMessageAckGetStatus>
    {
        public GetLockMessageAckGetStatusConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_get_status");
        }
    }
}