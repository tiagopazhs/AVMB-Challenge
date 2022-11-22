using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;
using server.Domain.Interfaces.Service;

namespace server.Services
{
    public class  RepositoryService : IRepositoryService
    {
        public RepositoryService(){
        }
        public async Task<RepositoryModel> Create(string idUser, string repositoryName)
        {
            return new RepositoryModel{
                Id=1,
                Nome="NovoRepository"
            };
        }
    }
}
