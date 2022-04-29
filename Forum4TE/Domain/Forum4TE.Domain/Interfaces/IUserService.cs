using Forum4TE.Domain.Entites;

namespace Forum4TE.Domain.Interfaces
{
    public interface IUserService
    {
        void Create(UserDomain user);
        UserDomain GetByCredential(string email, string password);
    }
}
