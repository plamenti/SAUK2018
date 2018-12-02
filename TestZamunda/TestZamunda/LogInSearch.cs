using System;
using System.Text;
using System.Threading;
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
        private StringBuilder verificationErrors;
        private HomePage homePage;

        
        [TestInitialize]
        public void InitializeTest()
        {
            //driver = new FirefoxDriver();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            verificationErrors = new StringBuilder();
            homePage = new HomePage(driver);
        }
        
        [TestCleanup]
        public void CleanupTest()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

            Assert.AreEqual("", verificationErrors.ToString());
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
