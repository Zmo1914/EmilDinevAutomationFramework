using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Framework.DriverSetup;
using Dodax.Pages.Main;
using Dodax.Sections.MainHeader;
using System.IO;

namespace Dodax.Pages.Base
{
    public class DotaxBasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected MainPage mainPage;
        protected MainHeaderSection mainHeaderSection;

        [SetUp]
        public void TestSetup()
        {
            driver = BasePage.Start(Browser.Chrome);

            mainPage = new MainPage(driver);
            mainHeaderSection = new MainHeaderSection(driver);

            mainPage.LoginDotaxSite("https://www.dodax.ca/");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("dddd");
        }

        [TearDown]
        public void TestTeardown()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
