using OpenQA.Selenium;

namespace SeleniumTest.Framework.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; }

        protected BasePage (IWebDriver driver)
        {
            Driver = driver;
        }

    }
}
