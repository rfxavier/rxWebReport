using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockCofreConfig : EntityTypeConfiguration<GetLockCofre>
    {
        public GetLockCofreConfig()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id_cofre)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.nome)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.serie)
                .HasMaxLength(50);

            this.Property(t => t.tipo)
                .HasMaxLength(50);

            this.Property(t => t.marca)
                .HasMaxLength(50);

            this.Property(t => t.modelo)
                .HasMaxLength(50);

            this.Property(t => t.tamanho_malote)
                .HasMaxLength(50);

            this.Property(t => t.cod_loja)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("cofre");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_cofre).HasColumnName("id_cofre");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.serie).HasColumnName("serie");
            this.Property(t => t.tipo).HasColumnName("tipo");
            this.Property(t => t.marca).HasColumnName("marca");
            this.Property(t => t.modelo).HasColumnName("modelo");
            this.Property(t => t.tamanho_malote).HasColumnName("tamanho_malote");
            this.Property(t => t.trackLastWriteTime).HasColumnName("trackLastWriteTime");
            this.Property(t => t.trackCreationTime).HasColumnName("trackCreationTime");
            this.Property(t => t.cod_loja).HasColumnName("cod_loja");

            // Relationships
            //this.HasMany<Models.ApplicationUser>(t => t.ApplicationUsers)
            //    .WithMany(u => u.GetLockCofres)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("id_cofre"); // Link to id_cofre
            //        m.MapRightKey("UserId"); // ApplicationUser Id
            //        m.ToTable("AspNetUserCofres");
            //    });
        }
    }
}
