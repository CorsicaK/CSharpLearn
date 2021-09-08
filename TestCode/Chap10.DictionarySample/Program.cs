using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap10.DictionarySample
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new Dictionary<EmployeeId, Employee>(31);
            var idTony = new EmployeeId("C3755");
            var tony = new Employee(idTony, " Tony Smart", 379025.00m);
            employees.Add(idTony, tony);
            var idCarl = new EmployeeId("F3325");
            var carl = new Employee(idCarl, "Carl Edwards", 403644.00m);
            employees.Add(idCarl, carl);
            var idKevin = new EmployeeId("G3525");
            var kevin = new Employee(idKevin, "Kevin Aards", 512644.00m);
            employees.Add(idKevin, kevin);
            var idMatt = new EmployeeId("JU225");
            var matt = new Employee(idMatt , "Matt Fords", 162543.00m);
            employees[idMatt] = matt;

            while (true)
            {
                Console.Write("Enter employee id (x to exit)> ");
                var userInput = Console.ReadLine();
                userInput = userInput.ToUpper();
                if (userInput == "X") break;

                EmployeeId id;
                try
                {
                    id = new EmployeeId(userInput);
                    Employee employee;
                    if(!employees.TryGetValue (id,out employee))
                    {
                        Console.WriteLine("Employee with id{0} does not exist", id);
                    }
                    else
                    {
                        Console.WriteLine(employee);
                    }
                }
                catch (EmployeeIdException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
