using System;
using System.Linq;

namespace SoftUniDatabaseExample
{
    class Program
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            //var employees = context.Employees
            //    .Where(e => e.JobTitle == "Design Engineer")
            //    .OrderByDescending(e => e.LastName)
            //    .Select(e => new
            //    {
            //        e.FirstName,
            //        LastName = e.LastName,
            //        JopPosition = e.JobTitle
            //    });

            //Console.WriteLine(employees);
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}

            //var employee = context.Employees.FirstOrDefault(emp => emp.LastName == "Nakov");
            //employee.FirstName = "Dr...";
            //Console.WriteLine(employee.FirstName);
            //context.SaveChanges();

            //var town = context.Towns.First();
            //var addresses = town.Addresses.ToList();
            //foreach (var address in addresses)
            //{
            //    address.Town = null;
            //}
            //context.Towns.Remove(town);
            //context.SaveChanges();

            //var employeesName = context.Employees
            //    .Where(emp => emp.Salary > 50000)
            //    .Select(emp => emp.FirstName);

            //foreach (var empName in employeesName)
            //{
            //    Console.WriteLine(empName);
            //}

            //var employees = context.Employees
            //    .Where(emp => emp.Department.Name == "Research and Development")
            //    .OrderBy(emp => emp.Salary)
            //    .ThenByDescending(emp => emp.FirstName)
            //    .Select(emp => new
            //    {
            //        emp.FirstName,
            //        emp.LastName,
            //        Department = emp.Department.Name,
            //        emp.Salary
            //    });

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("{0} {1} from {2} - ${3:f2}",
            //        employee.FirstName,
            //        employee.LastName,
            //        employee.Department,
            //        employee.Salary);
            //}

            //var address = new Address()
            //{
            //    AddressText = "Vitoshka 15",
            //    TownID = 4
            //};

            //Employee employee = null;
            //employee = context.Employees.FirstOrDefault(emp => emp.LastName == "Nakov");
            //employee.Address = address;

            //context.SaveChanges();

            //var employee = context.Employees.FirstOrDefault(emp => emp.LastName == "Nakov");
            //Console.WriteLine(employee.Address.AddressText);

            //var project = context.Projects.Find(2);
            //var employees = project.Employees.ToList();
            //foreach (var employee in employees)
            //{
            //    employee.Projects = null;
            //}
            //context.Projects.Remove(project);
            //context.SaveChanges();

            //var employees = context.Database.SqlQuery<Employee>(
            //     "SELECT * FROM Employees WHERE FirstName='John'");
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee.FullName);
            //}

            var employeesByJob = context.Employees.GroupBy(emp => emp.JobTitle);
            foreach (var employee in employeesByJob)
            {
                Console.WriteLine("--{0}",employee.Key);
                foreach (var emp in employee)
                {
                    Console.WriteLine(emp.FullName);
                }
            }
        }
    }
}
