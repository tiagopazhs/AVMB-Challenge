using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;

namespace server.Domain.Interfaces.Service
{
    public interface IRepositoryService
    {
        Task<RepositoryModel> Create(string idUser, string repositoryName);
    }
}
