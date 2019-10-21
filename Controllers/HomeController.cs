using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GithubClone.Models;
using Microsoft.Extensions.Logging;

namespace GithubClone.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;

        public HomeController(MyContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("LoggedIn").HasValue)
            {
                int? Uid = HttpContext.Session.GetInt32("LoggedIn");
                User Current = DbContext.Users.FirstOrDefault(uid => uid.UserId == Uid);
                ViewBag.CurrentUser = Current;
                return View("Home");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("none")]
        public IActionResult None()
        {
            return View("NotComplete");
        }

        [HttpPost("SignUp")]
        public IActionResult SignUp(User newuser)
        {
            if(ModelState.IsValid)
            {
                if(DbContext.Users.Any(ue => ue.Email == newuser.Email))
                {
                    ModelState.AddModelError("Email", "That Email already exists!");
                }
                if(DbContext.Users.Any(ue => ue.UserName == newuser.UserName))
                {
                    ModelState.AddModelError("UserName", "That Username already exists!");
                }
                if(DbContext.Users.Any(ue => ue.Email == newuser.Email) || DbContext.Users.Any(ue => ue.UserName == newuser.UserName))
                {
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newuser.Password = Hasher.HashPassword(newuser, newuser.Password);
                DbContext.Add(newuser);
                DbContext.SaveChanges();
                int userId = newuser.UserId;
                HttpContext.Session.SetInt32("LoggedIn", userId);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost("LoginProcess")]
        public IActionResult LoginProcess(Login user)
        {
            if(ModelState.IsValid)
            {
                User emailInDb = DbContext.Users.FirstOrDefault(u => u.Email == user.UNEInput);
                User usernameInDb = DbContext.Users.FirstOrDefault(u => u.UserName == user.UNEInput);
                if(emailInDb != null || usernameInDb != null)
                {
                    if(usernameInDb != null)
                    {
                        var hasher = new PasswordHasher<Login>();
                        var result = hasher.VerifyHashedPassword(user, usernameInDb.Password, user.Password);
                        if(result == 0)
                        {
                            ModelState.AddModelError("Password", "Invalid password.");
                            return View("Index");
                        }
                        else
                        {
                            int userId = usernameInDb.UserId;
                            HttpContext.Session.SetInt32("LoggedIn", userId);
                            return RedirectToAction("Index");
                        }
                    }
                    else if(usernameInDb == null)
                    {
                        if(emailInDb != null)
                        {
                            var hasher = new PasswordHasher<Login>();
                            var result = hasher.VerifyHashedPassword(user, emailInDb.Password, user.Password);
                            if(result == 0)
                            {
                                ModelState.AddModelError("Password", "Invalid password.");
                                return View("Index");
                            }
                            else
                            {
                                int userId = emailInDb.UserId;
                                HttpContext.Session.SetInt32("LoggedIn", userId);
                                return RedirectToAction("Index");
                            }
                        }
                        else
                        {
                            return View("Index");
                        }
                    }
                    else
                    {
                        return View("Index");
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("{username}")]
        public IActionResult AccountPage(string username)
        {
            if(HttpContext.Session.GetInt32("LoggedIn") != null)
            {
                User CurrentUser = DbContext.Users.FirstOrDefault(uid => uid.UserId == HttpContext.Session.GetInt32("LoggedIn"));
                ViewBag.CurrentUser = CurrentUser;
                return View("AccountPage");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("new")]
        public IActionResult NewRepo()
        {
            if(HttpContext.Session.GetInt32("LoggedIn") != null)
            {
                User CurrentUser = DbContext.Users.FirstOrDefault(uid => uid.UserId == HttpContext.Session.GetInt32("LoggedIn"));
                ViewBag.CurrentUser = CurrentUser;
                return View("NewRepository");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("newRepoProcess")]
        public IActionResult NewRepoProcess(Repository newRepo)
        {
            if(ModelState.IsValid)
            {
                int? LoggedId = HttpContext.Session.GetInt32("LoggedIn");
                User LoggedUser = DbContext.Users.FirstOrDefault(uid => uid.UserId == LoggedId);
                DbContext.Repositories.Add(newRepo);
                DbContext.SaveChanges();
                return RedirectToAction("Repository", new{username = LoggedUser.UserName, repositoryName = newRepo.Name});
            }
            else
            {
                return View("NewRepository");
            }
        }

        [HttpGet("{username}/{repositoryName}")]
        public IActionResult Repository(Repository Repo, string username, string repositoryName)
        {
            if(HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                int? LoggedId = HttpContext.Session.GetInt32("LoggedIn");
                User LoggedUser = DbContext.Users.FirstOrDefault(uid => uid.UserId == LoggedId);
                ViewBag.CurrentUser = LoggedUser;
                Repository CurrentRepo = DbContext.Repositories
                    .Where(oid => oid.UserId == LoggedId)
                    .FirstOrDefault(rn => rn.Name == repositoryName);
                ViewBag.CurrentRepo = CurrentRepo;
                return View("RepoCode");
            }
        }

    }
}
