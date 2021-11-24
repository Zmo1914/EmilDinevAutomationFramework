using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using UI.Framework.DriverSetup;
using UI.Pages.AmazonSections.Header;

namespace UI.Pages.AmazonPages.ProductDetails
{
    public partial class ProductDetailsPage : BasePage
    {
        public ProductDetailsPage(IWebDriver driver) : base(driver)
        {
            HeaderSection = new HeaderSection(driver);
        }

        public HeaderSection HeaderSection { get; private set; }

        private IWebElement AddToBacketButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='add-to-cart-button']")));

        private IWebElement ProductTitleLabel =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='productTitle']")));

        private IWebElement ProductBadge =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='badge-wrapper']/a")));

        private IWebElement ProductPriceLabel =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='price']")));

        private IWebElement SelectedFormatButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.
                XPath("//span[@class='a-button a-button-selected a-spacing-mini a-button-toggle format']")));

        private IWebElement NewItemInBasketNotification =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='huc-v2-order-row-container']")));


    }
}
