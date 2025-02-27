using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckDevLockConfig: EntityTypeConfiguration<GetLockMessageAckDevLock>
    {
        public GetLockMessageAckDevLockConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_dev_lock");
        }
    }
}