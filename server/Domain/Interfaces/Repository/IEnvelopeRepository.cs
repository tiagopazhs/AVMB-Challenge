using System.Collections.Generic;
using System.Threading.Tasks;
using server.Domain.Entity;

namespace server.Domain.Interfaces.Repository
{
    public interface IEnvelopeRepository
    {
        Task<Envelope> Store(Envelope data);
    }
}
