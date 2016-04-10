using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DataAccess.DataModels
{
    public class Set
    {
        public int Id { get; set; }
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        public int SetNumber { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
    }
}
