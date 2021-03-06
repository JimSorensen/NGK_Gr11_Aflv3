﻿using System;
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

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		// GET /account/Register
		[AllowAnonymous]
		public IActionResult Register() => View();


		// Post /account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(User user)
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

		// GET /account/Login
		[AllowAnonymous]
		public IActionResult Login(string returnUrl)
		{
			Login login = new Login
			{
				ReturnUrl = returnUrl
			};
			return View(login);
		}

		// Post /account/login
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(Login login)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = await userManager.FindByEmailAsync(login.Email);
				if (appUser != null)
				{
					Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync
						(appUser, login.Password, false, false);
					if (result.Succeeded)
						return Redirect(login.ReturnUrl ?? "/");
				}
				ModelState.AddModelError("", " Login failed, wrong credentials");
			}
			return View(login);
		}

		// GET /account/Logout
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return Redirect("/");
		}
	}
}
