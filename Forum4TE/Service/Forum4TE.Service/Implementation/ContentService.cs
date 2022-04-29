using Forum4TE.Domain.Entites;
using Forum4TE.Domain.Interfaces;
using Forum4TE.Domain.Validations;
using Forum4TE.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Forum4TE.Service.Implementation
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _repository;

        public ContentService(IContentRepository repository)
        {
            _repository = repository;
        }

        public void Create(ContentDomain content) => _repository.Create(content.SetCreateDate(null));
    
        public void Delete(Guid id) => _repository.Delete(id);
        
        public ContentDomain Get(Guid id) => _repository.Get(id);

        public IEnumerable<ContentDomain> GetAll() => _repository.GetAll();

        public IEnumerable<ContentDomain> GetAllByUser(Guid UserId) => _repository.GetAllByUser(UserId);

        public void Update(ContentDomain content)
        {
            var result = _repository.Get(content.Id);

            ContentValidation.CheckIdUsersAreTheSameToUpdate(content, result);

            content
                .SetCreateDate(result.CreateDate)
                .SetUpdateDate();

            _repository.Update(content);
        }
    }
}
