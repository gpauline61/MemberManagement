using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Web.ViewModels.Branch
{
    public class BranchIndexViewModel
    {
        public int BranchID { get; set; }
        [Display(Name = "Branch")]
        public string BranchName { get; set; }
        [Display(Name = "Address")]
        public string BranchAddress { get; set; }
    }
}
