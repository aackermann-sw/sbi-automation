using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SBI.Automation.Common.Extension.Aspx
{
    /// <summary>
    /// fluent interface
    /// </summary>
    public static class AspxExtension
    {

        public static IWebDriver SendValueId(this IWebDriver driver, string id, string value)
        {
            IWebElement element = driver.ById(id);
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"document.getElementById('{id}').value='{value}';");

            return driver;
        }
        public static IWebDriver WaitAsync(this IWebDriver driver)
        {
            driver.WaitForElementNotPresent(By.XPath("//div[@class='blockUI blockMsg blockPage']"));
            return driver;
        }
        public static IWebDriver SetMultiSelect(this IWebDriver driver, string selectId, int index)
        {

            driver.WaitForElementToAppear(By.Id(selectId));
            //create a select object
            SelectElement selectElement = new SelectElement(driver.ById(selectId));

            //Select the option by index.
            selectElement.SelectByIndex(index);

            return  driver;
        }
    }
}
