using ChatRoom.Models;
using ChatRoom.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public readonly UserManager<IdentityUser> _UserManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _UserService;
        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, IUserService userService)
        {
            _logger = logger;
            _UserManager = userManager;
            _UserService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _UserManager.GetUserAsync(User);
            var appUser = await _UserService.GetApplicationUser(user.Id);
            
            return View(appUser);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
