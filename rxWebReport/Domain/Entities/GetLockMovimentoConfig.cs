using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMovimentoConfig : EntityTypeConfiguration<GetLockMovimento>
    {
        public GetLockMovimentoConfig()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.data_type)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.nome)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.tipo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("movimento");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.data_type).HasColumnName("data_type");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.tipo).HasColumnName("tipo");
            this.Property(t => t.trackLastWriteTime).HasColumnName("trackLastWriteTime");
            this.Property(t => t.trackCreationTime).HasColumnName("trackCreationTime");
        }
    }
}
