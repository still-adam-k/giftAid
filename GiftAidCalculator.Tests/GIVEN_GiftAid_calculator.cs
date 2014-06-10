using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    using System.Security.Cryptography.X509Certificates;

    using GiftAidCalculator.TestConsole;

    using Moq;

    [TestFixture]
    public class GIVEN_GiftAid_calculator
    {

        [Test]
        public void I_can_calculate_gift_aid_according_to_tax_rate()
        {
            var calculator = GetAidCalculator();

            var giftAid = calculator.CalculateGiftAidFor(100m);

            Assert.That(giftAid, Is.EqualTo(25m));
        }

        [Test]
        public void The_tax_rate_is_retrieved_from_data_store()
        {
             var taxMock = new Mock<ITaxRepository>();
            ITaxRepository taxRateRepository = taxMock.Object;

            var calculator = new AidCalculator(taxRateRepository);

            calculator.CalculateGiftAidFor(1m);

            taxMock.Verify(x => x.GetCurrentTaxRate);
        }

        private static AidCalculator GetAidCalculator()
        {
            return new AidCalculator(new FakeTaxRateRepository());
        }
    }

}
