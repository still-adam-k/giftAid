using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    using System.Security.Cryptography.X509Certificates;

    using GiftAidCalculator.TestConsole;

    using Moq;

    [TestFixture]
    public class GIVEN_GiftAid_calculator_for_donor
    {

        [Test]
        public void I_can_calculate_gift_aid_according_to_tax_rate()
        {
            var calculator = GetAidCalculator();

            var giftAid = calculator.CalculateGiftAidFor(100m);

            Assert.That(giftAid, Is.EqualTo(25m));
        }

        private static IGiftAidCalculator GetAidCalculator()
        {
            return new AidCalculator(new FakeTaxRateRepository());
        }
    }

}
