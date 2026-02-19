
namespace MemberManagement.Domain.Entities
{
    public class Membership
    {
        public int MembershipID { get; set; }
        public string MembershipType { get; set; }
        public string? MembershipDescription { get; set; }
        public DateTime DateCreated { get; set; }

        public List<Member>? Members { get; set; }
    }
}
