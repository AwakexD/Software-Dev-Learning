using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Git.Models;
using Git.Services;
using Microsoft.EntityFrameworkCore.Internal;

namespace Git.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;

    //ToDo : Login and Register
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel loginModel)
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel registerModel)
        {
            return this.View();
        }

        public HttpResponse Logout()
        {
            return this.View();
        }
    }
}
