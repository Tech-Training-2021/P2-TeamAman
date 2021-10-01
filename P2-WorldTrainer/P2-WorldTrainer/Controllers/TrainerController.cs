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
            int user_id = Convert.ToInt32(HttpContext.Request.Cookies["user_id"]);
            if (ModelState.IsValid)
            {
                repo.AddTrainerData(Mapper.Map(obj, user_id));
                foreach (int skillId in obj.Skill_Id)
                {
                    repo.AddTrainerSkill(Mapper.MapSkill(skillId, user_id));
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Please Fill all Data");
            return RedirectToAction("AddDetails");
        }

        public IActionResult Details()
        {
            int user_id = Convert.ToInt32(HttpContext.Request.Cookies["user_id"]);
            ViewBag.id = user_id;
            return View(Mapper.Map(repo.GetTrainerById(user_id)));
        }

        public IActionResult EditUser()
        {
            int user_id = Convert.ToInt32(HttpContext.Request.Cookies["user_id"]);
            Trainer data = repo.EditUserDetail(user_id);
            Models.EditProfile reg = new Models.EditProfile()
            {
                // Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
            };
            return View(reg);
        }
        [HttpPost]
        public IActionResult UpdateDetails(Models.EditProfile reg)
        {
            Trainer obj = new Trainer();
            obj.Id = Convert.ToInt32(HttpContext.Request.Cookies["user_id"]);
            obj.FirstName = reg.FirstName;
            obj.LastName = reg.LastName;
            obj.Email = reg.Email;

            repo.UpdateData(obj);
            return RedirectToAction("Details");
        }
        public IActionResult EditionalDetail()
        {
           int user_id = Convert.ToInt32(HttpContext.Request.Cookies["user_id"]);
            var data = repo.GetMoreDetail(user_id);
            var skills = repo.GetSkillName(user_id);
            if (data != null && skills!=null)
            {
                return View(Mapper.Map(data, skills));
            }
            return RedirectToAction("AddDetails");
        }
    }
}
