using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreToGo.Models
{
    public class SetModel
    {
        public int[] Score { get; set; }

        public TeamRotationModel[] TeamRotations { get; set; }

        public int Winner { get; set; }
    }
}