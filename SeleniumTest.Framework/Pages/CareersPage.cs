using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTest.Framework.Pages
{
    public class CareersPage: BasePage
    {
        public CareersPage(IWebDriver driver): base(driver)
        {
        }

        public IJavaScriptExecutor Executor => (IJavaScriptExecutor)Driver;
        public Actions Actions => new Actions(Driver);

        #region UI Elements

        private IWebElement CountryDropdown => Driver.FindElement(By.Id("country"));
        private IWebElement VacancyFilter => Driver.FindElement(By.Id("vacancies-filter"));
        private IWebElement CountryElement => Driver.FindElement(By.Id("country-element"));
        private IWebElement LanguageDropdown => Driver.FindElement(By.Id("language"));
        private IWebElement EnglishOption => Driver.FindElement(By.Id("ch-7"));
        private IWebElement JobsFoundMessage => Driver.FindElement(By.XPath("//div[@class='col-xs-12 pl0-md-down pr0-md-down']/h3"));

        #endregion

        #region UI Usage

        private void ScrollVacancyFilterIntoView()
        {
            Executor.ExecuteScript("arguments[0].scrollIntoView();", VacancyFilter);
        }

        private void ExpandingCountryDropdown()
        {
            CountryElement.Click();
        }
        private void PressArrowUpKey()
        {
            Actions.SendKeys(Keys.ArrowUp).Build().Perform();
        }

        private void PressArrowDownKey()
        {
            Actions.SendKeys(Keys.ArrowDown).Build().Perform();
        }

        private void SelectCountryNameByArrowsPressing(string countryName)
        {
           
            var selectElement = new SelectElement(CountryDropdown);

            while (!selectElement.SelectedOption.GetAttribute("value").Equals(countryName))
            {
                PressArrowDownKey();
            }
        }

        private void ExpandOrCollapseLanguageDropdown()
        {
            LanguageDropdown.Click();
        }

        private void SelectLanguageOption()
        {
            Executor.ExecuteScript("arguments[0].click();", EnglishOption);
        }

        private string GetTextFromMessage()
        {
            var messageText = JobsFoundMessage.Text;
            return messageText;
        }

        private void WaitUntilJobsFoundMessagesGetRefreshed()
        {
            var oldMessage = GetTextFromMessage();
            var wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(300)).Until(Driver=> Driver.FindElement(By.XPath("//div[@class='col-xs-12 pl0-md-down pr0-md-down']/h3")).Text !=oldMessage);
        }

        #endregion

        #region Action

        public void SelectCountryByValue(string countryName)
        {
            ScrollVacancyFilterIntoView();
            ExpandingCountryDropdown();
            PressArrowUpKey();
            SelectCountryNameByArrowsPressing(countryName);
        }

        public void SelectLanguageByValue()
        {
            ExpandOrCollapseLanguageDropdown();
            SelectLanguageOption();
            ExpandOrCollapseLanguageDropdown();
        }

        public string GetVacancyNumber()
        {
            WaitUntilJobsFoundMessagesGetRefreshed();
            var message = GetTextFromMessage();
            string[] words = message.Split();
            char[] charsToTrim = {' '};
            var number = words[0].Trim(charsToTrim);
            return number;
        }
    }
        #endregion

 }
