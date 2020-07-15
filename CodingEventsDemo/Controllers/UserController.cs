﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.ViewModels;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEventsDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;

        public UserController(UserManager<User> u)
        {
            userManager = u;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            UserRegistrationViewModel userRegistrationViewModel = new UserRegistrationViewModel();
            return View(userRegistrationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessRegistrationForm(UserRegistrationViewModel userRegistrationViewModel)
        {
            if(ModelState.IsValid)
            {
                var newUser = new User
                {
                    Name = userRegistrationViewModel.Name,
                    UserName = userRegistrationViewModel.Username,
                    Email = userRegistrationViewModel.Email
                };

                var result = await userManager.CreateAsync(newUser, userRegistrationViewModel.Password);

                if (result.Succeeded)
                {
                    return Redirect("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }

                    return View(userRegistrationViewModel);
                }
            }
            return View(userRegistrationViewModel);
        }
    }
}