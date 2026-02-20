using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Application.DTO.BranchDTO
{
    public class BranchDeleteDTO
    {
        public int BranchID { get; set; }
        [Display(Name = "Branch")]
        public string BranchName { get; set; }
        [Display(Name = "Address")]
        public string BranchAddress { get; set; }
    }
}
