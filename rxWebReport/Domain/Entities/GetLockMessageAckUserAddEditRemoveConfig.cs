using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckUserAddEditRemoveConfig : EntityTypeConfiguration<GetLockMessageAckUserAddEditRemove>
    {
        public GetLockMessageAckUserAddEditRemoveConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_user_add_edit_remove");
        }
    }
}