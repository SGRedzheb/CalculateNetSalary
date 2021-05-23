using CalculateNetSalary.Core.Abstract;
using CalculateNetSalary.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculateNetSalary.Tests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void IncomeOfTaxType_None()
        {
            //arrange
            var empName = "Selena Gomez";
            decimal grossIncome = 1000;
            IncomeFactory incomeFac = Income.GetIncomeFactory(empName, grossIncome);

            //act
            var income = incomeFac.GetIncome();

            //assert
            Assert.AreEqual(TaxTypes.None, income.TaxType);
        }

        [TestMethod]
        public void IncomeOfTaxType_Income()
        {
            //arrange
            var empName = "Stamat Ivanov";
            decimal grossIncome = 3500;
            IncomeFactory incomeFac = Income.GetIncomeFactory(empName, grossIncome);

            //act
            var income = incomeFac.GetIncome();

            //assert
            Assert.AreEqual(TaxTypes.IncomeTax, income.TaxType);
        }

        [TestMethod]
        public void IncomeOfTaxType_Social()
        {
            //arrange
            var empName = "Grigor Dimitrov";
            decimal grossIncome = 2900;
            IncomeFactory incomeFac = Income.GetIncomeFactory(empName, grossIncome);

            //act
            var income = incomeFac.GetIncome();

            //assert
            Assert.AreEqual(TaxTypes.SocialTax, income.TaxType);
        }
    }
}
