using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Dodax.Pages.Main
{
    public partial class MainPage
    {

        public void AcceptAll()
        {
            AcceptAllButton.Click();
        }

        public void ToNextPageByContinue(int pageCounter)
        {
            try
            {
                for (int i = 0; i < pageCounter; i++)
                {
                    PaginationNextButton.SendKeys(Keys.Enter);
                }
            }
            catch (NoSuchElementException exception)
            {
                System.Console.WriteLine(exception.Message);
            }

        }

        public void ToPrevPageByBack(int pageCounter)
        {
            try
            {
                for (int i = 0; i < pageCounter; i++)
                {
                    PaginationBackButton.SendKeys(Keys.Enter);
                }
            }
            catch (NoSuchElementException exception)
            {
                System.Console.WriteLine(exception.Message);
            }

        }


        public void ToNextPage(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int currentPage = int.Parse(PaginationActivePageButton.Text);
                IList<IWebElement> nextPageElement = Driver.FindElements(By
                    .XPath($"//a[@data-qa='paginationLink' and @data-page='{currentPage}']"));
                if (nextPageElement.Count != 0)
                {
                    nextPageElement[0].SendKeys(Keys.Enter);
                }
            }
        }

        public void ToNextPageByDots(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int currentPage = int.Parse(PaginationActivePageButton.Text);
                IList<IWebElement> nextPageElement = Driver.FindElements(By
                    .XPath($"//a[@data-qa='paginationLink' and @data-page='{currentPage}']"));
                if (nextPageElement.Count != 0)
                {
                    nextPageElement[1].SendKeys(Keys.Enter);
                }
            }
        }


        public void ToLastPage()
        {
            PaginationNumericButtonList[PaginationNumericButtonList.Count - 1].SendKeys(Keys.Enter);
        }


        public bool CheckActivePageNumber(int pageNumber)
        {
            if (int.Parse(PaginationActivePageButton.Text) == pageNumber)
                return true;

            return false;
        }

        public void GetProductToBasket(string productName)
        {
            for (int i = 0; i < DataProductButtonList.Count; i++)
            {
                string dataProductName = DataProductNameList[i].GetAttribute("data-product-name");
                if (dataProductName.Equals(productName))
                {
                    DataProductButtonList[i].Click();
                    Console.WriteLine($"Time: {DateTime.Now} | Product with data name \"{dataProductName}\" added in basket.");
                }
            }
        }

        public string[] GetProductToBasket()
        {
            if (DataProductNameList.Count != 0)
            {
                var random = new Random();
                int randomProduct = random.Next(DataProductNameList.Count);

                string[] productData = new string[] { 
                    DataProductNameList[randomProduct].GetAttribute("data-product-name"),
                    DataProductNameList[randomProduct].GetAttribute("data-product-price") };

                int counterBeforeAdd = MainHeaderSection.GetShoppingCartCounter();
                DataProductButtonList[randomProduct].SendKeys(Keys.Enter);

                Console.WriteLine($"Time: {DateTime.Now} | Product with data \"{productData[0]}\" added in basket.");

                while (true)
                {
                    if (MainHeaderSection.GetShoppingCartCounter() > counterBeforeAdd)
                    {
                        break;
                    }
                    Thread.Sleep(500);
                }
                return productData;
            }

            return null;
        }
    }
}
