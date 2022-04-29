using System;
using System.Collections.Generic;

namespace Forum4TE.Repository.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public IEnumerable<ContentModel> Contents { get; set; }
    }
}
