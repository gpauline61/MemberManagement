using AutoMapper;
using MemberManagement.Application.DTO.BranchDTO;
using MemberManagement.Application.DTO.MemberDTO;
using MemberManagement.Application.Interface;
using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
using System.Collections;

namespace MemberManagement.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        public BranchService(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable> GetAll()
        {
            var branches = (IEnumerable<Branch>)await _branchRepository.GetAll();

            List<BranchIndexDTO> branchesDTO = new List<BranchIndexDTO>();
            foreach (var branch in branches)
            {
                var branchDTO = _mapper.Map<BranchIndexDTO>(branch);

                branchesDTO.Add(branchDTO);
            }
            return branchesDTO;
        }

        public bool AddBranch(Branch branch)
        {
            if (_branchRepository.checkBranch(branch))
            {
                return false;
            }
            return _branchRepository.Add(branch);
        }

        public async Task<BranchDetailDTO> DetailBranch(int id)
        {
            if (_branchRepository.checkBranchId(id))
            {
                var branchBlank = new BranchDetailDTO();
                return branchBlank;
            }

            var branch = await _branchRepository.DetailBranch(id);

            var branchDTO = _mapper.Map<BranchDetailDTO>(branch);
            return branchDTO;
        }
        public async Task<BranchEditDTO> EditBranch(int id)
        {
            if (_branchRepository.checkBranchId(id))
            {
                var branchBlank = new BranchEditDTO();
                return branchBlank;
            }

            var branch = await _branchRepository.EditBranch(id);
            var branchDTO = _mapper.Map<BranchEditDTO>(branch);
            return branchDTO;
        }
        public async Task SaveEditBranch(int id, Branch branch)
        {
            _branchRepository.Update(branch);
        }

        public async Task<BranchDeleteDTO> DeleteBranch(int id)
        {
            if (_branchRepository.checkBranchId(id))
            {
                var branchBlank = new BranchDeleteDTO();
                return branchBlank;
            }

            var branch = await _branchRepository.DeleteBranch(id);
            var branchDTO = _mapper.Map<BranchDeleteDTO>(branch);
            return branchDTO;
        }

        public async Task DeleteConfirmed(int id)
        {
            await _branchRepository.DeleteConfirmed(id);
        }
    }
}
