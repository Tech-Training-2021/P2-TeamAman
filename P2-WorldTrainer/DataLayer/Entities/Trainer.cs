using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Entities
{
    public partial class Trainer
    {
        public Trainer()
        {
            TrainerDetails = new HashSet<TrainerDetail>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TrainerDetail> TrainerDetails { get; set; }
    }
}
