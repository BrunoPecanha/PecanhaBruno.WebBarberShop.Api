using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBaberShop.Infra.Data.EntityConfig {
    public class DayBalanceConfiguration : IEntityTypeConfiguration<DayBalance> {
        public void Configure(EntityTypeBuilder<DayBalance> builder) {

            builder
             .ToTable("DayBalance")
             .HasKey(c => c.Id);            

            builder
            .Property(c => c.RegisteringDate)
            .HasColumnName("RegisteringDate")
            .IsRequired();

            builder
            .Property(c => c.LastUpdate)
            .HasColumnName("LastUpdate");

            //Cardinalidade : 1:N
            builder
            .HasOne(x => x.Company)
            .WithMany(x => x.DayBalances)
            .HasForeignKey(x => x.CompanyId)
            .IsRequired();

            //Cardinalidade : 1:1
            builder
           .HasOne(x => x.Queue)
           .WithOne(x => x.DayBalance)
           .HasForeignKey<DayBalance>(x => x.QueueId)
           .OnDelete(DeleteBehavior.ClientSetNull);

            //Cardinalidade : 1:1
            builder
           .HasOne(x => x.ScheduleDay)
           .WithOne(x => x.DayBalance)
           .HasForeignKey<DayBalance>(x => x.ScheduleDayId)
           .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
