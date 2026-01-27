using MemberManagement.Application.Services;
using MemberManagement.Models;
using MemberManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MemberManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly MemberService _memberService;
        public HomeController(MemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Index()
        {
            var memberCount = _memberService.GetMemberCount();
            var memberCountVM = new MemberCountViewModel()
            {
                TotalMembers = memberCount[0],
                ActiveMembers = memberCount[1],
                InactiveMembers = memberCount[2],
            };

            return View(memberCountVM);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
