using System.Text;
using System.Xml;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            Console.WriteLine(IncreaseSalaries(dbContext));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(x => x)
                .OrderBy(x => x.EmployeeId);

            foreach (Employee employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} " +
                              $"{employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(x => x.Salary > 50000)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .OrderBy(e => e.FirstName);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development ")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                }).OrderBy(x => x.FirstName);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from " +
                              $"{employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address addressToAdd = new Address() { AddressText = "Vitoshka 15", TownId = 4 };
            var employee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            employee.Address = addressToAdd;

            context.SaveChanges();

            return string.Join("\n",
                context.Employees.OrderByDescending(x => x.AddressId).Take(10).Select(x => x.Address.AddressText));
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            return "";
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .Select(x => new
                {
                    Address = x,
                    EmployeeCount = x.Employees.Count()
                }). Where(x => x.EmployeeCount > 0)
                .OrderByDescending(x => x.EmployeeCount)
                .ThenBy(x => x.Address.Town.Name)
                .ThenBy(x => x.Address.AddressText)
                .Take(10);

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.Address.AddressText} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var e = context.Employees.Find(147);

            return $"{e.FirstName} {e.LastName} - {e.JobTitle}";
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerName = $"{x.Manager.FirstName} {x.Manager.LastName}",
                    EmployeeCount = x.Employees.Count(),
                    DepartmentEmployees = x.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle 
                    }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList()
                })
                .Where(x => x.EmployeeCount > 5)
                .OrderBy(x => x.EmployeeCount)
                .ThenBy(x => x.DepartmentName);

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerName}");
                foreach (var employee  in department.DepartmentEmployees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }
            
            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects.Select(p => p).OrderBy(p => p.EndDate).Take(10);
            return "";
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var empolyees = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Information Services" || e.Department.Name == "Marketing")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName).ToList();

            foreach (var empolyee in empolyees)
            {
                empolyee.Salary *= 1.2m;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            empolyees.ForEach(x => sb.AppendLine($"{x.FirstName} {x.LastName} (${x.Salary:f2})"));

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            return "";
        }
    }
}
