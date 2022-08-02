using HW16.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW16.Configurations
{
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.HasKey(e => e.EmployeeProjectId);

            builder.Property(e => e.EmployeeId);
            builder.Property(e => e.EmployeeProjectId);
            builder.Property(e => e.StartedDate).HasPrecision(7);
            builder.Property(e => e.ProjectId);
            builder.Property(e => e.Rate);
        }
    }
}
