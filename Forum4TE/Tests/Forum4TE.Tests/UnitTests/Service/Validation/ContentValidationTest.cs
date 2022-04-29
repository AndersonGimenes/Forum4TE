using Forum4TE.Domain.Entites;
using Forum4TE.Domain.Exceptions;
using Forum4TE.Domain.Validations;
using System;
using Xunit;

namespace Forum4TE.Tests.UnitTests.Service.Validation
{
    public class ContentValidationTest
    {
        [Fact]
        public void MustThrowDomainExceptionWhenUsersAreNotTheSame()
        {
            var request = new ContentDomain { UserId = Guid.Parse("341e5447-d234-4711-9437-a988ec87cb3d") };
            var registered = new ContentDomain { UserId = Guid.Parse("716e6223-7801-4572-a5f1-705e0576c7fc") };

            var ex = Assert.Throws<DomainException>(() => ContentValidation.CheckIdUsersAreTheSameToUpdate(request, registered));
            Assert.Equal("Can not Update!", ex.Message);
        }
    }
}
