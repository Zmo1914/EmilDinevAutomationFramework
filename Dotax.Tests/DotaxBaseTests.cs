﻿using System;
using Dodax.Facades.AddToCart;
using Dodax.Pages.Categories;
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
        protected CategoriesPage categoriesPage; 
        protected AddToCartFacade addToCartFacade;

        [SetUp]
        public void TestSetup()
        {
            driver = BasePage.Start(Browser.Chrome);

            mainPage = new MainPage(driver);
            categoriesPage = new CategoriesPage(driver);
            addToCartFacade = new AddToCartFacade(driver);

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