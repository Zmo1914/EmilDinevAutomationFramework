using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using UI.Framework.DriverSetup;
using UI.Pages.AmazonSections.Header;

namespace UI.Pages.AmazonPages.Main
{
    public partial class MainPage : BasePage
    {
        public HeaderSection HeaderSection { get; private set; }


        public MainPage(IWebDriver driver) : base(driver)
        {
            HeaderSection = new HeaderSection(driver);
        }


        private IWebElement AcceptAllButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainPageLocators.AcceptAllButton)));

        private IWebElement ContinueShipButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainPageLocators.ContinueShipButton)));


        private IList<IWebElement> SearchResultTitleList =>
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(MainPageLocators.SearchResultTitleList)));

        private IList<IWebElement> SearchResultList =>
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(MainPageLocators.SearchResultList)));
    }

}

