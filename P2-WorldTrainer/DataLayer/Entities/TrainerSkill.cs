using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Entities
{
    public partial class TrainerSkill
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int SkillId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
