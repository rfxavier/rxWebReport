using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckGetStatusViewConfig : EntityTypeConfiguration<GetLockMessageAckGetStatusView>
    {
        public GetLockMessageAckGetStatusViewConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_get_status_view");
        }
    }
}