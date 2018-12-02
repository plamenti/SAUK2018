using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AmazonProductOrder
{
    [TestClass]
    public class ProductOrder
    {
        private static IWebDriver driver;
        private HomePage homePage;

        public ProductOrder()
        {
            string browser = ConfigurationManager.AppSettings["browser"];
            switch (browser)
            {
                case "firefox":
                    driver = new FirefoxDriver(); break;
                case "chrome":
                    driver = new ChromeDriver(); break;
                default: driver = new FirefoxDriver(); break;
            }

            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);
        }

        [TestInitialize]
        public void InitializeTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [TestMethod]
        public void SearchProduct()
        {

            homePage.Navigate();
            homePage.GoToLoginPage();
            homePage.Login();
            homePage.Search();

            // Assert
            Assert.IsTrue(homePage.IsResutFound(), "The result is not found");

            homePage.GoToDetails();
            homePage.AddToCard();
            homePage.Checkout();

            // Assert
            
            Assert.IsTrue(homePage.IsName(), "The result is not found");
        }
    }
}
