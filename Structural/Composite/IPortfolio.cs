using System;

namespace Structural.Composite
{
    /// <summary>
    /// represents a set of assets (portfolio)
    /// can calculate approximate price of itself
    /// </summary>
    public interface IPortfolio
    {
        int Id { get; }
        void AddDeal(IPortfolio child);
        void RemoveDeal(IPortfolio child);
        double EstimateForwardPrice(DateTime at);
    }
}