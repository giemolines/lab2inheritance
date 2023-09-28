using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; // Import this for LINQ extension methods

namespace LAB_2_INHERITANCE
{
    internal class Program
    {
        // Create lists for employees and their categories
        static List<Employee> employees = new List<Employee>();
        static List<Salaried> salariedEmployees = new List<Salaried>();
        static List<Wages> wagesEmployees = new List<Wages>();
        static List<PartTime> partTimeEmployees = new List<PartTime>();

        static void Main(string[] args)
        {
            

            // Read from "employees.txt" file
            string[] lines = File.ReadAllLines("/workspaces/lab2inheritance/LAB_2_INHERITANCE/employees.txt");

            foreach (string line in lines)
            {
                string[] columns = line.Split(":");

                // ID
                string id = columns[0];

                // NAME
                string name = columns[1];

                // ADDRESS
                string address = columns[2];

                // PHONE NUMBER
                string phone = columns[3];

                // SIN NUMBER
                long sin = long.Parse(columns[4]);

                // DATE OF BIRTH
                string dob = columns[5];

                // DEPARTMENT
                string dept = columns[6];

                // RATE
                double rate = double.Parse(columns[7]);

                char firstDigitofID = id[0];

                Employee employee;

                if (firstDigitofID >= '0' && firstDigitofID <= '4')
                {
                    double salary = double.Parse(columns[7]);
                    employee = new Salaried(id, name, address, phone, sin, dob, dept, salary);
                }
                else if (firstDigitofID >= '5' && firstDigitofID <= '7')
                {
                    double hours = double.Parse(columns[8]);
                    employee = new Wages(id, name, address, phone, sin, dob, dept, rate, hours);
                }
                else
                {
                    double hours = double.Parse(columns[8]);
                    employee = new PartTime(id, name, address, phone, sin, dob, dept, rate, hours);
                }

                employees.Add(employee);
            }

            foreach (Employee emp in employees)
            {
                if (emp is Salaried salaried)
                {
                    salariedEmployees.Add(salaried);
                }
                else if (emp is Wages wages)
                {
                    wagesEmployees.Add(wages);
                }
                else if (emp is PartTime partTime)
                {
                    partTimeEmployees.Add(partTime);
                }
            }

           
            //// Display employee information
            //foreach (Employee emp in employees)
            //{
            //    Console.WriteLine(emp.ToString());
            //    if (emp is Salaried)
            //    {
            //        Console.WriteLine("Salaried");
            //    }
            //    else if (emp is Wages)
            //    {
            //        Console.WriteLine("Wages");
            //    }
            //    else if (emp is PartTime)
            //    {
            //        Console.WriteLine("Part Time");
            //    }

            //    Console.WriteLine();
            //}


            //DISPLAY METHODS

            // B.
            Console.WriteLine(CalculateAverageWeeklyPay(employees));

            //C.
            Console.WriteLine(HighestWeeklyPay(wagesEmployees));

            //D.
            Console.WriteLine(LowestSalary(salariedEmployees));

            //E.
            Console.WriteLine(PercentageOfEmployees());
        }

        // B. Calculate the average weekly pay for all employees
        static string CalculateAverageWeeklyPay(List<Employee> employees)
        {
            double totalWeeklyPay = 0.0;
            double averageWeeklyPay = 0.0;

            foreach (Employee emp in employees)
            {
                totalWeeklyPay += emp.getPay();
            }

            int numberOfEmployees = employees.Count;
            averageWeeklyPay = totalWeeklyPay / numberOfEmployees;


            return $"The average weekly pay for all employees is: {averageWeeklyPay:C}\n";
        }

        //C. Calculate and return the highest weekly pay for the wage employees, including the name of the employee

        static string HighestWeeklyPay(List<Wages> wagesEmployees)
        {
            List<double> weeklyPay = new List<double>();

            foreach (Wages emp1 in wagesEmployees)
            {
                double pay = emp1.getPay();
                weeklyPay.Add(pay);
            }

            double HighestWeeklyPay = weeklyPay.Max();
            string HighestWeeklyPaidEmployee = "";

            foreach (Wages emp in wagesEmployees)
            {
                double pay = emp.getPay();
                if (HighestWeeklyPay == pay)
                {
                    HighestWeeklyPaidEmployee = emp.Name;
                }
            }
            return $"The Highest weekly paid wage employee is {HighestWeeklyPaidEmployee} with a weekly pay of {HighestWeeklyPay:C}\n";
        }

        //D. Calculate and return the lowest salary for the salaried employees, and the name of the employee
        static string LowestSalary(List<Salaried> salariedEmployees)
        {
            List<double> salaries = new List<double>();

            foreach (Salaried emp1 in salariedEmployees)
            {
                double pay = emp1.getPay();
                salaries.Add(pay);
            }

            double LowestSalary = salaries.Min();
            string LowestSalariedEmployee = "";
            double LowestEmployeeSalary = 0.0;

            foreach (Salaried emp in salariedEmployees)
            {
                double pay = emp.getPay();
                if (LowestSalary == pay)
                {
                    LowestSalariedEmployee = emp.Name;
                    LowestEmployeeSalary = emp.Salary;
                }
            }
            return $"The lowest salaried employee is {LowestSalariedEmployee} with a salary of {LowestEmployeeSalary:C}\n";

        }

        //E. What percentage of the company's employees fall into each employee category?

        static string PercentageOfEmployees()
        {
            double totalEmployees = employees.Count;
            double percentageSalaried = (salariedEmployees.Count / totalEmployees) * 100;
            double percentageWages = (wagesEmployees.Count / totalEmployees) * 100;
            double percentagePartTime = (partTimeEmployees.Count / totalEmployees) * 100;

            return $"The percentage of Salaried employees is {percentageSalaried:F2}%\nWaged Employees is {percentageWages:F2}%\nPart Time is {percentagePartTime:F2}%\n";
        }


    }
}
