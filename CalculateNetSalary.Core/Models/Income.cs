using CalculateNetSalary.Core.Abstract;
using CalculateNetSalary.Core.Factory;
using System;

namespace CalculateNetSalary.Core.Models
{
    public static class Income
    {
        public static IncomeFactory GetIncomeFactory(string employeeName, decimal grossIncome)
        {
            var incomeTaxType = GetIncomeTaxType(grossIncome);

            switch (incomeTaxType)
            {
                case TaxTypes.SocialTax:
                    return new AvarageIncomeFactory(employeeName, grossIncome);
                case TaxTypes.IncomeTax:
                    return new HighIncomeFactory(employeeName, grossIncome);
                case TaxTypes.None:
                    return new RegularIncomeFactory(employeeName, grossIncome);
                default:
                    throw new NotImplementedException("Income factory not implemented.");
            }
        }

        private static TaxTypes GetIncomeTaxType(decimal grossIncome)
        {
            if (grossIncome <= 1000)
                return TaxTypes.None;

            if (grossIncome > 1000 && grossIncome < 3000)
                return TaxTypes.SocialTax;

            return TaxTypes.IncomeTax;
        }
    }
}
