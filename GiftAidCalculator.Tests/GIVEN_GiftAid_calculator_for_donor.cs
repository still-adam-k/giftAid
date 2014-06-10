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

        [Test]
        public void And_amount_of_donations_resulting_in_large_fraction_THEN_I_receive_rounded_gift_aid_result()
        {
            var calculator = GetAidCalculator();

            var giftAid = calculator.CalculateGiftAidFor(100.256m);

            Assert.That(giftAid, Is.EqualTo(25.06m));
        }

        private static IGiftAidCalculator GetAidCalculator()
        {
            return new AidCalculator(new FakeTaxRateRepository());
        }
    }

}
