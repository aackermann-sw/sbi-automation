using SBI.Automation.Common.Extension;
using SBI.Automation.Common.Extension.Angular;
using OpenQA.Selenium;
using SBI.Automation.Common.Extension.Validation;

namespace SBI.Automation.Model.Pages.Login
{
    public class InformacionAdicional : PageBase
    {
        private const string submitNext = "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-additional-information[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[2]/div[1]/input[1]";

        private DatosPersonales<InformacionAdicional> _DatosPersonales;
        public DatosPersonales<InformacionAdicional> DatosPersonales { 
            get {
                if (_DatosPersonales == null)
                    _DatosPersonales = new DatosPersonales<InformacionAdicional>(Driver, this);
                    return _DatosPersonales;
                } 
        }

        #region Constructor 
        public InformacionAdicional(IWebDriver driver, string url) : base(driver, url) { }
        public InformacionAdicional(IWebDriver driver) : base(driver) { }

        #endregion



        public InformacionAdicional SubmitQuote()
        {
            Driver.ClickAsync(By.XPath(submitNext));

            return this;
        }


    }


    public class DatosPersonales<T> {

        private const string setNombre = "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-additional-information[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[2]/div[1]/input[1]";
        private const string setApellido = "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-additional-information[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[3]/div[1]/input[1]";
        private const string setRut = "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-additional-information[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[5]/div[1]/input[1]";
        private const string setMail = "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-additional-information[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[6]/div[1]/input[1]";
        private const string setCelular = "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-additional-information[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[7]/div[1]/input[1]";
        private const string setCodigoPostal = "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-additional-information[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[9]/div[1]/input[1]";
        private const string setCalle = "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-additional-information[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[11]/div[1]/input[1]";
        private const string setNroPuerta = "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-additional-information[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[12]/div[1]/input[1]";
        private const string setApartamento = "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-additional-information[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[13]/div[1]/input[1]";
        private const string setTipoDocumento = "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-additional-information[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[4]/div[1]/app-custom-dropdown[1]/div[1]";
        private const string setDepartamento =  "//body/app-root[1]/div[1]/div[2]/div[1]/app-step-additional-information[1]/div[1]/form[1]/div[1]/div[2]/div[1]/div[10]/div[1]/app-custom-dropdown[1]/div[1]/div[1]";

        private IWebDriver Driver;
        public T Owner;
        public DatosPersonales(IWebDriver driver, T owner)
        {
            Driver = driver;
            Owner = owner;
        }
        public DatosPersonales<T> SetTipoDocumento(string value)
        {
            Driver.Dowpdown(setTipoDocumento, value);

            return this;
        }
        public DatosPersonales<T> SetDepartamento(string value)
        {
            Driver.Dowpdown(setDepartamento, value);

            return this;
        }
        public DatosPersonales<T> SetNombre(string value)
        {
            Driver.SendKeyAsync(By.XPath(setNombre), value);

            return this;
        }

        public DatosPersonales<T> SetApellido(string value)
        {
            Driver.SendKeyAsync(By.XPath(setApellido), value);

            return this;
        }
        public DatosPersonales<T> SetRut(string value)
        {
            Driver.SendKeyAsync(By.XPath(setRut), value);

            return this;
        }
        public DatosPersonales<T> SetMail(string value)
        {
            Driver.SendKeyAsync(By.XPath(setMail), value);

            return this;
        }
        public DatosPersonales<T> SetCelular(string value)
        {
            Driver.SendKeyAsync(By.XPath(setCelular), value);

            return this;
        }

        public DatosPersonales<T> SetCodigoPostal(string value)
        {
            Driver.SendKeyAsync(By.XPath(setCodigoPostal), value);

            return this;
        }
        public DatosPersonales<T> SetCalle(string value)
        {
            Driver.SendKeyAsync(By.XPath(setCalle), value);

            return this;
        }
        public DatosPersonales<T> SetNroPuerta(string value)
        {
            Driver.SendKeyAsync(By.XPath(setNroPuerta), value);

            return this;
        }
        public DatosPersonales<T> SetApartamento(string value)
        {
            Driver.SendKeyAsync(By.XPath(setApartamento), value);

            return this;
        }

    }

}
