using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STG.Domain.Models
{
    public class TeamInSetInformation
    {
        public TeamInSetInformation()
        {
            Substitutions = new List<Substitution>();
        }

        public List<Substitution> Substitutions { get; set; }
        //rotation history
        //substitutions
        //time outs
    }
}
