using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecanhaBruno.WebBarberShop.Domain.Entities;

namespace PecanhaBruno.WebBaberShop.Infra.Data.EntityConfig {
    public class ScheduleDayXCustumersConfiguration : IEntityTypeConfiguration<ScheduleDayXCustumers>
    {
        public void Configure(EntityTypeBuilder<ScheduleDayXCustumers> builder) {

            builder
                .ToTable("ScheduleDayCustumers")
                .HasKey(x => x.Id);

            builder
            .Property(c => c.CustumerId)
            .HasColumnName("CustumerId")
            .IsRequired();

            //builder
            //.Property(c => c.ScheduleDayId)
            //.HasColumnName("ScheduleDayId")
            //.IsRequired();

            builder
            .Property(c => c.LastUpdate)
            .HasColumnName("LastUpdate");

            builder
            .Property(c => c.RegisteringDate)
            .HasColumnName("RegisteringDate")
            .IsRequired();


            //builder
            //.HasOne(c => c.ScheduleDay)
            //.WithMany(s => s.CustumerList)
            //.HasForeignKey(s => s.ScheduleDayId);

        }
    }
}
