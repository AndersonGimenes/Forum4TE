using System;

namespace Forum4TE.Domain.Entites
{
    public class ContentDomain
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ContentDomain SetCreateDate(DateTime? createDate)
        {
            CreateDate = createDate ?? DateTime.Now;
            return this;
        }

        public ContentDomain SetUpdateDate()
        {
            UpdateDate = DateTime.Now;
            return this;
        }

        public ContentDomain SetUserId(Guid value)
        {
            UserId = value;
            return this;
        }

        public ContentDomain SetCreator(string creator)
        {
            Creator = creator;
            return this;
        }
    }
}
