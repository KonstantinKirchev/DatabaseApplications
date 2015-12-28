using System;
using System.Linq;

namespace Explicit_Transactions
{
    class ExplicitTransactionsExample
    {
        static void Main()
        {
            using (var context = new SoftUniEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        string increaseSalary = @"UPDATE Employees SET Salary = Salary * 1.2 WHERE LastName = 'Wilson'";
                        context.Database.ExecuteSqlCommand(increaseSalary);

                        var seniorEmployees = context.Employees
                            .Where(e => e.Projects.Count() >= 5);

                        foreach (var employee in seniorEmployees)
                        {
                            employee.JobTitle = "Senior " + employee.JobTitle;
                        }
                        context.SaveChanges();

                        string removeSalary = @"UPDATE Employees SET Salary = NULL WHERE LastName = 'Brown'";
                        context.Database.ExecuteSqlCommand(removeSalary);

                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();;
                        Console.WriteLine("An exception has occurred: {0}", ex.Message);
                    }
                }
            }
        }
    }
}