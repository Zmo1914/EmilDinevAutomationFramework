using NUnit.Framework;
using System.Globalization;

namespace Dotax.Tests.MainPageTests
{
    internal class ShoppingCartTests : DotaxBaseTests
    {
        [TestCase(
            "Der kleine Hobbit",
            "Der kleine Hobbit, Veredelte Mini-Ausgabe",
            "Der Matrix Code",
            "Books & Audiobooks")]
        public void GetSearch(string searchProductA, string searchProductB, string searchProductC, string productCategorie)
        {
            mainPage.MainHeaderSection.Search(searchProductA, productCategorie);
            mainPage.MainHeaderSection.Search(searchProductB, productCategorie);
            mainPage.MainHeaderSection.Search(searchProductC, productCategorie);
            //mainPage.MainHeaderSection.Search(searchProductA, productCategorie);


        }

        [Test]
        public void AssertTotalPriceChoppingCart()
        {
            addToCartFacade.AddProduct(3);

            string expectedPrice = addToCartFacade.TotalCartPrice;

            float actualTotalAmount = mainPage.ShoppingCartMiniSection.GetTotalAmount();
            string actual = actualTotalAmount.ToString("0.00");
            Assert.That(actual.Equals(expectedPrice), $"FAILED. Expected total amount of the products is not equal to actual.");

        }
            

    }
}
