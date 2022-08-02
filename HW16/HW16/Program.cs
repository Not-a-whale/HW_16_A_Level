
using HW16;
using HW16.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Program
{
    class HW16
    {
        static void Main(string[] args)
        {
/*            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                Project project1 = new Project { Name = "Analniki", Budget = 1000.0M, StartedDate = new DateTime(2015, 7, 20), ClientId = 5 };
                db.Projects.Add(project1);
                db.SaveChanges();

                Office office = new Office { Title = "Respublica Park", Location = "Dorogozhichi" };
                db.Offices.Add(office);

                Title title = new Title { Name = "Developer" };
                db.Titles.Add(title);

                Employee employee1 = new Employee() { FirstName = "George", LastName = "Klint", HiredDate = new DateTime(2020, 1, 20), OfficeId = 1, TitleId = 3 };
                db.Employees.Add(employee1);

                Employee employee2 = new Employee() { FirstName = "John", LastName = "Goodman", HiredDate = new DateTime(2018, 3, 21), OfficeId = 1, TitleId = 3 };
                db.Employees.Add(employee2);

                Employee employee3 = new Employee() { FirstName = "Bill", LastName = "Steiner", HiredDate = new DateTime(2016, 1, 26), OfficeId = 1, TitleId = 3 };
                db.Employees.Add(employee3);

                Employee employee4 = new Employee() { FirstName = "Sam", LastName = "Orwell", HiredDate = new DateTime(2017, 7, 21), OfficeId = 1, TitleId = 3 };
                db.Employees.Add(employee4);

                Employee employee5 = new Employee() { FirstName = "Tom", LastName = "Keeney", HiredDate = new DateTime(2019, 5, 29), OfficeId = 1, TitleId = 3 };
                db.Employees.Add(employee5);
                db.SaveChanges();
            }*/

            using (ApplicationContext db = new ApplicationContext())
            {
                // 1) Years in office from now

                var yearsInOffice = (from e in db.Employees select EF.Functions.DateDiffYear(e.HiredDate, DateTime.Now)).ToList();

                foreach (var year in yearsInOffice)
                {
                    Console.WriteLine(year);
                }

                Console.WriteLine("\n");

                // 2) Update two entities in one query
                var selectedEmployees = (from e in db.Employees where e.FirstName == "Tom" select e).ToList();
                selectedEmployees.ForEach(e => e.OfficeId = 2);

                foreach(var emp in selectedEmployees)
                {
                    Console.WriteLine(emp.LastName);
                    Console.WriteLine(emp.OfficeId);
                }

                // 3) Add a new Employee
                Employee employee2 = new Employee() { FirstName = "John", LastName = "Green", HiredDate = new DateTime(2018, 3, 21), OfficeId = 1, TitleId = 3 };
                db.Employees.Add(employee2);
                db.SaveChanges();


            }
        }
    }
}
