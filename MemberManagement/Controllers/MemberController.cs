using MemberManagement.Application.Services;
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
           var members = await _memberService.GetAll();
            return View();
        }
    }
}
