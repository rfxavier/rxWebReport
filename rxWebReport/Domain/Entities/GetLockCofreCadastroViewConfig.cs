using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockCofreCadastroViewConfig: EntityTypeConfiguration<GetLockCofreCadastroView>
    {
        public GetLockCofreCadastroViewConfig()
        {
            // Primary Key
            this.HasKey(t => t.id_cofre);

            this.ToTable("cofre_cadastro_view");
        }
    }
}