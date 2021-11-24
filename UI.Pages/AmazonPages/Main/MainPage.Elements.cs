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
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.
                XPath("//input[@id='sp-cc-accept']")));

        private IWebElement ContinueShipButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.
                XPath("//span[contains(text(),'CONTINUE')]/parent::span")));


        private IList<IWebElement> SearchResultTitleList => Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.
                XPath("//span[@class='a-size-medium a-color-base a-text-normal']")));

        private IList<IWebElement> SearchResultList => Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.
            XPath("//span[@class='a-size-medium a-color-base a-text-normal']/ancestor::div[@class='a-section']")));
    }

}

