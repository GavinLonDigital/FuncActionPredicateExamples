using System;
using System.Collections.Generic;
using System.Linq;
namespace FuncActionPredicateExamples
{
    class Program
    {
        delegate TResult Func2<out TResult>();
        delegate TResult Func2<in T1, out TResult>(T1 arg);
        delegate TResult Func2<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
        delegate TResult Func2<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);


        static void Main(string[] args)
        {
            //************Func

            // MathClass mathClass = new MathClass();

            //Func<int, int, int> calc = mathClass.Sum;

            //Func<int, int, int> calc =  (a, b) =>  a + b;

            //int result = calc(1, 2);

            //Console.WriteLine($"Result: {result}");

            //float d = 2.3f, e = 4.56f;
            //int f = 5;

            //Func<float, float, int, float> calc2 = (arg1, arg2, arg3) => (arg1 + arg2) * arg3;

            //float result2 = calc2(d,e,f);

            //Console.WriteLine($"Result: {result2}");

            Func<decimal, decimal, decimal> calculateTotalAnnualSalary = (annualSalary, bonusPercentage) => annualSalary + (annualSalary * (bonusPercentage / 100));

            //Console.WriteLine($"Total annual Salary: {calculateTotalAnnualSalary(60000,2)}");

            //********Action

            Action<int, string, string, decimal, char, bool> displayEmployeeDetails = (arg1, arg2, arg3, arg4, arg5, arg6) => Console.WriteLine($"Id: {arg1}{Environment.NewLine}First Name: {arg2}{Environment.NewLine}Last Name: {arg3}{Environment.NewLine}Annual Salary: {arg4}{Environment.NewLine}Gender: {arg5}{Environment.NewLine}Manager: {arg6}");

            //displayEmployeeRecords(1, "Sarah", "Jones",60000,'f',true);

            //***********Predicate
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee { Id = 1, FirstName="Sarah", LastName="Jones", AnnualSalary= calculateTotalAnnualSalary(60000,2), Gender='f',IsManager=true });
            employees.Add(new Employee { Id = 2, FirstName = "Andrew", LastName = "Brown", AnnualSalary = calculateTotalAnnualSalary(40000,2), Gender = 'm', IsManager = false });
            employees.Add(new Employee { Id = 3, FirstName = "John", LastName = "Henderson", AnnualSalary = calculateTotalAnnualSalary(58000,2), Gender = 'm', IsManager = true });
            employees.Add(new Employee { Id = 4, FirstName = "Jane", LastName = "May", AnnualSalary = calculateTotalAnnualSalary(30000,2), Gender = 'f', IsManager = false });

            //List<Employee> employeesFiltered = FilterEmployees(employees, e => e.IsManager == true);
             List<Employee> employeesFiltered = employees.FilterEmployees(e => e.AnnualSalary > 45000);
           // List<Employee> employeesFiltered = employees.Where(e => e.AnnualSalary < 45000).ToList();

            foreach (Employee employee in employeesFiltered)
            {
                displayEmployeeDetails(employee.Id,employee.FirstName,employee.LastName,employee.AnnualSalary,employee.Gender,employee.IsManager);
                Console.WriteLine();
            }



            Console.ReadKey();
        }

        static List<Employee> FilterEmployees(List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> employeesFiltered = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    employeesFiltered.Add(employee);
                }
            }
            return employeesFiltered;
        }
    }

    public static class Extensions
    {
        public static List<Employee> FilterEmployees(this List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> employeesFiltered = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    employeesFiltered.Add(employee);
                }
            }
            return employeesFiltered;
        }
    }

        public class Employee
        { 
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public decimal AnnualSalary { get; set; }
            public char Gender { get; set; }
            public bool IsManager { get; set; }
         }

    public class MathClass
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
