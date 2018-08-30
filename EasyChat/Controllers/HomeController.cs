using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyChat.Models;
using EasyChat.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EasyChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;

        public HomeController(IHubContext<ChatHub> hubContext,SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {     
            _signInManager = signInManager;
            _userManager = userManager;
            _hubContext = hubContext;
        }


        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> Drek()
        {

            
            var identity = (ClaimsIdentity) User.Identity;
            //await _signInManager.SignOutAsync();
            var shit = await _signInManager.GetExternalAuthenticationSchemesAsync();
            var shit1 = await _signInManager.GetExternalLoginInfoAsync();
            // var shit3 = await _userManager.FindByNameAsync(User.Identity.Name);
            //await _signInManager.Context.User.Identity.
           
            return View("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
