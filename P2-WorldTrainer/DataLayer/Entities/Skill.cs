using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            TrainerSkills = new HashSet<TrainerSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TrainerSkill> TrainerSkills { get; set; }
    }
}
