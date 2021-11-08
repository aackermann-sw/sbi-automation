
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SBI.Automation.Common.Extension
{
    /// <summary>
    /// fluent interface
    /// </summary>
    public static class WebDriverExtension
    {
        /// <summary>
        /// navigate to url
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static IWebDriver Go(this IWebDriver driver, string url) {
                driver.Navigate().GoToUrl(url);
                return driver;
        }

        public static IWebDriver Maximize(this IWebDriver driver) {
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static IWebDriver Click(this IWebDriver driver, By by) {
            if(Helper.Exist(driver, by))
            { 
                driver.FindElement(by).Click();
            }
            return driver;
        }

        public static IWebDriver Click(this IWebDriver driver, string id) {

            if (Helper.ExistById(driver, id))
            {
                driver.FindElement(By.Id(id)).Click();
            }
            return driver;
        }

        public static IWebDriver SendKeyName(this IWebDriver driver, string name,  string key) {
            IWebElement element = ByName(driver, name);
            element.SendKeys(key);
            return driver;
        }

        public static IWebDriver ClickAsync(this IWebDriver driver, string id)
        {
            WaitForElementToAppear(driver, By.Id(id));
            driver.FindElement(By.Id(id)).Click();
           
            return driver;
        }

        public static IWebDriver ClickAsync(this IWebDriver driver, By id)
        {
            WaitForElementToAppear(driver, id);
            driver.FindElement(id).Click();

            return driver;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="id"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IWebDriver SendKeyId(this IWebDriver driver, string id, string key)
        {
            IWebElement element = ById(driver, id);
            element.SendKeys(key);
            return driver;
        }
        public static IWebElement ById(this IWebDriver driver, string id)
        {
            WaitForElementToAppear(driver, By.Id(id));
            return driver.FindElement(By.Id(id));
        }

        public static IWebElement ByCss(this IWebDriver driver, string css)
        {
            var selector = By.CssSelector(css);
            WaitForElementToAppear(driver, selector);

            return driver.FindElement(selector);
        }

        public static IWebElement FindBy(this IWebDriver driver, By id)
        {
            return driver.FindElement(id);
        }

        public static bool Displayed(this IWebDriver driver, By id)
        {
            return Helper.Exist(driver, id);
        }

        public static IWebElement ByName(this IWebDriver driver, string name)
        {
            WaitForElementToAppear(driver, By.Name(name));
            return driver.FindElement(By.Name(name));
        }

        public static IWebElement ByXPath(this IWebDriver driver, string xpath)
        {
            WaitForElementToAppear(driver, By.XPath(xpath));
            return driver.FindElement(By.XPath(xpath));
        }

        public static IWebDriver SendKey(this IWebDriver driver, By by ,  string key) {
            IWebElement element = driver.FindElement(by);
            element.SendKeys(key);
            return driver;
        }
        public static IWebDriver SendKeyAsync(this IWebDriver driver, By by ,  string key) {
            WaitForElementToAppear(driver, by);
            IWebElement element = driver.FindElement(by);
            element.SendKeys(key);
            return driver;
        }

        public static IWebDriver SendTextByName(this IWebDriver driver, string name,  string text) {
            IWebElement element = ByName(driver, name);

            var chars = text.ToCharArray();
            foreach (char v in chars)
            {
                element.SendKeys(v.ToString());
            }

            return driver;
        }

        public static IWebDriver SendTextId(this IWebDriver driver, string id, string text)
        {
            IWebElement element = ById(driver, id);

            var chars = text.ToCharArray();
            foreach (char v in chars)
            {
                element.SendKeys(v.ToString());
            }

            return driver;
        }

        public static IWebDriver SendTextCssSelector(this IWebDriver driver, string cssSelector, string text)
        {
            IWebElement element = ByCss(driver, cssSelector);

            var chars = text.ToCharArray();
            foreach (char v in chars)
            {
                element.SendKeys(v.ToString());
            }

            return driver;
        }


        public static IWebDriver SetSelect(this IWebDriver driver, string selectId,  string text) {
            var by = By.XPath($@"//select[@id='{selectId}']//option[contains(text(),'{text}')]");

            WaitForElementToAppear(driver, by);

            return Click(driver, by);
        }

        public static IWebDriver SetSelect(this IWebDriver driver, string selectId, int index)
        {

            WaitForElementToAppear(driver, By.Id(selectId));
            //create a select object
            SelectElement selectElement = new SelectElement(ById(driver, selectId));

            //Select the option by index.
            selectElement.SelectByIndex(index);

            return driver;  //Click(driver, By.Id(selectId));
        }

        public static IWebDriver Submit(this IWebDriver driver, string id) {
            var buscar = driver.FindElement(By.Id(id));
            buscar.Submit();
            return driver;
        }
        public static IWebDriver Wait(this IWebDriver driver, int milliseconds) {
            Thread.Sleep(milliseconds);
            return driver;
        }

        public static IWebDriver WaitForElementNotPresent(this IWebDriver driver, string id)
        {

            return WaitForElementNotPresent(driver, By.Id(id));
        }

        public static IWebDriver WaitForElementNotPresent(this IWebDriver driver, By locator)
        {
            return driver.TimerLoop(() => !driver.FindElement(locator).Displayed, true, "Timeout: Element did not go away at: " + locator);
        }

        public static IWebDriver WaitForElementToAppear(this IWebDriver driver, By locator)
        {
            return driver.TimerLoop(() => driver.FindElement(locator).Displayed && driver.FindElement(locator).Enabled, false, "Timeout: Element not visible at: " + locator);
        }

        public static IWebDriver TimerLoop(this IWebDriver driver, Func<bool> isComplete, bool exceptionCompleteResult, string timeoutMsg)
        {
            const int timeoutinteger = 100;

            for (int second = 0; ; second++)
            {
                try
                {
                    if (isComplete())
                        return driver;
                    if (second >= timeoutinteger)
                        throw new TimeoutException(timeoutMsg);
                }
                catch (Exception ex)
                {
                    if (exceptionCompleteResult)
                        return driver;
                    if (second >= timeoutinteger)
                        throw new TimeoutException(timeoutMsg, ex);
                }
                Thread.Sleep(100);
            }
        }


        /// <summary>
        /// get cookie value
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public static IWebDriver GetCookie(this IWebDriver driver, string cookieName, ref string value)
        {
            var cookie = driver.Manage().Cookies.GetCookieNamed(cookieName);
            
            if (cookie != null)
                value = cookie.Value;

            return driver;
        }

        public static IWebDriver Hover(this IWebDriver driver, By element)
        {

            WaitForElementToAppear(driver, element);

            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindBy(element)).Perform();

            return driver;
        }

    }
}
