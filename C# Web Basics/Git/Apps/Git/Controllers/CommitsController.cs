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

        //ToDo : Fix Crate page
        public HttpResponse Create(string repositoryId)
        {
            var viewModel = this.repositoryService.GetRepositoryNameAndId(repositoryId);
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateCommitModel commitModel)
        {
            return this.View();
        }

        public HttpResponse Delete(string repositoryId)
        {

        }
    }
}
