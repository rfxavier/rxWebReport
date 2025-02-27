using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckUserListConfig: EntityTypeConfiguration<GetLockMessageAckUserList>
    {
        public GetLockMessageAckUserListConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_get_userlist");
        }
    }
}