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
    public class UntitledTestCase4
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
        public void TheUntitledTestCase4Test()
        {
            driver.Navigate().GoToUrl("http://shopping.bg/");
            driver.FindElement(By.Id("search")).Click();
            driver.FindElement(By.Id("search")).Clear();
            driver.FindElement(By.Id("search")).SendKeys("clod b");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='продукта'])[1]/following::input[3]")).Click();
            driver.FindElement(By.Id("search")).Click();
            driver.FindElement(By.Id("search")).Clear();
            driver.FindElement(By.Id("search")).SendKeys("cloud b");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='продукта'])[1]/following::input[3]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cloud-B ДЕКОРАТИВНА НОЩНА ЛАМПА ОКТОПОД - Dreamz To Go Octo™ - 7452'])[2]/following::img[1]")).Click();
            driver.FindElement(By.Id("bigbuybtn")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Цена'])[1]/following::a[2]")).Click();
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
