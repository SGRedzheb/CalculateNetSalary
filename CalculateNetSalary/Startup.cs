using CalculateNetSalary.Core.Models;
using CalculateNetSalary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculateNetSalary.Core.Abstract;

namespace CalculateNetSalary
{
    class Startup
    {
        private static IncomeFactory _incomeFactory;
        private static AbstractIncome _employeeIncome;
        private static decimal _grossIncome;
        private static string _employeeName;
        private static bool exit;

        public static void Main()
        {
            exit = false;
            do
            {
                try
                {
                    GetInput();
                    Console.WriteLine(Environment.NewLine);

                    CreateEmployeeAccount(_employeeName, _grossIncome);

                    DisplayNetIncomeAndTaxes();

                    ExitProgram();

                    Console.WriteLine($"========================{Environment.NewLine}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (!exit);
        }

        private static void ExitProgram()
        {
            Console.WriteLine("To exit program type 'e', then press enter...");
            exit = Console.ReadLine() == "e";
        }

        private static void DisplayNetIncomeAndTaxes()
        {
            Console.WriteLine(_employeeIncome.TaxLog);
            Console.WriteLine($"{_employeeIncome.EmployeeName}'s net income: {_employeeIncome.NetIncome} IDR");
        }

        private static void GetInput()
        {
            Console.WriteLine("Enter employee name:");
            _employeeName = Console.ReadLine();
            Console.WriteLine("Enter employee gross income:");
            _grossIncome = 0;
            string grossIncome = Console.ReadLine();

            if (!decimal.TryParse(grossIncome, out _grossIncome))
            {
                throw new FormatException("Gross income must be numeric.");
            }
        }

        private static void CreateEmployeeAccount(string empName, decimal grossIncome)
        {
            _incomeFactory = Income.GetIncomeFactory(empName, grossIncome);
            _employeeIncome = _incomeFactory.GetIncome();
        }
    }
}
