using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Framework.DriverSetup;

namespace UI.Pages.AmazonSections.Header
{
    public partial class HeaderSection : BasePage
    {
        public HeaderSection(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement SearchBoxInput =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='twotabsearchtextbox']")));

        private IWebElement SearchBoxSubmitButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@value='Go']")));

        private IWebElement BasketButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='nav-cart-count']")));


        private SelectElement SearchBoxSelect
        {
            get
            {
                IWebElement element =
                    Wait.Until(ExpectedConditions.ElementExists(By.XPath("//select[@id='searchDropdownBox']")));

                return new SelectElement(element);
            }
        }

    }
}
