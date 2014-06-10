using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator
{
    public class AidCalculator
    {
        private decimal taxRate = 20m;

        public decimal CalculateGiftAidFor(decimal donationAmount)
        {   
            var ratio = CalculateGiftAidRatio();
            return donationAmount * ratio;
        }

        private decimal CalculateGiftAidRatio()
        {
            return taxRate / (100 - taxRate);
        }
    }
}
