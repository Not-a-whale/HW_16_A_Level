
using HW16.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW16.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);

            builder.Property(e => e.EmployeeId);
            builder.Property(e => e.TitleId);
            builder.Property(e => e.FirstName).HasMaxLength(50);
            builder.Property(e => e.DateOfBirth).HasColumnType("date");
            builder.Property(e => e.HiredDate).HasPrecision(7);
            builder.Property(e => e.LastName).HasMaxLength(50);
            builder.Property(e => e.OfficeId);
            builder.Property(e => e.LastName);
        }
    }
}
