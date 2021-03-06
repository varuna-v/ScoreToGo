﻿using System;

namespace STG.Domain.Models
{
    public class Set
    {
        public int[] Score { get; set; } //!! move in to TeamInSetInformation
        public int FirstServer { get; set; }
        public int Winner { get; set; }
        public int SetNumber { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public TeamRotation[] TeamRotations { get; set; } //!! move in to TeamInSetInformation
        public TeamInSetInformation[] Information { get; set; }
    }
}
