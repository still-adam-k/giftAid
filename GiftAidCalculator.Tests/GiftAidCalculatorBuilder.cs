using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator.Tests
{
    using GiftAidCalculator.TestConsole;

    internal class GiftAidCalculatorBuilder
    {
        private ITaxRepository taxRepository;

        public GiftAidCalculatorBuilder()
        {
            taxRepository = new FakeTaxRateRepository();
        }

        public static GiftAidCalculatorBuilder Create()
        {
            return new GiftAidCalculatorBuilder();
        }

        public GiftAidCalculatorBuilder WithTaxSource(ITaxRepository taxRepository)
        {
            this.taxRepository = taxRepository;
            return this;
        }

        private AidCalculator Build()
        {
            return new AidCalculator(this.taxRepository);
        }

        public IGiftAidCalculatorAdministration AsAdmin()
        {
            return this.Build();
        }

        public IGiftAidCalculator AsDonor()
        {
            return this.Build();
        }
    }
}
