using NUnit.Framework;
using SeleniumTest.Framework.Data;
using SeleniumTest.Framework.Helpers;
using SeleniumTest.Framework.Pages;
using System.Collections.Generic;

namespace SeleniumTestProject.TestCases
{
    public class BaseTest
    {
 
        private static readonly ConfigData _configData = DataProcessingHelper.GetConfigData();
        private static readonly BrowserFactory _browser = new BrowserFactory(_configData);

        protected void StartBrowser()
        {
            _browser.Start();
        }

        protected void OpenApplication()
        {
            _browser.GoToUrl();
        }

        protected void CloseApplication()
        {
            _browser.ExitDriver();
        }

        protected TPage CreatePageInstance<TPage>() where TPage : BasePage
        {
            return _browser.GetPage<TPage>();
        }

        protected static IList<TestCaseData> GetInputData()
        {
            var datas = DataProcessingHelper.GetTestData();
            var testCaseDatas = new List<TestCaseData>();
            foreach (var data in datas)
            {
                testCaseDatas.Add(new TestCaseData(data).SetName(data.Country + "Vacances_{m}"));
            }
            return testCaseDatas;
        }
    }
}
