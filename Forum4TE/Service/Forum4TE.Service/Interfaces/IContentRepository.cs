using Forum4TE.Domain.Entites;
using System;
using System.Collections.Generic;

namespace Forum4TE.Service.Interfaces
{
    public interface IContentRepository
    {
        IEnumerable<ContentDomain> GetAll();
        ContentDomain Get(Guid id);
        void Create(ContentDomain content);
        void Update(ContentDomain content);
        void Delete(Guid id);
        IEnumerable<ContentDomain> GetAllByUser(Guid userId);
    }
}
