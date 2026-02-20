
namespace MemberManagement.Domain.Entities
{
    public class Membership
    {
        public int MembershipID { get; set; }
        public string MembershipType { get; set; }
        public string? MembershipDescription { get; set; }
        public DateTime DateCreated { get; set; }

        public List<Member>? Members { get; set; }

        public Membership() { } //model Membership binding
        public Membership(List<Member> members, string membershipType)
        {
            MembershipType = membershipType;
            Members = members ?? new List<Member>();
            DateCreated = DateTime.UtcNow;
        }
    }
}
