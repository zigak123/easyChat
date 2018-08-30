using EasyChat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EasyChat.Hubs
{
    public class ChatHub: Hub
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        //private readonly EnvironmentVariableTarget info = await _signInManager.GetExternalLoginInfoAsync();

        public ChatHub(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task SendMessage(string user, string message)
        {
            System.Diagnostics.Debug.WriteLine(this.Context.User.Identity.Name);
            System.Diagnostics.Debug.WriteLine(this.Context.User);
            
                
            
            await Clients.User(Context.UserIdentifier).SendAsync("ReceiveMessage", user, message);
        }
    }
}
