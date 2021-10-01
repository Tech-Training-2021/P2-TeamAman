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
    }
}
