using Dodax.Sections.MainHeader;
using Dodax.Sections.ShoppingCartMini;
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
        public ShoppingCartMiniSection ShoppingCartMiniSection { get; private set; }

        public MainPage(IWebDriver driver) : base(driver)
        {
            MainHeaderSection = new MainHeaderSection(driver);
            ShoppingCartMiniSection = new ShoppingCartMiniSection(driver);
        }

        private IWebElement AcceptAllButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainPageLocators.AcceptAllButton)));



        /// ********************* Footer Pagination elements *********************
        private IWebElement PaginationNextButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainPageLocators.PaginationNextButton)));

        private IWebElement PaginationBackButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainPageLocators.PaginationBackButton)));


        private IWebElement PaginationActivePageButton =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainPageLocators.PaginationAvtivePageButton)));

        private IList<IWebElement> PaginationNumericButtonList =>
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(MainPageLocators.PaginationNumericButtonList)));



        /// ********************* Search result elements *********************
        private IList<IWebElement> DataProductNameList => 
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(MainPageLocators.DataProductNameList)));

        private IList<IWebElement> DataProductButtonList =>
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(MainPageLocators.DataProductButtonList)));

        private IList<IWebElement> SearchResultPageContentList =>
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(MainPageLocators.SearchResultPageContentList)));

    }
}
