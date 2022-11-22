using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;

namespace server.Domain.Interfaces.Service
{
    public interface IEnvelopeService
    {
        Task<EnvelopeModel> Create(CreateEnvelopeModel data);
    }
}
