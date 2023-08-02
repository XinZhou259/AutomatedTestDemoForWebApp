using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using PhotoFolio.Configration;


namespace PhotoFolio.Tests
{
    internal class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = CreateDriver(ConfigurationProvider.ConfigurationManager["browser"]);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("your file location/PhotoFolio/index.html");
        }

        [TearDown]
        public void TearDown() 
        {
            driver.Quit();  
        
        }

        private IWebDriver CreateDriver(string browserName)
        {
            switch (browserName.ToLowerInvariant())
            {
                case "chrome":
                    return new ChromeDriver();

                case "firefox":
                    return new FirefoxDriver();

                case "edge":
                    return new EdgeDriver();

                default:
                    throw new Exception("Provided browser is not supported.");

            }
        }

        
    }
}
