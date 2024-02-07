using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Git.Data;
using Git.Models;
using Git.ViewModels;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext context;

        public RepositoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<RepositoryViewModel> GetAllRepositories(string userId)
        {
            return this.context.Repositories.Where(r => r.OwnerId == userId || r.IsPublic == true)
                .OrderByDescending(x => x.OwnerId == userId)
                .ThenByDescending(x => x.CreatedOn)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Owner = x.Owner.Username,
                    CreatedOn = x.CreatedOn.ToString("MM/dd/yyyy h:mm tt"),
                    CommitsCount = x.Commits.Count,

                }).ToList();

        }
        public void CreateReposotory(CreateRepositoryModel repositoryModel)
        {
            Repository repository = new Repository()
            {
                Name = repositoryModel.Name,
                OwnerId = repositoryModel.OwnerId,
                CreatedOn = DateTime.Now.ToUniversalTime(),
                IsPublic = repositoryModel.RepositoryType == "Public" ? true : false,
            };

            this.context.Repositories.Add(repository);
            this.context.SaveChanges();
        }

        public bool IsRepositoryNameAvailable(string repositoryName, string userId)
        {
            return !this.context.Repositories.Any(x => x.Name == repositoryName && x.OwnerId == userId);
        }

        public CreateCommitViewModel GetRepositoryNameAndId(string repositoryId)
        {
            return new CreateCommitViewModel
            {
                Id = repositoryId,
                Name = this.context.Repositories.FirstOrDefault(x => x.Id == repositoryId).Name,
            };
        }
    }
}
