 using MemberManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Web.ViewModels
{
    public class MemberCreateViewModel
    {
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateOnly Birthdate { get; set; }
        public string Address { get; set; }
        public BranchCategory Branch { get; set; }
        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
    }
}
