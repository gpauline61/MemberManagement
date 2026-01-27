using MemberManagement.Application.DTO;
using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
using System;
using System.Collections;

namespace MemberManagement.Application.Services
{
    public class MemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _memberRepository.GetAll();
        }

        public async Task<Member> DetailMember(int id)
        {
            return await _memberRepository.DetailMember(id);
        }

        public bool AddMember(Member member)
        {
            return _memberRepository.Add(member);
        }

        public async Task<Member> EditMember(int id)
        {
            return await _memberRepository.EditMember(id);
        }

        public async Task SaveEditMember(int id, Member member)
        {
            await _memberRepository.SaveEditMember(id, member);
        }

        public async Task<Member> DeleteMember(int id)
        {
            return await _memberRepository.DeleteMember(id);

        }

        public async Task DeleteConfirmed(int id)
        {
            await _memberRepository.DeleteConfirmed(id);
        }

        public List<int> GetMemberCount()
        {
            return _memberRepository.GetMemberCount();
        }

        public async Task<IEnumerable> GetAllActive()
        {
            return await _memberRepository.GetAllActive();
        }

        public async Task<IEnumerable> GetAllInactive()
        {
            return await _memberRepository.GetAllInactive();
        }

    }
}
