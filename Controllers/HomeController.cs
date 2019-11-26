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

/*  
To Do List:
1. Perfect the css and detail of each page
2. Create and complete each page for individual repositories
3. Create and complete each page for users account
4. Make it so users can at least type their own code into the repositories they make
5. Attempt to implement the ability for users to upload code to their repository remotely
6. Use JS to make the topbar partial's search bar work like on github
7. Create a twitter style follower feature for following and being followed
8. Put all needed info into the home page (can't be done until followers are made)
9. Pull requests/actions
10. Create ability to clone code onto your machine
11. Write more tasks...
*/

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
                List<Repository> allRepos = DbContext.Repositories.Where(uid => uid.UserId == Uid).ToList();
                ViewBag.AllRepos = allRepos;
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

        //paths dealing with users account
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

        //paths that deal with new repositories
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

        //paths that deal with existing repositories
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

        [HttpGet("{username}/{repositoryName}/issues")]
        public IActionResult RepositoryIssues()
        {
            if(HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("");
            }
        }

        [HttpGet("{username}/{repositoryName}/pulls")]
        public IActionResult RepositoryPullRequests()
        {
            if(HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("");
            }
        }

        [HttpGet("{username}/{repositoryName}/actions/new")]
        public IActionResult RepositoryActions()
        {
            if(HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("");
            }
        }

        [HttpGet("{username}/{repositoryName}/projects")]
        public IActionResult RepositoryProjects()
        {
            if(HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("");
            }
        }

        [HttpGet("{username}/{repositoryName}/wiki")]
        public IActionResult RepositoryWiki()
        {
            if(HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("");
            }
        }

        [HttpGet("{username}/{repositoryName}/network/alerts")]
        public IActionResult RepositorySecurity()
        {
            if(HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("");
            }
        }

        [HttpGet("{username}/{repositoryName}/pulse")]
        public IActionResult RepositoryInsights()
        {
            if(HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("");
            }
        }

        [HttpGet("{username}/{repositoryName}/settings")]
        public IActionResult RepositorySettings()
        {
            if(HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("");
            }
        }

    }
}
