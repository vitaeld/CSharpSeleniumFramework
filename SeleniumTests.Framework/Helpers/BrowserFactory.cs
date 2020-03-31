using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Framework.Helpers
{
    public class BrowserFactory
    {
        private IWebDriver _driver { get; set; }
        private string _appUrl { get; set; }

        public BrowserFactory()
        {
            _appUrl = "https://careers.veeam.com/";
        }

        public void Start()
        {
            _driver = new ChromeDriver();
        }

        public void GoToUrl()
        {
            _driver.Navigate().GoToUrl(_appUrl);
        }
    }
}
