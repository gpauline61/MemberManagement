using AutoMapper;
using MemberManagement.Application.DTO.BranchDTO;
using MemberManagement.Application.Interface;
using MemberManagement.Application.Services;
using MemberManagement.Domain.Entities;
using MemberManagement.Web.ViewModels.Branch;
using MemberManagement.Web.ViewModels.Member;
using Microsoft.AspNetCore.Mvc;

namespace MemberManagement.Web.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;
        public BranchController(IBranchService branchService, IMapper mapper)
        {
            _branchService = branchService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var branchesDTO = (IEnumerable<BranchIndexDTO>)
                await _branchService.GetAll();
            List<BranchIndexViewModel> branchResultViewModel =
                new List<BranchIndexViewModel>();

            //auto mapping of a DTO to ViewModel
            foreach (var branchDTO in branchesDTO)
            {
                var branchViewModel = _mapper.Map<BranchIndexViewModel>(branchDTO);
                branchResultViewModel.Add(branchViewModel);
            }
            return View(branchResultViewModel);
        }

        //Open the create member page
        public IActionResult Create()
        {
            var branchCreateViewModel = new BranchCreateViewModel();
            return View(branchCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                var checkBranch = _branchService.AddBranch(branch);
                if (checkBranch == false)
                {
                    ModelState.AddModelError("", "The branch you are trying to add is already in the list.");

                    var branchCreateViewModel = _mapper.Map<BranchCreateViewModel>(branch);

                    //Reopen the create page with the values entered
                    return View(branchCreateViewModel);
                }
                //else, success in creating the member will redirect to all members' page
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        //View a specific member
        public async Task<IActionResult> Detail(int id)
        {
             var branchDTO = await _branchService.DetailBranch(id);
             //check if Member exists
             if (branchDTO.BranchName == null)
             {
                 ModelState.AddModelError("", "The Branch you're trying to access does not exist.");
                 return View();
             }
             var branchViewModel = _mapper.Map<BranchDetailViewModel>(branchDTO);
             return View(branchViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var branchDTO = await _branchService.EditBranch(id);
            if (branchDTO.BranchName == null)
            {
                ModelState.AddModelError("", "The Branch you're trying to edit does not exist.");
                return View();
            }

            var branchViewModel = _mapper.Map<BranchEditViewModel>(branchDTO);

            return View(branchViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Branch branch)
        {
            if (id != branch.BranchID)
            {
                return NotFound();
            }
            //Check for input validation
            if (ModelState.IsValid)
            {
                await _branchService.SaveEditBranch(id, branch);
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var branchDTO = await _branchService.DeleteBranch(id);

            //Return an empty Delete page
            //since member does not exists
            if (branchDTO.BranchName == null)
            {
                ModelState.AddModelError("", "The Branch you're trying to delete does not exist.");
                return View();
            }

            //Else, will continue to open the delete page with the member's details
            var branchViewModel = _mapper.Map<BranchDeleteViewModel>(branchDTO);

            return View(branchViewModel);
        }

        //Process to replace IsActive value to false
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _branchService.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
