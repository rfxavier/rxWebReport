using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockCofreUserConfig : EntityTypeConfiguration<GetLockCofreUser>
    {
        public GetLockCofreUserConfig()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id_cofre)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.data_user)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.nome)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("cofre_user");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_cofre).HasColumnName("id_cofre");
            this.Property(t => t.data_user).HasColumnName("data_user");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.trackLastWriteTime).HasColumnName("trackLastWriteTime");
            this.Property(t => t.trackCreationTime).HasColumnName("trackCreationTime");
        }
    }
}
