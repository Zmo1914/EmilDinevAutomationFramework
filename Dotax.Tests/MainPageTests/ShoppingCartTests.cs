using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Dotax.Tests.MainPageTests
{
    internal class ShoppingCartTests : DotaxBaseTests
    {
        [TestCase(3)]
        public void AssertTotalPriceInShoppingCart(int productCounter)
        {
            addToCartFacade.AddProduct(productCounter);

            Assert.That(mainPage.ShoppingCartMiniSection.GetTotalAmount().Equals(addToCartFacade.TotalCartPrice), $"FAILED. Expected total amount of the products is not equal to actual.");
        }

        [TestCase(2)]
        public void AssertProductPriceInShoppingCart(int productCounter)
        {
            addToCartFacade.AddProduct(productCounter);

            CollectionAssert.AreEquivalent(addToCartFacade.ProductPrices, mainPage.ShoppingCartMiniSection.GetProductPrices());
        }

        // not ready
        [TestCase(2,2,3)]
        public void AssertProductPriceReserButtonsInShoppingCart(int productCounter, int productNumber, int additional)
        {
            addToCartFacade.AddProduct(productCounter);
            mainPage.MainHeaderSection.OpenShoppingCart();
            mainPage.ShoppingCartMiniSection.AddQuantityToProduct(productNumber, additional);

            bool isTrue = mainPage.ShoppingCartMiniSection.AssertPriceByQuantity(productNumber);
        }

    }
}
