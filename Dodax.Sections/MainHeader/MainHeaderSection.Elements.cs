using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Framework.DriverSetup;

namespace Dodax.Sections.MainHeader
{
    public partial class MainHeaderSection : BasePage
    {
        public MainHeaderSection(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement HeaderSearchBarInput => 
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(MainHeaderSectionLocators.HeaderSearchBarInput)));

        private IWebElement HeaderSearchBarButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainHeaderSectionLocators.HeaderSearchBarInput)));

        private IWebElement HeaderSearchBarSelect =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainHeaderSectionLocators.HeaderSearchBarSelect)));

        private IWebElement HeaderShoppingCartButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainHeaderSectionLocators.HeaderShoppingCartButton)));

    }
}
