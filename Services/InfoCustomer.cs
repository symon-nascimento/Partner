using Partner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partner.Services {
    internal class InfoCustomer {
        public List<Client> GetCustomer(int idClient) {
            PartnerContext db = new();
            List<Client> client = new();

            try {
                client = db.Clients
                                .Where(data => data.Id == idClient)
                                .Select(data => new Client {
                                    Alias = data.Alias,
                                    Uin = data.Uin,
                                    CompanyName = data.CompanyName,
                                    Id = data.Id,
                                }).ToList();
                Console.WriteLine($"Dados do cliente identificados");
                foreach (var c in client) {
                    Console.WriteLine($"Cliente (Infor Customers) {c.CompanyName}");
                }
            } catch (Exception error) {
                Console.WriteLine($"Erro ao buscar as informações do cliente no Banco de Dados: {error.Message}");
            }
            return client;
        }
    }
}
