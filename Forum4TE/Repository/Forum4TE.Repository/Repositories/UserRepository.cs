using Forum4TE.Domain.Entites;
using Forum4TE.Repository.Context;
using Forum4TE.Repository.Mapper;
using Forum4TE.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Forum4TE.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Forum4TEContext _context;

        public UserRepository(Forum4TEContext context)
        {
            _context = context;
        }

        public void Create(UserDomain user)
        {
            var model = MapperModel.MapperUserToUserModel(user);

            _context.Users.Add(model);
            _context.SaveChanges();
        }

        public UserDomain GetByCredential(string email, string password)
        {
            var model = _context
                            .Users
                            .AsNoTracking()
                            .FirstOrDefault(x => x.Email == email && x.Password == password);

            if (model is null)
                return null;

            return MapperModel.MapperUserModelToUser(model);
        }

        public UserDomain GetByEmail(string email)
        {
            var model = _context
                           .Users
                           .AsNoTracking()
                           .FirstOrDefault(x => x.Email == email);

            if (model is null)
                return null;

            return MapperModel.MapperUserModelToUser(model);
        }
    }
}
