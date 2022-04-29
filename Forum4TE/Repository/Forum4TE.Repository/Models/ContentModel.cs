using System;

namespace Forum4TE.Repository.Models
{
    public class ContentModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public UserModel User { get; set; }
    }
}
