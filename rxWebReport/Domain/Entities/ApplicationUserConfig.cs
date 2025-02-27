using System.Data.Entity.ModelConfiguration;
using rxWebReport.Models;

namespace rxWebReport.Domain.Entities
{
    public class ApplicationUserConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfig()
        {
            HasOptional(u => u.Company)
                .WithMany(c => c.ApplicationUsers)
                .HasForeignKey(u => u.CompanyId);

            HasOptional(u => u.GetLockLoja)
                .WithMany(l => l.ApplicationUsers)
                .HasForeignKey(u => u.GetLockLojaId);

            HasOptional(u => u.GetLockCliente)
                .WithMany(l => l.ApplicationUsers)
                .HasForeignKey(u => u.GetLockClienteId);

            HasMany<GetLockCofre>(u => u.GetLockCofres)
                .WithMany(c => c.ApplicationUsers)
                .Map(uc => {
                    uc.MapLeftKey("UserId");
                    uc.MapRightKey("id_cofre");
                    uc.ToTable("AspNetUserCofres");
                });
        }
    }
}