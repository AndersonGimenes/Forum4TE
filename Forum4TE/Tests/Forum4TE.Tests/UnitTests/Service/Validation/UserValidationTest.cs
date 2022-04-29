using Forum4TE.Domain.Entites;
using Forum4TE.Domain.Exceptions;
using Forum4TE.Domain.Validations;
using Xunit;

namespace Forum4TE.Tests.UnitTests.Service.Validation
{
    public class UserValidationTest
    {
        [Fact]
        public void MustThrowDomainExceptionWhenAlreadyEmailRegistered()
        {
            var registered = new UserDomain { Email = "test@test.com" };

            var ex = Assert.Throws<DomainException>(() => UserValidation.DoubleUserValidation(registered));
            Assert.Equal("Email already registered", ex.Message);
        }

        [Fact]
        public void MustThrowDomainExceptionWhenLoginInNotValid()
        {

            var ex = Assert.Throws<DomainException>(() => UserValidation.VerifyUserLogin(null));
            Assert.Equal("Invalid User", ex.Message);
        }
    }
}
