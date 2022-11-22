using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;
using server.Domain.Interfaces.Service;
using server.Domain.Interfaces.Service.AntiCorruption;

namespace server.Services
{
    public class EnvelopeService : IEnvelopeService
    {
        public readonly IRepositoryService _repositoryService;
        public readonly IFolderService _folderService;
        public readonly IEnvelopeAntiCorruptionService _envelopeAntiCorruptionService;

        public EnvelopeService(IRepositoryService repositoryService, IFolderService folderService, IEnvelopeAntiCorruptionService envelopeAntiCorruptionService)
        {
            _repositoryService = repositoryService;
            _folderService = folderService;
            _folderService = folderService;
            _envelopeAntiCorruptionService = envelopeAntiCorruptionService;
        }
        public async Task<EnvelopeModel> Create(CreateEnvelopeModel data)
        {
            RepositoryModel repository = await _repositoryService.Create(data.UserId, data.RepositoryName);
            FolderModel folder = await _folderService.Create(repository.id, data.FolderName);
            EnvelopeModel envelope = await _envelopeAntiCorruptionService.Create(data, folder, repository);

            return envelope;
        }
    }
}
