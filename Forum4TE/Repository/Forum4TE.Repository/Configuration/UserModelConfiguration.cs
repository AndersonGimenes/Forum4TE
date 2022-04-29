using Forum4TE.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum4TE.Repository.Configuration
{
    public class UserModelConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder
                .ToTable("User");

            builder
                .HasKey(x => x.Id)
                .HasName("Pk_User");

            builder
                .Property(x => x.Id)
                .HasColumnType("char(36)");

            builder
                .Property(x => x.FullName)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(x => x.Password)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder
                .Property(x => x.CreateDate)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
