using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator.TestConsole
{
    public class FakeTaxRateRepository : ITaxRepository
    {

        public decimal GetCurrentTaxRate
        {
            get
            {
                return 20m;
            }
        }

        public void StoreCurrentTaxRate(decimal taxRate)
        {
        }
    }
}
