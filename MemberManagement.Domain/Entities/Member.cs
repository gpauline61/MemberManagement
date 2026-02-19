
namespace MemberManagement.Domain.Entities
{
    public class Member
    {
        public int MemberID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
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

        protected Member() { }
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

        public void Initialize()
        {
            this.IsActive = true;
            this.DateCreated = DateTime.UtcNow;
        }
    }

}
