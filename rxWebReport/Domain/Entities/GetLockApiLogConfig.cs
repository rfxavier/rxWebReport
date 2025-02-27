using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockApiLogConfig : EntityTypeConfiguration<GetLockApiLog>
    {
        public GetLockApiLogConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("api_log");
        }
    }
}