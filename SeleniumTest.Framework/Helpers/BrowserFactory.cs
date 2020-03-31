using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.Framework.Data;
using SeleniumTest.Framework.Pages;
using System;

namespace SeleniumTest.Framework.Helpers
{
    public class BrowserFactory
    {
        private IWebDriver Driver { get; set; }
        private string AppUrl { get; set; }

        public BrowserFactory(ConfigData configData)
        {
            AppUrl = configData.AppUrl;
        }

        public void Start()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(options);
        }

        public void GoToUrl()
        {
            Driver.Navigate().GoToUrl(AppUrl);
        }

        public void ExitDriver()
        {
            Driver?.Quit();
        }

        public T GetPage<T>() where T : BasePage
        {
            return (T)Activator.CreateInstance(typeof(T), Driver);
        }
    }
}
