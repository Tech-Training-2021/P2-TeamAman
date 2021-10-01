using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IRepository
    {
        void Add(User user);
        void AddTrainer(Trainer trainer);
    }
}
