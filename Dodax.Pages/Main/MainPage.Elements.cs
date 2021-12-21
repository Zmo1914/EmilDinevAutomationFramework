using Dodax.Sections.MainHeader;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Framework.DriverSetup;

namespace Dodax.Pages.Main
{
    public partial class MainPage : BasePage
    {
        public MainHeaderSection MainHeaderSection { get; private set; }

        public MainPage(IWebDriver driver) : base(driver)
        {
            MainHeaderSection = new MainHeaderSection(driver);
        }

        private IList<IWebElement> SearchResultPageContentList =>
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(MainPageLocators.SearchResultPageContentList)));

    }
}
