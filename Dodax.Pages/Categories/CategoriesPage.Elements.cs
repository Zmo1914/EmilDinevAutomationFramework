using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Framework.DriverSetup;

namespace Dodax.Pages.Categories
{
    public partial class CategoriesPage : BasePage
    {
        public CategoriesPage(IWebDriver driver) : base(driver)
        {
        }

        private IList<IWebElement> CategoriesList =>
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(CategoriesPageLocators.CategoriesList)));




    }
}
