using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockGetStatusBitProfileConfig: EntityTypeConfiguration<GetLockGetStatusBitProfile>
    {
        public GetLockGetStatusBitProfileConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_get_status_bit_profile");
        }
    }
}