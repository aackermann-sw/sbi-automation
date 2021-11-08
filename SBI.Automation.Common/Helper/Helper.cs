using OpenQA.Selenium;
using SBI.Automation.Common.Extension;

namespace SBI.Automation.Common
{
    public static class Helper
    {

        /// <summary>
        /// Método que verifica la existencia y la visibilidad del elemento en cuestion
        /// </summary>
        /// <param name="driver">El driver con el que se está interactuando</param>
        /// <param name="element">Nombre del Id a evaluar</param>
        /// <returns>boolean</returns>
        public static bool ExistById(IWebDriver driver, string element)
        {
            try
            {
                return driver.ById(element).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        /// <summary>
        /// Método que verifica la existencia y la visibilidad del elemento en cuestion
        /// </summary>
        /// <param name="driver">El driver con el que se está interactuando</param>
        /// <param name="element">Nombre del Name a evaluar</param>
        /// <returns>boolean</returns>
        public static bool ExistByName(IWebDriver driver, string element)
        {
            try
            {
                return driver.ByName(element).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Método que verifica la existencia y la visibilidad del elemento en cuestion
        /// </summary>
        /// <param name="driver">El driver con el que se está interactuando</param>
        /// <param name="element">Nombre del By a evaluar</param>
        /// <returns>boolean</returns>
        public static bool Exist(IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
