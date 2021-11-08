using SBI.Automation.Common.Extension;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SBI.Automation.Common.Extension.Validation;

namespace SBI.Automation.Model.Pages
{
    public abstract class  PageBase
    {
        public IWebDriver Driver;

        public PageBase(IWebDriver driver, string url)
        {
            this.Driver = driver;
            this.Driver.Go(url);
        }

        public PageBase(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Verify that current page URL matches the expected URL.
        /// </summary>
        public void AssertVerifyPageUrl(string pageUrl, int timeout = 5)
        {
            Driver.AssertIsTrue(()=> 
                new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout)).Until<bool>((d) =>
                {
                    return d.Url.Contains(pageUrl);
                })
            );
        }

    }
}
