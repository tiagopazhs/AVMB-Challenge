using server.Domain.Interfaces.Repository;
using server.Domain.Entity;
using server.Infraestructure.Context;
using System.Threading.Tasks;

namespace server.Infraestructure.Repository
{
    public class EnvelopeRepository : IEnvelopeRepository
    {
        public async Task<Envelope> Store(Envelope data)
        {
            using (var context = new ApiContext())
            {
                var envelopes = new List<Envelope>
                {
                data
                };
                context.Envelopes.AddRange(envelopes);
                context.SaveChanges();
                return data;
            }
        }
    }
}