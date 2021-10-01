using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2_WorldTrainer.Models
{
    public class EditionalDetail
    {
        public int Experience { get; set; }
        public string HighestQualification { get; set; }

        public IList<string> Skills { get; set; }

    }
}
