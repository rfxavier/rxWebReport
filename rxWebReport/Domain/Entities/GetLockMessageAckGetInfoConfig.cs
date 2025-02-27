using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckGetInfoConfig: EntityTypeConfiguration<GetLockMessageAckGetInfo>
    {
        public GetLockMessageAckGetInfoConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_get_info");
        }
    }
}