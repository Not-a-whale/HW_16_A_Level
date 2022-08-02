using HW16.Configurations;
using HW16.DbModels;
using Microsoft.EntityFrameworkCore;

namespace HW16
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Title> Titles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=LAPTOP-NGTI8E14;Initial Catalog=Project;Integrated Security=True;Pooling=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.Entity<Client>().HasData(
                new Client() { ClientId = 1, FirstName = "test1", LastName = "test", ProjectId = 1 },
                new Client() { ClientId = 2, FirstName = "test2", LastName = "test", ProjectId = 2 },
                new Client() { ClientId = 3, FirstName = "test3", LastName = "test", ProjectId = 3 },
                new Client() { ClientId = 4, FirstName = "test4", LastName = "test", ProjectId = 4 },
                new Client() { ClientId = 5, FirstName = "test5", LastName = "test", ProjectId = 5 }
                );

            modelBuilder.Entity<Project>().HasData(
                new Project() { ProjectId = 1, Name = "test1", Budget = 100.0M, ClientId = 1 },
                new Project() { ProjectId = 2, Name = "test2", Budget = 100.0M, ClientId = 2 },
                new Project() { ProjectId = 3, Name = "test3", Budget = 100.0M, ClientId = 3 },
                new Project() { ProjectId = 4, Name = "test4", Budget = 100.0M, ClientId = 4 },
                new Project() { ProjectId = 5, Name = "test5", Budget = 100.0M, ClientId = 5 }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee() { EmployeeId = 1, FirstName = "George", LastName = "Klint", HiredDate = new DateTime(2020, 1, 20),OfficeId = 1 },
                new Employee() { EmployeeId = 2, FirstName = "John", LastName = "Goodman", HiredDate = new DateTime(2018, 3, 21), OfficeId = 2 },
                new Employee() { EmployeeId = 3, FirstName = "Bill", LastName = "Steiner", HiredDate = new DateTime(2016, 1, 26), OfficeId = 3 },
                new Employee() { EmployeeId = 4, FirstName = "Sam", LastName = "Orwell", HiredDate = new DateTime(2017, 7, 21), OfficeId = 4 },
                new Employee() { EmployeeId = 5, FirstName = "Tom", LastName = "Keeney", HiredDate = new DateTime(2019, 5, 29), OfficeId = 5 }
            );
        }
    }
}
