using Newtonsoft.Json;
using Npgsql;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using UI.Framework.Data;

namespace UI.Framework.DriverSetup
{
    public abstract partial class BasePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public IWebDriver Driver => driver;
        public WebDriverWait Wait => wait;


        public FrameworkData FrameworkData { get; private set; } 

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            FrameworkData = new FrameworkData();
            FrameworkData = JsonConvert.DeserializeObject<FrameworkData>(File.ReadAllText("Data\\Framework.json"));
        }


        public static IWebDriver Start(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    {
                        var options = new ChromeOptions
                        {
                            AcceptInsecureCertificates = true
                        };
                        return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
                    }
                case Browser.ChromeHeadless:
                    {
                        var options = new ChromeOptions
                        {
                            AcceptInsecureCertificates = true
                        };
                        options.AddArgument("headless");
                        options.AddArgument("disable-gpu");
                        options.AddArgument("start-maximized");
                        options.AddArgument("window-size=1920,1080");

                        return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }
        }

        public void FocutToElement(IWebElement element)
        {            
            Actions actions = new(driver);
            actions.MoveToElement(element);
            actions.Perform();

        }

        public void ScrollToBottomOfPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public void GoToUrl(string url)
        {
            MaximizeBrowser();
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().GoToUrl(url);

            Console.WriteLine($"Time: {DateTime.Now} | Page address: {url} is loaded.");
        }

        public void MaximizeBrowser()
        {
            Driver.Manage().Window.Maximize();
        }

        public void AcceptAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
        }


        public IWebElement WaitForElementToExist(int waitTimeInSeconds, By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeInSeconds));
                IWebElement element = wait.Until(ExpectedConditions.ElementExists(by));

                return element;
            }
            catch (NoSuchElementException exception)
            {
                Console.WriteLine($"Time: {DateTime.Now} | Exception {exception.Message}.");

                return null;
            }
        }

        public bool IsElementExist(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }
    }
}
