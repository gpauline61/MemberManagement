using MemberManagement.Application.Services;
using MemberManagement.Domain.Entities;
using MemberManagement.Models;
using MemberManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MemberManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;
        public HomeController(HomeService homeService)
        {
            _homeService = homeService;
        }
        public IActionResult Index()
        {
            var memberCount = _homeService.GetMemberCount();
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
