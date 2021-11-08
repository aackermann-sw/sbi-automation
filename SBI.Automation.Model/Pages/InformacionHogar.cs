using SBI.Automation.Common.Extension;
using OpenQA.Selenium;
using SBI.Automation.Common.Extension.Validation;

namespace SBI.Automation.Model.Pages.Login
{
    public class InformacionHogar : PageBase
    {
        private const string submitQuote = "//button[contains(text(),'Cotizar!')]";

        public InformacionHogar(IWebDriver driver, string url) : base(driver, url){}



        public SeleccionPaquete SubmitQuote()
        {
            var element = By.XPath(submitQuote);
            Driver.ClickAsync(element);

            return new SeleccionPaquete(Driver);
        }

       

    }
}
