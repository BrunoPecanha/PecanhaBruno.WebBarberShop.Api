using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBaberShop.Infra.Data.EntityConfig {
    public class ScheduleDayConfiguration : IEntityTypeConfiguration<ScheduleDay>
    {
        public void Configure(EntityTypeBuilder<ScheduleDay> builder) {

            builder
                .ToTable("ScheduleDay")
                .HasKey(x => x.Id);           
          
            builder
                .Property(c => c.StartTime)
                .HasColumnName("StartTime")
                .HasColumnType("DateTime");

            builder
              .Property(c => c.EndTime)
              .HasColumnName("EndTime")
              .HasColumnType("DateTime");

            builder
              .Property(c => c.EstimatedTimeToNext)
              .HasColumnName("EstimatedTimeToNext")
              .HasColumnType("DateTime");

            builder
              .Property(x => x.LastUpdate)
              .HasColumnName("LastUpdate");

            builder
             .Property(x => x.RegisteringDate)
             .HasColumnName("RegisteringDate");

            //builder
            //.HasOne(c => c.Current)
            //.WithOne(s => s.ScheduleDay.ScheduleDay)
            //.HasForeignKey("ScheduleDayId");            
        }
    }
}

