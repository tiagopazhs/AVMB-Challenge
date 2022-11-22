using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;
using server.Domain.Interfaces.Service;

namespace server.Services
{
    public class  EnvelopeService : IEnvelopeService
    {
        public readonly IRepositoryService _repositoryService;
        public readonly IFolderService _folderService;

        public EnvelopeService(IRepositoryService repositoryService,IFolderService folderService){
            _repositoryService=repositoryService;
            _folderService=folderService;
        }
        public async Task<EnvelopeModel> Create(CreateEnvelopeModel data)
        {
            RepositoryModel repository = await _repositoryService.Create(data.UserId,data.RepositoryName);
            FolderModel folder = await _folderService.Create(repository.id,data.FolderName);

            return new EnvelopeModel{
                Repositorio=repository
            };
        }
    }
}
