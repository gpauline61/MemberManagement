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
        public async Task<IActionResult> Index()
        {
            var status = "";
            IEnumerable<MemberIndexDTO> membersDTO = (IEnumerable<MemberIndexDTO>)await _memberService.GetAll();
            
            List<MemberIndexViewModel> memberResultViewModel = new List<MemberIndexViewModel>();
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

        public async Task<IActionResult> IndexActive()
        {
            IEnumerable<MemberActiveInactiveDTO> membersDTO = (IEnumerable<MemberActiveInactiveDTO>)await _memberService.GetAllActive();
            List<MemberActiveInactiveViewModel> memberResultViewModel = new List<MemberActiveInactiveViewModel>();
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

        //Index page for Inactive Members
        public async Task<IActionResult> IndexInactive()
        {
            IEnumerable<MemberActiveInactiveDTO> membersDTO = (IEnumerable<MemberActiveInactiveDTO>)await _memberService.GetAllInactive();
            List<MemberActiveInactiveViewModel> memberResultViewModel = new List<MemberActiveInactiveViewModel>();
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

        public async Task<IActionResult> Detail(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberDTO = await _memberService.DetailMember(id);
            if (memberDTO == null)
            {
                return NotFound();
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

        public IActionResult Create()
        {
            var memberCreateViewModel = new MemberCreateViewModel();
            return View(memberCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            if (ModelState.IsValid)
            {
                _memberService.AddMember(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _memberService.EditMember(id);
            if (member == null)
            {
                return NotFound();
            }
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
            return View(memberViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Member member)
        {
            if (id != member.MemberID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _memberService.SaveEditMember(id, member);
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var member = await _memberService.DeleteMember(id);
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
