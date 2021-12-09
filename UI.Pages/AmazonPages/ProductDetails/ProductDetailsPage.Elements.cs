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
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProductDetailsPageLocators.AddToBacketButton)));

        private IWebElement ProductTitleLabel =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ProductDetailsPageLocators.ProductTitleLabel)));

        private IWebElement ProductBadge =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ProductDetailsPageLocators.ProductBadge)));

        private IWebElement ProductPriceLabel =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ProductDetailsPageLocators.ProductPriceLabel)));

        private IWebElement SelectedFormatButton =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ProductDetailsPageLocators.SelectedFormatButton)));

        private IWebElement NewItemInBasketNotification =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ProductDetailsPageLocators.NewItemInBasketNotification)));


    }
}
