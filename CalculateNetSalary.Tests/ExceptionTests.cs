using CalculateNetSalary.Core.Abstract;
using CalculateNetSalary.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculateNetSalary.Tests
{
    [TestClass]
    public class ExceptionTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid_EmployeeName()
        {
            //arrange
            var empName = "Ivan";
            decimal grossIncome = 100;
            IncomeFactory incomeFac = Income.GetIncomeFactory(empName, grossIncome);

            //act
            incomeFac.GetIncome();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Invalid_GrossIncome_EqualToZero()
        {
            //arrange
            var empName = "Stoyan Todorov";
            decimal grossIncome = 0;
            IncomeFactory incomeFac = Income.GetIncomeFactory(empName, grossIncome);

            //act
            incomeFac.GetIncome();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Invalid_GrossIncome_LessThanZero()
        {
            //arrange
            var empName = "Stoyan Todorov";
            decimal grossIncome = -15;
            IncomeFactory incomeFac = Income.GetIncomeFactory(empName, grossIncome);

            //act
            incomeFac.GetIncome();
        }
    }
}
