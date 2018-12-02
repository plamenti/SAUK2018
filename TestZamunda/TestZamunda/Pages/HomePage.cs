using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestZamunda.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
        }

        public IWebElement Username
        {
            get
            {
                return driver.FindElement(By.Name("username"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return driver.FindElement(By.Name("login"));
            }
            
        }

        public IWebElement Password
        {
            get
            {
                return driver.FindElement(By.Name("password"));
            }
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(GetConfigProperty("url"));
        }

        public void Login()
        {
            Username.Clear();
            Username.SendKeys(GetConfigProperty("username"));

            Password.Clear();
            Password.SendKeys(GetConfigProperty("password"));

            LoginButton.Submit();

            Thread.Sleep(1000);
        }

        public void Filter()
        {
            driver.FindElement(By.Id("check_browsemovies")).Click();
            driver.FindElement(By.Id("check_browsegames")).Click();
            driver.FindElement(By.Id("check_browseothers")).Click();
            driver.FindElement(By.Id("check_browsesport")).Click();
            driver.FindElement(By.Id("check_browsemusic")).Click();
            driver.FindElement(By.Id("check_browsesoftware")).Click();
            driver.FindElement(By.Name("c28")).Click();
        }

        public void Search()
        {
            driver.FindElement(By.Id("submitsearch")).Click();
            driver.FindElement(By.Id("search")).Click();
            driver.FindElement(By.Id("search")).Clear();
            driver.FindElement(By.Id("search")).SendKeys("Желтый глаз тигра (5-6 серии из 16) 2018");
            driver.FindElement(By.Id("submitsearch")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='favorites'])[2]/following::a[1]")).Click();
        }

        public string GetConfigProperty(string propertyKey)
        {
            return ConfigurationManager.AppSettings[propertyKey];
        }
    }
}
