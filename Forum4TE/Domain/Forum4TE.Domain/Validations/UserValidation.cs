using Forum4TE.Domain.Entites;
using Forum4TE.Domain.Exceptions;

namespace Forum4TE.Domain.Validations
{
    public static class UserValidation
    {
        public static void DoubleUserValidation(UserDomain userRegistered)
        {
            if (userRegistered != null)
                throw new DomainException("Email already registered");
        }

        public static void VerifyUserLogin(UserDomain user)
        {
            if (user is null)
                throw new DomainException("Invalid User");
        }
    }
}
