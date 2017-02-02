namespace MusicArchive.Repositories
{
    public interface IUserRepository
    {
        void RegisterNewUser(string userName, string emailAddress, string password);
        bool Login(string userName, string password);
    }
}