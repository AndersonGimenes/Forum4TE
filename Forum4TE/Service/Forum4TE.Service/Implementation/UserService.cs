using Forum4TE.Domain.Entites;
using Forum4TE.Domain.Interfaces;
using Forum4TE.Domain.Validations;
using Forum4TE.Security;
using Forum4TE.Service.Interfaces;
using System;

namespace Forum4TE.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Create(UserDomain user)
        {
            var userDomain = _repository.GetByEmail(user.Email);

            UserValidation.DoubleUserValidation(userDomain);

            user.SetCreateDate()
                .SetPasswordEncrypt(PasswordHandler.GeneratePassword(user.Email, user.Password));

            _repository.Create(user);
        }

        public UserDomain GetByCredential(string email, string password)
        {
            var user = _repository.GetByCredential(email, PasswordHandler.GeneratePassword(email, password));

            UserValidation.VerifyUserLogin(user);

            return user;
        }
    }
}
