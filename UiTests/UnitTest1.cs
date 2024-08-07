using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace UiTests
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.agdata.com");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}