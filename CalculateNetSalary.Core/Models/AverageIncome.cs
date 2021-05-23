using CalculateNetSalary.Core.Abstract;
using CalculateNetSalary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculateNetSalary.Core.Models
{
    /// <summary>
    /// AvarageIncome class.
    /// Above 1000 and below 3000 IDR.
    /// </summary>
    class AverageIncome : AbstractIncome, IApplyTaxes
    {
        public AverageIncome(TaxTypes taxType, string employeeName, decimal grossIncome)
            : base(taxType, employeeName, grossIncome)
        {
            this.AddIncomeTaxes();
            base.CalculateNetIncome();
        }

        public void AddIncomeTaxes()
        {
            _taxes = new List<Tax>();
            if (TaxType == TaxTypes.SocialTax)
            {
                _taxes.Add(new Tax { TaxName = TaxTypes.IncomeTax, TaxAmount = 10.0M });
                _taxes.Add(new Tax { TaxName = TaxTypes.SocialTax, TaxAmount = 15.0M });
            }
        }
    }
}
