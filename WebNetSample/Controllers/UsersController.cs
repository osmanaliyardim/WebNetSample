﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebNetMVC.Areas.Identity.Roles;

namespace WebNetMVC.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();

            return View(users);
        }
    }
}
