using MemberManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Web.ViewModels.MemberVM
{
    public class MemberEditViewModel
    {
        public int MemberID { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateOnly Birthdate { get; set; }
        public string? Address { get; set; }
        public BranchCategory Branch { get; set; }
        [Display(Name = "Contact No.")]
        [RegularExpression(@"^\+639([0-9]{9})$", ErrorMessage = "Invalid input. +639xxxxxxxxx")]
        public string? ContactNo { get; set; }
        [Display(Name = "Email Address")]
        public string? Email { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
