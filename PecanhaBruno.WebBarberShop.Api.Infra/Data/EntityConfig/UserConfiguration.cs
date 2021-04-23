using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBaberShop.Infra.Data.EntityConfig {
    public class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {

            builder
             .ToTable("SysUser")
             .HasKey(x => x.Id);

            builder
            .Property(c => c.RegisteringDate)
            .HasColumnName("RegisteringDate")
            .IsRequired();

            builder
            .Property(c => c.Name)
            .HasColumnName("Name");

            builder
             .Property(c => c.LastName)
             .HasColumnName("LastName");

            builder
             .Property(c => c.LastUpdate)
             .HasColumnName("LastUpdate");

            //builder
            // .Property(c => c.Picture)
            // .HasColumnName("Picture");

            builder
             .Property(c => c.LastVisitDate)
             .HasColumnName("LastVisitDate");

            builder
             .Property(c => c.MobileInfo)
             .HasColumnName("MobileInfo");

            builder
             .Property(c => c.Activated)
             .HasColumnName("Activated")
             .HasDefaultValue(1);

            builder
            .Property(c => c.Email)
            .HasColumnName("Email");

            builder
            .Property(c => c.PassWord)
            .HasColumnName("PassWord");

            builder
            .Property(c => c.Owner)
            .HasColumnName("Owner");


            builder
                 .HasOne(x => x.Company)
                 .WithOne(x => x.User)
                 .HasForeignKey<Company>(x => x.UserId);

            builder
                .HasMany(x => x.Customer)
                .WithOne(x => x.User);
        }
    }
}
