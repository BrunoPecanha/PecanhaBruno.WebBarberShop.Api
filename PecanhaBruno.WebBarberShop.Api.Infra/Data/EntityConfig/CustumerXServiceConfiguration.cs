using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBaberShop.Infra.Data.EntityConfig {
    public class CustumerXServiceConfiguration : IEntityTypeConfiguration<CustumerXServices>
    {
        public void Configure(EntityTypeBuilder<CustumerXServices> builder) {

            builder
                .ToTable("CustumerServices")
                .HasKey(x => x.Id);            

            builder
            .Property(c => c.CustumerId)
            .HasColumnName("CustumerId")
            .IsRequired();

            builder
            .Property(c => c.ServiceId)
            .HasColumnName("ServiceId")
            .IsRequired();

            builder
            .Property(c => c.LastUpdate)
            .HasColumnName("LastUpdate");

            builder
            .Property(c => c.RegisteringDate)
            .HasColumnName("RegisteringDate")
            .IsRequired();            

            builder
            .HasOne(c => c.Custumer)
            .WithMany(s => s.CustumerServices)
            .HasForeignKey(s => s.CustumerId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
            .HasOne(c => c.Service)
            .WithMany(s => s.CustumerServices)
            .HasForeignKey(s => s.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
