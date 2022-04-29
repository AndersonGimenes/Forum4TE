using System;

namespace Forum4TE.Domain.Entites
{
    public class UserDomain
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }

        public UserDomain SetCreateDate()
        {
            CreateDate = DateTime.Now;
            return this;
        }

        public UserDomain SetPasswordEncrypt(string value)
        {
            Password = value;
            return this;
        }
    }
}
