using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;

namespace server.Domain.Interfaces.Service
{
    public interface IFolderService
    {
        Task<FolderModel> Create(string repositoryId, string folderName);
    }
}
