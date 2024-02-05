using System;
using System.Collections.Generic;
using System.Text;
using Git.Models;
using Git.Services;
using Git.ViewModels;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Git.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoriesService;

        public RepositoriesController(IRepositoryService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            List<RepositoryViewModel> allRepositories = this.repositoriesService.GetAllRepositories(this.GetUserId());
            return this.View(allRepositories);
        }

        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepositoryModel repositoryModel)
        {
            if (string.IsNullOrEmpty(repositoryModel.Name) || repositoryModel.Name.Length < 3 || repositoryModel.Name.Length > 10)
            {
                this.Error("Repository name should be between 3 and 10 symbols.");
            }

            if (this.repositoriesService.IsRepositoryNameAvailable(repositoryModel.Name, repositoryModel.OwnerId) == false)
            {
                this.Error("Repository with this name already exists");
            }

            repositoryModel.OwnerId = this.GetUserId();
            this.repositoriesService.CreateReposotory(repositoryModel);

            return this.Redirect("/Repositories/All");
        }
    }
}
