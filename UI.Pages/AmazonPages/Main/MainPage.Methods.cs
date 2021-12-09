using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using UI.Framework.Extentions;

namespace UI.Pages.AmazonPages.Main
{
    public partial class MainPage
    {
        public void LoginAmazonUk(string url)
        {
            MaximizeBrowser();
            Driver.Manage().Cookies.DeleteAllCookies();
            GoToUrl(url);
        }

        public void AcceptAllCookies()
        {
            AcceptAllButton.Click();
        }

        public void AcceptShipping()
        {
            ContinueShipButton.Click();
        }

        public List<string> ExtractTextFromSearchResultList()
        {
            List<string> newList = new();

            for (int i = 0; i < SearchResultList.Count; i++)
            {
                newList.Add(SearchResultList[i].Text);
                //Console.WriteLine(SearchResultList[i].Text);
            }            

            return newList;
        }

        public string GetTitle()
        {
            string title = Driver.Title;
            return title;
        }

        public void OpenProductDetails(string productName)
        {
            for (int i = 0; i < SearchResultTitleList.Count; i++)
            {
                if (SearchResultTitleList[i].Text.Contains(productName))
                {
                    SearchResultTitleList[i].Click();
                    WaitForElementToExist(60, By.XPath("//input[@id='add-to-cart-button']"));

                    break;
                }
            }
        }

    }
}
