using DataLayer.Entities;
using P2_WorldTrainer.Common;
using P2_WorldTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_WorldTrainer
{
    public class Mapper
    {
        public static DataLayer.Entities.User Map(Models.Register user)
        {
            Encryption pass = new Encryption();
            return new DataLayer.Entities.User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = pass.EncryptPassword(user.Password)
            };
        }
        public static DataLayer.Entities.Trainer MapT(Models.Register user)
        {
            Encryption pass = new Encryption();
            return new DataLayer.Entities.Trainer()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = pass.EncryptPassword(user.Password)
            };
        }
        public static DataLayer.Entities.User Map(Models.Login user)
        {
            Encryption pass = new Encryption();
            return new DataLayer.Entities.User()
            {
                Email = user.Email,
                Password = pass.EncryptPassword(user.Password)
            };
        }
        public static DataLayer.Entities.TrainerDetail Map(Models.AddMoreTrainerDetails obj,int id)
        {
            return new DataLayer.Entities.TrainerDetail()
            {
               Experience=obj.Experience,
               HighestQualification=obj.HighestQualification,
               TrainerId = id
            };
        }
        public static DataLayer.Entities.TrainerSkill MapSkill(int skillId, int id)
        {
            return new DataLayer.Entities.TrainerSkill()
            {
                SkillId = skillId,
                TrainerId = id
            };
        }

    }
}
