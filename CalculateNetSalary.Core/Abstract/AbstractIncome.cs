using CalculateNetSalary.Core.Interfaces;
using CalculateNetSalary.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculateNetSalary.Core.Abstract
{
    /// <summary>
    /// 'Income' concrete abstract class
    /// </summary>
    public abstract class AbstractIncome : INetIncome
    {
        #region Fields
        /// <summary>
        /// Tax type of income
        /// </summary>
        protected TaxTypes _taxType;
        /// <summary>
        /// Log of applied taxes to gross income
        /// </summary>
        public string TaxLog;
        /// <summary>
        /// Employee name
        /// </summary>
        protected string _empoyeeName;
        /// <summary>
        /// Employee's gross income
        /// </summary>
        protected decimal _grossIncome;
        /// <summary>
        /// Employee's net income
        /// </summary>
        protected decimal _netIncome;
        /// <summary>
        /// List of taxes to aplly to employee's gross income
        /// </summary>
        protected List<Tax> _taxes;
        #endregion

        #region Properties
        /// <summary>
        /// Employee name. 
        /// Employee name must be between 5 and 20 characters long.
        /// </summary>
        public string EmployeeName
        {
            get
            {
                return _empoyeeName;
            }
            set
            {
                if (value.Length < 5 || value.Length > 20)
                    throw new ArgumentException("Employee name must be between 5 and 20 characters long.", nameof(EmployeeName));

                _empoyeeName = value;
            }
        }
        /// <summary>
        /// Employee's gross income. 
        /// Employee's gross income must be non negative or zero.
        /// </summary>
        public decimal GrossIncome
        {
            get
            {
                return _grossIncome;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(GrossIncome), "Gross income must be non negative or zero.");

                _grossIncome = value;
            }
        }
        /// <summary>
        /// Employee's net income
        /// </summary>
        public decimal NetIncome
        {
            get
            {
                return _netIncome;
            }
            set
            {
                _netIncome = value;
            }
        }

        /// <summary>
        /// Tax type for income range
        /// </summary>
        public TaxTypes TaxType
        {
            get
            {
                return _taxType;
            }
            set
            {
                _taxType = value;
            }
        }
        #endregion

        #region Constructor
        public AbstractIncome(TaxTypes taxType, string employeeName, decimal grossIncome)
        {
            TaxType = taxType;
            EmployeeName = employeeName;
            GrossIncome = grossIncome;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calculate net income by applying taxes for the income tax type
        /// </summary>
        public virtual void CalculateNetIncome()
        {
            var gross = GrossIncome;
            StringBuilder log = new StringBuilder();

            foreach (var tax in _taxes)
            {
                decimal taxAmount = (gross * tax.TaxAmount / 100);

                log.Append($"{gross} => tax amount {taxAmount} IDR ({tax.TaxName}){Environment.NewLine}");

                gross -= taxAmount;
            }
            TaxLog = log.ToString();
            NetIncome = gross;
        }
        #endregion
    }
}
