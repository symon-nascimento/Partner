using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Partner.Services {
    internal class DownloadFiles {
        public async Task Invoice(string nfSrc, string PathWithNameFile) {

            try {

                using (HttpClient client = new()) {
                    HttpResponseMessage response = await client.GetAsync(nfSrc);
                    if (response.IsSuccessStatusCode) {
                        using (Stream contentStream = await response.Content.ReadAsStreamAsync()) {
                            using (FileStream fileStream = new(PathWithNameFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
                                await contentStream.CopyToAsync(fileStream);
                            }
                        }
                        Console.WriteLine("Download concluído!");

                    } else {
                        Console.WriteLine($"Falha ao fazer o download. Status de resposta: {response.StatusCode}");
                    }
                }
            } catch (Exception error) {
                Console.WriteLine($"Erro ao durante o Download da nota: {error.Message}");
            }
        }
    }
}

