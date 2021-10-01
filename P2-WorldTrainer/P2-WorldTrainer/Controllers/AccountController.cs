using DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2_WorldTrainer.Common;
using P2_WorldTrainer.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_WorldTrainer.Controllers
{
    public class AccountController : Controller
    {
        public readonly IRepository repo;

        public AccountController(IRepository _repo)
        {
            repo = _repo;
        }
      
        public IActionResult Login()
        {
            List<string> roleList = new List<string>();
            roleList.Add("Select role");
            roleList.Add("Trainer");
            roleList.Add("User");
            ViewBag.message = roleList;
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login user)
        {
            if (ModelState.IsValid)
            {
                if (user.Role == "User")
                {
                    var u = repo.checkUser(Mapper.Map(user));
                    if (u != null)
                    {
                        CookieOptions option = new CookieOptions();
                        option.Expires = DateTime.Now.AddDays(2);
                        Response.Cookies.Append("user_id", u.Id.ToString(), option);
                        Response.Cookies.Append("userrole", user.Role.ToString(), option);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "No User Exist");
                        return RedirectToAction("Login");
                    }
                }
                else if (user.Role == "Trainer")
                {
                    Encryption pass = new Encryption();
                    string EncryptedPass = pass.EncryptPassword(user.Password);
                    var u = repo.checkTrainer(user.Email,EncryptedPass);
                    if (u != null)
                    {
                        CookieOptions option = new CookieOptions();
                        option.Expires = DateTime.Now.AddDays(2);
                        Response.Cookies.Append("user_id", u.Id.ToString(), option);
                        Response.Cookies.Append("userrole", user.Role.ToString(), option);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "No User Exist");
                        return RedirectToAction("Login");
                    }
                }
            }
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            List<string> roleList = new List<string>();
            roleList.Add("Select role");
            roleList.Add("Trainer");
            roleList.Add("User");
            ViewBag.message = roleList;
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register user)
        {
            if (ModelState.IsValid)
            {
                if (user.Role == "User")
                {
                    repo.Add(Mapper.Map(user));
                    return RedirectToAction("Login");
                }
                else if (user.Role == "Trainer")
                {
                    repo.AddTrainer(Mapper.MapT(user));
                    return RedirectToAction("Login");
                }
            }
            return RedirectToAction("Register");
        }
       public IActionResult Logout()
        {
            if (Request.Cookies["user_id"] != null)
            {
                Response.Cookies.Delete("user_id");
            }
            if (Request.Cookies["userrole"] != null)
            {
                Response.Cookies.Delete("userrole");
            }

            return RedirectToAction("Login");
        }
    }
}
