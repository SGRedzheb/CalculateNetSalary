using CalculateNetSalary.Core.Abstract;
using CalculateNetSalary.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculateNetSalary.Tests
{
    [TestClass]
    public class NetIncomeTests
    {
        [TestMethod]
        public void NoTax_NetIncome()
        {
            //arrange
            var empName = "Dimitar Petkov";
            decimal grossIncome = 1000;
            decimal expectedIncome = 1000;
            IncomeFactory incomeFac = Income.GetIncomeFactory(empName, grossIncome);

            //act
            var income = incomeFac.GetIncome();

            //assert
            Assert.AreEqual((double)expectedIncome, (double)income.NetIncome, 0.001);
        }

        [TestMethod]
        public void IncomeTax_NetIncome()
        {
            //arrange
            var empName = "Krasimir Stoyanov";
            decimal grossIncome = 3500;
            decimal expectedIncome = 3150;
            IncomeFactory incomeFac = Income.GetIncomeFactory(empName, grossIncome);

            //act
            var income = incomeFac.GetIncome();

            //assert
            Assert.AreEqual((double)expectedIncome, (double)income.NetIncome, 0.001);
        }

        [TestMethod]
        public void SocialTax_NetIncome()
        {
            //arrange
            var empName = "Ivan Ivanov";
            decimal grossIncome = 2600;
            decimal expectedIncome = 1989;
            IncomeFactory incomeFac = Income.GetIncomeFactory(empName, grossIncome);

            //act
            var income = incomeFac.GetIncome();

            //assert
            Assert.AreEqual((double)expectedIncome, (double)income.NetIncome, 0.001);
        }
    }
}
