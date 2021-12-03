using AppJobSearch.Utility.Language;
using System.ComponentModel.DataAnnotations;

namespace AppJobSearch.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E003")]
        public string Name { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E002")]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(6, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E003")]
        public string Password { get; set; }
    }
}
