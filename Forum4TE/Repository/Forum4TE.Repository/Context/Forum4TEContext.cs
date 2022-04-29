using Forum4TE.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Forum4TE.Repository.Context
{
    public class Forum4TEContext : DbContext
    {
        public Forum4TEContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<ContentModel> Contents { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
