using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Core.Entities;
using Store.Models;

namespace Store.Controllers
{
    public class AccountController : Controller
        {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;

            public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }

            [HttpGet]
            public IActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Register(RegisterModel model)
            {
                if (ModelState.IsValid)
                {
                    User user = new User
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        PhoneNumber = model.Number,
                        Email = model.Email,
                        UserName = model.Email

                    };

                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {

                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Profile", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }

                return View(model);
            }

            [HttpGet]
            public ViewResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<ActionResult> Login(LoginModel model)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var result = await _signInManager
                    .PasswordSignInAsync(model.Email, model.Password, true, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Profile", "Account");
                }
                else
                {


                    ModelState.AddModelError(string.Empty, "Incorrect login or password.");

                }

                return View();
            }

            [HttpGet]
            public async Task<ActionResult> Logout()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }


            [HttpGet]
            [Authorize]
            public async Task<ActionResult> Profile()
            {

                return View(await _userManager.FindByNameAsync(User.Identity.Name));

            }

            [HttpGet]
            [Authorize]
            public async Task<ActionResult> Edit()
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                var model = new EditViewModel
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email
                };
                return View(model);
            }

            [HttpPost]
            [Authorize]
            public async Task<ActionResult> Edit(EditViewModel model)
            {

                User user = await _userManager.FindByNameAsync(User.Identity.Name);


                user.Name = model.Name;
                user.Surname = model.Surname;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.UpdateAsync(user);
                    return RedirectToAction("Profile", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        return View(model);
                    }

                    //return View(await _userManager.FindByNameAsync(User.Identity.Name));
                }


                return RedirectToAction("Profile", "Account");

            }

            [HttpGet]
            [Authorize]
            public async Task<ActionResult> EditPassword()
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                var model = new EditPasswordModel()
                {
                    Email = user.Email
                };

                return View(model);
            }

            [HttpPost]
            [Authorize]
            public async Task<ActionResult> EditPassword(EditPasswordModel model)
            {

                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        await Logout();

                        return RedirectToAction("Login");

                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                            return View(model);
                        }
                    }
                }

                return RedirectToAction("Profile", "Account");

            }

        }

    }



