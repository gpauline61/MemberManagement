using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Web.ViewModels.Branch
{
    public class BranchEditViewModel
    {
        public int BranchID { get; set; }

        [Required(ErrorMessage = "Branch name is required.")]
        [Display(Name = "Branch")]
        public string BranchName { get; set; }

        [Required(ErrorMessage = "Branch Address is required.")]
        [Display(Name = "Address")]
        public string BranchAddress { get; set; }
    }
}
