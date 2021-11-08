
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SBI.Automation.Common.Extension.Angular
{
    /// <summary>
    /// fluent interface
    /// </summary>
    public static class AngularExtension
    {
        public static IWebDriver Dowpdown(this IWebDriver driver, string selectId, int index)
        {
            driver.ClickAsync(By.XPath(selectId));

            string select = $"//li[{index}]";

            driver.ClickAsync(By.XPath(select));

            return driver;
        }

        public static IWebDriver Dowpdown(this IWebDriver driver, string selectId, string value)
        {
            driver.ClickAsync(By.XPath(selectId));

            string select = $"//li[contains(.,'{value}')]";

            driver.ClickAsync(By.XPath(select));

            return driver;
        }

    }
}
