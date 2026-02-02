using MemberManagement.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Application.Services
{
    public class HomeService
    {
        private readonly IHomeRepository _homeRepository; 
        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }
        public List<int> GetMemberCount()
        {
            return _homeRepository.GetMemberCount();
        }
    }
}
