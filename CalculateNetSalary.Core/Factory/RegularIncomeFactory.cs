using CalculateNetSalary.Core.Abstract;
using CalculateNetSalary.Core.Models;

namespace CalculateNetSalary.Core.Factory
{
    class RegularIncomeFactory : IncomeFactory
    {
        private string _employeeName;
        private decimal _grossIncome;
        private TaxTypes taxType;
        public RegularIncomeFactory(string employeeName, decimal grossIncome)
        {
            this._employeeName = employeeName;
            this._grossIncome = grossIncome;
            this.taxType = TaxTypes.None;
        }

        public override AbstractIncome GetIncome()
        {
            return new RegularIncome(taxType, _employeeName, _grossIncome);
        }

        public override string ToString()
        {
            return TaxTypes.None.ToString();
        }
    }
}
