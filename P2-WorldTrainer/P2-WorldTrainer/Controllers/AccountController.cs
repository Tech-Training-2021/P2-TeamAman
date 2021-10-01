using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using P2_WorldTrainer.Models;
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
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register user)
        {
            user.Role = "User";
            if (ModelState.IsValid)
            {
                if (user.Role == "User")
                {
                    repo.Add(Mapper.Map(user));
                }
                else if (user.Role == "Trainer")
                {
                    repo.AddTrainer(Mapper.MapT(user));
                }
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
