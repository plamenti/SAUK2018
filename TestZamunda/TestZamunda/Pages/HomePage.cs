using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;

namespace TestZamunda.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private const string MovieToSearch = "Желтый глаз тигра (5-6 серии из 16) 2018";

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

        public IWebElement PopupCloseButton
        {
            get
            {
                return driver.FindElement(By.Id("closefloatingbox"));
            }
        }

        public IWebElement SoftwareCategory
        {
            get
            {
                return driver.FindElement(By.Id("check_browsesoftware"));
            }
        }

        public IWebElement MusicCategory
        {
            get
            {
                return driver.FindElement(By.Id("check_browsemusic"));
            }
        }

        public IWebElement OthersCategory
        {
            get
            {
                return driver.FindElement(By.Id("check_browseothers"));
            }
        }

        public IWebElement GamesCategory
        {
            get
            {
                return driver.FindElement(By.Id("check_browsegames"));
            }
        }

        public IWebElement MoviesCategory
        {
            get
            {
                return driver.FindElement(By.Id("check_browsemovies"));
            }
        }

        public IWebElement SportCategory
        {
            get
            {
                return driver.FindElement(By.Id("check_browsesport"));
            }
        }

        public IWebElement RussianFilmsCategory
        {
            get
            {
                return driver.FindElement(By.XPath("//a[contains(@style, '!important;') and text() = 'Movies/Russia']/preceding-sibling::input[1]"));
            }
        }

        public IWebElement FoundResult
        {
            get
            {
                return driver.FindElement(By.XPath($"//a[text()='{MovieToSearch}']"));
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
        }

        public void Filter()
        {
            // This could break the test if the pop up si not present
            // Check presence 
            if (IsElementPresent(By.Id("closefloatingbox")))
            {
                PopupCloseButton.Click();
            }

            MoviesCategory.Click();
            GamesCategory.Click();
            OthersCategory.Click();
            MusicCategory.Click();
            SoftwareCategory.Click();
            SportCategory.Click();
            RussianFilmsCategory.Click();
        }

        public void Search()
        {
            driver.FindElement(By.Id("submitsearch")).Click();
            driver.FindElement(By.Id("search")).Click();
            driver.FindElement(By.Id("search")).Clear();
            driver.FindElement(By.Id("search")).SendKeys($"{MovieToSearch}");
            driver.FindElement(By.Id("submitsearch")).Click();
            
        }

        public string GetConfigProperty(string propertyKey)
        {
            return ConfigurationManager.AppSettings[propertyKey];
        }

        public bool IsResutFound()
        {
            return IsElementPresent(By.XPath($"//a[text()='{MovieToSearch}']"));
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                IWebElement foundElement = driver.FindElement(by);
                return foundElement.Displayed && foundElement.Enabled;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
