using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

        [TestCase(3)]
        public void AssertTotalPriceInChoppingCart(int productCounter)
        {
            addToCartFacade.AddProduct(productCounter);

            Assert.That(mainPage.ShoppingCartMiniSection.GetTotalAmount().Equals(addToCartFacade.TotalCartPrice), $"FAILED. Expected total amount of the products is not equal to actual.");
        }

        [TestCase(2)]
        public void AssertProductPriceInChoppingCart(int productCounter)
        {
            addToCartFacade.AddProduct(productCounter);

            CollectionAssert.AreEquivalent(addToCartFacade.ProductPrices, mainPage.ShoppingCartMiniSection.GetProductPrices());
        }

        [TestCase(4)]
        public void AssertProductPriceReserButtonsInChoppingCart(int productCounter)
        {
            addToCartFacade.AddProduct(productCounter);
            mainPage.ShoppingCartMiniSection.AddQuantityToProduct(2,3);
        }

    }
}
