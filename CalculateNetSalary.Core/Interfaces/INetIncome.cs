namespace CalculateNetSalary.Core.Interfaces
{
    interface INetIncome
    {
        /// <summary>
        /// Calculate employee's net income by applying taxes for his gross income
        /// </summary>
        void CalculateNetIncome();
    }
}
