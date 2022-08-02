using HW16.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW16.Configurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(o => o.OfficeId);

            builder.Property(o => o.OfficeId);
            builder.Property(o => o.Title).HasMaxLength(100);
            builder.Property(o => o.Location).HasMaxLength(100);
        }
    }
}
