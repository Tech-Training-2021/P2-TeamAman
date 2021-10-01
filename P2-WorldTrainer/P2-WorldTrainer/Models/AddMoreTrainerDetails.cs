using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
namespace P2_WorldTrainer.Models
{
    public class AddMoreTrainerDetails
    {
        [Required]
        [Range(0,40)]
        public int Experience { get; set; }
        [Required]

        public string HighestQualification { get; set; }
        [Required]

        public List<Skill> Skill_Id { get; set; }
    }
}
