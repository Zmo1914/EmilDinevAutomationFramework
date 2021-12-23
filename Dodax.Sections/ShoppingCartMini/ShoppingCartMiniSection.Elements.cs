using Dodax.Sections.MainHeader;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Framework.DriverSetup;

namespace Dodax.Sections.ShoppingCartMini
{
    public partial class ShoppingCartMiniSection : BasePage
    {
        public MainHeaderSection MainHeaderSection;

        public ShoppingCartMiniSection(IWebDriver driver) : base(driver)
        {
            MainHeaderSection = new MainHeaderSection(driver);
        }

        private IWebElement TotalAmountLabel =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ShoppingCartMiniSectionLocators.TotalAmountLabel)));
    }
}
