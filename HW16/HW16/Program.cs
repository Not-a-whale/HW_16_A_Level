
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
                Console.WriteLine("\n");

                // 4) Deleting some guy
                Employee toBeRemoved = db.Employees.Where(e => e.EmployeeId == 1006).First();
                Console.WriteLine($"Firing {toBeRemoved.FirstName}");
                db.Employees.Remove(toBeRemoved);
                Console.WriteLine($"{toBeRemoved.FirstName} has been fired");
                Console.WriteLine("\n");

                // 5) Group by roles. Return roles that do not have a letter 'a' in their names

                var listOfAllTheRolesForAllEmployees = db.Titles.Join(db.Employees,
                    e => e.TitleId,
                    t => t.TitleId,
                    (t, employees) => new
                    {
                        Title = t.Name
                    }).Distinct().ToList();

                var rolesWithoutAInTitle = listOfAllTheRolesForAllEmployees.FindAll(t => !t.Title.Contains('a'));
                foreach(var role in rolesWithoutAInTitle)
                {
                    Console.WriteLine(role.Title);
                }
                Console.WriteLine("\n");

                // 6) Connected entities query
                var titlesAndEmployees = db.Employees.Join(db.Titles,
                    e => e.TitleId,
                    t => t.TitleId,
                    (e, t) => new
                    {
                        Name = e.FirstName,
                        Title = t.Name
                    }).ToList();

                foreach(var employee in titlesAndEmployees)
                {
                    Console.WriteLine($"The guy named {employee.Name} is a {employee.Title}");
                }

            }
        }
    }
}
