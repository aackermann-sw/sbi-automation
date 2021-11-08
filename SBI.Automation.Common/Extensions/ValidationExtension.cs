using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SBI.Automation.Common.Extension.Validation
{

    public static class AssertExtension
    {


        public static IWebDriver AssertIsTrue(this IWebDriver driver, Func<bool> condition)
        {
            Assert.IsTrue(condition.Invoke());
            return driver;
        }

        
        public static IWebDriver AssertElementDisplayed(this IWebDriver driver, string id, bool result = false)
        {
            var elementId = By.Id(id);
            return driver.AssertIsTrue(() => { return driver.Displayed(elementId); });
        }

        public static IWebDriver  AssertScreenByUrl(this IWebDriver driver, string screenUrl)
        {
            string currentURL = driver.Url;
            return driver.AssertIsTrue(() => { return currentURL.Equals(screenUrl); });
        }

        public static IWebDriver AssertElementIsPresent(this IWebDriver driver, By element)
        {
            IWebElement findElement = driver.FindElement(element);
            return driver.AssertIsTrue(() => { return findElement.Displayed; });
        }

        public static IWebDriver AssertTextInElement(this IWebDriver driver, By element, string text)
        {
            string findElement = driver.FindElement(element).Text;
            return driver.AssertIsTrue(() => { return findElement.Equals(text); });
        }
    }
}
