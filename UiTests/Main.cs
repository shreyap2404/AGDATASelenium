using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UiTests
{
    public class Main
    {

        protected IWebDriver Driver;

        public Main(IWebDriver driver)
        {
            Driver = driver;
        }

        // Common methods, e.g., for waiting
        protected void WaitForElement(By locator, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
    }


}