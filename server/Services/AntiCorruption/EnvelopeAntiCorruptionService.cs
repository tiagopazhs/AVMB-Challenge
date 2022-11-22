using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;
using server.Models.AntiCorruption;
using server.Services;
using server.Domain.Interfaces.Service.AntiCorruption;
using Newtonsoft.Json;
namespace server.Services.AntiCorruption
{
    public class EnvelopeAntiCorruptionService : IEnvelopeAntiCorruptionService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public EnvelopeAntiCorruptionService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<EnvelopeModel> Create(CreateEnvelopeModel data, FolderModel folder, RepositoryModel repository)
        {
            var docs = new List<DocumentModel>();
            foreach (DocumentEventopeModel item in data.Documento)
            {
                docs.Add(new DocumentModel
                {
                    conteudo = item.Conteudo,
                    mimeType = item.MimeType,
                    nomeArquivo = item.NomeArquivo,
                });
            }
            var body = new
            {
                token = Settings.Token,
                @params = new
                {
                    Envelope = new
                    {
                        descricao = data.Descricao,
                        Repositorio = new RepositoryModel
                        {
                            id = repository.id,
                            nome = repository.nome,
                        },
                        Pasta = new FolderModel
                        {
                            id = folder.id,
                        },
                        mensagem = "Mensagem de abertura",
                        mensagemObservadores = "mensagem observadores",
                        /*mensagemNotificacaoSMS = null,
                        dataExpiracao = null,
                        horaExpiracao = null,*/
                        usarOrdem = "S",
                        ConfigAuxiliar = new
                        {
                            documentosComXMLs = "N",
                            urlCarimboTempo = "null"
                        },
                        listaDocumentos = new
                        {
                            Documento = docs
                        },
                        incluirHashTodasPaginas = "S",
                        permitirDespachos = "S",
                        ignorarNotificacoes = "N",
                        ignorarNotificacoesPendentes = "N",
                    }
                }
            };
            var httpRequestMessage = new HttpRequestMessage();
            HttpRequestMessage message = new HttpRequestMessage();
            httpRequestMessage.Headers.Add("Accept", "application/json");
            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri($"{Settings.SignatureApiUrl}/inserirEnvelope");

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.Timeout = new TimeSpan(0, 2, 0);

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();
                CreateEnvelopeResponseModel responseAntiCorruption = await System.Text.Json.JsonSerializer.DeserializeAsync<CreateEnvelopeResponseModel>(contentStream);

                return new EnvelopeModel
                {
                    id = responseAntiCorruption.response.data.idEnvelope
                };
            }
            throw new System.Exception("Erro ao criar repositorio");
        }
    }
}
