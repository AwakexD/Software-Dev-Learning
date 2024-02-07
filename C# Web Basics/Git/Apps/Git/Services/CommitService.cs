using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Git.Data;
using Git.Models;
using Git.ViewModels;

namespace Git.Services
{
    public class CommitService : ICommitService
    {
        private readonly ApplicationDbContext context;

        public CommitService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(CreateCommitModel commitModel)
        {
            Commit newCommit = new Commit()
            {
                CreatedOn = DateTime.Now.ToUniversalTime(),
                RepositoryId = commitModel.RepositoryId,
                CreatorId = commitModel.CreatorId,
                Description = commitModel.Description,
            };

            this.context.Commits.Add(newCommit);
            this.context.SaveChanges();
        }

        public List<CommitViewModel> GetUserAllCommits(string userId)   
        {
            return this.context.Commits.Where(c => c.CreatorId == userId)
                .OrderByDescending(c => c.Repository.Name)
                .Select(c => new CommitViewModel
                {
                    Id = c.Id,
                    Repository = c.Repository.Name,
                    CreatedOn = c.CreatedOn.ToString("MM/dd/yyyy h:mm tt"),
                    Description = c.Description,
                }).ToList();
        }

        public void Delete(string commitId)
        {
            var commit = this.context.Commits.FirstOrDefault(c => c.Id == commitId);
            this.context.Commits.Remove(commit);
            this.context.SaveChanges();
        }

        public bool DoesCommitExist(string commitId, string userId)
        {
            return this.context.Commits.Any(c => c.Id == commitId && c.CreatorId == userId);
        }
    }
}
