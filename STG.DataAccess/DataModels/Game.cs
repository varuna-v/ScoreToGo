using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DataAccess.DataModels
{
    public class Game : RavenDocumentBase
    {
        public Team[] Teams { get; set; }
        public GamePlay GamePlay { get; set; }
        public DateTime StartedAt { get; set; }
    }
}
