
namespace MemberManagement.Domain.Entities
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; private set; }
        public string? BranchAddress { get; set; }
        public DateTime DateCreated { get; private set; }

        public List<Member>? Members { get; private set; }

        public Branch() { }
        public Branch(List<Member> members, string branchName)
        {
            BranchName = branchName;   
            Members = members ?? new List<Member>();
            DateCreated = DateTime.UtcNow;
        }

    }
}
