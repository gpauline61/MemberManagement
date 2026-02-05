using MemberManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Web.ViewModels
{
    public class MemberCreateViewModel
    {
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        //Date picker
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateOnly Birthdate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public string? Address { get; set; }
        public BranchCategory Branch { get; set; }
        [Display(Name = "Contact No.")]
        public string? ContactNo { get; set; }
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Emailasdasdas Address.")]
        public string? Email { get; set; }
    }
    
}
