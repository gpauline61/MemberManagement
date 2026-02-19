
namespace MemberManagement.Domain.Entities
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string? BranchAddress { get; set; }
        public DateTime DateCreated { get; set; }

        public List<Member>? Members { get; set; }

    }
}
