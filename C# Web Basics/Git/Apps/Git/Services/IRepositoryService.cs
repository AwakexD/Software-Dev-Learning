using Git.Models;
using Git.ViewModels;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoryService
    {
        void CreateReposotory(CreateRepositoryModel repositoryModel);
        List<RepositoryViewModel> GetAllRepositories(string userId);
        bool IsRepositoryNameAvailable(string repositoryName, string userId);
    }
}
