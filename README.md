# SBI Automation
C#/.NET web UI test automation full featured framework based on Selenium WebDriver.
It uses fluent page object pattern.

[![Build Status]

Use C#

## Features

* **WebDriver**. Based on [Selenium WebDriver](https://github.com/SeleniumHQ/selenium) and preserves all its features.
* **Page Object Model**. Provides unique fluent page object pattern that is easy to implement and maintain.


### Test

Usage in the test method:

```C#
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
		.SetNroPuerta("150");

	// assert
	page
		.AssertVerifyPageUrl("LoginPage");
```

### Setup

```C#
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
```