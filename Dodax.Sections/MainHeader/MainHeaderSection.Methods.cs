using Dotax.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodax.Sections.MainHeader
{
    public partial class MainHeaderSection
    {
        public void Search(Categories categories)
        {
            string categrie = categories.ToString();

            HeaderSearchBarSelect.SelectByText(categrie);
            HeaderSearchBarButton.Click();
        }

        public void Search(string productName, string productCategorie)
        {            
            HeaderSearchBarSelect.SelectByText(productCategorie);
            HeaderSearchBarInput.SendKeys(productName);

            HeaderSearchBarButton.Click();
        }

        public void GoToAllcategoriesPage()
        {
            HeaderCategoriesButton.Click();
            HeaderAllCategoriesButton.Click(); //SendKeys(Keys.Enter);
        }
    }
}
