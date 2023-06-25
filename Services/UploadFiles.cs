using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;

namespace Partner.Services {
    internal class UploadFiles {
        public async Task Cms(string PathWithNameFile) {

            try {
                DotNetEnv.Env.Load();
                DotNetEnv.Env.TraversePath().Load();
                string CMS_URL = DotNetEnv.Env.GetString("CMS_URL");

                string directusEndpoint = $"{CMS_URL}";

                using (HttpClient client = new()) {
                    // Lê o conteúdo do arquivo PDF
                    byte[] fileBytes = File.ReadAllBytes(PathWithNameFile);

                    // Cria uma solicitação multipart/form-data manualmente
                    using (var formData = new MultipartFormDataContent()) {
                        // Cria um ByteArrayContent com o conteúdo do arquivo PDF
                        var fileContent = new ByteArrayContent(fileBytes);
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");

                        // Define o nome do campo e o nome do arquivo
                        formData.Add(fileContent, "file", Path.GetFileName(PathWithNameFile));

                        // Faz a solicitação POST para o Directus
                        HttpResponseMessage response = client.PostAsync(directusEndpoint, formData).Result;

                        // Verifica se a solicitação foi bem-sucedida
                        if (response.IsSuccessStatusCode) {
                            Console.WriteLine("PDF enviado com sucesso para o Directus!");
                        } else {
                            Console.WriteLine($"Falha ao enviar o PDF para o Directus. Status: {response.StatusCode}");
                        }
                    }
                }
            } catch (Exception error) {
                Console.WriteLine($"Erro ao durante o Download da nota: {error.Message}");
            }
        }
    }
}
