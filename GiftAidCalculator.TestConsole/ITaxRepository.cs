using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator
{
    public interface ITaxRepository
    {
        decimal GetCurrentTaxRate { get; }

        void StoreCurrentTaxRate(decimal taxRate);
    }
}
