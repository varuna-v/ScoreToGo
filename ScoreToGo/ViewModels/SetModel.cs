using STG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreToGo.ViewModels
{
    public class SetModel
    {
        public int[] Score { get; set; }

        public TeamRotationModel[] TeamRotations { get; set; }

        public int FirstServer { get; set; }

        public int Winner { get; set; }

        public TeamInSetInformation[] Information { get; set; }
    }
}