using NUnit.Framework;
using SeleniumTestProject.TestCases;
using SeleniumTest.Framework.Pages;
using SeleniumTest.Framework.Data;

namespace SeleniumTestProject
{
    public class Tests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            StartBrowser();
            OpenApplication();

        }

        [TearDown]
        public void TearDown()
        {
            CloseApplication();
        }
        [Test]
        [TestCaseSource(nameof(GetInputData))]
        public void SearchByCountryAndLanguage(InputData testData)
        {
            var careersPage = CreatePageInstance<CareersPage>();         
            careersPage.SelectCountryByValue(testData.Country);
            careersPage.SelectLanguageByValue();
            var vacancyNumber = careersPage.GetVacancyNumber();

            Assert.AreEqual(int.Parse(testData.VacancyResult), int.Parse(vacancyNumber));
        }
    }
}