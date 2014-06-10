using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleTo("GiftAidCalculator.Tests")]

namespace GiftAidCalculator
{
    public interface IGiftAidCalculator
    {
        decimal CalculateGiftAidFor(decimal donationAmount);
    }

    public interface IGiftAidCalculatorAdministration
    {
        void ChangeCurrentTaxRate(decimal newTaxRate);
    }

    internal class AidCalculator : IGiftAidCalculator, IGiftAidCalculatorAdministration
    {
        private ITaxRepository taxRateRepository;

        public AidCalculator(ITaxRepository taxRateRepository)
        {
            this.taxRateRepository = taxRateRepository;
        }

        public decimal CalculateGiftAidFor(decimal donationAmount)
        {   
            var ratio = CalculateGiftAidRatio();
            decimal aid =  donationAmount * ratio;
            return Decimal.Round(aid, 2);
        }

        public void ChangeCurrentTaxRate(decimal newTaxRate)
        {
            taxRateRepository.StoreCurrentTaxRate(newTaxRate);
        }

        private decimal CalculateGiftAidRatio()
        {
            var taxRate = taxRateRepository.GetCurrentTaxRate;
            return taxRate / (100 - taxRate);
        }
    }
}
