using System.ComponentModel;

namespace CalculateNetSalary.Core.Models
{
    public enum TaxTypes
    {
        [Description("Income below or equal to 1000 IDR")]
        None,
        [Description("Income above to 3000 IDR")]
        IncomeTax,
        [Description("Income above 1000 and below 3000 IDR")]
        SocialTax
    }
}
