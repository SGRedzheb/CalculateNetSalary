using CalculateNetSalary.Core.Abstract;
using CalculateNetSalary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculateNetSalary.Core.Models
{
    /// <summary>
    /// HighIncome class
    /// Above 3000 IDR gross salary
    /// </summary>
    class HighIncome : AbstractIncome, IApplyTaxes
    {
        public HighIncome(TaxTypes taxType, string employeeName, decimal grossIncome)
            : base(taxType, employeeName, grossIncome)
        {
            this.AddIncomeTaxes();
            base.CalculateNetIncome();
        }

        public void AddIncomeTaxes()
        {
            _taxes = new List<Tax>();
            if (TaxType == TaxTypes.IncomeTax)
            {
                _taxes.Add(new Tax { TaxName = TaxTypes.IncomeTax, TaxAmount = 10.0M });
            }
        }
    }
}
