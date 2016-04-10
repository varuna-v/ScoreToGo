using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DataAccess.DataModels
{
    public class Game : RavenDocumentBase
    {
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public DateTime StartedAt{ get; set; }
        public DateTime EndedAt { get; set; }
        public Set[] Sets { get; set; }
    }
}
