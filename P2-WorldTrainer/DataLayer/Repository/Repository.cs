using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.Repository
{
    public class Repository : IRepository
    {
        WorldTrainerDbContext _context;
        public Repository(WorldTrainerDbContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            if (user != null)
            {
                _context.Add(user);
                _context.SaveChanges();
            }
        }

        public void AddTrainer(Trainer trainer)
        {
            if (trainer != null)
            {
                _context.Trainers.Add(trainer);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// It will check for Whether User detail is exist in database or not
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User checkUser(User user)
        {
            return _context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
        }
        /// <summary>
        /// It will check for Whether Trainer detail is exist in database or not
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Trainer checkTrainer(string Email,string Password)
        {
            return _context.Trainers.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
        }

        public IEnumerable<Skill> GetSkills()
        {
            return _context.Skills.ToList();
        }

        public void AddTrainerData(TrainerDetail obj)
        {
            _context.TrainerDetails.Add(obj);
            _context.SaveChanges();
        }

        public void AddTrainerSkill(TrainerSkill obj)
        {
            
            _context.TrainerSkills.Add(obj);
            _context.SaveChanges();
        }
        public Trainer GetTrainerById(int id)
        {
            if (id > 0)
            {
                var data = _context.Trainers.Where(d => d.Id == id).FirstOrDefault();
                return data;
            }
            else
            {
                return null;
            }
        }

        public Trainer EditUserDetail(int id)
        {
            Trainer data = _context.Trainers.Where(s => s.Id == id).FirstOrDefault();
            return data;
        }
        public void UpdateData(Trainer obj)
        {
            Trainer data = _context.Trainers.Where(s => s.Id == obj.Id).FirstOrDefault();
            data.FirstName = obj.FirstName;
            data.LastName = obj.LastName;
            data.Email = obj.Email;
            _context.SaveChanges();
        }
        public TrainerDetail GetMoreDetail(int id)
        {
            return _context.TrainerDetails.Where(u => u.TrainerId == id).FirstOrDefault();
        }
        public List<string> GetSkillName(int id)
        {
            List<string> list = new List<string>();
            var skill = _context.TrainerSkills.Where(o => o.TrainerId == id).ToList();
            foreach(var data in skill)
            {

                var SkillData = _context.Skills.Where(u=>u.Id==data.SkillId).FirstOrDefault();
                string name = SkillData.Name;
                list.Add(name);
            }
            return list;
        }
    }
}
