using MemberManagement.Application.DTO;
using MemberManagement.Application.Services;
using MemberManagement.Domain.Entities;
using MemberManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MemberManagement.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly MemberService _memberService;
        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
        }

        //View all members
        public async Task<IActionResult> Index()
        {
            var membersDTO = (IEnumerable<MemberIndexDTO>)
                await _memberService.GetAll();
            
            List<MemberIndexViewModel> memberResultViewModel = 
                new List<MemberIndexViewModel>();

            //manual mapping of a DTO to ViewModel
            foreach (var memberDTO in membersDTO)
            {
                var memberViewModel = new MemberIndexViewModel()
                {
                    MemberID = memberDTO.MemberID,
                    LastName = memberDTO.LastName,
                    FirstName = memberDTO.FirstName,
                    Birthdate = memberDTO.Birthdate,
                    Address = memberDTO.Address,
                    Branch = memberDTO.Branch,
                    ContactNo = memberDTO.ContactNo,
                    Email = memberDTO.Email,
                    IsActive = memberDTO.IsActive,
                };
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
                var memberViewModel = new MemberActiveInactiveViewModel()
                {
                    MemberID = memberDTO.MemberID,
                    LastName = memberDTO.LastName,
                    FirstName = memberDTO.FirstName,
                    Birthdate = memberDTO.Birthdate,
                    Address = memberDTO.Address,
                    Branch = memberDTO.Branch,
                    ContactNo = memberDTO.ContactNo,
                    Email = memberDTO.Email,
                };
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
                var memberViewModel = new MemberActiveInactiveViewModel()
                {
                    MemberID = memberDTO.MemberID,
                    LastName = memberDTO.LastName,
                    FirstName = memberDTO.FirstName,
                    Birthdate = memberDTO.Birthdate,
                    Address = memberDTO.Address,
                    Branch = memberDTO.Branch,
                    ContactNo = memberDTO.ContactNo,
                    Email = memberDTO.Email,
                };
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
            
            var memberViewModel = new MemberDetailViewModel()
            {
                MemberID = memberDTO.MemberID,
                LastName = memberDTO.LastName,
                FirstName = memberDTO.FirstName,
                Birthdate = memberDTO.Birthdate,
                Address = memberDTO.Address,
                Branch = memberDTO.Branch,
                ContactNo = memberDTO.ContactNo,
                Email = memberDTO.Email,
                IsActive = memberDTO.IsActive,
            };
            
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
                    var memberCreateViewModel = new MemberCreateViewModel()
                    {
                        LastName = member.LastName,
                        FirstName = member.FirstName,
                        Birthdate = member.Birthdate,
                        Address = member.Address,
                        Branch = member.Branch,
                        ContactNo = member.ContactNo,
                        Email = member.Email,
                    };
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
            var member = await _memberService.EditMember(id);
            //Check if a member exists
            //If not, will create an error and open an empty Edit page
            if (member.LastName == null)
            {
                ModelState.AddModelError("", "The Member you're trying to edit does not exist.");
                return View();
            }

            //Else will continue to open the Edit page with the member's details
            var memberViewModel = new MemberEditViewModel()
            {
                MemberID = member.MemberID,
                LastName = member.LastName,
                FirstName = member.FirstName,
                Birthdate = member.Birthdate,
                Address = member.Address,
                Branch = member.Branch,
                ContactNo = member.ContactNo,
                Email = member.Email,
                IsActive = member.IsActive,
            };

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
            var member = await _memberService.DeleteMember(id);

            //Return an empty Delete page
            //since member does not exists
            if (member.LastName == null)
            {
                ModelState.AddModelError("", "The Member you're trying to delete does not exist.");
                return View();
            }

            //Else, will continue to open the delete page with the member's details
            var status = "";
            if (member.IsActive)
            {
                status = "YES";
            }
            else
            {
                status = "NO";
            }
                var memberViewModel = new MemberDetailViewModel()
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
            return View(memberViewModel);
        }

        //Process to replace IsActive value to false
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _memberService.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
