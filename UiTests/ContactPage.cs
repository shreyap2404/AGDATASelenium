using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace UiTests
{
    public class ContactPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "h1")]
        private IWebElement PageHeader { get; set; }

        public ContactPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public bool IsContactPageDisplayed()
        {
            return PageHeader.Text.Contains("Contact");
        }
    }
}
