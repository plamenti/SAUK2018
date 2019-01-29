using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class UntitledTestCase
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
        }
        
        [ClassCleanup]
        public static void CleanupClass()
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
        }
        
        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }
        
        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [TestMethod]
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("https://www.mobile.bg/pcgi/mobile.cgi");
            driver.FindElement(By.Name("marka")).Click();
            new SelectElement(driver.FindElement(By.Name("marka"))).SelectByText("BMW");
            driver.FindElement(By.Name("marka")).Click();
            driver.FindElement(By.Name("model")).Click();
            new SelectElement(driver.FindElement(By.Name("model"))).SelectByText("3");
            driver.FindElement(By.Name("model")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Новини от ФАКТИ.bg'])[1]/preceding::strong[1]")).Click();
            driver.FindElement(By.Name("f12")).Click();
            new SelectElement(driver.FindElement(By.Name("f12"))).SelectByText("Бензинов");
            driver.FindElement(By.Name("f12")).Click();
            driver.FindElement(By.Name("f10")).Click();
            new SelectElement(driver.FindElement(By.Name("f10"))).SelectByText("от 2007 г.");
            driver.FindElement(By.Name("f10")).Click();
            driver.FindElement(By.Name("f14")).Click();
            new SelectElement(driver.FindElement(By.Name("f14"))).SelectByText("Комби");
            driver.FindElement(By.Name("f14")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Състояние:'])[1]/following::input[1]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
