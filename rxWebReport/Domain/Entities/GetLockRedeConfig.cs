using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockRedeConfig : EntityTypeConfiguration<GetLockRede>
    {
        public GetLockRedeConfig()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.cod_rede)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.nome)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("rede");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.cod_rede).HasColumnName("cod_rede");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.trackLastWriteTime).HasColumnName("trackLastWriteTime");
            this.Property(t => t.trackCreationTime).HasColumnName("trackCreationTime");
        }
    }
}
