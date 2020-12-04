using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NGK_G11_Aflv3.Models;

namespace NGK_G11_Aflv3.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> userManager;
		private readonly SignInManager<AppUser> signInManager;
		private IPasswordHasher<AppUser> passwordHasher;

		public AccountController(UserManager<AppUser> userManager,
							   SignInManager<AppUser> signInManager,
							  IPasswordHasher<AppUser> passwordHasher)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.passwordHasher = passwordHasher;
		}

		// GET /account/Register
		[AllowAnonymous]
		public IActionResult Register() => View();

		// Post /account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(AppUser user)
		{

			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser
				{
					UserName = user.UserName,
					Email = user.Email
				};

				IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

				if (result.Succeeded)
				{
					return RedirectToAction("Login");
				}
				else
				{
					foreach (IdentityError error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}
			return View(user);
		}		
	}
}
