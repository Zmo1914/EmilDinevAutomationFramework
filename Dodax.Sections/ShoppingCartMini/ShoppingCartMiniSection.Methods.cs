using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodax.Sections.ShoppingCartMini
{
    public partial class ShoppingCartMiniSection
    {
        public string GetTotalAmount()
        {
            MainHeaderSection.OpenShoppingCart();
            if (MainHeaderSection.GetShoppingCartCounter() > 0)
            {
                return float.Parse(TotalAmountLabel.GetAttribute("data-qa-total"), CultureInfo.InvariantCulture).ToString("0.00");
            }
            return null;
        }

        public List<string> GetProductPrices()
        {
            List<string> products = new();

            for (int i = 0; i < ShoppingCartProductList.Count; i++)
            {
                products.Add(ShoppingCartProductList[i].GetAttribute("data-product-price"));
            }

            return products;
        }


        public void AddQuantityToProduct(int productNumber, int quantity)
        {
            VIewShoppingCartButton.Click();
            for (int i = 0; i < quantity; i++)
            {
                PlusButtonsList[productNumber - 1].SendKeys(Keys.Enter);
            }
            MainHeaderSection.OpenShoppingCart();

            
        }

        public bool AssertPriceByQuantity(int productNumber)
        {
            float total = float.Parse(ShoppingCartProductList[productNumber - 1].GetAttribute("data-product-price"), CultureInfo.InvariantCulture);
            float preUnit = float.Parse(ShoppingCartProductList[productNumber - 1].GetAttribute("data-product-price-item"), CultureInfo.InvariantCulture);
            float quant = float.Parse(ShoppingCartProductList[productNumber - 1].GetAttribute("data-product-qty"));

            if (total == (preUnit*quant))
            {
                return true;
            }
            return false;
        }
    }
}
