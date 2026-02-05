using AutoMapper;
using MemberManagement.Application.DTO;
using MemberManagement.Domain.Interfaces;
using System.Collections;
using Member = MemberManagement.Domain.Entities.Member;

namespace MemberManagement.Application.Services
{
    public class MemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        //Get all Members
        public async Task<IEnumerable> GetAll()
        {
            
            var members = (IEnumerable<Member>)await _memberRepository.GetAll();

            List<MemberIndexDTO> membersDTO = new List<MemberIndexDTO>();
            foreach (var member in members)
            {
                //convert to a DTO before transfering back to the Controller
                var memberDTO = _mapper.Map<MemberIndexDTO>(member);
                memberDTO.IsActive = member.IsActive ? "YES" : "NO";
                membersDTO.Add(memberDTO);
            }
            return membersDTO; 
        }

        //Get Member's details
        public async Task<MemberDetailDTO> DetailMember(int id)
        {
            var status = "";
            //check if the members to show details exist in the list
            //If id does not exist, return an empty DTO
            if (_memberRepository.checkMemberId(id))
            {
                var memberBlank = new MemberDetailDTO();
                return memberBlank;
            }

            //if Member exists
            //Get the member's details from the repository
            var member = await _memberRepository.DetailMember(id);

            //Convert Member Entity to its DTO counterpart
            var memberDTO = _mapper.Map<MemberDetailDTO>(member);
            return memberDTO;
        }

        //Adding new member
        public bool AddMember(Member member)
        {
            //Check if Member already exists by checking the Last name, 
            //first name and birthdate inputs from the user
            //Will return true indicating that the member to be added
            //is already in the list
            if (_memberRepository.checkMember(member))
            {
                return false;
            }

                //else will continue to save the new member
                return _memberRepository.Add(member);
        }

        //Edit a member
        public async Task<MemberEditDTO> EditMember(int id)
        {
            //Check if member to edit exists
            //If not, will return an empty Member entity
            if (_memberRepository.checkMemberId(id))
            {
                var memberBlank = new MemberEditDTO();
                return memberBlank;
            }

            //else, will proceed to get details of the member to be edited
            var member = await _memberRepository.EditMember(id);
            var memberDTO = _mapper.Map<MemberEditDTO>(member);
            return memberDTO;
        }

        //Saving the edit form of a member after submitting the form
        public async Task SaveEditMember(int id, Member member)
        {
            await _memberRepository.SaveEditMember(id, member);
        }

        //Soft deleting a member
        public async Task<MemberDetailDTO> DeleteMember(int id)
        {
            //Check if member to delete exists
            //If non existent, will return a blank Member entity
            if (_memberRepository.checkMemberId(id))
            {
                var memberBlank = new MemberDetailDTO();
                return memberBlank;
            }

            //Else, if member exists, will proceed in soft deleting the member
            var member = await _memberRepository.DeleteMember(id);
            var memberDTO = _mapper.Map<MemberDetailDTO>(member);
            return memberDTO;

        }

        //Process in deleting the found member
        public async Task DeleteConfirmed(int id)
        {
            await _memberRepository.DeleteConfirmed(id);
        }

        //Getting all Active Members (IsActive == True)
        public async Task<IEnumerable> GetAllActive()
        {
            var members = (IEnumerable<Member>)await _memberRepository.GetAllActive();
            List<MemberActiveInactiveDTO> membersDTO = new List<MemberActiveInactiveDTO>();
            
            //convert each found member to a DTO
            foreach (var member in members)
            {
                var memberDTO = _mapper.Map<MemberActiveInactiveDTO>(member);
                membersDTO.Add(memberDTO);

            }
            return membersDTO;
        }

        //Getting all Inactive Members (IsActive == False)
        public async Task<IEnumerable> GetAllInactive()
        {
            var members = (IEnumerable<Member>)await _memberRepository.GetAllInactive();
            List<MemberActiveInactiveDTO> membersDTO = new List<MemberActiveInactiveDTO>();

            //convert each found member to a DTO
            foreach (var member in members)
            {
                var memberDTO = _mapper.Map<MemberActiveInactiveDTO>(member);
                membersDTO.Add(memberDTO);
            }
            return membersDTO;
        }


    }
}
