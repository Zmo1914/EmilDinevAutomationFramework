﻿using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using UI.Framework.Data;
using UI.Framework.DriverSetup;
using UI.Pages.AmazonPages.Main;
using UI.Pages.AmazonPages.ProductDetails;
using UI.Pages.AmazonPages.ShoppingBasket;

namespace UI.Tests.AmazonUk
{
    public class AmazonBasePageTests
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected MainPage mainPage;
        protected ProductDetailsPage productDetailsPage;
        protected ShoppingBasketPage shoppingBasketPage;
        //protected FrameworkData frameworkData;

        [SetUp]
        public void TestSetup()
        {
            //frameworkData = new FrameworkData();
            //frameworkData = JsonConvert.DeserializeObject<FrameworkData>(File.ReadAllText("Data\\Framework.json"));

            driver = BasePage.Start(Browser.Chrome);

            mainPage = new MainPage(driver);
            productDetailsPage = new ProductDetailsPage(driver);
            shoppingBasketPage = new ShoppingBasketPage(driver);

            mainPage.LoginAmazonUk("https://www.amazon.co.uk/");
            mainPage.AcceptAllCookies();
            mainPage.AcceptShipping();
        }

        [TearDown]
        public void TestTeardown()
        {
            driver.Close();
            driver.Quit();
        }

        protected void FunctionalityUnderTest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                string screenshotFileName = $"{TestContext.CurrentContext.Test.MethodName}_{DateTime.Now.Hour}_{DateTime.Now.Second}.jpg";
                string filePath = "C:\\Users\\emild\\source\\repos\\EmilDinevAutomationFramework\\Screenshots\\";

                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(@$"{filePath}{screenshotFileName}");

                using (StreamWriter file = new StreamWriter(Path.Combine(@$"{filePath}Test_Logger.log"), true))
                {
                    file.WriteLine(
                        $"TIME: {DateTime.Now} | Test Name: \"{TestContext.CurrentContext.Test.Name}\"\n" +
                        $"    - Screenshot: \"{screenshotFileName}\"\n" +
                        $"    - Error message: {ex.Message}\n" +
                        $"----------------\n");
                    file.Close();
                }

                throw;
            }
        }
    }
}
