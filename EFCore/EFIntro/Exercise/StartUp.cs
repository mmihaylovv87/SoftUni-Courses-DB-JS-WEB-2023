using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext db = new SoftUniContext();

            string result = RemoveTown(db);

            Console.WriteLine(result);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            int townId = context.Towns
                .Where(t => t.Name == "Seattle")
                .Select(t => t.TownId)
                .FirstOrDefault();

            var addresses = context.Addresses
                .Where(a => a.TownId == townId)
                .ToList();


            foreach (var emp in context.Employees)
            {
                if (addresses.Contains(emp.Address))
                {
                    emp.AddressId = null;
                }
            }

            context.Addresses.RemoveRange(addresses);
            context.Towns.Remove(context.Towns.FirstOrDefault(t => t.TownId == townId));

            context.SaveChanges();

            string output = addresses.Count == 1 ? $"{addresses.Count} address in Seattle was deleted"
                : $"{addresses.Count} addresses in Seattle were deleted";

            return output;
        }
    }
}