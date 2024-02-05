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
            if (usersService.DoesUserExist(loginModel.Username, loginModel.Password) == false)
            {
                return this.Error("User with this username and password does not exist.");
            }

            var userId = usersService.GetUserId(loginModel.Username, loginModel.Password);
            this.SignIn(userId);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel registerModel)
        {

            if (string.IsNullOrEmpty(registerModel.Username) || registerModel.Username.Length < 5 && registerModel.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters long.");
            }

            if (usersService.IsEmailValid(registerModel.Email) == false || string.IsNullOrEmpty(registerModel.Email))
            {
                return this.Error("Invalid email!");
            }

            if (string.IsNullOrEmpty(registerModel.Password) || registerModel.Password.Length < 6 || registerModel.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters long.");
            }
            if (this.IsUserSignedIn())
            {
                return this.Error("Only logged off users can register");
            }

            if (usersService.IsEmailAvailable(registerModel.Email) == false)
            {
                return this.Error("Email is already taken.");
            }

            if (usersService.IsUsernameAvailable(registerModel.Username) == false)
            {
                return this.Error("Username is already taken");
            }

            if (usersService.DoesUserExist(registerModel.Username, registerModel.Password))
            {
                return this.Error("User already exists.");
            }

            this.usersService.CreateUser(registerModel.Username, registerModel.Email, registerModel.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
