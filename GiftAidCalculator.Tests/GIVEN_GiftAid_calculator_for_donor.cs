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
            var calculator = GiftAidCalculatorBuilder.Create().AsDonor();

            var giftAid = calculator.CalculateGiftAidFor(100m);

            Assert.That(giftAid, Is.EqualTo(25m));
        }

        [Test]
        public void The_tax_rate_is_retrieved_from_data_store()
        {
            var taxMock = new Mock<ITaxRepository>();
            var calculator = GiftAidCalculatorBuilder
                .Create()
                .WithTaxSource(taxMock.Object)
                .AsDonor();

            calculator.CalculateGiftAidFor(1m);

            taxMock.Verify(x => x.GetCurrentTaxRate);
        }

        [Test]
        public void And_amount_of_donations_resulting_in_large_fraction_THEN_I_receive_rounded_gift_aid_result()
        {
            var calculator = GiftAidCalculatorBuilder.Create().AsDonor();

            var giftAid = CalculateAmountThatWouldResultIn_25_064_giftAid(calculator);

            Assert.That(giftAid, Is.EqualTo(25.06m));
        }

        private static decimal CalculateAmountThatWouldResultIn_25_064_giftAid(IGiftAidCalculator calculator)
        {
            return calculator.CalculateGiftAidFor(100.256m);
        }
    }
}
