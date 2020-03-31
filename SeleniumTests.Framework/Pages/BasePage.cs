using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Framework.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver _driver { get; set; }

        protected BasePage (IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
