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

        /// <summary>
        /// INPUT element 'Search box'. Main search in the page/section.
        /// </summary>
        private IWebElement SearchBoxInput =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(HeaderSectionLocators.SearchBoxInputCss)));

        /// <summary>
        /// Button element 'Submit' of the main search bar.
        /// </summary>
        private IWebElement SearchBoxSubmitButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(HeaderSectionLocators.SearchBoxSubmitButtonCss)));

        /// <summary>
        /// BUTTON element 'Bascket' int the upper right corner of the section.
        /// </summary>
        private IWebElement BasketButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(HeaderSectionLocators.BasketButtonCss)));


        /// <summary>
        /// SELECT element 'Search in'.
        /// </summary>
        private SelectElement SearchBoxSelect
        {
            get
            {
                IWebElement element =
                    Wait.Until(ExpectedConditions.ElementExists(By.CssSelector(HeaderSectionLocators.SearchBoxSelectCss)));

                return new SelectElement(element);
            }
        }
    }
}
