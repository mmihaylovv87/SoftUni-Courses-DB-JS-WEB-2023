using ORMFundamentals.Models;

namespace ORMFundamentals
{
    // Microsoft.EntityFrameworkCore.SqlServer
    // Microsoft.EntityFrameworkCore.Design
    // dotnet ef dbcontext scaffold "Server=DESKTOP-T5A7CLB;Database=SoftUni;Trusted_Connection=True;Encrypt=False" +
    // Microsoft.EntityFrameworkCore.SqlServer '-o' (create folder and put info in)
    public class StartUp
    {
        public static void Main()
        {
            var db = new SoftUniContext();
            var departments = db.Employees.GroupBy(x => x.Department.Name)
                .Select(x => new { Name = x.Key, Count = x.Count() })
                .ToList();
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Name} => {department.Count}");
            }
        }
    }
}