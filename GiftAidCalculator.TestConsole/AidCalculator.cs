using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator
{
    public class AidCalculator
    {
        public decimal CalculateGiftAidFor(decimal p)
        {
            return GiftAidAmount(p);
        }

        static decimal GiftAidAmount(decimal donationAmount)
        {
            var gaRatio = 20m / (100 - 20m);
            return donationAmount * gaRatio;
        }
    }
}
