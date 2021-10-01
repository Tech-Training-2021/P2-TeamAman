using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public User checkUser(User user)
        {
            return _context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
        }
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
    }
}
