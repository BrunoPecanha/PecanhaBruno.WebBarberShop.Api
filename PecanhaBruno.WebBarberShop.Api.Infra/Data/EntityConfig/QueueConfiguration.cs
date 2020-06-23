using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBaberShop.Infra.Data.EntityConfig {
    public class QueueConfiguration : IEntityTypeConfiguration<CurrentQueue> {
        public void Configure(EntityTypeBuilder<CurrentQueue> builder) {

            builder
            .ToTable("Queue")
            .HasKey(x => x.Id);           

            builder
            .Property(c => c.RegisteringDate)
            .HasColumnName("RegisteringDate")
            .IsRequired();


            builder
            .Property(c => c.LastUpdate)
            .HasColumnName("LastUpdate")
            .IsRequired();

            builder
           .Property(c => c.FinalizationTime)
           .HasColumnName("FinalizationTime")
           .IsRequired();

            builder
            .HasOne(x => x.Company)
            .WithMany(x => x.Queue);           


            builder
           .Property(c => c.IsWorking)
           .HasColumnName("IsWorking")
           .IsRequired();
        }
    }
}
