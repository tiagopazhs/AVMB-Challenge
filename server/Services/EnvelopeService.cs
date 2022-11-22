using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;
using server.Domain.Interfaces.Service;

namespace server.Services
{
    public class  EnvelopeService : IEnvelopeService
    {
        public readonly IRepositoryService _repositoryService;

        public EnvelopeService(IRepositoryService repositoryService){
            _repositoryService=repositoryService;
        }
        public async Task<EnvelopeModel> Create()
        {
            RepositoryModel repository = await _repositoryService.Create("16481","newRepository");

            return new EnvelopeModel{
                Repositorio=repository
            };
        }
    }
}
