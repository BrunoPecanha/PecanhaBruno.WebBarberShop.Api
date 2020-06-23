using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBaberShop.Infra.Data.EntityConfig {
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder) {

            builder
             .ToTable("Company")
             .HasKey(x => x.Id);

            builder
            .Property(c => c.RegisteringDate)
            .HasColumnName("RegisteringDate")
            .IsRequired();

            builder
            .Property(c => c.LastUpdate)
            .HasColumnName("LastUpdate");

            builder
            .Property(c => c.FantasyName)
            .HasColumnName("FantasyName");

            builder
            .Property(c => c.RealName)
            .HasColumnName("RealName");

            builder
           .Property(c => c.Cnpj)
           .HasColumnName("Cnpj");

            builder
           .Property(c => c.Address)
           .HasColumnName("Address");

            builder
           .Property(c => c.UseQueue)
           .HasColumnName("UseQueue")
           .HasColumnType("bit");           

            builder
            .Property(c => c.Logo)
            .HasColumnName("Logo");

            builder
           .Property(c => c.Activated)
           .HasColumnName("Activated")
           .HasDefaultValue(1);

            builder
            .Property(c => c.ConfirmationNotice)
            .HasColumnName("ConfirmationNotice")
            .HasColumnType("bit");

            builder
                .Property(x => x.UserId)
                .HasColumnName("UserId");

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Company)
                .HasForeignKey<User>(x => x.CompanyId);

            builder
            .HasMany(x => x.Queue)
            .WithOne(x => x.Company);           
        }
    }
}
