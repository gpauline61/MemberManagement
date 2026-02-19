
using MemberManagement.Domain.Entities;

<<<<<<< HEAD
=======
using MemberManagement.Domain.Enum;

>>>>>>> feature/membership
namespace MemberManagement.Application.DTO.MemberDTO
{
    public class MemberCreateDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateOnly Birthdate { get; set; }
        public string? Address { get; set; }
        public Branch? Branch { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
    }
}
