using NUnit.Framework;

namespace UI.Tests.AmazonUk
{
    public class MainPageTests : AmazonBasePageTests
    {

        [TestCase("Amazon.co.uk: Low Prices in Electronics, Books, Sports Equipment & more")]
        public void AssertWebPageTitle(string expectedTitle)
        {
            Assert.That(mainPage.GetTitle().Equals(expectedTitle), "Assert failed.");
        }

        [TestCase("Books", "Harry Potter and the Cursed Child", "Harry Potter and the Cursed Child - Parts One and Two")]
        public void AssertFirstShowedSearchProductAvailability(string productType, string productName, string expectedValue)
        {
            mainPage.HeaderSection.SearchForProduct(productType, productName);

            Assert.That(mainPage.ExtractTextFromSearchResultList()[0].Contains(expectedValue), $"Assert failed.");
        }

        [TestCase("Books", "Harry Potter and the Cursed Child", "Best Seller")]
        public void AssertSearchProductHasBadge(string productType, string productName, string expectedBadge)
        {
            mainPage.HeaderSection.SearchForProduct(productType, productName);

            Assert.That(mainPage.ExtractTextFromSearchResultList()[0].Contains(expectedBadge), $"Assert failed.");
        }

        [TestCase("Books", "Harry Potter and the Cursed Child", "£4\r\n00")]
        public void AssertSearchProductPrice(string productType, string productName, string expectedPrice)
        {
            mainPage.HeaderSection.SearchForProduct(productType, productName);

            Assert.That(mainPage.ExtractTextFromSearchResultList()[0].Contains(expectedPrice), $"Assert failed.");
        }
    }
}
