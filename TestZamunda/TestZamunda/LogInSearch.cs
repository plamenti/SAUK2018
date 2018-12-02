using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TestZamunda.Pages;

namespace TestZamunda
{
    [TestClass]
    public class LogInSearch
    {
        private static IWebDriver driver;
        private HomePage homePage;

        
        [TestInitialize]
        public void InitializeTest()
        {
            //driver = new FirefoxDriver();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);

            /*
             !!! This is only for demo purposes !!!

             An implicit wait is to tell WebDriver to poll the DOM
             for a certain amount of time when trying to find
             an element or elements if they are not immediately available.
             The default setting is 0. Once set,
             the implicit wait is set for the life of the WebDriver object instance.

             !!! Better approach is to use explicit wait for every one single element !!!
             */
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        
        [TestCleanup]
        public void CleanupTest()
        {
            try
            {
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        
        [TestMethod]
        public void TheLogInSearchTest()
        {
            // Arrange
            homePage.Navigate();
            homePage.Login();

            // Act
            homePage.Filter();
            homePage.Search();

            // Assert
            Assert.IsTrue(homePage.IsResutFound(), "The result is not found");
        }
    }
}
