using Forum4TE.Domain.Entites;
using System;

namespace Forum4TE.Service.Interfaces
{
    public interface IUserRepository
    {
        void Create(UserDomain user);
        UserDomain GetByCredential(string email, string password);
        UserDomain GetByEmail(string email);
    }
}
