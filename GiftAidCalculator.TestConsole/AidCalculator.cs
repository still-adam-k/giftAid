using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator
{
    public class AidCalculator
    {
        private decimal taxRate = 20m;
        private ITaxRepository taxRateRepository;

        public AidCalculator(ITaxRepository taxRateRepository)
        {
            this.taxRateRepository = taxRateRepository;
        }

        public decimal CalculateGiftAidFor(decimal donationAmount)
        {   
            var ratio = CalculateGiftAidRatio();
            return donationAmount * ratio;
        }

        private decimal CalculateGiftAidRatio()
        {
            var taxRate = taxRateRepository.GetCurrentTaxRate;
            return taxRate / (100 - taxRate);
        }

        public void ChangeCurrentTaxRate(decimal p)
        {
            taxRateRepository.StoreCurrentTaxRate(p);
        }
    }
}
