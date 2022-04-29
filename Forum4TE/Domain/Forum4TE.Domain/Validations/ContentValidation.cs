using Forum4TE.Domain.Entites;
using Forum4TE.Domain.Exceptions;

namespace Forum4TE.Domain.Validations
{
    public static class ContentValidation
    {
        public static void CheckIdUsersAreTheSameToUpdate(ContentDomain request, ContentDomain registered)
        {
            if (request.UserId != registered.UserId)
                throw new DomainException("Can not Update!");
        }
    }
}
