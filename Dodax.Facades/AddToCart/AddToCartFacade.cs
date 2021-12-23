using Dodax.Pages.Categories;
using Dodax.Pages.Main;
using Dodax.Sections.MainHeader;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Framework.DriverSetup;

namespace Dodax.Facades.AddToCart
{
    public class AddToCartFacade : BasePage
    {
        private float totalPrice;
        private IList<string> productNames = new List<string>();
        private IList<string> productPrices = new List<string>();

        public string TotalCartPrice { get => totalPrice.ToString("0.00"); }
        public IList<string> ProductNames { get => productNames; set => productNames = value; }
        public IList<string> ProductPrices { get => productPrices; set => productPrices = value; }

        private readonly MainPage MainPage;
        private readonly CategoriesPage CategoriesPage;

        public AddToCartFacade(IWebDriver driver) : base(driver)
        {
            CategoriesPage = new CategoriesPage(driver);
            MainPage = new MainPage(driver);
        }

        public void AddProduct(int count)
        {
            
            for (int i = 0; i < count; i++)
            {
                MainPage.MainHeaderSection.GoToAllcategoriesPage();
                CategoriesPage.SelectCategory();
                string[] productA = MainPage.GetProductToBasket();
                productNames.Add(productA[0]);
                productPrices.Add(productA[1]);

                totalPrice += float.Parse(productA[1], CultureInfo.InvariantCulture);

                MainPage.MainHeaderSection.GoToMainPage();
            }

        }
    }
}
