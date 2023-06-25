using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Partner.Services {
    internal class Utils {
        public IWebDriver driver;

        public void Scraping(string BaseUrl) {
            try {
                ChromeOptions option = new();
              //  option.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                option.AddArgument("--healess");
                driver = new ChromeDriver(option);
              
                
                driver.Navigate().GoToUrl(BaseUrl);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                Console.WriteLine("Portal da prefeitura acessado");
            } catch (Exception error) {
                Console.WriteLine($"Erro duante o acesso ao portal da prefeitura de Guarujá. -> {error.Message}");
            }
        }
    }
}

