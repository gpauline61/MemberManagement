using AutoMapper;
using MemberManagement.Application.DTO.MemberDTO;
using MemberManagement.Application.Interface;
using MemberManagement.Application.Services;
using MemberManagement.Web.ViewModels.MemberViewModel;
using Microsoft.AspNetCore.Mvc;
using Member = MemberManagement.Domain.Entities.Member;

namespace MemberManagement.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;
        public MemberController(MemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }

        //View all members
        public async Task<IActionResult> Index()
        {
            var membersDTO = (IEnumerable<MemberIndexDTO>)
                await _memberService.GetAll();
            
            List<MemberIndexViewModel> memberResultViewModel = 
                new List<MemberIndexViewModel>();

            //auto mapping of a DTO to ViewModel
            foreach (var memberDTO in membersDTO)
            {
                var memberViewModel = _mapper.Map<MemberIndexViewModel>(memberDTO);
                memberResultViewModel.Add(memberViewModel);
            }
            return View(memberResultViewModel);
        }

        //View all Active members
        public async Task<IActionResult> IndexActive()
        {
            var membersDTO = (IEnumerable<MemberActiveInactiveDTO>)
                await _memberService.GetAllActive();
            List<MemberActiveInactiveViewModel> memberResultViewModel = 
                new List<MemberActiveInactiveViewModel>();

            foreach (var memberDTO in membersDTO)
            {
                var memberViewModel = _mapper.Map<MemberActiveInactiveViewModel>(memberDTO);
                memberResultViewModel.Add(memberViewModel);
            }
            return View(memberResultViewModel);
        }

        //View all Inactive Members
        public async Task<IActionResult> IndexInactive()
        {
            var membersDTO = (IEnumerable<MemberActiveInactiveDTO>)
                await _memberService.GetAllInactive();
            List<MemberActiveInactiveViewModel> memberResultViewModel = 
                new List<MemberActiveInactiveViewModel>();
            foreach (var memberDTO in membersDTO)
            {
                var memberViewModel = _mapper.Map<MemberActiveInactiveViewModel>(memberDTO);
                memberResultViewModel.Add(memberViewModel);
            }
            return View(memberResultViewModel);
        }

        //View a specific member
        public async Task<IActionResult> Detail(int id)
        {
            var memberDTO = await _memberService.DetailMember(id);
            //check if Member exists
            if(memberDTO.LastName == null)
            {
                ModelState.AddModelError("", "The Member you're trying to access does not exist.");
                return View();
            }
            var memberViewModel = _mapper.Map<MemberDetailDeleteViewModel>(memberDTO);
            memberViewModel.IsActive = memberDTO.IsActive ? "YES" : "NO";
            return View(memberViewModel);
        }


        //Open the create member page
        public IActionResult Create()
        {
            var memberCreateViewModel = new MemberCreateViewModel();
            return View(memberCreateViewModel);
        }

        //Processing of creating a member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            //Check if all input are valid
            if (ModelState.IsValid)
            {
                var checkMember = _memberService.AddMember(member);
                //If the member to be added is already in the list
                //will create an error and will pass the current values
                //in the form given by the user
                if (checkMember == false) {
                    ModelState.AddModelError("", "The member you are trying to add is already in the list.");
                    
                    var memberCreateViewModel = _mapper.Map<MemberCreateViewModel>(member);
                    
                    //Reopen the create page with the values entered
                    return View(memberCreateViewModel);
                }
                    //else, success in creating the member will redirect to all members' page
                    return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        //Open the Edit page of a member
        public async Task<IActionResult> Edit(int id)
        {
            var memberDTO = await _memberService.EditMember(id);
            //Check if a member exists
            //If not, will create an error and open an empty Edit page
            if (memberDTO.LastName == null)
            {
                ModelState.AddModelError("", "The Member you're trying to edit does not exist.");
                return View();
            }

            //Else will continue to open the Edit page with the member's details
            var memberViewModel = _mapper.Map<MemberEditViewModel>(memberDTO);

            //Else return to the page of Edit with the member's details
            return View(memberViewModel);
        }

        //Process on saving the edited member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Member member)
        {
            if (id != member.MemberID)
            {
                return NotFound();
            }
            //Check for input validation
            if (ModelState.IsValid)
            {
                await _memberService.SaveEditMember(id, member);
                return RedirectToAction("Index");
            }
            return View(member);
        }

        //Open the delete page of a member
        public async Task<IActionResult> Delete(int id)
        {
            var memberDTO = await _memberService.DeleteMember(id);

            //Return an empty Delete page
            //since member does not exists
            if (memberDTO.LastName == null)
            {
                ModelState.AddModelError("", "The Member you're trying to delete does not exist.");
                return View();
            }

            //Else, will continue to open the delete page with the member's details
            var memberViewModel = _mapper.Map<MemberDetailDeleteViewModel>(memberDTO);
            memberViewModel.IsActive = memberDTO.IsActive ? "YES" : "NO";

            return View(memberViewModel);
        }

        //Process to replace IsActive value to false
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _memberService.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
