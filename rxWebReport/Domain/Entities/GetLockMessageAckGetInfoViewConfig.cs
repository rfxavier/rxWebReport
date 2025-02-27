using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckGetInfoViewConfig : EntityTypeConfiguration<GetLockMessageAckGetInfoView>
    {
        public GetLockMessageAckGetInfoViewConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_get_info_view");
        }
    }
}