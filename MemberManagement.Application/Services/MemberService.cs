using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Application.Services
{
    public class MemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            return await _memberRepository.GetAll();
        }
    }
}
