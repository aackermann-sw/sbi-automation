using SBI.Automation.Common.Extension;
using OpenQA.Selenium;
using SBI.Automation.Common.Extension.Validation;

namespace SBI.Automation.Model.Pages.Login
{
    public class SeleccionPaquete : PageBase
    {
        private const string submitTakeIt = "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-package-selection[1]/div[1]/div[#home]/div[1]/div[1]/button[1]";
        public SeleccionPaquete(IWebDriver driver, string url) : base(driver, url){}
        public SeleccionPaquete(IWebDriver driver) : base(driver) { }



        public InformacionAdicional SubmitTakeIt(int home)
        {
            var element = By.XPath(submitTakeIt.Replace("#home", home.ToString()));
            Driver.ClickAsync(element);

            return new InformacionAdicional(base.Driver);
        }

       

    }
}
