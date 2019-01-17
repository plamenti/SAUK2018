using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class TestBrutoAndCar
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheBrutoAndCarTest()
        {
            driver.Navigate().GoToUrl("https://www.calculator.bg/");
            driver.FindElement(By.LinkText("Калкулатор заплата бруто/нето")).Click();
            driver.FindElement(By.Id("bruto")).Click();
            driver.FindElement(By.Id("bruto")).Clear();
            driver.FindElement(By.Id("bruto")).SendKeys("1800");
            driver.FindElement(By.Id("nabor_type")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='дата на раждане:'])[1]/following::input[1]")).Click();
            driver.FindElement(By.Id("det")).Click();
            driver.FindElement(By.LinkText("Осигурителен калкулатор")).Click();
            driver.FindElement(By.Id("suma")).Click();
            driver.FindElement(By.Id("suma")).Clear();
            driver.FindElement(By.Id("suma")).SendKeys("2800");
            driver.FindElement(By.Id("category")).Click();
            new SelectElement(driver.FindElement(By.Id("category"))).SelectByText("втора категория труд");
            driver.FindElement(By.Id("category")).Click();
            driver.FindElement(By.Id("deinost")).Click();
            new SelectElement(driver.FindElement(By.Id("deinost"))).SelectByText("Добив на варовик, суров гипс,");
            driver.FindElement(By.Id("deinost")).Click();
            driver.FindElement(By.Id("kval")).Click();
            new SelectElement(driver.FindElement(By.Id("kval"))).SelectByText("Специалисти");
            driver.FindElement(By.Id("kval")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Ставка за фонд трудова злополука и професионална болест'])[1]/following::input[1]")).Click();
            driver.FindElement(By.Id("det")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Calculator.bg'])[1]/following::img[1]")).Click();
            driver.FindElement(By.Name("two")).Click();
            driver.FindElement(By.Name("eight")).Click();
            driver.FindElement(By.Name("zero")).Click();
            driver.FindElement(By.Name("zero")).Click();
            driver.FindElement(By.Name("minus")).Click();
            driver.FindElement(By.Name("three")).Click();
            driver.FindElement(By.Name("eight")).Click();
            driver.FindElement(By.Name("five")).Click();
            driver.FindElement(By.Name("calc")).Click();
            driver.Navigate().GoToUrl("https://www.calculator.bg/index.php");
            driver.FindElement(By.LinkText("За автомобила")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Данъчен калкулатор за автомобили'])[3]/following::a[1]")).Click();
            driver.FindElement(By.Id("fuel")).Click();
            driver.FindElement(By.Id("fuel")).Clear();
            driver.FindElement(By.Id("fuel")).SendKeys("7.8");
            driver.FindElement(By.Id("price")).Click();
            driver.FindElement(By.Id("price")).Click();
            driver.FindElement(By.Id("price")).Clear();
            driver.FindElement(By.Id("price")).SendKeys("2.25");
            driver.FindElement(By.Id("city1")).Click();
            driver.FindElement(By.Id("city1")).Clear();
            driver.FindElement(By.Id("city1")).SendKeys("София");
            driver.FindElement(By.Id("city2")).Click();
            driver.FindElement(By.Id("city2")).Clear();
            driver.FindElement(By.Id("city2")).SendKeys("Пловдив");
            driver.FindElement(By.Id("bb")).Click();
            driver.FindElement(By.Id("det")).Click();
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
