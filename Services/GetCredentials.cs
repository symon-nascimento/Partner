using Partner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partner.Services {
    internal class GetCredentials {
        public List<PortalsCredential> PortalCityHall() {

            PartnerContext db = new();
            List<PortalsCredential> credential = new();

            try {
                credential = db.PortalsCredentials.Select(data => new PortalsCredential {
                    Uin = data.Uin,
                    BaseUrl = data.BaseUrl,
                    Password = data.Password
                }).ToList();

                Console.WriteLine($"Credenciais identificadas");
            } catch (Exception error) {
                Console.WriteLine($"Erro durante ao buscar as credenciais de acesso ao portal da prefeitura no Banco de dados: {error.Message}");
            }
            return credential;
        }
    }
}
