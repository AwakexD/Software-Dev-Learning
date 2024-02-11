using System.Collections.Generic;
using Git.Models;
using Git.ViewModels;

namespace Git.Services
{
    public interface ICommitService
    {
        void Create(CreateCommitModel commitModel);

        List<CommitViewModel> GetUserAllCommits (string userId);

        void Delete(string commitId);

        bool DoesCommitExist(string commitId, string userId);
    }
}
