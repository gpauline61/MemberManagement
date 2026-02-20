
namespace MemberManagement.Domain.Entities
{
    public class Member
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly? Birthdate { get; set; }
        public string? Address { get; set; }

        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }

        public int? MembershipId { get; set; }
        public Membership? Membership { get; set; }

        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public Member() { }
        public Member(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required.");
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.");

            FirstName = firstName;
            LastName = lastName;
            IsActive = true;
            DateCreated = DateTime.UtcNow;
        }
    }

}
