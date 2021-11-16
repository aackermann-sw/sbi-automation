using NUnit.Framework;
using SBI.Automation.Model.Pages.Login;

namespace Automation
{
    [TestFixture]
    public class InformacionAdicionalTest: TestBase
    {
        [Test]
        public void Validate_Aditional_Information_Fill()
        {
            // arrange
            var page = new InformacionHogar(driver, "https://front-hogar.sbi-cotizador.test.switch.local/informacion-hogar");

            // act
            page
                .SubmitQuote()
                .SubmitTakeIt(2)
                .DatosPersonales
                .SetTipoDocumento("RUT")
                .SetDepartamento("Salto")
                .SetNombre("nombre")
                .SetApellido("apellido")
                .SetApartamento("apartamente 15")
                .SetCalle("calle 1")
                .SetCelular("091770204")
                .SetMail("agus@hotmail.com")
                .SetCodigoPostal("097812")
                .SetRut("12454654")
                .SetNroPuerta("150")
                .SetFechaNacimiento("11/27/1982");

            // assert
            page
                .AssertVerifyPageUrl("informacion-adicional");
        }


    }
}
