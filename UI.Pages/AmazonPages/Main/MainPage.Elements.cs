using Npgsql;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using UI.Framework.Data;
using UI.Framework.DriverSetup;
using UI.Pages.AmazonSections.Header;

namespace UI.Pages.AmazonPages.Main
{
    public partial class MainPage : BasePage
    {
        public HeaderSection HeaderSection { get; private set; }

        private DataBaseConnection DataBaseConnection { get; set; }

        public MainPage(IWebDriver driver) : base(driver)
        {
            HeaderSection = new HeaderSection(driver);
            DataBaseConnection = new DataBaseConnection();
        }
        
        private IWebElement AcceptAllButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath(DataBaseConnection.GetLocatorByName("AcceptAllButton"))));

        private IWebElement ContinueShipButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath(DataBaseConnection.GetLocatorByName("ContinueShipButton"))));

        private IList<IWebElement> SearchResultTitleList =>
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy
                (By.XPath(DataBaseConnection.GetLocatorByName("SearchResultTitleList"))));

        private IList<IWebElement> SearchResultList =>
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(
                By.XPath(DataBaseConnection.GetLocatorByName("SearchResultList"))));
    }

}

