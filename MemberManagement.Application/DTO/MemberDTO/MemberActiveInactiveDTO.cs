using MemberManagement.Domain.Entities;

namespace MemberManagement.Application.DTO.MemberDTO
{
    public class MemberActiveInactiveDTO
    {
        public int MemberID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateOnly Birthdate { get; set; }
        public string? Address { get; set; }
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }
        public int? MembershipId { get; set; }
        public Membership? Membership { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
    }
}
