using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;

namespace server.Domain.Interfaces.Service.AntiCorruption
{
    public interface IEnvelopeAntiCorruptionService
    {
        Task<EnvelopeModel> Create(CreateEnvelopeModel data,FolderModel folder, RepositoryModel repository);
    }
}
