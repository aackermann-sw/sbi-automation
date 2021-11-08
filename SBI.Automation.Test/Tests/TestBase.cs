using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using SBI.Automation.Model.Pages.Login;

namespace Automation
{
    [TestFixture]
    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void Init()
        {
            var options = new ChromeOptions();
#if Debug
            options.AddArgument("--headless");
#endif
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver( Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BrowserDriver"), options, TimeSpan.FromMinutes(4));


        }
        [TearDown]
        public void Endtest()
        {
            driver.Quit();
        }



    }
}
