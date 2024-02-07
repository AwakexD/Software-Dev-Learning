using System;
using System.Collections.Generic;
using System.Text;
using Git.Models;
using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;
        private readonly IRepositoryService repositoryService;

        public CommitsController(ICommitService commitService, IRepositoryService repositoryService)
        {
            this.commitService = commitService;
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            var allCommits = this.commitService.GetUserAllCommits(this.GetUserId());
            return this.View(allCommits);
        }

        public HttpResponse Create(string id)
        {
           var viewModel = this.repositoryService.GetRepositoryNameAndId(id);
           return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateCommitModel commitModel)
        {
            if (string.IsNullOrEmpty(commitModel.Description) && commitModel.Description.Length < 5)
            {
                return this.View("Invalid commit description");
            }

            commitModel.CreatorId = this.GetUserId();
            this.commitService.Create(commitModel);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {
            string userId = this.GetUserId();

            if (commitService.DoesCommitExist(id, userId) == false)
            {
                return this.Error("Commit does not exists");
            }

            this.commitService.Delete(id);

            return this.Redirect("/Commits/All");
        }
    }
}
