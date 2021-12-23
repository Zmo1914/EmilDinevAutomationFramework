using System;
using Dodax.Pages.Main;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UI.Framework.DriverSetup;

namespace Dotax.Tests
{
    public class DotaxBaseTests
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected MainPage mainPage;

        [SetUp]
        public void TestSetup()
        {
            driver = BasePage.Start(Browser.Chrome);

            mainPage = new MainPage(driver);

            mainPage.GoToUrl("https://www.dodax.ca/");
            mainPage.AcceptAll();
        }

        [TearDown]
        public void TestTeardown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}