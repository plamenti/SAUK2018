using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;


namespace AmazonProductOrder
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

        public IWebElement SearchField
        {
            get
            {
                return driver.FindElement(By.Id("twotabsearchtextbox"));
            }            
        }

        public IWebElement SearchForm
        {
            get
            {
                return driver.FindElement(By.Name("site-search"));
            }
        }

        public string GetProductForSearch
        {
            get
            {
                return ConfigurationManager.AppSettings["search_words"];
            }
        }

        public string GetProduct
        {
            get
            {
                return ConfigurationManager.AppSettings["product"];
            }
        }

        public IWebElement Username
        {
            get
            {
                return driver.FindElement(By.Id("ap_email"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return driver.FindElement(By.Id("ap_password"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return driver.FindElement(By.Id("signInSubmit"));
            }

        }


        public IWebElement CheckoutButton
        {
            get
            {
                return driver.FindElement(By.Id("hlb-ptc-btn-native"));
            }
        }

        public IWebElement GetName
        {
            get
            {
                return driver.FindElement(By.Id("enterAddressFullName"));
            }

        }




        public void Navigate()
        {
            driver.Navigate().GoToUrl(GetConfigProperty("url"));
        }

        public void GoToLoginPage()
        {
            IWebElement button = driver.FindElement(By.XPath("//a[@id='a-autoid-0-announce']"));
            button.Click();
        }

        public void Login()
        {

            Username.Clear();
            Username.SendKeys(GetConfigProperty("username"));

            Password.Clear();
            Password.SendKeys(GetConfigProperty("password"));

            LoginButton.Submit();
        }

        public void Search()
        {
            SearchField.Clear();
            SearchField.SendKeys(GetProductForSearch);
            SearchForm.Submit();
        }

        public void GoToDetails()
        {
            IWebElement rootElement = driver.FindElement(By.XPath($"//a[contains(., '{GetProduct}')]"));
            rootElement.Click();
        }

        public void AddToCard()
        {
            IWebElement rootElement = driver.FindElement(By.XPath("//input[@id='add-to-cart-button']"));
            rootElement.Click();
        }

        public void Checkout()
        {
            string popUpId = "siNoCoverage-announce";
           
            IWebElement rootElement = CheckoutButton;
            rootElement.Click();
            Thread.Sleep(1000);

            if (IsPopup(popUpId))
            {
                ClosePopup(By.Id(popUpId));
            }
        }


        public string GetConfigProperty(string propertyKey)
        {
            return ConfigurationManager.AppSettings[propertyKey];
        }

        public bool IsResutFound()
        {
            return IsElementPresent(By.XPath($"//a[contains(., '{GetProduct}')]"));
        }

        public bool IsName()
        {

            
            if (GetName.GetAttribute("type") == ConfigurationManager.AppSettings["attribute"])
            {
                return true;
            }

            return false;
        }

        public bool IsPopup(string id)
        {
            return IsElementPresent(By.Id(id));
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

        public void ClosePopup(By by)
        {
            IWebElement foundElement = driver.FindElement(by);
            foundElement.Click();
        }
    }
}