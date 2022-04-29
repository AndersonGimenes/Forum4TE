using Forum4TE.Domain.Entites;
using Forum4TE.Repository.Context;
using Forum4TE.Repository.Mapper;
using Forum4TE.Repository.Models;
using Forum4TE.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum4TE.Repository.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly Forum4TEContext _context;

        public ContentRepository(Forum4TEContext context)
        {
            _context = context;
        }

        public void Create(ContentDomain content)
        {
            var model = MapperModel.MapperContentToContentModel(content);

            _context.Contents.Add(model);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var model = _context
                            .Contents
                            .FirstOrDefault(x => x.Id == id);

            _context.Contents.Remove(model);
            _context.SaveChanges();
        }

        public ContentDomain Get(Guid id)
        {
            var model = _context
                            .Contents
                            .AsNoTracking()
                            .FirstOrDefault(x => x.Id == id);

            return MapperModel.MapperContentModelToContent(model);
        }

        public IEnumerable<ContentDomain> GetAll() 
        {
            var result = _context
                            .Contents
                            .AsNoTracking()
                            .Include("User")
                            .AsEnumerable();

            return GetAllBase(result);
        }

        public IEnumerable<ContentDomain> GetAllByUser(Guid userId)
        {
            var result = _context
                            .Contents
                            .AsNoTracking()
                            .Include("User")
                            .Where(x => x.UserId == userId)
                            .AsEnumerable();

            return GetAllBase(result);
        }

        public void Update(ContentDomain content)
        {
            var model = MapperModel.MapperContentToContentModel(content);

            _context.Contents.Update(model);
            _context.SaveChanges();
        }

        #region [PRIVATE METHODS]
        public IEnumerable<ContentDomain> GetAllBase(IEnumerable<ContentModel> models)
        {
            if (!models.Any())
                return new List<ContentDomain>();

            var contentList = MapperModel.MapperContentModelToContentList(models).ToList();

            return contentList;
        }
        #endregion
    }
}
