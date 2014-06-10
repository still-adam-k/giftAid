using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator.Tests
{
    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class GIVEN_Gift_Aid_calculator_for_admin
    {
        [Test]
        public void The_tax_rate_is_retrieved_from_data_store()
        {
            var taxMock = GetDataStoreMock();
            var calculator = GetAidCalculatorWithMockedDataStore(taxMock);

            calculator.CalculateGiftAidFor(1m);

            taxMock.Verify(x => x.GetCurrentTaxRate);
        }

        [Test]
        public void And_I_set_the_new_rate_THEN_the_rate_should_be_changed_in_data_store()
        {
            var taxMock = new Mock<ITaxRepository>();
            var calculator = GetAidCalculatorWithMockedDataStore(taxMock);

            calculator.ChangeCurrentTaxRate(0.25m);

            taxMock.Verify(x => x.StoreCurrentTaxRate(0.25m));
        }

        private static AidCalculator GetAidCalculatorWithMockedDataStore(Mock<ITaxRepository> taxMock)
        {
            ITaxRepository taxRateRepository = taxMock.Object;

            var calculator = new AidCalculator(taxRateRepository);
            return calculator;
        }

        private static Mock<ITaxRepository> GetDataStoreMock()
        {
            return new Mock<ITaxRepository>();
        }
    }
}
