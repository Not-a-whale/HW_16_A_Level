using HW16.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW16.Configurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.HasKey(o => o.TitleId);

            builder.Property(o => o.TitleId);
            builder.Property(o => o.Name).HasMaxLength(50);
        }
    }
}
