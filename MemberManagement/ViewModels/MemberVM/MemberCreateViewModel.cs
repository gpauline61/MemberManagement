using MemberManagement.Application.Validators.MemberValidators;
using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Web.ViewModels.MemberVM
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
        [AgeRangeAttribute]
        public DateOnly Birthdate { get; set; }
        public string? Address { get; set; }
        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }
        public int? MembershipId { get; set; }
        public Membership? Membership { get; set; }
        [Display(Name = "Contact No.")]
        [RegularExpression(@"^\+639([0-9]{9})$", ErrorMessage = "Invalid input. +639xxxxxxxxx")]
        public string? ContactNo { get; set; }
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? Email { get; set; }
    }
    
}
