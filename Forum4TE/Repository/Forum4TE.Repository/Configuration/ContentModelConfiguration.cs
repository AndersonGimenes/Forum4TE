using Forum4TE.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum4TE.Repository.Configuration
{
    public class ContentModelConfiguration : IEntityTypeConfiguration<ContentModel>
    {
        public void Configure(EntityTypeBuilder<ContentModel> builder)
        {
            builder
                .ToTable("Content");

            builder
                .HasKey(x => x.Id)
                .HasName("Pk_Content");

            builder
                .Property(x => x.Id)
                .HasColumnType("char(36)");

            builder
                .Property(x => x.Title)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
                .Property(x => x.CreateDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(x => x.UpdateDate)
                .HasColumnType("datetime");

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Contents)
                .HasConstraintName("Fk_User_Content")
                .HasForeignKey("UserId");
        }
    }
}
