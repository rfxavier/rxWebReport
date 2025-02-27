using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockClienteConfig : EntityTypeConfiguration<GetLockCliente>
    {
        public GetLockClienteConfig()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.cod_cliente)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.nome)
                .HasMaxLength(50);

            this.Property(t => t.cod_rede)
                .HasMaxLength(50);

            this.Property(t => t.razao_social)
                .HasMaxLength(50);

            this.Property(t => t.cnpj)
                .HasMaxLength(50);

            this.Property(t => t.endereco)
                .HasMaxLength(60);

            this.Property(t => t.complemento)
                .HasMaxLength(60);

            this.Property(t => t.bairro)
                .HasMaxLength(50);

            this.Property(t => t.cidade)
                .HasMaxLength(50);

            this.Property(t => t.uf)
                .HasMaxLength(20);

            this.Property(t => t.CEP)
                .HasMaxLength(10);

            this.Property(t => t.pessoa_contato)
                .HasMaxLength(50);

            this.Property(t => t.email)
                .HasMaxLength(100);

            this.Property(t => t.telefone)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("cliente");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.cod_cliente).HasColumnName("cod_cliente");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.cod_rede).HasColumnName("cod_rede");
            this.Property(t => t.trackLastWriteTime).HasColumnName("trackLastWriteTime");
            this.Property(t => t.trackCreationTime).HasColumnName("trackCreationTime");
            this.Property(t => t.razao_social).HasColumnName("razao_social");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.endereco).HasColumnName("endereco");
            this.Property(t => t.complemento).HasColumnName("complemento");
            this.Property(t => t.bairro).HasColumnName("bairro");
            this.Property(t => t.cidade).HasColumnName("cidade");
            this.Property(t => t.uf).HasColumnName("uf");
            this.Property(t => t.CEP).HasColumnName("CEP");
            this.Property(t => t.latitude).HasColumnName("latitude");
            this.Property(t => t.longitude).HasColumnName("longitude");
            this.Property(t => t.pessoa_contato).HasColumnName("pessoa_contato");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.telefone).HasColumnName("telefone");
        }
    }
}
