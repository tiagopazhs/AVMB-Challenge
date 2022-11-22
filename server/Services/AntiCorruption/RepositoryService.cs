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
    public class RepositoryService : IRepositoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RepositoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<RepositoryModel> Create(string idUser, string repositoryName)
        {
            var body = new
            {
                token = Settings.Token,
                @params = new
                {
                    Repositorio = new RepositoryModel
                    {
                        Usuario = new UserModel
                        {
                            id = idUser
                        },
                        nome = repositoryName,
                        compartilharCriacaoDocs = "S",
                        compartilharVisualizacaoDocs = "S",
                        ocultarEmailSignatarios = "N",
                        opcaoValidCertICP = "S",
                        opcaoValidDocFoto = "S",
                        opcaoValidDocSelfie = "S",
                        opcaoValidTokenSMS = "S",
                        opcaoValidLogin = "S",
                        opcaoValidReconhecFacial = "S",
                        opcaoValidPix = "N",
                        lembrarAssinPendentes = "N"
                    }
                }
            };
            var httpRequestMessage = new HttpRequestMessage();
            HttpRequestMessage message = new HttpRequestMessage();
            httpRequestMessage.Headers.Add("Accept", "application/json");
            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri($"{Settings.SignatureApiUrl}/inserirRepositorio");

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.Timeout = new TimeSpan(0, 2, 0);

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();
                CreateRepositoryResponseModel responseAntiCorruption = await System.Text.Json.JsonSerializer.DeserializeAsync<CreateRepositoryResponseModel>(contentStream);

                return new RepositoryModel
                {
                    id = responseAntiCorruption.response.data.idRepositorio,
                    nome = repositoryName
                };
            }
            throw new System.Exception("Erro ao criar repositorio");
        }
    }
}
