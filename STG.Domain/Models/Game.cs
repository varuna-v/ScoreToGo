using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.Domain.Models
{
    public class Game : ModelBase
    {
        public Team[] Teams { get; set; }
        public GamePlay GamePlay { get; set; }
        public DateTime StartedAt { get; set; }
    }
}
