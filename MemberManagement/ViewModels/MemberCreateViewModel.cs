using MemberManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Web.ViewModels
{
    public class MemberCreateViewModel
    {
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        //Date picker
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateOnly Birthdate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public string? Address { get; set; }
        public BranchCategory Branch { get; set; }
        [Display(Name = "Contact No.")]
        [RegularExpression(@"^\+639([0-9]{9})$", ErrorMessage = "Invalid input. +639xxxxxxxxx")]
        public string? ContactNo { get; set; }
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? Email { get; set; }
    }
    
}
