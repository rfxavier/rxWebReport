using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockLojaClienteRedeViewConfig : EntityTypeConfiguration<GetLockLojaClienteRedeView>
    {
        public GetLockLojaClienteRedeViewConfig()
        {
            // Primary Key
            this.HasKey(t => t.id_loja);

            // Properties
            this.Property(t => t.cod_loja)
                .HasMaxLength(50);

            this.Property(t => t.nome_loja)
                .HasMaxLength(50);

            this.Property(t => t.id_cliente);

            this.Property(t => t.cod_cliente)
                .HasMaxLength(50);

            this.Property(t => t.nome_cliente)
                .HasMaxLength(50);

            this.Property(t => t.id_rede);

            this.Property(t => t.cod_rede)
                .HasMaxLength(50);

            this.Property(t => t.nome_rede)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("loja_cliente_rede_view");
            this.Property(t => t.id_loja).HasColumnName("id_loja");
            this.Property(t => t.cod_loja).HasColumnName("cod_loja");
            this.Property(t => t.nome_loja).HasColumnName("nome_loja");
            this.Property(t => t.id_cliente).HasColumnName("id_cliente");
            this.Property(t => t.cod_cliente).HasColumnName("cod_cliente");
            this.Property(t => t.nome_cliente).HasColumnName("nome_cliente");
            this.Property(t => t.id_rede).HasColumnName("id_rede");
            this.Property(t => t.cod_rede).HasColumnName("cod_rede");
            this.Property(t => t.nome_rede).HasColumnName("nome_rede");
        }
    }
}
