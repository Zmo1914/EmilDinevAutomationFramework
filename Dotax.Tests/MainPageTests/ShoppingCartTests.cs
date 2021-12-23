using NUnit.Framework;

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


        }

        [TestCase("Der kleine Hobbit", "Books & Audiobooks")]
        public void GetSearcAh(string searchProductA, string productCategorie)
        {
            mainPage.MainHeaderSection.GoToAllcategoriesPage();
            mainPage.MainHeaderSection.Search(searchProductA, productCategorie);
            mainPage.GetProductToBasket(searchProductA);
        }

    }
}
