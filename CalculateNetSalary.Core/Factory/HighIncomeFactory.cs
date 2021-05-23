using CalculateNetSalary.Core.Abstract;
using CalculateNetSalary.Core.Models;

namespace CalculateNetSalary.Core.Factory
{
    class HighIncomeFactory : IncomeFactory
    {
        private string _employeeName;
        private decimal _grossIncome;
        private TaxTypes taxType;
        public HighIncomeFactory(string employeeName, decimal grossIncome)
        {
            this._employeeName = employeeName;
            this._grossIncome = grossIncome;
            this.taxType = TaxTypes.IncomeTax;
        }

        public override AbstractIncome GetIncome()
        {
            return new HighIncome(taxType, _employeeName, _grossIncome);
        }
        public override string ToString()
        {
            return TaxTypes.IncomeTax.ToString();
        }
    }
}
