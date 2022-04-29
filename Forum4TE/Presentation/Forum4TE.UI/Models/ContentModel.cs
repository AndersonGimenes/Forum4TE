using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forum4TE.UI.Models
{
    public class ContentModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        public string Creator { get; set; }
        
        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }
    }
}
