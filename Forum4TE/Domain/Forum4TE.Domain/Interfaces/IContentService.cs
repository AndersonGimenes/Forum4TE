using Forum4TE.Domain.Entites;
using System;
using System.Collections.Generic;

namespace Forum4TE.Domain.Interfaces
{
    public interface IContentService
    {
        IEnumerable<ContentDomain> GetAll();
        IEnumerable<ContentDomain> GetAllByUser(Guid UserId);
        ContentDomain Get(Guid id);
        void Create(ContentDomain content);
        void Update(ContentDomain content);
        void Delete(Guid id);
    }
}
