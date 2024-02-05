using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Git.Data;

namespace Git.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string CreateUser(string username, string email, string password)
        {
            User user = new User
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password),
            };
            this.context.Users.Add(user);
            this.context.SaveChanges();

            return user.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.context.Users.Any(u => u.Email == email);
        }

        public string GetUserId(string username, string password)
        {
            return this.context.Users.FirstOrDefault(u => u.Username == username && u.Password == ComputeHash(password)).Id?
                .ToString();
        }

        public bool IsUsernameAvailable(string username)
        {
            return !this.context.Users.Any(u => u.Username == username);
        }

        public bool DoesUserExist(string username, string password)
        {
            return this.context.Users.Any(u => u.Username == username && u.Password == ComputeHash(password));
        }

        public bool IsEmailValid(string email)
        {
            EmailAddressAttribute emailAddressAttribute = new EmailAddressAttribute();
            return emailAddressAttribute.IsValid(email);
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            //Convert to text
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(b.ToString("X2"));
            }

            return hashedInputStringBuilder.ToString();
        }
    }
}
