
namespace MemberManagement.Domain.Entities
{
    public class Membership
    {
        public int MembershipID { get; set; }
        public string MembershipType { get; private set; }
        public string? MembershipDescription { get; set; }
        public DateTime DateCreated { get; private set; }

        public List<Member>? Members { get; private set; }

        public Membership() { }
        public Membership(List<Member> members, string membershipType)
        {
            MembershipType = membershipType;
            Members = members ?? new List<Member>();
            DateCreated = DateTime.UtcNow;
        }
    }
}
