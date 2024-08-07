using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace UiTests
{
    public class CompanyPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "ul.navbar-nav li:nth-child(2) > a")]
        private IWebElement CompanyMenu { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='/company/']")]
        private IWebElement OverviewLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href='#contact']")]
        private IWebElement GetStartedButton { get; set; }

        public CompanyPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToOverview()
        {
            CompanyMenu.Click();
            OverviewLink.Click();
        }

        public List<string> GetPageValues()
        {
            var values = new List<string>();
            var elements = _driver.FindElements(By.CssSelector("div.content > p"));
            foreach (var element in elements)
            {
                values.Add(element.Text);
            }
            return values;
        }

        public void ClickGetStarted()
        {
            GetStartedButton.Click();
        }
    }

}
