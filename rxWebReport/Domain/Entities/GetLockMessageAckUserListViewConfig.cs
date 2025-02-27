using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageAckUserListViewConfig : EntityTypeConfiguration<GetLockMessageAckUserListView>
    {
        public GetLockMessageAckUserListViewConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_get_userlist_view");
        }
    }
}