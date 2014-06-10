using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class GIVEN_GiftAid_calculator
    {

        [Test]
        public void I_can_calculate_gift_aid_according_to_tax_rate()
        {
            var calculator = new AidCalculator();

            var giftAid = calculator.CalculateGiftAidFor(100m);

            Assert.That(giftAid, Is.EqualTo(25m));
        }
    }

}
