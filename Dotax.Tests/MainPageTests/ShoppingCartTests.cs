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

        [TestCase]
        public void AssertTotalPriceChoppingCart()
        {
            mainPage.MainHeaderSection.GoToAllcategoriesPage();
            categoriesPage.SelectCategory();
            string[] productA = mainPage.GetProductToBasket();
            mainPage.MainHeaderSection.GoToMainPage();

            mainPage.MainHeaderSection.GoToAllcategoriesPage();
            categoriesPage.SelectCategory();
            string[] productB = mainPage.GetProductToBasket();
            mainPage.MainHeaderSection.GoToMainPage();

            mainPage.MainHeaderSection.GoToAllcategoriesPage();
            categoriesPage.SelectCategory();
            string[] productC = mainPage.GetProductToBasket();
            mainPage.MainHeaderSection.GoToMainPage();

            float expectedTotalAmount = float.Parse(productA[1], CultureInfo.InvariantCulture) + float.Parse(productB[1],
                CultureInfo.InvariantCulture) + float.Parse(productC[1], CultureInfo.InvariantCulture);
            string expected = expectedTotalAmount.ToString("0.00");

            float actualTotalAmount = mainPage.ShoppingCartMiniSection.GetTotalAmount();
            string actual = actualTotalAmount.ToString("0.00");
            Assert.That(actual.Equals(expected), $"FAILED. Expected total amount of the products is not equal to actual.");

        }

    }
}
