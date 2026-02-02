using MemberManagement.Application.DTO;
using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
using System;
using System.Collections;
using System.Net.NetworkInformation;

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
            var status = "";
            IEnumerable<Member> membersDTO = (IEnumerable<Member>)await _memberRepository.GetAll();

            List<MemberIndexDTO> memresDTO = new List<MemberIndexDTO>();
            foreach (var member in membersDTO)
            {
                if (member.IsActive)
                {
                    status = "YES";
                }
                else
                {
                    status = "NO";
                }
                var memberDTO = new MemberIndexDTO()
                {
                    MemberID = member.MemberID,
                    LastName = member.LastName,
                    FirstName = member.FirstName,
                    Birthdate = member.Birthdate,
                    Address = member.Address,
                    Branch = member.Branch,
                    ContactNo = member.ContactNo,
                    Email = member.Email,
                    IsActive = status,
                };
                memresDTO.Add(memberDTO);
            }
            return memresDTO; 
        }

        public async Task<MemberIndexDTO> DetailMember(int id)
        {
            var status = "";
            var member = await _memberRepository.DetailMember(id);
            if (member.IsActive)
            {
                status = "YES";
            }
            else
            {
                status = "NO";
            }

            //Convert Member Entity to its DTO counterpart
            var memberDTO = new MemberIndexDTO(){
                MemberID = member.MemberID,
                LastName = member.LastName,
                FirstName = member.FirstName,
                Birthdate = member.Birthdate,
                Address = member.Address,
                Branch = member.Branch,
                ContactNo = member.ContactNo,
                IsActive = status,
            };
            return memberDTO;
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
        public async Task<IEnumerable> GetAllActive()
        {
            var membersDTO = (IEnumerable<Member>)await _memberRepository.GetAllActive();
            List<MemberActiveInactiveDTO> memresDTO = new List<MemberActiveInactiveDTO>();
            foreach (var member in membersDTO)
            {
                var memberDTO = new MemberActiveInactiveDTO()
                {
                    MemberID = member.MemberID,
                    LastName = member.LastName,
                    FirstName = member.FirstName,
                    Birthdate = member.Birthdate,
                    Address = member.Address,
                    Branch = member.Branch,
                    ContactNo = member.ContactNo,
                    Email = member.Email,
                };
                memresDTO.Add(memberDTO);
            }
            return memresDTO;
        }

        public async Task<IEnumerable> GetAllInactive()
        {
            var membersDTO = (IEnumerable<Member>)await _memberRepository.GetAllInactive();
            List<MemberActiveInactiveDTO> memresDTO = new List<MemberActiveInactiveDTO>();
            foreach (var member in membersDTO)
            {
                var memberDTO = new MemberActiveInactiveDTO()
                {
                    MemberID = member.MemberID,
                    LastName = member.LastName,
                    FirstName = member.FirstName,
                    Birthdate = member.Birthdate,
                    Address = member.Address,
                    Branch = member.Branch,
                    ContactNo = member.ContactNo,
                    Email = member.Email,
                };
                memresDTO.Add(memberDTO);
            }
            return memresDTO;
        }
    }
}
