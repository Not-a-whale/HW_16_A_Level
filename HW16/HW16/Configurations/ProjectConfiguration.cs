using HW16.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW16.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.ProjectId);

            builder.Property(p => p.ProjectId);
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.StartedDate).HasPrecision(7);
            builder.Property(p => p.Budget);
            builder.Property(p => p.ClientId).IsRequired(true);
        }
    }
}
