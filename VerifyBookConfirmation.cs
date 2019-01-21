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
    public class TestCase1
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
        public void TheCase1Test()
        {
            driver.Navigate().GoToUrl("https://katalon-demo-cura.herokuapp.com/");
            driver.FindElement(By.Id("btn-make-appointment")).Click();
            driver.FindElement(By.Id("txt-username")).Click();
            driver.FindElement(By.Id("txt-username")).Clear();
            driver.FindElement(By.Id("txt-username")).SendKeys("John Doe");
            driver.FindElement(By.Id("txt-password")).Clear();
            driver.FindElement(By.Id("txt-password")).SendKeys("ThisIsNotAPassword");
            driver.FindElement(By.Id("txt-password")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Facility'])[1]/following::div[1]")).Click();
            driver.FindElement(By.Id("combo_facility")).Click();
            new SelectElement(driver.FindElement(By.Id("combo_facility"))).SelectByText("Hongkong CURA Healthcare Center");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Facility'])[1]/following::option[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Facility'])[1]/following::label[1]")).Click();
            driver.FindElement(By.Id("radio_program_medicaid")).Click();
            driver.FindElement(By.Id("txt_visit_date")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Sa'])[1]/following::td[32]")).Click();
            driver.FindElement(By.Id("txt_comment")).Click();
            driver.FindElement(By.Id("txt_comment")).Clear();
            driver.FindElement(By.Id("txt_comment")).SendKeys("Test");
            driver.FindElement(By.Id("btn-book-appointment")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Make Appointment'])[1]/following::h2[1]")).Click();
            try
            {
                Assert.AreEqual("Appointment Confirmation", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Make Appointment'])[1]/following::h2[1]")).Text);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
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
