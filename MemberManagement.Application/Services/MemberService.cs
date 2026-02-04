using MemberManagement.Application.DTO;
using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
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

        //Get all Members
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

                //convert to a DTO before transfering back to the Controller
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

        //Get Member's details
        public async Task<MemberIndexDTO> DetailMember(int id)
        {
            var status = "";
            //check if the members to show details exist in the list
            //If id does not exist, return an empty DTO
            if (_memberRepository.checkMemberId(id))
            {
                var memberBlank = new MemberIndexDTO();
                return memberBlank;
            }

            //if Member exists
            //Get the member's details from the repository
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
        public async Task<Member> EditMember(int id)
        {
            //Check if member to edit exists
            //If not, will return an empty Member entity
            if (_memberRepository.checkMemberId(id))
            {
                var memberBlank = new Member();
                return memberBlank;
            }

            //else, will proceed to get details of the member to be edited
            return await _memberRepository.EditMember(id);
        }

        //Saving the edit form of a member after submitting the form
        public async Task SaveEditMember(int id, Member member)
        {
            await _memberRepository.SaveEditMember(id, member);
        }

        //Soft deleting a member
        public async Task<Member> DeleteMember(int id)
        {
            //Check if member to delete exists
            //If non existent, will return a blank Member entity
            if (_memberRepository.checkMemberId(id))
            {
                var memberBlank = new Member();
                return memberBlank;
            }

            //Else, if member exists, will proceed in soft deleting the member
            return await _memberRepository.DeleteMember(id);

        }

        //Process in deleting the found member
        public async Task DeleteConfirmed(int id)
        {
            await _memberRepository.DeleteConfirmed(id);
        }

        //Getting all Active Members (IsActive == True)
        public async Task<IEnumerable> GetAllActive()
        {
            var membersDTO = (IEnumerable<Member>)await _memberRepository.GetAllActive();
            List<MemberActiveInactiveDTO> memresDTO = new List<MemberActiveInactiveDTO>();
            
            //convert each found member to a DTO
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

        //Getting all Inactive Members (IsActive == False)
        public async Task<IEnumerable> GetAllInactive()
        {
            var membersDTO = (IEnumerable<Member>)await _memberRepository.GetAllInactive();
            List<MemberActiveInactiveDTO> memresDTO = new List<MemberActiveInactiveDTO>();

            //convert each found member to a DTO
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
