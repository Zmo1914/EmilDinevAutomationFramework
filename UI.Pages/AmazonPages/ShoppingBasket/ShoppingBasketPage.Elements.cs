using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using UI.Framework.DriverSetup;

namespace UI.Pages.AmazonPages.ShoppingBasket
{
    public partial class ShoppingBasketPage : BasePage
    {
        public ShoppingBasketPage(IWebDriver driver) : base(driver)
        {
        }

        private IList<IWebElement> ItemsList =>
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(ShoppingBasketPageLocators.ItemsList)));
    }
}
