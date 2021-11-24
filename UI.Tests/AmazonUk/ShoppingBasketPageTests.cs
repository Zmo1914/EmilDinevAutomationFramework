using NUnit.Framework;

namespace UI.Tests.AmazonUk
{
    class ShoppingBasketPageTests : AmazonBasePageTests
    {
        [SetUp]
        public void SearchProductSetup()
        {
            mainPage.HeaderSection.SearchForProduct("Books", "Harry Potter and the Cursed Child");
            mainPage.OpenProductDetails("Harry Potter and the Cursed Child - Parts One and Two");

            productDetailsPage.AddProductToBasket();
            productDetailsPage.HeaderSection.GoToShoppingBasket();
        }

        [TestCase("Harry Potter and the Cursed Child - Parts One and Two")]
        public void Test1(string expectedItem)
        {
            Assert.That(shoppingBasketPage.CheckItem(expectedItem));
        }

    }
}
