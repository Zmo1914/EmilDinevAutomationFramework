using OpenQA.Selenium;
using UI.Framework.Extentions;

namespace UI.Pages.AmazonSections.Header
{
    public partial class HeaderSection
    {
        public void SearchForProduct(string productType, string productName)
        {
            SearchBoxSelect.SelectValueByText(productType);
            SearchBoxInput.SendKeys(productName);
            SearchBoxSubmitButton.Click();
        }

        public string GetBasketItemCounter()
        {
            return BasketButton.Text;
        }

        public void GoToShoppingBasket()
        {
            BasketButton.Click();

            WaitForElementToExist(20, By.XPath("//h1[contains(text(),'Shopping Basket')]"));
        }

    }
}
