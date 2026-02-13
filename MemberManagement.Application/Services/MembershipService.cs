using AutoMapper;
using AutoMapper.Execution;
using MemberManagement.Application.DTO.MemberDTO;
using MemberManagement.Application.DTO.MembershipDTO;
using MemberManagement.Application.Interface;
using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Application.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;

        public MembershipService(IMembershipRepository memberRepository, IMapper mapper)
        {
            _membershipRepository = memberRepository;
            _mapper = mapper;
        }

        public bool AddMembership(Membership membership)
        {
            if (_membershipRepository.checkMembership(membership))
            {
                return false;
            }
            //else will continue to save the new member
            return _membershipRepository.Add(membership);
        }

        public async Task DeleteConfirmed(int id)
        {
            await _membershipRepository.DeleteConfirmed(id);
        }

        public async Task<MembershipDetailDTO> DeleteMembership(int id)
        {
            if (_membershipRepository.checkMembershipId(id))
            {
                var membershipBlank = new MembershipDetailDTO();
                return membershipBlank;
            }

            //Else, if member exists, will proceed in soft deleting the member
            var membership = await _membershipRepository.DeleteMembership(id);
            var membershipDTO = _mapper.Map<MembershipDetailDTO>(membership);
            return membershipDTO;
        }

        public async Task<MembershipDetailDTO> DetailMembership(int id)
        {
            if (_membershipRepository.checkMembershipId(id))
            {
                var membershipBlank = new MembershipDetailDTO();
                return membershipBlank;
            }

            //if Member exists
            //Get the member's details from the repository
            var membership = await _membershipRepository.DetailMembership(id);

            //Convert Member Entity to its DTO counterpart
            var membershipDTO = _mapper.Map<MembershipDetailDTO>(membership);
            return membershipDTO;
        }

        public async Task<MembershipEditDTO> EditMembership(int id)
        {
            if (_membershipRepository.checkMembershipId(id))
            {
                var membershipBlank = new MembershipEditDTO();
                return membershipBlank;
            }

            //else, will proceed to get details of the member to be edited
            var membership = await _membershipRepository.EditMembership(id);
            var membershipDTO = _mapper.Map<MembershipEditDTO>(membership);
            return membershipDTO;
        }

        public async Task<IEnumerable> GetAll()
        {
            var memberships = (IEnumerable<Membership>)await _membershipRepository.GetAll();

            List<MembershipIndexDTO> membershipsDTO = new List<MembershipIndexDTO>();
            foreach (var membership in memberships)
            {
                //convert to a DTO before transfering back to the Controller
                var membershipDTO = _mapper.Map<MembershipIndexDTO>(membership);
                membershipsDTO.Add(membershipDTO);
            }
            return membershipsDTO;
        }

        public async Task SaveEditMembership(int id, Membership membership)
        {
            _membershipRepository.Update(membership);
        }
    }
}
