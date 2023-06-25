using OpenQA.Selenium;
using Partner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Partner.CityHalls {
    public class Guaruja {
        public static async Task Scraping(List<int> idContracts) {

            try {

                for (int i = 0; i < idContracts.Count; i++) {

                    foreach (int idContract in idContracts) {

                        var credential = new GetCredentials().PortalCityHall();
                        var download = new DownloadFiles();
                        var upload = new UploadFiles();
                        var gmail = new Email();
                        var contract = new InfoContracts().Contracts(idContract);

                        var idClient = contract[0].Clients;
                        var customer = new InfoCustomer().GetCustomer((int)idClient);
                        var utils = new Utils();


                        utils.Scraping(credential[0].BaseUrl);

                        // Clicar em: Acesso Exclusivo Prestador e next
                        // TODO: Verificar como trabalhar com Xpath
                        utils.driver.FindElement(By.XPath("//*[@id='principal']/table/tbody/tr[2]/td/table/tbody/tr/td/table/tbody/tr/td[1]/table/tbody/tr[1]/td/table/tbody/tr/td[1]/table/tbody/tr[1]/td/table/tbody/tr/td[1]")).Click();

                        //Informando credenciais e next CNPJ
                        utils.driver.FindElement(By.Id("ext-gen29")).SendKeys(credential[0].Uin);
                        utils.driver.FindElement(By.Id("ext-gen33")).SendKeys(credential[0].Password);
                        utils.driver.FindElement(By.Id("ext-gen35")).Click();

                        // Acessando página de emissão
                        utils.driver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[2]/td/table/tbody/tr[2]/td/table/tbody/tr/td[1]/table/tbody/tr/td/table/tbody/tr[2]/td/div/div/div/div[1]/div[2]/div/div[1]")).Click();

                        // Inserindo dados do cliente
                        utils.driver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[2]/td/table/tbody/tr[2]/td/table/tbody/tr/td[2]/table/tbody/tr/td/table/tbody/tr/td/div/div[2]/div/div/div/div/table[1]/tbody/tr/td/div/div/div/form/fieldset/div/div/fieldset[1]/div/div/table/tbody/tr[2]/td/div/div/div/div/div[1]/div/div/div/div[1]/input")).SendKeys(customer[i].Uin);

                        // Clicando em: Enviar
                        utils.driver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[2]/td/table/tbody/tr[2]/td/table/tbody/tr/td[2]/table/tbody/tr/td/table/tbody/tr/td/div/div[2]/div/div/div/div/table[1]/tbody/tr/td/div/div/div/form/fieldset/div/div/fieldset[1]/div/div/table/tbody/tr[2]/td/div/div/div/div/div[2]/div/div/table/tbody/tr/td/table/tbody/tr/td[2]")).Click();

                        // Clicando em: Próximo Passo
                        utils.driver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[2]/td/table/tbody/tr[2]/td/table/tbody/tr/td[2]/table/tbody/tr/td/table/tbody/tr/td/div/div[2]/div/div/div/div/table[2]/tbody/tr/td/table/tbody/tr/td[2]")).Click();

                        // Clicando em: Código do Serviço/Atividade
                        utils.driver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[2]/td/table/tbody/tr[2]/td/table/tbody/tr/td[2]/table/tbody/tr/td/table/tbody/tr/td/div/div[2]/div/div[2]/div/div/div/div/div/form/fieldset[3]/div/div/div[1]/div/div/div/div[1]/div/div/div/div[1]/div[1]/input")).Click();

                        // Selecionando o código de atividade
                        utils.driver.FindElement(By.XPath("/html/body/div[10]/div/div[2]")).Click();

                        // Clicando em: Descrição ou código do Serviço
                        utils.driver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[2]/td/table/tbody/tr[2]/td/table/tbody/tr/td[2]/table/tbody/tr/td/table/tbody/tr/td/div/div[2]/div/div[2]/div/div/div/div/div/form/fieldset[3]/div/div/div[2]/div/div/div/div[1]/div/div/div/div[1]/textarea")).Click();

                        // Inserindo texto em Descrição ou código do serviço
                        utils.driver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[2]/td/table/tbody/tr[2]/td/table/tbody/tr/td[2]/table/tbody/tr/td/table/tbody/tr/td/div/div[2]/div/div[2]/div/div/div/div/div/form/fieldset[3]/div/div/div[2]/div/div/div/div[1]/div/div/div/div[1]/textarea")).SendKeys($"{contract[0].ServiceDescription}");

                        // Inseriondo o valor do serviço
                        utils.driver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[2]/td/table/tbody/tr[2]/td/table/tbody/tr/td[2]/table/tbody/tr/td/table/tbody/tr/td/div/div[2]/div/div[2]/div/div/div/div/div/form/fieldset[5]/div/div/div[1]/div/div/div/div[1]/div/div/div/div[1]/input")).SendKeys(contract[i].MonthlyFees);

                        // Clicando em: Próximo Passo
                        utils.driver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[2]/td/table/tbody/tr[2]/td/table/tbody/tr/td[2]/table/tbody/tr/td/table/tbody/tr/td/div/div[2]/div/div[2]/div/div/div/div/div/form/table/tbody/tr/td[2]/table/tbody/tr/td/table/tbody/tr/td[2]/em/button")).Click();

                        // Clicando em: Emitir Nfse
                        utils.driver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[2]/td/table/tbody/tr[2]/td/table/tbody/tr/td[2]/table/tbody/tr/td/table/tbody/tr/td/div/div[2]/div/div[3]/div/div/div/div/div/form/table[2]/tbody/tr/td[2]/table/tbody/tr/td/table/tbody/tr/td[2]/em/button")).Click();

                        // Clicando em: Ok - Pós a emissão da nota
                        utils.driver.FindElement(By.XPath("/html/body/div[10]/div[2]/div[2]/div/div/div/div/div/table/tbody/tr/td[1]/table/tbody/tr/td[2]")).Click();

                        // Clicando em: Visualizar Nota Fiscal
                        utils.driver.FindElement(By.XPath("/html/body/div[10]/div[2]/div[2]/div/div/div/div/div/table/tbody/tr/td[1]/table/tbody/tr/td[2]")).Click();

                        //Verificando a quantidade de abas abertas no navegador
                        var handles = utils.driver.WindowHandles;

                        while (handles.Count < 2) {
                            Thread.Sleep(100);
                        }

                        utils.driver.SwitchTo().Window(handles[1]);

                        handles = utils.driver.WindowHandles;

                        // Clicando em: Exportar PDF
                        utils.driver.FindElement(By.XPath("/html/body/table/tbody/tr[1]/td/form/table/tbody/tr/td[3]/table/tbody/tr/td[2]/a")).Click();

                        handles = utils.driver.WindowHandles;

                        while (handles.Count < 3) {
                            Thread.Sleep(100);
                        }

                        utils.driver.SwitchTo().Window(handles[2]);

                        string companyName = customer[i].CompanyName;
                       
                        string nfSrc = utils.driver.Url;
                        utils.driver.Quit();

                        DateTime dateTimeNow = DateTime.Now;
                        var dateString = dateTimeNow.ToString("dd-MM-yyyy-HHmmss");
    
                        string PathWithNameFile = Path.Combine(".", "Invoices", Path.GetFileName($"{companyName}_{dateString}.pdf"));
  
                        await download.Invoice(nfSrc, PathWithNameFile);
                        await upload.Cms(PathWithNameFile);
                       
                          gmail.SendEmail(
                            emailsTo: new List<string> {
            $"{contract[0].Email}"
                            },
                            attachments: new List<string> {
                    $"{PathWithNameFile}"
                            }
                        );
                   }
                }
            } catch (Exception error) {
                Console.WriteLine($"Erro durante o Scraping: {error.Message}");
            }
        }
    }
}

