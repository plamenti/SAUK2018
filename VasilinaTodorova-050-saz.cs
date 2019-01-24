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
    public class Test
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
        public void TheTest()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Search'])[1]/following::span[1]")).Click();
            driver.FindElement(By.Id("ap_email")).Clear();
            driver.FindElement(By.Id("ap_email")).SendKeys("test666@abv.bg");
            driver.FindElement(By.Id("ap_password")).Click();
            driver.FindElement(By.Id("ap_password")).Clear();
            driver.FindElement(By.Id("ap_password")).SendKeys("testtest66");
            driver.FindElement(By.Id("signInSubmit")).Click();
            try
            {
                Assert.AreEqual("There was a problem", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your password is incorrect'])[1]/preceding::h4[1]")).Text);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("ap_password")).Click();
            driver.FindElement(By.Id("ap_password")).Clear();
            driver.FindElement(By.Id("ap_password")).SendKeys("testtest666");
            driver.FindElement(By.Id("signInSubmit")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your Account'])[1]/following::span[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Disability Customer Support'])[1]/following::div[9]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Switch Accounts'])[1]/following::span[1]")).Click();
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
