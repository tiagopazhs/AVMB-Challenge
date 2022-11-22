using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;
using server.Models.AntiCorruption;
using server.Domain.Interfaces.Service;
using Newtonsoft.Json;
using System.Text.Json;
using server;
namespace server.Services
{
    public class FolderService : IFolderService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FolderService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<FolderModel> Create(string repositoryId,string folderName)
        {
            var body = new
            {
                token = Settings.Token,
                @params = new
                {
                    Pasta = new FolderModel
                    {
                        Repositorio=new RepositoryModel{
                            id=repositoryId
                        },
                        nome = folderName
                    }
                }
            };
            var httpRequestMessage = new HttpRequestMessage();
            HttpRequestMessage message = new HttpRequestMessage();
            httpRequestMessage.Headers.Add("Accept", "application/json");
            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri($"{Settings.SignatureApiUrl}/inserirPasta");

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.Timeout = new TimeSpan(0, 2, 0);

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();
                CreateFolderResponseModel responseAntiCorruption = await System.Text.Json.JsonSerializer.DeserializeAsync<CreateFolderResponseModel>(contentStream);

                return new FolderModel
                {
                    id = responseAntiCorruption.response.data.idPasta,
                    nome = folderName
                };
            }
            throw new System.Exception("Erro ao criar a pasta.");
        }
    }
}
