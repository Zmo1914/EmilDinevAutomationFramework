using NUnit.Framework;
using UI.TestData.AmazonTestData;

namespace UI.Tests.AmazonUk
{
    public class MainPageTests : AmazonBasePageTests
    {

        [TestCase("Amazon.co.uk: Low Prices in Electronics, Books, Sports Equipment & more")]
        public void AssertWebPageTitle(string expectedTitle)
        {
            FunctionalityUnderTest(() =>
            {
                Assert.That(mainPage.GetTitle().Equals(expectedTitle), "Assert failed.");
            });
        }

        [TestCaseSource(typeof(Product), "SetValues_AssertFirstShowedSearchProductAvailability")]
        public void AssertFirstShowedSearchProductAvailability(Product product)
        {
            FunctionalityUnderTest(() =>
            {
                mainPage.HeaderSection.SearchForProduct(product.Type, product.SearchName);
                Assert.That(mainPage.ExtractTextFromSearchResultList()[0].Contains(product.ExpectedName), $"Assert failed.");
            });
        }

        [TestCaseSource(typeof(Product), "SetValues_AssertSearchProductHasBadge")]
        public void AssertSearchProductHasBadge(Product product)
        {
            FunctionalityUnderTest(() =>
            {
                mainPage.HeaderSection.SearchForProduct(product.Type, product.SearchName);
                Assert.That(mainPage.ExtractTextFromSearchResultList()[0].Contains(product.Badge), $"Assert failed.");
            });
        }

        [TestCaseSource(typeof(Product), "SetValues_AssertSearchProductPrice")]
        public void AssertSearchProductPrice(Product product)
        {
            FunctionalityUnderTest(() =>
            {
                mainPage.HeaderSection.SearchForProduct(product.Type, product.SearchName);
                Assert.That(mainPage.ExtractTextFromSearchResultList()[0].Contains(product.Price), $"Assert failed.\n" +
                    $"Expected price:{product.Price} |");
            });

        }
    }
}
