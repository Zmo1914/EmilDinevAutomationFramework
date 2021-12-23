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
        public string TotalCartPrice { get => totalPrice.ToString("0.00"); }

        private MainPage MainPage;
        private CategoriesPage CategoriesPage;

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
                totalPrice += float.Parse(productA[1], CultureInfo.InvariantCulture);

                MainPage.MainHeaderSection.GoToMainPage();
            }

        }
    }
}
