namespace Git.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);
        string GetUserId(string username, string password);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);

        bool DoesUserExist(string username, string password);

        bool IsEmailValid(string email);
    }
}
