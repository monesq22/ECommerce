using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ECommerce.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "This Field is Reqired!")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "This Field is Reqired!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
