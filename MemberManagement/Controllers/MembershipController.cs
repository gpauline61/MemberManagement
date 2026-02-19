using AutoMapper;
using MemberManagement.Application.DTO.MemberDTO;
using MemberManagement.Application.DTO.MembershipDTO;
using MemberManagement.Application.Interface;
using MemberManagement.Application.Services;
using MemberManagement.Domain.Entities;
using MemberManagement.Web.ViewModels.MembershipVM;
using MemberManagement.Web.ViewModels.MemberVM;
using Microsoft.AspNetCore.Mvc;

namespace MemberManagement.Web.Controllers
{
    public class MembershipController : Controller
    {
        private readonly IMembershipService _membershipservice;
        private readonly IMapper _mapper;

        public MembershipController(IMembershipService membershipService, IMapper mapper)
        {
            _membershipservice = membershipService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var membershipsDTO = (IEnumerable<MembershipIndexDTO>)
                await _membershipservice.GetAll();

            List<MembershipIndexViewModel> membershipResultViewModel =
                new List<MembershipIndexViewModel>();

            foreach (var membershipDTO in membershipsDTO)
            {
                var membershipViewModel = _mapper.Map<MembershipIndexViewModel>(membershipDTO);
                membershipResultViewModel.Add(membershipViewModel);
            }
            return View(membershipResultViewModel);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var membershipDTO = await _membershipservice.DetailMembership(id);
            //check if Member exists
            if (membershipDTO.MembershipType == null)
            {
                ModelState.AddModelError("", "The Membership you're trying to access does not exist.");
                return View();
            }
            var membershipViewModel = _mapper.Map<MembershipDetailViewModel>(membershipDTO);
            return View(membershipViewModel);
        }

        public IActionResult Create()
        {
            var membershipCreateViewModel = new MembershipCreateViewModel();
            return View(membershipCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MembershipCreateViewModel membershipViewModel)
        {
            var membership = _mapper.Map<Membership>(membershipViewModel);
            if (ModelState.IsValid)
            {
                var checkMembership = _membershipservice.AddMembership(membership);
                if (checkMembership == false)
                {
                    ModelState.AddModelError("", "The membership you are trying to add is already in the list.");

                    var membershipCreateViewModel = _mapper.Map<MembershipCreateViewModel>(membership);

                    return View(membershipCreateViewModel);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(membership);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var membershipDTO = await _membershipservice.EditMembership(id);
            //Check if a member exists
            //If not, will create an error and open an empty Edit page
            if (membershipDTO.MembershipType == null)
            {
                ModelState.AddModelError("", "The Membership you're trying to edit does not exist.");
                return View();
            }

            //Else will continue to open the Edit page with the member's details
            var membershipViewModel = _mapper.Map<MembershipEditViewModel>(membershipDTO);

            //Else return to the page of Edit with the member's details
            return View(membershipViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MembershipEditViewModel membershipViewModel)
        {
            if (id != membershipViewModel.MembershipID)
            {
                return NotFound();
            }
            var membership = _mapper.Map<Membership>(membershipViewModel);
            //Check for input validation
            if (ModelState.IsValid)
            {
                await _membershipservice.SaveEditMembership(id, membership);
                return RedirectToAction("Index");
            }
            return View(membership);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var membershipDTO = await _membershipservice.DeleteMembership(id);

            if (membershipDTO.MembershipType == null)
            {
                ModelState.AddModelError("", "The Membership you're trying to delete does not exist.");
                return View();
            }

            var membershipViewModel = _mapper.Map<MembershipDetailViewModel>(membershipDTO);

            return View(membershipViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _membershipservice.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
