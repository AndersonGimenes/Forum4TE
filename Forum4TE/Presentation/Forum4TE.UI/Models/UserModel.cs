using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forum4TE.UI.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        [DisplayName("Full Name")]
        [Required(ErrorMessage ="Full Name is required!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }

        public DateTime CreateDate { get; }
    }
}