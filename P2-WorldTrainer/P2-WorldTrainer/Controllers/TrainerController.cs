using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Repository;

namespace P2_WorldTrainer.Controllers
{
    public class TrainerController : Controller
    {
        public readonly IRepository repo;

        public TrainerController(IRepository _repo)
        {
            repo = _repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddDetails()
        {
            List<Skill> skill = new List<Skill>();
            var skills = repo.GetSkills();
            skill = (from c in skills select c).ToList();
            skill.Insert(0, new Skill { Id = 0, Name = "--Select Skill--" });
            ViewBag.message = skill;
            return View();
        }
        [HttpPost]
        public IActionResult AddDetails(Models.AddMoreTrainerDetails obj)
        {
            int id = 1;
            if (ModelState.IsValid)
            {
                repo.AddTrainerData(Mapper.Map(obj, id));
                foreach (int skillId in obj.Skill_Id)
                {
                    repo.AddTrainerSkill(Mapper.MapSkill(skillId, id));
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Please Fill all Data");
            return RedirectToAction("AddDetails");
        }
    }
}
