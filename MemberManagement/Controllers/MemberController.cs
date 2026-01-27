using MemberManagement.Application.DTO;
using MemberManagement.Application.Services;
using MemberManagement.Domain.Entities;
using MemberManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

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
            IEnumerable<Member> members = (IEnumerable<Member>)await _memberService.GetAll();
            
            List<MemberIndexViewModel> memres = new List<MemberIndexViewModel>();
            foreach (var member in members)
            {
                if (member.IsActive)
                {
                    status = "YES";
                }
                else
                {
                    status = "NO";
                }
                var memberViewModel = new MemberIndexViewModel()
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
                memres.Add(memberViewModel);
            }
            return View(memres);
        }

        public async Task<IActionResult> Detail(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _memberService.DetailMember(id);
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
                IsActive = member.IsActive,
            };
            if (member == null)
            {
                return NotFound();
            }
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
                IsActive = member.IsActive,
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

        public async Task<IActionResult> IndexActive()
        {
            var status = "";
            IEnumerable<Member> members = (IEnumerable<Member>)await _memberService.GetAllActive();
            List<MemberActiveInactiveViewModel> memres = new List<MemberActiveInactiveViewModel>();
            foreach (var member in members)
            {
                if (member.IsActive)
                {
                    status = "YES";
                }
                else
                {
                    status = "NO";
                }
                var memberViewModel = new MemberActiveInactiveViewModel()
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
                memres.Add(memberViewModel);
            }
            return View(memres);
        }

        //Index page for Inactive Members
        public async Task<IActionResult> IndexInactive()
        {
            var status = "";
            IEnumerable<Member> members = (IEnumerable<Member>)await _memberService.GetAllInactive();
            List<MemberActiveInactiveViewModel> memres = new List<MemberActiveInactiveViewModel>();
            foreach (var member in members)
            {
                if (member.IsActive)
                {
                    status = "YES";
                }
                else
                {
                    status = "NO";
                }
                var memberViewModel = new MemberActiveInactiveViewModel()
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
                memres.Add(memberViewModel);
            }
            return View(memres);
        }
    }
}
