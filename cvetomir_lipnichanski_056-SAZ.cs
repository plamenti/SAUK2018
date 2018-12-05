using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace SeleniumTests
{
    [TestClass]
    public class Mymall
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new FirefoxDriver();
            baseURL = "https://sports.mymall.bg/?utm_source=direct&utm_medium=redirectnew&utm_campaign=mymall.bg";
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
        public void TheMymallTest()
        {
            //NAVIGATE
            driver.Navigate().GoToUrl("https://sports.mymall.bg/?utm_source=direct&utm_medium=redirectnew&utm_campaign=mymall.bg");
            //SEARCHING BY FILTER
            driver.FindElement(By.Id("search_query")).Clear();
            driver.FindElement(By.Id("search_query")).SendKeys("яке мъжко");
            //SUBMIT SEARCH BUTTON
            driver.FindElement(By.Id("search_submit")).Click();
            //MARKING AN ITEM
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Сходни продукти'])[5]/following::a[1]")).Click();
            //ASSERT VISIBILITY OF AN ELEMENT
            Assert.IsTrue(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Spyder Wengen FZ Mid Weight Stryke мъжко яке'])[1]/following::h1[1]")).Displayed);
            //INTO THE BASKET
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Любими продукти'])[1]/following::span[1]")).Click();
            //VERIFY TEXT - FAIL
            try
            {
                Assert.AreEqual("Твоята количка - тест за верификация", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Огромноразнообразие'])[1]/following::div[5]")).Text);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
            //SEARCHING OTHER CATEGORY
            driver.FindElement(By.LinkText("Мъжки стоки")).Click();
            driver.FindElement(By.LinkText("Дънки")).Click();
            driver.Close();
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
