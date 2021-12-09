using NUnit.Framework;

namespace UI.Tests.AmazonUk
{
    class ProductDetailsPageTests : AmazonBasePageTests
    {
        [SetUp]
        public void SearchProductSetup()
        {
            mainPage.HeaderSection.SearchForProduct("Books", "Harry Potter and the Cursed Child");
            mainPage.OpenProductDetails("Harry Potter and the Cursed Child - Parts One and Two");
        }

        [TestCase("Harry Potter and the Cursed Child - Parts One and Two: The Official Playscript of the Original West End Production")]
        public void AssertProductDetailsName(string expectedProductName)
        {
            FunctionalityUnderTest(() =>
            {
                Assert.That(productDetailsPage.GetProducName().Equals(expectedProductName), "Assert failed.");
            });
        }

        [Test]
        public void AssertProductDetailsHasBadge()
        {
            FunctionalityUnderTest(() =>
            {
                Assert.That(productDetailsPage.HasBadge(), "Assert failed.");
            });
        }

        [TestCase("£4.00")]
        public void AssertProductDetailsPrice(string expectedPrice)
        {
            FunctionalityUnderTest(() =>
            {
                Assert.That(productDetailsPage.GetPrice().Equals(expectedPrice), "Assert failed.");
            });
        }

        [TestCase("Paperback")]
        public void AssertProductDetailsSelectedFormat(string expectedSelectedFormat)
        {
            FunctionalityUnderTest(() =>
            {
                Assert.That(productDetailsPage.GetSelectedFormat().Contains(expectedSelectedFormat), "Assert failed.");
            });
        }

        [TestCase("1")]
        public void AssertProductDetailsBasketCounter(string expectedSelectedFormat)
        {
            FunctionalityUnderTest(() =>
            {
                productDetailsPage.AddProductToBasket();
                Assert.That(productDetailsPage.HeaderSection.GetBasketItemCounter().Equals(expectedSelectedFormat), "Assert failed.");
            });
        }

        [Test]
        public void AssertAddedProductInBasketNotification()
        {
            FunctionalityUnderTest(() =>
            {
                productDetailsPage.AddProductToBasket();
                Assert.That(productDetailsPage.HasNewItemInBasketNotification(), "Assert failed.");
            });
        }
    }
}
