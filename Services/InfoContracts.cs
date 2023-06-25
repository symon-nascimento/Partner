using Partner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partner.Services {
    internal class InfoContracts {
        public List<Contract> Contracts(int idContract) {

            PartnerContext db = new();
            List<Contract> contract = new List<Contract>();

            try {
                contract = db.Contracts
                          .Where(data => data.Id == idContract)
                          .Select(data => new Contract {
                              Clients = data.Clients,
                              Id = data.Id,
                              ContractStart = data.ContractStart,
                              ContractEnd = data.ContractEnd,
                              EmailSendDate = data.EmailSendDate,
                              MonthlyFees = data.MonthlyFees,
                              Email = data.Email,
                              Manager = data.Manager,
                              TelephoneNumber = data.TelephoneNumber,
                              WhatsappNumber = data.WhatsappNumber,
                              ServiceDescription = data.ServiceDescription,
                          }).ToList();
                Console.WriteLine($"Dados do contrato identificados");

            } catch (Exception error) {
                Console.WriteLine($"Erro ao buscar as informações do contrato no Banco de Dados: {error.Message}");
            }
            return contract;
        }
    }
}
