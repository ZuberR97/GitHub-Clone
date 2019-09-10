﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GithubClone.Models;

namespace GithubClone.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("SignUp")]
        public IActionResult SignUp(User newuser)
        {
            if(ModelState.IsValid)
            {
                User IsNewName = DbContext.Users.FirstOrDefault(un => un.UserName == newuser.UserName);
                User IsNewEmail = DbContext.Users.FirstOrDefault(ue => ue.Email == newuser.Email);
                if(IsNewEmail != null)
                {
                    ModelState.AddModelError("Email", "That Email already exists!");
                }
                if(IsNewName != null)
                {
                    ModelState.AddModelError("UserName", "That Username already exists!");
                }
                if(IsNewEmail != null || IsNewName != null)
                {
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newuser.Password = Hasher.HashPassword(newuser, newuser.Password);
                DbContext.Add(newuser);
                DbContext.SaveChanges();
                int userId = newuser.UserId;
                HttpContext.Session.SetInt32("loggeduser", userId);
                return RedirectToAction("Dashboard", new{userId = userId});
            }
            else
            {
                return View("Index");
            }
        }

    }
}
