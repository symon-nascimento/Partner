
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using DotNetEnv;
using Partner.CityHalls;
using Partner.Entities;

namespace Partner {
    class Program {
        public static async Task Main() {
            DotNetEnv.Env.Load();
            DotNetEnv.Env.TraversePath().Load();
            PartnerContext db = new();

            DateTime dateTimeNow = DateTime.Now;
            var dateString = dateTimeNow.ToString("dd/MM/yyyy HH:mm:ss");

            int dateNow = dateTimeNow.Day;
            int month = dateTimeNow.Month;
            int year = dateTimeNow.Year;

            // Verificar se hoje existe nota a ser emitida e se esta dentro do prazo de vigência do contrato.

            try {
            
                var ids = db.Contracts
                  .Where(data => data.EmailSendDate.Value.Day == dateNow)
                  .Where(data => data.ContractEnd.Value.Month >= month)
                  .Where(data => data.ContractEnd.Value.Year == year)
                  .Select(data => data.Id)
                  .ToList();

                if (ids.Count == 0) {
                    await Console.Out.WriteLineAsync("Sem notas fiscais pendentes!");
                }

                foreach (var idContract in ids) {
                    await Console.Out.WriteLineAsync($"ID da Nota fiscal pendente: {idContract}");

                    if (idContract == ids.Count) {
                        await Guaruja.Scraping(ids);
                    }
                }

            } catch (Exception error) {
                await Console.Out.WriteLineAsync($"Erro ao buscar Notas Fiscais pendentes -> {error.Message}");
            }
        }
    }
}
