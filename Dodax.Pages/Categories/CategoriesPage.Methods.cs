using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodax.Pages.Categories
{
    public partial class CategoriesPage
    {
        public void SelectCategory(string categoryName)
        {
            IList<IWebElement> category = Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By
                .XPath($"//div[@class='cat-categories']/descendant::a[text()='{categoryName}']")));

            if (category.Count != 0)
            {
                string extractedName = category[0].Text;
                category[0].SendKeys(Keys.Enter);
                Console.WriteLine($"Time: {DateTime.Now} | Category \"{extractedName}\" selected.");
                return;
            }
            Console.WriteLine($"Time: {DateTime.Now} | No such category \"{categoryName}\".");
        }

        public void SelectCategory()
        {
            if (CategoriesList.Count != 0)
            {
                var random = new Random();
                int randomCategory = random.Next(CategoriesList.Count);

                string categorynName = CategoriesList[randomCategory].Text;

                CategoriesList[randomCategory].SendKeys(Keys.Enter);

                Console.WriteLine($"Time: {DateTime.Now} | Category \"{categorynName}\" selected.");
                return;
            }
            Console.WriteLine($"Time: {DateTime.Now} | No category selected.");
        }

    }
}
