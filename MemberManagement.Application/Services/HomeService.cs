using MemberManagement.Domain.Interfaces;

namespace MemberManagement.Application.Services
{
    public class HomeService
    {
        private readonly IHomeRepository _homeRepository; 
        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        //Computation of the total count for All,
        //Active, and Inactive members
        public List<int> GetMemberCount()
        {
            return _homeRepository.GetMemberCount();
        }
    }
}
