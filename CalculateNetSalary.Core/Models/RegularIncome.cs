using CalculateNetSalary.Core.Abstract;
using CalculateNetSalary.Core.Interfaces;

namespace CalculateNetSalary.Core.Models
{
    /// <summary>
    /// RegularIncome class
    /// Salary below or equal to 1000 IDR.
    /// </summary>
    class RegularIncome : AbstractIncome
    {
        public RegularIncome(TaxTypes taxType, string employeeName, decimal grossIncome)
            : base(taxType, employeeName, grossIncome)
        {
            this.CalculateNetIncome();
        }

        /// <summary>
        /// Regular income's net salary is equal to gross salary.
        /// </summary>
        public override void CalculateNetIncome()
        {
            _netIncome = _grossIncome;
        }
    }
}
