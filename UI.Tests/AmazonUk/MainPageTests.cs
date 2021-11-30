using NUnit.Framework;
using UI.TestData.AmazonTestData;

namespace UI.Tests.AmazonUk
{
    public class MainPageTests : AmazonBasePageTests
    {

        [TestCase("Amazon.co.uk: Low Prices in Electronics, Books, Sports Equipment & more")]
        public void AssertWebPageTitle(string expectedTitle)
        {
            Assert.That(mainPage.GetTitle().Equals(expectedTitle), "Assert failed.");
        }

        [TestCaseSource(typeof(Product), "SetValues_AssertFirstShowedSearchProductAvailability")]
        public void AssertFirstShowedSearchProductAvailability(Product product)
        {
            mainPage.HeaderSection.SearchForProduct(product.Type, product.SearchName);

            Assert.That(mainPage.ExtractTextFromSearchResultList()[0].Contains(product.ExpectedName), $"Assert failed.");
        }

        [TestCaseSource(typeof(Product), "SetValues_AssertSearchProductHasBadge")]
        public void AssertSearchProductHasBadge(Product product)
        {
            mainPage.HeaderSection.SearchForProduct(product.Type, product.SearchName);

            Assert.That(mainPage.ExtractTextFromSearchResultList()[0].Contains(product.Badge), $"Assert failed.");
        }

        [TestCase("Books", "Harry Potter and the Cursed Child", "£4\r\n00")]
        public void AssertSearchProductPrice(string productType, string productName, string expectedPrice)
        {
            mainPage.HeaderSection.SearchForProduct(productType, productName);

            Assert.That(mainPage.ExtractTextFromSearchResultList()[0].Contains(expectedPrice), $"Assert failed.");
        }
    }
}
