using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace QA.Automation.Inc.Selenium.Classes
{
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Finds the Element By a provided means with a provided time out period.
        /// </summary>
        /// <param name="driver">Webdriver to use.</param>
        /// <param name="by">Find By option.</param>
        /// <param name="timeoutInSeconds">Number of seconds to wait before throwing exception.</param>
        /// <returns>IWebElement found given search condition.</returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static bool TryFind(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(drv => drv.FindElement(by));
                    return true;
                }
                driver.FindElement(by);
                return true;
            }
            catch (Exception) // if this throws an exception the control was not found by the provided mechanism so it return false
            {
                return false;
            }
        }
    }
}
