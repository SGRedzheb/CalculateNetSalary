using CalculateNetSalary.Core.Abstract;
using CalculateNetSalary.Core.Models;

namespace CalculateNetSalary.Core.Factory
{
    class AvarageIncomeFactory : IncomeFactory
    {
        private string _employeeName;
        private decimal _grossIncome;
        private TaxTypes taxType;

        public AvarageIncomeFactory(string employeeName, decimal grossIncome)
        {
            this._employeeName = employeeName;
            this._grossIncome = grossIncome;
            this.taxType = TaxTypes.SocialTax;
        }

        public override AbstractIncome GetIncome()
        {
            return new AverageIncome(taxType, _employeeName, _grossIncome);
        }

        public override string ToString()
        {
            return TaxTypes.SocialTax.ToString();
        }
    }
}
