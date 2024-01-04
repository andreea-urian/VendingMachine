using System;
using iQuest.VendingMachine.Business.Payment;

namespace VendingMachine.Tests.UseCases
{
    public class CardPaymentValidatorTests
    {
        [Test]
        [TestCase("321", true)]
        [TestCase("3212", false)]
        [TestCase("jsdjasa", false)]
        [TestCase("2i1", false)]
        [TestCase("acb",false)]
        [TestCase("123", true)]
        public void TestCVV(string cvv, bool expectedValid)
        {
            bool actualValid = CardPaymentValidator.ValidCVV(cvv);

            Assert.That(actualValid, Is.EqualTo(expectedValid));
        }

        [Test]
        [TestCase("374245455400126", true)]
        [TestCase("32120998", false)]
        [TestCase("09875432569776766775", false)]
        [TestCase("8y8y8g4450012h9n", false)]
        [TestCase("qsdfrtghhyfvvcxs", false)]
        public void TestCardNumber(string cardNumber, bool expectedValid)
        {
            bool actualValid = CardPaymentValidator.ValidCardNumber(cardNumber);

            Assert.That(actualValid, Is.EqualTo(expectedValid));
        }

        [Test]
        [TestCase("8/2/2024 2:30:00 PM", true)]
        [TestCase("8.2.2024 2:30:00 AM", true)]
        [TestCase("8/2/2023 2:30:00 PM", false)]
        [TestCase("8/2/2023", false)]
        [TestCase("2:30:00 PM", false)]
        [TestCase("8.2.2023 2:30", false)]
        public void TestExpirationDate(DateTime expirationDate, bool expectedValid)
        {
            bool actualValid = CardPaymentValidator.ValidExpirationDate(expirationDate);

            Assert.That(actualValid, Is.EqualTo(expectedValid));
        }

        [Test]
        public void ValidCard_ValidInputs_ReturnsTrue()
        {
            // Arrange
            var CardPaymentValidator = new CardPaymentValidator("374245455400126", "123", DateTime.Now.AddDays(30));

            // Act
            var result = CardPaymentValidator.ValidCard();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidCard_InvalidCardNumber_ReturnsFalse()
        {
            // Arrange
            var CardPaymentValidator = new CardPaymentValidator("1234567890", "123", DateTime.Now.AddDays(30));

            // Act
            var result = CardPaymentValidator.ValidCard();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidCard_InvalidCVV_ReturnsFalse()
        {
            // Arrange
            var CardPaymentValidator = new CardPaymentValidator("374245455400126", "invalidCVV", DateTime.Now.AddDays(30));

            // Act
            var result = CardPaymentValidator.ValidCard();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidCard_ExpiredCard_ReturnsFalse()
        {
            // Arrange
            var CardPaymentValidator = new CardPaymentValidator("374245455400126", "123", DateTime.Now.AddDays(-1));

            // Act
            var result = CardPaymentValidator.ValidCard();

            // Assert
            Assert.IsFalse(result);
        }
    }
}

