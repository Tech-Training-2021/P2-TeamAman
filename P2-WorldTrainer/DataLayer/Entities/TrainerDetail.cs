using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Entities
{
    public partial class TrainerDetail
    {
        public int Id { get; set; }
        public int Experience { get; set; }
        public string HighestQualification { get; set; }
        public int TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
