using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBaberShop.Infra.Data.EntityConfig {
    public class CustumerConfiguration : IEntityTypeConfiguration<Custumer>
    {
        public void Configure(EntityTypeBuilder<Custumer> builder) {

            builder
                .ToTable("Custumer")
                .HasKey(x => x.Id);         

            builder
                .Property(c => c.IsServiceDone)
                .HasColumnName("IsServiceDone")
                .IsRequired();

            builder
               .Property(c => c.RegisteringDate)
               .HasColumnName("RegisteringDate")
               .IsRequired();

            builder
              .Property(c => c.LastUpdate)
              .HasColumnName("LastUpdate");

            builder
              .Property(c => c.Comment)
              .HasColumnName("Comment");

            builder
              .Property(c => c.CurrentCustomerInService)
              .HasColumnName("CurrentCustomerInService");

            builder
              .Property(c => c.QueuePosition)
              .HasColumnName("QueuePosition");

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Custumer)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder
                .HasOne(x => x.CurrentQueue)
                .WithMany(x => x.Custumers)
                .HasForeignKey(x => x.QueueId);

            builder
                .HasOne(x => x.ScheduleDay)
                .WithMany(x => x.Custumers)
                .HasForeignKey(x => x.ScheduleId);
        }
    }
}
