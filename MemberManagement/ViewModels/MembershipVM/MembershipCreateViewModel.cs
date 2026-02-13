using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Web.ViewModels.MembershipVM
{
    public class MembershipCreateViewModel
    {
        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Membership Type is required.")]
        public string MembershipType { get; set; }
        [Display(Name = "Membership Description")]
        [Required(ErrorMessage = "Membership Description is required.")]
        public string? MembershipDescription { get; set; }
    }
}
